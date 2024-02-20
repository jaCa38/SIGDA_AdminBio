using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SIGDA.Reporteador.ItextSharp
{
    public class ConfigArchivo
    {
        private string _nombreArchivo = string.Empty;
        private eOrientacion _orientacionPagina = 0;
        private eTipoHoja _tipoHoja = eTipoHoja.Carta;
        private float _margenIzquierdo = .5f;
        private float _margenSuperior = .5f;
        private float _margenDerecho = .5f;
        private float _margenInferior = .5f;
        private string _marcaAgua = string.Empty;
        private string _formatoCuadricula = "9";
        private Boolean _resumen = false;
        private Boolean _suprimeDetalle = false;
        private string _tituloResumen = string.Empty;
        private eTipoFuente _fuente = eTipoFuente.Arial;
        private eSizeFuente _sizeFuente = eSizeFuente.Standar;
        //private Boolean _oficio = false;
        eTipoReporte _tipoReporte = eTipoReporte.Oficio;
        Boolean _habilitarHTML = false;
        Boolean _mostarTotales = false;
        long _totalFilas = 0;


        //metaDatos del documento
        private string _titulo = "Supremo Tribunal de Justicia";
        private string _referencia = "Supremo Tribunal de Justicia";
        private string _palabrasClaves = "";
        private string _autor = "";
        private string _creador = "";
        private Boolean _bFecha = true;
        private Boolean _bProductor = true;
        
        //preferencias de encripción
        private Boolean _bImprimir = false;
        private Boolean _bModificar = false;
        private Boolean _bCopiar = false;
        private Boolean _bModificarAnotaciones = false;
        private Boolean _bLlenar = false;
        private Boolean _bEnsamblar = false;
        private Boolean _bAccesibilidad_contenido = false;
        private Boolean _bDegragar = false;
        private string _pwd = "";
        
        //preferencias de vista del documento
        private string _layout = "1p";
        private string _modo = "n";
        private string _bfullScreen = "";
        private Boolean _bToolBar = false;
        private Boolean _bMenuBar = true;
        private Boolean _bWindow = true;
        private Boolean _bAjustar = false;
        private Boolean _bCentrar = false;

        //propiedades de pagina

        public string NombreArchivo
        {
            get
            {
                return _nombreArchivo;
            }
            set
            {
                _nombreArchivo = value;
            }
        }
        public long TotalFilas
        {
            get
            {
                return _totalFilas;
            }
            set
            {
                _totalFilas = value;
            }
        }

        public Boolean HabilitarHTML
        {
            get
            {
                return _habilitarHTML;
            }
            set
            {
                _habilitarHTML = value;
            }
        }
        public Boolean MostrarTotales
        {
            get
            {
                return _mostarTotales;
            }
            set
            {
                _mostarTotales = value;
            }
        }
        public eTipoReporte TipoReporte
        {
            get
            {
                return _tipoReporte;
            }
            set
            {
                _tipoReporte = value;
            }
        }
        public Boolean Resumen
        {
            get
            {
                return _resumen;
            }
            set
            {
                _resumen = value;
            }
        }
        public Boolean SuprimeDetalle
        {
            get
            {
                return _suprimeDetalle;
            }
            set
            {
                _suprimeDetalle = value;
            }
        }
        public string TituloResumen
        {
            get
            {
                return _tituloResumen;
            }
            set
            {
                _tituloResumen = value;
            }
        }
        public eTipoHoja TipoHoja
        {
            get
            {
                return _tipoHoja;
            }
            set
            {
                _tipoHoja = value;
            }
        }
        public float MargenIzquierdo
        {
            get
            {
                return _margenIzquierdo;
            }
            set
            {
                _margenIzquierdo = (float)value * 72;
            }
        }
        public float MargenDerecho
        {
            get
            {
                return _margenDerecho;
            }
            set
            {
                _margenDerecho = (float)value * 72;
            }
        }
        public float MargenSuperior
        {
            get
            {
                return _margenSuperior;
            }
            set
            {
                _margenSuperior = (float)value * 72;
            }
        }
        public float MargenInferior
        {
            get
            {
                return _margenInferior;
            }
            set
            {
                _margenInferior = (float)value * 72;
            }
        }
        public eOrientacion OrientacionPagina
        {
            get
            {
                return _orientacionPagina;
            }
            set
            {
                _orientacionPagina = value;
            }
        }
        public string MarcaAgua
        {
            get
            {
                return _marcaAgua;
            }
            set
            {
                _marcaAgua = value;
            }
        }
        public string FormatoCuadricula
        {
            get
            {
                return _formatoCuadricula;
            }
            set
            {
                _formatoCuadricula = value;
            }
        }
        public eTipoFuente Fuente
        {
            get
            {
                return _fuente;
            }
            set
            {
                _fuente = value;
            }
        }
        public eSizeFuente SizeFuente
        {
            get
            {
                return _sizeFuente;
            }
            set
            {
                _sizeFuente = value;
            }
        }
        //public Boolean Oficio
        //{
        //    get
        //    {
        //        return _oficio;
        //    }
        //    set
        //    {
        //        _oficio = value;
        //    }
        //}

        //metaDatos del documento
        public string Titulo
        {
            get
            {
                return _titulo;
            }
            set
            {
                _titulo = value;
            }
        }
        public string Referencia
        {
            get
            {
                return _referencia;
            }
            set
            {
                _referencia = value;
            }
        }
        public string PalabrasClaves
        {
            get
            {
                return _palabrasClaves;
            }
            set
            {
                _palabrasClaves = value;
            }
        }
        public string Autor
        {
            get
            {
                return _autor;
            }
            set
            {
                _autor = value;
            }
        }
        public string Creador
        {
            get
            {
                return _creador;
            }
            set
            {
                _creador = value;
            }
        }
        public Boolean BFecha
        {
            get
            {
                return _bFecha;
            }
            set
            {
                _bFecha = value;
            }
        }
        public Boolean BProductor
        {
            get
            {
                return _bProductor;
            }
            set
            {
                _bProductor = value;
            }
        }

        //preferencias de encripción                                                                        
        public Boolean BImprimir
        {
            get
            {
                return _bImprimir;
            }
            set
            {
                _bImprimir = value;
            }
        }
        public Boolean BModificar
        {
            get
            {
                return _bModificar;
            }
            set
            {
                _bModificar = value;
            }
        }
        public Boolean BCopiar
        {
            get
            {
                return _bCopiar;
            }
            set
            {
                _bCopiar = value;
            }
        }
        public Boolean BModificar_anotaciones
        {
            get
            {
                return _bModificarAnotaciones;
            }
            set
            {
                _bModificarAnotaciones = value;
            }
        }
        public Boolean BLlenar
        {
            get
            {
                return _bLlenar;
            }
            set
            {
                _bLlenar = value;
            }
        }
        public Boolean BEnsamblar
        {
            get
            {
                return _bEnsamblar;
            }
            set
            {
                _bEnsamblar = value;
            }
        }
        public Boolean BAccesibilidadContenido
        {
            get
            {
                return _bAccesibilidad_contenido;
            }
            set
            {
                _bAccesibilidad_contenido = value;
            }
        }
        public Boolean BDegragar
        {
            get
            {
                return _bDegragar;
            }
            set
            {
                _bDegragar = value;
            }
        }
        public string Pwd
        {
            get
            {
                return _pwd;
            }
            set
            {
                _pwd = value;
            }
        }

        //preferencias de vista del documento                                                                
        public string Layout
        {
            get
            {
                return _layout;
            }
            set
            {
                _layout = value;
            }
        }
        public string Modo
        {
            get
            {
                return _modo;
            }
            set
            {
                _modo = value;
            }
        }
        public string BfullScreen
        {
            get
            {
                return _bfullScreen;
            }
            set
            {
                _bfullScreen = value;
            }
        }
        public Boolean BToolBar
        {
            get
            {
                return _bToolBar;
            }
            set
            {
                _bToolBar = value;
            }
        }
        public Boolean BMenuBar
        {
            get
            {
                return _bMenuBar;
            }
            set
            {
                _bMenuBar = value;
            }
        }
        public Boolean BWindow
        {
            get
            {
                return _bWindow;
            }
            set
            {
                _bWindow = value;
            }
        }
        public Boolean BAjustar
        {
            get
            {
                return _bAjustar;
            }
            set
            {
                _bAjustar = value;
            }
        }
        public Boolean BCentrar
        {
            get
            {
                return _bCentrar;
            }
            set
            {
                _bCentrar = value;
            }
        }

        public void ConfiguraPagina(Document document)
        {
            //configurar tamaño y horientación        
                if (this.TipoHoja == eTipoHoja.Carta)
                    document.SetPageSize(this.OrientacionPagina == eOrientacion.Horizontal ? PageSize.LETTER.Rotate() : PageSize.LETTER);
                if (this.TipoHoja == eTipoHoja.Legal)
                    document.SetPageSize(this.OrientacionPagina == eOrientacion.Horizontal ? PageSize.LEGAL.Rotate(): PageSize.LEGAL);
                if (this.TipoHoja== eTipoHoja.A4)
                    document.SetPageSize(this.OrientacionPagina == eOrientacion.Horizontal ? PageSize.A4.Rotate(): PageSize.A4);
            
            //configurar margenes          
            //document.SetMargins(_margenIzquierdo, _margenDerecho, _margenSuperior, _margenInferior);

            //configurar marca de agua **CHECAR AQUÍ SI SE IMPLEMENTA DESPUÉS MARCA DE AGUA
            //if (!marca_agua.equals(""))
            //{
            //    float posicion_x = 0;
            //    float posicion_y = 0;
            //    String imagen = "Imagenes/hoja.gif";
            //    if (marca_agua.length() > 0)
            //        imagen = marca_agua;
            //    try
            //    {
            //        Image image = Image.GetInstance(Toolkit.getDefaultToolkit().createImage(imagen), null);
            //        image.Alignment = Element.ALIGN_CENTER;
            //        posicion_x = (document.getPageSize().width() - image.width()) / 2;
            //        posicion_y = (document.getPageSize().height() - image.height()) / 2;
            //        Watermark watermark = new Watermark(image, posicion_x, posicion_y);
            //        watermark.bottom();
            //        //Watermark watermark = new Watermark(Image.getInstance(imagen), posicion_x, posicion_y);
            //        document.add(watermark);
            //    }
            //    catch (Exception e)
            //    {
            //        System.err.println("No se encuentra la imagen.");
            //    }

            //}

        }

        public void ConfiguraMetaDatos(Document documento)
        {
            if (!_titulo.Equals(""))
                documento.AddTitle(_titulo);
            if (!_referencia.Equals(""))
                documento.AddSubject(_referencia);
            if (!_palabrasClaves.Equals(""))
                documento.AddKeywords(_palabrasClaves);
            if (!_autor.Equals(""))
                documento.AddAuthor(_autor);
            if (!_creador.Equals(""))
                documento.AddCreator(_creador);
            if (_bProductor)
                documento.AddProducer();
            if (_bFecha)
                documento.AddCreationDate();
        }

        public void ConfiguraEncriptar(PdfWriter writer)
        {
            int preferencias = 0;

            if (!_bImprimir)
                preferencias = preferencias | PdfWriter.AllowPrinting;
            if (_bModificar)
                preferencias = preferencias | PdfWriter.AllowModifyContents;
            if (_bCopiar)
                preferencias = preferencias | PdfWriter.AllowCopy;
            if (_bModificarAnotaciones)
                preferencias = preferencias | PdfWriter.AllowModifyAnnotations;
            if (_bLlenar)
                preferencias = preferencias | PdfWriter.AllowFillIn;
            if (_bEnsamblar)
                preferencias = preferencias | PdfWriter.AllowAssembly;
            if (_bAccesibilidad_contenido)
                preferencias = preferencias | PdfWriter.AllowScreenReaders;
            if (_bDegragar)
                preferencias = preferencias | PdfWriter.AllowDegradedPrinting;
            
            writer.SetEncryption(PdfWriter.STRENGTH128BITS, null, null, preferencias);
        }

        public void ConfiguraVista(PdfWriter writer)
        {
            if (!_layout.Equals(""))
            {
                if (_layout.Equals("1p"))
                    writer.AddViewerPreference(PdfName.PAGELAYOUT, PdfName.SINGLEPAGE);
                if (_layout.Equals("1c"))
                    writer.AddViewerPreference(PdfName.PAGELAYOUT, PdfName.ONECOLUMN);
                if (_layout.Equals("2ci"))
                    writer.AddViewerPreference(PdfName.PAGELAYOUT, PdfName.TWOCOLUMNLEFT);
                if (_layout.Equals("2cd"))
                    writer.AddViewerPreference(PdfName.PAGELAYOUT, PdfName.TWOCOLUMNRIGHT);
            }
            if (!_modo.Equals(""))
            {
                if (_modo.Equals("n"))
                    writer.AddViewerPreference(PdfName.PAGEMODE, PdfName.USEOUTLINES);
                if (_modo.Equals("t"))
                    writer.AddViewerPreference(PdfName.PAGEMODE, PdfName.USETHUMBS);
                if (_modo.Equals("fs"))
                    writer.AddViewerPreference(PdfName.PAGEMODE, PdfName.FULLSCREEN);
            }


            if (_bToolBar == true)
                writer.AddViewerPreference(PdfName.HIDETOOLBAR, PdfBoolean.PDFTRUE);
            else
                writer.AddViewerPreference(PdfName.HIDETOOLBAR, PdfBoolean.PDFFALSE);
            if (_bMenuBar == true)
                writer.AddViewerPreference(PdfName.HIDEMENUBAR, PdfBoolean.PDFTRUE);
            else
                writer.AddViewerPreference(PdfName.HIDEMENUBAR, PdfBoolean.PDFFALSE);
            if (_bWindow == true)
                writer.AddViewerPreference(PdfName.HIDEWINDOWUI, PdfBoolean.PDFTRUE);
            else
                writer.AddViewerPreference(PdfName.HIDEWINDOWUI, PdfBoolean.PDFFALSE);
            if (_bAjustar == true)
                writer.AddViewerPreference(PdfName.FITWINDOW, PdfBoolean.PDFTRUE);
            else
                writer.AddViewerPreference(PdfName.FITWINDOW, PdfBoolean.PDFFALSE);
            if (_bCentrar == true)
                writer.AddViewerPreference(PdfName.CENTERWINDOW, PdfBoolean.PDFTRUE);
            else
                writer.AddViewerPreference(PdfName.CENTERWINDOW, PdfBoolean.PDFFALSE);

            if (_modo.Equals("fs") && !_bfullScreen.Equals(""))
            {
                if (_bfullScreen.Equals("n"))
                    writer.AddViewerPreference(PdfName.NONFULLSCREENPAGEMODE, PdfName.USENONE);
                if (_bfullScreen.Equals("o"))
                    writer.AddViewerPreference(PdfName.NONFULLSCREENPAGEMODE, PdfName.USEOUTLINES);
                if (_bfullScreen.Equals("t"))
                    writer.AddViewerPreference(PdfName.NONFULLSCREENPAGEMODE, PdfName.USETHUMBS);
            }

        }

    }
}
