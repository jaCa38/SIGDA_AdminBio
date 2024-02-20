using Dapper;
using Microsoft.Data.SqlClient;
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
    public class NomOrdController : INomOrdService, IDisposable
    {
        DataTableReader? dtrResultado = null;
        private string? _cadenaConexion;

        public NomOrdController(string cadena)
        {
            _cadenaConexion = cadena;
        }
        public void Dispose()
        {
            try { }
            catch (Exception) { }
        }

        public List<ClaveMontoBase> ObtenerInformacionClavesMontos(int anio, long idGral)
        {
            List<ClaveMontoBase> lstResultado = new List<ClaveMontoBase>();
            var sql = @"[asf].[pa_auxTimbresNomOrd_ObtenerInfoClavesMontos]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@anio", anio);
            dpParametros.Add("@idGral", idGral);
            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<ClaveMontoBase>(
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

        public List<EncabezadoNomOrdBase> ObtenerInformacionEncabezado(int anio)
        {
            List<EncabezadoNomOrdBase> lstResultado = new List<EncabezadoNomOrdBase>();
            var sql = @"[asf].[pa_auxTimbresNomOrd_ObtenerInfoEncabezado]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@anio", anio);
            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<EncabezadoNomOrdBase>(
                        sql,
                        dpParametros, commandType: CommandType.StoredProcedure
                        //, splitOn: "IdentificadorElementoIndice"
                        , commandTimeout: 2000
                        ).ToList();
                    lstResultado = recRevoc;
                }
                foreach(EncabezadoNomOrdBase info in lstResultado)
                {
                    List<ClaveMontoBase> lstClaves = ObtenerInformacionClavesMontos(anio, info.IdGeneral);
                    info.LstClaves = lstClaves;
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
