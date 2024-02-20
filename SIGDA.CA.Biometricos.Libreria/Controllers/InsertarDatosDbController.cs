using Dapper;
using MySql.Data.MySqlClient;
using SIGDA.CA.Biometricos.Libreria.Services.Interfaces;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SIGDA.CA.Biometricos.Libreria
{
    public class InsertarDatosDbController : IInsertarDatosDb, IDisposable
    {

        private string strConexionMYSQL;
        private string strConexionMSSQL;
        DataTableReader dtrResultado = null;

        public InsertarDatosDbController(string cadenaMysql, string cadenaMSSQL)
        {
            strConexionMYSQL = cadenaMysql;
            strConexionMSSQL = cadenaMSSQL;
        }


        #region Insertar registros en SICA_MYSQL
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



        #endregion


        #region Insertar Datos SQLSERVER_SIGDA
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



        public bool InsertarLogDescargaFotosMSSQL(int idTerminal, DateTime fechaDescarga, int cantidadFotos, int CantidadRegistros)
        {
            try
            {
                var sql = @"[biometrico].[pa_Log_Fotos_Descarga]";
                var dpParametros = new DynamicParameters();
                dpParametros.Add("@idTerminal", idTerminal);
                dpParametros.Add("@fechaFotos", fechaDescarga);
                dpParametros.Add("@cantidadFotografias", cantidadFotos);
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


        public bool InsertarBiometriaDBMSSQL(int idEmpleado, int idTerminal, string bioPlantilla)
        {
            try
            {

                var convercionVarbinary = Encoding.UTF8.GetBytes(bioPlantilla);
                var sql = @"[biometrico].[pa_Biometria_Almacena]";
                var dpParametros = new DynamicParameters();
                dpParametros.Add("@idEmpleado", idEmpleado);
                dpParametros.Add("@idTerminal", idTerminal);
                dpParametros.Add("@template", convercionVarbinary);


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




        #endregion

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
