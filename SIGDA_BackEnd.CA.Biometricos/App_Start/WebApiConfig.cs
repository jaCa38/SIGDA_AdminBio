using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SIGDA_BackEnd.CA.Biometricos
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de Web API
            //var cors = new EnableCorsAttribute("*", "*", "*");
            //config.EnableCors(cors);


            // Rutas de Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.EnableSwagger(c => c.SingleApiVersion("v1", "Administracion Terminales Biometricas"))
            .EnableSwaggerUi();


        }
    }
}
