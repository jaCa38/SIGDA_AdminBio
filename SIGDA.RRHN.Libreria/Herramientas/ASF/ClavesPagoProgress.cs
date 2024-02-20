using Newtonsoft.Json;
using SIGDA.APIProgress.Models.ASF;
using SIGDA.APIProgress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Herramientas.ASF
{
    public class ClavesPagoProgress
    {
        public async Task<List<ClavesPagoProgress>> ObtenerListaClaves()
        {
            LoginRequest loginRequest = new LoginRequest();
            loginRequest.Username = "adminSRHN";
            loginRequest.Passwd = "C3cilio1804.";
            APIConnection apiConection = new APIConnection();
            SecToken token = apiConection.ObtenerSecureTokenLocal(loginRequest);

            HttpClient client = new HttpClient();
            var targeturi = APIConnection.APISecure + "/api/asf/participaciones/anexonomina/nomord/claves";
            client.DefaultRequestHeaders.Add("SK", token.Key);
            client.DefaultRequestHeaders.Add("SP", token.Secure);
            client.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", token.Token);
            var responseTask = client.PostAsync(targeturi, null);
            responseTask.Wait();
            var result2 = responseTask.Result;

            if (result2.IsSuccessStatusCode)
            {
                string responseContent = await result2.Content.ReadAsStringAsync();
                //se supone que aqui llega (linea de abajo) llega el arreglo con las respues de sí o no
                var productResult = JsonConvert.DeserializeObject<List<ClavesPagoProgress>>(responseContent);
                //aqui guardar en BD local (los registros originales y el resultado?)

                return productResult;
            }
            else
                return null;
        }
    }
}
