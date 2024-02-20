using Dapper;
using SIGDA.Documentos.Factorizadores;
using SIGDA.Documentos.Models;
using SIGDA.Documentos.Services;
using SIGDA.Reporteador.ItextSharp;
using SIGDA.Reporteador.Models;
using SIGDA.Reporteador.Services.Interfaces;
using SIGDA.Reporteador.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Reporteador.Controllers
{
    public class BaseReportesController : IBaseReportesService
    {
        #region Constructor Variables
        DataTableReader dtrResultado = null;
        private string strCadena;
        private string _cadenaConexion = string.Empty;
        public BaseReportesController() { }
        public BaseReportesController(string CadenaConexion) => _cadenaConexion = CadenaConexion;
        #endregion

        public EsquemaReporte ConsultarEsquemaReporte(long IdReporte)
        {
            EsquemaReporte lstResultado = new EsquemaReporte();

            var sql = @"[catalogo].[pa_EsquemaReporte_Consultar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@IdReporte", IdReporte);
            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<EsquemaReporte>(
                        sql,
           dpParametros, commandType: CommandType.StoredProcedure
           //, splitOn: "IdentificadorElementoIndice"
           , commandTimeout: 2000
           ).ToList();
                    lstResultado = recRevoc.ToList().First();
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
        public string ArchivarDocumentoTemporal(long IdMinerva, ConfigReporteador configReporteador, ConfigArchivo configArchivo)
        {
            MetaDocumentoTmpService service;
            long IdDocumentoTMP = 0;
            MetaDocumentoTmpConsulta metaDocumentoTmpConsulta;
            MetaDocumentoFile metaDocumentoFile = new MetaDocumentoFile()
            {
                NombreDocumento = configReporteador.NombreArchivo,
                IdTipoDocumento = 1,
                File = File.ReadAllBytes(configArchivo.NombreArchivo)
            };
            File.Delete(configArchivo.NombreArchivo); //Se borra archivo que se generó antes de archivar en SIGDA_DOCUMENTOS
            using (var Gestion = FactorizadorDocumentos.CrearConexionGenericaDocumentosTmp())
            {
                service = new MetaDocumentoTmpService(Gestion);
                IdDocumentoTMP = service.ArchivarDocumento(metaDocumentoFile, IdMinerva);

                if (IdDocumentoTMP > 0)
                {
                    metaDocumentoTmpConsulta = service.ConsultarDocumento(IdDocumentoTMP, Guid.NewGuid().ToString());
                    return metaDocumentoTmpConsulta.URL;
                }
                else
                    throw new Exception("No se pudo almacenar el registro en DOCUMENTOS_TEMPORALES de la BD SIGDA_DOCUMENTOS");

            }
        }

        protected void EnumerFilasDT(ref DataTable dtListado)
        {
            for (int i = 0; i < dtListado.Rows.Count; i++)
            {
                dtListado.Rows[i][0] = i + 1;
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
