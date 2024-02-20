using Newtonsoft.Json;
using SIGDA.APIProgress.Models.Vac;
using SIGDA.APIProgress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SIGDA.APIProgress.Models.Trans.ASEG;
using SIGDA.APIProgress.Models.Trans.ASEG.CveEmp;
using static Dapper.SqlMapper;

namespace SIGDA.SRHN.Libreria.Herramientas.Transp
{
    public class AsegProgress
    {
        public async Task<List<CuentaEmpleado>> CuentasEmpleado(CuentaEmpleado identif)
        {
            LoginRequest loginRequest = new LoginRequest();
            loginRequest.Username = "adminSRHN";
            loginRequest.Passwd = "C3cilio1804.";
            APIConnection apiConection = new APIConnection();
            SecToken token = apiConection.ObtenerSecureTokenLocal(loginRequest);

            HttpClient client = new HttpClient();
            var targeturi = APIConnection.APISecure + "api/transparencia/aseg/cuentasEmpleado";
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
                var productResult = JsonConvert.DeserializeObject<List<CuentaEmpleado>>(responseContent);
                return productResult;
            }
            else
                return null;
        }
        public async Task<List<MovimientoLicencia>> ObtenerLicencias(MovimientoLicencia identif)
        {
            LoginRequest loginRequest = new LoginRequest();
            loginRequest.Username = "adminSRHN";
            loginRequest.Passwd = "C3cilio1804.";
            APIConnection apiConection = new APIConnection();
            SecToken token = apiConection.ObtenerSecureTokenLocal(loginRequest);

            HttpClient client = new HttpClient();
            var targeturi = APIConnection.APISecure + "api/transparencia/aseg/licencias";
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
                var productResult = JsonConvert.DeserializeObject<List<MovimientoLicencia>>(responseContent);
                return productResult;
            }
            else
                return null;
        }
        public async Task<List<MovimientoLicencia>> ObtenerMovimientos(MovimientoLicencia identif)
        {
            LoginRequest loginRequest = new LoginRequest();
            loginRequest.Username = "adminSRHN";
            loginRequest.Passwd = "C3cilio1804.";
            APIConnection apiConection = new APIConnection();
            SecToken token = apiConection.ObtenerSecureTokenLocal(loginRequest);

            HttpClient client = new HttpClient();
            var targeturi = APIConnection.APISecure + "api/transparencia/aseg/movimientos";
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
                var productResult = JsonConvert.DeserializeObject<List<MovimientoLicencia>>(responseContent);
                return productResult;
            }
            else
                return null;
        }
        public async Task<List<QnaTrimestre>> ObtenerQnasTrimestre(QnaTrimestre identif)
        {
            LoginRequest loginRequest = new LoginRequest();
            loginRequest.Username = "adminSRHN";
            loginRequest.Passwd = "C3cilio1804.";
            APIConnection apiConection = new APIConnection();
            SecToken token = apiConection.ObtenerSecureTokenLocal(loginRequest);

            HttpClient client = new HttpClient();
            var targeturi = APIConnection.APISecure + "api/transparencia/aseg/clavesxEmpleado/uno";
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
                var productResult = JsonConvert.DeserializeObject<List<QnaTrimestre>>(responseContent);
                return productResult;
            }
            else
                return null;
        }
        public async Task<List<InfoEmpleado>> ObtenerDatosEmpleado(InfoEmpleado identif)
        {
            LoginRequest loginRequest = new LoginRequest();
            loginRequest.Username = "adminSRHN";
            loginRequest.Passwd = "C3cilio1804.";
            APIConnection apiConection = new APIConnection();
            SecToken token = apiConection.ObtenerSecureTokenLocal(loginRequest);

            HttpClient client = new HttpClient();
            client.Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite);
            var targeturi = APIConnection.APISecure + "api/transparencia/aseg/clavesxEmpleado/dos";
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
                var productResult = JsonConvert.DeserializeObject<List<InfoEmpleado>>(responseContent);
                return productResult;
            }
            else
                return null;
        }
        public async Task<List<ClaveEmpleadoTrim>> ObtenerClavesEmpleadoTrimestre(ClaveEmpleadoTrim identif)
        {
            LoginRequest loginRequest = new LoginRequest();
            loginRequest.Username = "adminSRHN";
            loginRequest.Passwd = "C3cilio1804.";
            APIConnection apiConection = new APIConnection();
            SecToken token = apiConection.ObtenerSecureTokenLocal(loginRequest);

            HttpClient client = new HttpClient();
            var targeturi = APIConnection.APISecure + "api/transparencia/aseg/clavesxEmpleado/tres";
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
                var productResult = JsonConvert.DeserializeObject<List<ClaveEmpleadoTrim>>(responseContent);
                return productResult;
            }
            else
                return null;
        }
    }
}
