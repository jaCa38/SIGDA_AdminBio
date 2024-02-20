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
    public class ApiFotosCotroller
    {
        public static readonly string apiBiometricos = ConfigurationManager.AppSettings["apiBiometricos"];
        
        public async Task<FotosResualtado> DescargaFotoOkBiometricos(DateTime fechaDescargaFoto, string ipTerminal, int portTerminal, string nombreTerminal)

        {
            FotosResualtado resultado = new FotosResualtado();
            //FotosResualtado  resultado = new FotosResualtado();
            //InfoBiometrico infoBiometrico = new InfoBiometrico();
            var valores = new BusquedaFotoFailed { FechaBusqueda = fechaDescargaFoto, IpTerminal = ipTerminal, PortTerminal = portTerminal, NombreTerminal =nombreTerminal };
            try
            {
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(apiBiometricos);
                    //var json = System.Text.Json.JsonSerializer.Serialize(Valores);
                    //HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var json = System.Text.Json.JsonSerializer.Serialize(valores);
                    HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var response = await cliente.PostAsync("DescargaFotosBiometrico", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        resultado = JsonConvert.DeserializeObject<FotosResualtado>(result);
                       
                    }
                }

            }
            catch (Exception ex)
            {
                
                resultado.ConexionEstatus = false;
                resultado.MsjError = ex.Message;
            }
           return resultado;
        }

        public async Task<FotosResualtado> DescargaFotoBioSorrymetricos(DateTime fechaDescargaFoto, string ipTerminal, int portTerminal, string nombreTerminal)

        {
            FotosResualtado resultado = new FotosResualtado();
            //FotosResualtado  resultado = new FotosResualtado();
            //InfoBiometrico infoBiometrico = new InfoBiometrico();
            var valores = new BusquedaFotoFailed { FechaBusqueda = fechaDescargaFoto, IpTerminal = ipTerminal, PortTerminal = portTerminal, NombreTerminal = nombreTerminal };
            try
            {
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(apiBiometricos);
                    //var json = System.Text.Json.JsonSerializer.Serialize(Valores);
                    //HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var json = System.Text.Json.JsonSerializer.Serialize(valores);
                    HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var response = await cliente.PostAsync("DescargaFotosSorryBiometrico", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        resultado = JsonConvert.DeserializeObject<FotosResualtado>(result);

                    }
                }

            }
            catch (Exception ex)
            {

                resultado.ConexionEstatus = false;
                resultado.MsjError = ex.Message;
            }
            return resultado;
        }




        public async Task<bool> InsertarLogFotosDescargaMSSQL(int idTerminal, DateTime fechaDescarga, int cantidadFotos, int cantidadRegistros)
        {

            bool resultado = true;
            var valores = new LogAudit { IdTerminal = idTerminal, FechaDescarga = fechaDescarga, CantidadFotos = cantidadFotos, CantidadRegistros = cantidadRegistros };
            try
            {
                using (var Cliente = new HttpClient())
                {
                    Cliente.BaseAddress = new Uri(apiBiometricos);
                    var json = System.Text.Json.JsonSerializer.Serialize(valores);
                    HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var response = await Cliente.PostAsync("InsertarLogDescargaFotosMSSQL", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        resultado = JsonConvert.DeserializeObject<bool>(result);

                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return resultado;
        }


        



    }
}
