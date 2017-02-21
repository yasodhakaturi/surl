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

function CampaignsController($scope, $rootScope, $http, $uibModal, UsersCollectionModel, CampaignsCollectionModel, CampaignModel) {
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
          { name:'Created By', field: 'CreatedUserName' },

          { name:'Status', field: 'IsActive', cellTemplate:'<div>' +
                                                              '<span ng-if="row.entity.IsActive">Active</span>' +
                                                              '<span ng-if="!row.entity.IsActive">In Active</span>' +
                                                              '&nbsp;' +
                                                              '</div>'},
          { name:'Generate url\'s', cellTemplate:'<div>' +
          '&nbsp;&nbsp;<a ng-click="grid.appScope.generateUrls(row.entity)">Click</a>' +
          '&nbsp;' +
          '</div>'},
          { name:'Actions', cellTemplate:'<div>' +
                      '<a ng-click="grid.appScope.editCampaign(row.entity)">Edit</a>' +
                      '&nbsp;&nbsp;&nbsp;' +
                      '<a ui-sref="bitraz.main.analytics({rid:row.entity.ReferenceNumber})" >View</a>' +
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
        $scope.campaignListOptions.data = response;
        $rootScope.pageLoading = false;
      }, function errorCallback(response) {
        $rootScope.pageLoading = false;
        $scope.errorMessage = "Error: failed to load campaign info";
      });

      UsersCollectionModel.getAll().then(function(response) {
            $scope.usersList = response;
          }, function errorCallback(response) {
            console.log('error', response);
          });
    };

    $scope.editCampaign = function(_row) {
      var row = angular.copy(_row);
      var instance = $uibModal.open({
        animation: true,
        ariaLabelledBy: 'modal-title-top',
        ariaDescribedBy: 'modal-body-top',
        templateUrl: 'views/admin/campaigns/edit_campaign.html',
        size: 'lg',
        controller: function($scope, customers) {
          var $ctrl = this;
          $scope.name = 'top';

          $ctrl.newCampaign = row;

          $ctrl.customerList = customers;

          $scope.save = function () {
            $ctrl.saveError = "";
            if($ctrl.newCampaignForm.$valid){
              $ctrl.newCampaign.save().then((resp)=>{

                _row = angular.extend(_row,resp);
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
        resolve: {
          'customers': ()=>{ return $scope.usersList; }
        },
        controllerAs: '$ctrl'
      });

    };

    $scope.addCampaign = function() {
      var instance = $uibModal.open({
        animation: true,
        ariaLabelledBy: 'modal-title-top',
        ariaDescribedBy: 'modal-body-top',
        templateUrl: 'views/admin/campaigns/add_campaign.html',
        size: 'lg',
        controller: function($scope, customers, parentScope) {
          var $ctrl = this;
          $scope.name = 'top';

          $ctrl.newCampaign = new CampaignModel({});
          $ctrl.customerList = customers;

          $scope.save = function () {
            $ctrl.saveError = "";
            if($ctrl.newCampaignForm.$valid){
              $ctrl.newCampaign.save().then((resp)=>{
              parentScope.campaignListOptions.data.push(resp);
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
       resolve: {
         'customers': ()=>{ return $scope.usersList; },
         'parentScope': ()=>{ return $scope;}
       },
        controllerAs: '$ctrl'
      });
    };

    $scope.refreshData();


    $scope.generateUrls = function(_row){
        var row = angular.copy(_row);
        var instance = $uibModal.open({
          animation: true,
          ariaLabelledBy: 'modal-title-top',
          ariaDescribedBy: 'modal-body-top',
          templateUrl: 'views/admin/campaigns/generate_campaign_url.html',
          size: 'lg',
          backdrop: 'static',
          keyboard: false,
          controller: function($scope, campaign) {
            var $ctrl = this;
            $ctrl.campaign = campaign;
            $ctrl.campaign.generator = {"simple": {}, "advanced":{}, "upload":{}};
            $ctrl.activeTab = 'simple';
            $ctrl.campaignForm = {"simple": {}, "advanced":{}, "upload":{}};
            $ctrl.generation = false;
            $scope.generate = function (form ,type) {
              console.log(form, type);
              $ctrl.saveError = "";
              if($ctrl.campaignForm[type].$valid){
                if(type == 'simple' || type == 'advanced'){
                  $ctrl.generation = true;
                  $ctrl.campaign.generate({LongUrl: form.longurl, MobileNumbers: $scope.sanitizeMobileNumbers(form.mobileNumbers, type)}, type).then((resp)=>{
                    console.log(resp);
                    $ctrl.generation = false;
                  }, (err) => {
                    $ctrl.generation = false;
                    $ctrl.saveError = err && err.message || "Failed to save user.";
                  });
                }else if(type == 'upload'){

                }
              }

            };

            $scope.sanitizeMobileNumbers = (mobileNumbers, type) => {
              if(type == 'advanced'){
                return mobileNumbers.replace(/\r\n|\n/g,",").replace(/\s/g, '').split(',').filter(function(n){ return n != undefined && n != '' });
              }else if(type == 'simple'){
                return [mobileNumbers];
              }

            };

            $scope.validateUrl = function(longUrl){

              return longUrl;
            };

            $scope.cancel = function () {
              $ctrl.saveError = "";
              instance.dismiss('cancel');
            };

          },
          resolve: {
            'campaign': ()=>{ return row; }
          },
          controllerAs: '$ctrl'
        });
    }


  }
function ArchievesController($http, $scope) {}

function SettingsController($http, $scope) {}

function UsersController($scope, $http, $uibModal, UsersCollectionModel, UserModel, $timeout) {

  $scope.userListOptions = {
      enableSorting: true,
      columnDefs: [
        { name:'Name', field: 'UserName' },
        { name:'Email', field: 'Email' },
        { name:'Active', field: 'IsActive'},
        { name:'ApiKey', cellTemplate:'<div>' +
        '&nbsp; &nbsp;<a ng-click="grid.appScope.seeApiKey(row.entity)">Show API Key</a>' +
        '</div>'},
        { name:'Actions', cellTemplate:'<div>' +
                    '&nbsp;&nbsp;<a ng-click="grid.appScope.editUser(row.entity)">Edit</a>' +
                    '&nbsp; | &nbsp;<a ng-click="grid.appScope.changeUserPassword(row.entity)">Change Password</a>' +
                    '</div>'
        }
      ],
    data : []
    };
  
  $scope.refreshData = function () {
    UsersCollectionModel.getAll().then(function(response) {
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

  $scope.seeApiKey = function(row, ele){
    $scope.keyError = null;
    $scope.selectedRow = row;
    $('#myApiModal').modal('show');
    $scope.loadingkey = true;
    row.getKey().then(
      (keyObj)=>{
          $scope.selectedRow.apikey = keyObj.key || row.key;
        $scope.loadingkey = false;
        var clipboard = new Clipboard('.copy-button');

      }, (err)=>{
        $scope.keyError = err.message || 'Failed to load key. try again';
        $scope.loadingkey = false;
        console.log('failed to get key.', err)
      });
  };

  $scope.refreshData();
}



function appCtrl($http, $scope) {
  // console.log($scope, $http)
}


