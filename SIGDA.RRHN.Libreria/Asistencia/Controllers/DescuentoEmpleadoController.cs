using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Win32;
using SIGDA.SRHN.Libreria.Asistencia.Enums;
using SIGDA.SRHN.Libreria.Asistencia.Models;
using SIGDA.SRHN.Libreria.Asistencia.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Asistencia.Controllers
{
    public class DescuentoEmpleadoController : IDescuentoEmpleadoService, IDisposable
    {
        #region Constructor Variables
        DataTableReader? dtrResultado = null;
        private string? _cadenaConexion;

        public DescuentoEmpleadoController(string cadena)
        {
            _cadenaConexion = cadena;
        }
        #endregion
        public bool AlmacenarDescuentoEmpleado(DescuentoEmpleadoBase descuentoEmpleado)
        {
            var sql = @"[asistencia].[pa_ConfigDescuento_Almacena]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idEmpleado", descuentoEmpleado.IdEmpleado);
            dpParametros.Add("@idTipoDescuento", (int)descuentoEmpleado.IdTipoDescuento);
            dpParametros.Add("@idEstatus", (int)descuentoEmpleado.IdEstatus);
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

        public bool ModificaDescuentoEmpleado(DescuentoEmpleadoBase descuentoEmpleado)
        {
            var sql = @"[asistencia].[pa_ConfigDescuento_Modifica]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idConsec", descuentoEmpleado.IdConsec);
            dpParametros.Add("@idTipoDescuento", (int)descuentoEmpleado.IdTipoDescuento);
            dpParametros.Add("@idEstatus", (int)descuentoEmpleado.IdEstatus);
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

        public List<DescuentoEmpleadoBase> ObtenerListado(DescuentoEmpleadoBase descuentoEmpleado)
        {
            List<DescuentoEmpleadoBase> lstResultado = new List<DescuentoEmpleadoBase>();
            var sql = @"[asistencia].[pa_ConfigDescuento_ObtenerListado]";
            var dpParametros = new DynamicParameters();            
            dpParametros.Add("@idTipoDescuento", (int)descuentoEmpleado.IdTipoDescuento);
            dpParametros.Add("@idEstatus", (int)descuentoEmpleado.IdEstatus);
            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<DescuentoEmpleadoBase>(
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
            try { } catch (Exception) { }
        }
    }
}
