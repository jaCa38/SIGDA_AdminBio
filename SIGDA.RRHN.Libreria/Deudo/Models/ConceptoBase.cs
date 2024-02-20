using Dapper;
using SIGDA.Conexion;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGDA.Catalogos.Genericos.Models;

namespace SIGDA.SRHN.Libreria.Deudo.Models
{
    public class ConceptoBase : BaseModel
    {
        private string _cadenaConexion = string.Empty;
        public ConceptoBase() { }
        public ConceptoBase(string CadenaConexion) => _cadenaConexion = CadenaConexion;

        public override IEnumerable<BaseModel> ConsultarCatalogoGenerico()
        {
            IEnumerable<BaseModel> lstResultado = new List<BaseModel>();

            var sql = @"[deudo].[pa_Concepto_ObtenerTodos]";
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
        public override BaseModel ConsultarCatalogoGenericoFiltroID()
        {
            List<BaseModel> lstResultado = new List<BaseModel>();

            var sql = @"[deudo].[pa_Concepto_ObtenerTodos]";
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
                    //lstResultado = recRevoc.Where() .FindAll(x => x.IdMunicipio == IdMunicipio );
                    lstResultado = recRevoc.Where(a => a.IdPrincipal == this.IdPrincipal).ToList();

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
        public override bool InsertarCatalogoGenerico()
        {
            var sql = @"[deudo].[pa_Concepto_Almacenar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@descripcion", this.DescripPrincipal);
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
            var sql = @"[deudo].[pa_Concepto_Actualizar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@id", this.IdPrincipal);
            dpParametros.Add("@descripcion", this.DescripPrincipal);
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

