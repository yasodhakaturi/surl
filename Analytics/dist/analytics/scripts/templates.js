angular.module('bitraz.template', ['views/analytics/analytics.html', 'views/analytics/archieves.html', 'views/analytics/campaigns.html', 'views/analytics/header.html', 'views/analytics/index.html', 'views/analytics/settings.html', 'views/analytics/users.html', 'views/common/dashboard/dashboard_tmpl.html', 'views/common/directives/analytics_layout.html', 'views/common/header-dashboard.html', 'views/common/navigation.html', 'views/common/panel_tools.html']);

angular.module("views/analytics/analytics.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/analytics/analytics.html",
    "<!-- Main Wrapper --> <div id=\"wrapper\"> <div class=\"content\" animate-panel effect=\"zoomIn\"> <div class=\"row\"> <div class=\"col-lg-12 text-right\"> <span> Choose a Campaign</span> <select name=\"selectedCampaign\" ng-model=\"selectedCampaign\"> <option value=\"5\"> Current Campaign: 01/01/2017 - till date <option value=\"4\"> Last Campaign: 12/01/2016 - 12/31/2016 <option value=\"3\"> Older Campaign: 12/01/2016 - 12/31/2016 <option value=\"2\"> Older Campaign: 12/01/2016 - 12/31/2016 </select> </div> </div> <div class=\"row\"> <div class=\"col-lg-12\"> <analytics-layout campaign-id=\"rid && rid.id\" data-range=\"selectedCampaign\"></analytics-layout> </div> </div> <div class=\"row\"> <div class=\"col-lg-12\"> </div> </div> </div> </div>");
}]);

angular.module("views/analytics/archieves.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/analytics/archieves.html",
    "<!-- Main Wrapper --> <div id=\"wrapper\"> <div class=\"content\" animate-panel effect=\"zoomIn\"> <div class=\"row\"> <div class=\"col-lg-12 text-center m-t-md\"> <h2> Welcome to biTRAZ archieves </h2> <p>Special <strong>Analytic Trace Application</strong> for your mobile marketing campaigns.</p> </div> </div> </div> </div>");
}]);

angular.module("views/analytics/campaigns.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/analytics/campaigns.html",
    "<!-- Main Wrapper --> <div id=\"wrapper\"> <div class=\"content\" animate-panel effect=\"zoomIn\"> <div class=\"row\"> <div class=\"col-lg-12 text-center m-t-md\"> <h2> Welcome to biTRAZ campaigns </h2> <p>Special <strong>Analytic Trace Application</strong> for your mobile marketing campaigns.</p> </div> </div> </div> </div>");
}]);

angular.module("views/analytics/header.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/analytics/header.html",
    "<div id=\"logo\" class=\"light-version\" href=\"#\"> <a ng-href=\"#\"><span> bi <span class=\"part2\">TRAZ</span> </span></a> </div> <nav role=\"navigation\"> <!-- <minimaliza-menu></minimaliza-menu> --> <div class=\"small-logo\" ng-href=\"#\"> <a ng-href=\"#\"><span class=\"text-primary\">bi <span class=\"part2\">TRAZ</span></span></a> </div> <div class=\"mobile-menu\"> <button type=\"button\" class=\"navbar-toggle mobile-menu-toggle\" data-toggle=\"collapse\" data-target=\"#mobile-collapse\"> <i class=\"fa fa-chevron-down\"></i> </button> <div class=\"collapse mobile-navbar\" id=\"mobile-collapse\"> <ul class=\"nav navbar-nav\"> <li ng-class=\"{'active':active == 'home'}\"><a class=\"page-scroll\" href=\"#page-top\">Home</a></li> <li ng-class=\"{'active':active == 'analytics'}\"><a class=\"page-scroll\" page-scroll href=\"#analytics\">Analytics</a></li> <li ng-class=\"{'active':active == 'security'}\"><a class=\"page-scroll\" page-scroll href=\"#security\">Security </a></li> <li><a class=\"page-scroll\" page-scroll href=\"#\">Logout</a></li> </ul> </div> </div> <div class=\"navbar-right\"> <ul class=\"nav navbar-nav no-borders\"> <li uib-dropdown> <a ui-sref=\"bitraz.main.index\" uib-dropdown-toggle> <i class=\"pe-7s-home\"></i> </a> </li> <li uib-dropdown> <a uib-dropdown-toggle> <i class=\"pe-7s-graph\"></i> </a> <div uib-dropdown-menu class=\"hdropdown bigmenu animated flipInX\"> <table> <tbody> <tr> <td> <a ui-sref=\"bitraz.main.analytics\"> <i class=\"pe pe-7s-graph1 text-danger\"></i> <h5>Analytics</h5> </a>  <td> <a ui-sref=\"bitraz.main.campaigns\"> <i class=\"pe pe-7s-portfolio text-info\"></i> <h5>Campaigns</h5> </a>   <tr> <td> <a ui-sref=\"bitraz.main.users\"> <i class=\"pe pe-7s-users text-success\"></i> <h5>Users</h5> </a>  <td> <a ui-sref=\"bitraz.main.archieves\"> <i class=\"pe pe-7s-box1 text-success\"></i> <h5>Archieve</h5> </a>    </table> </div> </li> <li> <a ui-sref=\"bitraz.main.settings\"> <i class=\"pe-7s-config\"></i> </a> </li> <li> <a> <i class=\"pe-7s-power\"></i> </a> </li> </ul> </div> </nav>");
}]);

angular.module("views/analytics/index.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/analytics/index.html",
    "<!-- Main Wrapper --> <div id=\"wrapper\"> <div class=\"content\" animate-panel effect=\"zoomIn\"> <div class=\"row\"> <div class=\"col-lg-12 text-center m-t-md\"> <h2> Welcome to biTRAZ home </h2> <p>Special <strong>Analytic Trace Application</strong> for your mobile marketing campaigns.</p> </div> </div> </div> </div>");
}]);

angular.module("views/analytics/settings.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/analytics/settings.html",
    "<!-- Main Wrapper --> <div id=\"wrapper\"> <div class=\"content\" animate-panel effect=\"zoomIn\"> <div class=\"row\"> <div class=\"col-lg-12 text-center m-t-md\"> <h2> Welcome to biTRAZ settings </h2> <p>Special <strong>Analytic Trace Application</strong> for your mobile marketing campaigns.</p> </div> </div> </div> </div>");
}]);

angular.module("views/analytics/users.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/analytics/users.html",
    "<!-- Main Wrapper --> <div id=\"wrapper\"> <div class=\"content\" animate-panel effect=\"zoomIn\"> <div class=\"row\"> <div class=\"col-lg-12 text-center m-t-md\"> <h2> Welcome to biTRAZ users </h2> <p>Special <strong>Analytic Trace Application</strong> for your mobile marketing campaigns.</p> </div> </div> </div> </div>");
}]);

angular.module("views/common/dashboard/dashboard_tmpl.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/common/dashboard/dashboard_tmpl.html",
    "");
}]);

angular.module("views/common/directives/analytics_layout.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/common/directives/analytics_layout.html",
    "<section class=\"anlaytics-layout-container \" style=\"padding-top:0px;\">\n" +
    "    <div class=\"row\" style=\"padding-bottom: 5px;\">\n" +
    "        <div class=\"col-lg-12 refresh-block\">\n" +
    "            <span class=\"pull-right\">\n" +
    "                View Refreshes in {{$ctrl.timeLeft}} Seconds <a ng-click=\"$ctrl.resetTime()\"><i class=\"fa fa-refresh\"></i></a>\n" +
    "            </span>\n" +
    "\n" +
    "        </div>\n" +
    "    </div>\n" +
    "    <div class=\"row\">\n" +
    "        <div class=\"col-lg-4\">\n" +
    "            <div class=\"hpanel\">\n" +
    "                <div class=\"panel-body text-center h-200\">\n" +
    "                    <i class=\"pe-7s-graph1 fa-4x\"></i>\n" +
    "\n" +
    "                    <h1 class=\"m-xs\">{{$ctrl.summary.visits}}</h1>\n" +
    "\n" +
    "                    <h3 class=\"font-extra-bold no-margins text-success\">\n" +
    "                        Total Visits\n" +
    "                    </h3>\n" +
    "                    <small>Total visits to the campaign.</small>\n" +
    "                </div>\n" +
    "                <!--<div class=\"panel-footer\">-->\n" +
    "                <!--This is standard panel footer-->\n" +
    "                <!--</div>-->\n" +
    "            </div>\n" +
    "        </div>\n" +
    "\n" +
    "        <div class=\"col-lg-4\">\n" +
    "            <div class=\"hpanel\">\n" +
    "                <div class=\"panel-body text-center h-200\">\n" +
    "                    <i class=\"fa fa-user-o fa-4x\"></i>\n" +
    "\n" +
    "                    <h1 class=\"m-xs\">{{$ctrl.summary.unique_users}}</h1>\n" +
    "\n" +
    "                    <h3 class=\"font-extra-bold no-margins text-success\">\n" +
    "                        Unique User Visits\n" +
    "                    </h3>\n" +
    "                    <small>unique users visited to campaign.</small>\n" +
    "                </div>\n" +
    "                <!--<div class=\"panel-footer\">-->\n" +
    "                <!--This is standard panel footer-->\n" +
    "                <!--</div>-->\n" +
    "            </div>\n" +
    "        </div>\n" +
    "\n" +
    "        <div class=\"col-lg-4\">\n" +
    "            <div class=\"hpanel\">\n" +
    "                <div class=\"panel-body text-center h-200\">\n" +
    "                    <i class=\"fa fa-users fa-4x\"></i>\n" +
    "\n" +
    "                    <h1 class=\"m-xs\">{{$ctrl.summary.total_users}}</h1>\n" +
    "\n" +
    "                    <h3 class=\"font-extra-bold no-margins text-success\">\n" +
    "                        Total Users\n" +
    "                    </h3>\n" +
    "                    <small>Total users visited to campaign.</small>\n" +
    "                </div>\n" +
    "                <!--<div class=\"panel-footer\">-->\n" +
    "                <!--This is standard panel footer-->\n" +
    "                <!--</div>-->\n" +
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
    "                                                                                                             ng-model=\"date\" options=\"opts\" required/></span> <b class=\"caret\"></b>\n" +
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
