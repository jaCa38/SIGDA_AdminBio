using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Win32;
using SIGDA.SRHN.Libreria.Asistencia.Enums;
using SIGDA.SRHN.Libreria.Asistencia.Models;
using SIGDA.SRHN.Libreria.Asistencia.Services.Interfaces;
using SIGDA.Conexion;
using SIGDA.SRHN.Libreria.Deudo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Asistencia.Controllers
{
    public class CatalogoController : ICatalogoService, IDisposable
    {
        #region Constructor Variables
        DataTableReader? dtrResultado = null;
        private string? _cadenaConexion;

        public CatalogoController(string cadena)
        {
            _cadenaConexion = cadena;
        }
        #endregion
        public List<CatalogoBase> ObtenerCatalogoAsistencia(ETipoCatalogo catalogo)
        {
            List<CatalogoBase> lstResultado = new List<CatalogoBase>();
            var sql = @"[cat].[pa_Catalogo_ObtenerItems]";
            var dpParametros = new DynamicParameters();
            string esquema = string.Empty, descripcion = string.Empty;
            switch (catalogo)
            {
                case ETipoCatalogo.CatEstatus:
                    esquema = "cat";
                    descripcion = "estatus";
                    break;
                case ETipoCatalogo.CatTipoDescuento:
                    esquema = "cat";
                    descripcion = "tipoDescuento";
                    break;
                case ETipoCatalogo.AsistenciaEstatus:
                    esquema = "asistencia";
                    descripcion = "estatus";
                    break;               
            }
            dpParametros.Add("@esquema", esquema);
            dpParametros.Add("@descripcion", descripcion);
            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<CatalogoBase>(
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
            try { } catch (Exception) { }
        }

        
    }
}
