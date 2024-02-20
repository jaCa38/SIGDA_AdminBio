using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Win32;
using SIGDA.SRHN.Libreria.ASF.Models;
using SIGDA.SRHN.Libreria.ASF.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.ASF.Controllers
{
    public class DesafectacionController : IDesafectacionService, IDisposable
    {
        DataTableReader? dtrResultado = null;
        private string? _cadenaConexion;

        public DesafectacionController(string cadena)
        {
            _cadenaConexion = cadena;
        }
        public bool AlmacenaInformacion(EmpleadoDesafectacionBase encabezado, List<DetalleDesafectacion> detalle)
        {
            string infoDetalle = string.Empty;
            string infoEncabezado = encabezado.IdEmpleado.ToString() + "|" + encabezado.EsHonorarios.ToString() + "|" +
                encabezado.Serie + "|" + encabezado.AnioQuincena.ToString() + "|" +
                encabezado.Funcion + "|" + encabezado.Puesto + "|" + encabezado.Nivel + "|" + encabezado.Antiguedad;

            foreach(DetalleDesafectacion det in detalle)
            {
                infoDetalle += det.IdClave.ToString() + "|" + det.Gravado.ToString() + "|" + 
                    det.Exento.ToString() + "|" + det.IdTipoClave.ToString() + "?";
            }
            infoDetalle = infoDetalle.Substring(0, infoDetalle.Length - 1);

            var sql = @"[nom].[pa_Desafectacion_AlmacenaInfo]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@encabezado", infoEncabezado);
            dpParametros.Add("@detalle", infoDetalle);
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

        public List<EmpleadoDesafectacionBase> BuscarCoincidenciaEmpleado(EmpleadoDesafectacionBase empleado)
        {
            List<EmpleadoDesafectacionBase> lstResultado = new List<EmpleadoDesafectacionBase>();
            var sql = @"[nom].[pa_Desafectacion_BusquedaPersonalTimbrado]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@anio", empleado.AnioQuincena);
            dpParametros.Add("@cve", empleado.IdEmpleado);
            dpParametros.Add("@nombre", empleado.Nombre);
            dpParametros.Add("@paterno", empleado.Paterno);
            dpParametros.Add("@materno", empleado.Materno);            
            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<EmpleadoDesafectacionBase>(
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

        public List<EmpleadoDesafectacionBase> Obtener(int anio)
        {
            List<EmpleadoDesafectacionBase> lstResultado = new List<EmpleadoDesafectacionBase>();
            var sql = @"[nom].[pa_Desafectacion_ObtenerEncabezado]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@anio", anio);            
            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<EmpleadoDesafectacionBase>(
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

        public EmpleadoDesafectacionBase ObtenerUno(long IdGeneral, int anio)
        {
            List<EmpleadoDesafectacionBase> lst = Obtener(anio);
            return lst.FindLast(x => x.IdGeneral == IdGeneral);
        }
        public void Dispose()
        {
            try { }
            catch (Exception) { }
        }
    }
}
