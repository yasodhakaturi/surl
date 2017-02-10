angular.module('bitraz.models', ['bitraz.models.common'])
  .factory('UsersCollectionModel', ['$http', '$q', 'appConfig', 'UserModel', function($http, $q, appConfig, UserModel) {
    "use strict";
    class Users {
      constructor(data={}) {
        //this.UserService = UserService;
        this.collection = [];
        this.lastFetchedOn = null;
      }

      getAll(){
        var getAllDefer = $q.defer();
        $http({
          method: 'GET',
          url: appConfig.apiEndPoint + '/api/CustomerApi'
        })
          .then((response) => {
            var users = [];
            angular.forEach(response.data, function(user){
              users.push(new UserModel(user));
            });
            this.collection = users;
            getAllDefer.resolve(users);
          }, (err) => {
            getAllDefer.reject(err);
          });
        return getAllDefer.promise;
      };
    }

  return new Users();
}])
  .factory('UserModel', ['$http', '$q', 'appConfig', function($http, $q, appConfig) {
    class User {
      constructor(data) {
        this.id = data.id || null;
        this.UserName = data.UserName;
        this.Email = data.Email;
        this.IsActive = data.IsActive || false;
      }

      save(){
        var refDefer = $q.defer();

        if(!this.id){
          //save
          $http({
            method: 'POST',
            url: appConfig.apiEndPoint + '/Customer/AddClient',
            data: {UserName: this.UserName, Email: this.Email, Password: this.Password, IsActive: this.IsActive}
          }).then((userObj) => {
//            console.log('user save', userObj)
            refDefer.resolve(new UserModel(userObj.data));
          }, (err) => {
            console.log('user save failed', err);
            refDefer.reject(err);
          });
          
        }else{
          //update
          $http({
            method: 'POST',
            url: appConfig.apiEndPoint + '/Customer/UpdateClient',
            data: {id: this.id, UserName: this.UserName, Email: this.Email,  IsActive: this.IsActive}
          }).then((userObj) => {
//            console.log('user update', userObj);
            refDefer.resolve(new UserModel(userObj.data));
          }, (err) => {
            console.log('user update failed', err);
            refDefer.reject(err);
          });
        }
        return refDefer.promise;
      }

      resetPassword(){
        let refDefer = $q.defer();
        $http({
          method: 'PUT',
          url: appConfig.apiEndPoint + '/Customer/UpdateClient',
          data: {id: this.id, Password: this.Password}
        }).then((userObj) => {
//          console.log('user update', userObj);
          refDefer.resolve(new UserModel(userObj.data));
        }, (err) => {
          console.log('user update failed', err);
          refDefer.reject(err);
        });
        return refDefer.promise;
      }
    }
    return User;
  }])

  .factory('CampaignsCollectionModel', ['$http', '$q', 'appConfig', 'CampaignModel', 'UserModel', function($http, $q, appConfig, CampaignModel, UserModel) {
        "use strict";
        class Campaigns {
          constructor(data={}) {
            this.collection = [];
            this.lastFetchedOn = null;
          }

          getAll(){
            var getAllDefer = $q.defer();
            $http({
              method: 'GET',
              url: appConfig.apiEndPoint + '/Campaign/Search'
            })
              .then((response) => {
                var campaigns = [];
                angular.forEach(response.data, function(campaign){
                  campaigns.push(new CampaignModel(campaign));
                });
                this.collection = campaigns;
                getAllDefer.resolve(campaigns);
              }, (err) => {
                getAllDefer.reject(err);
              });
            return getAllDefer.promise;
          };
        }

      return new Campaigns();
    }])
  .factory('CampaignModel', ['$http', '$q', 'appConfig', function($http, $q, appConfig) {
        class Campaign {
          constructor(data) {
            this.Id = data.Id || null;
            this.CampaignName = data.CampaignName;
            this.ReferenceNumber = data.ReferenceNumber;
            this.CreatedOn = data.CreatedDate || '';
            this.CreatedUserId = data.CreatedUserId || '';
            this.CreatedUserName = data.CreatedUserName || '';
            this.CreatedUserEmail = data.CreatedUserEmail || '';
            this.CreatedUserActiveState = data.CreatedUserActiveState || '';
            this.HasPassword = !!data.HasPassword || false;
            this.IsActive = data.IsActive || false;
            this.Password = '';
            this.EditPassword = false;
          }

          save(){
            var refDefer = $q.defer();

            if(!this.Id){
              //save
              var data = {CampaignName: this.CampaignName, IsActive: this.IsActive, CreatedUserId: this.CreatedUserId};
              if(this.Password !=''){
                data.Pwd = this.Password
              }else{
                 data.Pwd = false;
               }
              $http({
                method: 'POST',
                url: appConfig.apiEndPoint + '/Campaign/AddCampaign',
                data: data
              }).then((campaignObj) => {
//                console.log('campaign save', campaignObj)
                refDefer.resolve(new CampaignModel(campaignObj.data));
              }, (err) => {
                console.log('campaign save failed', err);
                refDefer.reject(err);
              });

            }else{
              //update
              var data = {ReferenceNumber:this.ReferenceNumber, CampaignName: this.CampaignName, IsActive: this.IsActive};
              if(this.EditPassword && this.RemovePassword){
                data.Pwd = '';
              }else if(this.EditPassword && this.Password !=''){
                data.Pwd = this.Password
              }
              $http({
                method: 'POST',
                url: appConfig.apiEndPoint + '/Campaign/UpdateCampaign',
                data: data
              }).then((campaignObj) => {
//                console.log('campaign update', campaignObj);
                refDefer.resolve(new Campaign(campaignObj.data));
              }, (err) => {
                console.log('campaign update failed', err);
                refDefer.reject(err);
              });
            }
            return refDefer.promise;
          }

  //        resetPassword(){
  //          let refDefer = $q.defer();
  //          $http({
  //            method: 'PUT',
  //            url: appConfig.apiEndPoint + '/api/Users/'+this.id,
  //            data: {id: this.id, Password: this.Password}
  //          }).then((userObj) => {
  //            console.log('user update', userObj);
  //            refDefer.resolve(new UserModel(userObj.data));
  //          }, (err) => {
  //            console.log('user update failed', err);
  //            refDefer.reject(err);
  //          });
  //          return refDefer.promise;
  //        }
        }
        return Campaign;
    }])