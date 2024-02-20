using SIGDA.Documentos.Factorizadores;
using SIGDA.Documentos.Models;
using SIGDA.Documentos.Services;
using SIGDA.Reporteador.Interfaces;
using SIGDA.Reporteador.ItextSharp;
using SIGDA.Reporteador.Models;
using SIGDA.Reporteador.Services.InterfacesFotocopiado;
using SIGDA.Reporteador.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Reporteador.Controllers
{
    public class FotocopiadoController : BaseReportesController, IReportesService
    {
        #region Constructor Variables
        DataTableReader dtrResultado = null;
        ConfigEncabezado vconfigEncabezado = new ConfigEncabezado();
        ConfigArchivo vconfigArchivo = new ConfigArchivo();
        ConfigTablas vconfigTablas = new ConfigTablas();
        ConfigColumnas vconfigColumnas = new ConfigColumnas();
        ConfigPiePagina vconfigPiePagina = new ConfigPiePagina();
        FormarDoctoPDF vFormarDoctoPDF = null;

        DataTable dtListado = new DataTable();
        DataSet _dtsDatos = new DataSet();
        SqlConexion sql = new SqlConexion();
        ConfigReporteador ConfigReporteador = new ConfigReporteador();

        private string _cadenaConexion = string.Empty;
        public FotocopiadoController() { }
        public FotocopiadoController(string CadenaConexion): base (CadenaConexion)
        {
            _cadenaConexion = CadenaConexion;
        }
        #endregion


        public string ReporteCopiadorasZona(long IdMinerva)
        {
            string URI = string.Empty;
            try
            {
                sql.Conectar(_cadenaConexion);

                List<SqlParameter> _Parametros = new List<SqlParameter>();
                //_Parametros.Add(new SqlParameter("@FechaInicial", Parametro.FechaInicial));
                sql.PrepararProcedimiento("[fotocopiado].[pa_Reporte_CopiadorasZona]", _Parametros);
                dtListado = sql.EjecutarTableReportes();
                if (dtListado.Rows.Count > 0)
                {
                    EnumerFilasDT(ref dtListado);
                    EsquemaReporte esquemaReporte = ConsultarEsquemaReporte(2);
                    vconfigArchivo = ConfigReporteador.ConfigurarArchivo(esquemaReporte.Esquema, dtListado); //CONFIGURO ARCHIVO PDF
                    vconfigTablas = ConfigReporteador.ConfigurarColumnas(esquemaReporte.Esquema); //CONFIGURO COLUMNAS DE LA TABLA
                    vconfigPiePagina = ConfigReporteador.ConfigurarPieDePagina(); //CONFIGURO PIE DE PÁGINA GENERICO
                    _dtsDatos.Tables.Add(dtListado.Copy());

                    vconfigArchivo.TipoReporte = esquemaReporte.TipoReporte;
                    vconfigArchivo.HabilitarHTML = esquemaReporte.HabilitarHTML;
                    vconfigEncabezado.Descripcion1 = esquemaReporte.Descripcion1;
                    vconfigEncabezado.Descripcion2 = esquemaReporte.Descripcion2;
                    vconfigEncabezado.Mostrar = esquemaReporte.MostrarHeader;
                    vconfigPiePagina.TituloFooter = esquemaReporte.TituloFooter;
                    vconfigPiePagina.MostrarOtroTitulo = esquemaReporte.MostrarOtroTitulo;
                    vconfigPiePagina.Mostrar = esquemaReporte.MostrarFooter;
                    vconfigPiePagina.LeyendaAnual = ConnectionStrings.Leyenda;
                    vconfigArchivo.Resumen = esquemaReporte.Resumen;
                    vconfigArchivo.MostrarTotales = esquemaReporte.MostrarTotales;
                    vconfigArchivo.TotalFilas = dtListado.Rows.Count;
                    vconfigArchivo.TituloResumen = esquemaReporte.TituloResumen;

                    vFormarDoctoPDF = new FormarDoctoPDF(vconfigArchivo, vconfigTablas, vconfigColumnas, vconfigEncabezado, vconfigPiePagina, _dtsDatos, dtrResultado);

                    #region Integración de SIGDA.DOCUMENTOS para almacenar archivo temporal
                    URI = ArchivarDocumentoTemporal(IdMinerva, ConfigReporteador, vconfigArchivo);
                    #endregion

                }
                else
                    URI = string.Empty;
                
            }
            catch(SqlException sqlEx)
            {
                throw new Exception(sqlEx.Message, sqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message,ex);
            }
            finally
            {
                dtListado.Dispose();
                _dtsDatos.Dispose();
                sql.Desconectar();
                sql.Dispose();
            }
            return URI;
        }

        #region Métodos privados
       
        #endregion

        #region IDisposable Support
        bool disposedValue = false; // Para detectar llamadas redundantes
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (dtrResultado != null) { dtrResultado.Close(); dtrResultado.Dispose(); }
                    if (dtListado != null)
                    {
                        dtListado.Dispose();
                        dtListado = null;
                    }
                    if (_dtsDatos != null)
                    {
                        _dtsDatos.Dispose();
                        _dtsDatos = null;
                    }
                    // TODO: elimine el estado administrado (objetos administrados).
                    if (sql != null)
                    {
                        sql.Dispose();
                        sql = null;
                    }
                    vconfigEncabezado = null;
                    vconfigArchivo = null;
                    vconfigTablas = null;
                    vconfigColumnas = null;
                    vconfigPiePagina = null;
                }

                // TODO: libere los recursos no administrados (objetos no administrados) y reemplace el siguiente finalizador.
                // TODO: configure los campos grandes en nulos.

                disposedValue = true;
            }
        }

        // TODO: reemplace un finalizador solo si el anterior Dispose(bool disposing) tiene código para liberar los recursos no administrados.
        // ~GestionFamiliarService()
        // {
        //   // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
        //   Dispose(false);
        // }

        // Este código se agrega para implementar correctamente el patrón descartable.
        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
            // GC.SuppressFinalize(this);
        }


        #endregion
    }
}
