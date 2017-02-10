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
    .controller('ClientController', ClientController)
    .controller('ContactController', ContactController)
    .controller('FeatureController', FeatureController)

    .controller('AnalyticsController', AnalyticsController);


function AppController($http, $scope) {}

function ClientController($http, $scope) {}
function ContactController($http, $scope) {}

function HeaderController($rootScope,$window, $scope, $state, AuthService, appConfig) {

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
function FeatureController($http, $scope) {}
function HomeController($http, $scope) {}
function appCtrl($http, $scope) {
  //console.log($scope, $http)
}

function AnalyticsController($rootScope, $scope, RidService, $state, $location) {
  $scope.rid = {};
  $scope.isLoaded = false;
  $rootScope.pageLoading = true;

  $scope.init = () => {
    $scope.rid.id = $state.params.rid || null;
    $scope.hasAuthentication = false;
    $scope.isAuthorized = false;

    if($scope.rid.id){
      $scope.validateRid();
    }else{
      $scope.isLoaded = true;
      $rootScope.pageLoading = false;
    }
  };

  $scope.validateRid = (model = {id:$scope.rid.id}) => {
    $scope.error = '';
    if(!$scope.isAuthorized && $scope.hasAuthentication && model.password){
      RidService.validate(model).$promise.then((resp) => {
        $scope.isLoaded = true;
        $rootScope.pageLoading = false;
        $scope.isAuthorized = resp.success ? true: false;
        if(!$scope.isAuthorized){
          $scope.error = 'Invalid Authorization';
        }
      }, (err) => {
        $scope.isLoaded = true;
        $rootScope.pageLoading = false;
        $scope.error = 'Something is Wrong!';
        console.log("failed to validate reference id.");
      })
    }else if(!$scope.isAuthorized){
      RidService.getInfo({id: model.id}).$promise.then((resp) => {
        $state.go('.', {rid: model.id});
        $scope.isLoaded = true;
        $rootScope.pageLoading = false;
        $scope.hasAuthentication = !!resp.has_authentication;
        $scope.isAuthorized = !!resp.is_authorized;
      }, (err) => {
        $scope.isLoaded = true;
        $rootScope.pageLoading = false;
        console.log("failed to get reference id info");
        $scope.error = 'Something is Wrong!';
      });
    }else{
      $scope.isLoaded = true;
      $rootScope.pageLoading = false;
    }
  };

  if(!($rootScope.userInfo && $rootScope.userInfo.user_id)){
    $state.go('bitraz.main.login', {redirect_url: $location.$$absUrl});
  }else{
    $scope.init()
  }

}



