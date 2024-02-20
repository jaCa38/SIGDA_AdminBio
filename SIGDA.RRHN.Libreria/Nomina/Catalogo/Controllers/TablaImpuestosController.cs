using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Win32;
using Newtonsoft.Json;
using SIGDA.Conexion;
using SIGDA.SRHN.Libreria.Deudo.Models;
using SIGDA.SRHN.Libreria.Nomina.Catalogo.Enums;
using SIGDA.SRHN.Libreria.Nomina.Catalogo.Models;
using SIGDA.SRHN.Libreria.Nomina.Catalogo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Nomina.Catalogo.Controllers
{
    public class TablaImpuestosController : ITablaImpuestosService, IDisposable
    {
        DataTableReader? dtrResultado = null;
        private string? _cadenaConexion;
        public TablaImpuestosController(string cadena)
        {
            _cadenaConexion = cadena;
        }

        public bool AlmacenaTabla(EncabezadoTabla tabla)
        {
            var sql = @"[nomina].[catalogo.pa_Tabla_ISR_SE_Almacena]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@tabla_ISR_SE_json", JsonConvert.SerializeObject(tabla));
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
        public EncabezadoTabla ObtenerTablaVigente(ETipoTabla tipoTabla)
        {
            EncabezadoTabla lstResultado = new EncabezadoTabla();
            var sql = @"[nomina].[catalogo.pa_Tabla_ISR_SE_ObtenerVigente]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idTipoTabla", (int)tipoTabla);
            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var orderDictionary = new Dictionary<int, EncabezadoTabla>();
                    var list = connection.Query<EncabezadoTabla, DetalleTabla, EncabezadoTabla>(
                        sql,
                        map:(order, line) =>
                        {
                            line.IdTabla = order.IdTabla;
                            if (orderDictionary.TryGetValue(order.IdTabla, out EncabezadoTabla existent))
                            {
                                order = existent;
                            }
                            else
                            {
                                order.ListaDetalle = new List<DetalleTabla>();
                                orderDictionary.Add(order.IdTabla, order);
                            }
                            order.ListaDetalle.Add(line);
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

        public void Dispose()
        {
            try { }
            catch (Exception) { }
        }        
    }
        
}
