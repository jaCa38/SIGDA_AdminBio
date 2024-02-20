using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGDA.Reporteador.ItextSharp
{
    public class descripcionTabla
    {
        private string nombreTabla = "";
        private string encabezadoTabla = "";
        private eTipoTabla tipoTabla = eTipoTabla.Datos;
        private Boolean saltoPagina = false;
        private ConfigColumnas vconfigColumnas = new ConfigColumnas();

        public string NombreTabla
        {
            get
            {
                return nombreTabla;
            }
            set
            {
                nombreTabla = value;
            }
        }
        public string EncabezadoTabla
        {
            get
            {
                return encabezadoTabla;
            }
            set
            {
                encabezadoTabla = value;
            }
        }
        public eTipoTabla TipoTabla
        {
            get
            {
                return tipoTabla;
            }
            set
            {
                tipoTabla = value;
            }
        }
        public Boolean SaltoPagina
        {
            get
            {
                return saltoPagina;
            }
            set
            {
                saltoPagina = value;
            }
        }

        public ConfigColumnas VconfigColumnas
        {
            get
            {
                return vconfigColumnas;
            }
        }

    }
}
