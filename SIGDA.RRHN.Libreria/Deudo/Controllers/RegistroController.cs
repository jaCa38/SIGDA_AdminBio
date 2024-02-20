using Dapper;
using Microsoft.Win32;
using SIGDA.Conexion;
using SIGDA.SRHN.Libreria.Deudo.Models;
using SIGDA.SRHN.Libreria.Deudo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Deudo.Controllers
{
    public class RegistroController : IRegistroService, IDisposable
    {
        DataTableReader? dtrResultado = null;
        private string? _cadenaConexion;

        public RegistroController(string cadena)
        {
            _cadenaConexion = cadena;
        }

        public bool AlmacenaRegistro(RegistroBase registro)
        {
            var sql = @"[deudo].[pa_Registro_Almacenar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idEmpleado", registro.IdEmpleado);
            dpParametros.Add("@monto", registro.MontoAdeudo);
            dpParametros.Add("@idConcepto", registro.IdConcepto);
            dpParametros.Add("@obs", registro.Observaciones);
            dpParametros.Add("@idUsuario", registro.IdUsuario);
            dpParametros.Add("@listaFechas", registro.ListaFechas);
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

        public List<RegistroBase> ConsultarRegistros()
        {
            List<RegistroBase> lstResultado = new List<RegistroBase>();
            var sql = @"[deudo].[pa_Registro_Obtener]";
            var dpParametros = new DynamicParameters();
            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<RegistroBase>(
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

        public List<RegistroBase> ConsultarRegistrosFiltro(long id)
        {
            List<RegistroBase> lista = ConsultarRegistros();
            return lista.Where(x => x.IdRegistro == id).ToList();
        }

        
        public bool EliminaRegistro(long idRegistro)
        {
            var sql = @"[deudo].[pa_Registro_Eliminar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idRegistro", idRegistro);
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

        public bool ModificaRegistro(RegistroBase registro)
        {
            var sql = @"[deudo].[pa_Registro_Actualizar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idRegistro", registro.IdRegistro);
            dpParametros.Add("@idConcepto", registro.IdConcepto);
            dpParametros.Add("@monto", registro.MontoAdeudo);
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
        public bool SaldarRegistro(RegistroBase registro)
        {
            var sql = @"[deudo].[pa_Registro_Saldar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idRegistro", registro.IdRegistro);
            dpParametros.Add("@idTipoRecuperacion", registro.IdTipoRecuperacion);
            dpParametros.Add("@idUsuario", registro.IdUsuario);
            dpParametros.Add("@obs", registro.Observaciones);
            dpParametros.Add("@fecha", registro.Fecha);
            dpParametros.Add("@monto", registro.MontoAdeudo);
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
            try
            {

            }
            catch (Exception)
            {

            }
        }
        public bool ModificaAdeudoPendiente(RegistroBase registro)
        {
            var sql = @"[deudo].[pa_Registro_ModificarAdeudoPendiente]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idRegistro", registro.IdRegistro);            
            dpParametros.Add("@monto", registro.MontoAdeudo);
            dpParametros.Add("@idUsuario", registro.IdUsuario);
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
    }
}
