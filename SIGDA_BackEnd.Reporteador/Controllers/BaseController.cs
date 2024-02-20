using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace SIGDA_BackEnd.Reporteador.Controllers
{
    public class BaseController : ApiController
    {
        protected string GetIdCT()
        {
            try
            {

                var identity = HttpContext.Current.User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    IEnumerable<System.Security.Claims.Claim> claims = identity.Claims;
                    return claims.First(i => i.Type == "IdSubCT").Value;
                }
            }
            catch (Exception ex)
            {
                //StreamWriter sw = new StreamWriter("C:\\Logs\\Paso2error.txt", true, Encoding.ASCII);
                //sw.Write(ex.Message);
                //sw.Close();
                throw new Exception(ex.Message);
            }

            throw new NotImplementedException();
        }
        protected string GetIdUsuario()
        {
            try
            {
                var identity = HttpContext.Current.User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    IEnumerable<Claim> claims = identity.Claims;
                    return claims.First(i => i.Type == "UserId").Value;
                }
            }
            catch (Exception ex)
            {
                //StreamWriter sw = new StreamWriter("C:\\Logs\\Paso2error.txt", true, Encoding.ASCII);
                //sw.Write(ex.Message);
                //sw.Close();
                throw new Exception(ex.Message);
            }

            throw new NotImplementedException();
        }
        
    }
}