using System.Collections.Generic;
using System.Web.Http;

namespace SIGDA_BackEnd.Reporteador.Controllers
{
    public class ValuesController : BaseController
    {
        // GET api/values/GetUsuario
        [Authorize]
        [HttpGet]
        public IEnumerable<string> GetUsuario()
        {
            var Iduser = GetIdUsuario();
            return new string[] { "value1", "value2" };
        }

    }
}
