using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace SIGDA.Reporteador.ItextSharp
{
    public abstract class Base
    {
        protected ConfigArchivo vconfigArchivo = new ConfigArchivo();
        protected ConfigEncabezado vconfigEncabezado = new ConfigEncabezado();
        protected ConfigPiePagina vconfigPiePagina = new ConfigPiePagina();
        protected ConfigColumnas vconfigColumnas = new ConfigColumnas();
        protected ConfigTablas vconfigTablas = new ConfigTablas();
        protected DataTableReader dtrDatos;
        protected DataSet dtsDatos = new DataSet();
        public leeConfigArchivo LeeConfigArchivo = new leeConfigArchivo();

        public Base() { }
        /// <summary>
        /// manipular vconfigArchivo para configurar opciones de archivo como nombre, margenes....
        /// </summary>
        protected abstract void ConfigurarArchivo();
        /// <summary>
        /// manipular vconfigEncabezado para configurar opciones encabezado....
        /// </summary>
        protected abstract void ConfigurarEncabezado();
        /// <summary>
        /// manipular vconfigPiePagina para configurar opciones pie pagina....
        /// </summary>
        protected abstract void ConfigurarPiePagina();
        /// <summary>
        /// manipular vconfigColumnas para configurar opciones de columnas a mostrar en el reporte....
        /// </summary>
        protected abstract void ConfigurarColumnas();
        /// <summary>
        /// codigo para llenar dtrDatos el cual contien los datos a mostrar en el reporte....
        /// </summary>
        protected abstract void LlenarDtrDatos();
        /// <summary>
        /// metodo para generar el reporte....
        /// </summary>
        protected abstract void LlenarDtrDatos(DataTable dtDatos);

        public void CrearPDF()
        {
            ConfigurarArchivo();
            ConfigurarEncabezado();
            ConfigurarPiePagina();
            ConfigurarColumnas();
            LlenarDtrDatos();
            FormarDoctoPDF vFormarDoctoPDF = new FormarDoctoPDF(vconfigArchivo, vconfigTablas, vconfigColumnas, vconfigEncabezado, vconfigPiePagina,dtsDatos, dtrDatos);
            dtrDatos.Close();
        }
        public void CrearPDF(DataSet _dtsDatos)
        {
            dtsDatos = _dtsDatos;
            LeeConfigArchivo.leerConfigArchivo(dtsDatos);

            ConfigurarArchivo();
            ConfigurarEncabezado();
            ConfigurarPiePagina();
            ConfigurarColumnas();
            //LlenarDtrDatos();
            FormarDoctoPDF vFormarDoctoPDF = new FormarDoctoPDF(vconfigArchivo, vconfigTablas, vconfigColumnas, vconfigEncabezado, vconfigPiePagina, dtsDatos, dtrDatos);
        }
        public void llenaDts(DataSet _dtsDatos)
        {
            dtsDatos = _dtsDatos;
            LeeConfigArchivo.leerConfigArchivo(dtsDatos);
        }

    }
}
