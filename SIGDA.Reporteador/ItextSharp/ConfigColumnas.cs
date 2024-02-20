using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGDA.Reporteador.ItextSharp
{
    public class ConfigColumnas
    {
        internal List<descripcionColumna> columnas = new List<descripcionColumna>();
        internal List<descripcionCelda> celdasEncabezadoPersonalizado = new List<descripcionCelda>();
        private int numeroColumnas = 0;
        private int numeroRompimientos = 0;
        private bool encabezadoPersonalizado = false;
        public int NumeroColumnas
        {
            get
            {
                numeroColumnas = columnas.Count;
                return numeroColumnas;
            }
        }
        public int NumeroRompimientos
        {
            get
            {
                return numeroRompimientos;
            }
        }
        public bool EncabezadoPersonalizado
        {
            get
            {
                return encabezadoPersonalizado;
            }
            set
            {
                encabezadoPersonalizado = value;
            }
        }

        public void agregaColumna(string nombreColumna, string encabezadoColumna, string alineacionColumna, string longitudColumna,
            eTipoFuente fuenteColumna, string tamañoFuenteColumna, string colorColumna, string colorFondoColumna,
            int totalColumna, Boolean tieneRompimiento, string encabezadoRompimiento, eTipoFuente fuenteRompimiento,
            string tamañoFuenteRompimiento, string colorRompimiento, string colorFondoRompimiento, Boolean saltoRompimiento)
        {
            descripcionColumna columna = new descripcionColumna();
            columna.NombreColumna = nombreColumna;
            columna.EncabezadoColumna = encabezadoColumna;
            columna.AlineacionColumna = alineacionColumna;
            columna.LongitudColumna = longitudColumna;
            columna.FuenteColumna = fuenteColumna;
            columna.TamañoFuenteColumna = tamañoFuenteColumna;
            columna.ColorColumna = colorColumna;
            columna.ColorFondoColumna = colorFondoColumna;
            columna.TotalColumna = totalColumna;
            columna.TieneRompimiento = tieneRompimiento;
            columna.EncabezadoRompimiento = encabezadoRompimiento;
            columna.FuenteRompimiento = fuenteRompimiento;
            columna.TamañoFuenteRompimiento = tamañoFuenteRompimiento;
            columna.ColorRompimiento = colorRompimiento;
            columna.ColorFondoRompimiento = colorFondoRompimiento;
            columna.SaltoRompimiento = saltoRompimiento;
            columnas.Add(columna);
            if (tieneRompimiento == true)
                numeroRompimientos += 1;
        }

        public void agregaColumna(string nombreColumna, string encabezadoColumna)
        {
            descripcionColumna columna = new descripcionColumna();
            columna.NombreColumna = nombreColumna;
            columna.EncabezadoColumna = encabezadoColumna;
            columnas.Add(columna);
        }

        public void agregarCeldasEncabezadoPersonalizado(string valorCelda, int expandeColumnasCelda, int expandeRenglonesCelda)
        {
            descripcionCelda celda = new descripcionCelda();
            celda.ValorCelda = valorCelda;
            celda.ExpandeColumnasCelda = expandeColumnasCelda;
            celda.ExpandeRenglonesCelda = expandeRenglonesCelda;
            celdasEncabezadoPersonalizado.Add(celda);
        }

    }
}
