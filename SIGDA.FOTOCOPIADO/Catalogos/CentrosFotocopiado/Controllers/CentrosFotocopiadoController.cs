using Dapper;
using Microsoft.Data.SqlClient;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.CentrosFotocopiado.Interfaces;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.CentrosFotocopiado.Models;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.CentrosFotocopiado.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Catalogos.CentrosFotocopiado.Controllers
{
    public class CentrosFotocopiadoController: ICentroFotocopiadoService,IDisposable
    {
        #region Constructor Variables
        DataTableReader? dtrResultado = null;
        private string? strCadena;
        private string _cadenaConexion = string.Empty;
        public CentrosFotocopiadoController() { }
        public CentrosFotocopiadoController(string CadenaConexion) => _cadenaConexion = CadenaConexion;
        #endregion

        public bool Actualizar(CentroFotocopiadoBase centroFotocopiadoBase)
        {
            var sql = @"[catalogo].[pa_CentroFotocopiado_Actualizar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@IdCentroFotocopiado", centroFotocopiadoBase.IdCentroFotocopiado);
            dpParametros.Add("@cefo_id_zona", centroFotocopiadoBase.IdZona);
            dpParametros.Add("@cefo_id_municipio", centroFotocopiadoBase.IdMunicipio);
            dpParametros.Add("@cefo_nombre", centroFotocopiadoBase.NombreCentroFotocopiado);
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

        public List<CentroFotocopiadoDetalle> Consultar()
        {
            List<CentroFotocopiadoDetalle> lstResultado = new List<CentroFotocopiadoDetalle>();

            var sql = @"[catalogo].[pa_CentrosFotocopiado_Consultar]";
            var dpParametros = new DynamicParameters();

            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<CentroFotocopiadoDetalle>(
                        sql,
           dpParametros, commandType: CommandType.StoredProcedure
           //, splitOn: "IdentificadorElementoIndice"
           , commandTimeout: 2000
           ).ToList();
                    lstResultado = recRevoc.OrderBy(x => x.IdCentroFotocopiado).ToList();
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

        public CentroFotocopiadoDetalle Consultar(long Id)
        {
            List<CentroFotocopiadoDetalle> lstResultado = new List<CentroFotocopiadoDetalle>();

            var sql = @"[catalogo].[pa_CentrosFotocopiado_Consultar]";
            var dpParametros = new DynamicParameters();

            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<CentroFotocopiadoDetalle>(
                        sql,
           dpParametros, commandType: CommandType.StoredProcedure
           //, splitOn: "IdentificadorElementoIndice"
           , commandTimeout: 2000
           ).ToList();
                    lstResultado = recRevoc.Where(x => x.IdCentroFotocopiado == Id).ToList();
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

        public bool Desactivar(long Id)
        {
            var sql = @"[catalogo].[pa_CentroFotocopiado_Desactivar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@IdCentroFotocopiado", Id);
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

        public bool Insertar(CentroFotocopiadoBase centroFotocopiadoBase)
        {
            var sql = @"[catalogo].[pa_CentroFotocopiado_Insertar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@cefo_id_zona", centroFotocopiadoBase.IdZona);
            dpParametros.Add("@cefo_id_municipio", centroFotocopiadoBase.IdMunicipio);
            dpParametros.Add("@cefo_nombre", centroFotocopiadoBase.NombreCentroFotocopiado);
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
