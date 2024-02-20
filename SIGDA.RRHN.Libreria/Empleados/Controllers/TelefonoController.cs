using Dapper;
using Microsoft.Data.SqlClient;
using SIGDA.SRHN.Libreria.Empleados.Models;
using SIGDA.SRHN.Libreria.Empleados.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Empleados.Controllers
{
    public class TelefonoController : ITelefonoService, IDisposable
    {
        #region Constructor Variables
        DataTableReader? dtrResultado = null;
        private string? strCadena;

        public TelefonoController(string cadena)
        {
            strCadena = cadena;
        }
        #endregion
        public bool Actualiza(TelefonoBase tel)
        {
            var sql = @"[rh].[pa_Telefono_Actualiza]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idTelefono", tel.IdTelefono);
            dpParametros.Add("@idTipoTelefono", tel.IdPrincipal);
            dpParametros.Add("@numero", tel.Numero);
            try
            {
                using (var connection = new SqlConnection(strCadena))
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

        public bool Almacena(TelefonoBase tel)
        {
            var sql = @"[rh].[pa_Telefono_Alta]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idEmpleado", tel.IdEmpleado);
            dpParametros.Add("@idTipoTelefono", tel.IdPrincipal);
            dpParametros.Add("@numero", tel.Numero);
            try
            {
                using (var connection = new SqlConnection(strCadena))
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

        public bool Elimina(TelefonoBase tel)
        {
            var sql = @"[rh].[pa_Telefono_Elimina]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idTelefono", tel.IdTelefono);            
            try
            {
                using (var connection = new SqlConnection(strCadena))
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

        public IEnumerable<TelefonoBase> ObtenerTodos(TelefonoBase tel)
        {
            IEnumerable<TelefonoBase> lstResultado = new List<TelefonoBase>();
            var sql = @"[rh].[pa_Telefono_Obtener]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idEmpleado", tel.IdEmpleado);
            try
            {
                using (var connection = new SqlConnection(strCadena))
                {
                    var recRevoc = connection.Query<TelefonoBase>(
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
            return lstResultado;
        }

        public TelefonoBase ObtenerUno(TelefonoBase tel)
        {
            IEnumerable<TelefonoBase> lista = ObtenerTodos(tel);
            TelefonoBase telefono = lista.First(x => x.IdTelefono == tel.IdTelefono);
            return telefono;
        }
    }
}
