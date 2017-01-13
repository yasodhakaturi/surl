angular.module("bitraz.dashboard", ['ui.router'])
  .component("dashboardLayout", {
    templateUrl: "views/common/dashboard/dashboard_tmpl.html",
    bindings: {
      config: "<"
    },
    controller: ["$scope", "$rootScope", "$timeout", "RidService", function ($scope, $rootScope, $timeout, RidService) {
      var $ctrl = this;
      
      $ctrl.params = {};
      $ctrl.data = {};
      $rootScope.pageLoading = true;

      $ctrl.getSummary = () => {
        $rootScope.pageLoading = true;
        let summaryDefer = RidService.getSummary($ctrl.getParams()).$promise;
        summaryDefer.then((res)=>{
          $ctrl.data = res;
          $rootScope.pageLoading = false;
        }, (err)=>{
          $rootScope.pageLoading = false;
          console.log("failed to get summary", err);
        });
      };

      $ctrl.getParams = ()=> {
        if($ctrl.config.userId){$ctrl.params.cid = $ctrl.config.userId;}
        if($ctrl.config.campaignId){$ctrl.params.campaignId = $ctrl.config.campaignId;}else{ delete $ctrl.params.campaignId;}
        return $ctrl.params;
      };

      $ctrl.$onInit = ()=>{
        if(!( _.isNull($rootScope.userInfo && $rootScope.userInfo.user_id) || _.isUndefined($rootScope.userInfo && $rootScope.userInfo.user_id))){
          $ctrl.getSummary();
        }

      };

      $ctrl.$onChanges = (changes)=>{
        if(changes.config && !changes.config.isFirstChange()){
          if(!( _.isNull($rootScope.userInfo && $rootScope.userInfo.user_id) || _.isUndefined($rootScope.userInfo && $rootScope.userInfo.user_id))) {
            $ctrl.getSummary();
          }
        }
      }

    }]
  });