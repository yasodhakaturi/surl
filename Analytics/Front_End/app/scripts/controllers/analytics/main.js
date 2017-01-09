/**
 *
 * appCtrl
 *
 */

angular
  .module('bitraz.controllers', ['bitraz.auth', 'bitraz.common.controllers'])
    .controller('appCtrl', appCtrl)
    .controller('AppController', AppController)
    .controller('HeaderController', HeaderController)
    .controller('HomeController', HomeController)
    .controller('AnalyticsController', AnalyticsController)
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
    userId: $rootScope.userInfo.Id,
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
function AnalyticsController($http, $scope, RidService, $state, $timeout) {
  $scope.rid = {};
  $scope.isLoaded = false;
  $scope.init = () => {
    $scope.rid.id = $state.params.rid || null;
    // $scope.hasAuthentication = false;
    // $scope.isAuthorized = false;

    // if($scope.rid.id){
    //   $scope.validateRid();
    // }else{
      $scope.isLoaded = true;
    //}
    
    
  };

  $scope.init();
}
function CampaignsController($http, $scope) {}
function ArchievesController($http, $scope) {}
function SettingsController($http, $scope) {}
function UsersController($http, $scope) {}
function appCtrl($http, $scope) {

  console.log($scope, $http)


}


