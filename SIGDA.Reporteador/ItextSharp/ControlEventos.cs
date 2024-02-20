using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.events;
using iTextSharp.text.factories;

namespace SIGDA.Reporteador.ItextSharp
{
    class ControlEventos : PdfPageEventHelper
    {
        //class ControlEventos extends PdfPageEventHelper {
        Document document1;
        PdfWriter writer1;
        ConfigEncabezado encabezado1;
        ConfigPiePagina pie1;

        public ControlEventos(PdfWriter writerx, Document documentx, ConfigEncabezado encabezadox, ConfigPiePagina piex)
        {
            encabezado1 = encabezadox;
            document1 = documentx;
            writer1 = writerx;
            pie1 = piex;
        }

        // the paragraph number
        private int n = 0;

        public override void OnEndPage(PdfWriter writer, Document document)
        {

            base.OnEndPage(writer, document);
            if (encabezado1.Mostrar)
                encabezado1.PoneEncabezado(writer1, document1);
            if (pie1.MostrarOtroTitulo)
                pie1.PreFormaTabla(writer1, document1, eTipoReporte.ListaDeAcuerdos);
            if(pie1.Mostrar)    
                pie1.PonePie2(writer1, document1);
        }

        // we override only the onParagraph method
        //public void OnParagraph(PdfWriter writer, Document document, float position) {}    
        //public void OnChapter(PdfWriter pdfWriter, Document document, float param, Paragraph paragraph) {}    
        //public void OnChapterEnd(PdfWriter pdfWriter, Document document, float param) {}    
        //public void OnCloseDocument(PdfWriter pdfWriter, Document document) {} 


        //public void OnEndPage(PdfWriter pdfWriter, Document document) {
        //    encabezado1.PoneEncabezado(writer1, document1);
        //    pie1.PonePie2(writer1, document1);
        //}    
        //public void OnGenericTag(PdfWriter pdfWriter, Document document, Rectangle rectangle, String str) {}    
        //public void OnOpenDocument(PdfWriter pdfWriter, Document document) {}    
        //public void OnParagraphEnd(PdfWriter pdfWriter, Document document, float param) {}    
        //public void OnSection(PdfWriter pdfWriter, Document document, float param, int param3, Paragraph paragraph) {}    
        //public void OnSectionEnd(PdfWriter pdfWriter, Document document, float param) {}    
        //public void OnStartPage(PdfWriter pdfWriter, Document document) {
        ////pie1.PonePie(writer1, document1);
        //}

    }
}
