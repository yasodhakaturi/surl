angular.module('bitraz.template', ['views/admin/admin.html', 'views/admin/analytics.html', 'views/admin/archieves.html', 'views/admin/campaigns.html', 'views/admin/components/clients_component_tmpl.html', 'views/admin/header.html', 'views/admin/index.html', 'views/admin/settings.html', 'views/admin/users.html', 'views/admin/users/add_user.html', 'views/admin/users/change_password.html', 'views/admin/users/edit_user.html', 'views/common/analytics.html', 'views/common/dashboard/activities_tmpl.html', 'views/common/dashboard/dashboard_tmpl.html', 'views/common/dashboard/logged_users_tmpl.html', 'views/common/dashboard/recent_campaigns_tmpl.html', 'views/common/dashboard/total_campaigns_tmpl.html', 'views/common/dashboard/total_users_tmpl.html', 'views/common/dashboard/total_visits_tmpl.html', 'views/common/dashboard/urls_generated_tmpl.html', 'views/common/directives/analytics_layout.html', 'views/common/header-dashboard.html', 'views/common/login.html', 'views/common/navigation.html', 'views/common/panel_tools.html']);

angular.module("views/admin/admin.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/admin/admin.html",
    "<!-- Header --> <div id=\"header\" ng-include=\"'views/common/header-dashboard.html'\"></div> <!-- Navigation --> <!-- <aside id=\"menu\" ng-include=\"'views/common/navigation.html'\"></aside> --> <!-- Main Wrapper --> <div id=\"wrapper\"> <div class=\"content\" animate-panel effect=\"zoomIn\"> <div class=\"row\"> <div class=\"col-lg-12 text-center m-t-md\"> <h2> Welcome to biTRAZ Admin. </h2> <p>Special <strong>Analytic Trace Application</strong> for your mobile marketing campaigns.</p> </div> </div> </div> </div>");
}]);

angular.module("views/admin/analytics.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/admin/analytics.html",
    "<!-- Main Wrapper --> <div id=\"wrapper\"> <div class=\"content\" animate-panel effect=\"zoomIn\"> <div class=\"row\"> <div class=\"col-lg-12 text-right\"> <span> Choose a Campaign</span> <select name=\"selectedCampaign\" ng-model=\"selectedCampaign\"> <option value=\"{{campaign.rid}}\" ng-repeat=\"campaign in campaigns\"> {{campaign.title || \"Campaign (\" + campaign.rid + \")\"}} : {{campaign.createdOn | date: 'MM/dd/yyyy'}} - {{campaign.endDate | date: 'MM/dd/yyyy' || 'Till Date'}} </select> </div> </div> <div class=\"row\"> <div class=\"col-lg-12\"> <analytics-layout campaign-id=\"selectedCampaign\" data-range=\"selectedCampaign\"></analytics-layout> </div> </div> <div class=\"row\"> <div class=\"col-lg-12\"> </div> </div> </div> </div>");
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
    "<div id=\"logo\" class=\"light-version\"> <a ng-href=\"#\"><span class=\"logo\"></span></a> </div> <nav role=\"navigation\"> <!-- <minimaliza-menu></minimaliza-menu> --> <div class=\"small-logo\"> <a ng-href=\"#\"><span class=\"logo\"></span></a> </div> <div class=\"mobile-menu\" ng-if=\"$root.userInfo.user_id\"> <button type=\"button\" class=\"navbar-toggle mobile-menu-toggle\" data-toggle=\"collapse\" data-target=\"#mobile-collapse\"> <i class=\"fa fa-chevron-down\"></i> </button> <div class=\"collapse mobile-navbar\" id=\"mobile-collapse\"> <ul class=\"nav navbar-nav\"> <li ng-class=\"{'active':active == 'home'}\"><a class=\"page-scroll\" href=\"#page-top\">Home</a></li> <li ng-class=\"{'active':active == 'analytics'}\"><a class=\"page-scroll\" page-scroll href=\"#analytics\">Analytics</a></li> <li ng-class=\"{'active':active == 'security'}\"><a class=\"page-scroll\" page-scroll href=\"#security\">Security </a></li> <li><a class=\"page-scroll\" page-scroll ng-click=\"logout()\">Logout</a></li> </ul> </div> </div> <div class=\"navbar-right\" ng-if=\"$root.userInfo.user_id\"> <ul class=\"nav navbar-nav no-borders\"> <li uib-dropdown> <a ui-sref=\"bitraz.main.index\" uib-dropdown-toggle> <i class=\"pe-7s-home\"></i> </a> </li> <li uib-dropdown> <a uib-dropdown-toggle> <i class=\"pe-7s-graph\"></i> </a> <div uib-dropdown-menu class=\"hdropdown bigmenu animated flipInX\"> <table> <tbody> <tr> <td> <a ui-sref=\"bitraz.main.analytics\"> <i class=\"pe pe-7s-graph1 text-danger\"></i> <h5>Analytics</h5> </a>  <td> <a ui-sref=\"bitraz.main.campaigns\"> <i class=\"pe pe-7s-portfolio text-info\"></i> <h5>Campaigns</h5> </a>   <tr> <td> <a ui-sref=\"bitraz.main.users\"> <i class=\"pe pe-7s-users text-success\"></i> <h5>Users</h5> </a>  <td> <a ui-sref=\"bitraz.main.archieves\"> <i class=\"pe pe-7s-box1 text-success\"></i> <h5>Archieve</h5> </a>    </table> </div> </li> <li> <a ui-sref=\"bitraz.main.settings\"> <i class=\"pe-7s-config\"></i> </a> </li> <li> <a ng-click=\"logout()\"> <i class=\"pe-7s-power\"></i> </a> </li> </ul> </div> </nav>");
}]);

angular.module("views/admin/index.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/admin/index.html",
    "<!-- Main Wrapper --> <div id=\"wrapper\"> <div class=\"content\" animate-panel effect=\"zoomIn\"> <div class=\"row\"> <div class=\"col-lg-12\"> <h2> Summary </h2> </div> </div> <dashboard-layout config=\"dashboardConfig\"></dashboard-layout> </div> </div>");
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

angular.module("views/common/analytics.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/common/analytics.html",
    "<!-- Main Wrapper --> <div id=\"wrapper\"> <div class=\"content\" animate-panel effect=\"zoomIn\" ng-if=\"isLoaded\"> <div class=\"row\"> <div class=\"col-lg-12 text-right\"> <span> Choose a Campaign</span> <select name=\"selectedCampaign\" ng-model=\"selectedCampaign\" ng-change=\"campaignChange(selectedCampaign)\"> <option value=\"{{campaign.rid}}\" ng-repeat=\"campaign in campaigns\" ng-selected=\"campaign.rid == selectedCampaign\"> {{campaign.title || \"Campaign (\" + campaign.rid + \")\"}} : {{campaign.createdOn | date: 'mm.dd.yyyy'}} - {{campaign.inActiveDate | date: 'mm.dd.yyyy' || 'Till Date'}} </select> </div> </div> <div class=\"row\"> <div class=\"col-lg-12\"> <analytics-layout campaign-id=\"selectedCampaign\"></analytics-layout> </div> </div> <div class=\"row\"> <div class=\"col-lg-12\"> </div> </div> </div> </div>");
}]);

angular.module("views/common/dashboard/activities_tmpl.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/common/dashboard/activities_tmpl.html",
    "<div class=\"hpanel\">\n" +
    "    <div class=\"panel-heading\" ng-if=\"$ctrl.header\">\n" +
    "        <div class=\"panel-tools\">\n" +
    "        </div>\n" +
    "        Activity\n" +
    "    </div>\n" +
    "    <div class=\"panel-body list\">\n" +
    "\n" +
    "        <div class=\"pull-right\">\n" +
    "            <a ng-click=\"$ctrl.show('today')\" class=\"btn btn-xs btn-default\" ng-class=\"{'text-success': $ctrl.state == 'today'}\">Today</a>\n" +
    "            <a ng-click=\"$ctrl.show('last7days')\" class=\"btn btn-xs btn-default \" ng-class=\"{'text-success': $ctrl.state == 'last7days'}\">Week</a>\n" +
    "            <a ng-click=\"$ctrl.show('month')\" class=\"btn btn-xs btn-default\" ng-class=\"{'text-success': $ctrl.state == 'month'}\">Month</a>\n" +
    "        </div>\n" +
    "        <div class=\"panel-title\">Last Activity</div>\n" +
    "        <div class=\"list-item-container\" style=\"width: 100%\">\n" +
    "            <div class=\"list-item\">\n" +
    "                <h3 class=\"no-margins font-extra-bold text-success\" ng-bind=\"$ctrl.activeData.urlTotal || 0 | number\"></h3>\n" +
    "                <small>Total Urls Generated</small>\n" +
    "                <div class=\"pull-right font-bold\">{{$ctrl.activeData.urlPercent || 0 | number}}% <i class=\"fa fa-level-up text-success\"></i></div>\n" +
    "            </div>\n" +
    "            <div class=\"list-item\">\n" +
    "                <h3 class=\"no-margins font-extra-bold text-color3\" ng-bind=\"$ctrl.activeData.visitsTotal || 0 | number\"></h3>\n" +
    "                <small>visited</small>\n" +
    "                <div class=\"pull-right font-bold\">{{$ctrl.activeData.visitsPercent || 0 | number}}% <i class=\"fa fa-level-down text-color3\"></i></div>\n" +
    "            </div>\n" +
    "\n" +
    "            <div class=\"list-item\">\n" +
    "                <h3 class=\"no-margins font-extra-bold text-info\" ng-bind=\"$ctrl.activeData.revisitsTotal || 0 | number\"></h3>\n" +
    "                <small>Revisited</small>\n" +
    "                <div class=\"pull-right font-bold\">{{$ctrl.activeData.revisitsPercent || 0}}% <i class=\"fa fa-bolt text-color3\"></i></div>\n" +
    "            </div>\n" +
    "            <div class=\"list-item\" ng-if=\"$ctrl.header\">\n" +
    "                <h3 class=\"no-margins font-extra-bold text-warning\" ng-bind=\"$ctrl.activeData.noVisitsTotal || 0 | number\"></h3>\n" +
    "                <small>Never Visited</small>\n" +
    "                <div class=\"pull-right font-bold\">{{$ctrl.activeData.noVisitsPercent || 0}}% <i class=\"fa fa-level-up text-success\"></i></div>\n" +
    "            </div>\n" +
    "        </div>\n" +
    "\n" +
    "    </div>\n" +
    "</div>");
}]);

angular.module("views/common/dashboard/dashboard_tmpl.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/common/dashboard/dashboard_tmpl.html",
    "<div class=\"dashboard-container\" ng-if=\"$ctrl.config && $ctrl.config.type == 'all'\">\n" +
    "    <div class=\"row\">\n" +
    "        <div class=\"col-lg-3 col-md-6\">\n" +
    "            <urls-generated data=\"$ctrl.data.totalUrls\" is-campaign=\"!!$ctrl.config.campaignId\"></urls-generated>\n" +
    "        </div>\n" +
    "        <div class=\"col-lg-3 col-md-6\">\n" +
    "            <total-users data=\"$ctrl.data.users\" is-campaign=\"!!$ctrl.config.campaignId\"></total-users>\n" +
    "        </div>\n" +
    "        <div class=\"col-lg-3 col-md-6\">\n" +
    "            <total-visits data=\"$ctrl.data.visits\" is-campaign=\"!!$ctrl.config.campaignId\"></total-visits>\n" +
    "        </div>\n" +
    "\n" +
    "        <div class=\"col-lg-3 col-md-6\">\n" +
    "            <total-campaigns data=\"$ctrl.data.campaigns\" is-campaign=\"!!$ctrl.config.campaignId\"></total-campaigns>\n" +
    "        </div>\n" +
    "\n" +
    "\n" +
    "    </div>\n" +
    "    <div class=\"row\">\n" +
    "\n" +
    "        <div class=\"col-lg-6\">\n" +
    "            <recent-campaigns data=\"$ctrl.data.recentCampaigns\"></recent-campaigns>\n" +
    "        </div>\n" +
    "\n" +
    "        <div class=\"col-lg-3\">\n" +
    "            <activities data=\"$ctrl.data.activities\" header=\"true\" is-campaign=\"!!$ctrl.config.campaignId\"></activities>\n" +
    "        </div>\n" +
    "\n" +
    "        <div class=\"col-lg-3\">\n" +
    "            <!--<logged-users data=\"$ctrl.data.loggedInUsers\"></logged-users>-->\n" +
    "        </div>\n" +
    "\n" +
    "    </div>\n" +
    "</div>\n" +
    "\n" +
    "<div class=\"dashboard-container\" ng-if=\"$ctrl.config && $ctrl.config.type == 'campaign'\">\n" +
    "    <div class=\"row\">\n" +
    "        <div class=\"col-lg-3 col-md-6\">\n" +
    "            <urls-generated data=\"$ctrl.data.totalUrls\" is-campaign=\"!!$ctrl.config.campaignId\"></urls-generated>\n" +
    "        </div>\n" +
    "        <div class=\"col-lg-3 col-md-6\">\n" +
    "            <total-users data=\"$ctrl.data.users\" is-campaign=\"!!$ctrl.config.campaignId\"></total-users>\n" +
    "        </div>\n" +
    "        <div class=\"col-lg-3 col-md-6\">\n" +
    "            <total-visits data=\"$ctrl.data.visits\" is-campaign=\"!!$ctrl.config.campaignId\"></total-visits>\n" +
    "        </div>\n" +
    "        <div class=\"col-lg-3 col-md-6\">\n" +
    "            <activities data=\"$ctrl.data.activities\" is-campaign=\"!!$ctrl.config.campaignId\" header=\"false\"></activities>\n" +
    "        </div>\n" +
    "\n" +
    "    </div>\n" +
    "</div>");
}]);

angular.module("views/common/dashboard/logged_users_tmpl.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/common/dashboard/logged_users_tmpl.html",
    "<div class=\"hpanel\">\n" +
    "    <div class=\"panel-heading\">\n" +
    "        <div class=\"panel-tools\">\n" +
    "\n" +
    "        </div>\n" +
    "        Members\n" +
    "    </div>\n" +
    "    <div class=\"panel-body h-200\">\n" +
    "        <div class=\"stats-title pull-left\">\n" +
    "            <h4>Logged Into Analytics Page</h4>\n" +
    "        </div>\n" +
    "        <div class=\"stats-icon pull-right\">\n" +
    "            <i class=\"pe-7s-graph2 fa-4x\"></i>\n" +
    "        </div>\n" +
    "\n" +
    "        <div class=\"m-t-xl\">\n" +
    "            <h1 class=\"text-success\">{{$ctrl.data.total || 0}}</h1>\n" +
    "                                <span class=\"font-bold no-margins\">\n" +
    "\n" +
    "                                </span>\n" +
    "            <div class=\"row\">\n" +
    "                <div class=\"col-xs-4\">\n" +
    "                    <small class=\"stats-label\">Today </small>\n" +
    "                    <h4>{{$ctrl.data.totalToday || 0}}</h4>\n" +
    "                </div>\n" +
    "\n" +
    "                <div class=\"col-xs-4\">\n" +
    "                    <small class=\"stats-label\">Yesterday</small>\n" +
    "                    <h4>{{$ctrl.data.totalYesterday || 0}}</h4>\n" +
    "                </div>\n" +
    "\n" +
    "                <div class=\"col-xs-4\">\n" +
    "                    <small class=\"stats-label\">This Week</small>\n" +
    "                    <h4>{{$ctrl.data.totalWeek || 0}}</h4>\n" +
    "                </div>\n" +
    "            </div>\n" +
    "        </div>\n" +
    "    </div>\n" +
    "</div>");
}]);

angular.module("views/common/dashboard/recent_campaigns_tmpl.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/common/dashboard/recent_campaigns_tmpl.html",
    "<div class=\"hpanel\">\n" +
    "    <div class=\"panel-heading\">\n" +
    "        <div class=\"panel-tools\">\n" +
    "\n" +
    "        </div>\n" +
    "        Recent campaigns\n" +
    "    </div>\n" +
    "    <div class=\"panel-body list\">\n" +
    "        <div class=\"table-responsive project-list\">\n" +
    "            <table class=\"table table-striped\">\n" +
    "                <thead>\n" +
    "                <tr>\n" +
    "\n" +
    "                    <th colspan=\"1\">Campaigns</th>\n" +
    "                    <th>Urls</th>\n" +
    "                    <th>Visits</th>\n" +
    "                    <th>Status</th>\n" +
    "                </tr>\n" +
    "                </thead>\n" +
    "                <tbody>\n" +
    "                <tr ng-if=\"$ctrl.data.length > 0\" ng-repeat=\"campaign in $ctrl.data\">\n" +
    "                    <td><a class=\"text-success\" ui-sref=\"bitraz.main.analytics({rid:campaign.rid})\">{{campaign.title || \"Campaign (\" + campaign.rid + \")\"}}</a>\n" +
    "                        <br/>\n" +
    "                        <small><i class=\"fa fa-clock-o\"></i> Created {{campaign.createdOn | date: 'MM.dd.yyyy'}}</small>\n" +
    "                        <small ng-if=\"campaign.endDate\"><i class=\"fa fa-clock-o\"></i> Ended {{campaign.endDate | date: 'MM.dd.yyyy'}}</small>\n" +
    "                    </td>\n" +
    "                    <td>\n" +
    "                        <span class=\"pie\">{{campaign.users}}</span>\n" +
    "                    </td>\n" +
    "                    <td><strong>{{(campaign.visits/campaign.users)*100 | number:0}}%</strong></td>\n" +
    "                    <td><span>{{campaign.status ? 'Active':'InActive'}}</span></td>\n" +
    "                </tr>\n" +
    "                <tr ng-if=\"!$ctrl.data\"><td colspan=\"4\" class=\"text-center\">No Campaigns</td> </tr>\n" +
    "                </tbody>\n" +
    "            </table>\n" +
    "        </div>\n" +
    "    </div>\n" +
    "</div>");
}]);

angular.module("views/common/dashboard/total_campaigns_tmpl.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/common/dashboard/total_campaigns_tmpl.html",
    "<div class=\"hpanel stats\">\n" +
    "    <div class=\"panel-body h-200\">\n" +
    "        <div class=\"stats-title pull-left\">\n" +
    "            <h4>Total Campaigns</h4>\n" +
    "        </div>\n" +
    "        <div class=\"stats-icon pull-right\">\n" +
    "            <i class=\"pe-7s-science fa-4x\"></i>\n" +
    "        </div>\n" +
    "        <div class=\"m-t-xl\">\n" +
    "            <h3 class=\"m-b-xs\">{{$ctrl.data.total || 0}}</h3>\n" +
    "                    <span class=\"font-bold no-margins\">\n" +
    "                        Active Campaigns\n" +
    "                    </span>\n" +
    "            <div class=\"row\">\n" +
    "                <div class=\"col-xs-6\">\n" +
    "                    <small class=\"stats-label\">This Week</small>\n" +
    "                    <h4>{{$ctrl.data.campaignsLast7days || 0}}</h4>\n" +
    "                </div>\n" +
    "\n" +
    "                <div class=\"col-xs-6\">\n" +
    "                    <small class=\"stats-label\">This Month</small>\n" +
    "                    <h4>{{$ctrl.data.campaignsMonth || 0}}</h4>\n" +
    "                </div>\n" +
    "            </div>\n" +
    "        </div>\n" +
    "    </div>\n" +
    "</div>");
}]);

angular.module("views/common/dashboard/total_users_tmpl.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/common/dashboard/total_users_tmpl.html",
    "<div class=\"hpanel stats\">\n" +
    "    <div class=\"panel-body h-200\">\n" +
    "        <div class=\"stats-title pull-left\">\n" +
    "            <h4>Total Users</h4>\n" +
    "        </div>\n" +
    "        <div class=\"stats-icon pull-right\">\n" +
    "            <i class=\"pe-7s-share fa-4x\"></i>\n" +
    "        </div>\n" +
    "        <div class=\"m-t-xl\">\n" +
    "            <h3 class=\"m-b-xs text-success\" ng-bind=\"$ctrl.data.total || 0 | number\"></h3>\n" +
    "                            <span class=\"font-bold no-margins\" ng-if=\"$ctrl.isCampaign\">\n" +
    "                                Unique users in this campaign\n" +
    "                            </span>\n" +
    "                            <span class=\"font-bold no-margins\" ng-if=\"!$ctrl.isCampaign\">\n" +
    "                                Unique users across all campaigns\n" +
    "                            </span>\n" +
    "\n" +
    "            <div class=\"progress m-t-xs full progress-small\" ng-init=\"percent = ($ctrl.data.uniqueUsers || 0)/($ctrl.data.total || 1)\">\n" +
    "                <div style=\"width: {{percent}}%\" aria-valuemax=\"100\" aria-valuemin=\"0\" aria-valuenow=\"{{percent}}\"\n" +
    "                     role=\"progressbar\" class=\" progress-bar progress-bar-success\">\n" +
    "                    <span class=\"sr-only\">{{percent}}% Unique Users</span>\n" +
    "                </div>\n" +
    "            </div>\n" +
    "\n" +
    "            <div class=\"row\">\n" +
    "                <div class=\"col-xs-4\">\n" +
    "                    <small class=\"stats-label\">Today </small>\n" +
    "                    <h4>{{$ctrl.data.uniqueUsersToday || 0}}/<span class=\"text-success\">{{$ctrl.data.usersToday || 0}}</span> </h4>\n" +
    "                </div>\n" +
    "\n" +
    "                <div class=\"col-xs-4\">\n" +
    "                    <small class=\"stats-label\">Yesterday</small>\n" +
    "                    <h4>{{$ctrl.data.uniqueUsersYesterday || 0}}/<span class=\"text-success\">{{$ctrl.data.usersYesterday || 0}}</span></h4>\n" +
    "                </div>\n" +
    "\n" +
    "                <div class=\"col-xs-4\">\n" +
    "                    <small class=\"stats-label\">Last 7 Days</small>\n" +
    "                    <h4>{{$ctrl.data.uniqueUsersLast7days || 0}}/<span class=\"text-success\">{{$ctrl.data.usersLast7days || 0}}</span></h4>\n" +
    "                </div>\n" +
    "            </div>\n" +
    "        </div>\n" +
    "    </div>\n" +
    "</div>");
}]);

angular.module("views/common/dashboard/total_visits_tmpl.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/common/dashboard/total_visits_tmpl.html",
    "<div class=\"hpanel stats\">\n" +
    "    <div class=\"panel-body h-200\">\n" +
    "        <div class=\"stats-title pull-left\">\n" +
    "            <h4>Total Visits</h4>\n" +
    "        </div>\n" +
    "        <div class=\"stats-icon pull-right\">\n" +
    "            <i class=\"pe-7s-monitor fa-4x\"></i>\n" +
    "        </div>\n" +
    "        <div class=\"m-t-xl\">\n" +
    "            <h3 class=\"m-b-xs text-success\" ng-bind=\"$ctrl.data.total || 0 | number\"></h3>\n" +
    "                            <span class=\"font-bold no-margins\">\n" +
    "                                Unique users visited\n" +
    "                            </span>\n" +
    "\n" +
    "            <div class=\"progress m-t-xs full progress-small\" ng-init=\"percent = ($ctrl.data.visits || 0) / ($ctrl.data.uniqueVisits || 0)\">\n" +
    "                <div style=\"width: {{percent}}%\" aria-valuemax=\"100\" aria-valuemin=\"0\" aria-valuenow=\"{{percent}}\"\n" +
    "                     role=\"progressbar\" class=\" progress-bar progress-bar-success\">\n" +
    "                    <span class=\"sr-only\">{{percent}}% Unique Visits</span>\n" +
    "                </div>\n" +
    "            </div>\n" +
    "\n" +
    "            <div class=\"row\">\n" +
    "                <div class=\"col-xs-4\">\n" +
    "                    <small class=\"stats-label\">Today </small>\n" +
    "                    <h4>{{$ctrl.data.uniqueVisitsToday || 0}}/<span class=\"text-success\">{{$ctrl.data.visitsToday || 0}}</span></h4>\n" +
    "                </div>\n" +
    "\n" +
    "                <div class=\"col-xs-4\">\n" +
    "                    <small class=\"stats-label\">Yesterday</small>\n" +
    "                    <h4>{{$ctrl.data.uniqueVisitsYesterday || 0}}/<span class=\"text-success\">{{$ctrl.data.visitsYesterday || 0}}</span></h4>\n" +
    "                </div>\n" +
    "\n" +
    "                <div class=\"col-xs-4\">\n" +
    "                    <small class=\"stats-label\">Last 7 Days</small>\n" +
    "                    <h4>{{$ctrl.data.uniqueVisitsLast7days || 0}}/<span class=\"text-success\">{{$ctrl.data.visitsLast7days || 0}}</span></h4>\n" +
    "                </div>\n" +
    "            </div>\n" +
    "        </div>\n" +
    "    </div>\n" +
    "</div>");
}]);

angular.module("views/common/dashboard/urls_generated_tmpl.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/common/dashboard/urls_generated_tmpl.html",
    "<div class=\"hpanel\">\n" +
    "    <div class=\"panel-body text-center h-200\">\n" +
    "        <i class=\"pe-7s-graph1 fa-4x\"></i>\n" +
    "\n" +
    "        <h1 class=\"m-xs\" ng-bind=\"$ctrl.data.count || 0 | number\"></h1>\n" +
    "\n" +
    "        <h3 class=\"font-extra-bold no-margins text-success\">\n" +
    "            Url's Generated\n" +
    "        </h3>\n" +
    "        <small>Total number of urls generated</small>\n" +
    "    </div>\n" +
    "\n" +
    "</div>");
}]);

angular.module("views/common/directives/analytics_layout.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/common/directives/analytics_layout.html",
    "<section class=\"anlaytics-layout-container \" style=\"padding-top:0px;\">\n" +
    "    <div class=\"row\" style=\"padding-bottom: 5px;\">\n" +
    "        <div class=\"col-lg-12 refresh-block\">\n" +
    "            <span class=\"pull-right\">\n" +
    "                <!--View Refreshes in {{$ctrl.timeLeft}} Seconds <a ng-click=\"$ctrl.resetTime()\"><i class=\"fa fa-refresh\"></i></a>-->\n" +
    "                Refresh View <a ng-click=\"$ctrl.resetTime()\"><i class=\"fa fa-refresh\"></i></a>\n" +
    "            </span>\n" +
    "\n" +
    "        </div>\n" +
    "    </div>\n" +
    "    <div class=\"row\">\n" +
    "        <dashboard-layout config=\"$ctrl.dashboardConfig\"></dashboard-layout>\n" +
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

angular.module("views/common/login.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/common/login.html",
    "<div class=\"login-container\"> <div class=\"row\"> <div class=\"col-md-12\"> <div class=\"text-center m-b-md\" style=\"border: 1px solid transparent\"> <h3>LOGIN</h3> <!-- <small> This is the best app ever!</small> --> </div> <div class=\"hpanel\"> <div class=\"panel-body\"> <form name=\"loginForm\" id=\"loginForm\" novalidate ng-submit=\"login()\"> <div class=\"form-group\"> <label class=\"control-label\" for=\"username\">Username</label> <input type=\"text\" placeholder=\"name@your_domain.com\" title=\"Please enter you username\" ng-model=\"uname\" ng-required=\"true\" value=\"\" name=\"username\" id=\"username\" class=\"form-control\"> </div> <span ng-if=\"loginForm.username.$touched && loginForm.username.$error.required\" class=\"text-danger\">Name is required</span> <div class=\"form-group\"> <label class=\"control-label\" for=\"password\">Password</label> <input type=\"password\" title=\"Please enter your password\" ng-required=\"true\" ng-model=\"pswd\" name=\"password\" id=\"password\" class=\"form-control\"> </div> <span ng-if=\"loginForm.password.$touched && loginForm.password.$error.required\" class=\"text-danger\">Password is required</span> <button class=\"btn btn-success btn-block\" type=\"submit\"><span ng-show=\"!loading\">Login</span><span ng-show=\"loading\"><i class=\"fa fa-refresh fa-spin\"></i> </span></button> <span class=\"text-danger\" ng-if=\"loginError\" class=\"text-danger\">Error: {{loginError}} </span> </form> </div> </div> </div> </div> </div>");
}]);

angular.module("views/common/navigation.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/common/navigation.html",
    "<div id=\"navigation\"> <div class=\"profile-picture\"> <div class=\"stats-label text-color\"> <span class=\"font-extra-bold font-uppercase\">Username</span> <div class=\"dropdown\" uib-dropdown> <a uib-dropdown-toggle href=\"#\"> <small class=\"text-muted\">Founder of App <b class=\"caret\"></b></small> </a> <ul uib-dropdown-menu class=\"animated flipInX m-t-xs\"> <li><a>Item</a></li> </ul> </div> </div> </div> <ul side-navigation class=\"nav metismenu\" id=\"side-menu\"> <li ui-sref-active=\"active\"> <a ui-sref=\"dashboard\"> <span class=\"nav-label\">Dashboard</span></a> </li> </ul> </div>");
}]);

angular.module("views/common/panel_tools.html", []).run(["$templateCache", function($templateCache) {
  $templateCache.put("views/common/panel_tools.html",
    "<!-- This is template for panel tools --><!-- It contains collapse function (showhide) and close function (closebox) --><!-- All function is handled from directive panelTools in directives.js file --> <div class=\"panel-tools\"> <a ng-click=\"showhide()\"><i class=\"fa fa-chevron-up\"></i></a> <a ng-click=\"closebox()\"><i class=\"fa fa-times\"></i></a> </div>");
}]);
