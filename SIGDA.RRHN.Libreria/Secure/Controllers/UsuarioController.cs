using Dapper;
using Microsoft.Data.SqlClient;
using SIGDA.Catalogos.Genericos.Models;
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
    public class UsuarioController : IUsuarioService, IDisposable
    {
        DataTableReader? dtrResultado = null;
        private string? _cadenaConexion;

        public UsuarioController(string cadena)
        {
            _cadenaConexion = cadena;
        }
        public List<PermisoBase> ObtenerUsuarios()
        {
            List<PermisoBase> lstResultado = new List<PermisoBase>();
            var sql = @"[secure].[pa_Config_ObtenerUsuarios]";
            var dpParametros = new DynamicParameters();            
            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<PermisoBase>(
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
        public void Dispose()
        {
            try { }
            catch (Exception)
            { }
        }

       
    }
}
