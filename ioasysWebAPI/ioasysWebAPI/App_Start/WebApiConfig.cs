using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ioasysWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    //name: "DefaultApi",
            //    name: "DefaultApiV1",
            //    routeTemplate: "api/v{version}/testusers/{id}",
            //    defaults: new { id = RouteParameter.Optional, controller = "TestUsersV1" }
            //);
        }
    }
}
