using Newtonsoft.Json;
using SIGDA.CA.Biometricos.Libreria.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestBiometricos
{
    public class ApiConsultarDbController
    {
        public static readonly string apiBiometricos = ConfigurationManager.AppSettings["apiBiometricos"];
        //public static readonly string apiBiometricos = ConfigurationManager.AppSettings["apiBiometricosDebug"];

       


        public async Task<List<ListaBiometriasEmpleado>> ObtenerListaDeBiometriasDb(int idEmpleado, string fw)
        {

            var resultado = new List<ListaBiometriasEmpleado>();
            var valores = new ObtenerBiometriasDb { IdEmpleado =idEmpleado , Fw = fw };
            try
            {
                using (var cliente = new HttpClient())
                {
                    cliente.Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite);
                    cliente.BaseAddress = new Uri(apiBiometricos);

                      var json = System.Text.Json.JsonSerializer.Serialize(valores);
                      HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var response = await cliente.PostAsync("ObtenerBiometriasDbEmpleado", content);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        resultado = JsonConvert.DeserializeObject<List<ListaBiometriasEmpleado>>(result);

                    }

                }

            }
            catch (Exception ex)
            {
                return resultado;
            }
            return resultado;
        }








    }
}
