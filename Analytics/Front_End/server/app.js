var express = require('express');
var fs = require("fs"),
  path = require("path"),
  multer = require('multer'),
  bodyParser = require('body-parser')
chance = require("chance").Chance();
var app = express();
app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());


var traverseFileSystem = function (currentPath) {
  //console.log(currentPath);
  var files = fs.readdirSync(currentPath);
  for (var i in files) {
    var currentFile = currentPath + '/' + files[i];
    var stats = fs.statSync(currentFile);
    if (stats.isFile()) {
      console.log(currentFile);
    }
    else if (stats.isDirectory()) {
      traverseFileSystem(currentFile);
    }
  }
};
console.log("Static Json files:");
traverseFileSystem('./mock_data');


var accessObject;
var config;


app.all("*", function (req, res, next) {
  var p = req.path;
  console.log("request: " + req.method + ":" + p);
  var origin = req.headers.origin;
  console.log(origin)
  accessObject = {"Access-Control-Allow-Origin": origin || '*',
    "Access-Control-Allow-Credentials":"true",
    "Access-Control-Allow-Headers": "Origin, X-Requested-With, Content-Type, Accept",
    "Access-Control-Allow-Methods": "PUT, PATCH, OPTIONS, GET, POST, DELETE"
  };
  config = {root: "./mock_data", headers: accessObject}

  if(req.method === "OPTIONS") {
    res.append("Access-Control-Allow-Origin", origin || '*')
      .append("Access-Control-Allow-Credentials", "true")
      .append("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept")
      .append("Access-Control-Allow-Methods", "PUT, PATCH, OPTIONS, GET, POST, DELETE")
      .status(200).end();
  }

  res.header(accessObject);

 if( /\/api\/Users/.exec(p)){
   var users = require("./mock_data/chance/admin/users");
   res.json( users.get() );
  }
  else if( /\/api\/rid\/info\/\d*$/.exec(p)){
    var rid = require("./mock_data/chance/rid");
    res.json( rid.get() );
  }
 else if( /\/api\/rid\/validate\/\d*$/.exec(p)){
    var rid = require("./mock_data/chance/rid");
    res.json( rid.post() );
  }

 else if( /\/api\/AnalyticsApi\/GETSUMMARY/.exec(p)){
   var rid = require("./mock_data/chance/analytics");
   res.json( rid.getSummary() );
 }

 else if( /\/api\/AnalyticsApi\/GETALLCOUNTS/.exec(p)){
   var rid = require("./mock_data/chance/analytics");
   res.json( rid.getCounts() );
 }

 else if( /\/Auth\/Login/.exec(p)){
   var user = require("./mock_data/chance/user");
   res.json( user.login(req) );
 } else if( /\/Auth\/Logout/.exec(p)){
   var user = require("./mock_data/chance/user");
   res.json( user.logout(req) );
 }
  else{
    console.log("P:" + p + req.query.portfolio);
    res.sendFile( "index.html", {root: ".", headers: accessObject} );
  }
});

app.listen(process.env.PORT || 3301);
console.log("Server started: http://localhost:3301/");
