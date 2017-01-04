angular.module('bitraz.template', ['views/common/dashboard/dashboard_tmpl.html', 'views/common/directives/analytics_layout.html', 'views/common/header-dashboard.html', 'views/common/navigation.html', 'views/common/panel_tools.html', 'views/index/analytics.html', 'views/index/clients.html', 'views/index/contact.html', 'views/index/features.html', 'views/index/index.html', 'views/index/index_header.html', 'views/index/login.html']);

angular.module("views/common/dashboard/dashboard_tmpl.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/common/dashboard/dashboard_tmpl.html",
    "");
}]);

angular.module("views/common/directives/analytics_layout.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/common/directives/analytics_layout.html",
    "<section class=\"anlaytics-layout-container \" style=\"padding-top:0px;\">\n" +
    "    <div class=\"refresh-block pull-right\" style=\"padding-bottom: 5px;\">\n" +
    "        View Refreshes in {{$ctrl.timeLeft}} Seconds <a ng-click=\"$ctrl.resetTime()\"><i class=\"fa fa-refresh\"></i></a>\n" +
    "    </div>\n" +
    "    <div class=\"row\">\n" +
    "        <div class=\"col-md-12 col-sm-12 col-xs-12\">\n" +
    "            <div class=\"panel panel-default\">\n" +
    "                <div class=\"panel-body tile_count\">\n" +
    "                    <div class=\"col-md-4 col-sm-4 col-xs-4 tile_stats_count\">\n" +
    "                        <span class=\"count_top\"><i class=\"fa fa-eye\"></i> Total Visits</span>\n" +
    "                        <div class=\"count\" id=\"visits_total\">{{$ctrl.summary.visits}}</div>\n" +
    "                        <span class=\"count_bottom\"><i class=\"green\"><span id=\"visits_percentage\"></span>% </i> From last day</span>\n" +
    "                    </div>\n" +
    "                    <div class=\"col-md-4 col-sm-4 col-xs-4 tile_stats_count\">\n" +
    "                        <span class=\"count_top\"><i class=\"fa fa-user\"></i> Unique User Visits</span>\n" +
    "                        <div class=\"count\" id=\"unique_users_total\">{{$ctrl.summary.unique_users}}</div>\n" +
    "                        <span class=\"count_bottom\"><i class=\"green\"><span id=\"unique_users_percentage\"></span>% </i> From last day</span>\n" +
    "                    </div>\n" +
    "                    <div class=\"col-md-4 col-sm-4 col-xs-4 tile_stats_count\">\n" +
    "                        <span class=\"count_top\"><i class=\"fa fa-users\"></i> Total Users</span>\n" +
    "                        <div class=\"count green\" id=\"total_users\">{{$ctrl.summary.total_users}}</div>\n" +
    "                        <span class=\"count_bottom\">&nbsp;</span>\n" +
    "                    </div>\n" +
    "                </div>\n" +
    "            </div>\n" +
    "        </div>\n" +
    "    </div>\n" +
    "    <div class=\"row\">\n" +
    "        <div class=\"col-md-12 col-sm-12 col-xs-12\">\n" +
    "            <div class=\"panel panel-default\">\n" +
    "                <div class=\"panel-body\">\n" +
    "                    <div class=\"col-md-12 col-sm-12 col-xs-12\">\n" +
    "                        <div class=\"dashboard_graph\">\n" +
    "\n" +
    "                            <div class=\"row x_title\">\n" +
    "                                <div class=\"col-md-8\">\n" +
    "                                    <h3>User Activities<small style=\"padding-left: 10px\">timeline presentation</small></h3>\n" +
    "                                </div>\n" +
    "                                <div class=\"col-md-4\">\n" +
    "                                    <div id=\"reportrange\" class=\"pull-right\" style=\"background: #fff; cursor: pointer; padding: 5px 10px; border: 0px solid #ccc; width: 100%;\">\n" +
    "                                        <i class=\"glyphicon glyphicon-calendar fa fa-calendar\"></i>\n" +
    "                                        <span style=\"display: inline-block;width: calc(100% - 30px);\"><input date-range-picker id=\"daterange3\" name=\"daterange3\" class=\"form-control date-picker\" type=\"text\"\n" +
    "                                                     ng-model=\"date\" options=\"opts\" required/></span> <b class=\"caret\"></b>\n" +
    "\n" +
    "                                    </div>\n" +
    "                                </div>\n" +
    "                            </div>\n" +
    "\n" +
    "                            <div class=\"col-md-12 col-sm-12 col-xs-12\">\n" +
    "                                <div id=\"placeholder33\" style=\"height: 260px; display: none\" class=\"demo-placeholder\"></div>\n" +
    "                                <div style=\"width: 100%;\">\n" +
    "                                    <highchart id=\"canvas_dahs\" config=\"chartConfig\" class=\"demo-placeholder\" style=\"width: 100%; height:270px;\"></highchart>\n" +
    "                                </div>\n" +
    "                            </div>\n" +
    "                            <div class=\"clearfix\"></div>\n" +
    "                        </div>\n" +
    "                    </div>\n" +
    "                </div>\n" +
    "            </div>\n" +
    "        </div>\n" +
    "    </div>\n" +
    "\n" +
    "    <div class=\"row\">\n" +
    "        <div class=\"col-md-12 col-sm-12 col-xs-12\">\n" +
    "            <div class=\"panel panel-default\">\n" +
    "                <div class=\"panel-body\">\n" +
    "                    <div class=\"col-md-12 col-sm-12 col-xs-12\">\n" +
    "                        <div class=\"dashboard_graph\">\n" +
    "\n" +
    "                            <div class=\"row x_title\">\n" +
    "                                <div class=\"col-md-6\">\n" +
    "                                    <h3>Visitors location <small>geo-presentation</small></h3>\n" +
    "                                </div>\n" +
    "                            </div>\n" +
    "\n" +
    "                            <div class=\"col-md-12 col-sm-12 col-xs-12\">\n" +
    "                                <div style=\"width: 100%;\">\n" +
    "                                    <highchart id=\"world-map-gdp\" config=\"locationConfig\" class=\"columnscol-md-12 col-sm-12 col-xs-12\" style=\"height: 400px\">\n" +
    "\n" +
    "                                    </highchart>\n" +
    "                                </div>\n" +
    "                            </div>\n" +
    "\n" +
    "                            <div class=\"clearfix\"></div>\n" +
    "                        </div>\n" +
    "                    </div>\n" +
    "\n" +
    "                </div>\n" +
    "            </div>\n" +
    "        </div>\n" +
    "    </div>\n" +
    "    <div class=\"row\">\n" +
    "        <div class=\"col-md-12 col-sm-12 col-xs-12\">\n" +
    "            <div class=\"panel panel-default\">\n" +
    "                <div class=\"panel-body\">\n" +
    "                    <div class=\"col-md-6 col-sm-6 col-xs-6\">\n" +
    "                        <div class=\"dashboard_graph \">\n" +
    "\n" +
    "                            <div class=\"row x_title\">\n" +
    "                                <div class=\"col-md-12 text-center\">\n" +
    "                                    <h3>Devices</h3>\n" +
    "                                </div>\n" +
    "                            </div>\n" +
    "                            <div class=\"row\">\n" +
    "                                <div class=\"col-md-12 col-sm-12 col-xs-12\">\n" +
    "                                    <!--<div id=\"placeholder33\" style=\"height: 360px; display: none\" class=\"demo-placeholder\"></div>-->\n" +
    "                                    <div style=\"width: 100%;\">\n" +
    "                                        <highchart id=\"devices-chart\" config=\"deviceConfig\"  style=\"height:300px;\"></highchart>\n" +
    "                                    </div>\n" +
    "                                </div>\n" +
    "                            </div>\n" +
    "\n" +
    "                            <div class=\"clearfix\"></div>\n" +
    "                        </div>\n" +
    "                    </div>\n" +
    "                    <div class=\"col-md-6 col-sm-6 col-xs-6\">\n" +
    "                        <div class=\"dashboard_graph \">\n" +
    "\n" +
    "                            <div class=\"row x_title\">\n" +
    "                                <div class=\"col-md-12 text-center\">\n" +
    "                                    <h3>Platforms</h3>\n" +
    "                                </div>\n" +
    "                            </div>\n" +
    "                            <div class=\"row\">\n" +
    "                                <div class=\"col-md-12 col-sm-12 col-xs-12\">\n" +
    "                                    <!--<div id=\"placeholder33\" style=\"height: 360px; display: none\" class=\"demo-placeholder\"></div>-->\n" +
    "                                    <div style=\"width: 100%;\">\n" +
    "                                        <highchart id=\"platform-chart\" config=\"platformConfig\" style=\"height:300px;\"></highchart>\n" +
    "                                    </div>\n" +
    "                                </div>\n" +
    "                            </div>\n" +
    "                            <div class=\"clearfix\"></div>\n" +
    "                        </div>\n" +
    "                    </div>\n" +
    "                </div>\n" +
    "            </div>\n" +
    "        </div>\n" +
    "    </div>\n" +
    "\n" +
    "</section>");
}]);

angular.module("views/common/header-dashboard.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/common/header-dashboard.html",
    "<div id=\"logo\" class=\"light-version\"> <span> bi <span class=\"part2\">TRAZ</span> </span> </div> <nav role=\"navigation\"> <!-- <minimaliza-menu></minimaliza-menu> --> <div class=\"small-logo\"> <span class=\"text-primary\">bi <span class=\"part2\">TRAZ</span></span> </div> <div class=\"mobile-menu\"> <button type=\"button\" class=\"navbar-toggle mobile-menu-toggle\" data-toggle=\"collapse\" data-target=\"#mobile-collapse\"> <i class=\"fa fa-chevron-down\"></i> </button> <div class=\"collapse mobile-navbar\" id=\"mobile-collapse\"> <ul class=\"nav navbar-nav\"> <li> <a href=\"#\">Login</a> </li> </ul> </div> </div> <div class=\"navbar-right\"> <ul class=\"nav navbar-nav no-borders\"> <li> <a> <i class=\"pe-7s-upload pe-rotate-90\"></i> </a> </li> </ul> </div> </nav>");
}]);

angular.module("views/common/navigation.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/common/navigation.html",
    "<div id=\"navigation\"> <div class=\"profile-picture\"> <div class=\"stats-label text-color\"> <span class=\"font-extra-bold font-uppercase\">Username</span> <div class=\"dropdown\" uib-dropdown> <a uib-dropdown-toggle href=\"#\"> <small class=\"text-muted\">Founder of App <b class=\"caret\"></b></small> </a> <ul uib-dropdown-menu class=\"animated flipInX m-t-xs\"> <li><a>Item</a></li> </ul> </div> </div> </div> <ul side-navigation class=\"nav metismenu\" id=\"side-menu\"> <li ui-sref-active=\"active\"> <a ui-sref=\"dashboard\"> <span class=\"nav-label\">Dashboard</span></a> </li> </ul> </div>");
}]);

angular.module("views/common/panel_tools.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/common/panel_tools.html",
    "<!-- This is template for panel tools --><!-- It contains collapse function (showhide) and close function (closebox) --><!-- All function is handled from directive panelTools in directives.js file --> <div class=\"panel-tools\"> <a ng-click=\"showhide()\"><i class=\"fa fa-chevron-up\"></i></a> <a ng-click=\"closebox()\"><i class=\"fa fa-times\"></i></a> </div>");
}]);

angular.module("views/index/analytics.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/index/analytics.html",
    "<div id=\"wrapper\"> <div class=\"content\" animate-panel effect=\"zoomIn\"> <div class=\"row\" ng-show=\"isLoaded\"> <div ng-if=\"!isAuthorized\"> <p>1.Ask for RID before showing analytics</p> <p>2.Validate rid, if authentication is required ask for password. else proceed</p> <form novalidate name=\"ridRequest\"> <div class=\"col-sm-12\"> <div class=\"row\"> <label>Reference Id: <input type=\"text\" name=\"referenceId\" ng-model=\"rid.id\" ng-required=\"true\" ng-change=\"\"></label> </div> <div class=\"row\" ng-if=\"hasAuthentication\"> <label>Password: <input type=\"password\" name=\"referencePswd\" ng-model=\"rid.password\" ng-required=\"true\"></label> </div> <div class=\"row\"> <label><input type=\"submit\" ng-click=\"validateRid(rid)\" value=\"Save\"></label> </div> <span class=\"text-danger\" ng-if=\"error\"> error: {{error}}</span> </div> </form> </div> <div ng-if=\"isAuthorized\"> <analytics-layout campaign-id=\"rid.id\"></analytics-layout> </div> </div> <div class=\"row\" ng-hide=\"isLoaded\"> <div class=\"splash-title\"> <h1>Loading..</h1> <p></p> <img src=\"images/loading-bars.svg\" width=\"64\" height=\"64\"></div> </div> </div> </div>");
}]);

angular.module("views/index/clients.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/index/clients.html",
    "<!-- Main Wrapper --> <div id=\"wrapper\"> <div class=\"content\" animate-panel effect=\"zoomIn\"> <div class=\"row\"> <div class=\"col-lg-12 text-center m-t-md\"> <h2> Welcome to biTRAZ 4 </h2> <p>Special <strong>Analytic Trace Application</strong> for your mobile marketing campaigns.</p> </div> </div> </div> </div>");
}]);

angular.module("views/index/contact.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/index/contact.html",
    "<!-- Main Wrapper --> <div id=\"wrapper\"> <div class=\"content\" animate-panel effect=\"zoomIn\"> <div class=\"row\"> <div class=\"col-lg-12 text-center m-t-md\"> <h2> Welcome to biTRAZ 3 </h2> <p>Special <strong>Analytic Trace Application</strong> for your mobile marketing campaigns.</p> </div> </div> </div> </div>");
}]);

angular.module("views/index/features.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/index/features.html",
    "<!-- Navigation --><!-- <aside id=\"menu\" ng-include=\"'views/common/navigation.html'\"></aside> --><!-- Main Wrapper --> <div id=\"wrapper\"> <div class=\"content\" animate-panel effect=\"zoomIn\"> <div class=\"row\"> <div class=\"col-lg-12 text-center m-t-md\"> <h2> Welcome to biTRAZ 2 </h2> <p>Special <strong>Analytic Trace Application</strong> for your mobile marketing campaigns.</p> </div> </div> </div> </div>");
}]);

angular.module("views/index/index.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/index/index.html",
    "<!-- Main Wrapper --> <div id=\"wrapper\"> <div class=\"content\" animate-panel effect=\"zoomIn\"> <div class=\"row\"> <div class=\"col-lg-12 text-center m-t-md\"> <h2> Welcome to biTRAZ 1 </h2> <p>Special <strong>Analytic Trace Application</strong> for your mobile marketing campaigns.</p> <p> <a ui-sref=\"bitraz.main.analytics\">Analytics Page</a> </p> </div> </div> </div> </div>");
}]);

angular.module("views/index/index_header.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/index/index_header.html",
    "<div id=\"logo\" class=\"light-version\" href=\"#\"> <a ng-href=\"#\"><span> bi <span class=\"part2\">TRAZ</span> </span></a> </div> <nav role=\"navigation\"> <!-- <minimaliza-menu></minimaliza-menu> --> <div class=\"small-logo\" ng-href=\"#\"> <a ng-href=\"#\"><span class=\"text-primary\">bi <span class=\"part2\">TRAZ</span></span></a> </div> <div class=\"mobile-menu\"> <button type=\"button\" class=\"navbar-toggle mobile-menu-toggle\" data-toggle=\"collapse\" data-target=\"#mobile-collapse\"> <i class=\"fa fa-chevron-down\"></i> </button> <div class=\"collapse mobile-navbar\" id=\"mobile-collapse\"> <ul class=\"nav navbar-nav\"> <li ng-class=\"{'active':active == 'home'}\"><a class=\"page-scroll\" ui-sref=\"bitraz.main.index\">Home</a></li> <li ng-class=\"{'active':active == 'features'}\"><a class=\"page-scroll\" page-scroll ui-sref=\"bitraz.main.features\">Features</a></li> <li ng-class=\"{'active':active == 'clients'}\"><a class=\"page-scroll\" page-scroll ui-sref=\"bitraz.main.clients\">Clients </a></li> <li ng-class=\"{'active':active == 'contact'}\"><a class=\"page-scroll\" page-scroll ui-sref=\"bitraz.main.contact\">Contact</a></li> <li ng-class=\"{'active':active == 'login'}\" ng-show=\"!$root.userInfo || !$root.userInfo.Id\"><a class=\"page-scroll\" page-scroll ui-sref=\"bitraz.main.login\">Sign In</a></li> <li ng-class=\"{'active':active == 'logout'}\" ng-show=\"$root.userInfo && $root.userInfo.Id\"><a class=\"page-scroll\" page-scroll ui-sref=\"bitraz.main.login\">Log Out</a></li> </ul> </div> </div> <div class=\"navbar-default\"> <div class=\"navbar-right\"> <ul class=\"nav navbar-nav no-borders\"> <li ng-class=\"{'active':active == 'home'}\"><a class=\"page-scroll\" ui-sref=\"bitraz.main.index\">Home</a></li> <li ng-class=\"{'active':active == 'features'}\"><a class=\"page-scroll\" page-scroll ui-sref=\"bitraz.main.features\">Features</a></li> <li ng-class=\"{'active':active == 'clients'}\"><a class=\"page-scroll\" page-scroll ui-sref=\"bitraz.main.clients\">Clients </a></li> <li ng-class=\"{'active':active == 'contact'}\"><a class=\"page-scroll\" page-scroll ui-sref=\"bitraz.main.contact\">Contact</a></li> <li ng-class=\"{'active':active == 'login'}\" ng-show=\"!$root.userInfo || !$root.userInfo.Id\"><a class=\"page-scroll\" page-scroll ui-sref=\"bitraz.main.login\">Sign In</a></li> <li ng-class=\"{'active':active == 'logout'}\" ng-show=\"$root.userInfo && $root.userInfo.Id\"><a class=\"page-scroll\" page-scroll ui-sref=\"bitraz.main.logout\">Log Out</a></li> </ul> </div> </div> </nav>");
}]);

angular.module("views/index/login.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/index/login.html",
    "<div class=\"login-container\"> <div class=\"row\"> <div class=\"col-md-12\"> <div class=\"text-center m-b-md\" style=\"border: 1px solid transparent\"> <h3>LOGIN</h3> <!-- <small> This is the best app ever!</small> --> </div> <div class=\"hpanel\"> <div class=\"panel-body\"> <form action=\"#\" id=\"loginForm\"> <div class=\"form-group\"> <label class=\"control-label\" for=\"username\">Username</label> <input type=\"text\" placeholder=\"example@gmail.com\" title=\"Please enter you username\" required value=\"\" name=\"username\" id=\"username\" class=\"form-control\"> <span class=\"help-block small\">Your unique username to app</span> </div> <div class=\"form-group\"> <label class=\"control-label\" for=\"password\">Password</label> <input type=\"password\" title=\"Please enter your password\" placeholder=\"******\" required value=\"\" name=\"password\" id=\"password\" class=\"form-control\"> <span class=\"help-block small\">Your strong password</span> </div> <div class=\"checkbox\"> <input icheck type=\"checkbox\" ng-model=\"remember\" ng-init=\"remember = true\"> Remember login <p class=\"help-block small\">(if this is a private computer)</p> </div> <button class=\"btn btn-success btn-block\">Login</button> <a class=\"btn btn-default btn-block\" href=\"#\">Register</a> </form> </div> </div> </div> </div> </div>");
}]);
