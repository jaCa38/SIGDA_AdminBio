using Dapper;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using SIGDA.CA.Libreria.Punch.Models;
using SIGDA.CA.Punch.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.CA.Punch.Controllers
{
    public class PunchController: IPunchService,IDisposable
    {
        #region Constructor Variables
        DataTableReader? dtrResultado = null;
        private string strCadenaMSSQL;
        private string strCadenaMYSQL;

        public PunchController(string cadenaMSSQL, string cadenaMYSQL)
        {
            strCadenaMSSQL = cadenaMSSQL;
            strCadenaMYSQL = cadenaMYSQL;
        }
        #endregion

        public List<BasePunch> ConsultarInformacionCruda(DateTime fechaInicio, DateTime fechaFin)
        {
            List<BasePunch> lstResultado = new List<BasePunch>();

            var sql = @"SELECT pun_idReg AS IdRegistroSICA, pun_idEstatus AS IdEstatus, pun_idTerminal AS IdBiometrico, pun_idEmpleado AS IdClaveEmpleado, pun_punch_date AS FechaChecada, pun_punch_time AS HoraChecada FROM sicadb.bio_punchs_master WHERE pun_punch_date between @FechaI AND @FechaF";

            try
            {
                using (var connection = new MySqlConnection(strCadenaMYSQL))
                {
                    var recRevoc = connection.Query<BasePunch>(
                        sql,
           new { FechaI = fechaInicio, FechaF = fechaFin }, commandType: CommandType.Text
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

        public List<BasePunch> ConsultarInformacionCrudaBiometrico(DateTime fechaInicio, DateTime fechaFin, long IdBiometrico)
        {
            List<BasePunch> lstResultado = new List<BasePunch>();

            var sql = @"SELECT pun_idReg AS IdRegistroSICA, 
                                pun_idEstatus AS IdEstatus, 
                                pun_idTerminal AS IdBiometrico,
                                pun_idTerminal AS IdBiometrico,
                                (SELECT axs_descripcion FROM bio_terminales WHERE axs_idBiometrico = pun_idTerminal) AS DescripcionBiometrico, 
                                pun_idEmpleado AS IdClaveEmpleado, 
                                pun_punch_date AS FechaChecada,
                                pun_punch_time AS HoraChecada 
                                FROM sicadb.bio_punchs_master 
                                WHERE pun_punch_date between @FechaI AND @FechaF AND pun_idTerminal = @TerminalId";

            try
            {
                using (var connection = new MySqlConnection(strCadenaMYSQL))
                {
                    var recRevoc = connection.Query<BasePunch>(
                        sql,
           new { FechaI = fechaInicio, FechaF = fechaFin, @TerminalId = IdBiometrico }, commandType: CommandType.Text
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
        public List<BasePunch> ConsultarInformacionCrudaEmpleado(DateTime fechaInicio, DateTime fechaFin, long IdEmpleado)
        {

            

            List<BasePunch> lstResultado = new List<BasePunch>();

            var sql = @"SELECT pun_idReg AS IdRegistroSICA, 
                                pun_idEstatus AS IdEstatus, 
                                pun_idTerminal AS IdBiometrico,
                                (SELECT axs_descripcion FROM bio_terminales WHERE axs_idBiometrico = pun_idTerminal) AS DescripcionBiometrico,
                                pun_idEmpleado AS IdClaveEmpleado,
                                pun_punch_date AS FechaChecada, 
                                pun_punch_time AS HoraChecada FROM sicadb.bio_punchs_master WHERE pun_punch_date between @FechaI AND  @FechaF AND pun_idEmpleado = @EmpleadoId";

            try
            {
                using (var connection = new MySqlConnection(strCadenaMYSQL))
                {
                    var recRevoc = connection.Query<BasePunch>(
                        sql,
           new { FechaI = fechaInicio.ToString("yyyy-MM-dd"), FechaF = fechaFin.ToString("yyyy-MM-dd"), EmpleadoId = IdEmpleado }, commandType: CommandType.Text
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

        public bool InsertarInformacionCruda(List<BasePunch> registros)
        {

            var sql = @"INSERT INTO [biometrico].[INFORMACION.BRUTO](inbr_idRegistro,inbr_idEmpleado,inbr_idBiometrico,inbr_fechaChecada,inbr_horaChecada,inbr_fechaSubida,inbr_idEstatus,inbr_borrado) VALUES(@IdRegistroSICA,@IdClaveEmpleado,@IdBiometrico,@FechaChecada,@HoraChecada,GETDATE(),@IdEstatus,1);";

            try
            {
                using (var connection = new SqlConnection(strCadenaMSSQL))
                {
                    var rowsAffected = connection.Execute(sql, registros);
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
