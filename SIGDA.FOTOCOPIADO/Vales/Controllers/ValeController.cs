using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.Enums;
using SIGDA.FOTOCOPIADO.Libreria.Vales.Models;
using SIGDA.FOTOCOPIADO.Libreria.Vales.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Vales.Controllers
{
    public class ValeController : IValeService, IDisposable
    {
        #region Constructor Variables
        DataTableReader? dtrResultado = null;
        private string? strCadena;
        private string _cadenaConexion = string.Empty;
        public ValeController() { }
        public ValeController(string CadenaConexion) => _cadenaConexion = CadenaConexion;
        #endregion

        public bool Actualizar(Vale vale, long IdMinerva)
        {
            var sql = @"[vales].[pa_ValesCopiadoras_Actualizar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@IdValeCopiadora", vale.IdVale);
            dpParametros.Add("@vaco_copi_id", vale.IdCopiadora);
            dpParametros.Add("@vaco_serie", vale.SerieVale == null ? "" : vale.SerieVale);
            dpParametros.Add("@vaco_folio", vale.FolioVale == null ? "" : vale.FolioVale);
            dpParametros.Add("@vaco_fecha_asignado", vale.FechaAsignadoVale);
            dpParametros.Add("@vaco_fecha_registrado", vale.FechaRegistradoVale);
            dpParametros.Add("@vaco_cantidad_copias", vale.CantidadCopias);
            dpParametros.Add("@vaco_tico_id", vale.IdentificadorTipoCopia);
            dpParametros.Add("@vaco_tipo_hoja", (int)vale.TipoHoja);
            dpParametros.Add("@vaco_observaciones", vale.Observaciones == null ? "" : vale.Observaciones);
            dpParametros.Add("@vaco_id_zona", vale.IdZona);
            dpParametros.Add("@vaco_id_municipio", vale.IdMunicipio);
            dpParametros.Add("@vaco_ccs_401_identificador", vale.IdentificadorCCS);
            dpParametros.Add("@vaco_esva_id", vale.IdEstatusVale);
            dpParametros.Add("@IdMinerva", IdMinerva);
            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var rowsAf = connection.Execute(sql, dpParametros, commandType: CommandType.StoredProcedure, commandTimeout: 2000);
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

        public List<ValeBase> Consultar()
        {
            List<ValeBase> lstResultado = new List<ValeBase>();

            var sql = @"[vales].[pa_ValesCopiadoras_Consultar]";
            var dpParametros = new DynamicParameters();

            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<ValeBase>(
                        sql,
           dpParametros, commandType: CommandType.StoredProcedure
           //, splitOn: "IdentificadorElementoIndice"
           , commandTimeout: 2000
           ).ToList();
                    lstResultado = recRevoc.OrderBy(x => x.IdVale).ToList();
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

        public ValeDetalle Consultar(long Id)
        {
            List<ValeDetalle> lstResultado = new List<ValeDetalle>();

            var sql = @"[vales].[pa_ValesCopiadoras_ConsultarDetalle]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@IdVale", Id);

            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<ValeDetalle>(
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

        public bool Desactivar(long Id, long IdMinerva)
        {
            var sql = @"[vales].[pa_ValesCopiadoras_Desactivar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@IdValeCopiadora", Id);
            dpParametros.Add("@IdMinerva", IdMinerva);
            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var rowsAf = connection.Execute(sql, dpParametros, commandType: CommandType.StoredProcedure, commandTimeout: 2000);
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

        public bool Insertar(Vale vale, long IdMinerva)
        {
            var sql = @"[vales].[pa_ValesCopiadoras_Insertar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@vaco_copi_id", vale.IdCopiadora);
            dpParametros.Add("@vaco_serie", vale.SerieVale == null ? "" : vale.SerieVale);
            dpParametros.Add("@vaco_folio", vale.FolioVale == null ? "" : vale.FolioVale);
            dpParametros.Add("@vaco_fecha_asignado", vale.FechaAsignadoVale);
            dpParametros.Add("@vaco_fecha_registrado", vale.FechaRegistradoVale);
            dpParametros.Add("@vaco_cantidad_copias", vale.CantidadCopias);
            dpParametros.Add("@vaco_tico_id", vale.IdentificadorTipoCopia);
            dpParametros.Add("@vaco_tipo_hoja", (int)vale.TipoHoja);
            dpParametros.Add("@vaco_observaciones", vale.Observaciones == null ? "" : vale.Observaciones);
            dpParametros.Add("@vaco_id_zona", vale.IdZona);
            dpParametros.Add("@vaco_id_municipio", vale.IdMunicipio);
            dpParametros.Add("@vaco_ccs_401_identificador", vale.IdentificadorCCS);
            dpParametros.Add("@vaco_esva_id", vale.IdEstatusVale);
            dpParametros.Add("@IdMinerva", IdMinerva);
            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var Identificador = connection.QuerySingle<long>(sql, dpParametros, commandType: CommandType.StoredProcedure, commandTimeout: 2000);
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

        
    }
}
