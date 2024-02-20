using Newtonsoft.Json;
using SIGDA.APIProgress.Models;
using SIGDA.APIProgress.Models.CA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Herramientas.CA
{
    public class ControlAsistenciaProgress
    {
        public async Task<bool> AlmacenarInfoFaltasOmisionES(RegistroCAProgress[] lstRegistros)
        {
            LoginRequest loginRequest = new LoginRequest();
            loginRequest.Username = "adminSRHN";
            loginRequest.Passwd = "C3cilio1804.";
            APIConnection apiConection = new APIConnection();
            SecToken token = apiConection.ObtenerSecureTokenLocal(loginRequest);

            HttpClient client = new HttpClient();
            var targeturi = APIConnection.APISecure + "api/falta/omisionES";
            client.DefaultRequestHeaders.Add("SK", token.Key);
            client.DefaultRequestHeaders.Add("SP", token.Secure);
            client.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", token.Token);

            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JWT);
            var responseTask = client.PostAsJsonAsync(targeturi, lstRegistros);
            //var responseTask = client.GetAsync(targeturi + $"?cve={cve}&nombre={nombre}&paterno={paterno}&materno={materno}");
            responseTask.Wait();
            var result2 = responseTask.Result;

            if (result2.IsSuccessStatusCode)
            {
                string responseContent = await result2.Content.ReadAsStringAsync();
                //se supone que aqui llega (linea de abajo) llega el arreglo con las respues de sí o no
                var productResult = JsonConvert.DeserializeObject<List<RegistroCAProgress>>(responseContent);
                //aqui guardar en BD local (los registros originales y el resultado?)

                return true;
            }
            else
                return false;

        }
    }
}
