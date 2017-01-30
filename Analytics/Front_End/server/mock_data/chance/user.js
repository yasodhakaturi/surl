var chance = require("chance").Chance();
var model = require("./models.js");

exports.login = function(request){
  var role;
  switch(request.body.uname){
    case 'demo':
      role = 'Member';
      break;

    case 'admin':
      role = 'Admin';
      break;

    case 'user':
      role = 'MemberAdmin';
      break;

    default:
      role = null;

  }

  if(role && request.body.password == 'password'){
    if(role == 'Member'){
      return {user_info: {user_id: 1, user_role:role, user_name:request.body.uname}, redirected_url:'/Home'};
    }else if(role == 'MemberAdmin'){
      return {user_info: {user_id: 1, user_role:role, user_name:request.body.uname}, redirected_url:'/Analytics'};
    }else if(role == 'Admin'){
      return {user_info: {user_id: 1, user_role:role, user_name:request.body.uname}, redirected_url:'/Admin'};
    }
  }else if(role){
    return {'error': {"message": 'Invalid Credentials'}}
  }else{
    return {'error': {"message": 'Invalid Credentials'}}
  }

};

exports.logout = function(query){
    return {"success": "logged out successfully"};
};

exports.user = function(query){
  return {user_info: {user_id: 1, user_role:'Member', user_name:'test'}, redirected_url:'Index/'};
};

exports.list = function(query){
  var count = chance.integer({min: 0, max: 10});
  return  chance.n(function () {
      return model.adminUserModel()
    }, count)

};

