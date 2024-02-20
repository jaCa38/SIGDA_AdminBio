using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SIGDA.Reporteador.ItextSharp
{
    public class Resumen
    {
        //variables del resumen
        private int numeroRompimientos = 0;
        public DataSet datosResumen = new DataSet();
        public ConfigColumnas vconfigColumnas = new ConfigColumnas();

        public List<descripcionColumna> configuracionColumnas = new List<descripcionColumna>();
        public List<descripcionColumna> configuracion = new List<descripcionColumna>();

        public Document documentResumen;
        public Font fuenteResumen;

        public Resumen(PdfWriter writer, Document document, String descripcion, ConfigColumnas columnas, Font fuente, int numeroRompimientos)
        {
            configuracionColumnas = columnas.columnas;
            NumeroRompimientos = numeroRompimientos - 1;

            documentResumen = document;
            fuenteResumen = fuente;

            //configurar tabla y columnas del resumen
            configuraResumen(descripcion);

        }

        public int NumeroRompimientos
        {
            get
            {
                return numeroRompimientos;
            }
            set
            {
                numeroRompimientos = value;
            }
        }


        private void configuraResumen(String descripcion)
        {
            //Extrae la información acerca de las columnas del resumen
            datosResumen.Tables.Add("Datos");

            int cuentaRompiminetos = 0;
            int tipoTotal = 0;
            bool tieneRompiminetos = false;
            for (int i = 0; i < configuracionColumnas.Count; i++)
            {
                if (configuracionColumnas.ElementAt(i).TieneRompimiento == true || configuracionColumnas.ElementAt(i).TotalColumna > 0)
                {
                    //agregar columna para formar tabla
                    datosResumen.Tables["Datos"].Columns.Add(configuracionColumnas.ElementAt(i).NombreColumna);
                    //agregar la configuracion de cada columna del resumen     
                    if (configuracionColumnas.ElementAt(i).TieneRompimiento == true)
                    {
                        cuentaRompiminetos++;
                        if (cuentaRompiminetos <= NumeroRompimientos)
                            tieneRompiminetos = configuracionColumnas.ElementAt(i).TieneRompimiento;
                        else
                            tieneRompiminetos = false;
                    }
                    else
                        tieneRompiminetos = configuracionColumnas.ElementAt(i).TieneRompimiento;

                    if (configuracionColumnas.ElementAt(i).TotalColumna > 0)
                    {
                        tipoTotal = 1;
                    }
                    else
                    {
                        tipoTotal = 0;
                    }

                    vconfigColumnas.agregaColumna(configuracionColumnas.ElementAt(i).NombreColumna,
                    configuracionColumnas.ElementAt(i).EncabezadoColumna,
                    configuracionColumnas.ElementAt(i).AlineacionColumna,
                    configuracionColumnas.ElementAt(i).LongitudColumna,
                    configuracionColumnas.ElementAt(i).FuenteColumna,
                    configuracionColumnas.ElementAt(i).TamañoFuenteColumna,
                    configuracionColumnas.ElementAt(i).ColorColumna,
                    configuracionColumnas.ElementAt(i).ColorFondoColumna,
                    tipoTotal,
                    tieneRompiminetos,
                    configuracionColumnas.ElementAt(i).EncabezadoRompimiento,
                    configuracionColumnas.ElementAt(i).FuenteRompimiento,
                    configuracionColumnas.ElementAt(i).TamañoFuenteRompimiento,
                    configuracionColumnas.ElementAt(i).ColorRompimiento,
                    configuracionColumnas.ElementAt(i).ColorFondoRompimiento,
                    configuracionColumnas.ElementAt(i).SaltoRompimiento);
                    //configuracionColumnas.ElementAt(i).TotalColumna,     
                }
            }
        }

    }
}
