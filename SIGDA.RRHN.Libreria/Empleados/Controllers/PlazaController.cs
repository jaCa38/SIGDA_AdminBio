using Dapper;
using Microsoft.Data.SqlClient;
using SIGDA.SRHN.Libreria.Empleados.Interfaces;
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
    public class PlazaController : IPlazaService, IDisposable
    {
        #region Constructor Variables
        DataTableReader? dtrResultado = null;
        private string? strCadena;

        public PlazaController(string cadena)
        {
            strCadena = cadena;
        }
        #endregion
        public bool AlmacenaPlaza(PlazaBase plaza)
        {
            var sql = @"[rh].[pa_Plaza_Almacena]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@identificadorNominaProgress", plaza.IdentificadorNominaProgress);
            dpParametros.Add("@idPlazaNominaProgress", plaza.IdPlazaNominaProgress);
            dpParametros.Add("@denominacion", plaza.Denominacion);
            dpParametros.Add("@funcion", plaza.Funcion);
            dpParametros.Add("@nivel", plaza.Nivel);
            dpParametros.Add("@idSubCentroTrabajo", plaza.IdPrincipal);
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
            try { }
            catch (Exception) { }
        }

        //public PlazaBase ObtenerPlaza(PlazaBase plaza)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<PlazaBase> ObtenerPlazasByCT(PlazaBase ct)
        {
            IEnumerable<PlazaBase> lstResultado = new List<PlazaBase>();
            var sql = @"[rh].[pa_Plaza_ObtenerPlazasByCT]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idSubCT", ct.IdPrincipal);
            try
            {
                using (var connection = new SqlConnection(strCadena))
                {
                    var recRevoc = connection.Query<PlazaBase>(
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
