angular.module('bitraz.rid', ["ngResource"])
    .service('RidService', ["$resource", 'appConfig', function ($resource, appConfig) {
      return $resource(appConfig.apiEndPoint + '/api/rid/', {}, {
        getInfo: {
          method: 'GET',
          url: appConfig.apiEndPoint + '/api/rid/info/:id'
        },
        validate: {
          method: 'POST',
          url: appConfig.apiEndPoint + '/api/rid/validate/:id'
        },
        getSummary: {
          method: 'GET',
          url: appConfig.apiEndPoint + '/api/AnalyticsApi/GETSUMMARY'
        },
        getCounts: {
          method: 'GET',
          url: appConfig.apiEndPoint + '/api/AnalyticsApi/GETALLCOUNTS'
        }
      }, {
        stripTrailingSlashes: false
      });
    }]);


