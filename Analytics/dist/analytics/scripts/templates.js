angular.module('bitraz.template', ['views/analytics/analytics.html', 'views/analytics/archieves.html', 'views/analytics/campaigns.html', 'views/analytics/campaigns/add_campaign.html', 'views/analytics/campaigns/campaign_list.html', 'views/analytics/campaigns/edit_campaign.html', 'views/analytics/header.html', 'views/analytics/index.html', 'views/analytics/settings.html', 'views/analytics/users.html', 'views/analytics/users/change_password.html', 'views/common/analytics.html', 'views/common/dashboard/activities_tmpl.html', 'views/common/dashboard/dashboard_tmpl.html', 'views/common/dashboard/logged_users_tmpl.html', 'views/common/dashboard/recent_campaigns_tmpl.html', 'views/common/dashboard/total_campaigns_tmpl.html', 'views/common/dashboard/total_users_tmpl.html', 'views/common/dashboard/total_visits_tmpl.html', 'views/common/dashboard/urls_generated_tmpl.html', 'views/common/directives/analytics_layout.html', 'views/common/header-dashboard.html', 'views/common/login.html', 'views/common/navigation.html', 'views/common/panel_tools.html']);

angular.module("views/analytics/analytics.html", []).run(["$templateCache", function ($templateCache) {
  $templateCache.put("views/analytics/analytics.html",
    "<!-- Main Wrapper --> <div id=\"wrapper\"> <div class=\"content\" animate-panel effect=\"zoomIn\"> <div class=\"row\"> <div class=\"col-lg-12 text-right\"> <span> Choose a Campaign</span> <select name=\"selectedCampaign\" ng-model=\"selectedCampaign\"> <option value=\"5\"> Current Campaign: 01/01/2017 - till date <option value=\"4\"> Last Campaign: 12/01/2016 - 12/31/2016 <option value=\"3\"> Older Campaign: 12/01/2016 - 12/31/2016 <option value=\"2\"> Older Campaign: 12/01/2016 - 12/31/2016 </select> </div> </div> <div class=\"row\"> <div class=\"col-lg-12\"> <analytics-layout campaign-id=\"rid && rid.id\" data-range=\"selectedCampaign\"></analytics-layout> </div> </div> <div class=\"row\"> <div class=\"col-lg-12\"> </div> </div> </div> </div>");
}]);

angular.module("views/analytics/archieves.html", []).run(["$templateCache", function ($templateCache) {
  $templateCache.put("views/analytics/archieves.html",
    "<!-- Main Wrapper --> <div id=\"wrapper\"> <div class=\"content\" animate-panel effect=\"zoomIn\"> <div class=\"row\"> <div class=\"col-lg-12 text-center m-t-md\"> <h2> Welcome to Mobilytics.ae archieves </h2> <p>Special <strong>Analytic Trace Application</strong> for your mobile marketing campaigns.</p> </div> </div> </div> </div>");
}]);

angular.module("views/analytics/campaigns.html", []).run(["$templateCache", function ($templateCache) {
  $templateCache.put("views/analytics/campaigns.html",
    "<!-- Main Wrapper --> <div id=\"wrapper\"> <div class=\"content\" animate-panel effect=\"zoomIn\" ng-show=\"!$rootScope.pageLoading\"> <div class=\"row\"> <div class=\"col-lg-12\"> <h2> Campaigns </h2> </div> </div> <div class=\"row\"> <div class=\"col-lg-8 col-md-10 col-sm-12\"> <ul class=\"list-inline text-right\"> <li><div class=\"btn btn-primary\" ng-click=\"addCampaign()\">Add Campaign</div> </li> </ul> </div> </div> <div class=\"row\"> <div class=\"col-lg-8 col-md-10 col-sm-12\"> <div id=\"campaignList\" ui-grid=\"campaignListOptions\" class=\"grid\"></div> </div> </div> </div> </div>");
}]);

angular.module("views/analytics/campaigns/add_campaign.html", []).run(["$templateCache", function ($templateCache) {
  $templateCache.put("views/analytics/campaigns/add_campaign.html",
    "<div id=\"add_user\">\n" +
    "\n" +
    "    <div class=\"content\" animate-panel effect=\"zoomIn\">\n" +
    "        <div class=\"modal-header\">\n" +
    "            <h3 class=\"modal-title\" id=\"modal-title\">Add a Campaign</h3>\n" +
    "        </div>\n" +
    "\n" +
    "        <ng-form class=\"form-horizontal\" name=\"$ctrl.newCampaignForm\" novalidate>\n" +
    "            <div class=\"modal-body\" id=\"modal-body\">\n" +
    "                <div class=\"form-group\">\n" +
    "                    <label class=\"col-sm-3 control-label\">Campaign Name</label>\n" +
    "\n" +
    "                    <div class=\"col-sm-9\">\n" +
    "                        <input type=\"text\" ng-required=\"true\" name=\"name\" placeholder=\"Campaign Name\"\n" +
    "                               class=\"form-control\" ng-model=\"$ctrl.newCampaign.CampaignName\"/>\n" +
    "                        <small class=\"form-text text-muted text-danger\"\n" +
    "                               ng-if=\"$ctrl.newCampaignForm.name.$invalid && $ctrl.newCampaignForm.username.$touched\">\n" +
    "                            <span ng-if=\"$ctrl.newCampaignForm.name.$error.required\">Name is required</span>\n" +
    "                        </small>\n" +
    "                    </div>\n" +
    "\n" +
    "                </div>\n" +
    "                <div class=\"form-group\">\n" +
    "                    <label class=\"col-sm-3 control-label\">Enable Password</label>\n" +
    "\n" +
    "                    <div class=\"col-sm-9\">\n" +
    "                        <input type=\"checkbox\" name=\"HasPassword\" class=\"form-control\"\n" +
    "                               ng-model=\"$ctrl.newCampaign.HasPassword\"/>\n" +
    "                    </div>\n" +
    "                </div>\n" +
    "                <div class=\"form-group\" ng-if=\"$ctrl.newCampaign.HasPassword\">\n" +
    "                    <label class=\"col-sm-3 control-label\">Password</label>\n" +
    "\n" +
    "                    <div class=\"col-sm-9\">\n" +
    "                        <input id=\"pw1\" type=\"password\" ng-required=\"!!$ctrl.newCampaign.HasPassword\" ng-minlength=\"8\"\n" +
    "                               name=\"password\" placeholder=\"Password\" class=\"form-control\"\n" +
    "                               ng-model=\"$ctrl.newCampaign.Password\"/>\n" +
    "                        <small class=\"form-text text-muted text-danger\"\n" +
    "                               ng-if=\"$ctrl.newCampaignForm.password.$invalid && $ctrl.newCampaignForm.password.$touched\">\n" +
    "                            <span ng-if=\"$ctrl.newCampaignForm.password.$error.required\">Password is required</span>\n" +
    "                            <span ng-if=\"!$ctrl.newCampaignForm.password.$error.required && $ctrl.newCampaignForm.password.$error.minlength\">Minimum 8 characters are required.</span>\n" +
    "                        </small>\n" +
    "                    </div>\n" +
    "                </div>\n" +
    "\n" +
    "\n" +
    "                <div class=\"form-group\">\n" +
    "                    <label class=\"col-sm-3 control-label\">Active</label>\n" +
    "\n" +
    "                    <div class=\"col-sm-9\">\n" +
    "                        <input type=\"checkbox\" name=\"isActive\" class=\"form-control\"\n" +
    "                               ng-model=\"$ctrl.newCampaign.IsActive\"/>\n" +
    "                    </div>\n" +
    "                </div>\n" +
    "\n" +
    "            </div>\n" +
    "            <div class=\"modal-footer\">\n" +
    "                <small class=\"text-danger\" ng-if=\"$ctrl.saveError\">Error: {{$ctrl.saveError}}</small>\n" +
    "                <button class=\"btn btn-default\" type=\"submit\" ng-click=\"cancel()\">Cancel</button>\n" +
    "                <button class=\"btn btn-primary\" type=\"submit\" ng-class=\"{'disabled': !$ctrl.newCampaignForm.$valid}\"\n" +
    "                        ng-disabled=\"!$ctrl.newCampaignForm.$valid\" ng-click=\"save($ctrl.newCampaign)\">Save changes\n" +
    "                </button>\n" +
    "            </div>\n" +
    "        </ng-form>\n" +
    "    </div>\n" +
    "</div>\n" +
    "");
}]);

angular.module("views/analytics/campaigns/campaign_list.html", []).run(["$templateCache", function ($templateCache) {
  $templateCache.put("views/analytics/campaigns/campaign_list.html",
    "");
}]);

angular.module("views/analytics/campaigns/edit_campaign.html", []).run(["$templateCache", function ($templateCache) {
  $templateCache.put("views/analytics/campaigns/edit_campaign.html",
    "<div id=\"add_user\">\n" +
    "\n" +
    "    <div class=\"content\" animate-panel effect=\"zoomIn\">\n" +
    "        <div class=\"modal-header\">\n" +
    "            <h3 class=\"modal-title\" id=\"modal-title\">Edit a Campaign</h3>\n" +
    "        </div>\n" +
    "\n" +
    "        <ng-form class=\"form-horizontal\" name=\"$ctrl.newCampaignForm\" novalidate >\n" +
    "            <div class=\"modal-body\" id=\"modal-body\">\n" +
    "                <div class=\"form-group\">\n" +
    "                    <label class=\"col-sm-3 control-label\">Campaign Name</label>\n" +
    "\n" +
    "                    <div class=\"col-sm-9\">\n" +
    "                        <input type=\"text\" ng-required=\"true\" name=\"name\" placeholder=\"Campaign Name\" class=\"form-control\" ng-model=\"$ctrl.newCampaign.CampaignName\" />\n" +
    "                        <small  class=\"form-text text-muted text-danger\" ng-if=\"$ctrl.newCampaignForm.name.$invalid && $ctrl.newCampaignForm.username.$touched\">\n" +
    "                            <span ng-if=\"$ctrl.newCampaignForm.name.$error.required\">Name is required</span>\n" +
    "                        </small>\n" +
    "                    </div>\n" +
    "\n" +
    "                </div>\n" +
    "                <div class=\"form-group\" >\n" +
    "                    <label class=\"col-sm-3 control-label\" ng-if=\"$ctrl.newCampaign.HasPassword\">Edit Password</label>\n" +
    "                    <label class=\"col-sm-3 control-label\" ng-if=\"!$ctrl.newCampaign.HasPassword\">Add Password</label>\n" +
    "\n" +
    "                    <div class=\"col-sm-9\">\n" +
    "                        <input type=\"checkbox\" name=\"EditPassword\"  class=\"form-control\" ng-model=\"$ctrl.newCampaign.EditPassword\" />\n" +
    "                    </div>\n" +
    "                </div>\n" +
    "\n" +
    "                <div class=\"form-group\" ng-if=\"$ctrl.newCampaign.HasPassword && $ctrl.newCampaign.EditPassword\">\n" +
    "                    <label class=\"col-sm-3 control-label\" ng-if=\"$ctrl.newCampaign.HasPassword\">Remove Password</label>\n" +
    "\n" +
    "                    <div class=\"col-sm-9\">\n" +
    "                        <input type=\"checkbox\" name=\"RemovePassword\"  class=\"form-control\" ng-model=\"$ctrl.newCampaign.RemovePassword\" />\n" +
    "                    </div>\n" +
    "                </div>\n" +
    "\n" +
    "                <div class=\"form-group\" ng-if=\"$ctrl.newCampaign.EditPassword\">\n" +
    "                    <label class=\"col-sm-3 control-label\">Password</label>\n" +
    "\n" +
    "                    <div class=\"col-sm-9\">\n" +
    "                        <input id=\"pw1\" type=\"password\" ng-required=\"!!$ctrl.newCampaign.EditPassword && !$ctrl.newCampaign.RemovePassword\" ng-minlength=\"$ctrl.newCampaign.RemovePassword ? 0 : 8\" name=\"password\" placeholder=\"Password\" class=\"form-control\" ng-model=\"$ctrl.newCampaign.Password\" ng-disabled=\"$ctrl.newCampaign.RemovePassword\" />\n" +
    "\n" +
    "                        <small  class=\"form-text text-muted text-danger\" ng-if=\"$ctrl.newCampaignForm.password.$invalid && $ctrl.newCampaignForm.password.$touched\">\n" +
    "                            <span ng-if=\"$ctrl.newCampaignForm.password.$error.required\">Password is required</span>\n" +
    "                            <span ng-if=\"!$ctrl.newCampaignForm.password.$error.required && $ctrl.newCampaignForm.password.$error.minlength\">Minimum 8 characters are required.</span>\n" +
    "                        </small>\n" +
    "                    </div>\n" +
    "                </div>\n" +
    "\n" +
    "\n" +
    "                <div class=\"form-group\">\n" +
    "                    <label class=\"col-sm-3 control-label\">Active</label>\n" +
    "\n" +
    "                    <div class=\"col-sm-9\">\n" +
    "                        <input type=\"checkbox\" name=\"isActive\"  class=\"form-control\" ng-model=\"$ctrl.newCampaign.IsActive\" />\n" +
    "                    </div>\n" +
    "                </div>\n" +
    "\n" +
    "            </div>\n" +
    "            <div class=\"modal-footer\">\n" +
    "                <small class=\"text-danger\" ng-if=\"$ctrl.saveError\">Error: {{$ctrl.saveError}} </small>\n" +
    "                <button class=\"btn btn-default\" type=\"submit\" ng-click=\"cancel()\">Cancel</button>\n" +
    "                <button class=\"btn btn-primary\" type=\"submit\" ng-class=\"{'disabled': !$ctrl.newCampaignForm.$valid}\" ng-disabled=\"!$ctrl.newCampaignForm.$valid\"  ng-click=\"save($ctrl.newCampaign)\">Save changes</button>\n" +
    "            </div>\n" +
    "        </ng-form>\n" +
    "    </div>\n" +
    "</div>\n" +
    "");
}]);

angular.module("views/analytics/header.html", []).run(["$templateCache", function ($templateCache) {
  $templateCache.put("views/analytics/header.html",
    "<div id=\"logo\" class=\"light-version\"> <a ng-href=\"#\"><span class=\"logo\">mobilytics.ae</span></a> </div> <nav role=\"navigation\"> <!-- <minimaliza-menu></minimaliza-menu> --> <div class=\"small-logo\"> <a ng-href=\"#\"><span class=\"logo\">mobilytics.ae</span></a> </div> <div class=\"mobile-menu\" ng-if=\"$root.userInfo.user_id\"> <button type=\"button\" class=\"navbar-toggle mobile-menu-toggle\" data-toggle=\"collapse\" data-target=\"#mobile-collapse\"> <i class=\"fa fa-chevron-down\"></i> </button> <div class=\"collapse mobile-navbar\" id=\"mobile-collapse\"> <ul class=\"nav navbar-nav\"> <li ng-class=\"{'active':active == 'home'}\"><a class=\"page-scroll\" href=\"#page-top\"><i class=\"pe-7s-home\"></i> Home</a></li> <li ng-class=\"{'active':active == 'analytics'}\"><a class=\"page-scroll\" page-scroll ui-sref=\"bitraz.main.analytics\"><i class=\"pe pe-7s-graph1 text-danger\"></i> Analytics</a></li> <li ng-class=\"{'active':active == 'campaigns'}\"><a class=\"page-scroll\" page-scroll ui-sref=\"bitraz.main.campaigns\"><i class=\"pe pe-7s-portfolio text-info\"></i> Campaigns</a></li> <li ng-class=\"{'active':active == 'security'}\"><a class=\"page-scroll\" page-scroll ui-sref=\"bitraz.main.settings\"><i class=\"pe-7s-config\"></i> Security </a></li> <li><a class=\"page-scroll\" page-scroll ng-click=\"logout()\"><i class=\"pe-7s-power\"></i> Logout</a></li> </ul> </div> </div> <div class=\"navbar-right\" ng-if=\"$root.userInfo.user_id\"> <ul class=\"nav navbar-nav no-borders\"> <li uib-dropdown> <a ui-sref=\"bitraz.main.index\" uib-dropdown-toggle> <i class=\"pe-7s-home\"></i> </a> </li> <li uib-dropdown> <a uib-dropdown-toggle> <i class=\"pe-7s-graph\"></i> </a> <div uib-dropdown-menu class=\"hdropdown bigmenu animated flipInX\"> <table> <tbody> <tr> <td> <a ui-sref=\"bitraz.main.analytics\"> <i class=\"pe pe-7s-graph1 text-danger\"></i> <h5>Analytics</h5> </a>  <td> <a ui-sref=\"bitraz.main.campaigns\"> <i class=\"pe pe-7s-portfolio text-info\"></i> <h5>Campaigns</h5> </a>    </table> </div> </li> <li> <a ui-sref=\"bitraz.main.settings\"> <i class=\"pe-7s-config\"></i> </a> </li> <li> <a ng-click=\"logout()\"> <i class=\"pe-7s-power\"></i> </a> </li> </ul> </div> </nav>");
}]);

angular.module("views/analytics/index.html", []).run(["$templateCache", function ($templateCache) {
  $templateCache.put("views/analytics/index.html",
    "<!-- Main Wrapper --> <div id=\"wrapper\"> <div class=\"content\" animate-panel effect=\"zoomIn\"> <div class=\"row\"> <div class=\"col-lg-12\"> <h2> Summary </h2> </div> </div> <dashboard-layout config=\"dashboardConfig\"></dashboard-layout> </div> </div>");
}]);

angular.module("views/analytics/settings.html", []).run(["$templateCache", function ($templateCache) {
  $templateCache.put("views/analytics/settings.html",
    "<!-- Main Wrapper --> <div id=\"wrapper\"> <div class=\"content\" animate-panel effect=\"zoomIn\"> <div class=\"row\"> <div class=\"col-lg-12 m-t-md\"> <h2> Account Settings </h2> </div> </div> <div class=\"row\"> <div class=\"col-lg-6 m-t-md\"> <h3> API Key </h3> <div class=\"row\" ng-show=\"!currentUser.apikey && !loadingkey\"> <div class=\"col-lg-4 m-t-md\"> <button class=\"btn btn-success\" ng-click=\"seeApiKey()\">Show API Key</button> </div> </div> <div class=\"row\" ng-show=\"loadingkey\"> <div class=\"col-sm-12\"> Loading.. <i class=\"fa fa-spinner fa-spin\"></i> </div> </div> <div class=\"row\" ng-show=\"currentUser.apikey && !loadingkey\"> <div class=\"col-sm-6\"> <h4 id=\"apikeymodal\"> {{currentUser.apikey}} </h4> </div> <div class=\"col-sm-6 text-left\"> <div class=\"btn btn-success btn-small right api-copy-button\" data-clipboard-action=\"copy\" data-clipboard-target=\"#apikeymodal\">Copy to Clipboard</div> </div> </div> <div class=\"row\" ng-if=\"keyError\"> <div class=\"col-sm-12\"> <div class=\"text-left error\"> {{keyError}} </div> </div> </div> </div> </div> <div class=\"row\"> <div class=\"col-lg-6 m-t-md\"> <h3> Change Password </h3> <div class=\"row\"> <div class=\"col-lg-4 m-t-md\"> <button class=\"btn btn-success\" ng-click=\"changeUserPassword()\">Click To Login Password</button> </div> </div> </div> </div> </div> </div>");
}]);

angular.module("views/analytics/users.html", []).run(["$templateCache", function ($templateCache) {
  $templateCache.put("views/analytics/users.html",
    "<!-- Main Wrapper --> <div id=\"wrapper\"> <div class=\"content\" animate-panel effect=\"zoomIn\"> <div class=\"row\"> <div class=\"col-lg-12 text-center m-t-md\"> <h2> Welcome to Mobilytics.ae users </h2> <p>Special <strong>Analytic Trace Application</strong> for your mobile marketing campaigns.</p> </div> </div> </div> </div>");
}]);

angular.module("views/analytics/users/change_password.html", []).run(["$templateCache", function ($templateCache) {
  $templateCache.put("views/analytics/users/change_password.html",
    "<div id=\"edit_user\">\n" +
    "\n" +
    "    <div class=\"content\" animate-panel effect=\"zoomIn\">\n" +
    "        <div class=\"modal-header\">\n" +
    "            <h3 class=\"modal-title\" id=\"modal-title\">Change Login Password</h3>\n" +
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

angular.module("views/common/analytics.html", []).run(["$templateCache", function ($templateCache) {
  $templateCache.put("views/common/analytics.html",
    "<!-- Main Wrapper --> <div id=\"wrapper\"> <div class=\"content\" animate-panel effect=\"zoomIn\" ng-if=\"isLoaded\"> <div class=\"row\"> <div class=\"col-lg-12 text-right\"> <span> Choose a Campaign</span> <select name=\"selectedCampaign\" ng-model=\"selectedCampaign\" ng-change=\"campaignChange(selectedCampaign)\"> <option value=\"{{campaign.ReferenceNumber}}\" ng-repeat=\"campaign in campaigns\" ng-selected=\"campaign.ReferenceNumber == selectedCampaign\"> {{campaign.CampaignName || \"Campaign (\" + campaign.ReferenceNumber + \")\"}} : {{campaign.CreatedDate | date: 'MM.dd.yyyy'}} </select> </div> </div> <div class=\"row\"> <div class=\"col-lg-12\"> <analytics-layout campaign-id=\"selectedCampaign\"></analytics-layout> </div> </div> <div class=\"row\"> <div class=\"col-lg-12\"> </div> </div> </div> </div>");
}]);

angular.module("views/common/dashboard/activities_tmpl.html", []).run(["$templateCache", function ($templateCache) {
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

angular.module("views/common/dashboard/dashboard_tmpl.html", []).run(["$templateCache", function ($templateCache) {
  $templateCache.put("views/common/dashboard/dashboard_tmpl.html",
    "<div class=\"dashboard-container col-sm-12\" ng-if=\"$ctrl.config && $ctrl.config.type == 'all'\">\n" +
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
    "<div class=\"dashboard-container col-sm-12\" ng-if=\"$ctrl.config && $ctrl.config.type == 'campaign'\">\n" +
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

angular.module("views/common/dashboard/logged_users_tmpl.html", []).run(["$templateCache", function ($templateCache) {
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

angular.module("views/common/dashboard/recent_campaigns_tmpl.html", []).run(["$templateCache", function ($templateCache) {
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

angular.module("views/common/dashboard/total_campaigns_tmpl.html", []).run(["$templateCache", function ($templateCache) {
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

angular.module("views/common/dashboard/total_users_tmpl.html", []).run(["$templateCache", function ($templateCache) {
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
    "            <div class=\"progress m-t-xs full progress-small\">\n" +
    "\n" +
    "                <div style=\"width: {{($ctrl.data.uniqueUsers || 0)/($ctrl.data.total || 1) * 100}}%\" aria-valuemax=\"100\" aria-valuemin=\"0\" aria-valuenow=\"{{($ctrl.data.uniqueUsers || 0)/($ctrl.data.total || 1) * 100}}\"\n" +
    "                     role=\"progressbar\" class=\" progress-bar progress-bar-success\" tooltip-popup-delay='500' tooltip-placement=\"bottom\" uib-tooltip=\"{{($ctrl.data.uniqueUsers + ' of ' + $ctrl.data.total + ' - ')}}{{((($ctrl.data.uniqueUsers || 0)/($ctrl.data.total || 1)) * 100) | number}}%\">\n" +
    "                    <span class=\"sr-only\">{{($ctrl.data.uniqueUsers || 0)/($ctrl.data.total || 1) * 100}}% Unique Users</span>\n" +
    "                </div>\n" +
    "            </div>\n" +
    "\n" +
    "            <div class=\"row\">\n" +
    "                <div class=\"col-xs-4\">\n" +
    "                    <small class=\"stats-label\">Today </small>\n" +
    "                    <h6><span tooltip-popup-delay='500' tooltip-placement=\"bottom\" uib-tooltip=\"{{($ctrl.data.uniqueUsersToday || 0)}} Unique Users of {{$ctrl.data.usersToday || 0}} total\">{{$ctrl.data.uniqueUsersToday || 0}}/<span class=\"text-success\">{{$ctrl.data.usersToday || 0}}</span> </span></h6>\n" +
    "                </div>\n" +
    "\n" +
    "                <div class=\"col-xs-4\">\n" +
    "                    <small class=\"stats-label\">Yesterday</small>\n" +
    "                    <h6><span tooltip-popup-delay='500' tooltip-placement=\"bottom\" uib-tooltip=\"{{($ctrl.data.usersYesterday || 0)}} Unique Users of {{$ctrl.data.usersYesterday || 0}} total\">{{$ctrl.data.usersYesterday || 0}}/<span class=\"text-success\">{{$ctrl.data.usersYesterday || 0}}</span></span></h6>\n" +
    "                </div>\n" +
    "\n" +
    "                <div class=\"col-xs-4\">\n" +
    "                    <small class=\"stats-label\">Last 7 Days</small>\n" +
    "                    <h6><span tooltip-popup-delay='500' tooltip-placement=\"bottom\" uib-tooltip=\"{{($ctrl.data.uniqueUsersLast7days || 0)}} Unique Users of {{$ctrl.data.usersLast7days || 0}} total\">{{$ctrl.data.uniqueUsersLast7days || 0}}/<span class=\"text-success\">{{$ctrl.data.usersLast7days || 0}}</span></span></h6>\n" +
    "                </div>\n" +
    "            </div>\n" +
    "        </div>\n" +
    "    </div>\n" +
    "</div>");
}]);

angular.module("views/common/dashboard/total_visits_tmpl.html", []).run(["$templateCache", function ($templateCache) {
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
    "            <div class=\"progress m-t-xs full progress-small\" >\n" +
    "                <div style=\"width: {{(($ctrl.data.uniqueVisits || 0) / ($ctrl.data.total || 1) * 100)}}%\" aria-valuemax=\"100\" aria-valuemin=\"0\" aria-valuenow=\"{{(($ctrl.data.uniqueVisits || 0) / ($ctrl.data.total || 1) * 100)}}\"\n" +
    "                     role=\"progressbar\" class=\" progress-bar progress-bar-success\" tooltip-popup-delay='500' tooltip-placement=\"bottom\" uib-tooltip=\"{{($ctrl.data.uniqueVisits + ' of ' + $ctrl.data.total + ' - ')}}{{(($ctrl.data.uniqueVisits || 0) / ($ctrl.data.total || 1) * 100) | number}}%\">\n" +
    "                    <span class=\"sr-only\">{{(($ctrl.data.uniqueVisits || 0) / ($ctrl.data.total || 1) * 100)}}% Unique Visits</span>\n" +
    "                </div>\n" +
    "            </div>\n" +
    "\n" +
    "            <div class=\"row\">\n" +
    "                <div class=\"col-xs-4\">\n" +
    "                    <small class=\"stats-label\">Today </small>\n" +
    "                    <h6><span tooltip-popup-delay='500' tooltip-placement=\"bottom\" uib-tooltip=\"{{($ctrl.data.uniqueVisitsToday || 0)}} Unique visits of {{$ctrl.data.visitsToday || 0}} total\">{{$ctrl.data.uniqueVisitsToday || 0}}/<span class=\"text-success\">{{$ctrl.data.visitsToday || 0}}</span></span></h6>\n" +
    "                </div>\n" +
    "\n" +
    "                <div class=\"col-xs-4\">\n" +
    "                    <small class=\"stats-label\">Yesterday</small>\n" +
    "                    <h6><span tooltip-popup-delay='500' tooltip-placement=\"bottom\" uib-tooltip=\"{{($ctrl.data.uniqueVisitsYesterday || 0)}} Unique visits of {{$ctrl.data.visitsToday || 0}} total\">{{$ctrl.data.visitsYesterday || 0}}/<span class=\"text-success\">{{$ctrl.data.visitsYesterday || 0}}</span></span></h6>\n" +
    "                </div>\n" +
    "\n" +
    "                <div class=\"col-xs-4\">\n" +
    "                    <small class=\"stats-label\">Last 7 Days</small>\n" +
    "                    <h6><span tooltip-popup-delay='500' tooltip-placement=\"bottom\" uib-tooltip=\"{{($ctrl.data.uniqueVisitsLast7days || 0)}} Unique visits of {{$ctrl.data.visitsLast7days || 0}} total\">{{$ctrl.data.uniqueVisitsLast7days || 0}}/<span class=\"text-success\">{{$ctrl.data.visitsLast7days || 0}}</span></span></h6>\n" +
    "                </div>\n" +
    "            </div>\n" +
    "        </div>\n" +
    "    </div>\n" +
    "</div>");
}]);

angular.module("views/common/dashboard/urls_generated_tmpl.html", []).run(["$templateCache", function ($templateCache) {
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

angular.module("views/common/directives/analytics_layout.html", []).run(["$templateCache", function ($templateCache) {
  $templateCache.put("views/common/directives/analytics_layout.html",
    "<section class=\"anlaytics-layout-container \" style=\"padding-top:0px;\">\n" +
    "    <div ng-show=\"!$ctrl.loading\">\n" +
    "        <div class=\"row\" style=\"padding-bottom: 5px;\">\n" +
    "            <div class=\"col-lg-12 refresh-block\">\n" +
    "            <span class=\"pull-right\">\n" +
    "                <!--View Refreshes in {{$ctrl.timeLeft}} Seconds <a ng-click=\"$ctrl.resetTime()\"><i class=\"fa fa-refresh\"></i></a>-->\n" +
    "                Refresh View <a ng-click=\"$ctrl.resetTime()\"><i class=\"fa fa-refresh\"></i></a>\n" +
    "            </span>\n" +
    "\n" +
    "            </div>\n" +
    "        </div>\n" +
    "        <div class=\"row\">\n" +
    "            <dashboard-layout config=\"$ctrl.dashboardConfig\"></dashboard-layout>\n" +
    "        </div>\n" +
    "        <div class=\"row\">\n" +
    "            <div class=\"col-md-12 col-sm-12 col-xs-12\">\n" +
    "                <div class=\"panel panel-default\">\n" +
    "                    <div class=\"panel-body\">\n" +
    "                        <div class=\"col-md-12 col-sm-12 col-xs-12\">\n" +
    "                            <div class=\"dashboard_graph\">\n" +
    "\n" +
    "                                <div class=\"row x_title\">\n" +
    "                                    <div class=\"col-md-8\">\n" +
    "                                        <h3>User Activities<small style=\"padding-left: 10px\">timeline presentation</small></h3>\n" +
    "                                    </div>\n" +
    "                                    <div class=\"col-md-4\">\n" +
    "                                        <div id=\"reportrange\" class=\"pull-right\" style=\"background: #fff; cursor: pointer; padding: 5px 10px; border: 0px solid #ccc; width: 100%;\">\n" +
    "                                            <i class=\"glyphicon glyphicon-calendar fa fa-calendar\"></i>\n" +
    "                                        <span style=\"display: inline-block;width: calc(100% - 40px);\"><input date-range-picker id=\"daterange3\" name=\"daterange3\" class=\"form-control date-picker\" type=\"text\"\n" +
    "                                                                                                             ng-model=\"date\" options=\"opts\" required/></span> <b class=\"caret\"></b>\n" +
    "                                        </div>\n" +
    "                                    </div>\n" +
    "                                </div>\n" +
    "\n" +
    "                                <div class=\"col-md-12 col-sm-12 col-xs-12\">\n" +
    "                                    <div id=\"placeholder33\" style=\"height: 260px; display: none\" class=\"demo-placeholder\"></div>\n" +
    "                                    <div style=\"width: 100%;\">\n" +
    "                                        <highchart id=\"canvas_dahs\" config=\"chartConfig\" class=\"demo-placeholder\" style=\"width: 100%; height:270px;\"></highchart>\n" +
    "                                    </div>\n" +
    "                                </div>\n" +
    "                                <div class=\"clearfix\"></div>\n" +
    "                            </div>\n" +
    "                        </div>\n" +
    "                    </div>\n" +
    "                </div>\n" +
    "            </div>\n" +
    "        </div>\n" +
    "\n" +
    "        <div class=\"row\">\n" +
    "            <div class=\"col-md-12 col-sm-12 col-xs-12\">\n" +
    "                <div class=\"panel panel-default\">\n" +
    "                    <div class=\"panel-body\">\n" +
    "                        <div class=\"col-md-12 col-sm-12 col-xs-12\">\n" +
    "                            <div class=\"dashboard_graph\">\n" +
    "\n" +
    "                                <div class=\"row x_title\">\n" +
    "                                    <div class=\"col-md-6\">\n" +
    "                                        <h3>Visitors location <small>geo-presentation</small></h3>\n" +
    "                                    </div>\n" +
    "                                </div>\n" +
    "\n" +
    "                                <div class=\"col-md-12 col-sm-12 col-xs-12\">\n" +
    "                                    <div style=\"width: 100%;\">\n" +
    "                                        <highchart id=\"world-map-gdp\" config=\"locationConfig\" class=\"columnscol-md-12 col-sm-12 col-xs-12\" style=\"height: 400px\">\n" +
    "\n" +
    "                                        </highchart>\n" +
    "                                    </div>\n" +
    "                                </div>\n" +
    "\n" +
    "                                <div class=\"clearfix\"></div>\n" +
    "                            </div>\n" +
    "                        </div>\n" +
    "\n" +
    "                    </div>\n" +
    "                </div>\n" +
    "            </div>\n" +
    "        </div>\n" +
    "        <div class=\"row\">\n" +
    "            <div class=\"col-md-12 col-sm-12 col-xs-12\">\n" +
    "                <div class=\"panel panel-default\">\n" +
    "                    <div map-lazy-load=\"https://maps.google.com/maps/api/js\" map-lazy-load-params=\"{{$ctrl.googleMapsUrl}}\">\n" +
    "                    <ng-map center=\"24.1009901,54.1816353\" zoom=\"3\" min-zoom=\"2\" max-zoom=\"12\" style=\"height: 450px;\" zoom-to-include-markers=\"true\" pan-control=\"true\"\n" +
    "                                map-type-control=\"true\"\n" +
    "                                map-type-control-options=\"{style:'DROPDOWN_MENU'}\"\n" +
    "                                zoom-control=\"true\"\n" +
    "                                zoom-control-options=\"{style:'SMALL'}\" street-view-control=\"false\"></ng-map>\n" +
    "                    </div>\n" +
    "                </div>\n" +
    "            </div>\n" +
    "        </div>\n" +
    "\n" +
    "        <div class=\"row\">\n" +
    "            <div class=\"col-md-12 col-sm-12 col-xs-12\">\n" +
    "                <div class=\"panel panel-default\">\n" +
    "                    <div class=\"panel-body\">\n" +
    "                        <div class=\"col-lg-6 col-md-12 col-sm-12 col-xs-12\">\n" +
    "                            <div class=\"dashboard_graph \">\n" +
    "\n" +
    "                                <div class=\"row x_title\">\n" +
    "                                    <div class=\"col-md-12 text-center\">\n" +
    "                                        <h3>Devices</h3>\n" +
    "                                    </div>\n" +
    "                                </div>\n" +
    "                                <div class=\"row\">\n" +
    "                                    <div class=\"col-md-12 col-sm-12 col-xs-12\">\n" +
    "                                        <!--<div id=\"placeholder33\" style=\"height: 360px; display: none\" class=\"demo-placeholder\"></div>-->\n" +
    "                                        <div style=\"width: 100%;\">\n" +
    "                                            <highchart id=\"devices-chart\" config=\"deviceConfig\"  style=\"height:300px;\"></highchart>\n" +
    "                                        </div>\n" +
    "                                    </div>\n" +
    "                                </div>\n" +
    "\n" +
    "                                <div class=\"clearfix\"></div>\n" +
    "                            </div>\n" +
    "                        </div>\n" +
    "                        <div class=\"col-lg-6 col-md-12 col-sm-12 col-xs-12\">\n" +
    "                            <div class=\"dashboard_graph \">\n" +
    "\n" +
    "                                <div class=\"row x_title\">\n" +
    "                                    <div class=\"col-md-12 text-center\">\n" +
    "                                        <h3>Platforms</h3>\n" +
    "                                    </div>\n" +
    "                                </div>\n" +
    "                                <div class=\"row\">\n" +
    "                                    <div class=\"col-md-12 col-sm-12 col-xs-12\">\n" +
    "                                        <!--<div id=\"placeholder33\" style=\"height: 360px; display: none\" class=\"demo-placeholder\"></div>-->\n" +
    "                                        <div style=\"width: 100%;\">\n" +
    "                                            <highchart id=\"platform-chart\" config=\"platformConfig\" style=\"height:300px;\"></highchart>\n" +
    "                                        </div>\n" +
    "                                    </div>\n" +
    "                                </div>\n" +
    "                                <div class=\"clearfix\"></div>\n" +
    "                            </div>\n" +
    "                        </div>\n" +
    "                    </div>\n" +
    "                </div>\n" +
    "            </div>\n" +
    "        </div>\n" +
    "    </div>\n" +
    "    <!--<div class=\"row\" ng-hide=\"$ctrl.loading\">-->\n" +
    "        <!--<div class=\"splash-title\">-->\n" +
    "            <!--<h1>Loading..</h1>-->\n" +
    "            <!--<p></p>-->\n" +
    "            <!--<img src=\"images/loading-bars.svg\" width=\"64\" height=\"64\"/></div>-->\n" +
    "    <!--</div>-->\n" +
    "\n" +
    "</section>");
}]);

angular.module("views/common/header-dashboard.html", []).run(["$templateCache", function ($templateCache) {
  $templateCache.put("views/common/header-dashboard.html",
    "<div id=\"logo\" class=\"light-version\"> <span> bi <span class=\"part2\">TRAZ</span> </span> </div> <nav role=\"navigation\"> <!-- <minimaliza-menu></minimaliza-menu> --> <div class=\"small-logo\"> <span class=\"text-primary\">bi <span class=\"part2\">TRAZ</span></span> </div> <div class=\"mobile-menu\"> <button type=\"button\" class=\"navbar-toggle mobile-menu-toggle\" data-toggle=\"collapse\" data-target=\"#mobile-collapse\"> <i class=\"fa fa-chevron-down\"></i> </button> <div class=\"collapse mobile-navbar\" id=\"mobile-collapse\"> <ul class=\"nav navbar-nav\"> <li> <a href=\"#\">Login</a> </li> </ul> </div> </div> <div class=\"navbar-right\"> <ul class=\"nav navbar-nav no-borders\"> <li> <a> <i class=\"pe-7s-upload pe-rotate-90\"></i> </a> </li> </ul> </div> </nav>");
}]);

angular.module("views/common/login.html", []).run(["$templateCache", function ($templateCache) {
  $templateCache.put("views/common/login.html",
    "<div class=\"login-container\"> <div class=\"row\" ng-if=\"!($root.userInfo && $root.userInfo.user_id)\"> <div class=\"col-md-12\"> <div class=\"text-center m-b-md\" style=\"border: 1px solid transparent\"> <h3>LOGIN</h3> <!-- <small> This is the best app ever!</small> --> </div> <div class=\"hpanel\"> <div class=\"panel-body\"> <form name=\"loginForm\" id=\"loginForm\" novalidate ng-submit=\"login(loginForm)\"> <div class=\"form-group\"> <label class=\"control-label\" for=\"username\">Username</label> <input type=\"text\" placeholder=\"name@your_domain.com\" title=\"Please enter you username\" ng-model=\"uname\" ng-required=\"true\" value=\"\" name=\"username\" id=\"username\" class=\"form-control\"> </div> <span ng-if=\"loginForm.username.$touched && loginForm.username.$error.required\" class=\"text-danger\">Name is required</span> <div class=\"form-group\"> <label class=\"control-label\" for=\"password\">Password</label> <input type=\"password\" title=\"Please enter your password\" ng-required=\"true\" ng-model=\"pswd\" name=\"password\" id=\"password\" class=\"form-control\"> </div> <span ng-if=\"loginForm.password.$touched && loginForm.password.$error.required\" class=\"text-danger\">Password is required</span> <button class=\"btn btn-success btn-block\" type=\"submit\"><span ng-show=\"!loading\">Login</span><span ng-show=\"loading\"><i class=\"fa fa-spinner fa-spin\"></i> </span></button> <span class=\"text-danger\" ng-if=\"loginError\" class=\"text-danger\">Error: {{loginError}} </span> </form> </div> </div> </div> </div> <div class=\"row\" ng-if=\"$root.userInfo && $root.userInfo.user_id\"> <div class=\"col-md-12\" style=\"padding-top: 40px\"> <div class=\"hpanel\"> <div class=\"panel-body\"> <div> <button class=\"btn btn-success btn-block\" ng-click=\"redirectUser()\" ng-if=\"$root.userInfo.isAdmin\">Go to Admin</button> </div> <div> <button class=\"btn btn-success btn-block\" ng-click=\"redirectUser()\" ng-if=\"!$root.userInfo.isAdmin\">Go to Analytics</button> </div> </div> </div> </div> </div> </div>");
}]);

angular.module("views/common/navigation.html", []).run(["$templateCache", function ($templateCache) {
  $templateCache.put("views/common/navigation.html",
    "<div id=\"navigation\"> <div class=\"profile-picture\"> <div class=\"stats-label text-color\"> <span class=\"font-extra-bold font-uppercase\">Username</span> <div class=\"dropdown\" uib-dropdown> <a uib-dropdown-toggle href=\"#\"> <small class=\"text-muted\">Founder of App <b class=\"caret\"></b></small> </a> <ul uib-dropdown-menu class=\"animated flipInX m-t-xs\"> <li><a>Item</a></li> </ul> </div> </div> </div> <ul side-navigation class=\"nav metismenu\" id=\"side-menu\"> <li ui-sref-active=\"active\"> <a ui-sref=\"dashboard\"> <span class=\"nav-label\">Dashboard</span></a> </li> </ul> </div>");
}]);

angular.module("views/common/panel_tools.html", []).run(["$templateCache", function ($templateCache) {
  $templateCache.put("views/common/panel_tools.html",
    "<!-- This is template for panel tools --><!-- It contains collapse function (showhide) and close function (closebox) --><!-- All function is handled from directive panelTools in directives.js file --> <div class=\"panel-tools\"> <a ng-click=\"showhide()\"><i class=\"fa fa-chevron-up\"></i></a> <a ng-click=\"closebox()\"><i class=\"fa fa-times\"></i></a> </div>");
}]);
