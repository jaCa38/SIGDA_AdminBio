using Newtonsoft.Json;
using SIGDA.APIProgress.Models;
using SIGDA.APIProgress.Models.Vac;
using SIGDA.SRHN.Libreria.Herramientas.ASF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Herramientas.Vac
{
    public class VacacionProgress
    {
        public async Task<int> ObtenerDiasProgress(int idEmpleado, int idPeriodo, int anio)
        {
            int diasObtenidos = 0;
            LoginRequest loginRequest = new LoginRequest();
            loginRequest.Username = "adminSRHN";
            loginRequest.Passwd = "C3cilio1804.";
            APIConnection apiConection = new APIConnection();
            SecToken token = apiConection.ObtenerSecureTokenLocal(loginRequest);

            HttpClient client = new HttpClient();
            var targeturi = APIConnection.APISecure + "api/vacacion?idEmpleado=" + idEmpleado.ToString()
                + "&idPeriodo=" + idPeriodo.ToString() + "&anio=" + anio.ToString();
            client.DefaultRequestHeaders.Add("SK", token.Key);
            client.DefaultRequestHeaders.Add("SP", token.Secure);
            client.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", token.Token);
            var responseTask = client.GetAsync(targeturi);
            responseTask.Wait();
            var result2 = responseTask.Result;
            if (result2.IsSuccessStatusCode)
            {
                string responseContent = await result2.Content.ReadAsStringAsync();
                diasObtenidos = Convert.ToInt32(responseContent);
            }
            return diasObtenidos;
        }
        public async Task<List<Periodo>> GetReportebyCT(string identificadorNomina, int idPeriodo, int anio)
        {            
            LoginRequest loginRequest = new LoginRequest();
            loginRequest.Username = "adminSRHN";
            loginRequest.Passwd = "C3cilio1804.";
            APIConnection apiConection = new APIConnection();
            SecToken token = apiConection.ObtenerSecureTokenLocal(loginRequest);

            HttpClient client = new HttpClient();
            var targeturi = APIConnection.APISecure + "api/vacacion/reporte?identifiacadorNomina=" + identificadorNomina
                + "&idPeriodo=" + idPeriodo.ToString() + "&anio=" + anio.ToString();
            client.DefaultRequestHeaders.Add("SK", token.Key);
            client.DefaultRequestHeaders.Add("SP", token.Secure);
            client.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", token.Token);
            var responseTask = client.GetAsync(targeturi);
            responseTask.Wait();
            var result2 = responseTask.Result;
            if (result2.IsSuccessStatusCode)
            {
                string responseContent = await result2.Content.ReadAsStringAsync();
                var productResult = JsonConvert.DeserializeObject<List<Periodo>>(responseContent);
                return productResult;
            }
            else
                return null;
        }
        public async Task<List<Periodo>> GetReportePlantilla(int idPeriodo, int anio)
        {
            LoginRequest loginRequest = new LoginRequest();
            loginRequest.Username = "adminSRHN";
            loginRequest.Passwd = "C3cilio1804.";
            APIConnection apiConection = new APIConnection();
            SecToken token = apiConection.ObtenerSecureTokenLocal(loginRequest);

            HttpClient client = new HttpClient();
            var targeturi = APIConnection.APISecure + "api/vacacion/repoPlantilla?idPeriodo=" + idPeriodo.ToString() + "&anio=" + anio.ToString();
            client.DefaultRequestHeaders.Add("SK", token.Key);
            client.DefaultRequestHeaders.Add("SP", token.Secure);
            client.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", token.Token);
            var responseTask = client.GetAsync(targeturi);
            responseTask.Wait();
            var result2 = responseTask.Result;
            if (result2.IsSuccessStatusCode)
            {
                string responseContent = await result2.Content.ReadAsStringAsync();
                var productResult = JsonConvert.DeserializeObject<List<Periodo>>(responseContent);
                return productResult;
            }
            else
                return null;
        }
        public async Task<List<Puesto>> GetTodosPuestos()
        {
            LoginRequest loginRequest = new LoginRequest();
            loginRequest.Username = "adminSRHN";
            loginRequest.Passwd = "C3cilio1804.";
            APIConnection apiConection = new APIConnection();
            SecToken token = apiConection.ObtenerSecureTokenLocal(loginRequest);

            HttpClient client = new HttpClient();
            var targeturi = APIConnection.APISecure + "api/vacacion/puestosTodos";
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
                var productResult = JsonConvert.DeserializeObject<List<Puesto>>(responseContent);
                return productResult;
            }
            else
                return null;
        }
        public async Task<List<PuestoEmpleado>> GetPuestosByCT(DatosVacacion identif)
        {
            LoginRequest loginRequest = new LoginRequest();
            loginRequest.Username = "adminSRHN";
            loginRequest.Passwd = "C3cilio1804.";
            APIConnection apiConection = new APIConnection();
            SecToken token = apiConection.ObtenerSecureTokenLocal(loginRequest);

            HttpClient client = new HttpClient();
            var targeturi = APIConnection.APISecure + "api/vacacion/puestosByCT";
            client.DefaultRequestHeaders.Add("SK", token.Key);
            client.DefaultRequestHeaders.Add("SP", token.Secure);
            client.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", token.Token);
            var responseTask = client.PostAsJsonAsync<DatosVacacion>(targeturi, identif);
            responseTask.Wait();
            var result2 = responseTask.Result;
            if (result2.IsSuccessStatusCode)
            {
                string responseContent = await result2.Content.ReadAsStringAsync();
                var productResult = JsonConvert.DeserializeObject<List<PuestoEmpleado>>(responseContent);
                return productResult;
            }
            else
                return null;
        }        
    }
}
