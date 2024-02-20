using Dapper;
using MySql.Data.MySqlClient;
using SIGDA.CA.Biometricos.Libreria.Conexion;
using SIGDA.CA.Biometricos.Libreria.Models;
using SIGDA.CA.Biometricos.Libreria.Services;
using SIGDA.CA.Biometricos.Libreria.Tools;
using Splash;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SIGDA.CA.Biometricos.Libreria.Controllers
{
    public class AdministracionBiometricosController : IAdministracionBiometrico, IDisposable
    {
        private string strConexionMYSQL;
        private string strConexionMSSQL;
        DataTableReader dtrResultado = null;

        public AdministracionBiometricosController(string cadenaMysql, string cadenaMSSQL)
        {
            strConexionMYSQL = cadenaMysql;
            strConexionMSSQL = cadenaMSSQL;
        }

        public List<InfoBiometrico> ObtenerTodasLasTerminales()
        {
            List<InfoBiometrico> infoConexion = new List<InfoBiometrico>();
            try
            {
                var sql = @"SELECT axs_idBiometrico AS IdTerminal, axs_ip AS IpTerminal, axs_puerto AS PortTerminal, axs_Descripcion AS NombreTerminal  FROM bio_Terminales WHERE axs_idEstatus = 1";

                try
                {
                    using (var connection = new MySqlConnection(strConexionMYSQL))
                    {
                        var recRevoc = connection.Query<InfoBiometrico>(
                        sql, commandType: CommandType.Text, commandTimeout: 28800).ToList();

                        infoConexion = recRevoc;
                    }
                }
                catch (MySqlException MySqlEx)
                {
                    infoConexion.Add(new InfoBiometrico { ConexionEstatus = false, ErrorMessage = MySqlEx.Message });
                }
                catch (Exception ex)
                {
                    infoConexion.Add(new InfoBiometrico { ConexionEstatus = false, ErrorMessage = ex.Message });
                }
            }
            catch (Exception ex)
            {
                infoConexion.Add(new InfoBiometrico { ConexionEstatus = false, ErrorMessage = ex.Message });
            }

            return infoConexion;
        }


        public ConfiguracionBiometrico ObtenerConfigTerminal(string ipTerminal, int puertoTerminal)
        {
            ConfiguracionBiometrico confTerminal = new ConfiguracionBiometrico();
            //string IpTerminal = ObtenerIpTerminal(IdTerminal);

            try
            {
                using (FaceId Client = new FaceId(ipTerminal, puertoTerminal))
                {
                    String answer;
                    string consulta = "GetDeviceInfo()";
                    Client.ReceiveTimeout = ConexionStrings.TIMEOUT_CONEXION_TERMINAL;
                    FaceId_ErrorCode ErrorCode = Client.Execute(consulta, out answer);
                    if (ErrorCode == FaceId_ErrorCode.Success)

                    {
                        //biometriaEmpleado = ExtraerInfoBiometria.ObtenerdatosBiometria(answer);
                        confTerminal = ExtraerDetallesTerminal.ExtraerConfigBiometrico(answer);
                        confTerminal.ConexionEstatus = true;

                    }
                    else
                    {
                        confTerminal.ConexionEstatus = false;
                    }
                }
            }
            catch (Exception ex)
            {
                confTerminal.ConexionEstatus = false;
            }
            return confTerminal;

        }


        public BaseResultado FijarFechaHoraTerminal(string ipTerminal, int puertoTerminal)

        {
            ipTerminal = HerramientasIp.ComprobarDireccionDeRed(ipTerminal);
            var resultadoActualizacion = new BaseResultado();


            try
            {
                using (FaceId Client = new FaceId(ipTerminal, puertoTerminal))
                {

                    String answer;
                    //string consulta = "SetDayTime(date=\""+DateTime.Now.ToString("yyyy-MM-dd") +"\" time=\""+ DateTime.Now.ToString("HH:mm:ss")+"\")";
                    string consulta = $"SetDateTime(date=\"{DateTime.Now.ToString("yyyy-MM-dd")}\" time=\"{DateTime.Now.ToString("HH:mm:ss")}\")";
                    Client.ReceiveTimeout = ConexionStrings.TIMEOUT_CONEXION_TERMINAL;
                    FaceId_ErrorCode ErrorCode = Client.Execute(consulta, out answer);
                    if (ErrorCode == FaceId_ErrorCode.Success)

                    {
                        //biometriaEmpleado = ExtraerInfoBiometria.ObtenerdatosBiometria(answer);
                        //confTerminal = ExtraerDetallesTerminal.ExtraerConfigBiometrico(answer);
                        resultadoActualizacion.Resultado = true;
                        resultadoActualizacion.ConexionStatus = true;


                    }
                    else
                    {
                        resultadoActualizacion.Resultado = false;
                        resultadoActualizacion.ConexionStatus = true;

                    }
                }
            }
            catch (Exception ex)
            {
                resultadoActualizacion.Resultado = false;
                resultadoActualizacion.ConexionStatus = false;
                resultadoActualizacion.ResultadoError = ex.Message;

            }
            return resultadoActualizacion;
        }



        public string ExtraerFechaHoraTerminal(string ipTerminal, int puertoTerminal)
        {
            ipTerminal = HerramientasIp.ComprobarDireccionDeRed(ipTerminal);
            string resultadoExtraerFechaHora;



            try
            {
                using (FaceId Client = new FaceId(ipTerminal, puertoTerminal))
                {
                    String answer;
                    string consulta = "GetDateTime()";
                    Client.ReceiveTimeout = ConexionStrings.TIMEOUT_CONEXION_TERMINAL;
                    FaceId_ErrorCode ErrorCode = Client.Execute(consulta, out answer);
                    if (ErrorCode == FaceId_ErrorCode.Success)

                    {
                        //biometriaEmpleado = ExtraerInfoBiometria.ObtenerdatosBiometria(answer);
                        //confTerminal = ExtraerDetallesTerminal.ExtraerConfigBiometrico(answer);
                        resultadoExtraerFechaHora = answer;

                    }
                    else
                    {
                        resultadoExtraerFechaHora = "";
                    }
                }
            }
            catch (Exception ex)
            {
                resultadoExtraerFechaHora = "";
            }
            return resultadoExtraerFechaHora;
        }


        public bool ReiniciarTerminal(string ipTerminal, int puertoTerminal)
        {
            ipTerminal = HerramientasIp.ComprobarDireccionDeRed(ipTerminal);
            bool resultadoReinicioTerminal;
            try
            {
                using (FaceId Client = new FaceId(ipTerminal, puertoTerminal))
                {
                    String answer;
                    string consulta = "RestartDevice()";
                    Client.ReceiveTimeout = ConexionStrings.TIMEOUT_CONEXION_TERMINAL;
                    FaceId_ErrorCode ErrorCode = Client.Execute(consulta, out answer);
                    if (ErrorCode == FaceId_ErrorCode.Success)

                    {
                        //biometriaEmpleado = ExtraerInfoBiometria.ObtenerdatosBiometria(answer);
                        //confTerminal = ExtraerDetallesTerminal.ExtraerConfigBiometrico(answer);
                        resultadoReinicioTerminal = true;

                    }
                    else
                    {
                        resultadoReinicioTerminal = false;
                    }
                }
            }
            catch (Exception ex)
            {
                resultadoReinicioTerminal = false;
            }
            return resultadoReinicioTerminal;
        }





        #region IDisposable Support
        bool disposedValue = false; // Para detectar llamadas redundantes
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (dtrResultado != null) { dtrResultado.Close(); dtrResultado.Dispose(); }
                    // TODO: elimine el estado administrado (objetos administrados).
                }

                // TODO: libere los recursos no administrados (objetos no administrados) y reemplace el siguiente finalizador.
                // TODO: configure los campos grandes en nulos.

                disposedValue = true;
            }
        }

        // TODO: reemplace un finalizador solo si el anterior Dispose(bool disposing) tiene código para liberar los recursos no administrados.
        // ~GestionFamiliarService()
        // {
        //   // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
        //   Dispose(false);
        // }

        // Este código se agrega para implementar correctamente el patrón descartable.
        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
            // GC.SuppressFinalize(this);
        }




        #endregion


    }
}
