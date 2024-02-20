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
    public class ApiBiometriasController
    {
        public static readonly string apiBiometricos = ConfigurationManager.AppSettings["apiBiometricos"];
        
        public async Task<BiometriaEmpleado> DescargaBiometriaEmpleado(int idEmpleado, string ipTerminal, int puertoConexion, long numSerie)

        {
            var  resultado = new BiometriaEmpleado();
            //FotosResualtado  resultado = new FotosResualtado();
            //InfoBiometrico infoBiometrico = new InfoBiometrico();
            var valores = new ObtenerBiometria { IdEmpleado = idEmpleado, IpTerminal = ipTerminal, PortConexion = puertoConexion, Numserie = numSerie};
            try
            {
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(apiBiometricos);
                    //var json = System.Text.Json.JsonSerializer.Serialize(Valores);
                    //HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var json = System.Text.Json.JsonSerializer.Serialize(valores);
                    HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var response = await cliente.PostAsync("ObtenerBiometriaEmpleado", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        resultado = JsonConvert.DeserializeObject<BiometriaEmpleado>(result);

                    }
                }

            }
            catch (Exception ex)
            {

               // resultado.ConexionEstatus = false;
               // resultado.MsjError = ex.Message;
            }
            return resultado;
        }

        public async Task<bool> GuardarBiometriaReloj(int idEmpleado, int idTerminal, string bioEmplTemplate)

        {
            bool resultado;
            //FotosResualtado  resultado = new FotosResualtado();
            //InfoBiometrico infoBiometrico = new InfoBiometrico();
            var valores = new BiometriaEnvio { Id = idEmpleado, IdTerminal = idTerminal, BiometriaTemplate = bioEmplTemplate };
            try
            {
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(apiBiometricos);
                    cliente.Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite);
                    //var json = System.Text.Json.JsonSerializer.Serialize(Valores);
                    //HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var json = System.Text.Json.JsonSerializer.Serialize(valores);
                    HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var response = await cliente.PostAsync("InsertarBiometriaMSSQL", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        resultado = JsonConvert.DeserializeObject<bool>(result);

                    }
                }

            }
            catch (Exception ex)
            {

                // resultado.ConexionEstatus = false;
                // resultado.MsjError = ex.Message;
            }
            return true;
        }



        public async Task<ConfiguracionBiometrico> ObtenerConfiguracionTerminalBiometrica(string ipTerminal, int puertoConexion)

        {
            ConfiguracionBiometrico resultado = new ConfiguracionBiometrico();
            //FotosResualtado  resultado = new FotosResualtado();
            //InfoBiometrico infoBiometrico = new InfoBiometrico();
            var valores = new BusquedaTerminal { IpTerminal = ipTerminal, PortTerminal= puertoConexion };
            try
            {
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(apiBiometricos);
                    //var json = System.Text.Json.JsonSerializer.Serialize(Valores);
                    //HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var json = System.Text.Json.JsonSerializer.Serialize(valores);
                    HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var response = await cliente.PostAsync("ObtenerConfigTerminal", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        resultado = JsonConvert.DeserializeObject<ConfiguracionBiometrico>(result);

                    }
                }

            }
            catch (Exception ex)
            {

                // resultado.ConexionEstatus = false;
                // resultado.MsjError = ex.Message;
            }
            return resultado;
        }

        public async Task<List<int>> ObtenerListadoEmpleadosTerminalBiometrica(string ipTerminal, int puertoConexion)

        {
             var resultado = new List<int>();
            //FotosResualtado  resultado = new FotosResualtado();
            //InfoBiometrico infoBiometrico = new InfoBiometrico();
            var valores = new BusquedaTerminal { IpTerminal = ipTerminal, PortTerminal = puertoConexion };
            try
            {
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(apiBiometricos);
                    //var json = System.Text.Json.JsonSerializer.Serialize(Valores);
                    //HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var json = System.Text.Json.JsonSerializer.Serialize(valores);
                    HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var response = await cliente.PostAsync("ObtenerListaEmpleadosTerminalBiometrica", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        resultado = JsonConvert.DeserializeObject<List<int>>(result);

                    }
                }

            }
            catch (Exception ex)
            {

                // resultado.ConexionEstatus = false;
                // resultado.MsjError = ex.Message;
            }
            return resultado;
        }




        public async Task<bool> EnviarBiometriaBio(string ipTerminal, int puerto, byte[] bioEmplTemplate)

        {
            bool resultado = false;
            //FotosResualtado  resultado = new FotosResualtado();
            //InfoBiometrico infoBiometrico = new InfoBiometrico();
            var valores = new BiometriaEnvio { IpTerminal = ipTerminal, Port = puerto,  TemplateToSend = bioEmplTemplate };
            try
            {
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(apiBiometricos);
                    cliente.Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite);
                    //var json = System.Text.Json.JsonSerializer.Serialize(Valores);
                    //HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var json = System.Text.Json.JsonSerializer.Serialize(valores);
                    HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var response = await cliente.PostAsync("EnviarBiometriaEmpleado", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        resultado = JsonConvert.DeserializeObject<bool>(result);

                    }
                }

            }
            catch (Exception ex)
            {
                resultado = false;
                // resultado.ConexionEstatus = false;
                // resultado.MsjError = ex.Message;
            }
            return resultado;
        }




    }
}
