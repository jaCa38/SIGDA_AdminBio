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

namespace SIGDA.SRHN.Libreria.Catalogos.EntidadesFederativas.Models
{
    public class EntidadFederativaBase : BaseModel
    {
        private string _cadenaConexion = string.Empty;
        public EntidadFederativaBase() { }
        public EntidadFederativaBase(string CadenaConexion) => _cadenaConexion = CadenaConexion;

        public override IEnumerable<BaseModel> ConsultarCatalogoGenerico(long Identificador)
        {
            IEnumerable<BaseModel> lstResultado = new List<BaseModel>();

            var sql = @"[catalogo].[sp_ObtenerEstadosCatalogo]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@id", Identificador);

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

    }
}
