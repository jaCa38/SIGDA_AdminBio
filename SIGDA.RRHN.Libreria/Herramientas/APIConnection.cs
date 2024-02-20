using Newtonsoft.Json;
using SIGDA.APIProgress.Models;

using System.Net.Http.Json;
using System.Text;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Azure;
using Newtonsoft.Json.Linq;

namespace SIGDA.SRHN.Libreria.Herramientas
{
    public class APIConnection
    {
        public HttpClient client = new HttpClient();
        //public static readonly string APISecure = "http://localhost:52634/";
        public static readonly string APISecure = "http://192.168.1.61:1596/";
        
        public async Task<SecToken> ObtenerSecureToken(LoginRequest loginRequest)
        {
            SecToken token = new SecToken();
            var targeturi = APISecure + "api/login/authenticate";

            //person.Username = Security.Decrypt(Security.Decrypt(Security.Decrypt(secureUser)));
            //person.Passwd = Security.Decrypt(Security.Decrypt(Security.Decrypt(securePass)));

            var json = JsonConvert.SerializeObject(loginRequest);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PostAsync(targeturi, data);
            var result = response.Result;

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var readTask = result.Content.ReadFromJsonAsync<SecToken>();
                token = readTask.Result;
                return token;
            }
            else
                return null;
        }
        public SecToken ObtenerSecureTokenLocal(LoginRequest loginRequest)
        {
            SecToken token = new SecToken();
            var targeturi = APISecure + "api/login/authenticate";

            //person.Username = Security.Decrypt(Security.Decrypt(Security.Decrypt(secureUser)));
            //person.Passwd = Security.Decrypt(Security.Decrypt(Security.Decrypt(securePass)));

            var json = JsonConvert.SerializeObject(loginRequest);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PostAsync(targeturi, data);
            var result = response.Result;

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var readTask = result.Content.ReadFromJsonAsync<SecToken>();
                token = readTask.Result;
                return token;
            }
            else
                return null;
        }

        public async Task<EmpleadosProgress> BuscarEmpleadosProgress(SecToken token, string cve, string nombre, string paterno, string materno)
        {
            var targeturi = APISecure + "api/Empleado";
            client.DefaultRequestHeaders.Add("SK", token.Key);
            client.DefaultRequestHeaders.Add("SP", token.Secure);
            client.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", token.Token);

            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JWT);
            var responseTask = client.GetAsync(targeturi+ $"?cve={cve}&nombre={nombre}&paterno={paterno}&materno={materno}");
            responseTask.Wait();
            var result2 = responseTask.Result;

            if (result2.IsSuccessStatusCode)
            {
                string responseContent = await result2.Content.ReadAsStringAsync();
                var productResult = JsonConvert.DeserializeObject<EmpleadosProgress>(responseContent);
               
                return productResult;
            }
            else
                return null;
        }
        
    }
}
