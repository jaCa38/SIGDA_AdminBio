using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using SIGDA.CA.Libreria.Turno.Models;
using SIGDA.CA.Libreria.Turno.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.CA.Libreria.Turno.Controllers
{
    public class TurnoSICAController: ITurnoSICAService, IDisposable
    {
        #region Constructor Variables
        DataTableReader? dtrResultado = null;
        private string strCadenaMSSQL;
        private string strCadenaMYSQL;

        public TurnoSICAController(string cadenaMSSQL, string cadenaMYSQL)
        {
            strCadenaMSSQL = cadenaMSSQL;
            strCadenaMYSQL = cadenaMYSQL;
        }
        #endregion

        public List<ConfigTurnoSICA> ConsultarConfiguracionTurnadoEmpleado()
        {
            List<ConfigTurnoSICA> lstResultado = new List<ConfigTurnoSICA>();

            var sql = @"SELECT tur_idReg IdentificadorSICA, tur_idEmpleado AS IdClaveEmpleado, (tur_dia1 - 100) AS IdTurnoDia1, (tur_dia2 - 100) AS IdTurnoDia2,(tur_dia3 - 100) AS IdTurnoDia3,(tur_dia4 - 100) AS IdTurnoDia4,(tur_dia5 - 100) AS IdTurnoDia5,(tur_dia6 - 100) AS IdTurnoDia6,(tur_dia7 - 100) AS IdTurnoDia7,tur_des1 AS DescansoDia1,tur_des2 AS DescansoDia2,tur_des3 AS DescansoDia3,tur_des4 AS DescansoDia4,tur_des5 AS DescansoDia5,tur_des6 AS DescansoDia6,tur_des7 AS DescansoDia7,IFNULL(tur_inicio,'1900-01-01') AS FechaInicio,IFNULL(tur_fin,'1900-01-01') AS FechaFin FROM sicadb.bio_empleados_tur WHERE tur_estatus_turno = 1;";

            try
            {
                using (var connection = new MySqlConnection(strCadenaMYSQL))
                {
                    var recRevoc = connection.Query<ConfigTurnoSICA>(
                        sql,null, commandType: CommandType.Text
           , commandTimeout: 28800
           ).ToList();
                    lstResultado = recRevoc;
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

            return lstResultado;
        }

        public bool InsertarConfiguracionTurnadoEmpleado(List<ConfigTurnoSICA> configTurnos)
        {
            var sql = @"INSERT INTO [asistencia].[TURNO.CONFIGURACION_SICA]([tcsi_idReg_SICA],[tcsi_idEmpleado],[tcsi_catu_dia1],[tcsi_catu_dia2],[tcsi_catu_dia3],[tcsi_catu_dia4],[tcsi_catu_dia5],[tcsi_catu_dia6],[tcsi_catu_dia7],[tcsi_descanso_dia1],[tcsi_descanso_dia2],[tcsi_descanso_dia3],[tcsi_descanso_dia4],[tcsi_descanso_dia5],[tcsi_descanso_dia6],[tcsi_descanso_dia7],[tcsi_fechaInicio],[tcsi_fechaFin],[tcsi_borrado])VALUES(@IdentificadorSICA,@IdClaveEmpleado,@IdTurnoDia1,@IdTurnoDia2,@IdTurnoDia3,@IdTurnoDia4,@IdTurnoDia5,@IdTurnoDia6,@IdTurnoDia7,@DescansoDia1,@DescansoDia2,@DescansoDia3,@DescansoDia4,@DescansoDia5,@DescansoDia6,@DescansoDia7,@FechaInicio,@FechaFin,0)";


            try
            {
                using (var connection = new SqlConnection(strCadenaMSSQL))
                {
                    var rowsAffected = connection.Execute(sql, configTurnos);
                }
            }
            catch (SqlException SqlEx)
            {
                string MensajeError = "ERROR : " + SqlEx.Message + ".";
                throw new Exception(MensajeError, SqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return true;
        }

        public bool ActualizarTurnosFijos()
        {
            var sql = @"UPDATE [asistencia].[TURNO.CONFIGURACION_SICA] SET tcsi_tipo = 1 WHERE tcsi_catu_dia1 =  tcsi_catu_dia2 and tcsi_catu_dia1 =  tcsi_catu_dia3 and tcsi_catu_dia1 =  tcsi_catu_dia4 and tcsi_catu_dia1 =  tcsi_catu_dia5 and tcsi_catu_dia1 =  tcsi_catu_dia6 and tcsi_catu_dia1 =  tcsi_catu_dia7 and convert(date,tcsi_fechaInicio) = convert(date,'1900-01-01') and  tcsi_descanso_dia6 = 0 and tcsi_descanso_dia7=0";


            try
            {
                using (var connection = new SqlConnection(strCadenaMSSQL))
                {
                    var rowsAffected = connection.Execute(sql);
                }
            }
            catch (SqlException SqlEx)
            {
                string MensajeError = "ERROR : " + SqlEx.Message + ".";
                throw new Exception(MensajeError, SqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return true;
        }
        public bool ActualizarTurnosVariables()
        {
            var sql = @"UPDATE [asistencia].[TURNO.CONFIGURACION_SICA] SET tcsi_tipo = 2 WHERE tcsi_tipo IS NULL";

            try
            {
                using (var connection = new SqlConnection(strCadenaMSSQL))
                {
                    var rowsAffected = connection.Execute(sql);
                }
            }
            catch (SqlException SqlEx)
            {
                string MensajeError = "ERROR : " + SqlEx.Message + ".";
                throw new Exception(MensajeError, SqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return true;
        }
        #region Private

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
