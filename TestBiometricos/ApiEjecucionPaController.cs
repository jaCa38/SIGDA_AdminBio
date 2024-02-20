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
    public class ApiEjecucionPaController
    {
        public static readonly string apiBiometricos = ConfigurationManager.AppSettings["apiBiometricos"];
        

       


        public async Task<bool> EjecutaPaDbProcesarInfoSICA()
        {

            bool resultado = true;
            //var Valores = new RegistrosRelojes { IdTerminal = idTerminalBio, IdEmpleado = idEmpleadoBio };
            try
            {
                using (var cliente = new HttpClient())
                {
                    cliente.Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite);
                    cliente.BaseAddress = new Uri(apiBiometricos);

                      //var json = System.Text.Json.JsonSerializer.Serialize(Valores);
                      //HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var response = await cliente.PostAsync("EjecutarProcesarInformacion", null);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        resultado = JsonConvert.DeserializeObject<bool>(result);

                    }

                }

            }
            catch (Exception ex)
            {
                resultado = true;
            }
            return resultado;
        }








    }
}
