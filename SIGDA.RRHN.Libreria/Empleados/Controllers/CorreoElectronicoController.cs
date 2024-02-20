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
    public class CorreoElectronicoController : ICorreoElectronicoService, IDisposable
    {
        #region Constructor Variables
        DataTableReader? dtrResultado = null;
        private string? strCadena;

        public CorreoElectronicoController(string cadena)
        {
            strCadena = cadena;
        }
        #endregion
        public bool ActualizarCorreoElectronico(CorreoElectronicoBase mail)
        {
            var sql = @"[rh].[pa_CorreoElectronico_Actualizar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idEmail", mail.IdEmail);
            dpParametros.Add("@email", mail.Email);            
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

        public bool AlmacenaCorreoElectronico(CorreoElectronicoBase mail)
        {
            var sql = @"[rh].[pa_CorreoElectronico_Alta]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idEmpleado", mail.IdEmpleado);
            dpParametros.Add("@email", mail.Email);
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
            try { } catch (Exception) { }
        }

        public bool EliminarCorreoElectronico(CorreoElectronicoBase mail)
        {
            var sql = @"[rh].[pa_CorreoElectronico_Eliminar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idEmail", mail.IdEmail);
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

        public CorreoElectronicoBase ObtenerCorreoElectronico(CorreoElectronicoBase mail)
        {
            IEnumerable<CorreoElectronicoBase> lista = ObtenerCorreosElectronicos(mail);
            CorreoElectronicoBase encontrado = lista.First(x => x.IdEmail == mail.IdEmail);
            return encontrado;
        }

        public IEnumerable<CorreoElectronicoBase> ObtenerCorreosElectronicos(CorreoElectronicoBase mail)
        {
            IEnumerable<CorreoElectronicoBase> lstResultado = new List<CorreoElectronicoBase>();
            var sql = @"[rh].[pa_CorreoElectronico_Obtener]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idEmpleado", mail.IdEmpleado);
            try
            {
                using (var connection = new SqlConnection(strCadena))
                {
                    var recRevoc = connection.Query<CorreoElectronicoBase>(
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
    }
}
