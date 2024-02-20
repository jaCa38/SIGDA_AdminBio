using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using SIGDA_BackEnd.Docker.Linux.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SIGDA_BackEnd.Docker.Linux.Controllers.AUTH
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
    public AuthController()
    {  }

    [AllowAnonymous]
    [HttpPost("Login")]
    public ActionResult<bool> Login()
    {
            bool autentica = false;

            if (Request.Headers.Keys.Contains("Authorization"))
            {
                StringValues values;

                if (Request.Headers.TryGetValue("Authorization", out values))
                {
                    var jwt = values.ToString();
                    autentica = TokenDecoderService.SaveDataToken(jwt);  
                }
            }
            if (autentica)
                return Ok(autentica);
            else
                return Unauthorized();
    }




        
    }
}