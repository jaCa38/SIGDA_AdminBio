using Dapper;
using Microsoft.Data.SqlClient;
using SIGDA.Catalogos.Genericos.Services.Interfaces;
using SIGDA.FOTOCOPIADO.Libreria.Copiadoras.Interfaces;
using SIGDA.FOTOCOPIADO.Libreria.Copiadoras.Models;
using SIGDA.FOTOCOPIADO.Libreria.Copiadoras.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Copiadoras.Controllers
{
    public class CopiadoraController : ICopiadoraService, IDisposable
    {
        #region Constructor Variables
        DataTableReader? dtrResultado = null;
        private string? strCadena;
        private string _cadenaConexion = string.Empty;
        public CopiadoraController() { }
        public CopiadoraController(string CadenaConexion) => _cadenaConexion = CadenaConexion;
        #endregion

        #region CRUD Catalogo
        public bool Actualizar(CopiadoraBase copiadoraBase)
        {
            var sql = @"[catalogo].[pa_Copiadoras_Actualizar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@IdCopiadora", copiadoraBase.IdCopiadora);
            dpParametros.Add("@copi_identificador_anterior", copiadoraBase.IdAnterior);
            dpParametros.Add("@copi_marc_id", copiadoraBase.IdMarca);
            dpParametros.Add("@copi_mode_id", copiadoraBase.IdModelo);
            dpParametros.Add("@copi_serie", copiadoraBase.Serie);
            dpParametros.Add("@copi_nombre", copiadoraBase.NombreCopiadora);
            dpParametros.Add("@copi_tipo_propiedad", (int)copiadoraBase.TipoPropiedad);
            dpParametros.Add("@copi_estatus", (int)copiadoraBase.EstatusCopiadora);
            dpParametros.Add("@copi_cefo_id", copiadoraBase.IdCentroFotocopiado);
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

        public bool ActualizarUbicacion(CopiadoraBase copiadoraBase)
        {
            var sql = @"[catalogo].[pa_Copiadoras_ActualizarUbicacion]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@IdCopiadora", copiadoraBase.IdCopiadora);
            dpParametros.Add("@copi_cefo_id", copiadoraBase.IdCentroFotocopiado);
            //dpParametros.Add("@IdMinerva", IdMinerva);
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

        public List<CopiadoraBase> Consultar()
        {
            List<CopiadoraBase> lstResultado = new List<CopiadoraBase>();

            var sql = @"[catalogo].[pa_Copiadoras_Consultar]";
            var dpParametros = new DynamicParameters();

            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<CopiadoraBase>(
                        sql,
           dpParametros, commandType: CommandType.StoredProcedure
           //, splitOn: "IdentificadorElementoIndice"
           , commandTimeout: 2000
           ).ToList();
                    lstResultado = recRevoc.OrderBy(x => x.IdAnterior).OrderBy(x => x.IdCopiadora).ToList();
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

        public CopiadoraBase Consultar(long Id)
        {
            List<CopiadoraBase> lstResultado = new List<CopiadoraBase>();

            var sql = @"[catalogo].[pa_Copiadoras_Consultar]";
            var dpParametros = new DynamicParameters();

            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<CopiadoraBase>(
                        sql,
           dpParametros, commandType: CommandType.StoredProcedure
           //, splitOn: "IdentificadorElementoIndice"
           , commandTimeout: 2000
           ).ToList();
                    lstResultado = recRevoc.Where(x => x.IdCopiadora == Id).ToList();
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

        public List<CopiadoraDetalle> ConsultarDetalle()
        {
            List<CopiadoraDetalle> lstResultado = new List<CopiadoraDetalle>();

            var sql = @"[catalogo].[pa_Copiadoras_ConsultarDetalle]";
            var dpParametros = new DynamicParameters();

            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<CopiadoraDetalle>(
                        sql,
           dpParametros, commandType: CommandType.StoredProcedure
           //, splitOn: "IdentificadorElementoIndice"
           , commandTimeout: 2000
           ).ToList();
                    lstResultado = recRevoc.OrderBy(x => x.IdAnterior).OrderBy(x => x.IdCopiadora).ToList();
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

        public bool Desactivar(long Id)
        {
            var sql = @"[catalogo].[pa_Copiadoras_Desactivar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@IdCopiadora", Id);

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
        
        public bool Insertar(CopiadoraBase copiadoraBase)
        {
            var sql = @"[catalogo].[pa_Copiadoras_Insertar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@copi_marc_id", copiadoraBase.IdMarca);
            dpParametros.Add("@copi_mode_id", copiadoraBase.IdModelo);
            dpParametros.Add("@copi_serie", copiadoraBase.Serie);
            dpParametros.Add("@copi_nombre", copiadoraBase.NombreCopiadora);
            dpParametros.Add("@copi_tipo_propiedad", (int)copiadoraBase.TipoPropiedad);
            dpParametros.Add("@copi_estatus", (int)copiadoraBase.EstatusCopiadora);
            dpParametros.Add("@copi_cefo_id", copiadoraBase.IdCentroFotocopiado);
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
        #endregion
        
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

        #region Contadores
        public List<ContadorBase> ConsultarContadores()
        {
            List<ContadorBase> lstResultado = new List<ContadorBase>();

            var sql = @"[copiadoras].[pa_Contadores_Consultar]";
            var dpParametros = new DynamicParameters();

            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<ContadorBase>(
                        sql,
           dpParametros, commandType: CommandType.StoredProcedure
           //, splitOn: "IdentificadorElementoIndice"
           , commandTimeout: 2000
           ).ToList();
                    lstResultado = recRevoc.OrderBy(x => x.IdContador).OrderBy(x => x.IdCopiadora).ToList();
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

        public ContadorDetalle ConsultarContadores(long Id)
        {
            List<ContadorDetalle> lstResultado = new List<ContadorDetalle>();

            var sql = @"[copiadoras].[pa_Contadores_ConsultarDetalle]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@IdContador", Id);

            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<ContadorDetalle>(
                        sql,
           dpParametros, commandType: CommandType.StoredProcedure
           //, splitOn: "IdentificadorElementoIndice"
           , commandTimeout: 2000
           ).ToList();
                    lstResultado = recRevoc.Where(x => x.IdContador == Id).ToList();
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

        public bool InsertarContador(ContadorBase copiadoraBase, long IdMinerva)
        {
            var sql = @"[copiadoras].[pa_Contadores_Insertar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@cont_copi_id", copiadoraBase.IdCopiadora);
            dpParametros.Add("@cont_fecha", copiadoraBase.FechaContador);
            dpParametros.Add("@cont_contador_inicial", copiadoraBase.ContadorInicial);
            dpParametros.Add("@cont_contador_final", copiadoraBase.ContadorFinal);
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

        public bool ActualizarContador(ContadorBase copiadoraBase, long IdMinerva)
        {
            var sql = @"[copiadoras].[pa_Contadores_Actualizar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@IdContador", copiadoraBase.IdContador);
            dpParametros.Add("@cont_copi_id", copiadoraBase.IdCopiadora);
            dpParametros.Add("@cont_fecha", copiadoraBase.FechaContador);
            dpParametros.Add("@cont_contador_inicial", copiadoraBase.ContadorInicial);
            dpParametros.Add("@cont_contador_final", copiadoraBase.ContadorFinal);
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

        public bool DesactivarContador(long Id, long IdMinerva)
        {
            var sql = @"[copiadoras].[pa_Contadores_Desactivar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@IdContador", Id);
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
        #endregion
        #region Costo por Copia
        public List<CostoDetalle> ConsultarCostosCopia()
        {
            List<CostoDetalle> lstResultado = new List<CostoDetalle>();

            var sql = @"[copiadoras].[pa_CostoCopia_Consultar]";
            var dpParametros = new DynamicParameters();

            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<CostoDetalle>(
                        sql,
           dpParametros, commandType: CommandType.StoredProcedure
           //, splitOn: "IdentificadorElementoIndice"
           , commandTimeout: 2000
           ).ToList();
                    lstResultado = recRevoc.OrderBy(x => x.IdCostoCopia).OrderBy(x => x.IdZona).ToList();
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

        public List<CostoDetalle> ConsultarCostosCopiaZona(long IdZona)
        {
            List<CostoDetalle> lstResultado = new List<CostoDetalle>();

            var sql = @"[copiadoras].[pa_CostoCopia_ConsultarZona]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@IdZona", IdZona);
            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<CostoDetalle>(
                        sql,
           dpParametros, commandType: CommandType.StoredProcedure
           //, splitOn: "IdentificadorElementoIndice"
           , commandTimeout: 2000
           ).ToList();
                    lstResultado = recRevoc.OrderBy(x => x.IdCostoCopia).ToList();
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

        public bool InsertarCostoCopia(CostoBase costoBase, long IdMinerva)
        {
            var sql = @"[copiadoras].[pa_CostoCopia_Insertar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@coco_id_Zona", costoBase.IdZona);
            dpParametros.Add("@coco_fecha_inicio", costoBase.FechaInicioCostoCopia);
            dpParametros.Add("@coco_fecha_fin", costoBase.FechaFinCostoCopia);
            dpParametros.Add("@coco_costo_copia", costoBase.CostoCopia);
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

        public bool ActualizarCostoCopia(CostoBase costoBase, long IdMinerva)
        {
            var sql = @"[copiadoras].[pa_CostoCopia_Actualizar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@IdCoco", costoBase.IdCostoCopia);
            dpParametros.Add("@coco_id_Zona", costoBase.IdZona);
            dpParametros.Add("@coco_fecha_inicio", costoBase.FechaInicioCostoCopia);
            dpParametros.Add("@coco_fecha_fin", costoBase.FechaFinCostoCopia);
            dpParametros.Add("@coco_costo_copia", costoBase.CostoCopia);
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

        public bool DesactivarCostoCopia(long Id, long IdMinerva)
        {
            var sql = @"[copiadoras].[pa_CostoCopia_Desactivar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@IdCoco", Id);
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
        #endregion
    }
}
