using Dapper;
using Microsoft.Data.SqlClient;
using SIGDA.SRHN.Libreria.Secure.Models;
using SIGDA.SRHN.Libreria.Secure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Secure.Controllers
{
    public class AutenticarController : IAutenticarService, IDisposable
    {
        DataTableReader? dtrResultado = null;
        private string? _cadenaConexion;

        public AutenticarController(string cadena)
        {
            _cadenaConexion = cadena;
        }
        public bool UsuarioAutenticado(UsuarioBase usuario)
        {
            var sql = @"[secure].[pa_Config_AlmacenaPermisoUsuarioModulo]";
            var dpParametros = new DynamicParameters();
            //dpParametros.Add("@datos", usuario.Datos);
            //dpParametros.Add("@idModulo", usuario.IdModulo);
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
            throw new NotImplementedException();
        }        
    }
}
