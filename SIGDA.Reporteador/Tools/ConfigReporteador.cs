using SIGDA.Reporteador.ItextSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SIGDA.Reporteador.Tools
{
    public class ConfigReporteador
    {
        public string NombreArchivo { get; set; }

        public ConfigArchivo ConfigurarArchivo(string esquema, DataTable dtListado)
        {
            ConfigArchivo vconfigArchivo = new ConfigArchivo();
            XDocument XDocNodos = null;
            //****CHECAR DESPUÉS ESTA PROPIEDADES SI SE HACEN DINÁMICAS
            vconfigArchivo.TituloResumen = "Titulo del resumen";
            vconfigArchivo.Resumen = false;
            vconfigArchivo.SuprimeDetalle = false;
            vconfigArchivo.MargenDerecho = (float)1.0 * 15;
            vconfigArchivo.MargenIzquierdo = (float)1.0 * 20;
            vconfigArchivo.MargenInferior = .5f;
            vconfigArchivo.MargenSuperior = .5f;
            vconfigArchivo.BCopiar = true;
            vconfigArchivo.BImprimir = false; //False se puede imprimir el documento, true no se puede imprimir el documento
            vconfigArchivo.BAccesibilidadContenido = true;

            XDocNodos = XDocument.Parse(esquema);
            
            var Cursor = from Valores in XDocNodos.Descendants("configuracionArchivo")
                         select Valores;

            foreach (var Obj in Cursor)
            {
                dtListado.TableName = Obj.Element("nombreArchivo").Value.ToString();
                NombreArchivo = Obj.Element("nombreArchivo").Value.ToString(); //Nombre del archivo sin extensión
                vconfigArchivo.NombreArchivo = Path.Combine(ConnectionStrings.PathReportesTemp, Obj.Element("nombreArchivo").Value.ToString() + Guid.NewGuid().ToString() + ".pdf");
                switch (Obj.Element("tipoHoja").Value.ToString())
                {
                    case "1":
                        vconfigArchivo.TipoHoja = eTipoHoja.Carta;
                        break;
                    case "2":
                        vconfigArchivo.TipoHoja = eTipoHoja.Oficio;
                        break;
                    case "5":
                        vconfigArchivo.TipoHoja = eTipoHoja.Legal;
                        break;
                    case "9":
                        vconfigArchivo.TipoHoja = eTipoHoja.A4;
                        break;
                    default:
                        vconfigArchivo.TipoHoja = eTipoHoja.Carta;
                        break;
                }
                switch (Obj.Element("tipoFuente").Value.ToString())
                {
                    case "1":
                        vconfigArchivo.Fuente = eTipoFuente.Arial;
                        break;
                    case "2":
                        vconfigArchivo.Fuente = eTipoFuente.Tahoma;
                        break;
                    case "3":
                        vconfigArchivo.Fuente = eTipoFuente.TimesNewRoman;
                        break;
                    case "4":
                        vconfigArchivo.Fuente = eTipoFuente.BookAntiqua;
                        break;
                    case "5":
                        vconfigArchivo.Fuente = eTipoFuente.Verdana;
                        break;
                    default:
                        vconfigArchivo.Fuente = eTipoFuente.Arial;
                        break;
                }
                switch (Obj.Element("tamanioFuente").Value.ToString())
                {
                    case "7":
                        vconfigArchivo.SizeFuente = eSizeFuente.Tiny;
                        break;
                    case "8":
                        vconfigArchivo.SizeFuente = eSizeFuente.VerySmall;
                        break;
                    case "9":
                        vconfigArchivo.SizeFuente = eSizeFuente.Small;
                        break;
                    case "10":
                        vconfigArchivo.SizeFuente = eSizeFuente.Medium;
                        break;
                    case "12":
                        vconfigArchivo.SizeFuente = eSizeFuente.Standar;
                        break;
                    case "14":
                        vconfigArchivo.SizeFuente = eSizeFuente.Large;
                        break;
                    default:
                        vconfigArchivo.SizeFuente = eSizeFuente.Small;
                        break;
                }
                switch (Obj.Element("orientacionHoja").Value.ToString())
                {
                    case "1":
                        vconfigArchivo.OrientacionPagina = eOrientacion.Horizontal;
                        break;
                    case "2":
                        vconfigArchivo.OrientacionPagina = eOrientacion.Vertical;
                        break;
                    default:
                        vconfigArchivo.OrientacionPagina = eOrientacion.Vertical;
                        break;
                }
            }
            return vconfigArchivo;
        }

        public ConfigPiePagina ConfigurarPieDePagina()
        {
            ConfigPiePagina vconfigPiePagina = new ConfigPiePagina();
            vconfigPiePagina.Fecha = DateTime.Now.ToShortDateString();
            vconfigPiePagina.Hora = DateTime.Now.ToShortTimeString();
            //vconfigPiePagina.Hora = "08:50:00";
            vconfigPiePagina.AgregarElementoPie("P");
            vconfigPiePagina.AgregarElementoPie("D");
            vconfigPiePagina.AgregarElementoPie("T");
            return vconfigPiePagina;
        }

        public ConfigTablas ConfigurarColumnas(string esquema)
        {
            ConfigTablas vconfigTablas = new ConfigTablas();
            int contador = 0;
            XDocument XDocNodos = null;

            XDocNodos = XDocument.Parse(esquema);

            var Cursor = from Valores in XDocNodos.Descendants("configuracionArchivo")
                         select Valores;

            foreach (var Obj in Cursor)
            {
                vconfigTablas.agregaTabla(Obj.Element("nombreArchivo").Value.ToString(), "", eTipoTabla.Datos, true);
            }

            var CursorColumnas = from Valores in XDocNodos.Descendants("columna")
                                 select Valores;
            foreach (var Obj in CursorColumnas)
            {
                contador++;
                eTipoFuente fuente = eTipoFuente.Arial;
                switch (Obj.Element("fuente").Value.ToString())
                {
                    case "1":
                        fuente = eTipoFuente.Arial;
                        break;
                    case "2":
                        fuente = eTipoFuente.Tahoma;
                        break;
                    case "3":
                        fuente = eTipoFuente.TimesNewRoman;
                        break;
                    case "4":
                        fuente = eTipoFuente.BookAntiqua;
                        break;
                    case "5":
                        fuente = eTipoFuente.Verdana;
                        break;
                    default:
                        fuente = eTipoFuente.Arial;
                        break;
                }

                vconfigTablas.UltimaTabla.VconfigColumnas.agregaColumna(Obj.Element("campo").Value.ToString(),
                                                                        Obj.Element("titulo").Value.ToString(),
                                                                        Obj.Element("alineacion").Value.ToString(),
                                                                        Obj.Element("longitud").Value.ToString(),
                                                                        fuente,
                                                                        Obj.Element("sizeFuente").Value.ToString(), "", "", int.Parse(Obj.Element("contabilizar").Value.ToString()),
                                                                        (Obj.Element("rompimiento").Value.ToString() == "0" ? false : true),
                                                                        Obj.Element("tituloRompimiento").Value.ToString(),
                                                                        eTipoFuente.Arial, "", "", "",
                                                                        (Obj.Element("saltoRompimiento").Value.ToString() == "0" ? false : true));

            }
            return vconfigTablas;
        }
    }
}
