using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Logging;
using SIGDA.CA.Libreria.Turno.Interfaces;
using SIGDA.CA.Libreria.Turno.Models;
using SIGDA.CA.Libreria.Turno.Services.Interfaces;
using SIGDA.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.CA.Libreria.Turno.Controllers
{
    public class TurnoController : ITipoTurnoService, IConfigTurnoService, ITurnoEmpleado, IDisposable
    {
        #region Constructor Variables
        DataTableReader? dtrResultado = null;
        private string strCadenaMSSQL;

        public TurnoController(string cadenaMSSQL)
        {
            strCadenaMSSQL = cadenaMSSQL;
        }
        #endregion

        #region CATALOGOS.TURNOS
        public List<TipoTurnoBase> ConsultarCatalogoTiposTurno()
        {
            List<TipoTurnoBase> lstResultado = new List<TipoTurnoBase>();

            var sql = @"[asistencia].[pa_Catalogo_Turnos_Consultar]";
            var dpParametros = new DynamicParameters();

            try
            {
                using (var connection = new SqlConnection(strCadenaMSSQL))
                {
                    var recRevoc = connection.Query<TipoTurnoBase>(
                        sql,
           dpParametros, commandType: CommandType.StoredProcedure
           //, splitOn: "IdentificadorElementoIndice"
           , commandTimeout: 2000
           ).ToList();
                    lstResultado = recRevoc.OrderBy(x => x.DescripcionCatalogoTurno).ToList();
                }
            }
            catch (SqlException SqlEx)
            {
                string MensajeError = "ERROR : " + SqlEx.Message + ". " + "LINEA : " + SqlEx.LineNumber + ".";
                throw new Exception(MensajeError, SqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return lstResultado;
        }
        #endregion

        #region CONFIGURACION.TURNO
        public List<ConfigTurno> ConsultarConfiguracionTurnos()
        {
            List<ConfigTurno> lstResultado = new List<ConfigTurno>();

            var sql = @"[asistencia].[pa_Configuracion_Turnos_Consultar]";
            var dpParametros = new DynamicParameters();

            try
            {
                using (var connection = new SqlConnection(strCadenaMSSQL))
                {
                    var recRevoc = connection.Query<ConfigTurno>(
                        sql,
           dpParametros, commandType: CommandType.StoredProcedure
           //, splitOn: "IdentificadorElementoIndice"
           , commandTimeout: 2000
           ).ToList();
                    lstResultado = recRevoc.OrderBy(x => x.IdConfigTurno).ToList();
                }
            }
            catch (SqlException SqlEx)
            {
                string MensajeError = "ERROR : " + SqlEx.Message + ". " + "LINEA : " + SqlEx.LineNumber + ".";
                throw new Exception(MensajeError, SqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return lstResultado;
        }

        public long InsertarConfiguracionTurnos(ConfigTurnoBase configTurnoBase)
        {
            var sql = @"[asistencia].[pa_Configuracion_Turnos_Almacenar] ";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@DescripcionCatalogoTurno", configTurnoBase.DescripcionCatalogoTurno);
            dpParametros.Add("@HoraEntrada", configTurnoBase.HoraEntrada);
            dpParametros.Add("@HoraSalida", configTurnoBase.HoraSalida);

            try
            {
                using (var connection = new SqlConnection(strCadenaMSSQL))
                {
                    var longRespuesta = connection.QueryFirst<long>(sql, dpParametros, commandType: CommandType.StoredProcedure, commandTimeout: 2000);

                    return longRespuesta;
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
        }
        #endregion

        #region Turno Empleado Fijo
        public TurnoEmpleadoFijo ConsultarTurnoEmpleadoFijo(long IdEmpleado)
        {
            List<TurnoEmpleadoFijo> lstResultado = new List<TurnoEmpleadoFijo>();

            var sql = @"[asistencia].[pa_Turno_Fijo_Empleado_Consultar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@IdEmpleado", IdEmpleado);

            try
            {
                using (var connection = new SqlConnection(strCadenaMSSQL))
                {
                    var recRevoc = connection.Query<TurnoEmpleadoFijo>(
                        sql,
           dpParametros, commandType: CommandType.StoredProcedure
           //, splitOn: "IdentificadorElementoIndice"
           , commandTimeout: 2000
           ).ToList();
                    lstResultado = recRevoc.ToList();
                }
            }
            catch (SqlException SqlEx)
            {
                string MensajeError = "ERROR : " + SqlEx.Message + ". " + "LINEA : " + SqlEx.LineNumber + ".";
                throw new Exception(MensajeError, SqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return lstResultado.First();
        }

        public long InsertarTurnoEmpleadoFijo(TurnoEmpleadoFijo Fijo)
        {
            var sql = @"[asistencia].[pa_Turno_Fijo_Empleado_Almacenar] ";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@IdEmpleado", Fijo.IdEmpleado);
            dpParametros.Add("@FechaInicio", Fijo.FechaInicio);
            dpParametros.Add("@FechaFin", Fijo.FechaFin);
            dpParametros.Add("@IdCatalogoTurno", Fijo.IdCatalogoTurno);

            try
            {
                using (var connection = new SqlConnection(strCadenaMSSQL))
                {
                    var longRespuesta = connection.QueryFirst<long>(sql, dpParametros, commandType: CommandType.StoredProcedure, commandTimeout: 2000);

                    return longRespuesta;
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
        }

        public bool EliminarTurnoEmpleadoFijo(long IdEmpleado)
        {
            var sql = @"[asistencia].[pa_Turno_Fijo_Empleado_Eliminar] ";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@IdEmpleado", IdEmpleado);

            try
            {
                using (var connection = new SqlConnection(strCadenaMSSQL))
                {
                    var rowsAf = connection.Execute(sql, dpParametros, commandType: CommandType.StoredProcedure, commandTimeout: 2000);
                    return true;
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
           
        }

        public List<TurnoEmpleadoFijo> ConsultarHistoricoTurnoEmpleadoFijo(long IdEmpleado)
        {
            List<TurnoEmpleadoFijo> lstResultado = new List<TurnoEmpleadoFijo>();

            var sql = @"[asistencia].[pa_Turno_Fijo_Empleado_Consultar_Historicos]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@IdEmpleado", IdEmpleado);

            try
            {
                using (var connection = new SqlConnection(strCadenaMSSQL))
                {
                    var recRevoc = connection.Query<TurnoEmpleadoFijo>(
                        sql,
           dpParametros, commandType: CommandType.StoredProcedure
           //, splitOn: "IdentificadorElementoIndice"
           , commandTimeout: 2000
           ).ToList();
                    lstResultado = recRevoc.OrderBy(x => x.FechaInicio).ToList();
                }
            }
            catch (SqlException SqlEx)
            {
                string MensajeError = "ERROR : " + SqlEx.Message + ". " + "LINEA : " + SqlEx.LineNumber + ".";
                throw new Exception(MensajeError, SqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return lstResultado;
        }
        #endregion

        #region Turno Empleado Variable
        public TurnoEmpleadoVariableDetalle ConsultarTurnoEmpleadoVariable(long IdEmpleado)
        {
            List<TurnoEmpleadoVariableDetalle> lstResultado = new List<TurnoEmpleadoVariableDetalle>();

            var sql = @"[asistencia].[pa_Turno_Variable_Empleado_Consultar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@IdEmpleado", IdEmpleado);

            try
            {
                using (var connection = new SqlConnection(strCadenaMSSQL))
                {
                    var recRevoc = connection.Query<TurnoEmpleadoVariableDetalle>(
                        sql,
           dpParametros, commandType: CommandType.StoredProcedure
           //, splitOn: "IdCatalogoTurno"
           , commandTimeout: 2000
           ).ToList();
                    lstResultado = recRevoc.ToList();
                }
            }
            catch (SqlException SqlEx)
            {
                string MensajeError = "ERROR : " + SqlEx.Message + ". " + "LINEA : " + SqlEx.LineNumber + ".";
                throw new Exception(MensajeError, SqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return lstResultado.First();
        }

        public long InsertarTurnoEmpleadoVariable(TurnoEmpleadoVariable Variable)
        {
            var sql = @"[asistencia].[pa_Turno_Variable_Empleado_Almacenar] ";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@IdEmpleado", Variable.IdEmpleado);
            dpParametros.Add("@FechaInicio", Variable.FechaInicio);
            dpParametros.Add("@FechaFin", Variable.FechaFin);
            dpParametros.Add("@TurnoDiaDomingo", Variable.TurnoDiaDomingo.IdCatalogoTurno);
            dpParametros.Add("@TurnoDiaLunes", Variable.TurnoDiaLunes.IdCatalogoTurno);
            dpParametros.Add("@TurnoDiaMartes", Variable.TurnoDiaMartes.IdCatalogoTurno);
            dpParametros.Add("@TurnoDiaMiercoles", Variable.TurnoDiaMiercoles.IdCatalogoTurno);
            dpParametros.Add("@TurnoDiaJueves", Variable.TurnoDiaJueves.IdCatalogoTurno);
            dpParametros.Add("@TurnoDiaViernes", Variable.TurnoDiaViernes.IdCatalogoTurno);
            dpParametros.Add("@TurnoDiaSabado", Variable.TurnoDiaSabado.IdCatalogoTurno);

            try
            {
                using (var connection = new SqlConnection(strCadenaMSSQL))
                {
                    var longRespuesta = connection.QueryFirst<long>(sql, dpParametros, commandType: CommandType.StoredProcedure, commandTimeout: 2000);

                    return longRespuesta;
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
        }

        public bool EliminarTurnoEmpleadoVariable(long IdEmpleado)
        {
            var sql = @"[asistencia].[pa_Turno_Variable_Empleado_Eliminar] ";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@IdEmpleado", IdEmpleado);

            try
            {
                using (var connection = new SqlConnection(strCadenaMSSQL))
                {
                    var rowsAf = connection.Execute(sql, dpParametros, commandType: CommandType.StoredProcedure, commandTimeout: 2000);
                    return true;
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
        }

        public List<TurnoEmpleadoVariableDetalle> ConsultarHistoricoTurnoEmpleadoVariable(long IdEmpleado)
        {
            List<TurnoEmpleadoVariableDetalle> lstResultado = new List<TurnoEmpleadoVariableDetalle>();

            var sql = @"[asistencia].[pa_Turno_Variable_Empleado_Consultar_Historicos]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@IdEmpleado", IdEmpleado);

            try
            {
                using (var connection = new SqlConnection(strCadenaMSSQL))
                {
                    var recRevoc = connection.Query<TurnoEmpleadoVariableDetalle>(
                        sql,
           dpParametros, commandType: CommandType.StoredProcedure
           //, splitOn: "IdentificadorElementoIndice"
           , commandTimeout: 2000
           ).ToList();
                    lstResultado = recRevoc.OrderBy(x => x.FechaInicio).ToList();
                }
            }
            catch (SqlException SqlEx)
            {
                string MensajeError = "ERROR : " + SqlEx.Message + ". " + "LINEA : " + SqlEx.LineNumber + ".";
                throw new Exception(MensajeError, SqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return lstResultado;
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
