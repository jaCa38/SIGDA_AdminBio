using Dapper;
using SIGDA.Consejo.Libreria.Models;
using SIGDA.Consejo.Libreria.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace SIGDA.Consejo.Libreria.Controllers
{
    public class ConsejoController: IGestionConsejoService, IDisposable
    {
        private readonly long IdUsuarioRH = 4825;
        long _IdMinerva = 0;

        #region Constructor Variables
        DataTableReader? dtrResultado = null;
        private string strCadenaMSSQL;
        private string strCadenaRH;

        public ConsejoController(string cadenaMSSQL, long idMinerva)
        {
            strCadenaMSSQL = cadenaMSSQL;
            _IdMinerva = idMinerva;
         }

        public ConsejoController(string cadenaMSSQL, string CadenaRH, long idMinerva)
        {
            strCadenaMSSQL = cadenaMSSQL;
            strCadenaRH = CadenaRH;
            _IdMinerva = idMinerva;
        }
        #endregion

        public List<SolicitudBase> ConsultarSolicitudes(long FolioConsejo)
        {
            List<SolicitudBase> lstResultado = new List<SolicitudBase>();

            var sql = @"[dbo].[promociones.ObtenerPorIdentificadorRH]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@prom_identificador", FolioConsejo);
            try
            {
                using (var connection = new SqlConnection(strCadenaMSSQL))
                {
                    var recRevoc = connection.Query<SolicitudBase>(
                        sql,
           dpParametros, commandType: CommandType.StoredProcedure
           //, splitOn: "IdentificadorElementoIndice"
           , commandTimeout: 2000
           ).ToList();
                    lstResultado = recRevoc.OrderBy(x => x.prom_Identificador).ToList();
                }

                LiberarBloqueos();
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
        public DetallePrecalificacion ConsultarDetallePrecalificacion(long FolioConsejo)
        {
            DetallePrecalificacion Resultado = new DetallePrecalificacion();

            var sql = @"[dbo].[promociones.ObtenerPrecalificacion]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@identificador_promocion", FolioConsejo);
            dpParametros.Add("@tipo_precalificacion", 1);
            try
            {
                using (var connection = new SqlConnection(strCadenaMSSQL))
                {
                    var recRevoc = connection.Query<DetallePrecalificacion>(
                        sql,
           dpParametros, commandType: CommandType.StoredProcedure
           //, splitOn: "IdentificadorElementoIndice"
           , commandTimeout: 2000
           ).ToList();
                    Resultado = recRevoc.First(x => x.prpc_identificador_promocion == FolioConsejo);
                }

                LiberarBloqueos();
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

            return Resultado;
        }
        public DetalleFolioConsejo ConsultarDetalleFolioConsejo(long FolioConsejo)
        {
            DetalleFolioConsejo Resultado = new DetalleFolioConsejo();

            var sql = @"[dbo].[promociones.ObtenerDetallesRH]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@Folio", FolioConsejo);
            try
            {
                using (var connection = new SqlConnection(strCadenaMSSQL))
                {
                    var recRevoc = connection.Query<DetalleFolioConsejo>(
                        sql,
           dpParametros, commandType: CommandType.StoredProcedure
           //, splitOn: "IdentificadorElementoIndice"
           , commandTimeout: 2000
           ).ToList();
                    Resultado = recRevoc.First();
                }

                LiberarBloqueos();
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

            return Resultado;
        }
        public List<DetallePersonajes> ConsultarDetallePersonajes(long FolioConsejo)
        {
            List<DetallePersonajes> lstResultado = new List<DetallePersonajes>();

            var sql = @"[dbo].[promociones.ObtenerPersonajes]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@identificador_promocion", FolioConsejo);
            try
            {
                using (var connection = new SqlConnection(strCadenaMSSQL))
                {
                    var recRevoc = connection.Query<DetallePersonajes>(
                        sql,
           dpParametros, commandType: CommandType.StoredProcedure
           //, splitOn: "IdentificadorElementoIndice"
           , commandTimeout: 2000
           ).ToList();
                    lstResultado = recRevoc.OrderBy(x => x.prpe_identificador).ToList();
                }

                LiberarBloqueos();
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
        public bool ContestarConsejoNuevoEmpleado(ContestacionFolioConsejo contestacionFolioConsejo)
        {
            bool respuesta = false;
            var sql = @"[dbo].[generales.GuardarPromocionesPrecalificaciones]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@prpc_identificador", 0);
            dpParametros.Add("@prpc_identificador_promocion", contestacionFolioConsejo.IdentificadorPromocion);
            dpParametros.Add("@prpc_tipo_precalificacion", 1);
            dpParametros.Add("@prpc_case_identificador", 100);
            dpParametros.Add("@prpc_genera_instruccion", 0);
            dpParametros.Add("@prpc_observaciones", contestacionFolioConsejo.ObservacionesPromocion);
            dpParametros.Add("@prpc_fecha_captura", DateTime.Now);
            dpParametros.Add("@prpc_estatus", 1);
            dpParametros.Add("@IdentificadorUsuario", IdUsuarioRH);


            try
            {
                using (var connection = new SqlConnection(strCadenaMSSQL))
                {
                    var IdPrecalificacion = connection.QueryFirst<long>(sql, dpParametros, commandType: CommandType.StoredProcedure, commandTimeout: 2000);

                    if (IdPrecalificacion > 0)
                    {
                        contestacionFolioConsejo.IdentificadorPrecalificacion = IdPrecalificacion;

                        if (GuardarPrecalificacionConsejo(contestacionFolioConsejo.IdentificadorPromocion))
                        if (InsertarFolioConsejo(contestacionFolioConsejo))
                                respuesta = true;
                    }
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
            finally
            {
                LiberarBloqueos();
            }

            return respuesta;
        }



        #region Private
        void LiberarBloqueos()
        {
            var sql = @"[dbo].[generales.LiberarBloqueosPorUsuario]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@identificador_usuario", IdUsuarioRH);
            dpParametros.Add("@timo_elemento", 2);
            try
            {
                using (var connection = new SqlConnection(strCadenaMSSQL))
                {
                    var rowsAf = connection.Execute(sql, dpParametros, commandType: CommandType.StoredProcedure, commandTimeout: 2000);
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
        }
        Boolean InsertarFolioConsejo(ContestacionFolioConsejo contestacionFolioConsejo)
        {
            var sql = @"[consejo].[pa_FolioConsejo_Almacena]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@IdFolioConsejo", contestacionFolioConsejo.IdentificadorPromocion);
            dpParametros.Add("@IdPrecalificacion", contestacionFolioConsejo.IdentificadorPrecalificacion);
            dpParametros.Add("@IdMinerva", _IdMinerva);
            dpParametros.Add("@nombramientos_json", JsonConvert.SerializeObject(contestacionFolioConsejo.Nombramientos));

            try
            {
                using (var connection = new SqlConnection(strCadenaRH))
                {
                    var rowsAffected = connection.Execute(sql, dpParametros, commandType: CommandType.StoredProcedure, commandTimeout: 2000);
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
        bool GuardarPrecalificacionConsejo(long FolioConsejo)
        {
            bool respuesta = false;
            var sql = @"[dbo].[generales.GuardarPromocionesAdministracion]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@prom_identificador", FolioConsejo);
            dpParametros.Add("@prom_precalificacion_rh", 3);
            dpParametros.Add("@prom_vobo_rh", 3);
            dpParametros.Add("@IdentificadorUsuario", IdUsuarioRH);

            try
            {
                using (var connection = new SqlConnection(strCadenaMSSQL))
                {
                    var Identificador = connection.QueryFirst<long>(sql, dpParametros, commandType: CommandType.StoredProcedure, commandTimeout: 2000);

                    if (Identificador > 0)
                        return true;
                    else return false;
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
