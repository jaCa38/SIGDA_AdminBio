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
    public class MetaDocumentoController:IMetaDocumentoService,IUnidadAlmacenamientoService, IDisposable
    {
        #region Constructor Variables
        DataTableReader? dtrResultado = null;
        private string? strCadena;
        private string _cadenaConexion = string.Empty;
        public MetaDocumentoController() { }
        public MetaDocumentoController(string CadenaConexion) => _cadenaConexion = CadenaConexion;
        #endregion

        public long ArchivarDocumento(MetaDocumentoFile metaDocumentoFile, long IdMinerva, EModuloSIGDA eModuloSIGDA, long IdCT, long IdZona)
        {
            long Resultado = 0;
            string RutaEspecifica = string.Empty;
            string GUID = Guid.NewGuid().ToString();
            UnidadAlmacenamiento unidadAlmacenamiento = ConsultarUnidadActiva();
            if (unidadAlmacenamiento != null )
            {
                try
                {
                    if (unidadAlmacenamiento.RutaUnidadAlmacenamiento != "")
                    {
                        EClasificadorMedia Tipo = Funciones.ObtenerTipo(Convert.ToInt32(metaDocumentoFile.IdTipoDocumento));
                        var RutaRepositorioModuloSIGDA = Path.Combine(unidadAlmacenamiento.RutaUnidadAlmacenamiento, Funciones.ObtenerRutaModuloSIGDA(eModuloSIGDA), Tipo.ToString());
                        RutaEspecifica = Path.Combine(Funciones.ObtenerRutaEspecifica(RutaRepositorioModuloSIGDA), GUID);
                        File.WriteAllBytes(RutaEspecifica, metaDocumentoFile.File);
                        if (File.Exists(RutaEspecifica))
                        {
                            var sql = @"[dbo].[pa_MetaDocumento_Almacenar]";
                            var dpParametros = new DynamicParameters();
                            dpParametros.Add("@medo_GUID", GUID);
                            dpParametros.Add("@medo_nombreDocumento", metaDocumentoFile.NombreDocumento);
                            dpParametros.Add("@medo_idMinerva", IdMinerva);
                            dpParametros.Add("@medo_idCT", IdCT);
                            dpParametros.Add("@medo_idZona", IdZona);
                            dpParametros.Add("@medo_tido_id", metaDocumentoFile.IdTipoDocumento);
                            dpParametros.Add("@medo_ruta", RutaEspecifica);

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
                catch(SqlException sqlEx)
                {
                    File.Delete(RutaEspecifica);
                    throw new Exception(sqlEx.Message, sqlEx);
                }
                catch (Exception ex)
                {
                    File.Delete(RutaEspecifica);
                    throw new Exception(ex.Message,ex);
                }
            }
            else
                throw new Exception("No existe UNIDAD DE ALMACENAMIENTO definida");
        }

        public long ArchivarDocumento(MetaDocumentoFileStream metaDocumentoFileStream, long IdMinerva, EModuloSIGDA eModuloSIGDA, long IdCT, long IdZona)
        {
            long Resultado = 0;
            string RutaEspecifica = string.Empty;
            string GUID = Guid.NewGuid().ToString();//
            UnidadAlmacenamiento unidadAlmacenamiento = ConsultarUnidadActiva();
            if (unidadAlmacenamiento != null)
            {
                try
                {
                    if (unidadAlmacenamiento.RutaUnidadAlmacenamiento != "")
                    {
                     //   var rutaCarpetaTemp = "D:\\pruebas";
                        EClasificadorMedia Tipo = Funciones.ObtenerTipo(Convert.ToInt32(metaDocumentoFileStream.IdTipoDocumento));
                       var RutaRepositorioModuloSIGDA = Path.Combine(unidadAlmacenamiento.RutaUnidadAlmacenamiento, Funciones.ObtenerRutaModuloSIGDA(eModuloSIGDA), Tipo.ToString());
                      // var RutaRepositorioModuloSIGDA = Path.Combine(rutaCarpetaTemp, Funciones.ObtenerRutaModuloSIGDA(eModuloSIGDA), Tipo.ToString());
                        RutaEspecifica = Path.Combine(Funciones.ObtenerRutaEspecifica(RutaRepositorioModuloSIGDA), GUID);
                        var memoryStream = new MemoryStream();
                        metaDocumentoFileStream.File.CopyTo(memoryStream);
                        File.WriteAllBytes(RutaEspecifica, memoryStream.ToArray());
                        if (File.Exists(RutaEspecifica))
                        {
                            var sql = @"[dbo].[pa_MetaDocumento_Almacenar]";
                            var dpParametros = new DynamicParameters();
                            dpParametros.Add("@medo_GUID", GUID);
                            dpParametros.Add("@medo_nombreDocumento", metaDocumentoFileStream.NombreDocumento);
                            dpParametros.Add("@medo_idMinerva", IdMinerva);
                            dpParametros.Add("@medo_idCT", IdCT);
                            dpParametros.Add("@medo_idZona", IdZona);
                            dpParametros.Add("@medo_tido_id", metaDocumentoFileStream.IdTipoDocumento);
                            dpParametros.Add("@medo_ruta", RutaEspecifica);

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

        public bool BorrarDocumento(long IdDocumento, long IdMinerva)
        {
            var sql = @"[dbo].[pa_MetaDocumento_Borrar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@IdMetaDocumento", IdDocumento);
            //dpParametros.Add("@IdMinerva", IdMinerva);
            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var rowsAf = connection.Execute(sql, dpParametros, commandType: CommandType.StoredProcedure, commandTimeout: 2000);
            /*******************POSTERIOR CHECAR SI SE BORRA EL ARCHIVO FÍSICO EN EL SERVIDOR*******/
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

        public MetaDocumentoConsulta ConsultarDocumento(long IdDocumento, string JWT)
        {
            MetaDocumentoConsulta lstResultado = new MetaDocumentoConsulta();

            var sql = @"[dbo].[pa_MetaDocumento_Consultar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@IdMetaDocumento", IdDocumento);
            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<MetaDocumentoConsulta>(
                        sql,
           dpParametros, commandType: CommandType.StoredProcedure
           //, splitOn: "IdentificadorElementoIndice"
           , commandTimeout: 2000
           ).ToList();
                    lstResultado = recRevoc.ToList().First();

                    /*Generación de URL*/
                    string check = Checksums.CrearSum(JWT + lstResultado.IdCTMetaDocumento + lstResultado.IdZonaMetaDocumento);
                    lstResultado.URL = Paths.URLMedia + "/" + Funciones.ObtenerServicio(lstResultado.IdTipoDocumento) + "/" + lstResultado.IdCTMetaDocumento.ToString() + "/" + lstResultado.IdZonaMetaDocumento.ToString() + "/" + lstResultado.GUIDDocumento + "/" + check + "/" + JWT + "/" + "0" + "/" + IdDocumento.ToString();
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
