using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SIGDA_BackEnd.Controllers
{
    public class BaseControllerSIGDA : ControllerBase
    {
        protected string GetIdCT()
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    IEnumerable<Claim> claims = identity.Claims;
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
        protected string GetIdZona()
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    IEnumerable<Claim> claims = identity.Claims;
                    return claims.First(i => i.Type == "IdZona").Value;
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
                var identity = HttpContext.User.Identity as ClaimsIdentity;
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
