using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace SIGDA.Reporteador.ItextSharp
{
    public class FormarDoctoPDF
    {
        ConfigArchivo _configArchivo;
        ConfigTablas _configTablas;
        ConfigColumnas _configColumnas;
        ConfigEncabezado _configEncabezado;
        ConfigPiePagina _configPiePagina;
        DataTableReader _dtrDatos;
        RepoRecepcion _reporteODP;
        ReporteCaratula _reporteCaratula;
        DataSet _dtsDatos;

        public ConfigArchivo ConfiguracionArchivo { set; get; }
        public ConfigTablas ConfiguracionTablas { set; get; }
        public ConfigColumnas ConfiguracionColumnas { set; get; }
        public ConfigEncabezado ConfiguracionEncabezado { set; get; }
        public ConfigPiePagina ConfiguracionPiePagina { set; get; }

        //variables para formar el docto
        int[] alineacionColumnas;
        float[] anchoColumnas;
        string[] nombrefuenteColumnas;
        string[] tamañofuenteColumnas;
        //Almacenar los valores de un registro al recorrerlos
        String[] valoresRompimientos;
        String[] valoresRompimientosAnterior;
        String[] valoresRegistro;
        Font fuenteColumnas;
        Font fuenteRompimiento;
        Boolean controlSalto = false;
        //Almacenar la configuración y acumulado de totales
        int[] configuracionTotales;
        int[,] acumuladoTotales;
        int baseColor = 150;
        Boolean banderaPoneTotales = false;
        //resumen
        Resumen resumen;
        Boolean banderaResumen = false;
        Document document;
        PdfWriter writer;
        //oficio
        Boolean bOficio = false;

        #region Documentos PDF por SISTEMA
        public FormarDoctoPDF(ConfigArchivo PconfigArchivo, ConfigTablas PconfigTablas, ConfigColumnas PconfigColumnas, ConfigEncabezado PconfigEncabezado, ConfigPiePagina PconfigPiePagina, DataSet PdtsDatos, DataTableReader PdtrDatos, RepoRecepcion reporteODP)
        {
            try
            {
                _configArchivo = PconfigArchivo;
                _configTablas = PconfigTablas;
                _configColumnas = PconfigColumnas;
                _configEncabezado = PconfigEncabezado;
                _configPiePagina = PconfigPiePagina;
                _dtsDatos = PdtsDatos;
                _dtrDatos = PdtrDatos;
                _reporteODP = reporteODP;

                //PdfReader PX = new PdfReader("c:\\Preba11.pdf"); 
                document = new Document();
                writer = PdfWriter.GetInstance(document, new FileStream(_configArchivo.NombreArchivo, FileMode.Create));

                Configura_doctoPDFPTable();

                switch (_configArchivo.TipoReporte)
                {
                    case eTipoReporte.Oficio:
                        Genera_Oficio();
                        document.NewPage();
                        break;
                    case eTipoReporte.AcuseRecibo:
                        GeneraRecibo();
                        document.NewPage();
                        break;
                }

                for (int iRecorreR = 0; iRecorreR < _configTablas.NumeroTablas; iRecorreR++)
                {
                    banderaResumen = false;
                    _configColumnas = _configTablas.tablas.ElementAt(iRecorreR).VconfigColumnas;
                    _dtrDatos = new DataTableReader(_dtsDatos.Tables[_configTablas.tablas.ElementAt(iRecorreR).NombreTabla]);

                    if (iRecorreR > 0)
                    {
                        if (_configTablas.tablas.ElementAt(iRecorreR).SaltoPagina == true)
                        {
                            document.NewPage();
                        }
                        else
                        {
                            document.Add(new Paragraph("  "));
                            document.Add(new Paragraph("  "));
                        }
                    }

                    if (_configTablas.tablas.ElementAt(iRecorreR).TipoTabla == eTipoTabla.Texto)
                        Genera_doctoTexto();
                    else
                    {
                        Genera_doctoPDFPTable(_configTablas.tablas.ElementAt(iRecorreR));
                        if (banderaResumen == true)
                        {
                            _configArchivo.Resumen = false;
                            _configArchivo.SuprimeDetalle = false;
                            _dtrDatos = new DataTableReader(resumen.datosResumen.Tables["Datos"]);
                            _configTablas.tablas.ElementAt(iRecorreR).EncabezadoTabla = "";
                            FormarDoctoPDF vFormarDoctoPDF = new FormarDoctoPDF(document, writer, _configArchivo, _configTablas.tablas.ElementAt(iRecorreR), resumen.vconfigColumnas, _configEncabezado, _configPiePagina, _dtrDatos);
                        }
                    }
                }
                document.Close();
                //System.out.println(RegresaNombreArchivo());            
            }
            catch (IOException ioe)
            {
                //System.err.println(ioe.getMessage());
            }
            finally
            {
                if (_dtrDatos != null) { _dtrDatos.Close(); _dtrDatos.Dispose(); }
                if (_dtsDatos != null) { _dtsDatos.Dispose(); }
            }
        }
        public FormarDoctoPDF(ConfigArchivo PconfigArchivo, ConfigTablas PconfigTablas, ConfigColumnas PconfigColumnas, ConfigEncabezado PconfigEncabezado, ConfigPiePagina PconfigPiePagina, DataSet PdtsDatos, DataTableReader PdtrDatos, List<RepoRecepcion> listadoPromociones)
        {
            try
            {
                _configArchivo = PconfigArchivo;
                _configTablas = PconfigTablas;
                _configColumnas = PconfigColumnas;
                _configEncabezado = PconfigEncabezado;
                _configPiePagina = PconfigPiePagina;
                _dtsDatos = PdtsDatos;
                _dtrDatos = PdtrDatos;

                //PdfReader PX = new PdfReader("c:\\Preba11.pdf"); 
                document = new Document();
                writer = PdfWriter.GetInstance(document, new FileStream(_configArchivo.NombreArchivo, FileMode.Create));

                Configura_doctoPDFPTable();
                for (int i = 0; i < listadoPromociones.Count; i++)
                {
                    GeneraVale(listadoPromociones[i]);
                    document.NewPage();
                }
                

                //for (int iRecorreR = 0; iRecorreR < _configTablas.NumeroTablas; iRecorreR++)
                //{
                //    banderaResumen = false;
                //    _configColumnas = _configTablas.tablas.ElementAt(iRecorreR).VconfigColumnas;
                //    _dtrDatos = new DataTableReader(_dtsDatos.Tables[_configTablas.tablas.ElementAt(iRecorreR).NombreTabla]);

                //    if (iRecorreR > 0)
                //    {
                //        if (_configTablas.tablas.ElementAt(iRecorreR).SaltoPagina == true)
                //        {
                //            document.NewPage();
                //        }
                //        else
                //        {
                //            document.Add(new Paragraph("  "));
                //            document.Add(new Paragraph("  "));
                //        }
                //    }

                //    if (_configTablas.tablas.ElementAt(iRecorreR).TipoTabla == eTipoTabla.Texto)
                //        Genera_doctoTexto();
                //    else
                //    {
                //        Genera_doctoPDFPTable(_configTablas.tablas.ElementAt(iRecorreR));
                //        if (banderaResumen == true)
                //        {
                //            _configArchivo.Resumen = false;
                //            _configArchivo.SuprimeDetalle = false;
                //            _dtrDatos = new DataTableReader(resumen.datosResumen.Tables["Datos"]);
                //            _configTablas.tablas.ElementAt(iRecorreR).EncabezadoTabla = "";
                //            FormarDoctoPDF vFormarDoctoPDF = new FormarDoctoPDF(document, writer, _configArchivo, _configTablas.tablas.ElementAt(iRecorreR), resumen.vconfigColumnas, _configEncabezado, _configPiePagina, _dtrDatos);
                //        }
                //    }
                //}
                document.Close();
            }
            catch (IOException ioe)
            {
                //System.err.println(ioe.getMessage());
            }
            finally
            {
                if (_dtrDatos != null) { _dtrDatos.Close(); _dtrDatos.Dispose(); }
                if (_dtsDatos != null) { _dtsDatos.Dispose(); }
            }
        }
        public FormarDoctoPDF(ConfigArchivo PconfigArchivo, ConfigTablas PconfigTablas, ConfigColumnas PconfigColumnas, ConfigEncabezado PconfigEncabezado, ConfigPiePagina PconfigPiePagina, DataSet PdtsDatos, DataTableReader PdtrDatos, ReporteCaratula reporteCaratula)
        {
            try
            {
                _configArchivo = PconfigArchivo;
                _configTablas = PconfigTablas;
                _configColumnas = PconfigColumnas;
                _configEncabezado = PconfigEncabezado;
                _configPiePagina = PconfigPiePagina;
                _dtsDatos = PdtsDatos;
                _dtrDatos = PdtrDatos;
                _reporteCaratula = reporteCaratula;

                //PdfReader PX = new PdfReader("c:\\Preba11.pdf"); 
                document = new Document();
                writer = PdfWriter.GetInstance(document, new FileStream(_configArchivo.NombreArchivo, FileMode.Create));

                Configura_doctoPDFPTable();

                switch (_configArchivo.TipoReporte)
                {
                    case eTipoReporte.Oficio:
                        Genera_Oficio();
                        document.NewPage();
                        break;
                    case eTipoReporte.Caratula:
                        GeneraCaratula();
                        document.NewPage();
                        break;
                }

                for (int iRecorreR = 0; iRecorreR < _configTablas.NumeroTablas; iRecorreR++)
                {
                    banderaResumen = false;
                    _configColumnas = _configTablas.tablas.ElementAt(iRecorreR).VconfigColumnas;
                    _dtrDatos = new DataTableReader(_dtsDatos.Tables[_configTablas.tablas.ElementAt(iRecorreR).NombreTabla]);

                    if (iRecorreR > 0)
                    {
                        if (_configTablas.tablas.ElementAt(iRecorreR).SaltoPagina == true)
                        {
                            document.NewPage();
                        }
                        else
                        {
                            document.Add(new Paragraph("  "));
                            document.Add(new Paragraph("  "));
                        }
                    }

                    if (_configTablas.tablas.ElementAt(iRecorreR).TipoTabla == eTipoTabla.Texto)
                        Genera_doctoTexto();
                    else
                    {
                        Genera_doctoPDFPTable(_configTablas.tablas.ElementAt(iRecorreR));
                        if (banderaResumen == true)
                        {
                            _configArchivo.Resumen = false;
                            _configArchivo.SuprimeDetalle = false;
                            _dtrDatos = new DataTableReader(resumen.datosResumen.Tables["Datos"]);
                            _configTablas.tablas.ElementAt(iRecorreR).EncabezadoTabla = "";
                            FormarDoctoPDF vFormarDoctoPDF = new FormarDoctoPDF(document, writer, _configArchivo, _configTablas.tablas.ElementAt(iRecorreR), resumen.vconfigColumnas, _configEncabezado, _configPiePagina, _dtrDatos);
                        }
                    }
                }
                document.Close();
                //System.out.println(RegresaNombreArchivo());            
            }
            catch (IOException ioe)
            {
                //System.err.println(ioe.getMessage());
            }
            finally
            {
                if (_dtrDatos != null) { _dtrDatos.Close(); _dtrDatos.Dispose(); }
                if (_dtsDatos != null) { _dtsDatos.Dispose(); }
            }
        }
        #endregion

        public FormarDoctoPDF(ConfigArchivo PconfigArchivo, ConfigTablas PconfigTablas, ConfigColumnas PconfigColumnas, ConfigEncabezado PconfigEncabezado, ConfigPiePagina PconfigPiePagina, DataSet PdtsDatos, DataTableReader PdtrDatos)
        {
            try
            {
                _configArchivo = PconfigArchivo;
                _configTablas = PconfigTablas;
                _configColumnas = PconfigColumnas;
                _configEncabezado = PconfigEncabezado;
                _configPiePagina = PconfigPiePagina;
                _dtsDatos = PdtsDatos;
                _dtrDatos = PdtrDatos;

                //PdfReader PX = new PdfReader("c:\\Preba11.pdf"); 
                document = new Document();
                writer = PdfWriter.GetInstance(document, new FileStream(_configArchivo.NombreArchivo, FileMode.Create));

                Configura_doctoPDFPTable();

                switch (_configArchivo.TipoReporte)
                {
                    case eTipoReporte.Oficio:
                        Genera_Oficio();
                        document.NewPage();
                        break;
                    case eTipoReporte.AcuseRecibo:
                        GeneraRecibo();
                        document.NewPage();
                        break;
                }



                for (int iRecorreR = 0; iRecorreR < _configTablas.NumeroTablas; iRecorreR++)
                {
                    banderaResumen = false;
                    _configColumnas = _configTablas.tablas.ElementAt(iRecorreR).VconfigColumnas;
                    _dtrDatos = new DataTableReader(_dtsDatos.Tables[_configTablas.tablas.ElementAt(iRecorreR).NombreTabla]);

                    if (iRecorreR > 0)
                    {
                        if (_configTablas.tablas.ElementAt(iRecorreR).SaltoPagina == true)
                        {
                            document.NewPage();
                        }
                        else
                        {
                            document.Add(new Paragraph("  "));
                            document.Add(new Paragraph("  "));
                        }
                    }

                    if (_configTablas.tablas.ElementAt(iRecorreR).TipoTabla == eTipoTabla.Texto)
                        Genera_doctoTexto();
                    else
                    {
                        Genera_doctoPDFPTable(_configTablas.tablas.ElementAt(iRecorreR));
                        if (banderaResumen == true)
                        {
                            _configArchivo.Resumen = false;
                            _configArchivo.SuprimeDetalle = false;
                            _dtrDatos = new DataTableReader(resumen.datosResumen.Tables["Datos"]);
                            _configTablas.tablas.ElementAt(iRecorreR).EncabezadoTabla = " ";
                            FormarDoctoPDF vFormarDoctoPDF = new FormarDoctoPDF(document, writer, _configArchivo, _configTablas.tablas.ElementAt(iRecorreR), resumen.vconfigColumnas, _configEncabezado, _configPiePagina, _dtrDatos);
                        }
                    }
                }



                document.Close();
                //System.out.println(RegresaNombreArchivo());            
            }
            catch (IOException ioe)
            {
                //System.err.println(ioe.getMessage());
            }
            finally
            {
                if (_dtrDatos != null) { _dtrDatos.Close(); _dtrDatos.Dispose(); }
                if (_dtsDatos != null) { _dtsDatos.Dispose(); }
            }
        }

        public FormarDoctoPDF(Document documentX, PdfWriter writerX, ConfigArchivo PconfigArchivo, descripcionTabla tabla, ConfigColumnas PconfigColumnas, ConfigEncabezado PconfigEncabezado, ConfigPiePagina PconfigPiePagina, DataTableReader PdtrDatos)
        {
            try
            {
                _configArchivo = PconfigArchivo;
                _configColumnas = PconfigColumnas;
                _configEncabezado = PconfigEncabezado;
                _configPiePagina = PconfigPiePagina;
                _dtrDatos = PdtrDatos;

                document = documentX;
                writer = writerX;

                //Configura_doctoPDFPTable();

                //titulo de resumen
                document.Add(new Paragraph(""));
                document.Add(new Paragraph(""));
                Paragraph tituloR;
                tituloR = new Paragraph(_configArchivo.TituloResumen);
                tituloR.Alignment = Element.ALIGN_CENTER;
                document.Add(tituloR);
                document.Add(new Paragraph(""));
                //genera tabla de resumen
                Genera_doctoPDFPTable(tabla);

                //document.Close();                
            }
            catch (IOException ioe)
            {
                //System.err.println(ioe.getMessage());
            }
        }

        public void Configura_doctoPDFPTable()
        {
            _configArchivo.ConfiguraMetaDatos(document);
            _configArchivo.ConfiguraVista(writer);
            _configArchivo.ConfiguraEncriptar(writer);
            _configArchivo.ConfiguraPagina(document);
            if(_configEncabezado.Mostrar)
                _configEncabezado.preconfigEncabezado(writer, document);

            if (_configArchivo.TipoReporte == eTipoReporte.ListaDeAcuerdos)
                _configPiePagina.preconfigPiePagina(writer, document, _configArchivo.TipoReporte);

            _configPiePagina.preconfigPiePagina(writer, document);

            //Configurar margeb¡nes de acuerdo al largo del encabezado
            float margen_izq = document.LeftMargin;
            float margen_der = document.RightMargin;
            float margen_sup = document.TopMargin;
            float margen_inf = document.BottomMargin;
            document.SetMargins(margen_izq, margen_der, margen_sup + _configEncabezado.table.TotalHeight - 15, margen_inf + _configPiePagina.table.TotalHeight + 20);

            //Abrir el docto.
            document.Open();
            //Activar el manejador de eventos 
            ControlEventos controlEventos = new ControlEventos(writer, document, _configEncabezado, _configPiePagina);
            writer.PageEvent = controlEventos;

        }

        public void Genera_Oficio()
        {
            fuenteColumnas = DefineFuente(_configArchivo.Fuente.ToString(), (float)_configArchivo.SizeFuente);
            Paragraph ph;
            leeConfigArchivo _leeConfigArchivo = new leeConfigArchivo();
            _leeConfigArchivo.leerConfigArchivo(_dtsDatos);

            ph = new Paragraph();
            ph.Font = fuenteColumnas;

            float[] tamañoCO = { 80, 20 };

            PdfPTable datatableO = new PdfPTable(tamañoCO);

            //datatableO.DefaultCell.Border = Rectangle.NO_BORDER;
            //datatableO.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            //datatableO.DefaultCell.VerticalAlignment = Element.ALIGN_TOP;

            //datatableO.AddCell("");
            //datatableO.AddCell(new Paragraph(_leeConfigArchivo.NumeroOficio, fuenteColumnas));
            //datatableO.AddCell("");
            //datatableO.AddCell(new Paragraph(_leeConfigArchivo.AsuntoOficio, fuenteColumnas));

            //----------------***Esto es para la imagen-------------------//
            //MemoryStream mems = new MemoryStream();
            //System.Drawing.Image img = Reporteador.Properties.Resources.poder_judicial;
            //img.Save(mems, System.Drawing.Imaging.ImageFormat.Gif);
            //iTextSharp.text.Image img2 = iTextSharp.text.Image.GetInstance(mems.ToArray());
            ////img2.Alignment = Element.ALIGN_CENTER;
            //img2.ScalePercent(35); //Porcentaje del tamaño de la imagen
            ////Image img = Image.GetInstance(Dibujo);
            ////img.Alignment = Element.ALIGN_CENTER;
            ////img.ScalePercent(28);
            ////datatableO.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            ////datatableO.DefaultCell.VerticalAlignment = Element.ALIGN_TOP;

            //PdfPCell cell = new PdfPCell(img2);
            //cell.Padding = 1;
            //cell.Border = 0;
            ////cell.setBackgroundColor(new Color(0, 0, 255));
            //cell.HorizontalAlignment = Element.ALIGN_LEFT;
            //datatableO.AddCell(cell);

            ////Font font = FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD);
            //ph = new Paragraph("", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD));
            //datatableO.AddCell(ph); //Si no meto el parrafo a la celda NO SE MUESTA LA IMAGEN *** ESTO VA DE CAJÓN               
            //----------------***Esto es para la imagen-------------------//

            document.Add(datatableO); //Una vez armado el DataTable0 lo meto al documento

            document.Add(new Paragraph("  "));
            document.Add(new Paragraph("  "));

            ph = new Paragraph(_leeConfigArchivo.Presidente, fuenteColumnas);
            ph.Alignment = Element.ALIGN_LEFT;
            document.Add(ph);
            ph = new Paragraph(_leeConfigArchivo.TituloPresidente, fuenteColumnas);
            ph.Alignment = Element.ALIGN_LEFT;
            document.Add(ph);

            PdfPTable datatablePresente = new PdfPTable(tamañoCO);
            datatablePresente.DefaultCell.Border = Rectangle.NO_BORDER;
            ph = new Paragraph("PRESENTE:", fuenteColumnas);
            ph.Alignment = Element.ALIGN_LEFT;
            datatablePresente.AddCell(ph);
            datatablePresente.AddCell("");
            document.Add(datatablePresente);
            document.Add(new Paragraph("  "));
            ph = new Paragraph(_leeConfigArchivo.Parrafo, fuenteColumnas);
            ph.Alignment = Element.ALIGN_JUSTIFIED;
            document.Add(ph);

            document.Add(new Paragraph("  "));
            //busca tablas del oficio
            for (int iRecorreR = 0; iRecorreR < _configTablas.NumeroTablas; iRecorreR++)
            {
                banderaResumen = false;
                //if (_configTablas.tablas.ElementAt(iRecorreR).TipoTabla == 3)
                //{
                //    _configColumnas = _configTablas.tablas.ElementAt(iRecorreR).VconfigColumnas;
                //    _dtrDatos = new DataTableReader(_dtsDatos.Tables[_configTablas.tablas.ElementAt(iRecorreR).NombreTabla]);
                //    document.Add(new Paragraph("  "));
                //    Genera_doctoPDFPTable(_configTablas.tablas.ElementAt(iRecorreR));
                //}
            }

            fuenteColumnas = DefineFuente(_configArchivo.Fuente.ToString(), (float)_configArchivo.SizeFuente);
            document.Add(new Paragraph("  "));
            document.Add(new Paragraph("  "));
            ph = new Paragraph(_leeConfigArchivo.Municipio != "" ? _leeConfigArchivo.Municipio + ", a " + _leeConfigArchivo.FechaGeneracion.ToLongDateString() + "." : "", fuenteColumnas);
            ph.Alignment = Element.ALIGN_CENTER;
            document.Add(ph);
            //document.Add(new Paragraph("  "));

            ph = new Paragraph(_leeConfigArchivo.Responsable1, fuenteColumnas);
            ph.Alignment = Element.ALIGN_CENTER;
            document.Add(ph);
            ph = new Paragraph(_leeConfigArchivo.Responsable2, fuenteColumnas);
            ph.Alignment = Element.ALIGN_CENTER;
            document.Add(ph);
        }

        /// <summary>
        /// Este método se implementa para generar el recibo de acuse en ODP
        /// </summary>
        public void GeneraRecibo()
        {
            fuenteColumnas = DefineFuente(_configArchivo.Fuente.ToString(), (float)_configArchivo.SizeFuente);
            Paragraph ph;
            leeConfigArchivo _leeConfigArchivo = new leeConfigArchivo();
            _leeConfigArchivo.leerConfigArchivo(_dtsDatos);

            ph = new Paragraph();
            ph.Font = fuenteColumnas;

            float[] tamañoCO = { 80, 20 };

            //PdfPTable datatableO = new PdfPTable(tamañoCO);
            ////datatableO.DefaultCell.Border = Rectangle.NO_BORDER;
            //datatableO.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            //datatableO.DefaultCell.VerticalAlignment = Element.ALIGN_TOP;
            //document.Add(datatableO); //Una vez armado el DataTable0 lo meto al documento

            //document.Add(new Paragraph("  ")); //Salto de página
            //document.Add(new Paragraph("  "));

            //if (_leeConfigArchivo.Presidente != "")
            //{
            //    ph = new Paragraph(_leeConfigArchivo.Presidente, fuenteColumnas);
            //    ph.Alignment = Element.ALIGN_LEFT;
            //    document.Add(ph);
            //}
            //if (_leeConfigArchivo.TituloPresidente != "")
            //{
            //    ph = new Paragraph(_leeConfigArchivo.TituloPresidente, fuenteColumnas);
            //    ph.Alignment = Element.ALIGN_LEFT;
            //    document.Add(ph);
            //}


            //PdfPTable datatablePresente = new PdfPTable(tamañoCO);
            //datatablePresente.DefaultCell.Border = Rectangle.NO_BORDER;
            if (_reporteODP.Juzgado != "")
            {
                ph = new Paragraph("PODER JUDICIAL DEL ESTADO DE GUANAJUATO", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD));
                ph.Alignment = Element.ALIGN_LEFT;
                //datatablePresente.AddCell(ph);
                //datatablePresente.AddCell("");
                //document.Add(datatablePresente);
                document.Add(ph);
                ph = new Paragraph(_reporteODP.Juzgado, FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD));
                ph.Alignment = Element.ALIGN_LEFT;
                document.Add(ph);
            }
            //*****Objeto cabecera****
            //document.Add(new Paragraph("  ")); //Un salto de línea
            if (_configArchivo.HabilitarHTML)
            {
                string parrafosHTML = _reporteODP.ParrafoCabecera;
                if (_reporteODP.ParrafoAnexos != "") //Si existe listado de anexos lo adjunto
                    parrafosHTML = parrafosHTML + "<br>" + _reporteODP.ParrafoAnexos;

                MemoryStream mem = new MemoryStream();
                StreamWriter sw = new StreamWriter(mem, Encoding.UTF8);
                sw.Write(parrafosHTML);
                sw.Flush();
                StreamReader stream_reader = new StreamReader(mem);
                mem.Seek(0, SeekOrigin.Begin);

                StyleSheet styles = new StyleSheet();
                styles.LoadStyle("p", "text-align", "justify");
                List<IElement> objects;
                objects = HTMLWorker.ParseToList(stream_reader, styles);
                stream_reader.Close();
                //objects = HTMLWorker.ParseToList(new StreamReader("c://pruebaHTML.htm", Encoding.Default), styles);

                for (int k = 0; k < objects.Count; ++k)
                {
                    if (objects[k].GetType().Name != "PdfPTable")
                    {
                        //ph.Alignment = Element.ALIGN_JUSTIFIED;
                        objects[k].Chunks[0].Font = fuenteColumnas;
                    }
                    //else
                    //{
                    //    ph = new Paragraph(" ");
                    //    ph.Alignment = Element.ALIGN_LEFT;
                    //    document.Add(ph);
                    //    ((PdfPTable)objects[k]).HorizontalAlignment = Element.ALIGN_LEFT;
                    //}
                    document.Add((IElement)objects[k]);
                }
                sw.Close();
            }
            else
            {
                //***Cabecera sin HTML
                ph = new Paragraph(_reporteODP.ParrafoCabecera, fuenteColumnas);
                ph.Alignment = Element.ALIGN_JUSTIFIED;
                document.Add(ph);

                //***Anexos sin HTML
                document.Add(new Paragraph("  "));
                document.Add(new Paragraph("DETALLES DE ANEXOS:", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD)));
                ph = new Paragraph(_reporteODP.ParrafoAnexos, fuenteColumnas);
                ph.Alignment = Element.ALIGN_JUSTIFIED;
                document.Add(ph);
            }
            

            /*------------DESCRIPCIÓN DEL ARTICULO DE PROCEDIMIENTOS*/
            document.Add(new Paragraph("  "));
            ph = new Paragraph(_reporteODP.ArticuloLey.Trim().ToUpper(), FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.NORMAL));
            ph.Alignment = Element.ALIGN_JUSTIFIED;
            document.Add(ph);

            if (_reporteODP.LeyendaVale != null && _reporteODP.LeyendaVale.Trim() != "")
            {
                /*LEYENDA: "Recibido con los datos y anexos que se describen en la razón
                        asentada por Oficialia de Partes Civil*/
                document.Add(new Paragraph("  "));
                ph = new Paragraph('"' + _reporteODP.LeyendaVale.Trim().ToUpper() + '"', FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD));
                ph.Alignment = Element.ALIGN_JUSTIFIED;
                document.Add(ph);
            }

            if (_reporteODP.LeyendaAnual != null && _reporteODP.LeyendaAnual.Trim() != "")
            {
                /*LEYENDA: "2014. Año de Efraín Huerta*/
                document.Add(new Paragraph("  "));
                ph = new Paragraph('"' + _reporteODP.LeyendaAnual.Trim().ToUpper() + '"', FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD));
                ph.Alignment = Element.ALIGN_JUSTIFIED;
                document.Add(ph);
            }

            //***Id e iniciales del USUARIO
            document.Add(new Paragraph("  "));
            ph = new Paragraph(_reporteODP.IdUsuario == string.Empty ? _reporteODP.InicUsuario : _reporteODP.IdUsuario + " - " + _reporteODP.InicUsuario, FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.NORMAL));
            ph.Alignment = Element.ALIGN_JUSTIFIED;
            document.Add(ph);

            
            //busca tablas del oficio
            for (int iRecorreR = 0; iRecorreR < _configTablas.NumeroTablas; iRecorreR++)
            {
                banderaResumen = false;
                //if (_configTablas.tablas.ElementAt(iRecorreR).TipoTabla == 3)
                //{
                //    _configColumnas = _configTablas.tablas.ElementAt(iRecorreR).VconfigColumnas;
                //    _dtrDatos = new DataTableReader(_dtsDatos.Tables[_configTablas.tablas.ElementAt(iRecorreR).NombreTabla]);
                //    document.Add(new Paragraph("  "));
                //    Genera_doctoPDFPTable(_configTablas.tablas.ElementAt(iRecorreR));
                //}
            }

            fuenteColumnas = DefineFuente(_configArchivo.Fuente.ToString(), (float)_configArchivo.SizeFuente);
            document.Add(new Paragraph("  "));
            document.Add(new Paragraph("  "));
            ph = new Paragraph(_leeConfigArchivo.Municipio != "" ? _leeConfigArchivo.Municipio + ", a " + _leeConfigArchivo.FechaGeneracion.ToLongDateString() + "." : "", fuenteColumnas);
            ph.Alignment = Element.ALIGN_CENTER;
            document.Add(ph);
            //document.Add(new Paragraph("  "));

            ph = new Paragraph(_leeConfigArchivo.Responsable1, fuenteColumnas);
            ph.Alignment = Element.ALIGN_CENTER;
            document.Add(ph);
            ph = new Paragraph(_leeConfigArchivo.Responsable2, fuenteColumnas);
            ph.Alignment = Element.ALIGN_CENTER;
            document.Add(ph);
        }

        /// <summary>
        /// Este método se implementa para generar el vale con el listado de promociones
        /// </summary>
        public void GeneraVale(RepoRecepcion objeto)
        {
            fuenteColumnas = DefineFuente(_configArchivo.Fuente.ToString(), (float)_configArchivo.SizeFuente);
            Paragraph ph;
            leeConfigArchivo _leeConfigArchivo = new leeConfigArchivo();
            _leeConfigArchivo.leerConfigArchivo(_dtsDatos);

            ph = new Paragraph();
            ph.Font = fuenteColumnas;

            float[] tamañoCO = { 80, 20 };

            PdfPTable datatableO = new PdfPTable(tamañoCO);
            //datatableO.DefaultCell.Border = Rectangle.NO_BORDER;
            datatableO.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            datatableO.DefaultCell.VerticalAlignment = Element.ALIGN_TOP;
            document.Add(datatableO); //Una vez armado el DataTable0 lo meto al documento

            document.Add(new Paragraph("  ")); //Salto de página
            //document.Add(new Paragraph("  "));

            ph = new Paragraph(_leeConfigArchivo.Presidente, fuenteColumnas);
            ph.Alignment = Element.ALIGN_LEFT;
            document.Add(ph);
            ph = new Paragraph(_leeConfigArchivo.TituloPresidente, fuenteColumnas);
            ph.Alignment = Element.ALIGN_LEFT;
            document.Add(ph);

            //PdfPTable datatablePresente = new PdfPTable(tamañoCO);
            //datatablePresente.DefaultCell.Border = Rectangle.NO_BORDER;
            ph = new Paragraph("PODER JUDICIAL DEL ESTADO DE GUANAJUATO", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD));
            ph.Alignment = Element.ALIGN_LEFT;
            //datatablePresente.AddCell(ph);
            //datatablePresente.AddCell("");
            //document.Add(datatablePresente);
            document.Add(ph);
            ph = new Paragraph(objeto.Juzgado, FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD));
            ph.Alignment = Element.ALIGN_LEFT;
            document.Add(ph);

            //*****Objeto cabecera****
            document.Add(new Paragraph("  ")); //Un salto de línea
            if (_configArchivo.HabilitarHTML)
            {
                string parrafosHTML = objeto.ParrafoCabecera;
                if (objeto.ParrafoAnexos != "") //Si existe listado de anexos lo adjunto
                    parrafosHTML = parrafosHTML + "<br>" + objeto.ParrafoAnexos;

                MemoryStream mem = new MemoryStream();
                StreamWriter sw = new StreamWriter(mem, Encoding.UTF8);
                sw.Write(parrafosHTML);
                sw.Flush();
                StreamReader stream_reader = new StreamReader(mem);
                mem.Seek(0, SeekOrigin.Begin);

                StyleSheet styles = new StyleSheet();
                styles.LoadStyle("p", "text-align", "justify");
                List<IElement> objects;
                objects = HTMLWorker.ParseToList(stream_reader, styles);
                stream_reader.Close();
                //objects = HTMLWorker.ParseToList(new StreamReader("c://pruebaHTML.htm", Encoding.Default), styles);

                for (int k = 0; k < objects.Count; ++k)
                {
                    if (objects[k].GetType().Name != "PdfPTable")
                    {
                        //ph.Alignment = Element.ALIGN_JUSTIFIED;
                        objects[k].Chunks[0].Font = fuenteColumnas;
                    }
                    else
                    {
                        ph = new Paragraph(" ");
                        ph.Alignment = Element.ALIGN_LEFT;
                        document.Add(ph);
                        ((PdfPTable)objects[k]).HorizontalAlignment = Element.ALIGN_LEFT;
                    }
                    document.Add((IElement)objects[k]);
                }
                sw.Close();
            }
            else
            {
                //***Cabecera sin HTML
                ph = new Paragraph(objeto.ParrafoCabecera, fuenteColumnas);
                ph.Alignment = Element.ALIGN_JUSTIFIED;
                document.Add(ph);

                //***Anexos sin HTML
                document.Add(new Paragraph("  "));
                document.Add(new Paragraph("DETALLES DE ANEXOS:", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD)));
                ph = new Paragraph(objeto.ParrafoAnexos, fuenteColumnas);
                ph.Alignment = Element.ALIGN_JUSTIFIED;
                document.Add(ph);
            }


            /*LEYENDA: "Recibido con los datos y anexos que se describen en la razón
                        asentada por Oficialia de Partes Civil*/
            document.Add(new Paragraph("  "));
            ph = new Paragraph('"' + objeto.LeyendaVale.Trim().ToUpper() + '"', FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD));
            ph.Alignment = Element.ALIGN_JUSTIFIED;
            document.Add(ph);

            document.Add(new Paragraph("  "));
            ph = new Paragraph('"' + objeto.LeyendaAnual.Trim().ToUpper() + '"', FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD));
            ph.Alignment = Element.ALIGN_JUSTIFIED;
            document.Add(ph);

            #region Zona para marcadores (INDICE, LO QUE ME ENCARGO JUAN)
            //// Code 1
            //document.Add(new Chunk("Chapter 1").SetLocalDestination("1"));
            //document.NewPage();

            //document.Add(new Chunk("Chapter 2").SetLocalDestination("2"));
            //document.Add(new Paragraph(new Chunk("Sub 2.1").SetLocalDestination("2.1")));
            //document.Add(new Paragraph(new Chunk("Sub 2.2").SetLocalDestination("2.2")));
            //document.NewPage();

            //document.Add(new Chunk("Chapter 3").SetLocalDestination("3"));

            //// Code 2
            //PdfContentByte cb = writer.DirectContent;
            //PdfOutline root = cb.RootOutline;

            //// Code 3
            //PdfOutline oline1 = new PdfOutline(root,
            //    PdfAction.GotoLocalPage("1", false), "Chapter 1");

            //PdfOutline oline2 = new PdfOutline(root,
            //    PdfAction.GotoLocalPage("2", false), "Chapter 2");
            //oline2.Open = false;
            //PdfOutline oline2_1 = new PdfOutline(oline2,
            //    PdfAction.GotoLocalPage("2.1", false), "Sub 2.1");
            //PdfOutline oline2_2 = new PdfOutline(oline2,
            //    PdfAction.GotoLocalPage("2.2", false), "Sub 2.2");

            //PdfOutline oline3 = new PdfOutline(root,
            //    PdfAction.GotoLocalPage("3", false), "Chapter 3");
            #endregion

            /*------------DESCRIPCIÓN DEL ARTICULO DE PROCEDIMIENTOS*/
            document.Add(new Paragraph("  "));
            ph = new Paragraph(objeto.ArticuloLey.Trim().ToUpper(), FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.NORMAL));
            ph.Alignment = Element.ALIGN_JUSTIFIED;
            document.Add(ph);

            //***Id e iniciales del USUARIO
            document.Add(new Paragraph("  "));
            ph = new Paragraph(objeto.IdUsuario == string.Empty ? objeto.InicUsuario : objeto.IdUsuario + " - " + objeto.InicUsuario, FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.NORMAL));
            ph.Alignment = Element.ALIGN_JUSTIFIED;
            document.Add(ph);

            fuenteColumnas = DefineFuente(_configArchivo.Fuente.ToString(), (float)_configArchivo.SizeFuente);
            document.Add(new Paragraph("  "));
            document.Add(new Paragraph("  "));
            ph = new Paragraph(_leeConfigArchivo.Municipio != "" ? _leeConfigArchivo.Municipio + ", a " + _leeConfigArchivo.FechaGeneracion.ToLongDateString() + "." : "", fuenteColumnas);
            ph.Alignment = Element.ALIGN_CENTER;
            document.Add(ph);
            //document.Add(new Paragraph("  "));

            ph = new Paragraph(_leeConfigArchivo.Responsable1, fuenteColumnas);
            ph.Alignment = Element.ALIGN_CENTER;
            document.Add(ph);
            ph = new Paragraph(_leeConfigArchivo.Responsable2, fuenteColumnas);
            ph.Alignment = Element.ALIGN_CENTER;
            document.Add(ph);
        }

        /// <summary>
        /// Este método se implementa para generar la carátula del expediente
        /// </summary>
        public void GeneraCaratula()
        {
            fuenteColumnas = DefineFuente(_configArchivo.Fuente.ToString(), (float)_configArchivo.SizeFuente);
            Paragraph ph;
            leeConfigArchivo _leeConfigArchivo = new leeConfigArchivo();
            _leeConfigArchivo.leerConfigArchivo(_dtsDatos);

            ph = new Paragraph();
            ph.Font = fuenteColumnas;

            float[] tamañoCO = { 80, 20 };

            PdfPTable datatableO = new PdfPTable(tamañoCO);
            //datatableO.DefaultCell.Border = Rectangle.NO_BORDER;
            datatableO.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            datatableO.DefaultCell.VerticalAlignment = Element.ALIGN_TOP;
            document.Add(datatableO); //Una vez armado el DataTable0 lo meto al documento

            document.Add(new Paragraph("  ")); //Salto de página
            //document.Add(new Paragraph("  "));

            ph = new Paragraph(_leeConfigArchivo.Presidente, fuenteColumnas);
            ph.Alignment = Element.ALIGN_LEFT;
            document.Add(ph);
            ph = new Paragraph(_leeConfigArchivo.TituloPresidente, fuenteColumnas);
            ph.Alignment = Element.ALIGN_LEFT;
            document.Add(ph);

            //PdfPTable datatablePresente = new PdfPTable(tamañoCO);
            //datatablePresente.DefaultCell.Border = Rectangle.NO_BORDER;
            ph = new Paragraph("PODER JUDICIAL DEL ESTADO DE GUANAJUATO", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD));
            ph.Alignment = Element.ALIGN_LEFT;
            //datatablePresente.AddCell(ph);
            //datatablePresente.AddCell("");
            //document.Add(datatablePresente);
            document.Add(ph);
            ph = new Paragraph(_reporteODP.Juzgado, FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD));
            ph.Alignment = Element.ALIGN_LEFT;
            document.Add(ph);

            //*****Objeto cabecera****
            document.Add(new Paragraph("  ")); //Un salto de línea
            if (_configArchivo.HabilitarHTML)
            {
                string parrafosHTML = _reporteODP.ParrafoCabecera;
                if (_reporteODP.ParrafoAnexos != "") //Si existe listado de anexos lo adjunto
                    parrafosHTML = parrafosHTML + "<br>" + _reporteODP.ParrafoAnexos;

                MemoryStream mem = new MemoryStream();
                StreamWriter sw = new StreamWriter(mem, Encoding.UTF8);
                sw.Write(parrafosHTML);
                sw.Flush();
                StreamReader stream_reader = new StreamReader(mem);
                mem.Seek(0, SeekOrigin.Begin);

                StyleSheet styles = new StyleSheet();
                styles.LoadStyle("p", "text-align", "justify");
                List<IElement> objects;
                objects = HTMLWorker.ParseToList(stream_reader, styles);
                stream_reader.Close();
                //objects = HTMLWorker.ParseToList(new StreamReader("c://pruebaHTML.htm", Encoding.Default), styles);

                for (int k = 0; k < objects.Count; ++k)
                {
                    if (objects[k].GetType().Name != "PdfPTable")
                    {
                        //ph.Alignment = Element.ALIGN_JUSTIFIED;
                        objects[k].Chunks[0].Font = fuenteColumnas;
                    }
                    else
                    {
                        ph = new Paragraph(" ");
                        ph.Alignment = Element.ALIGN_LEFT;
                        document.Add(ph);
                        ((PdfPTable)objects[k]).HorizontalAlignment = Element.ALIGN_LEFT;
                    }
                    document.Add((IElement)objects[k]);
                }
                sw.Close();
            }
            else
            {
                //***Cabecera sin HTML
                ph = new Paragraph(_reporteODP.ParrafoCabecera, fuenteColumnas);
                ph.Alignment = Element.ALIGN_JUSTIFIED;
                document.Add(ph);

                //***Anexos sin HTML
                document.Add(new Paragraph("  "));
                document.Add(new Paragraph("DETALLES DE ANEXOS:", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD)));
                ph = new Paragraph(_reporteODP.ParrafoAnexos, fuenteColumnas);
                ph.Alignment = Element.ALIGN_JUSTIFIED;
                document.Add(ph);
            }


            //***Id e iniciales del USUARIO
            document.Add(new Paragraph("  "));
            ph = new Paragraph(_reporteODP.IdUsuario + " - " + _reporteODP.InicUsuario, FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.NORMAL));
            ph.Alignment = Element.ALIGN_JUSTIFIED;
            document.Add(ph);


            //busca tablas del oficio
            for (int iRecorreR = 0; iRecorreR < _configTablas.NumeroTablas; iRecorreR++)
            {
                banderaResumen = false;
                //if (_configTablas.tablas.ElementAt(iRecorreR).TipoTabla == 3)
                //{
                //    _configColumnas = _configTablas.tablas.ElementAt(iRecorreR).VconfigColumnas;
                //    _dtrDatos = new DataTableReader(_dtsDatos.Tables[_configTablas.tablas.ElementAt(iRecorreR).NombreTabla]);
                //    document.Add(new Paragraph("  "));
                //    Genera_doctoPDFPTable(_configTablas.tablas.ElementAt(iRecorreR));
                //}
            }

            fuenteColumnas = DefineFuente(_configArchivo.Fuente.ToString(), (float)_configArchivo.SizeFuente);
            document.Add(new Paragraph("  "));
            document.Add(new Paragraph("  "));
            ph = new Paragraph(_leeConfigArchivo.Municipio != "" ? _leeConfigArchivo.Municipio + ", a " + _leeConfigArchivo.FechaGeneracion.ToLongDateString() + "." : "", fuenteColumnas);
            ph.Alignment = Element.ALIGN_CENTER;
            document.Add(ph);
            ph = new Paragraph(_leeConfigArchivo.Responsable1, fuenteColumnas);
            ph.Alignment = Element.ALIGN_CENTER;
            document.Add(ph);
            ph = new Paragraph(_leeConfigArchivo.Responsable2, fuenteColumnas);
            ph.Alignment = Element.ALIGN_CENTER;
            document.Add(ph);
        }

        public void Genera_doctoTexto()
        {
            ConfiguraTamañoArreglos();
            ConfiguraColumnas();
            fuenteColumnas = DefineFuente(nombrefuenteColumnas[0].ToString(), float.Parse(tamañofuenteColumnas[0].ToString()));
            Paragraph ph;
            while (_dtrDatos.Read())
            {
                ph = new Paragraph(_dtrDatos[0].ToString());
                //ph.Alignment = Element.ALIGN_JUSTIFIED;
                ph.Alignment = alineacionColumnas[0];
                ph.Font = fuenteColumnas;
                document.Add(ph);
                document.Add(Chunk.NEWLINE);
            }

        }
        public void Genera_doctoPDFPTable(descripcionTabla tabla)
        {

            //Document document = new Document();

            try
            {
                //PdfWriter writer =  PdfWriter.GetInstance (document,  new FileStream(_configArchivo.NombreArchivo , FileMode.Create));            

                //_configArchivo.ConfiguraMetaDatos(document);
                //_configArchivo.ConfiguraVista(writer);
                //_configArchivo.ConfiguraEncriptar(writer); 
                //_configArchivo.ConfiguraPagina(document);  

                //_configEncabezado.preconfigEncabezado(writer, document);
                //_configPiePagina.preconfigPiePagina(writer, document);

                ////Configurar margeb¡nes de acuerdo al largo del encabezado
                //float margen_izq = document.LeftMargin;
                //float margen_der = document.RightMargin;
                //float margen_sup = document.TopMargin;
                //float margen_inf = document.BottomMargin;                        
                //document.SetMargins (margen_izq,margen_der,margen_sup + _configEncabezado.table.TotalHeight  - 15,margen_inf + _configPiePagina.table.TotalHeight - 15);

                ////Abrir el docto.
                //document.Open();   
                ////Activar el manejador de eventos 
                //ControlEventos controlEventos = new ControlEventos(writer, document, _configEncabezado, _configPiePagina);
                //writer.PageEvent=controlEventos;            


                ConfiguraTamañoArreglos();

                //definir la estructura de la tabla
                PdfPTable datatable = new PdfPTable(_configColumnas.NumeroColumnas - _configColumnas.NumeroRompimientos);

                ConfiguraColumnas();
                ConfiguraTablaDatos(datatable);
                fuenteColumnas = DefineFuente();
                PoneEncabezado(datatable);

                //pone encabezado de tabla               
                Paragraph prEncabezado;
                if (tabla.EncabezadoTabla.Equals("") == false)
                {
                    prEncabezado = new Paragraph(tabla.EncabezadoTabla);
                    prEncabezado.Alignment = Element.ALIGN_CENTER;
                    prEncabezado.Font = fuenteColumnas;
                    document.Add(prEncabezado);
                    document.Add(Chunk.NEWLINE);
                }


                //Resumen, tambien se cambio indices para obtener valores de valoresConfiguracionx            
                if (_configArchivo.Resumen == true)
                {
                    banderaResumen = true;
                    //3 parametro valoresConfiguracionx.get(0).toString()
                    resumen = new Resumen(writer, document, _configArchivo.TituloResumen, _configColumnas, fuenteColumnas, _configColumnas.NumeroRompimientos);
                }

                //Evalua si se va a mostrar o no el detalle                                                                  
                if (_configArchivo.SuprimeDetalle == true)
                {
                    int nivelRompimiento = 0;
                    fuenteRompimiento = DefineFuente();
                    int cuentaRegistros = 0;
                    int contadorCampos = 0;

                    while (_dtrDatos.Read())
                    {
                        controlSalto = false;
                        contadorCampos = 0;
                        LeeRegistro();
                        if (banderaResumen == true)
                        {
                            //Para detectar si a habido un cambio en los rompimientos
                            nivelRompimiento = DetectaCambio();
                            if (nivelRompimiento < valoresRompimientos.Length)
                            {
                                if (cuentaRegistros > 0)
                                {
                                    //agregar registro a tabla de resumen                           
                                    agregaRegistroResumen();

                                    //Limpiar acumulados
                                    for (int indice = nivelRompimiento + 1; indice < valoresRompimientos.Length + 1; indice++)
                                    {
                                        for (int in2 = 0; in2 < _configColumnas.NumeroColumnas - _configColumnas.NumeroRompimientos; in2++)
                                        {
                                            if (acumuladoTotales[in2, indice] > 0)
                                                acumuladoTotales[in2, indice] = 0;
                                        }
                                    }
                                }

                            }

                            //cargar datos en acumulados totales
                            for (int indice = 0; indice < _configColumnas.NumeroColumnas; indice++)
                            {
                                if (_configColumnas.columnas.ElementAt(indice).TieneRompimiento == false)
                                {
                                    if (configuracionTotales[contadorCampos] > 0)
                                    {
                                        for (int in2 = 0; in2 < _configColumnas.NumeroRompimientos + 1; in2++)
                                            acumuladoTotales[contadorCampos, in2] = acumuladoTotales[contadorCampos, in2] + ValorEntero(valoresRegistro[indice], configuracionTotales[contadorCampos]);
                                    }
                                    contadorCampos++;
                                }
                            }

                            for (int indice = 0; indice < valoresRompimientos.Length; indice++)
                                valoresRompimientosAnterior[indice] = valoresRompimientos[indice];

                            cuentaRegistros += 1;
                        }
                        //////////////

                    }
                    if (banderaResumen == true)
                    {
                        //agregar registro a tabla de resumen                           
                        agregaRegistroResumen();
                    }
                }
                else
                {
                    if (_dtrDatos.HasRows == false)
                    {
                        //if (valoresRegistrosx.size() == 0){                
                        datatable.DefaultCell.Border = Rectangle.TOP_BORDER;
                        for (int i = 0; i < (_configColumnas.NumeroColumnas - _configColumnas.NumeroRompimientos); i++)
                            datatable.AddCell(" ");
                    }
                    if (_configColumnas.NumeroRompimientos == 0)
                    {
                        int vxx = 1;
                        int cuentaRegistros = 0;
                        while (_dtrDatos.Read())
                        {
                            //columnasContenido = valoresRegistrosx.get(i).toString();                                                  
                            LeeRegistro();
                            cuentaRegistros += 1;
                            AgregaRegistroPDFPTable(datatable);
                            if (cuentaRegistros == (4000 * vxx))
                            {
                                vxx++;
                                document.Add(datatable);
                                datatable = new PdfPTable(_configColumnas.NumeroColumnas);
                                ConfiguraTablaDatos(datatable);
                            }
                        }
                        document.Add(datatable);
                        //Poner impresion de totales
                        if (banderaPoneTotales)
                            PoneTablaTotal(document, 0);
                    }
                    else
                    {
                        //Configura una tabla vacia para ponerla entre rompimientos
                        PdfPTable tablaVacia = new PdfPTable(1);
                        //tablaVacia.setWidthPercentage(100); 
                        tablaVacia.DefaultCell.Border = 0;
                        tablaVacia.AddCell(new Paragraph(" ", fuenteColumnas));

                        int nivelRompimiento = 0;
                        fuenteRompimiento = DefineFuente();

                        int cuentaRegistros = 0;
                        //Recorrer los registros                    
                        while (_dtrDatos.Read())
                        {
                            //for ( int i = 0; i < xCC; i++ ){                        
                            controlSalto = false;
                            LeeRegistro();
                            //Para detectar si a habido un cambio en los rompimientos
                            nivelRompimiento = DetectaCambio();

                            if (nivelRompimiento < valoresRompimientos.Length)
                            {
                                //Genera tabla al encontrarse un rompimiento
                                String cadenaSangria = "                                        ";
                                PdfPTable tablaGrupo = new PdfPTable(_configColumnas.NumeroColumnas - _configColumnas.NumeroRompimientos);
                                ConfiguraTablaDatos(tablaGrupo);
                                PoneEncabezado(tablaGrupo);
                                if (datatable.Size > 1)
                                {
                                    document.Add(datatable);
                                }
                                datatable = tablaGrupo;

                                if (cuentaRegistros > 0)
                                {
                                    if (banderaResumen == true)
                                    {
                                        //agregar registro a tabla de resumen                           
                                        agregaRegistroResumen();
                                    }
                                    //Poner impresion totales
                                    if (banderaPoneTotales)
                                        PoneTablaTotal(document, nivelRompimiento + 1);
                                    //Limpiar acumulados
                                    for (int indice = nivelRompimiento + 1; indice < valoresRompimientos.Length + 1; indice++)
                                    {
                                        for (int in2 = 0; in2 < _configColumnas.NumeroColumnas - _configColumnas.NumeroRompimientos; in2++)
                                        {
                                            if (acumuladoTotales[in2, indice] > 0)
                                                acumuladoTotales[in2, indice] = 0;
                                        }
                                    }
                                    if (controlSalto)
                                    {
                                        document.NewPage();
                                    }
                                    else
                                    {
                                        document.Add(tablaVacia);
                                    }
                                }
                                //Pone los titulos de los rompimientos                                                 
                                for (int indice = nivelRompimiento; indice < valoresRompimientos.Length; indice++)
                                {
                                    //System.out.println(valoresRompimientos[in]);                            
                                    baseColor = 150;
                                    if ((baseColor + 25 * indice) > 255)
                                        baseColor = 150;
                                    else
                                        baseColor = 150 + 25 * indice;
                                    PdfPTable tablaRompimiento = new PdfPTable(1);
                                    ConfiguraTablaRompimientos(tablaRompimiento, baseColor);
                                    //busca el encabezado... esto se puede eficientar
                                    string encabezadoRomp = "";
                                    int indiceR = 0;
                                    for (int i = 0; i < _configColumnas.NumeroColumnas; i++)
                                    {
                                        if (_configColumnas.columnas.ElementAt(i).TieneRompimiento == true)
                                        {
                                            if (indice == indiceR)
                                            {
                                                encabezadoRomp = _configColumnas.columnas.ElementAt(i).EncabezadoRompimiento;
                                                break;
                                            }
                                            indiceR += 1;
                                        }
                                    }
                                    Paragraph ph = new Paragraph(cadenaSangria.Substring(0, indice * 4) + encabezadoRomp + ": " + valoresRompimientos[indice], fuenteRompimiento);
                                    tablaRompimiento.AddCell(ph);

                                    document.Add(tablaRompimiento);
                                    cadenaSangria = cadenaSangria + "   ";
                                }

                            }
                            //System.out.println(columnasContenido);                        
                            AgregaRegistroPDFPTable(datatable);
                            for (int indice = 0; indice < valoresRompimientos.Length; indice++)
                                valoresRompimientosAnterior[indice] = valoresRompimientos[indice];

                            cuentaRegistros += 1;
                        }
                        if (banderaResumen == true)
                        {
                            //agregar registro a tabla de resumen                           
                            agregaRegistroResumen();
                        }

                        if (datatable.Size > 1)
                        {
                            document.Add(datatable);
                            //section.add(datatable);
                        }

                        //Poner impresion de totales                
                        if (banderaPoneTotales)
                            PoneTablaTotal(document, 0);
                        //Inserta capitulo en el documento
                        //capitulo.remove(0);                   
                        //document.add(capitulo);                    
                    }
                }
                //Resumen prueba
                //if (banderaResumen == true){                
                //    //document.newPage();
                //    resumen.muestraVectores();
                //}
            }
            catch (DocumentException de)
            {
                //System.err.println(de.getMessage());            
                //bOk = false;
            }
            catch (IOException ioe)
            {
                //System.err.println(ioe.getMessage());            
                //bOk = false;
            }

            //document.Close();
        }

        private void agregaRegistroResumen()
        {
            //agregar datos a tabla resumen                            
            string[] temp = new string[resumen.vconfigColumnas.NumeroColumnas];
            int indiceR = 0;
            for (indiceR = 0; indiceR < valoresRompimientos.Length; indiceR++)
            {
                temp[indiceR] = _configArchivo.MostrarTotales == true ? "TOTAL DE " + valoresRompimientosAnterior[indiceR] + " " + _configArchivo.TotalFilas : valoresRompimientosAnterior[indiceR];
            }

            for (int indiceC = 0; indiceC < _configColumnas.NumeroColumnas - _configColumnas.NumeroRompimientos; indiceC++)
            {
                if (acumuladoTotales[indiceC, valoresRompimientos.Length] > 0)
                {
                    temp[indiceR] = acumuladoTotales[indiceC, valoresRompimientos.Length].ToString();
                    indiceR++;
                }
            }
            resumen.datosResumen.Tables["Datos"].Rows.Add(temp);
        }

        private void ConfiguraTamañoArreglos()
        {
            valoresRegistro = new String[_configColumnas.NumeroColumnas];
            valoresRompimientos = new String[_configColumnas.NumeroRompimientos];
            valoresRompimientosAnterior = new String[_configColumnas.NumeroRompimientos];
            alineacionColumnas = new int[_configColumnas.NumeroColumnas - _configColumnas.NumeroRompimientos];
            nombrefuenteColumnas = new string[_configColumnas.NumeroColumnas - _configColumnas.NumeroRompimientos];
            tamañofuenteColumnas = new string[_configColumnas.NumeroColumnas - _configColumnas.NumeroRompimientos];
            anchoColumnas = new float[_configColumnas.NumeroColumnas - _configColumnas.NumeroRompimientos];
            configuracionTotales = new int[_configColumnas.NumeroColumnas - _configColumnas.NumeroRompimientos];
            acumuladoTotales = new int[_configColumnas.NumeroColumnas - _configColumnas.NumeroRompimientos, _configColumnas.NumeroRompimientos + 1];
        }

        private void ConfiguraColumnas()
        {
            String valorAlineacion = "";
            int cuentaCol = 0;
            for (int i = 0; i < _configColumnas.NumeroColumnas; i++)
            {
                if (_configColumnas.columnas.ElementAt(i).TieneRompimiento == false)
                {
                    valorAlineacion = _configColumnas.columnas.ElementAt(i).AlineacionColumna;
                    if (valorAlineacion.Equals("L"))
                        alineacionColumnas[cuentaCol] = Element.ALIGN_LEFT;
                    if (valorAlineacion.Equals("R"))
                        alineacionColumnas[cuentaCol] = Element.ALIGN_RIGHT;
                    if (valorAlineacion.Equals("C"))
                        alineacionColumnas[cuentaCol] = Element.ALIGN_CENTER;
                    if (valorAlineacion.Equals("F"))
                        alineacionColumnas[cuentaCol] = Element.ALIGN_JUSTIFIED;
                    anchoColumnas[cuentaCol] = (float)(float.Parse(_configColumnas.columnas.ElementAt(i).LongitudColumna) / 1440) * 72;
                    configuracionTotales[cuentaCol] = _configColumnas.columnas.ElementAt(i).TotalColumna;
                    if (_configColumnas.columnas.ElementAt(i).TotalColumna > 0)
                    {
                        banderaPoneTotales = true;
                    }
                    nombrefuenteColumnas[cuentaCol] = _configColumnas.columnas.ElementAt(i).FuenteColumna.ToString();
                    tamañofuenteColumnas[cuentaCol] = _configColumnas.columnas.ElementAt(i).TamañoFuenteColumna;
                    cuentaCol += 1;
                }
            }
        }

        private void ConfiguraTablaDatos(PdfPTable datatablex)
        {
            try
            {
                datatablex.DefaultCell.Padding = 1;
                datatablex.WidthPercentage = 100;
                datatablex.SetWidths(anchoColumnas);
                datatablex.DefaultCell.PaddingTop = 0;
                datatablex.DefaultCell.PaddingBottom = 1;
                datatablex.DefaultCell.BorderColor = new BaseColor(150, 150, 150);
            }
            catch (DocumentException de)
            {
                //System.err.println(de.getMessage());
            }
        }

        private void ConfiguraTablaRompimientos(PdfPTable datatablex, int baseColorx)
        {
            datatablex.WidthPercentage = 100;
            datatablex.DefaultCell.BorderColor = (new BaseColor(150, 150, 150));
            datatablex.DefaultCell.BackgroundColor = (new BaseColor(baseColorx, baseColorx, baseColorx));
            datatablex.DefaultCell.PaddingTop = 0;
            datatablex.DefaultCell.PaddingBottom = 3;
        }

        private Font DefineFuente()
        {
            String nombreFuente = "Arial";
            float tamañoFuente = 12;
            nombreFuente = _configArchivo.Fuente.ToString();
            tamañoFuente = (float)_configArchivo.SizeFuente;
            return FontFactory.GetFont(nombreFuente, tamañoFuente, Font.NORMAL);
        }

        private Font DefineFuente(string _fuente, float _size)
        {
            return FontFactory.GetFont(_fuente,_size, Font.NORMAL);
        }

        private void PoneEncabezado(PdfPTable datatablex)
        {
            Font fuentEncabezado;
            fuentEncabezado = DefineFuente();
            fuentEncabezado.SetColor(BaseColor.WHITE.R, BaseColor.WHITE.G, BaseColor.WHITE.B);
            int cuentaCol = 0;

            if (_configColumnas.EncabezadoPersonalizado == true)
            {
                PdfPTable datatableT = new PdfPTable(anchoColumnas);
                ConfiguraTablaDatos(datatableT);
                datatableT.DefaultCell.Colspan = 1;
                datatableT.DefaultCell.Rowspan = 1;
                datatableT.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                datatableT.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                datatableT.DefaultCell.BackgroundColor = new BaseColor(100, 100, 100);
                datatableT.DefaultCell.BorderColor = new BaseColor(120, 120, 120);

                for (int i = 0; i < _configColumnas.celdasEncabezadoPersonalizado.Count(); i++)
                {
                    datatableT.DefaultCell.Colspan = _configColumnas.celdasEncabezadoPersonalizado.ElementAt(i).ExpandeColumnasCelda;
                    datatableT.DefaultCell.Rowspan = _configColumnas.celdasEncabezadoPersonalizado.ElementAt(i).ExpandeRenglonesCelda;
                    datatableT.AddCell(new Phrase(_configColumnas.celdasEncabezadoPersonalizado.ElementAt(i).ValorCelda, fuentEncabezado));

                }
                datatableT.DefaultCell.Colspan = 1;
                datatableT.DefaultCell.Rowspan = 1;
                PdfPCell cellE = new PdfPCell(datatableT);
                cellE.BorderColor = new BaseColor(120, 120, 120);
                cellE.Colspan = _configColumnas.NumeroColumnas - _configColumnas.NumeroRompimientos;
                datatablex.AddCell(cellE);
            }


            for (int i = 0; i < _configColumnas.NumeroColumnas; i++)
            {
                if (_configColumnas.columnas.ElementAt(i).TieneRompimiento == false)
                {
                    if (anchoColumnas[cuentaCol] == 0)
                    {
                        datatablex.AddCell("");
                    }
                    else
                    {
                        Paragraph ph = new Paragraph(_configColumnas.columnas.ElementAt(i).EncabezadoColumna, fuentEncabezado);
                        PdfPCell cell = new PdfPCell(ph);
                        cell.BackgroundColor = new BaseColor(100, 100, 100);
                        cell.BorderColor = new BaseColor(120, 120, 120);
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        datatablex.AddCell(cell);
                    }
                    cuentaCol += 1;
                }
            }
            if (_configColumnas.EncabezadoPersonalizado == true)
                datatablex.HeaderRows = 2;
            else
                datatablex.HeaderRows = 1;
        }

        private void LeeRegistro()
        {
            int contadorCelda = 0;

            //por lo pronto al configurar las columnas, estas deben de estar en el
            //mismo orden en que esta la consulta, despues hacemos esto dinamico
            for (int i = 0; i < _dtrDatos.FieldCount; i++)
            {
                valoresRegistro[i] = _dtrDatos[i].ToString();
                if (_configColumnas.columnas.ElementAt(i).TieneRompimiento == true)
                {
                    valoresRompimientos[contadorCelda] = _dtrDatos[i].ToString();
                    contadorCelda++;
                }
            }
            //Resumen
            //if (banderaResumen == true)
            //    resumen.leeRegistroResumen(valoresRegistro);

        }

        private void AgregaRegistroPDFPTable(PdfPTable datatablex)
        {
            String valorExtraido = "";

            //para multivalor
            System.Collections.Generic.List<string>[] valoresCompos = new System.Collections.Generic.List<string>[_configColumnas.NumeroColumnas - _configColumnas.NumeroRompimientos];
            //Vector [] valoresCompos = new Vector[_configColumnas.NumeroColumnas];
            for (int i = 0; i < _configColumnas.NumeroColumnas - _configColumnas.NumeroRompimientos; i++)
            {
                valoresCompos[i] = new System.Collections.Generic.List<string>();
            }
            int contadorCampos = 0;
            int contadorRenglones = datatablex.Size;
            int contadorRenglonesInicio = datatablex.Size;
            int numeroMayor = 0;
            Boolean banderaTraeMV = false;

            for (int indice = 0; indice < _configColumnas.NumeroColumnas; indice++)
            {
                if (_configColumnas.columnas.ElementAt(indice).TieneRompimiento == false)
                {
                    //if (indice >= rompimientosx.size()){                                                                      
                    valorExtraido = valoresRegistro[indice];
                    if (configuracionTotales[contadorCampos] > 0)
                    {
                        for (int in2 = 0; in2 < _configColumnas.NumeroRompimientos + 1; in2++)
                        {
                            switch (configuracionTotales[contadorCampos])
                            {
                                case 1: //suma
                                    acumuladoTotales[contadorCampos, in2] = acumuladoTotales[contadorCampos, in2] + ValorEntero(valoresRegistro[indice], configuracionTotales[contadorCampos]);
                                    break;
                                case 2: //cuenta
                                    acumuladoTotales[contadorCampos, in2] = acumuladoTotales[contadorCampos, in2] + 1;
                                    break;

                            }

                        }
                    }
                    //Detectar si trae multivalor                              
                    if (valorExtraido.IndexOf("ü") < 0)
                    {
                        System.Collections.Generic.List<string> valorExt = new System.Collections.Generic.List<string>();
                        valorExt.Add(valorExtraido);
                        valoresCompos[contadorCampos] = valorExt;
                        if (1 > numeroMayor)
                            numeroMayor = 1;
                    }
                    else
                    {
                        banderaTraeMV = true;
                        valoresCompos[contadorCampos] = extraeValores(valorExtraido, "ü");
                        if (valoresCompos[contadorCampos].Count > numeroMayor)
                            numeroMayor = valoresCompos[contadorCampos].Count;
                    }
                    contadorCampos++;
                }
            }

            for (int i = 0; i < numeroMayor; i++)
            {
                int indice;

                for (int indice2 = 0; indice2 < valoresCompos.Length; indice2++)
                {
                    if (valoresCompos[indice2].Count > i)
                    {
                        valorExtraido = valoresCompos[indice2].ElementAt(i);
                        //Para cambiar %u% a ú
                        indice = valorExtraido.IndexOf("%u%");
                        if (indice >= 0)
                        {
                            while (indice >= 0)
                            {
                                valorExtraido = valorExtraido.Substring(0, indice) + "ú" + valorExtraido.Substring(indice + 3);
                                indice = valorExtraido.IndexOf("%u%");
                            }
                        }
                    }
                    else
                        valorExtraido = " ";

                    //Formar tipo de borde
                    if (numeroMayor == 1)
                    {
                        if (_configArchivo.FormatoCuadricula.Equals("4"))
                        {
                            if (indice2 == 0)
                                datatablex.DefaultCell.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER;
                            else if (indice2 == valoresCompos.Length - 1)
                                datatablex.DefaultCell.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER;
                            else
                                datatablex.DefaultCell.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER;
                        }
                        if (_configArchivo.FormatoCuadricula.Equals("7"))
                        {
                            datatablex.DefaultCell.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                        } if (_configArchivo.FormatoCuadricula.Equals("9"))
                        {
                            if (banderaTraeMV == false)
                            {
                                if (numeroMayor == 1)
                                    datatablex.DefaultCell.Border = Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                                else
                                    datatablex.DefaultCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                            }
                            else
                            {
                                if (i == 0)
                                    if (numeroMayor == 1)
                                        datatablex.DefaultCell.Border = Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                                    else
                                        datatablex.DefaultCell.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER;
                                else
                                {
                                    if (i == numeroMayor - 1)
                                        datatablex.DefaultCell.Border = Rectangle.BOTTOM_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER;
                                    else
                                        datatablex.DefaultCell.Border = Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (_configArchivo.FormatoCuadricula.Equals("4"))
                        {
                            if (i == 0)
                            {
                                if (indice2 == 0)
                                    datatablex.DefaultCell.Border = Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER;
                                else if (indice2 == valoresCompos.Length - 1)
                                    datatablex.DefaultCell.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER;
                                else
                                    datatablex.DefaultCell.Border = Rectangle.TOP_BORDER;
                            }
                            else if (i == numeroMayor - 1)
                            {
                                if (indice2 == 0)
                                    datatablex.DefaultCell.Border = Rectangle.BOTTOM_BORDER | Rectangle.LEFT_BORDER;
                                else if (indice2 == valoresCompos.Length - 1)
                                    datatablex.DefaultCell.Border = Rectangle.BOTTOM_BORDER | Rectangle.RIGHT_BORDER;
                                else
                                    datatablex.DefaultCell.Border = Rectangle.BOTTOM_BORDER;
                            }
                            else
                            {
                                if (indice2 == 0)
                                    datatablex.DefaultCell.Border = Rectangle.LEFT_BORDER;
                                else if (indice2 == valoresCompos.Length - 1)
                                    datatablex.DefaultCell.Border = Rectangle.RIGHT_BORDER;
                                else
                                    datatablex.DefaultCell.Border = Rectangle.NO_BORDER;
                            }
                        }
                        if (_configArchivo.FormatoCuadricula.Equals("7"))
                        {
                            datatablex.DefaultCell.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                        }
                        if (_configArchivo.FormatoCuadricula.Equals("9"))
                        {
                            if (i == 0)
                                datatablex.DefaultCell.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER;
                            else
                            {
                                if (i == numeroMayor - 1)
                                    datatablex.DefaultCell.Border = Rectangle.BOTTOM_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER;
                                else
                                    datatablex.DefaultCell.Border = Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER;
                            }
                        }
                    }


                    if (anchoColumnas[indice2] == 0)
                    {
                        datatablex.AddCell("");
                    }
                    else
                    {
                        datatablex.DefaultCell.HorizontalAlignment = alineacionColumnas[indice2];
                        //Paragraph ph = new Paragraph(valorExtraido, fuenteColumnas);               
                        fuenteColumnas = DefineFuente(nombrefuenteColumnas[indice2], float.Parse(tamañofuenteColumnas[indice2]));
                        Paragraph ph = new Paragraph(valorExtraido, fuenteColumnas);
                        datatablex.AddCell(ph);
                    }
                }
            }
        }

        private int ValorEntero(String texto)
        {
            int valor;
            texto = texto.Trim();
            try
            {
                valor = int.Parse(texto);
            }
            catch (FormatException nfe)
            {
                valor = 0;
            }
            return valor;
        }

        private int ValorEntero(String texto, int tipoCalculo)
        {
            int valor;
            texto = texto.Trim();
            try
            {
                valor = int.Parse(texto);
            }
            catch (FormatException nfe)
            {
                valor = 0;
            }

            switch (tipoCalculo)
            {
                case 1: //suma                    
                    break;
                case 2: //conteo
                    valor = 1;
                    break;
            }

            return valor;
        }

        private System.Collections.Generic.List<string> extraeValores(String texto, String separador)
        {
            //Vector datos = new Vector();
            System.Collections.Generic.List<string> datos = new System.Collections.Generic.List<string>();
            int indice = texto.IndexOf(separador);
            while (indice >= 0)
            {
                //System.out.println("ValorMV:" + texto.substring(0, indice));
                datos.Add(texto.Substring(0, indice));
                texto = texto.Substring(indice + 1);
                indice = texto.IndexOf(separador);
            }
            if (texto.Length > 0)
                datos.Add(texto);
            return datos;
        }

        private void PoneTablaTotal(Document documentx, int limiteNivel)
        {

            for (int indice = valoresRompimientos.Length; indice >= limiteNivel; indice--)
            {
                if (indice == 0)
                    baseColor = 150;
                else
                {
                    baseColor = 150;
                    if ((baseColor + 25 * (indice - 1)) > 255)
                        baseColor = 150;
                    else
                        baseColor = 150 + 25 * (indice - 1);
                }
                PdfPTable tablaTotal = new PdfPTable(_configColumnas.NumeroColumnas - _configColumnas.NumeroRompimientos);
                ConfiguraTablaTotal(tablaTotal, baseColor);
                AgregaTotales(tablaTotal, indice);
                try
                {
                    documentx.Add(tablaTotal);
                }
                catch (DocumentException de)
                {
                    //System.err.println(de.getMessage());
                }
            }
        }

        private void AgregaTotales(PdfPTable datatablex, int nivelTotal)
        {
            String valorCelda = "";
            for (int indice = 0; indice < _configColumnas.NumeroColumnas - _configColumnas.NumeroRompimientos; indice++)
            {
                if (acumuladoTotales[indice, nivelTotal] > 0)
                    valorCelda = acumuladoTotales[indice, nivelTotal].ToString();
                else
                    valorCelda = "";
                datatablex.DefaultCell.HorizontalAlignment = alineacionColumnas[indice];
                Paragraph ph = new Paragraph(valorCelda, fuenteColumnas);
                datatablex.AddCell(ph);
            }
        }

        private void ConfiguraTablaTotal(PdfPTable datatablex, int baseColorx)
        {
            try
            {
                datatablex.DefaultCell.Padding = 1;
                datatablex.WidthPercentage = 100;
                datatablex.SetWidths(anchoColumnas);
                datatablex.DefaultCell.PaddingTop = 0;
                datatablex.DefaultCell.PaddingBottom = 1;
                datatablex.DefaultCell.BorderColor = (new BaseColor(baseColorx, baseColorx, baseColorx));
                datatablex.DefaultCell.Border = Rectangle.BOTTOM_BORDER;
                //datatablex.getDefaultCell().setBorderColor(new Color(150,150,150));  
                //datatablex.getDefaultCell().setBackgroundColor(new Color(baseColorx,baseColorx,baseColorx));   
            }
            catch (DocumentException de)
            {
                //System.err.println(de.getMessage());
            }
        }

        private int DetectaCambio()
        {
            int nsalto = valoresRompimientos.Length;
            for (int indice = 0; indice < valoresRompimientos.Length; indice++)
            {
                if (valoresRompimientos[indice].Equals(valoresRompimientosAnterior[indice]) == false)
                {
                    int indiceR = 0;
                    for (int i = 0; i < _configColumnas.NumeroColumnas; i++)
                    {
                        if (_configColumnas.columnas.ElementAt(i).TieneRompimiento == true)
                        {
                            if (indice == indiceR)
                            {
                                if (_configColumnas.columnas.ElementAt(i).SaltoRompimiento == true)
                                {
                                    controlSalto = true;
                                    break;
                                }
                            }
                            indiceR += 1;
                        }
                    }
                    nsalto = indice;
                    break;
                }
            }
            return nsalto;
        }
    }
}
