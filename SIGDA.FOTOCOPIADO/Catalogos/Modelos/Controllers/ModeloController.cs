using Dapper;
using Microsoft.Data.SqlClient;
using SIGDA.Conexion;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.Modelos.Models;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.Modelos.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Catalogos.Modelos.Controllers
{
    public  class ModeloController: IModeloService, IDisposable
    {
        #region Constructor Variables
        DataTableReader? dtrResultado = null;
        private string? strCadena;

        public ModeloController(string cadena)
        {
            strCadena = cadena;
        }
        #endregion

        public bool ActualizarModelo(long IdModelo, string Descripcion, long IdMarca)
        {
            var sql = @"[catalogo].[pa_Modelos_Actualizar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@IdModelo", IdModelo);
            dpParametros.Add("@DescripcionModelo", Descripcion);
            dpParametros.Add("@IdMarca", IdMarca);

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

        public ModelosBase ConsultarModeloFiltroId(long IdModelo)
        {
            ModelosBase Resultado = new ModelosBase();

            var sql = @"[catalogo].[pa_Modelos_Consultar]";
            var dpParametros = new DynamicParameters();

            try
            {
                using (var connection = new SqlConnection(strCadena))
                {
                    var recRevoc = connection.Query<ModelosBase>(
                        sql,
           dpParametros, commandType: CommandType.StoredProcedure
           //, splitOn: "IdentificadorElementoIndice"
           , commandTimeout: 2000
           ).ToList();
                    Resultado = recRevoc.First(x => x.IdentificadorModelo == IdModelo);
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

            return Resultado;
        }

        public List<ModelosBase> ConsultarModelos()
        {
            List<ModelosBase> lstResultado = new List<ModelosBase>();

            var sql = @"[catalogo].[pa_Modelos_Consultar]";
            var dpParametros = new DynamicParameters();

            try
            {
                using (var connection = new SqlConnection(strCadena))
                {
                    var recRevoc = connection.Query<ModelosBase>(
                        sql,
           dpParametros, commandType: CommandType.StoredProcedure
           //, splitOn: "IdentificadorElementoIndice"
           , commandTimeout: 2000
           ).ToList();
                    lstResultado = recRevoc.OrderBy(x => x.IdentificadorModelo).OrderBy(x => x.IdentificadorMarca).ToList();
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

        public bool DesactivarModelo(long IdModelo)
        {
            var sql = @"[catalogo].[pa_Modelos_Desactivar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@IdModelo", IdModelo);

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

        public bool InsertarModelo(string Descripcion, long IdMarca)
        {
            var sql = @"[catalogo].[pa_Modelos_Insertar]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@DescripcionModelo", Descripcion);
            dpParametros.Add("@IdMarca", IdMarca);

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
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ModelosBase> ConsultarModeloPorMarca(long IdMarca)
        {
            List<ModelosBase> lstResultado = new List<ModelosBase>();

            var sql = @"[catalogo].[pa_Modelos_Consultar]";
            var dpParametros = new DynamicParameters();

            try
            {
                using (var connection = new SqlConnection(strCadena))
                {
                    var recRevoc = connection.Query<ModelosBase>(
                        sql,
           dpParametros, commandType: CommandType.StoredProcedure
           //, splitOn: "IdentificadorElementoIndice"
           , commandTimeout: 2000
           ).ToList();
                    lstResultado = recRevoc.Where(x => x.IdentificadorMarca == IdMarca).ToList();
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
