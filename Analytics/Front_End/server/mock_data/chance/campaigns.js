var chance = require("chance").Chance();
var model = require("./models.js");

exports.list = function(query){
  var count = chance.integer({min: 0, max: 10});
  return {
    "campaigns": chance.n(function () {
      return model.campaignModel()
    }, count)
  }
};