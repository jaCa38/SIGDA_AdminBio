using Dapper;
using Microsoft.Data.SqlClient;
using SIGDA.FOTOCOPIADO.Libreria.Depositos.Models;
using SIGDA.FOTOCOPIADO.Libreria.Depositos.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Depositos.Controllers
{
    public class DepositoController : IDepositoService, IDisposable
    {
        #region Constructor Variables
        DataTableReader? dtrResultado = null;
        private string? strCadena;
        private string _cadenaConexion = string.Empty;
        public DepositoController() { }
        public DepositoController(string CadenaConexion) => _cadenaConexion = CadenaConexion;
        #endregion

        public bool Actualizar(Deposito deposito, long IdMinerva)
        {
            var sql = @"[vales].[pa_Depositos_Actualizar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@IdDeposito", deposito.IdDeposito);
            dpParametros.Add("@depo_cefo_id", deposito.IdCentroFotocopiado);
            dpParametros.Add("@depo_id_municipio", deposito.idMunicipio);
            dpParametros.Add("@depo_fecha_deposito", deposito.FechaDeposito);
            dpParametros.Add("@depo_sucursal", deposito.SucursalDeposito == null ? "" : deposito.SucursalDeposito);
            dpParametros.Add("@depo_folio", deposito.FolioDeposito == null ? "" : deposito.FolioDeposito);
            dpParametros.Add("@depo_fecha_inicio", deposito.FechaInicioDeposito);
            dpParametros.Add("@depo_fecha_fin", deposito.FechaFinDeposito);
            dpParametros.Add("@depo_importe", deposito.ImporteDeposito);
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

        public List<DepositoBase> Consultar()
        {
            List<DepositoBase> lstResultado = new List<DepositoBase>();

            var sql = @"[vales].[pa_Depositos_Consultar]";
            var dpParametros = new DynamicParameters();

            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<DepositoBase>(
                        sql,
           dpParametros, commandType: CommandType.StoredProcedure
           //, splitOn: "IdentificadorElementoIndice"
           , commandTimeout: 2000
           ).ToList();
                    lstResultado = recRevoc.OrderBy(x => x.IdDeposito).ToList();
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

        public DepositoDetalle Consultar(long Id)
        {
            List<DepositoDetalle> lstResultado = new List<DepositoDetalle>();

            var sql = @"[vales].[pa_Depositos_ConsultarDetalle]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@IdDeposito", Id);

            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<DepositoDetalle>(
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
            var sql = @"[vales].[pa_Depositos_Desactivar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@IdDeposito", Id);
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

        public bool Insertar(Deposito deposito, long IdMinerva)
        {
            var sql = @"[vales].[pa_Depositos_Insertar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@depo_cefo_id", deposito.IdCentroFotocopiado);
            dpParametros.Add("@depo_id_municipio", deposito.idMunicipio);
            dpParametros.Add("@depo_fecha_deposito", deposito.FechaDeposito);
            dpParametros.Add("@depo_sucursal", deposito.SucursalDeposito == null ? "" : deposito.SucursalDeposito);
            dpParametros.Add("@depo_folio", deposito.FolioDeposito == null ? "" : deposito.FolioDeposito);
            dpParametros.Add("@depo_fecha_inicio", deposito.FechaInicioDeposito);
            dpParametros.Add("@depo_fecha_fin", deposito.FechaFinDeposito);
            dpParametros.Add("@depo_importe", deposito.ImporteDeposito);
            dpParametros.Add("@IdMinerva", IdMinerva);
            dpParametros.Add("@IdDocumento", deposito.IdDocumento);
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
    }
}
