using Dapper;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using SIGDA.SRHN.Libreria.Deudo.Models;
using SIGDA.SRHN.Libreria.Nomina.Catalogo.Enums;
using SIGDA.SRHN.Libreria.Nomina.Catalogo.Models;
using SIGDA.SRHN.Libreria.Nomina.Catalogo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Nomina.Catalogo.Controllers
{
    public class TabuladorController : ITabuladorService, IDisposable
    {
        DataTableReader? dtrResultado = null;
        private string? _cadenaConexion;
        public TabuladorController(string cadena)
        {
            _cadenaConexion = cadena;
        }

        public bool AlmacenaTabulador(TabuladorBase tabulador)
        {
            var sql = @"[nomina].[catalogo.pa_Tabulador_Almacena]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@json", JsonConvert.SerializeObject(tabulador));
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
            try { }
            catch (Exception) { }
        }

        public TabuladorBase ObtenerTabuladorVigente()
        {
            TabuladorBase tabulador = ObtenerTabuladorVigenteNivel01();
            List<ClaveImporteBase> lstClaves = ObtenerTabuladorVigenteNivel02();
            foreach(DetalleTabuladorBase det in tabulador.ListaDetalleTabulador)
            {
                det.ListaClavesImportes = lstClaves.FindAll(x => x.IdDetalle == det.IdDetalle);
            }
            return tabulador;
        }

        private TabuladorBase ObtenerTabuladorVigenteNivel01() 
        {
            TabuladorBase lstResultado = new TabuladorBase();
            var sql = @"[nomina].[catalogo.pa_Tabulador_ObtenerVigente_Nivel01]";
            var dpParametros = new DynamicParameters();
            //dpParametros.Add("@idTipoTabla", (int)tipoTabla);
            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var orderDictionary = new Dictionary<int, TabuladorBase>();
                    var list = connection.Query<TabuladorBase, DetalleTabuladorBase, TabuladorBase>(
                        sql,
                        map: (order, line) =>
                        {
                            line.IdTabla = order.IdTabla;
                            if (orderDictionary.TryGetValue(order.IdTabla, out TabuladorBase existent))
                            {
                                order = existent;
                            }
                            else
                            {
                                order.ListaDetalleTabulador = new List<DetalleTabuladorBase>();
                                orderDictionary.Add(order.IdTabla, order);
                            }
                            order.ListaDetalleTabulador.Add(line);
                            return order;
                        }
                        , dpParametros
                        , splitOn: "IdTabla"
                        , commandTimeout: 2000
                        , commandType: CommandType.StoredProcedure
                        ).Distinct().ToList();
                    lstResultado = list.First();
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
        private List<ClaveImporteBase> ObtenerTabuladorVigenteNivel02()
        {
            List<ClaveImporteBase> lstResultado = new List<ClaveImporteBase>();
            var sql = @"[nomina].[catalogo.pa_Tabulador_ObtenerVigente_Nivel02]";
            var dpParametros = new DynamicParameters();
            //dpParametros.Add("@idRegistro", idRegistro);
            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<ClaveImporteBase>(
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
