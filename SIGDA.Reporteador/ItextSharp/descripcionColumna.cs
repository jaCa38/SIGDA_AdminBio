using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGDA.Reporteador.ItextSharp
{
    public class descripcionColumna
    {
        private string nombreColumna = "";
        private string encabezadoColumna = "";
        private string alineacionColumna = "L";
        private string longitudColumna = "100";
        private eTipoFuente fuenteColumna = eTipoFuente.Verdana;
        private string tamañoFuenteColumna = "7";
        private string colorColumna = "";
        private string colorFondoColumna = "";
        private int totalColumna = 0;
        private Boolean tieneRompimiento = false;
        private string encabezadoRompimiento = "";
        private eTipoFuente fuenteRompimiento = eTipoFuente.Verdana;
        private string tamañoFuenteRompimiento = "7";
        private string colorRompimiento = "";
        private string colorFondoRompimiento = "";
        private Boolean saltoRompimiento = false;
        private int indiceColumna = 0;

        public string NombreColumna
        {
            get
            {
                return nombreColumna;
            }
            set
            {
                nombreColumna = value;
            }
        }
        public string EncabezadoColumna
        {
            get
            {
                return encabezadoColumna;
            }
            set
            {
                encabezadoColumna = value;
            }
        }
        public string AlineacionColumna
        {
            get
            {
                return alineacionColumna;
            }
            set
            {
                alineacionColumna = value;
            }
        }
        public string LongitudColumna
        {
            get
            {
                return longitudColumna;
            }
            set
            {
                longitudColumna = value;
            }
        }
        public eTipoFuente FuenteColumna
        {
            get
            {
                return fuenteColumna;
            }
            set
            {
                fuenteColumna = value;
            }
        }
        public string TamañoFuenteColumna
        {
            get
            {
                return tamañoFuenteColumna;
            }
            set
            {
                tamañoFuenteColumna = value;
            }
        }
        public string ColorColumna
        {
            get
            {
                return colorColumna;
            }
            set
            {
                colorColumna = value;
            }
        }
        public string ColorFondoColumna
        {
            get
            {
                return colorFondoColumna;
            }
            set
            {
                colorFondoColumna = value;
            }
        }
        public int TotalColumna
        {
            get
            {
                return totalColumna;
            }
            set
            {
                totalColumna = value;
            }
        }
        public Boolean TieneRompimiento
        {
            get
            {
                return tieneRompimiento;
            }
            set
            {
                tieneRompimiento = value;
            }
        }
        public string EncabezadoRompimiento
        {
            get
            {
                return encabezadoRompimiento;
            }
            set
            {
                encabezadoRompimiento = value;
            }
        }
        public eTipoFuente FuenteRompimiento
        {
            get
            {
                return fuenteRompimiento;
            }
            set
            {
                fuenteRompimiento = value;
            }
        }
        public string TamañoFuenteRompimiento
        {
            get
            {
                return tamañoFuenteRompimiento;
            }
            set
            {
                tamañoFuenteRompimiento = value;
            }
        }
        public string ColorRompimiento
        {
            get
            {
                return colorRompimiento;
            }
            set
            {
                colorRompimiento = value;
            }
        }
        public string ColorFondoRompimiento
        {
            get
            {
                return colorFondoRompimiento;
            }
            set
            {
                colorFondoRompimiento = value;
            }
        }
        public Boolean SaltoRompimiento
        {
            get
            {
                return saltoRompimiento;
            }
            set
            {
                saltoRompimiento = value;
            }
        }
        public int IndiceColumna
        {
            get
            {
                return indiceColumna;
            }
            set
            {
                indiceColumna = value;
            }
        }

    }
}
