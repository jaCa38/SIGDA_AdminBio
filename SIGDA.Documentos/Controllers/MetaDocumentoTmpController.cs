using Dapper;
using Microsoft.Data.SqlClient;
using SIGDA.Documentos.Enums;
using SIGDA.Documentos.Models;
using SIGDA.Documentos.Services.Interfaces;
using SIGDA.Documentos.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Documentos.Controllers
{
    public class MetaDocumentoTmpController : IMetaDocumentoTmpService, IUnidadAlmacenamientoService, IDisposable
    {
        #region Constructor Variables
        DataTableReader? dtrResultado = null;
        private string? strCadena;
        private string _cadenaConexion = string.Empty;
        public MetaDocumentoTmpController() { }
        public MetaDocumentoTmpController(string CadenaConexion) => _cadenaConexion = CadenaConexion;
        #endregion
        public long ArchivarDocumento(MetaDocumentoFile metaDocumentoFile, long IdMinerva)
        {
            long Resultado = 0;
            string RutaEspecifica = string.Empty;
            string GUID = Guid.NewGuid().ToString();
            UnidadAlmacenamiento unidadAlmacenamiento = ConsultarUnidadActiva();
            if (unidadAlmacenamiento != null)
            {
                try
                {
                    if (unidadAlmacenamiento.RutaUnidadAlmacenamiento != "")
                    {
                        EClasificadorMedia Tipo = Funciones.ObtenerTipo(Convert.ToInt32(metaDocumentoFile.IdTipoDocumento));
                        var RutaRepositorioModuloSIGDA = Path.Combine(unidadAlmacenamiento.RutaUnidadAlmacenamiento, "tmp", Tipo.ToString());
                        RutaEspecifica = Path.Combine(Funciones.ObtenerRutaEspecifica(RutaRepositorioModuloSIGDA), GUID);
                        File.WriteAllBytes(RutaEspecifica, metaDocumentoFile.File);
                        if (File.Exists(RutaEspecifica))
                        {
                            var sql = @"[dbo].[pa_MetaDocumentoTemporal_Almacenar]";
                            var dpParametros = new DynamicParameters();
                            dpParametros.Add("@mdte_GUID", GUID);
                            dpParametros.Add("@mdte_nombreDocumento", metaDocumentoFile.NombreDocumento);
                            dpParametros.Add("@mdte_idMinerva", IdMinerva);
                            dpParametros.Add("@mdte_tido_id", metaDocumentoFile.IdTipoDocumento);
                            dpParametros.Add("@mdte_ruta", RutaEspecifica);

                            using (var connection = new SqlConnection(_cadenaConexion))
                            {
                                Resultado = connection.QuerySingle<long>(sql, dpParametros, commandType: CommandType.StoredProcedure, commandTimeout: 2000);
                            }
                            return Resultado;
                        }
                        else
                            throw new Exception("NO SE PUDO GUARDAR EL ARCHIVO");
                    }
                    else
                        throw new Exception("No existe UNIDAD DE ALMACENAMIENTO definida");
                }
                catch (SqlException sqlEx)
                {
                    File.Delete(RutaEspecifica);
                    throw new Exception(sqlEx.Message, sqlEx);
                }
                catch (Exception ex)
                {
                    File.Delete(RutaEspecifica);
                    throw new Exception(ex.Message, ex);
                }
            }
            else
                throw new Exception("No existe UNIDAD DE ALMACENAMIENTO definida");
        }

        public bool BorrarDocumento(long IdDocumento)
        {
            var sql = @"[dbo].[pa_MetaDocumentoTemporal_Borrar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@IdMetaDocumentoTemp", IdDocumento);
            //dpParametros.Add("@IdMinerva", IdMinerva);
            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var rowsAf = connection.Execute(sql, dpParametros, commandType: CommandType.StoredProcedure, commandTimeout: 2000);
                    /*******************FALTA!!!!! BORRAR EL ARCHIVO FÍSICO EN EL SERVIDOR*******/
                    return true;
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

        public MetaDocumentoTmpConsulta ConsultarDocumento(long IdDocumento, string JWT)
        {
            MetaDocumentoTmpConsulta lstResultado = new MetaDocumentoTmpConsulta();
            Random random = new Random();
            int randomZonaCT = random.Next();

            var sql = @"[dbo].[pa_MetaDocumentoTemporal_Consultar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@IdMetaDocumentoTemporal", IdDocumento);
            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<MetaDocumentoTmpConsulta>(
                        sql,
           dpParametros, commandType: CommandType.StoredProcedure
           //, splitOn: "IdentificadorElementoIndice"
           , commandTimeout: 2000
           ).ToList();
                    lstResultado = recRevoc.ToList().First();

                    /*Generación de URL*/
                    string check = Checksums.CrearSum(JWT + randomZonaCT + randomZonaCT);
                    lstResultado.URL = Paths.URLMedia + "/" + Funciones.ObtenerServicio(lstResultado.IdTipoDocumento) + "/" + randomZonaCT.ToString() + "/" + randomZonaCT.ToString() + "/" + lstResultado.GUIDDocumento + "/" + check + "/" + JWT + "/" + "1" + "/" + IdDocumento.ToString();
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

        public UnidadAlmacenamiento ConsultarUnidadActiva()
        {
            List<UnidadAlmacenamiento> lstResultado = new List<UnidadAlmacenamiento>();

            var sql = @"[dbo].[pa_UnidadAlmacenamiento_ConsultarActual]";
            var dpParametros = new DynamicParameters();

            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<UnidadAlmacenamiento>(
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

        public void Dispose()
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
