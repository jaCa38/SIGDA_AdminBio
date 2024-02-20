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
    public class InformacionLaboralController : IInformacionLaboralService, IDisposable
    {
        DataTableReader? dtrResultado = null;
        private string? strCadena;

        public InformacionLaboralController(string cadena)
        {
            strCadena = cadena;
        }

        public bool AlmacenaLaboral(InformacionLaboralBase info)
        {
            var sql = @"[cv].[pa_InfoLaboral_Actualiza]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idEmpleado", info.IdEmpleado);
            dpParametros.Add("@puesto", info.Puesto);
            dpParametros.Add("@mesInicio", info.MesDesde);
            dpParametros.Add("@anioInicio", info.AnioDesde);
            dpParametros.Add("@mesFin", info.MesHasta);
            dpParametros.Add("@anioFin", info.AnioHasta);
            dpParametros.Add("@institucion", info.Institucion);
            dpParametros.Add("@idMunicipio", info.IdMunicipio);
            dpParametros.Add("@otroMunicipio", info.Ubicacion);
            dpParametros.Add("@actividades", info.Actividades);
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

        public bool EliminaLaboral(InformacionLaboralBase info)
        {
            var sql = @"[cv].[pa_InfoLaboral_Elimina]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idLaboral", info.IdLaboral);            
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

        public bool ModificaLaboral(InformacionLaboralBase info)
        {
            var sql = @"[cv].[pa_InfoLaboral_Actualiza]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idLaboral", info.IdLaboral);
            dpParametros.Add("@idEmpleado", info.IdEmpleado);
            dpParametros.Add("@puesto", info.Puesto);
            dpParametros.Add("@mesInicio", info.MesDesde);
            dpParametros.Add("@anioInicio", info.AnioDesde);
            dpParametros.Add("@mesFin", info.MesHasta);
            dpParametros.Add("@anioFin", info.AnioHasta);
            dpParametros.Add("@institucion", info.Institucion);
            dpParametros.Add("@idMunicipio", info.IdMunicipio);
            dpParametros.Add("@otroMunicipio", info.Ubicacion);
            dpParametros.Add("@actividades", info.Actividades);            
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

        public List<InformacionLaboralBase> ObtenerInformacionLaboral(long idEmpleado)
        {
            List<InformacionLaboralBase> lstResultado = new List<InformacionLaboralBase>();
            var sql = @"[cv].[pa_InfoLaboral_ObtenerTodos]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idEmpleado", idEmpleado);
            try
            {
                using (var connection = new SqlConnection(strCadena))
                {
                    var recRevoc = connection.Query<InformacionLaboralBase>(sql,
                           dpParametros, commandType: CommandType.StoredProcedure
                        //, splitOn: "IdentificadorElementoIndice"
                        , commandTimeout: 2000).ToList();
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

        public InformacionLaboralBase ObtenerLaboral(InformacionLaboralBase info)
        {
            List<InformacionLaboralBase> lst = ObtenerInformacionLaboral(info.IdEmpleado);
            return lst.FindLast(x => x.IdLaboral == info.IdLaboral);
        }
        public void Dispose()
        {
            try { } catch (Exception) { }
        }

        public InformacionLaboralBase ObtenerLaboralUnaLinea(long idEmpleado)
        {
            List<InformacionLaboralBase> lstResultado = new List<InformacionLaboralBase>();
            var sql = @"[cv].[pa_InfoLaboral_UnaLinea]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idEmpleado", idEmpleado);
            try
            {
                using (var connection = new SqlConnection(strCadena))
                {
                    var recRevoc = connection.Query<InformacionLaboralBase>(sql,
                           dpParametros, commandType: CommandType.StoredProcedure
                        //, splitOn: "IdentificadorElementoIndice"
                        , commandTimeout: 2000).ToList();
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
            return lstResultado[0];
        }
    }
}
