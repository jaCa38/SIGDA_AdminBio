using Dapper;
using Microsoft.Data.SqlClient;
using SIGDA.Catalogos.Genericos.Models;
using SIGDA.Catalogos.Genericos.Services.Interfaces;
using SIGDA.SRHN.Libreria.Catalogos.SubCentrosTrabajo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Catalogos.Curriculum.Controllers
{
    public class NivelAcademicoController: INivelAcademicoService
    {
        DataTableReader? dtrResultado = null;
        private string? _cadenaConexion;

        public NivelAcademicoController(string cadena)
        {
            _cadenaConexion = cadena;
        }

        public void Dispose()
        {
            try { } catch (Exception) { }
        }

        public List<BaseModel> ObtenerEstatusEstudio()
        {
            List<BaseModel> lstResultado = new List<BaseModel>();
            var sql = @"[cv].[pa_Catalogo_ObtenerEstatusEstudio]";
            var dpParametros = new DynamicParameters();
            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<BaseModel>(sql, dpParametros, commandType: CommandType.StoredProcedure,
                        commandTimeout: 2000).ToList();
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

        List<BaseModel> INivelAcademicoService.ObtenerNivelesAcademicos()
        {
            List<BaseModel> lstResultado = new List<BaseModel>();
            var sql = @"[cv].[pa_Catalogo_ObtenerNivelAcademico]";
            var dpParametros = new DynamicParameters();
            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<BaseModel>(sql, dpParametros, commandType: CommandType.StoredProcedure,
                        commandTimeout: 2000).ToList();
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
    }
}
