using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Win32;
using SIGDA.Conexion;
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
    public class EstudioAcademicoController : IEstudioAcademicoService, IDisposable
    {
        DataTableReader? dtrResultado = null;
        private string? strCadena;

        public EstudioAcademicoController(string cadena)
        {
            strCadena = cadena;
        }
        public bool AlmacenaEstudio(EstudioAcademicoBase estudio)
        {
            var sql = @"[cv].[pa_EstudioAcademico_Almacena]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idEmpleado", estudio.IdEmpleado);
            dpParametros.Add("@idNivel", estudio.IdNivelAcademico);
            dpParametros.Add("@mes", estudio.MesGrado);
            dpParametros.Add("@anio", estudio.AnioGrado);
            dpParametros.Add("@institucion", estudio.Institucion);
            dpParametros.Add("@titulo", estudio.Titulo);
            dpParametros.Add("@hrs", estudio.Horas);
            dpParametros.Add("@cedProf", estudio.CedulaProfesional);
            dpParametros.Add("@idMunicipio", estudio.IdMuncipio);
            dpParametros.Add("@otroMunicipio", estudio.Ubicacion);
            dpParametros.Add("@idEstatus", estudio.IdEstatusEstudio);
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

        public bool EliminaEstudio(EstudioAcademicoBase estudio)
        {
            var sql = @"[cv].[pa_EstudioAcademico_Elimina]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idEstudio", estudio.IdEstudio);            
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

        public EstudioAcademicoBase MaximoEstudioAcademico(long idEmpleado)
        {
            List<EstudioAcademicoBase> lstResultado = new List<EstudioAcademicoBase>();
            var sql = @"[cv].[pa_EstudioAcademico_MaximoNivelEstudio]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idEmpleado", idEmpleado);
            try
            {
                using (var connection = new SqlConnection(strCadena))
                {
                    var recRevoc = connection.Query<EstudioAcademicoBase>(sql,
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

        public bool ModificaEstudio(EstudioAcademicoBase estudio)
        {
            var sql = @"[cv].[pa_EstudioAcademico_Actualiza]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idEstudio", estudio.IdEstudio);
            dpParametros.Add("@idEmpleado", estudio.IdEmpleado);
            dpParametros.Add("@idNivel", estudio.IdNivelAcademico);
            dpParametros.Add("@mes", estudio.MesGrado);
            dpParametros.Add("@anio", estudio.AnioGrado);
            dpParametros.Add("@institucion", estudio.Institucion);
            dpParametros.Add("@titulo", estudio.Titulo);
            dpParametros.Add("@hrs", estudio.Horas);
            dpParametros.Add("@cedProf", estudio.CedulaProfesional);
            dpParametros.Add("@idMunicipio", estudio.IdMuncipio);
            dpParametros.Add("@otroMunicipio", estudio.Ubicacion);
            dpParametros.Add("@idEstatus", estudio.IdEstatusEstudio);
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

        public EstudioAcademicoBase ObtenerEstudio(long idEstudio, long idEmpleado)
        {
            List<EstudioAcademicoBase> lst = ObtenerEstudios(idEmpleado);
            return lst.FindLast(x => x.IdEstudio == idEstudio);
        }

        public List<EstudioAcademicoBase> ObtenerEstudios(long idEmpleado)
        {
            List<EstudioAcademicoBase> lstResultado = new List<EstudioAcademicoBase>();
            var sql = @"[cv].[pa_EstudioAcademico_ObtenerTodos]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idEmpleado", idEmpleado);            
            try
            {
                using (var connection = new SqlConnection(strCadena))
                {
                    var recRevoc = connection.Query<EstudioAcademicoBase>( sql,
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
    }
}
