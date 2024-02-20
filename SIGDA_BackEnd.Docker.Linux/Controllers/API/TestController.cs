using Microsoft.AspNetCore.Mvc;
using SIGDA.SRHN.Libreria.Deudo.Factorizadores;

namespace SIGDA_BackEnd.Docker.Linux.Controllers.API
{
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("api/test/Get")]
        public string Get()
        {
            //return Environment.GetEnvironmentVariable("SIGDA_RH_QA_CNN"); 
            return "hi";
            //return SIGDA.Conexion.CadenasConexion.BDRHN_LOCAL;
        }
    }
}
