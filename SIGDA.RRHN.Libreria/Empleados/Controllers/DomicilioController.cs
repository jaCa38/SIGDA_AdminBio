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
    public class DomicilioController : IDomicilioService, IDisposable
    {
        #region Constructor Variables
        DataTableReader? dtrResultado = null;
        private string? strCadena;

        public DomicilioController(string cadena)
        {
            strCadena = cadena;
        }
        #endregion

        public IEnumerable<DomicilioBase> ObtenerColoniasPorCP(int codPostal)
        {
            IEnumerable<DomicilioBase> lstResultado = new List<DomicilioBase>();
            var sql = @"[rh].[pa_Domicilio_ObtenerColoniaPorCP]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@cp", codPostal);
            try
            {
                using (var connection = new SqlConnection(strCadena))
                {
                    var recRevoc = connection.Query<DomicilioBase>(
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
        public void Dispose()
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AlmacenaDomicilio(DomicilioBase domicilio)
        {
            var sql = @"[rh].[pa_Domicilio_Alta]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idEmpleado", domicilio.IdEmpleado);
            dpParametros.Add("@idColonia", domicilio.IdColonia);
            dpParametros.Add("@cp", domicilio.CP);
            dpParametros.Add("@calle", domicilio.Calle);
            dpParametros.Add("@numExt", domicilio.NumExt);
            dpParametros.Add("@numInt", domicilio.NumInt);
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

        public IEnumerable<DomicilioBase> ObtenerDomicilios(DomicilioBase domicilio)
        {
            IEnumerable<DomicilioBase> lstResultado = new List<DomicilioBase>();
            var sql = @"[rh].[pa_Domicilio_Obtener]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idEmpleado", domicilio.IdEmpleado);
            try
            {
                using (var connection = new SqlConnection(strCadena))
                {
                    var recRevoc = connection.Query<DomicilioBase>(
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
