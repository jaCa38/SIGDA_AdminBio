using Dapper;
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
    public class EstatusBase : BaseModel
    {
        private string _cadenaConexion = string.Empty;
        public EstatusBase() { }
        public EstatusBase(string cadenaConexion) => _cadenaConexion = cadenaConexion;
        public override IEnumerable<BaseModel> ConsultarCatalogoGenerico()
        {
            IEnumerable<BaseModel> lstResultado = new List<BaseModel>();
            var sql = @"[deudo].[pa_Estatus_Obtener]";
            var dpParametros = new DynamicParameters();
            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<BaseModel>(
                        sql, dpParametros, commandType: CommandType.StoredProcedure
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
