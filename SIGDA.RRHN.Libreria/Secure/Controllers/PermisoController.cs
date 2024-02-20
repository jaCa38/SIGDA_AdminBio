using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Win32;
using SIGDA.Catalogos.Genericos.Models;
using SIGDA.SRHN.Libreria.Deudo.Models;
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
    public class PermisoController : IPermisoService, IDisposable
    {
        DataTableReader? dtrResultado = null;
        private string? _cadenaConexion;

        public PermisoController(string cadena)
        {
            _cadenaConexion = cadena;
        }
        public bool AlmacenaPermiso(PermisoBase permiso)
        {
            var sql = @"[secure].[pa_Config_AlmacenaPermisoUsuarioModulo]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@datos", permiso.Datos);            
            dpParametros.Add("@idModulo", permiso.IdModulo);
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
        public List<PermisoBase> ObtenerPermisosModulo(PermisoBase permiso)
        {
            List<PermisoBase> lstResultado = new List<PermisoBase>();
            var sql = @"[secure].[pa_Config_ObtenerPermisoModulo]";
            var dpParametros = new DynamicParameters();
            //dpParametros.Add("@idUsuario", permiso.IdUsuario);
            dpParametros.Add("@idModulo", permiso.IdModulo);
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
        public PermisoBase ObtenerPermisosModuloUsuario(PermisoBase permiso) 
        {
            List<PermisoBase> lstResultado = new List<PermisoBase>();
            var sql = @"[secure].[pa_Config_ObtenerPermisoUsuarioModulo]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idUsuario", permiso.IdUsuario);
            dpParametros.Add("@idModulo", permiso.IdModulo);
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
            return lstResultado[0];
        }
        public void Dispose()
        {
            try { }
            catch (Exception)
            { }
        }

        
    }
}
