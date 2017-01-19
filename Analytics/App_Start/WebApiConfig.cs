using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Routing;
namespace Analytics.App_Start
{
    public class WebApiConfig
    {
        //public static void Register(HttpConfiguration config)
        //{
        //    // New code
        //    config.EnableCors();

        //    config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

        //    config.Routes.MapHttpRoute(
        //        name: "DefaultApi",
        //        routeTemplate: "api/{controller}/{id}",
        //        defaults: new { controller = "Test", action = "Get",id = RouteParameter.Optional }
        //    );

        //}

        public static void Register(HttpConfiguration config)
        {
            //config.SetCorsPolicyProviderFactory(new CorsPolicyFactory());
            config.EnableCors();
            //config.EnableCors(new EnableCorsAttribute("http://localhost:3000", "*", "*"));
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            config.MapHttpAttributeRoutes();
            EnableCrossSiteRequests(config);
            AddRoutes(config);
            //config.MapHttpAttributeRoutes();
        }

        private static void AddRoutes(HttpConfiguration config)
        {
//            config.Routes.MapHttpRoute(
//            name: "AdminUSers",
//             //routeTemplate: "api/game/authentificate;{username};{password}",
//            routeTemplate: "api/Test/Users/{objclient}/{id}",
//            defaults: new
//            {
//        controller = "Test",
//        action = "Users",
//        id=RouteParameter.Optional,
//        objclient=RouteParameter.Optional
//        //username = RouteParameter.Optional,
//        //password = RouteParameter.Optional
//    },
//    constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
//);

            config.Routes.MapHttpRoute(
                name: "Defaults",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            
        }

        private static void EnableCrossSiteRequests(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute(
                origins: "*",
                headers: "*",
                methods: "*");
            config.EnableCors(cors);
        }
    }
}