using System.Web.Http;
using WebActivatorEx;
using SIGDA_BackEnd.CA.Biometricos;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace SIGDA_BackEnd.CA.Biometricos
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            //GlobalConfiguration.Configuration.EnableSwagger(c => c.SingleApiVersion("v1", "API Biometricos")).EnableSwaggerUi();
            //swagger
        }
    }
}
