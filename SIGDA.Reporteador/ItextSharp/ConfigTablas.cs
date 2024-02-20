using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGDA.Reporteador.ItextSharp
{
    public class ConfigTablas
    {
        internal List<descripcionTabla> tablas = new List<descripcionTabla>();
        private int numeroTablas = 0;
        private descripcionTabla tabla = new descripcionTabla();


        public int NumeroTablas
        {
            get
            {
                numeroTablas = tablas.Count;
                return numeroTablas;
            }
        }

        public descripcionTabla UltimaTabla
        {
            get
            {
                tabla = tablas.ElementAt(NumeroTablas - 1);
                return tabla;
            }
        }


        public void agregaTabla(string nombreTabla, string encabezadoTabla, eTipoTabla tipoTabla, Boolean saltoPagina)
        {
            descripcionTabla tabla = new descripcionTabla();
            tabla.NombreTabla = nombreTabla;
            tabla.EncabezadoTabla = encabezadoTabla;
            tabla.TipoTabla = tipoTabla;
            tabla.SaltoPagina = saltoPagina;
            tablas.Add(tabla);
        }
    }
}
