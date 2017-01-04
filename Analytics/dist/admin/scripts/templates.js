angular.module('bitraz.template', ['views/admin/admin.html', 'views/admin/analytics.html', 'views/admin/archieves.html', 'views/admin/campaigns.html', 'views/admin/components/clients_component_tmpl.html', 'views/admin/header.html', 'views/admin/index.html', 'views/admin/settings.html', 'views/admin/users.html', 'views/admin/users/add_user.html', 'views/admin/users/change_password.html', 'views/admin/users/edit_user.html', 'views/common/dashboard/dashboard_tmpl.html', 'views/common/directives/analytics_layout.html', 'views/common/header-dashboard.html', 'views/common/navigation.html', 'views/common/panel_tools.html']);

angular.module("views/admin/admin.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/admin/admin.html",
    "<!-- Header --> <div id=\"header\" ng-include=\"'views/common/header-dashboard.html'\"></div> <!-- Navigation --> <!-- <aside id=\"menu\" ng-include=\"'views/common/navigation.html'\"></aside> --> <!-- Main Wrapper --> <div id=\"wrapper\"> <div class=\"content\" animate-panel effect=\"zoomIn\"> <div class=\"row\"> <div class=\"col-lg-12 text-center m-t-md\"> <h2> Welcome to biTRAZ Admin. </h2> <p>Special <strong>Analytic Trace Application</strong> for your mobile marketing campaigns.</p> </div> </div> </div> </div>");
}]);

angular.module("views/admin/analytics.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/admin/analytics.html",
    "<!-- Main Wrapper --> <div id=\"wrapper\"> <div class=\"content\" animate-panel effect=\"zoomIn\"> <div class=\"row\"> <div class=\"col-lg-12 text-center m-t-md\"> <h2> Welcome to biTRAZ admin analytics </h2> <p>Special <strong>Analytic Trace Application</strong> for your mobile marketing campaigns.</p> </div> </div> <div class=\"row\"> <div class=\"col-sm-12\"> <ul> <li>list of campaigns, select one</li> <li>show same analytics page as ease in analytic module</li> </ul> </div> </div> </div> </div>");
}]);

angular.module("views/admin/archieves.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/admin/archieves.html",
    "<!-- Main Wrapper --> <div id=\"wrapper\"> <div class=\"content\" animate-panel effect=\"zoomIn\"> <div class=\"row\"> <div class=\"col-lg-12 text-center m-t-md\"> <h2> Welcome to biTRAZ admin archieves </h2> <p>Special <strong>Analytic Trace Application</strong> for your mobile marketing campaigns.</p> </div> </div> </div> </div>");
}]);

angular.module("views/admin/campaigns.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/admin/campaigns.html",
    "<!-- Main Wrapper --> <div id=\"wrapper\"> <div class=\"content\" animate-panel effect=\"zoomIn\"> <div class=\"row\"> <div class=\"col-lg-12 text-center m-t-md\"> <h2> Welcome to biTRAZ admin campaigns </h2> <p>Special <strong>Analytic Trace Application</strong> for your mobile marketing campaigns.</p> </div> </div> <div class=\"row\"> <div class=\"col-sm-12\"> <ul> <li>list of campaigns</li> <li>add campaign</li> <li>edit campaign</li> </ul> </div> </div> </div> </div>");
}]);

angular.module("views/admin/components/clients_component_tmpl.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/admin/components/clients_component_tmpl.html",
    "");
}]);

angular.module("views/admin/header.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/admin/header.html",
    "<div id=\"logo\" class=\"light-version\" href=\"#\"> <a ng-href=\"#\"><span> bi <span class=\"part2\">TRAZ</span> </span></a> </div> <nav role=\"navigation\"> <!-- <minimaliza-menu></minimaliza-menu> --> <div class=\"small-logo\" ng-href=\"#\"> <a ng-href=\"#\"><span class=\"text-primary\">bi <span class=\"part2\">TRAZ</span></span></a> </div> <div class=\"mobile-menu\"> <button type=\"button\" class=\"navbar-toggle mobile-menu-toggle\" data-toggle=\"collapse\" data-target=\"#mobile-collapse\"> <i class=\"fa fa-chevron-down\"></i> </button> <div class=\"collapse mobile-navbar\" id=\"mobile-collapse\"> <ul class=\"nav navbar-nav\"> <li ng-class=\"{'active':active == 'home'}\"><a class=\"page-scroll\" href=\"#page-top\">Home</a></li> <li ng-class=\"{'active':active == 'analytics'}\"><a class=\"page-scroll\" page-scroll href=\"#analytics\">Analytics</a></li> <li ng-class=\"{'active':active == 'security'}\"><a class=\"page-scroll\" page-scroll href=\"#security\">Security </a></li> <li><a class=\"page-scroll\" page-scroll href=\"#\">Logout</a></li> </ul> </div> </div> <div class=\"navbar-right\"> <ul class=\"nav navbar-nav no-borders\"> <li uib-dropdown> <a ui-sref=\"bitraz.admin.index\" uib-dropdown-toggle> <i class=\"pe-7s-home\"></i> </a> </li> <li uib-dropdown> <a uib-dropdown-toggle> <i class=\"pe-7s-graph\"></i> </a> <div uib-dropdown-menu class=\"hdropdown bigmenu animated flipInX\"> <table> <tbody> <tr> <td> <a ui-sref=\"bitraz.admin.analytics\"> <i class=\"pe pe-7s-graph1 text-danger\"></i> <h5>Analytics</h5> </a>  <td> <a ui-sref=\"bitraz.admin.campaigns\"> <i class=\"pe pe-7s-portfolio text-info\"></i> <h5>Campaigns</h5> </a>   <tr> <td> <a ui-sref=\"bitraz.admin.users\"> <i class=\"pe pe-7s-users text-success\"></i> <h5>Users</h5> </a>  <td> <a ui-sref=\"bitraz.admin.archieves\"> <i class=\"pe pe-7s-box1 text-success\"></i> <h5>Archieve</h5> </a>    </table> </div> </li> <li> <a ui-sref=\"bitraz.admin.settings\"> <i class=\"pe-7s-config\"></i> </a> </li> <li> <a> <i class=\"pe-7s-power\"></i> </a> </li> </ul> </div> </nav>");
}]);

angular.module("views/admin/index.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/admin/index.html",
    "<!-- Main Wrapper --> <div id=\"wrapper\"> <div class=\"content\" animate-panel effect=\"zoomIn\"> <div class=\"row\"> <div class=\"col-lg-12 text-center m-t-md\"> <h2> Dashboard come here </h2> </div> </div> <div class=\"row\"> <div class=\"col-lg-12\"> <ul> <li>No. of Users.</li> <li>total views, yesterday, today, last week</li> <li>active campaigns</li> <li>total users logged into analytics page</li> <li>latest campaigns by last activity date</li> </ul> </div> </div> </div> </div>");
}]);

angular.module("views/admin/settings.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/admin/settings.html",
    "<!-- Main Wrapper --> <div id=\"wrapper\"> <div class=\"content\" animate-panel effect=\"zoomIn\"> <div class=\"row\"> <div class=\"col-lg-12 text-center m-t-md\"> <h2> Welcome to biTRAZ admin settings </h2> <p>Special <strong>Analytic Trace Application</strong> for your mobile marketing campaigns.</p> </div> </div> <div class=\"row\"> <div class=\"col-sm-12\"> <ul> <li>change password</li> <li>list admin users and roles, add/edit user</li> </ul> </div> </div> </div> </div>");
}]);

angular.module("views/admin/users.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/admin/users.html",
    "<!-- Main Wrapper --> <div id=\"wrapper\"> <div class=\"content\" animate-panel effect=\"zoomIn\"> <div class=\"row\"> <div class=\"col-lg-12\"> <h2> Users </h2> </div> </div> <div class=\"row\"> <div class=\"col-lg-8 col-md-10 col-sm-12\"> <ul class=\"list-inline text-right\"> <li><div class=\"btn btn-primary\" ng-click=\"addUser()\">Add User</div> </li> </ul> </div> </div> <div class=\"row\"> <div class=\"col-lg-8 col-md-10 col-sm-12\"> <div id=\"userList\" ui-grid=\"userListOptions\" class=\"grid\"></div> </div> </div> </div> </div>");
}]);

angular.module("views/admin/users/add_user.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/admin/users/add_user.html",
    "<div id=\"add_user\">\n" +
    "\n" +
    "    <div class=\"content\" animate-panel effect=\"zoomIn\">\n" +
    "        <div class=\"modal-header\">\n" +
    "            <h3 class=\"modal-title\" id=\"modal-title\">Add a User</h3>\n" +
    "        </div>\n" +
    "\n" +
    "            <ng-form class=\"form-horizontal\" name=\"$ctrl.newUserForm\" novalidate >\n" +
    "                <div class=\"modal-body\" id=\"modal-body\">\n" +
    "                    <div class=\"form-group\">\n" +
    "                        <label class=\"col-sm-2 control-label\">User Name</label>\n" +
    "\n" +
    "                        <div class=\"col-sm-10\">\n" +
    "                            <input type=\"text\" ng-required=\"true\" name=\"username\" placeholder=\"User Name\" class=\"form-control\" ng-model=\"$ctrl.newUser.UserName\" />\n" +
    "                            <small  class=\"form-text text-muted text-danger\" ng-if=\"$ctrl.newUserForm.username.$invalid && $ctrl.newUserForm.username.$touched\">\n" +
    "                                <span ng-if=\"$ctrl.newUserForm.username.$error.required\">Name is required</span>\n" +
    "                            </small>\n" +
    "                        </div>\n" +
    "\n" +
    "                    </div>\n" +
    "                    <div class=\"form-group\">\n" +
    "                        <label class=\"col-sm-2 control-label\">Email</label>\n" +
    "\n" +
    "                        <div class=\"col-sm-10\">\n" +
    "                            <input type=\"email\" ng-required=\"true\" name=\"email\" placeholder=\"Email\" class=\"form-control\" ng-model=\"$ctrl.newUser.Email\" />\n" +
    "                            <small  class=\"form-text text-muted text-danger\" ng-if=\"$ctrl.newUserForm.email.$invalid && $ctrl.newUserForm.email.$touched\">\n" +
    "                                <span ng-if=\"$ctrl.newUserForm.email.$error.required\">Email is required</span>\n" +
    "                                <span ng-if=\"!$ctrl.newUserForm.email.$error.required && $ctrl.newUserForm.email.$error.email\">Invalid Email</span>\n" +
    "                            </small>\n" +
    "                        </div>\n" +
    "                    </div>\n" +
    "\n" +
    "                    <div class=\"form-group\">\n" +
    "                        <label class=\"col-sm-2 control-label\">Password</label>\n" +
    "\n" +
    "                        <div class=\"col-sm-10\">\n" +
    "                            <input id=\"pw1\" type=\"password\" ng-required=\"true\" ng-minlength=\"8\" name=\"password\" placeholder=\"Password\" class=\"form-control\" ng-model=\"$ctrl.newUser.Password\" />\n" +
    "                            <small  class=\"form-text text-muted text-danger\" ng-if=\"$ctrl.newUserForm.password.$invalid && $ctrl.newUserForm.password.$touched\">\n" +
    "                                <span ng-if=\"$ctrl.newUserForm.password.$error.required\">Password is required</span>\n" +
    "                                <span ng-if=\"!$ctrl.newUserForm.password.$error.required && $ctrl.newUserForm.password.$error.minlength\">Minimum 8 characters are required.</span>\n" +
    "                            </small>\n" +
    "                        </div>\n" +
    "                    </div>\n" +
    "\n" +
    "                    <div class=\"form-group\">\n" +
    "                        <label class=\"col-sm-2 control-label\">Password</label>\n" +
    "\n" +
    "                        <div class=\"col-sm-10\">\n" +
    "                            <input id=\"pw2\" pw-check='pw1' type=\"password\" ng-required=\"true\" ng-minlength=\"8\" name=\"repassword\" placeholder=\"Password\" class=\"form-control\" ng-model=\"$ctrl.newUser.RePassword\" />\n" +
    "                            <small  class=\"form-text text-muted text-danger\" ng-if=\"$ctrl.newUserForm.repassword.$invalid && $ctrl.newUserForm.repassword.$touched\">\n" +
    "                                <span ng-if=\"$ctrl.newUserForm.repassword.$error.required\">Re Password is required</span>\n" +
    "                                <span ng-if=\"!$ctrl.newUserForm.repassword.$error.required && $ctrl.newUserForm.repassword.$error.minlength\">Minimum 8 characters are required.</span>\n" +
    "                                <span ng-if=\"!$ctrl.newUserForm.repassword.$error.required && !$ctrl.newUserForm.repassword.$error.minlength && $ctrl.newUserForm.repassword.$error.pwmatch\">Re Password Not Matched</span>\n" +
    "                            </small>\n" +
    "                        </div>\n" +
    "                    </div>\n" +
    "\n" +
    "                    <div class=\"form-group\">\n" +
    "                        <label class=\"col-sm-2 control-label\">Active</label>\n" +
    "\n" +
    "                        <div class=\"col-sm-10\">\n" +
    "                            <input type=\"checkbox\" name=\"isActive\"  class=\"form-control\" ng-model=\"$ctrl.newUser.IsActive\" />\n" +
    "                        </div>\n" +
    "                    </div>\n" +
    "                </div>\n" +
    "                <div class=\"modal-footer\">\n" +
    "                    <small class=\"text-danger\" ng-if=\"$ctrl.saveError\">Error: {{$ctrl.saveError}} </small>\n" +
    "                    <button class=\"btn btn-default\" type=\"submit\" ng-click=\"cancel()\">Cancel</button>\n" +
    "                    <button class=\"btn btn-primary\" type=\"submit\" ng-class=\"{'disabled': !$ctrl.newUserForm.$valid}\" ng-disabled=\"!$ctrl.newUserForm.$valid\"  ng-click=\"save($ctrl.newUser)\">Save changes</button>\n" +
    "                </div>\n" +
    "            </ng-form>\n" +
    "    </div>\n" +
    "</div>\n" +
    "");
}]);

angular.module("views/admin/users/change_password.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/admin/users/change_password.html",
    "<div id=\"edit_user\">\n" +
    "\n" +
    "    <div class=\"content\" animate-panel effect=\"zoomIn\">\n" +
    "        <div class=\"modal-header\">\n" +
    "            <h3 class=\"modal-title\" id=\"modal-title\">Change User Password</h3>\n" +
    "        </div>\n" +
    "\n" +
    "        <ng-form class=\"form-horizontal\" name=\"$ctrl.userForm\" novalidate >\n" +
    "            <div class=\"modal-body\" id=\"modal-body\">\n" +
    "                <div class=\"form-group\">\n" +
    "                    <label class=\"col-sm-2 control-label\">User Name</label>\n" +
    "\n" +
    "                    <div class=\"col-sm-10\">\n" +
    "                        {{$ctrl.user.UserName}}\n" +
    "                    </div>\n" +
    "\n" +
    "                </div>\n" +
    "                <div class=\"form-group\">\n" +
    "                    <label class=\"col-sm-2 control-label\">Email</label>\n" +
    "\n" +
    "                    <div class=\"col-sm-10\">\n" +
    "                        {{$ctrl.user.Email}}\n" +
    "                    </div>\n" +
    "                </div>\n" +
    "\n" +
    "                <div class=\"form-group\">\n" +
    "                    <label class=\"col-sm-2 control-label\">Password</label>\n" +
    "\n" +
    "                    <div class=\"col-sm-10\">\n" +
    "                        <input id=\"pw1\" type=\"password\" ng-required=\"true\" ng-minlength=\"8\" name=\"password\" placeholder=\"Password\" class=\"form-control\" ng-model=\"$ctrl.user.Password\" />\n" +
    "                        <small  class=\"form-text text-muted text-danger\" ng-if=\"$ctrl.userForm.password.$invalid && $ctrl.userForm.password.$touched\">\n" +
    "                            <span ng-if=\"$ctrl.userForm.password.$error.required\">Password is required</span>\n" +
    "                            <span ng-if=\"!$ctrl.userForm.password.$error.required && $ctrl.userForm.password.$error.minlength\">Minimum 8 characters are required.</span>\n" +
    "                        </small>\n" +
    "                    </div>\n" +
    "                </div>\n" +
    "\n" +
    "                <div class=\"form-group\">\n" +
    "                    <label class=\"col-sm-2 control-label\">Re-Password</label>\n" +
    "\n" +
    "                    <div class=\"col-sm-10\">\n" +
    "                        <input id=\"pw2\" pw-check='pw1' type=\"password\" ng-required=\"true\" ng-minlength=\"8\" name=\"repassword\" placeholder=\"Password\" class=\"form-control\" ng-model=\"$ctrl.user.RePassword\" />\n" +
    "                        <small  class=\"form-text text-muted text-danger\" ng-if=\"$ctrl.userForm.repassword.$invalid && $ctrl.userForm.repassword.$touched\">\n" +
    "                            <span ng-if=\"$ctrl.userForm.repassword.$error.required\">Re Password is required</span>\n" +
    "                            <span ng-if=\"!$ctrl.userForm.repassword.$error.required && $ctrl.userForm.repassword.$error.minlength\">Minimum 8 characters are required.</span>\n" +
    "                            <span ng-if=\"!$ctrl.userForm.repassword.$error.required && !$ctrl.userForm.repassword.$error.minlength && $ctrl.userForm.repassword.$error.pwmatch\">Re Password Not Matched</span>\n" +
    "                        </small>\n" +
    "                    </div>\n" +
    "                </div>\n" +
    "\n" +
    "                <div class=\"form-group\">\n" +
    "                    <label class=\"col-sm-2 control-label\">Active</label>\n" +
    "\n" +
    "                    <div class=\"col-sm-10\">\n" +
    "                        {{!!$ctrl.user.IsActive}}\n" +
    "                    </div>\n" +
    "                </div>\n" +
    "            </div>\n" +
    "            <div class=\"modal-footer\">\n" +
    "                <small class=\"text-danger\" ng-if=\"$ctrl.saveError\">Error: {{$ctrl.saveError}} </small>\n" +
    "                <button class=\"btn btn-default\" type=\"submit\" ng-click=\"cancel()\">Cancel</button>\n" +
    "                <button class=\"btn btn-primary\" type=\"submit\" ng-class=\"{'disabled': !$ctrl.userForm.$valid}\" ng-disabled=\"!$ctrl.userForm.$valid\"  ng-click=\"save($ctrl.user)\">Save changes</button>\n" +
    "            </div>\n" +
    "        </ng-form>\n" +
    "    </div>\n" +
    "</div>\n" +
    "");
}]);

angular.module("views/admin/users/edit_user.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/admin/users/edit_user.html",
    "<div id=\"edit_user\">\n" +
    "\n" +
    "    <div class=\"content\" animate-panel effect=\"zoomIn\">\n" +
    "        <div class=\"modal-header\">\n" +
    "            <h3 class=\"modal-title\" id=\"modal-title\">Edit a User</h3>\n" +
    "        </div>\n" +
    "\n" +
    "        <ng-form class=\"form-horizontal\" name=\"$ctrl.userForm\" novalidate >\n" +
    "            <div class=\"modal-body\" id=\"modal-body\">\n" +
    "                <div class=\"form-group\">\n" +
    "                    <label class=\"col-sm-2 control-label\">User Name</label>\n" +
    "\n" +
    "                    <div class=\"col-sm-10\">\n" +
    "                        <input type=\"text\" ng-required=\"true\" name=\"username\" placeholder=\"User Name\" class=\"form-control\" ng-model=\"$ctrl.user.UserName\" />\n" +
    "                        <small  class=\"form-text text-muted text-danger\" ng-if=\"$ctrl.userForm.username.$invalid && $ctrl.userForm.username.$touched\">\n" +
    "                            <span ng-if=\"$ctrl.userForm.username.$error.required\">Name is required</span>\n" +
    "                        </small>\n" +
    "                    </div>\n" +
    "\n" +
    "                </div>\n" +
    "                <div class=\"form-group\">\n" +
    "                    <label class=\"col-sm-2 control-label\">Email</label>\n" +
    "\n" +
    "                    <div class=\"col-sm-10\">\n" +
    "                        {{$ctrl.user.Email}}\n" +
    "                        <!--<input type=\"email\" ng-required=\"true\" name=\"email\" placeholder=\"Email\" class=\"form-control\" ng-model=\"$ctrl.user.Email\" />-->\n" +
    "                        <!--<small  class=\"form-text text-muted text-danger\" ng-if=\"$ctrl.userForm.email.$invalid && $ctrl.userForm.email.$touched\">-->\n" +
    "                            <!--<span ng-if=\"$ctrl.userForm.email.$error.required\">Email is required</span>-->\n" +
    "                            <!--<span ng-if=\"!$ctrl.userForm.email.$error.required && $ctrl.userForm.email.$error.email\">Invalid Email</span>-->\n" +
    "                        <!--</small>-->\n" +
    "                    </div>\n" +
    "                </div>\n" +
    "\n" +
    "                <div class=\"form-group\">\n" +
    "                    <label class=\"col-sm-2 control-label\">Active</label>\n" +
    "\n" +
    "                    <div class=\"col-sm-10\">\n" +
    "                        <input type=\"checkbox\" name=\"isActive\"  class=\"form-control\" ng-model=\"$ctrl.user.IsActive\" />\n" +
    "                    </div>\n" +
    "                </div>\n" +
    "            </div>\n" +
    "            <div class=\"modal-footer\">\n" +
    "                <small class=\"text-danger\" ng-if=\"$ctrl.saveError\">Error: {{$ctrl.saveError}} </small>\n" +
    "                <button class=\"btn btn-default\" type=\"submit\" ng-click=\"cancel()\">Cancel</button>\n" +
    "                <button class=\"btn btn-primary\" type=\"submit\" ng-class=\"{'disabled': !$ctrl.userForm.$valid}\" ng-disabled=\"!$ctrl.userForm.$valid\"  ng-click=\"save($ctrl.user)\">Save changes</button>\n" +
    "            </div>\n" +
    "        </ng-form>\n" +
    "    </div>\n" +
    "</div>\n" +
    "");
}]);

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
