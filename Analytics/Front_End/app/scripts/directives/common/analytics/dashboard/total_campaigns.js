angular.module("bitraz.dashboard")
  .component("totalCampaigns", {
    templateUrl: "views/common/dashboard/total_campaigns_tmpl.html",
    bindings: {
      data: "<"
    },
    controller: ["$scope", "$rootScope", "$timeout", function ($scope, $rootScope, $timeout) {
      var $ctrl = this;

    }]
  });