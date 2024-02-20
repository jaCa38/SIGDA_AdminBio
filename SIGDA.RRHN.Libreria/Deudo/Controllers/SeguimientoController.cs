using Dapper;
using Microsoft.Win32;
using SIGDA.SRHN.Libreria.Deudo.Models;
using SIGDA.SRHN.Libreria.Deudo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Deudo.Controllers
{
    public class SeguimientoController : ISeguimientoService, IDisposable
    {
        DataTableReader? dtrResultado = null;
        private string? _cadenaConexion;

        public SeguimientoController(string cadena)
        {
            _cadenaConexion = cadena;
        }

        public bool AlmacenarSeguimiento(SeguimientoBase seguimiento)
        {
            var sql = @"[deudo].[pa_Seguimiento_Almacenar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idRegistro", seguimiento.IdRegistro);
            dpParametros.Add("@numOficio", seguimiento.NumOficio);
            dpParametros.Add("@fechaOficio", seguimiento.FechaOficio);
            dpParametros.Add("@idDestino", seguimiento.IdDestino);
            dpParametros.Add("@obs", seguimiento.Observaciones);
            dpParametros.Add("@idUsuario", seguimiento.IdUsuario);
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

        public List<SeguimientoBase> ConsultarSeguimiento(long idRegistro)
        {
            List<SeguimientoBase> lstResultado = new List<SeguimientoBase>();
            var sql = @"[deudo].[pa_Seguimiento_Obtener]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idRegistro", idRegistro);
            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<SeguimientoBase>(
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
            try
            {
            }
            catch (Exception)
            {
            }
        }
    }
}
