using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SIGDA_BackEnd.Services
{
    public class TokenDecoderService
    {
        public static bool SaveDataToken(string Bearer)
        {
            JwtSecurityToken token = null;

            if (Bearer.Contains("Bearer"))
            {
                Bearer = Bearer.Replace("Bearer", "").Trim();
            }

            var handler = new JwtSecurityTokenHandler();

            token = handler.ReadJwtToken(Bearer);
            ///verificar la fecha, que siga siendo válido
            if (token == null)
            {
                return false;
            }

            var fecha = token.ValidTo;
            if (DateTime.UtcNow <= fecha)//sigue siendo válido
            {
                var ClaimUSID = token.Claims.First(claim => claim.Type == "UserId").Value;
                var claimUSN = token.Claims.First(claim => claim.Type == "unique_name").Value;
                var IdSubCT = token.Claims.First(claim => claim.Type == "IdSubCT").Value;
                var IdZona = token.Claims.First(claim => claim.Type == "IdZona").Value;
                ClaimsIdentity claimsIdentity = new ClaimsIdentity
                    (new[] { new Claim(ClaimTypes.Name, claimUSN),
                             new Claim("UserId", ClaimUSID),
                             new Claim("IdSubCT", IdSubCT),
                             new Claim("IdZona", IdZona)});
            }
            else
            {
                return false;
            }          
            return true;
        }
    }
}
