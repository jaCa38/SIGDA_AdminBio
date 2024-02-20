using Dapper;
using Microsoft.Data.SqlClient;
using SIGDA.Catalogos.Genericos.Models;

using SIGDA.Catalogos.Genericos.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Catalogos.Catalogo.Models
{
    public class CatalogoBase : CatalogoBaseModel
    {
        private string _cadenaConexion = string.Empty;
        public CatalogoBase() { }
        public CatalogoBase(string CadenaConexion) => _cadenaConexion = CadenaConexion;

        public override bool AlmacenaInformacionPrimeraVez(List<CatalogoBaseModel> lista)
        {
            string listaItems = string.Empty;
            CatalogoBaseModel esquema = new CatalogoBaseModel();
            esquema.Esquema = lista[0].Esquema.Split('.')[0];
            esquema.DescripPrincipal = lista[0].Esquema.Split('.')[1];
            foreach(CatalogoBaseModel cat in lista)
            {
                listaItems += cat.IdPrincipal.ToString() + "|" + cat.IdRelacion.ToString() + "|" + cat.DescripPrincipal + "?";
            }
            listaItems = listaItems.Substring(0, listaItems.Length - 1);
            var sql = @"[catalogo].[pa_Catalogo_AlmacenarItems]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@esquema", esquema.Esquema);
            dpParametros.Add("@descripcion", esquema.DescripPrincipal);
            dpParametros.Add("@items", listaItems);            
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
        public override List<CatalogoBaseModel> ObtenerCatalogo(CatalogoBaseModel catalogo)
        {
            List<CatalogoBaseModel> lstResultado = new List<CatalogoBaseModel>();
            var sql = @"[catalogo].[pa_Catalogo_ObtenerItems]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@esquema", catalogo.Esquema);
            dpParametros.Add("@descripcion", catalogo.DescripPrincipal);
            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<CatalogoBaseModel>(
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
    }
}
