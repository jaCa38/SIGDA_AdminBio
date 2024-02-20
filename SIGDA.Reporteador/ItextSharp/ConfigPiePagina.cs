using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SIGDA.Reporteador.ItextSharp
{
    public class ConfigPiePagina
    {
        private String columnaIzq = "";
        private String columnaCen = "";
        private String columnaDer = "";
        string _leyendaAnual = string.Empty;
        private int tipo = 1;
        private float ancho = 0;
        //Cambio prueba
        private int borde = Rectangle.TOP_BORDER;
        private Font fuente;
        private String fecha = "";
        private String hora = "";
        PdfWriter writer;
        //nuevo funcionamiento        
        private List<string> elementosPie = new List<string>();
        public PdfPTable table;
        private bool _mostrar = false;
        
        public string TituloFooter { set; get; }

        public string ColumnaIzq
        {
            get
            {
                return columnaIzq;
            }
            set
            {
                columnaIzq = value;
            }
        }
        public bool Mostrar
        {
            get
            {
                return _mostrar;
            }
            set
            {
                _mostrar = value;
            }
        }
        public bool MostrarOtroTitulo { set; get; }
        public string ColumnaCen
        {
            get
            {
                return columnaCen;
            }
            set
            {
                columnaCen = value;
            }
        }
        public string ColumnaDer
        {
            get
            {
                return columnaDer;
            }
            set
            {
                columnaDer = value;
            }
        }
        public int Tipo
        {
            get
            {
                return tipo;
            }
            set
            {
                tipo = value;
            }
        }
        public float Ancho
        {
            get
            {
                return ancho;
            }
            set
            {
                ancho = value;
            }
        }
        public int Borde
        {
            get
            {
                return borde;
            }
            set
            {
                borde = value;
            }
        }
        public Font Fuente
        {
            get
            {
                return fuente;
            }
            set
            {
                fuente = value;
            }
        }
        public string Fecha
        {
            get
            {
                return fecha;
            }
            set
            {
                fecha = value;
            }
        }
        public string Hora
        {
            get
            {
                return hora;
            }
            set
            {
                hora = value;
            }
        }
        
        public string LeyendaAnual { set { _leyendaAnual = value; } get { return _leyendaAnual; } }

        public void preconfigPiePagina(PdfWriter writerx, Document document)
        {
            ConfiguraPie(document);
            writer = writerx;
            PreFormaTabla(writer, document);
        }
        public void preconfigPiePagina(PdfWriter writerx, Document document,eTipoReporte tipoReporte)
        {
            ConfiguraPie(document);
            writer = writerx;
            PreFormaTabla(writer, document,tipoReporte);
        }
        
        public void ConfiguraPie(Document document)
        {
            Fuente = FontFactory.GetFont(FontFactory.HELVETICA, 9, Font.NORMAL);
            try
            {
                if (Tipo == 1)
                    borde = 0;
                if (Tipo == 2)
                    Borde = Rectangle.TOP_BORDER;
                ancho = document.PageSize.Width - (document.LeftMargin + document.RightMargin);
            }
            catch (Exception de)
            {
                //de.printStackTrace();
            }
        }

        public String ValoresColumna2(String valor)
        {
            String celda = "";
            if (!valor.Equals(""))
            {
                if (valor.IndexOf("P") >= 0)
                    valor = valor.Replace("P", writer.PageNumber.ToString());
                celda = valor;
            }
            return celda;
        }

        public String ValoresColumna(String valor)
        {
            String celda = "";
            if (!valor.Equals(""))
            {
                if (valor.Equals("D"))
                {
                    celda = "INFORME IMPRESO DESDE PLATAFORMA SIGDA EL DÍA: " + Fecha + "." + this.LeyendaAnual;
                }
                else
                {
                    if (valor.Equals("T"))
                    {
                        celda = "HORA:" + Hora;
                    }
                    else
                    {
                        if (valor.Equals("P"))
                            celda = "PÁGINA:" + writer.PageNumber.ToString();
                        else
                            celda = valor;
                    }
                }
            }
            return celda;
        }

        public void PreFormaTabla(PdfWriter writerx, Document document)
        {
            try
            {
                writer = writerx;
                table = new PdfPTable(elementosPie.Count);
                table.TotalWidth = Ancho;

                table.DefaultCell.Border = Borde;
                table.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                table.DefaultCell.VerticalAlignment = Element.ALIGN_TOP;

                for (int indice = 0; indice < elementosPie.Count; indice++)
                {
                    PdfPCell celda = new PdfPCell(new Paragraph(ValoresColumna(elementosPie.ElementAt(indice)), Fuente));
                    celda.Padding = 1;
                    //cell.setBackgroundColor(new Color(0, 0, 255));
                    celda.Border = Borde;
                    celda.HorizontalAlignment = Element.ALIGN_CENTER;
                    if (indice == 0)
                        celda.HorizontalAlignment = Element.ALIGN_LEFT;
                    if (indice == elementosPie.Count - 1)
                        celda.HorizontalAlignment = Element.ALIGN_RIGHT;
                    table.AddCell(celda);
                }
                    //table.WriteSelectedRows(0, -1, document.LeftMargin, table.TotalHeight + 15, writer.DirectContent);                  
            }
            catch (Exception de)
            {
                //de.printStackTrace();
            }
        }
        public void PreFormaTabla(PdfWriter writerx, Document document,eTipoReporte tipoReporte)
        {
            try
            {
                writer = writerx;

                PdfPTable table = new PdfPTable(3);
                table.TotalWidth = Ancho;
                table.DefaultCell.Border = Borde;
                table.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.DefaultCell.VerticalAlignment = Element.ALIGN_TOP;
                
                /*NOMBRE DEL SECRETARIO DE ACUERDOS*/
                PdfPCell cell = new PdfPCell(new Paragraph(TituloFooter.Trim().ToUpper(), Fuente));
                cell.Colspan = 3;
                cell.Padding = 1;
                cell.Border = 0;
                cell.HorizontalAlignment = 1; //0=Left, 1=Center, 2=Right
                table.AddCell(cell);

                /*LEYENDA C. Secretario(a) de Acuerdos*/
                Font fuenteLeyenda = FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD);
                cell = new PdfPCell(new Paragraph("C. Secretario(a) de Acuerdos", fuenteLeyenda));
                cell.Colspan = 3;
                cell.Padding = 1;
                cell.Border = 0;
                cell.HorizontalAlignment = 1; //0=Left, 1=Center, 2=Right
                table.AddCell(cell);

                /*INGRESO RENGLONES VACIOS PARA SEPARAR*/
                for (int i = 0; i < 10; i++)
                {
                    cell = new PdfPCell(new Paragraph(""));
                    cell.Colspan = 3;
                    cell.Padding = 1;
                    cell.Border = 0;
                    cell.HorizontalAlignment = 1; //0=Left, 1=Center, 2=Right
                    table.AddCell(cell);
                }

                /*INGRESAMOS FECHA, HORA DE IMPRESIÓN Y NÚMERO DE PÁGINA*/
                for (int indice = 0; indice < elementosPie.Count; indice++)
                {
                    PdfPCell celda = new PdfPCell(new Paragraph(ValoresColumna(elementosPie.ElementAt(indice)), Fuente));
                    celda.Padding = 1;
                    //cell.setBackgroundColor(new Color(0, 0, 255));
                    celda.Border = Borde;
                    celda.HorizontalAlignment = Element.ALIGN_CENTER;
                    if (indice == 0)
                        celda.HorizontalAlignment = Element.ALIGN_LEFT;
                    if (indice == elementosPie.Count - 1)
                        celda.HorizontalAlignment = Element.ALIGN_RIGHT;
                    table.AddCell(celda);
                }

                table.WriteSelectedRows(0, -1, document.LeftMargin, table.TotalHeight + 15, writer.DirectContent);
            }
            catch (Exception de)
            {
                //de.printStackTrace();
            }
        }

        public void PonePie2(PdfWriter writerx, Document document)
        {
            try
            {
                writer = writerx;
                table = new PdfPTable(elementosPie.Count);
                table.TotalWidth = Ancho;

                table.DefaultCell.Border = Borde;
                table.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                table.DefaultCell.VerticalAlignment = Element.ALIGN_TOP;

                for (int indice = 0; indice < elementosPie.Count; indice++)
                {
                    PdfPCell celda = new PdfPCell(new Paragraph(ValoresColumna(elementosPie.ElementAt(indice)), Fuente));
                    celda.Padding = 1;
                    //cell.setBackgroundColor(new Color(0, 0, 255));
                    celda.Border = Borde;
                    celda.HorizontalAlignment = Element.ALIGN_CENTER;
                    if (indice == 0)
                        celda.HorizontalAlignment = Element.ALIGN_LEFT;
                    if (indice == elementosPie.Count - 1)
                        celda.HorizontalAlignment = Element.ALIGN_RIGHT;
                    table.AddCell(celda);
                }
                table.WriteSelectedRows(0, -1, document.LeftMargin, table.TotalHeight + 15, writer.DirectContent);
            }
            catch (Exception de)
            {
                //de.printStackTrace();
            }
        }

        public void PonePie(PdfWriter writerx, Document document)
        {
            try
            {
                writer = writerx;
                PdfPTable table = new PdfPTable(3);
                table.TotalWidth = Ancho;

                table.DefaultCell.Border = Borde;
                table.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                table.DefaultCell.VerticalAlignment = Element.ALIGN_TOP;

                PdfPCell celda1 = new PdfPCell(new Paragraph(ValoresColumna(columnaIzq), Fuente));
                celda1.Padding = 1;
                //cell.setBackgroundColor(new Color(0, 0, 255));
                celda1.Border = Borde;
                celda1.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(celda1);

                PdfPCell celda2 = new PdfPCell(new Paragraph(ValoresColumna(columnaCen), Fuente));
                celda2.Padding = 1;
                //cell.setBackgroundColor(new Color(0, 0, 255));
                celda2.Border = Borde;
                celda2.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(celda2);

                PdfPCell celda3 = new PdfPCell(new Paragraph(ValoresColumna(columnaDer), Fuente));
                celda3.Padding = 1;
                //cell.setBackgroundColor(new Color(0, 0, 255));
                celda3.Border = Borde;
                celda3.HorizontalAlignment = Element.ALIGN_RIGHT;
                table.AddCell(celda3);
                table.WriteSelectedRows(0, -1, document.LeftMargin, table.TotalHeight + 15, writer.DirectContent);
            }
            catch (Exception de)
            {
                //de.printStackTrace();
            }
        }

        public void AgregarElementoPie(string vElemento)
        {
            elementosPie.Add(vElemento);
        }

    }
}
