using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using Newtonsoft.Json;
using System.Threading.Tasks;
using SIGDA.CA.Biometricos.Libreria.Models;
using Microsoft.IdentityModel.Tokens;
using System.Windows.Forms;


namespace SIGDA.CA.Biometricos.Libreria.Tools
{
    public   class ConexionApiNombramientos
    {
        public static readonly string apiBiometricos = Conexion.ConexionStrings.CONEXION_API_NOMBRAMIENTO;

        public  async Task<List<NombramientosRh>> ConectarConApiNom(int municipio, DateTime fechaInicio, DateTime fechaFin)
        {
            NombramientosRh nombramiento = new NombramientosRh();
            nombramiento.Inicio = fechaInicio.ToString("dd/MM/yyyy");
            nombramiento.Fin = fechaFin.ToString("dd/MM/yyyy");
            nombramiento.IdMunicipio = municipio;
            var resultadoNombremientos = new List<NombramientosRh>();
            //var valores = new NombramientosRh { inicio = fechaInicio.ToString("dd/MM/yyyy"), fin = fechaInicio.ToString("dd/MM/yyyy"), idMunicipio = municipio };
            //var json = Newtonsoft.Json.JsonConvert.SerializeObject(valores);
            //HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = ApiHelper.ApiClient.PostAsJsonAsync<NombramientosRh>(apiBiometricos, nombramiento);
            
              response.Wait();
              var result2 = response.Result;  

                if (result2.IsSuccessStatusCode)
                {
                    var result = await result2.Content.ReadAsStringAsync();
                    resultadoNombremientos = JsonConvert.DeserializeObject<List<NombramientosRh>>(result);
                }
                         
            return resultadoNombremientos;
        }




        #region test
        //public static readonly string apiBiometricos = Conexion.ConexionStrings.CONEXION_API_NOMBRAMIENTO;

        //public  async Task<List<NombramientosRh>> ConsultaNombramientosPorMunicipio( int idMunicipio, DateTime fechaInicioNom, DateTime fechaFinNom)
        //{

        //    var resultado = new List<NombramientosRh>();
        //    var Valores = new NombramientosRh { inicio = fechaInicioNom.ToString("dd/MM/yyyy"), fin = fechaFinNom.ToString("dd/MM/yyyy"), idMunicipio = idMunicipio };
        //    try
        //    {
        //        using (var cliente = new HttpClient())
        //        {
        //            cliente.Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite);
        //            cliente.BaseAddress = new Uri(apiBiometricos);

        //            //var json = System.Text.Json.JsonSerializer.Serialize(Valores);
        //            var json = Newtonsoft.Json.JsonConvert.SerializeObject(Valores);
        //            HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

        //            var response = await cliente.PostAsync("periodos", content);

        //            if (response.IsSuccessStatusCode)
        //            {
        //                var result = await response.Content.ReadAsStringAsync();
        //                resultado = JsonConvert.DeserializeObject<List<NombramientosRh>>(result);

        //            }

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        resultado.IsNullOrEmpty();
        //    }
        //    return resultado;
        //}
        #endregion
    }
}
