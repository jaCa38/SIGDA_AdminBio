using Dapper;
using Microsoft.Data.SqlClient;

using SIGDA.FOTOCOPIADO.Libreria.Catalogos.CentrosTrabajo.Models;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.CentrosTrabajo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Catalogos.CentrosTrabajo.Controllers
{
    public class CentroTrabajoController : ICentroTrabajoService, IDisposable
    {
        #region Constructor Variables
        DataTableReader? dtrResultado = null;
        private string? strCadena;
        private string _cadenaConexion = string.Empty;
        public CentroTrabajoController() { }
        public CentroTrabajoController(string CadenaConexion) => _cadenaConexion = CadenaConexion;
        #endregion

        public List<CentroTrabajoSAPBase> Consultar()
        {
            List<CentroTrabajoSAPBase> lstResultado = new List<CentroTrabajoSAPBase>();

            var sql = @"[catalogo].[pa_Centros401SAP_Consultar]";
            var dpParametros = new DynamicParameters();

            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<CentroTrabajoSAPBase>(
                        sql,
           dpParametros, commandType: CommandType.StoredProcedure
           //, splitOn: "IdentificadorElementoIndice"
           , commandTimeout: 2000
           ).ToList();
                    lstResultado = recRevoc.OrderBy(x => x.IdentificadorCCS).ToList();
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

                throw;
            }
        }
     
    }
}
