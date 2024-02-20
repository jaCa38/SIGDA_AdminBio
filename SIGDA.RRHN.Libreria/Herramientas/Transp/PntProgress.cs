using Newtonsoft.Json;
using SIGDA.APIProgress.Models.Trans.ASEG;
using SIGDA.APIProgress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SIGDA.APIProgress.Models.Trans.PNT;

namespace SIGDA.SRHN.Libreria.Herramientas.Transp
{
    public class PntProgress
    {
        public async Task<List<InfoEmp>> InfoCurricular(InfoEmp identif)
        {
            LoginRequest loginRequest = new LoginRequest();
            loginRequest.Username = "adminSRHN";
            loginRequest.Passwd = "C3cilio1804.";
            APIConnection apiConection = new APIConnection();
            SecToken token = apiConection.ObtenerSecureTokenLocal(loginRequest);

            HttpClient client = new HttpClient();
            var targeturi = APIConnection.APISecure + "api/transparencia/pnt/curricular";
            client.DefaultRequestHeaders.Add("SK", token.Key);
            client.DefaultRequestHeaders.Add("SP", token.Secure);
            client.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", token.Token);
            var responseTask = client.PostAsJsonAsync(targeturi, identif);
            responseTask.Wait();
            var result2 = responseTask.Result;
            if (result2.IsSuccessStatusCode)
            {
                string responseContent = await result2.Content.ReadAsStringAsync();
                var productResult = JsonConvert.DeserializeObject<List<InfoEmp>>(responseContent);
                return productResult;
            }
            else
                return null;
        }
        public async Task<List<RemuneracionBrutaNeta>> InfoRemuneracionBrutaNeta(RemuneracionBrutaNeta identif)
        {
            LoginRequest loginRequest = new LoginRequest();
            loginRequest.Username = "adminSRHN";
            loginRequest.Passwd = "C3cilio1804.";
            APIConnection apiConection = new APIConnection();
            SecToken token = apiConection.ObtenerSecureTokenLocal(loginRequest);

            HttpClient client = new HttpClient();
            client.Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite);
            var targeturi = APIConnection.APISecure + "api/transparencia/pnt/RemuneracionBrutaNeta";
            client.DefaultRequestHeaders.Add("SK", token.Key);
            client.DefaultRequestHeaders.Add("SP", token.Secure);
            client.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", token.Token);
            var responseTask = client.PostAsJsonAsync(targeturi, identif);
            responseTask.Wait(-1);
            var result2 = responseTask.Result;
            if (result2.IsSuccessStatusCode)
            {
                string responseContent = await result2.Content.ReadAsStringAsync();
                var productResult = JsonConvert.DeserializeObject<List<RemuneracionBrutaNeta>>(responseContent);
                return productResult;
            }
            else
                return null;
        }
        public async Task<List<RemuneracionBrutaNetaTabla>> InfoRemuneracionBrutaNetaTabla(RemuneracionBrutaNetaTabla identif)
        {
            LoginRequest loginRequest = new LoginRequest();
            loginRequest.Username = "adminSRHN";
            loginRequest.Passwd = "C3cilio1804.";
            APIConnection apiConection = new APIConnection();
            SecToken token = apiConection.ObtenerSecureTokenLocal(loginRequest);

            HttpClient client = new HttpClient();
            client.Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite);
            var targeturi = APIConnection.APISecure + "api/transparencia/pnt/RemuneracionBrutaNetaTabla";
            client.DefaultRequestHeaders.Add("SK", token.Key);
            client.DefaultRequestHeaders.Add("SP", token.Secure);
            client.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", token.Token);
            var responseTask = client.PostAsJsonAsync(targeturi, identif);
            responseTask.Wait(-1);
            var result2 = responseTask.Result;
            if (result2.IsSuccessStatusCode)
            {
                string responseContent = await result2.Content.ReadAsStringAsync();
                var productResult = JsonConvert.DeserializeObject<List<RemuneracionBrutaNetaTabla>>(responseContent);
                return productResult;
            }
            else
                return null;
        }
    }
}
