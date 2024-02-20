using Dapper;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using SIGDA.SRHN.Libreria.Nomina.Catalogo.Enums;
using SIGDA.SRHN.Libreria.Nomina.Catalogo.Models;
using SIGDA.SRHN.Libreria.Nomina.Catalogo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Nomina.Catalogo.Controllers
{
 //comentario
    public class ParametrosBaseController : IParametrosService, IDisposable
    {
        DataTableReader? dtrResultado = null;
        private string? _cadenaConexion;
        public ParametrosBaseController(string cadena)
        {
            _cadenaConexion = cadena;
        }

        public bool AltaParametros(ParametrosBase parametros)
        {
            var sql = @"[nomina].[catalogo.pa_ParametrosTabulador_Almacena]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@tabla_ISR_SE_json", JsonConvert.SerializeObject(parametros));
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

        public ParametrosBase ObtenerParametrosVigentes()
        {
            ParametrosBase lstResultado = new ParametrosBase();
            var sql = @"[nomina].[catalogo.pa_ParametrosTabulador_ObtenerVigentes]";
            var dpParametros = new DynamicParameters();            
            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {                    
                    var list = connection.Query<ParametrosBase>(
                        sql
                        , dpParametros
                        // , splitOn: "IdTabla"
                        , commandTimeout: 2000
                        , commandType: CommandType.StoredProcedure
                        ).ToList();
                    lstResultado = list.First();
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
        public void Dispose()
        {
            try { }
            catch (Exception) { }
        }
    }
}
