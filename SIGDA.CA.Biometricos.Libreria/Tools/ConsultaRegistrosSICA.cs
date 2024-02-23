using Dapper;
using MySql.Data.MySqlClient;
using SIGDA.CA.Biometricos.Libreria.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SIGDA.CA.Biometricos.Libreria.Tools
{
    public class ConsultaRegistrosSICA: IDisposable
    {
        private string strConexionMYSQL;
        private string strConexionMSSQL;
        DataTableReader dtrResultado = null;

        public ConsultaRegistrosSICA(string cadenaMysql, string cadenaMSSQL)
        {

            strConexionMYSQL = cadenaMysql;
            strConexionMSSQL = cadenaMSSQL;
        }

        public   List<RegistrosEmpleadoSICA> GenerarReporteSICA(int IdEmpleado, DateTime fechaNomInicio, DateTime fechaFinNom)
        {

            var registrosEmpleados = new List<RegistrosEmpleadoSICA>();
            try
            {
                //var sql = @"sp_empleado_registros_procesados";
                var sql = @"sp_registro_empleado";
                var dpParametros = new DynamicParameters();
                dpParametros.Add("@idEmpleado", IdEmpleado);
                dpParametros.Add("@fechaInicio", fechaNomInicio.ToString("yyyy-MM-dd"));
                dpParametros.Add("@fechaFin", fechaFinNom.ToString("yyyy-MM-dd"));


                try
                {
                    using (MySqlConnection connection = new MySqlConnection(strConexionMYSQL))
                    {
                        var recRevoc =  connection.Query<RegistrosEmpleadoSICA>(sql, dpParametros,
                            commandType: CommandType.StoredProcedure, commandTimeout: 28800).ToList();
                        

                        registrosEmpleados= recRevoc;
                        
                        return registrosEmpleados;

                    }

                }
                catch (MySqlException MySqlEx)
                {
                    string MensajeError = "ERROR : " + MySqlEx.Message + ".";
                    throw new Exception(MensajeError, MySqlEx);
                }
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            

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
        public virtual void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
            // GC.SuppressFinalize(this);
        }


        #endregion


    }
}
