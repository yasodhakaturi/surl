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
  console.log('HeaderController', $state, AuthService, appConfig);
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

function CampaignsController($http, $scope) {}
function ArchievesController($http, $scope) {}

function SettingsController($http, $scope) {}


function UsersController($scope, $http, $uibModal, UsersCollectionModel, UserModel) {

  $scope.userListOptions = {
      enableSorting: true,
      columnDefs: [
        { name:'Name', field: 'UserName' },
        { name:'Email', field: 'Email' },
        { name:'Active', field: 'IsActive'},
        { name:'Actions', cellTemplate:'<div>' +
                    '<a ng-click="grid.appScope.editUser(row.entity)">Edit</a>' +
                    '&nbsp; | &nbsp;<a ng-click="grid.appScope.changeUserPassword(row.entity)">Change Password</a>' +
                    '</div>'
        }
      ],
    data : []
    };
  
  $scope.refreshData = function () {
    UsersCollectionModel.getAll().then(function(response) {
      console.log(response);
      $scope.userListOptions.data = response;
    }, function errorCallback(response) {
      console.log('error', response);
    });
  };

  $scope.editUser = function(_row) {
    var row = angular.copy(_row);
    var instance = $uibModal.open({
      animation: true,
      ariaLabelledBy: 'modal-title-top',
      ariaDescribedBy: 'modal-body-top',
      templateUrl: 'views/admin/users/edit_user.html',
      size: 'lg',
      controller: function($scope) {
        var $ctrl = this;
        $scope.name = 'top';

        $ctrl.user = row;

        $scope.save = function () {
          $ctrl.saveError = "";
          if($ctrl.userForm.$valid){
            $ctrl.user.save().then((resp)=>{
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

  $scope.addUser = function() {
    var instance = $uibModal.open({
      animation: true,
      ariaLabelledBy: 'modal-title-top',
      ariaDescribedBy: 'modal-body-top',
      templateUrl: 'views/admin/users/add_user.html',
      size: 'lg',
      controller: function($scope) {
        var $ctrl = this;
        $scope.name = 'top';
        
        $ctrl.newUser = new UserModel({})

        $scope.save = function () {
          $ctrl.saveError = "";
          if($ctrl.newUserForm.$valid){
            $ctrl.newUser.save().then((resp)=>{
              console.log(resp)
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

  $scope.changeUserPassword = function(row) {
    var instance = $uibModal.open({
      animation: true,
      ariaLabelledBy: 'modal-title-top',
      ariaDescribedBy: 'modal-body-top',
      templateUrl: 'views/admin/users/change_password.html',
      size: 'lg',
      controller: function($scope) {
        var $ctrl = this;
        $scope.name = 'top';

        $ctrl.user = row;

        $scope.save = function () {
          $ctrl.saveError = "";
          if($ctrl.userForm.$valid){
            $ctrl.user.resetPassword().then((resp)=>{
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



function appCtrl($http, $scope) {
  // console.log($scope, $http)
}


