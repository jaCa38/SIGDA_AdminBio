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

namespace TestBiometricos
{


    public class ApiControllers
    {

       public static readonly string apiBiometricos = ConfigurationManager.AppSettings["apiBiometricos"];
       

        
        

        #region Prueba

        public async Task<BaseResultado> ValidadBiometria(int idEmpleado, string IpTerminal, int puertoTerminal)
        {
            BaseResultado resultadoV = new BaseResultado();
            var valores = new BorradorEmpleado { Id = idEmpleado, IpTerminal = IpTerminal , PortConexion = puertoTerminal };
            string resultado;
            try
            {
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(apiBiometricos);
                    var json = System.Text.Json.JsonSerializer.Serialize(valores);
                    HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var response = await cliente.PostAsync("VerificaBiometria", content);
                    if (response.IsSuccessStatusCode)
                    {
                        resultado = await response.Content.ReadAsStringAsync();
                        resultadoV = JsonConvert.DeserializeObject<BaseResultado>(resultado);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return resultadoV;
        }


        public async Task<List<InfoBiometrico>> ObtenerListaRelojes()
        {

            List<InfoBiometrico> infoBiometrico = null;
            try
            {
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(apiBiometricos);
                    //var json = System.Text.Json.JsonSerializer.Serialize(Valores);
                    //HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var response = await cliente.PostAsync("ObtenerIpTerminales", null);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        infoBiometrico = JsonConvert.DeserializeObject<List<InfoBiometrico>>(result);
                    }
                    

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return infoBiometrico;
        }




        public async Task<string> EliminarBiometria(int idEmpleado, string ipTerminal, int puertoConexion)
        {

            var Valores = new BorradorEmpleado { Id = idEmpleado, IpTerminal = ipTerminal, PortConexion = puertoConexion };
            string resultado = string.Empty;
            try
            {
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(apiBiometricos);
                    var json = System.Text.Json.JsonSerializer.Serialize(Valores);
                    HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var response = await cliente.PostAsync("EliminarEmpleadoBiometrico", content);
                    if (response.IsSuccessStatusCode)
                    {
                        resultado = await response.Content.ReadAsStringAsync();

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return resultado;
        }


        public async Task<InfoBiometrico> ObtenerInformacionTerminal(int idTerminal)

        {

            InfoBiometrico infoBiometrico = new InfoBiometrico();
            var valores = new BusquedaTerminal { IdTerminal = idTerminal };
            try
            {
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(apiBiometricos);
                    //var json = System.Text.Json.JsonSerializer.Serialize(Valores);
                    //HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var json = System.Text.Json.JsonSerializer.Serialize(valores);
                    HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var response = await cliente.PostAsync("ObtenerInfoTerminal", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        infoBiometrico = JsonConvert.DeserializeObject<InfoBiometrico>(result);

                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return infoBiometrico;
        }



        public async Task<List<RegistrosRelojes>> ObternerRegistrosTerminal(string ipBio, int portBio, DateTime fechaRec)
        {

            List<RegistrosRelojes> infoBiometrico = new List<RegistrosRelojes>();
            var valores = new DescargaRegistros { IpTerminal = ipBio, PortTerminal = portBio, Fecha = fechaRec };
            try
            {
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(apiBiometricos);
                    var json = System.Text.Json.JsonSerializer.Serialize(valores);
                    HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var response = await cliente.PostAsync("ObtenerRegistrosTerminal", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        infoBiometrico = JsonConvert.DeserializeObject<List<RegistrosRelojes>>(result);

                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return infoBiometrico;
        }


        public async Task<bool> InsertarRegistroSICA(int idTerminalBio, int idEmpleadoBio, DateTime fechaRec)
        {

            bool Resultado = true;
            var Valores = new RegistrosRelojes { IdTerminal = idTerminalBio, IdEmpleado = idEmpleadoBio, Record = fechaRec };
            try
            {
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(apiBiometricos);
                    var json = System.Text.Json.JsonSerializer.Serialize(Valores);
                    HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var response = await cliente.PostAsync("InsertarRegistrosMYSQL", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        Resultado = JsonConvert.DeserializeObject<bool>(result);

                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Resultado;
        }

        public async Task<bool> InsertarRegistroSIGDA(int idTerminalBio, int idEmpleadoBio, DateTime fechaRec)
        {

            bool Resultado = true;
            var Valores = new RegistrosRelojes { IdTerminal = idTerminalBio, IdEmpleado = idEmpleadoBio, Record = fechaRec };
            try
            {
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(apiBiometricos);
                    var json = System.Text.Json.JsonSerializer.Serialize(Valores);
                    HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var response = await cliente.PostAsync("InsertarRegistrosMSSQL", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        Resultado = JsonConvert.DeserializeObject<bool>(result);

                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Resultado;
        }


        public async Task<bool> InsertarBiometriasDbMSSQL(int idEmpleado, int idTerminal, string template)
        {

            bool Resultado = true;
            var Valores = new BiometriaEnvio { Id= idEmpleado, IdTerminal = idTerminal, BiometriaTemplate = template };
            try
            {
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(apiBiometricos);
                    var json = System.Text.Json.JsonSerializer.Serialize(Valores);
                    HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var response = await cliente.PostAsync("InsertarBiometriaMSSQL", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        Resultado = JsonConvert.DeserializeObject<bool>(result);

                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Resultado;
        }



        

        //public bool InsertarRegistroSICA1(int idTerminalBio, int idEmpleadoBio)
        //{

        //    bool Resultado = true;
        //    var Valores = new RegistrosRelojes { IdTerminal = idTerminalBio, IdEmpleado = idEmpleadoBio };
        //    try
        //    {
        //        using (var cliente = new HttpClient())
        //        {
        //            cliente.BaseAddress = new Uri(apiBiometricos);
        //            var json = System.Text.Json.JsonSerializer.Serialize(Valores);
        //            HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

        //            var response = cliente.PostAsync("EjecutarProcesarInformacionTest", null);
        //            if (response.IsSuccessStatusCode)
        //            {
        //                var result = response.Content.ReadAsStringAsync();
        //                Resultado = JsonConvert.DeserializeObject<bool>(result);

        //            }

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return Resultado;
        //}



        //public async Task<bool> InsertarLogAudit(int IdTerminalBio, DateTime FechaDescargaBio, int CantidadRegistrosBio, int ConexionEstatusBio, string MsjErrorBio)
        //{

        //    bool Resultado = true;
        //    var Valores = new LogAudit { IdTerminal = IdTerminalBio, FechaDescarga= FechaDescargaBio, CantidadRegistros = CantidadRegistrosBio, ConexionEstatus = ConexionEstatusBio, MsjError = MsjErrorBio};
        //    try
        //    {
        //        using (var Cliente = new HttpClient())
        //        {
        //            Cliente.BaseAddress = new Uri(InsertLogAuditMysql);
        //            var json = System.Text.Json.JsonSerializer.Serialize(Valores);
        //            HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

        //            var response = await Cliente.PostAsync(Cliente.BaseAddress, content);
        //            if (response.IsSuccessStatusCode)
        //            {
        //                var result = await response.Content.ReadAsStringAsync();
        //                Resultado = JsonConvert.DeserializeObject<bool>(result);

        //            }

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return Resultado;
        //}

        public async Task<List<RegistrosRelojes>> ObternerRegistrosTerminalPorRango(string ipTerminal, int puertoTerminal, DateTime fechaInicio, DateTime fechaFin)
        {

            List<RegistrosRelojes> infoBiometrico = new List<RegistrosRelojes>();
            var valores = new DescargaRegistrosPorFecha { IpTerminal = ipTerminal, PortTerminal = puertoTerminal, FechaInicio = fechaInicio, FechaFin = fechaFin };
            try
            {
                using (var Cliente = new HttpClient())
                {
                    Cliente.BaseAddress = new Uri(apiBiometricos);
                    var json = System.Text.Json.JsonSerializer.Serialize(valores);
                    HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var response = await Cliente.PostAsync("ObtenerRegistrosTerminalPorRangoFechas", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        infoBiometrico = JsonConvert.DeserializeObject<List<RegistrosRelojes>>(result);

                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return infoBiometrico;
        }


        public async Task<bool> InsertarLogAuditMSSQL(int idTerminal, DateTime fechaDescarga, int cantidadRegistros)
        {

            bool resultado = true;
            var valores = new LogAudit { IdTerminal = idTerminal, FechaDescarga = fechaDescarga, CantidadRegistros = cantidadRegistros };
            try
            {
                using (var Cliente = new HttpClient())
                {
                    Cliente.BaseAddress = new Uri(apiBiometricos);
                    var json = System.Text.Json.JsonSerializer.Serialize(valores);
                    HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var response = await Cliente.PostAsync("InsertarLogDescargaRegistrosMSSQL", content);
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


        public async Task<bool> InsertarLogErrorMSSQL(int idTerminal, int tipoTarea, DateTime fechaDescarga, string msjError)
        {

            bool resultado = true;
            var valores = new LogAudit { IdTerminal = idTerminal, TipoTarea = tipoTarea, FechaDescarga = fechaDescarga, MsjError = msjError };
            try
            {
                using (var Cliente = new HttpClient())
                {
                    Cliente.BaseAddress = new Uri(apiBiometricos);
                    var json = System.Text.Json.JsonSerializer.Serialize(valores);
                    HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var response = await Cliente.PostAsync("InsertarLogErrorMSSQL", content);
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


        //public async Task<bool> InsertarLogAuditSIGDA(int IdTerminalBio, DateTime FechaDescargaBio, int CantidadRegistrosBio, int ConexionEstatusBio, string MsjErrorBio)
        //{

        //    bool Resultado = true;
        //    var Valores = new LogAudit { IdTerminal = IdTerminalBio, FechaDescarga = FechaDescargaBio, CantidadRegistros = CantidadRegistrosBio, ConexionEstatus = ConexionEstatusBio, MsjError = MsjErrorBio };
        //    try
        //    {
        //        using (var Cliente = new HttpClient())
        //        {
        //            Cliente.BaseAddress = new Uri(InsertLogAuditMysql);
        //            var json = System.Text.Json.JsonSerializer.Serialize(Valores);
        //            HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

        //            var response = await Cliente.PostAsync(Cliente.BaseAddress, content);
        //            if (response.IsSuccessStatusCode)
        //            {
        //                var result = await response.Content.ReadAsStringAsync();
        //                Resultado = JsonConvert.DeserializeObject<bool>(result);

        //            }

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return Resultado;
        //}

        #endregion prueba

    }
}
