using Dapper;
using Microsoft.Data.SqlClient;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.TipoCopia.Models;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.TipoCopia.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Catalogos.TipoCopia.Controllers
{
    public class TipoCopiaController: ITipoCopiaService, IDisposable
    {
        #region Constructor Variables
        DataTableReader? dtrResultado = null;
        private string? strCadena;

        public TipoCopiaController(string cadena)
        {
            strCadena = cadena;
        }
        #endregion
        public List<TipoCopiaBase> ConsultarTiposCopia()
        {
            List<TipoCopiaBase> lstResultado = new List<TipoCopiaBase>();

            var sql = @"[catalogo].[pa_TiposCopia_Consultar]";
            var dpParametros = new DynamicParameters();

            try
            {
                using (var connection = new SqlConnection(strCadena))
                {
                    var recRevoc = connection.Query<TipoCopiaBase>(
                        sql,
           dpParametros, commandType: CommandType.StoredProcedure
           //, splitOn: "IdentificadorElementoIndice"
           , commandTimeout: 2000
           ).ToList();
                    lstResultado = recRevoc.OrderBy(x => x.DescripcionTipoCopia).ToList();
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
