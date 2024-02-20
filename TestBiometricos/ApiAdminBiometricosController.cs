using SIGDA.CA.Biometricos.Libreria.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;
//using System.Text.Json;
//using System.Text.Json.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks.Sources;

namespace TestBiometricos
{


    public class ApiAdminBiometricos
    {

       public static readonly string apiBiometricos = ConfigurationManager.AppSettings["apiBiometricos"];
       

        
        

       

        public async Task<ConfiguracionBiometrico> ConfiguracionTerminalBiometrica( string ipTerminal, int puertoTerminal)
        {
            var resultadoConfiguracion = new ConfiguracionBiometrico();
            var valores = new BusquedaTerminal {IpTerminal = ipTerminal, PortTerminal = puertoTerminal };
          
            try
            {
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(apiBiometricos);
                    var json = System.Text.Json.JsonSerializer.Serialize(valores);
                    HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var response = await cliente.PostAsync("ObtenerConfigTerminal", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var resultado = await response.Content.ReadAsStringAsync();
                        resultadoConfiguracion  = JsonConvert.DeserializeObject<ConfiguracionBiometrico>(resultado);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return resultadoConfiguracion;
        }

        public async Task<BaseResultado> AjusteHorarioBiometricos(string ipTerminal, int puertoTerminal)
        {
            var resultadoConfiguracion = new BaseResultado();
            var valores = new BusquedaTerminal { IpTerminal = ipTerminal, PortTerminal = puertoTerminal };

            try
            {
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(apiBiometricos);
                    var json = System.Text.Json.JsonSerializer.Serialize(valores);
                    HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var response = await cliente.PostAsync("FijarFechaHora", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var resultado = await response.Content.ReadAsStringAsync();
                        resultadoConfiguracion = JsonConvert.DeserializeObject<BaseResultado>(resultado);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return resultadoConfiguracion;
        }















    }
}
