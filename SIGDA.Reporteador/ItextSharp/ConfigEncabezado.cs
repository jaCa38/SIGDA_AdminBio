using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Org.BouncyCastle.Asn1.Cms;

namespace SIGDA.Reporteador.ItextSharp
{
    public class ConfigEncabezado
    {
        private String dibujo = "c:\\poder judicial.gif";
        private String descripcion1 = "";
        private String descripcion2 = "";
        private int tipo = 1;
        public PdfPTable table = new PdfPTable(2);
        private bool _mostrar = true;

        public string Dibujo
        {
            get
            {
                return dibujo;
            }
            set
            {
                dibujo = value;
            }
        }
        public string Descripcion1
        {
            get
            {
                return descripcion1;
            }
            set
            {
                descripcion1 = value;
            }
        }
        public string Descripcion2
        {
            get
            {
                return descripcion2;
            }
            set
            {
                descripcion2 = value;
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

        public void preconfigEncabezado(PdfWriter writer, Document document)
        {
            ConfiguraEncabezado(document);
        }

        public void ConfiguraEncabezado(Document document)
        {
            MemoryStream mems = null;
            System.Drawing.Image img = null;
            try
            {
                float ancho = 0;
                int borde = 0;
                String descripcion = "";
                if (Tipo == 1)
                    borde = 0;
                if (Tipo == 2)
                    borde = Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER;
                ancho = document.PageSize.Width - (document.LeftMargin + document.RightMargin);
                table.TotalWidth = ancho;
                float[] f = { (float)(ancho * .20), (float)(ancho - (ancho * .20)) };
                table.SetTotalWidth(f);
                table.DefaultCell.Border = borde;
                table.DefaultCell.Padding = 1;

                //Aquí se agrega la imagen del encabezado
                mems = new MemoryStream();

                img = SIGDA.Reporteador.Properties.Resources.poder_judicial; 
                img.Save(mems, System.Drawing.Imaging.ImageFormat.Gif);
                iTextSharp.text.Image img2 = iTextSharp.text.Image.GetInstance(mems.ToArray());
                img2.Alignment = Element.ALIGN_CENTER;
                img2.ScalePercent(50);

                //Image img = Image.GetInstance(Dibujo);
                //img.Alignment = Element.ALIGN_CENTER;
                //img.ScalePercent(50);

                table.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                table.DefaultCell.VerticalAlignment = Element.ALIGN_TOP;
                
                PdfPCell cell = new PdfPCell(img2);
                cell.Padding = 1;
                //cell.setBackgroundColor(new Color(0, 0, 255));
                cell.Border = borde;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(cell);
                
                if (descripcion1.Equals("") == false)
                    descripcion = descripcion1;

                if (descripcion2.Equals("") == false)
                {
                    if (descripcion.Equals("") == false)
                        descripcion = descripcion1 + "\n" + descripcion2;
                    else
                        descripcion = descripcion2;
                }

                Font font = FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD);
                Paragraph ph = new Paragraph(descripcion, font);

                ph.Alignment = Element.ALIGN_RIGHT;
                table.AddCell(ph);
            }
            catch (Exception de)
            {
                //de.printStackTrace();
            }
            finally
            {
                if (mems != null) mems.Dispose();
                if (img != null) img.Dispose();
            }

        }

        public void PoneEncabezado(PdfWriter writer, Document document)
        {
            try
            {
                table.WriteSelectedRows(0, -1, document.LeftMargin, document.PageSize.Height - 15, writer.DirectContent);
            }
            catch (Exception de)
            {
                //de.printStackTrace();
            }
        }

    }
}
