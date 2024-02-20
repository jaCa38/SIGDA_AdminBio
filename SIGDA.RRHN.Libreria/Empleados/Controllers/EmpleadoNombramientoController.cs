using Dapper;
using SIGDA.Conexion;
using SIGDA.SRHN.Libreria.Empleados.Models;
using SIGDA.SRHN.Libreria.Empleados.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SIGDA.SRHN.Libreria.Empleados.Controllers
{
    public class EmpleadoNombramientoController : IEmpleadoNombramientoService, IDisposable
    {
        #region Constructor Variables
        DataTableReader? dtrResultado = null;
        private string? strCadena;

        public EmpleadoNombramientoController(string cadena)
        {
            strCadena = cadena;
        }
        #endregion

        public IEnumerable<BaseCandidato> BuscarCandidato(string nombre, string paterno, string materno)
        {
            IEnumerable<BaseCandidato> lstResultado = new List<BaseCandidato>();

            var sql = @"[dbo].[pa_Candidato_Busqueda]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@Nombre", nombre);
            dpParametros.Add("@Paterno", paterno);
            dpParametros.Add("@Materno", materno);
            try
            {   
                using (var connection = new SqlConnection(strCadena))
                {
                    var recRevoc = connection.Query<BaseCandidato>(
                        sql,
           dpParametros, commandType: CommandType.StoredProcedure
           //, splitOn: "IdentificadorElementoIndice"
           , commandTimeout: 2000
           ).ToList();
                    //lstResultado = recRevoc.OrderBy(x => x.DescripPrincipal).ToList();
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
        public long InsertarNuevoEmpleado(EmpleadoNombramiento empleadoNombramiento, long IdMinerva)
        {
            var sql = @"[sigda].[pa_Empleado_Base_Insertar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@siem_sigein_ID_CANDIDATO", empleadoNombramiento.IdCandidato);
            dpParametros.Add("@siem_nombre", empleadoNombramiento.NombreEmpleado.Trim().ToUpper());
            dpParametros.Add("@siem_paterno", empleadoNombramiento.PaternoEmpleado.Trim().ToUpper());

            dpParametros.Add("@siem_materno", empleadoNombramiento.MaternoEmpleado.Trim().ToUpper());
            dpParametros.Add("@siem_idEstatusEmpleado", 1);
            dpParametros.Add("@siem_usuario_registro", IdMinerva);

            try
            {
                using (var connection = new SqlConnection(strCadena))
                {
                    var rowsAf = connection.ExecuteScalar<long>(sql, dpParametros, commandType: CommandType.StoredProcedure, commandTimeout: 2000);
                    return rowsAf;
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
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        public BaseEmpleado ObtenerUltimaActualizacionCV(long idEmpleado)
        {
            List<BaseEmpleado> lstResultado = new List<BaseEmpleado>();
            var sql = @"[cv].[pa_UltimaActualizacionCV]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idEmpleado", idEmpleado);
            try
            {
                using (var connection = new SqlConnection(strCadena))
                {
                    var recRevoc = connection.Query<BaseEmpleado>(sql,
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
        public IEnumerable<BaseCandidato> BuscarCandidatoPorRFC(string rfc)
        {
            IEnumerable<BaseCandidato> lstResultado = new List<BaseCandidato>();
            var sql = @"[dbo].[pa_Candidato_BusquedaPorRFC]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@Rfc", rfc);
            try
            {
                using (var connection = new SqlConnection(strCadena))
                {
                    var recRevoc = connection.Query<BaseCandidato>(
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
        public IEnumerable<BaseCandidato> BuscarCandidatoPorCURP(string curp)
        {
            IEnumerable<BaseCandidato> lstResultado = new List<BaseCandidato>();
            var sql = @"[dbo].[pa_Candidato_BusquedaPorCURP]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@curp", curp);
            try
            {
                using (var connection = new SqlConnection(strCadena))
                {
                    var recRevoc = connection.Query<BaseCandidato>(
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
        public IEnumerable<DomicilioBase> BuscarDomicilioCandidatoPorRFC(string rfc)
        {
            IEnumerable<DomicilioBase> lstResultado = new List<DomicilioBase>();
            var sql = @"[dbo].[pa_Candidato_BusquedaPorRFC]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@Rfc", rfc);
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
        public IEnumerable<DomicilioBase> BuscarDomicilioCandidatoPorCURP(string curp)
        {
            IEnumerable<DomicilioBase> lstResultado = new List<DomicilioBase>();
            var sql = @"[dbo].[pa_Candidato_BusquedaPorCURP]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@curp", curp);
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
        public int AlmacenaNuevoEmpleado(NuevoEmpleadoBase datosEmpleado)
        {
            int numEmpleado = 0;
            var sql = @"[rh].[pa_Empleado_Alta]";
            var dpParametros = new DynamicParameters();            
            dpParametros.Add("@datosGralesCandidato_json", JsonConvert.SerializeObject(datosEmpleado.DatosCandidato));
            dpParametros.Add("@datosDomicilio_json", JsonConvert.SerializeObject(datosEmpleado.DatosDomicilio));
            dpParametros.Add("@datosTelefonos_json", JsonConvert.SerializeObject(datosEmpleado.ListaTelefonos));
            dpParametros.Add("@datosMails_json", JsonConvert.SerializeObject(datosEmpleado.CorreosElectronicos));
            dpParametros.Add("@datosPuesto_json", JsonConvert.SerializeObject(datosEmpleado.DatosPuesto));
            dpParametros.Add("@idEmpleado", DbType.Int32, direction: ParameterDirection.Output);
            try
            {
                using (var connection = new SqlConnection(strCadena))
                {
                    var recRevoc = connection.Execute(
                        sql,
                       dpParametros, commandType: CommandType.StoredProcedure
                       //, splitOn: "IdentificadorElementoIndice"
                       , commandTimeout: 2000
                       );
                    var b = dpParametros.Get<int>("@idEmpleado");
                    numEmpleado = b;
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
            return numEmpleado;
        }
        
    }
}
