using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Win32;
using SIGDA.SRHN.Libreria.ASF.Models;
using SIGDA.SRHN.Libreria.ASF.Services.Interfaces;
using SIGDA.SRHN.Libreria.Deudo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.ASF.Controllers
{
    public class CuotaController : ICuotasService, IDisposable
    {
        DataTableReader? dtrResultado = null;
        private string? _cadenaConexion;

        public CuotaController(string cadena)
        {
            _cadenaConexion = cadena;
        }

        public bool AlmacenarInformacion(List<CuotaISSEGISSSTEBase> cuotas)
        {
            string datos = string.Empty;
            foreach(CuotaISSEGISSSTEBase dato in cuotas)
            {
                datos += dato.Importe.ToString() + "|" + dato.Texto.Trim() + "|" + dato.PosPre.Trim() + "|" + dato.CentroGestor.Trim() + "|" +
                    dato.Fondo.Trim() + "|" + dato.AreaFuncional.Trim() + "|" + dato.ElementoPEP.Trim() + "|" + dato.CuentaMayor.Trim() + "|" +
                    dato.CentroCosto.Trim() + "?";
            }
            datos = datos.Substring(0, datos.Length - 1);
            var sql = @"[asf].[pa_CuotasISSEGISSSTE_Almacena]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idQuincena", cuotas[0].IdQuincena);
            dpParametros.Add("@anioQuincena", cuotas[0].AnioQuincena);
            dpParametros.Add("@datos", datos);
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
            try { }
            catch (Exception) { }            
        }

        public List<CuotaISSEGISSSTEBase> ObtenerInformacion(CuotaISSEGISSSTEBase identificadorQna)
        {
            List<CuotaISSEGISSSTEBase> lstResultado = new List<CuotaISSEGISSSTEBase>();
            var sql = @"[asf].[pa_CuotasISSEGISSSTE_Obtener]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idQuincena", identificadorQna.IdQuincena);
            dpParametros.Add("@anioQuincena", identificadorQna.AnioQuincena);
            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<CuotaISSEGISSSTEBase>(
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
    }
}
