using Azure;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using SIGDA.CA.Biometricos.Libreria.Models;
using SIGDA.CA.Biometricos.Libreria.Services.Interfaces;
using SIGDA.CA.Biometricos.Libreria.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGDA.CA.Biometricos.Libreria.Controllers
{
    public class GenerarReportesAsistenciaController : ConsultaRegistrosSICA, IGenerarReportesAsistencia, IDisposable
    {
        private string strConexionMYSQL;
        private string strConexionMSSQL;
        DataTableReader dtrResultado = null;
        //ConsultaRegistrosSICA consultaRegistrosSICA = new ConsultaRegistrosSICA();
        ConexionApiNombramientos apiNom = new ConexionApiNombramientos();


        public GenerarReportesAsistenciaController(string cadenaMysql, string cadenaMSSQL) : base(cadenaMysql, cadenaMSSQL)
        {

            strConexionMYSQL = cadenaMysql;
            strConexionMSSQL = cadenaMSSQL;
        }



        public List<ReporteAsistencia> GenerarReporteAsistencia(int municipio, DateTime fechaInicio, DateTime fechaFin)
        {
            var reporteAsistencia = new List<ReporteAsistencia>();
           
           var reportePorMunicipo = new List<NombramientosRh>();
            var reporteSicaPorEmpleado = new List<RegistrosEmpleadoSICA>();
           


            reportePorMunicipo = apiNom.ConectarConApiNom(municipio, fechaInicio, fechaFin).Result;

            foreach (NombramientosRh nom in reportePorMunicipo)
            {
                reporteSicaPorEmpleado = GenerarReporteSICA(nom.IdEmpleado, Convert.ToDateTime(nom.Inicio), Convert.ToDateTime( nom.Fin));
                
                if (reporteSicaPorEmpleado.Count() < 0)
                {
                    break;
                }
                else
                {
                    foreach(RegistrosEmpleadoSICA reg in reporteSicaPorEmpleado)
                    {
                        reporteAsistencia.Add(new ReporteAsistencia
                        {
                            Id = reg.IdEmpleado,
                            Name = nom.Nombre + nom.Paterno + nom.Materno,
                            FechaRegistro = reg.Fecha,
                            HoraEntrada = reg.Entrada,
                            HoraSalida = reg.Salida,
                            Observacion = reg.Observaciones,
                            Inicidencia = reg.Incidencias,
                            Puesto = nom.Denominacion,
                            CT = nom.CentroTrabajo,
                            Municipio = nom.CentroTrabajo

                        });


                    }
                }
            }

            return reporteAsistencia;
         }

    
        


        #region IDisposable Support
        bool disposedValue = false; // Para detectar llamadas redundantes
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (dtrResultado != null) { dtrResultado.Close(); dtrResultado.Dispose(); }
                    // TODO: elimine el estado administrado (objetos administrados).
                }

                // TODO: libere los recursos no administrados (objetos no administrados) y reemplace el siguiente finalizador.
                // TODO: configure los campos grandes en nulos.

                disposedValue = true;
            }
        }

        // TODO: reemplace un finalizador solo si el anterior Dispose(bool disposing) tiene código para liberar los recursos no administrados.
        // ~GestionFamiliarService()
        // {
        //   // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
        //   Dispose(false);
        // }

        // Este código se agrega para implementar correctamente el patrón descartable.
        public virtual void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
            // GC.SuppressFinalize(this);
        }


        #endregion

    }
}
