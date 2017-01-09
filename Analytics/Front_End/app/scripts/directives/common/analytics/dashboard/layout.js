angular.module("bitraz.dashboard", [])
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
        if($ctrl.config.userId){$ctrl.params.userId = $ctrl.config.userId;}
        if($ctrl.config.campaignId){$ctrl.params.campaignId = $ctrl.config.campaignId;}else{ delete $ctrl.params.campaignId;}
        return $ctrl.params;
      };

      $ctrl.$onInit = ()=>{
         $ctrl.getSummary();
      };

      $ctrl.$onChanges = (changes)=>{
        if(changes.data && !changes.data.isFirstChange()){
          $ctrl.getSummary();
        }
      }

    }]
  });