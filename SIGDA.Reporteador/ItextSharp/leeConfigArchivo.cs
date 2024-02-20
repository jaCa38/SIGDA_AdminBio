using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SIGDA.Reporteador.ItextSharp
{
    public class leeConfigArchivo
    {
        //valores de configuracion dinamicos  
        private string nombreArchivo = "";
        private String descripcionEncabezado = string.Empty;
        private String descripcion2 = "";
        private DateTime fechaInicial = DateTime.Now;
        private DateTime fechaFinal = DateTime.Now;
        private DateTime fechaGeneracion = DateTime.Now;
        private DateTime horaGeneracion = DateTime.Now;
        private DateTime fechaImpresion = DateTime.Now;
        private DateTime horaImpresion = DateTime.Now;
        private string municipio = "";
        private string presidente = "";
        private string tituloPresidente = "";
        private string responsable1 = "";
        private string responsable2 = "";
        private string numeroOficio = "";
        private string asuntoOficio = "";
        private string parrafo = "";
        
        //propiedades de pagina  
        public string NombreArchivo
        {
            get
            {
                return nombreArchivo;
            }
            set
            {
                nombreArchivo = value;
            }
        }
        public string DescripcionEncabezado
        {
            get
            {
                return descripcionEncabezado;
            }
            set
            {
                descripcionEncabezado = value;
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
        public DateTime FechaInicial
        {
            get
            {
                return fechaInicial;
            }
            set
            {
                fechaInicial = value;
            }
        }
        public DateTime FechaFinal
        {
            get
            {
                return fechaFinal;
            }
            set
            {
                fechaFinal = value;
            }
        }
        public DateTime FechaGeneracion
        {
            get
            {
                return fechaGeneracion;
            }
            set
            {
                fechaGeneracion = value;
            }
        }
        public DateTime HoraGeneracion
        {
            get
            {
                return horaGeneracion;
            }
            set
            {
                horaGeneracion = value;
            }
        }
        public DateTime FechaImpresion
        {
            get
            {
                return fechaImpresion;
            }
            set
            {
                fechaImpresion = value;
            }
        }
        public DateTime HoraImpresion
        {
            get
            {
                return horaImpresion;
            }
            set
            {
                horaImpresion = value;
            }
        }
        public string Municipio
        {
            get
            {
                return municipio;
            }
            set
            {
                municipio = value;
            }
        }
        public string Presidente
        {
            get
            {
                return presidente;
            }
            set
            {
                presidente = value;
            }
        }
        public string TituloPresidente
        {
            get
            {
                return tituloPresidente;
            }
            set
            {
                tituloPresidente = value;
            }
        }
        public string Responsable1
        {
            get
            {
                return responsable1;
            }
            set
            {
                responsable1 = value;
            }
        }
        public string Responsable2
        {
            get
            {
                return responsable2;
            }
            set
            {
                responsable2 = value;
            }
        }
        public string NumeroOficio
        {
            get
            {
                return numeroOficio;
            }
            set
            {
                numeroOficio = value;
            }
        }
        public string AsuntoOficio
        {
            get
            {
                return asuntoOficio;
            }
            set
            {
                asuntoOficio = value;
            }
        }
        public string Parrafo
        {
            get
            {
                return parrafo;
            }
            set
            {
                parrafo = value;
            }
        }

        public void leerConfigArchivo(DataSet _dtsDatos)
        {
            if (_dtsDatos.Tables.Contains("ArchivoConf") == true)
            {
                DataTableReader _dtrDatos = _dtsDatos.Tables["ArchivoConf"].CreateDataReader();
                while (_dtrDatos.Read())
                {
                    NombreArchivo = _dtrDatos["NombreArchivo"].ToString();
                    this.DescripcionEncabezado = _dtrDatos["Descripcion1"].ToString();
                    Descripcion2 = _dtrDatos["Descripcion2"].ToString();
                    FechaInicial = DateTime.Parse(_dtrDatos["FechaInicial"].ToString());
                    FechaFinal = DateTime.Parse(_dtrDatos["FechaFinal"].ToString());
                    FechaGeneracion = DateTime.Parse(_dtrDatos["FechaGeneracion"].ToString());
                    HoraGeneracion = DateTime.Parse(_dtrDatos["HoraGeneracion"].ToString());
                    FechaImpresion = DateTime.Parse(_dtrDatos["FechaImpresion"].ToString());
                    HoraImpresion = DateTime.Parse(_dtrDatos["HoraImpresion"].ToString());
                    Municipio = _dtrDatos["Municipio"].ToString();
                    Presidente = _dtrDatos["Presidente"].ToString();
                    TituloPresidente = _dtrDatos["TituloPresidente"].ToString();
                    Responsable1 = _dtrDatos["Responsable1"].ToString();
                    Responsable2 = _dtrDatos["Responsable2"].ToString();
                    NumeroOficio = _dtrDatos["NumeroOficio"].ToString();
                    AsuntoOficio = _dtrDatos["AsuntoOficio"].ToString();
                    Parrafo = _dtrDatos["Parrafo"].ToString();
                }
            }
        }

        public DataTable generaConfigArchivos()
        {
            DataTable _tabla = new DataTable("ArchivoConf");
            _tabla.Columns.Add("NombreArchivo");
            _tabla.Columns.Add("Descripcion1");
            _tabla.Columns.Add("Descripcion2");
            _tabla.Columns.Add("FechaInicial");
            _tabla.Columns.Add("FechaFinal");
            _tabla.Columns.Add("FechaGeneracion");
            _tabla.Columns.Add("HoraGeneracion");
            _tabla.Columns.Add("FechaImpresion");
            _tabla.Columns.Add("HoraImpresion");
            _tabla.Columns.Add("Municipio");
            _tabla.Columns.Add("Presidente");
            _tabla.Columns.Add("TituloPresidente");
            _tabla.Columns.Add("Responsable1");
            _tabla.Columns.Add("Responsable2");
            _tabla.Columns.Add("NumeroOficio");
            _tabla.Columns.Add("AsuntoOficio");
            _tabla.Columns.Add("Parrafo");
            _tabla.Rows.Add(NombreArchivo, DescripcionEncabezado, Descripcion2, FechaInicial, FechaFinal, FechaGeneracion,
                HoraGeneracion, FechaImpresion, HoraImpresion, Municipio, Presidente, TituloPresidente, Responsable1,
                Responsable2, NumeroOficio, AsuntoOficio, Parrafo);
            return _tabla;
        }

    }
}
