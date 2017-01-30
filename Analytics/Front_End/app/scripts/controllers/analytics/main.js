/**
 *
 * appCtrl
 *
 */

angular
  .module('bitraz.controllers', ['bitraz.auth', 'bitraz.common.controllers', 'bitraz.campaigns'])
    .controller('appCtrl', appCtrl)
    .controller('AppController', AppController)
    .controller('HeaderController', HeaderController)
    .controller('HomeController', HomeController)

    .controller('CampaignsController', CampaignsController)
    .controller('UsersController', UsersController)
    .controller('ArchievesController', ArchievesController)
    .controller('SettingsController', SettingsController)


function AppController($http, $scope) {}
function HeaderController($rootScope, $scope, $state, AuthService, appConfig, $window) {
  console.log('HeaderController', $state, AuthService, appConfig)
  $scope.active = $state.current.data.activeMenu;

  $rootScope.$on('$stateChangeStart', function (event, toState, toStateParams, fromState, fromStateParams) {
    $scope.active = toState.data.activeMenu;
  });
  
  $scope.logout = () => {
    AuthService.logout().$promise.then((res)=>{
      $window.location.href = '/';
      $rootScope.userInfo = {};
    }, (err)=>{})
  }
}
function HomeController($http, $scope, $rootScope) {

  $scope.dashboardConfig = {
    userId: $rootScope.userInfo.user_id,
    type: 'all',
    modules:[
      {name: 'urlGenerated', rank:1, span:1},
      {name: 'totalUsers', rank:1, span:1},
      {name: 'totalVisits', rank:1, span:1},
      {name: 'totalCampaigns', rank:1, span:1},
      {name: 'totalAnalyticVisits', rank:1, span:1},
      {name: 'recentCampaigns', rank:1, span:2},
      {name: 'totalActivity', rank:1, span:1}
    ]
  }

}

function CampaignsController($scope, $rootScope, $http, $uibModal, CampaignsCollectionModel, CampaignModel) {
    $scope.campaignListOptions = {
        enableSorting: true,
        columnDefs: [
          { name:'Name', field: 'CampaignName' },
          { name:'Is Protected', field: 'HasPassword', cellTemplate:'<div>' +
                                                             '<span ng-if="row.entity.HasPassword">Active</span>' +
                                                             '<span ng-if="!row.entity.HasPassword">In Active</span>' +
                                                             '&nbsp;' +
                                                             '</div>'},
          { name:'Created On', field: 'CreatedOn', type:'date', format:'mm/dd/yyyy' },
          { name:'Status', field: 'IsActive', cellTemplate:'<div>' +
                                                              '<span ng-if="row.entity.IsActive">Active</span>' +
                                                              '<span ng-if="!row.entity.IsActive">In Active</span>' +
                                                              '&nbsp;' +
                                                              '</div>'},
          { name:'Actions', cellTemplate:'<div>' +
                      '<a ng-click="grid.appScope.editCampaign(row.entity)">Edit</a>' +
                      '&nbsp;' +
                      '</div>'
          }
        ],
        data : []
      };

    $scope.errorMessage = "";
    $rootScope.pageLoading = true;

    $scope.refreshData = function () {
      $rootScope.pageLoading = true;
      CampaignsCollectionModel.getAll().then(function(response) {
        console.log(response);
        $scope.campaignListOptions.data = response;
        $rootScope.pageLoading = false;
      }, function errorCallback(response) {
        console.log('error', response);
        $rootScope.pageLoading = false;
        $scope.errorMessage = "Error: failed to load campaign info";
      });

    };

    $scope.editCampaign = function(_row) {
      var row = angular.copy(_row);
      var instance = $uibModal.open({
        animation: true,
        ariaLabelledBy: 'modal-title-top',
        ariaDescribedBy: 'modal-body-top',
        templateUrl: 'views/analytics/campaigns/edit_campaign.html',
        size: 'lg',
        controller: function($scope) {
          var $ctrl = this;
          $scope.name = 'top';

          $ctrl.newCampaign = row;

          $scope.save = function () {
            $ctrl.saveError = "";
            if($ctrl.newCampaignForm.$valid){
              $ctrl.newCampaign.save().then((resp)=>{
                _row = resp;
                instance.close();
              }, (err) => {
                $ctrl.saveError = err && err.message || "Failed to save user.";
              })
            }

          };

          $scope.cancel = function () {
            $ctrl.saveError = "";
            instance.dismiss('cancel');
          };

        },
        controllerAs: '$ctrl'
      });

    };

    $scope.addCampaign = function() {
      var instance = $uibModal.open({
        animation: true,
        ariaLabelledBy: 'modal-title-top',
        ariaDescribedBy: 'modal-body-top',
        templateUrl: 'views/analytics/campaigns/add_campaign.html',
        size: 'lg',
        controller: function($scope) {
          var $ctrl = this;
          $scope.name = 'top';

          $ctrl.newCampaign = new CampaignModel({});

          $scope.save = function () {
            $ctrl.saveError = "";
            if($ctrl.newCampaignForm.$valid){
              $ctrl.newCampaign.save().then((resp)=>{
                instance.close();
              }, (err) => {
                $ctrl.saveError = err && err.message || "Failed to save user.";
              })
            }

          };

          $scope.cancel = function () {
            $ctrl.saveError = "";
            instance.dismiss('cancel');
          };

        },
        controllerAs: '$ctrl'
      });
    };

    $scope.refreshData();
  }
function ArchievesController($http, $scope) {}
function SettingsController($http, $scope) {}
function UsersController($http, $scope) {}
function appCtrl($http, $scope) {

  console.log($scope, $http)


}


