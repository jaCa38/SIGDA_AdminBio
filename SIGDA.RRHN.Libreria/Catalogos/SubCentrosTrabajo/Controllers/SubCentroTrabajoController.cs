using Dapper;
using SIGDA.SRHN.Libreria.Catalogos.Genericos.Enums;
using SIGDA.SRHN.Libreria.Catalogos.SubCentrosTrabajo.Models;
using SIGDA.SRHN.Libreria.Catalogos.SubCentrosTrabajo.Services.Interfaces;
using SIGDA.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Catalogos.SubCentrosTrabajo.Controllers
{
    public class SubCentroTrabajoController : ISubCentroTrabajoService, IDisposable
    {
        #region Constructor Variables
        DataTableReader? dtrResultado = null;
        private string? _cadenaConexion;

        public SubCentroTrabajoController(string cadena)
        {
            _cadenaConexion = cadena;
        }
        #endregion

        public List<SubCentroTrabajoBase> ConsultarCatalogoGenerico()
        {
            List<SubCentroTrabajoBase> lstResultado = new List<SubCentroTrabajoBase>();

            var sql = @"[catalogo].[pa_SubCentroTrabajo_Consultar]";
            var dpParametros = new DynamicParameters();

            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<SubCentroTrabajoBase>(
                        sql,
           dpParametros, commandType: CommandType.StoredProcedure
           //, splitOn: "IdentificadorElementoIndice"
           , commandTimeout: 2000
           ).ToList();
                    lstResultado = recRevoc;
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

        public List<SubCentroTrabajoBase> ConsultarCatalogoGenerico(EDivision division, EInstancia instancia, long IdSistema, long IdMunicipio, long IdCentroTrabajo)
        {
            List<SubCentroTrabajoBase> lstResultado = new List<SubCentroTrabajoBase>();

            var sql = @"[catalogo].[pa_SubCentroTrabajo_Consultar]";
            var dpParametros = new DynamicParameters();

            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<SubCentroTrabajoBase>(
                        sql,
           dpParametros, commandType: CommandType.StoredProcedure
           //, splitOn: "IdentificadorElementoIndice"
           , commandTimeout: 2000
           ).ToList();
                    //lstResultado = recRevoc.Where() .FindAll(x => x.IdMunicipio == IdMunicipio );
                    lstResultado = recRevoc.Where(a => a.IdMunicipio == IdMunicipio &&
                                  a.IdCentroTrabajo == IdCentroTrabajo &&
                                  a.Division == division &&
                                  a.Instancia == instancia &&
                                  a.IdSistema == IdSistema).ToList();

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
