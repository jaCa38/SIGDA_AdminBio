using Dapper;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGDA.Catalogos.Genericos.Models;

namespace SIGDA.SRHN.Libreria.Catalogos.CentrosTrabajo.Models
{
    public class CentroTrabajoBase : BaseModel
    {
        private string _cadenaConexion = string.Empty;
        public CentroTrabajoBase() { }
        public CentroTrabajoBase(string CadenaConexion) => _cadenaConexion = CadenaConexion;

        public override IEnumerable<BaseModel> ConsultarCatalogoGenerico()
        {
            IEnumerable<BaseModel> lstResultado = new List<BaseModel>();

            var sql = @"[catalogo].[pa_CentroTrabajo_Consultar]";
            var dpParametros = new DynamicParameters();

            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<BaseModel>(
                        sql,
           dpParametros, commandType: CommandType.StoredProcedure
           //, splitOn: "IdentificadorElementoIndice"
           , commandTimeout: 2000
           ).ToList();
                    lstResultado = recRevoc.OrderBy(x => x.DescripPrincipal).ToList();
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
        public override bool InsertarCatalogoGenerico()
        {
            var sql = @"[catalogo].[sp_Obtener_InfoCatalogoCTs_Almacenar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@tipo", 5);
            dpParametros.Add("@descrip", DescripPrincipal);
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
        public override bool ActualizarCatalogoGenerico()
        {
            var sql = @"[catalogo].[sp_Obtener_InfoCatalogoCTs_Actualizar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@tipo", 5);
            dpParametros.Add("@id", IdPrincipal);
            dpParametros.Add("@descrip", DescripPrincipal);
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
