using Dapper;
using MySql.Data.MySqlClient;
using SIGDA.CA.Biometricos.Libreria.Models;
using SIGDA.CA.Biometricos.Libreria.Services;
using SIGDA.CA.Biometricos.Libreria.Tools;
using Splash;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SIGDA.CA.Biometricos.Libreria.Controllers
{
    public class DescargaInfoBiometricosController : AdministracionBaseController, IDescargaInfoBiometricos, IDisposable
    {

        private string strConexionMYSQL;
        private string strConexionMSSQL;
        DataTableReader dtrResultado = null;

        public DescargaInfoBiometricosController(string cadenaMysql, string cadenaMSSQL) : base(cadenaMysql, cadenaMSSQL)
        {
            strConexionMYSQL = cadenaMysql;
            strConexionMSSQL = cadenaMSSQL;
        }

        InfoBiometrico infoBiometrico = new InfoBiometrico();


        public bool InsertarRegistrosSICA(int idTerminal, int idEmpleado, DateTime record)
        {

            var sql = @"sp_insertar_registros";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idEmpleado", idEmpleado);
            dpParametros.Add("@idTerminal", idTerminal);
            dpParametros.Add("@fecha", record.ToString("yyyy-MM-dd"));
            dpParametros.Add("@hora", record.ToString("HH:mm:ss"));

            try
            {
                using (var connection = new MySqlConnection(strConexionMYSQL))
                {
                    var recRevoc = connection.Execute(sql, dpParametros, commandType: CommandType.StoredProcedure, commandTimeout: 2000);
                    return true;
                }
            }
            catch (MySqlException MySqlEx)
            {
                //string MensajeError = "ERROR : " + MySqlEx.Message + ".";
                //throw new Exception(MensajeError, MySqlEx);
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }





        public bool InsertarRegistrosMSSQL(int idTerminal, int idEmpleado, DateTime record)
        {
            try
            {
                var sql = @"[biometrico].[pa_Registros_Almacena]";
                var dpParametros = new DynamicParameters();
                dpParametros.Add("@idTerminal", idTerminal);
                dpParametros.Add("@idEmpleado", idEmpleado);
                dpParametros.Add("@fecha", record.ToString("yyyy-MM-dd"));
                dpParametros.Add("@hora", record.ToString("HH:mm:ss"));

                try
                {
                    using (var connection = new SqlConnection(strConexionMSSQL))
                    {
                        var recRevoc = connection.Execute(sql, dpParametros, commandType: CommandType.StoredProcedure, commandTimeout: 2000);
                        return true;

                    }
                }
                catch (MySqlException MySqlEx)
                {
                    string MensajeError = "ERROR : " + MySqlEx.Message + ".";
                    throw new Exception(MensajeError, MySqlEx);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public bool InsertarLogErrorDescargaMSSQL(int idTerminal, int tipoEvento, DateTime fechaDescarga, string msjError)
        {
            try
            {
                var sql = @"[biometrico].[pa_Log_Almacena_Error]";
                var dpParametros = new DynamicParameters();
                dpParametros.Add("@idTerminal", idTerminal);
                dpParametros.Add("@tipoTarea", tipoEvento);
                dpParametros.Add("@fechaDescargar", fechaDescarga);
                dpParametros.Add("@msjError", msjError);

                try
                {
                    using (var connection = new SqlConnection(strConexionMSSQL))
                    {
                        var recRevoc = connection.Execute(sql, dpParametros, commandType: CommandType.StoredProcedure, commandTimeout: 2000);
                        return true;

                    }
                }
                catch (MySqlException MySqlEx)
                {
                    string MensajeError = "ERROR : " + MySqlEx.Message + ".";
                    throw new Exception(MensajeError, MySqlEx);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public bool InsertarLogDescargaRegistrosMSSQL(int IdTerminal, DateTime FechaDescarga, int CantidadRegistros)
        {
            try
            {
                var sql = @"[biometrico].[pa_log_Almacena]";
                var dpParametros = new DynamicParameters();
                dpParametros.Add("@idTerminal", IdTerminal);
                dpParametros.Add("@fechaRegistros", FechaDescarga);
                dpParametros.Add("@cantidadRegistros", CantidadRegistros);


                try
                {
                    using (var connection = new SqlConnection(strConexionMSSQL))
                    {
                        var recRevoc = connection.Execute(sql, dpParametros, commandType: CommandType.StoredProcedure, commandTimeout: 2500);
                        return true;

                    }
                }
                catch (MySqlException MySqlEx)
                {
                    string MensajeError = "ERROR : " + MySqlEx.Message + ".";
                    throw new Exception(MensajeError, MySqlEx);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public List<RegistrosRelojes> ObtenerRegistrosTerminalPorRangoFechas(string ipTerminal, int puertoTerminal, DateTime fechaInicio, DateTime fechaFin)
        {
            List<RegistrosRelojes> registrosTerminal = new List<RegistrosRelojes>();

            try
            {
                using (FaceId Client = new FaceId(ipTerminal, puertoTerminal))
                {
                    string answer;
                    var fechaInicioCeroHoras = fechaInicio.Date;
                    string consulta = "GetRecord(start_time=\"" + fechaInicioCeroHoras.ToString("yyyy-MM-dd HH:mm:ss") + "\"end_time=\"" + fechaFin.ToString("yyyy-MM-dd HH:mm:ss") + "\")";
                    Client.ReceiveTimeout = 30000;
                    FaceId_ErrorCode ErrorCode = Client.Execute(consulta, out answer);
                    if (ErrorCode == FaceId_ErrorCode.Success)

                    {

                        registrosTerminal = FormatoInfoTerminales.FormatoRegistrosTerminal(answer);

                    }
                }
            }

            catch (Exception ex)
            {
                registrosTerminal.Add(new RegistrosRelojes { ConexionReloj = false, ErrorMsj = ex.Message });
            }
            return registrosTerminal;
        }


        #region IDisposable Support
        bool disposedValue = false; // Para detectar llamadas redundantes
        protected new void Dispose(bool disposing)
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
        public new void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
            // GC.SuppressFinalize(this);
        }


        #endregion








    }
}
