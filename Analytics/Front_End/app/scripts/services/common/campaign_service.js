angular.module('bitraz.campaigns', ["ngResource"])
  .service('CampaignService', ["$resource", 'appConfig', function ($resource, appConfig) {
    return $resource(appConfig.apiEndPoint + '/api/CampaignApi/', {}, {
      getCampaigns: {
        method: 'get',
        url: appConfig.apiEndPoint + '/api/CampaignApi/List'
      },

      getDetails: {
        method: 'get',
        url: appConfig.apiEndPoint + '/api/CampaignApi/Details/:id'
      }
    }, {
      stripTrailingSlashes: false
    });
  }])


