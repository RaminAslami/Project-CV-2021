using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Project_2022_CV
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }


            );
            config.Routes.MapHttpRoute(
    name: "ControllerOnly",
    routeTemplate: "api/{controller}"
);
            // Controllers with Actions
            // To handle routes like `/api/VTRouting/route`
            config.Routes.MapHttpRoute(
                name: "ControllerAndAction",
                routeTemplate: "api/{controller}/{action}"
            );

        }
    }
}
