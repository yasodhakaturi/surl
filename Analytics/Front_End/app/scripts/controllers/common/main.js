angular
  .module('bitraz.common.controllers', ['bitraz.auth'])
  .controller('LoginController', LoginController);



function LoginController($rootScope, $scope, AuthService, appConfig, $state, $location, $window) {
  $scope.loginError = '';
  $scope.uname = '';
  $scope.pswd = '';
  $scope.loading = false;

  $scope.login = () => {
    $scope.loading = true;
    $scope.loginError = '';
    if($scope.loginForm.$valid){
      AuthService.login({uname: $scope.uname, password: $scope.pswd}).$promise.then((res)=>{
        if(res.error){
          $scope.loginError = res.error;
        }else{
          $rootScope.userInfo = res.user_info;
          if($state.params.redirect_url){
            $window.location.href = $state.params.redirect_url ? $state.params.redirect_url : '/';
          }else{
            $location.path(res.redirect_url || '/');
          }
        }

      }, (err)=>{
        $scope.loginError = err.error;
      });
      $scope.loading = false;
    }else{
      if ($scope.loginForm.$invalid) {
        angular.forEach($scope.loginForm.$error, function (field) {
          angular.forEach(field, function(errorField){
            errorField.$setTouched();
          });
        });
      }
      $scope.loading = false;
    }
  }

}

