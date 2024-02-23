using SIGDA.CA.Biometricos.Libreria.Factorizadores;
using SIGDA.CA.Biometricos.Libreria.Models;
using SIGDA.CA.Biometricos.Libreria.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Compilation;
using System.Web.Http;

namespace SIGDA_BackEnd.CA.Biometricos.Controllers
{
    public class ReporteEmpleadoPjController : ApiController
    {

        //[HttpPost]
        //[Route("api/ReporteAsistencia")]
        //public List<NombramientosRh> PostReporteAsistencia([FromBody] NombramientosRh nom)
        //{
        //    GenerarReportesAsistenciaService service;
        //    var fechaInicioNom = Convert.ToDateTime(nom.inicio);
        //    var fechaFinNom = Convert.ToDateTime(nom.fin);

        //    using (var gestion = FactorizadorGenerarReportesAsistencia.CrearConexionGenerarReportes())
        //    {
        //        service = new GenerarReportesAsistenciaService(gestion);
        //        return service.GenerarReporteAsistencia(nom.idMunicipio, fechaInicioNom, fechaFinNom);
        //    }

        //    throw new Exception();
        //}



        [HttpPost]
        [Route("api/ReporteAsistencia")]
        public List<ReporteAsistencia> PostReporteAsistencia([FromBody] NombramientosRh nom)
        {
            GenerarReportesAsistenciaService service;
            var fechaInicioNom = Convert.ToDateTime(nom.Inicio);
            var fechaFinNom = Convert.ToDateTime(nom.Fin);

            using (var gestion = FactorizadorGenerarReportesAsistencia.CrearConexionGenerarReportes())
            {
                service = new GenerarReportesAsistenciaService(gestion);
                return service.GenerarReporteAsistencia(nom.IdMunicipio, fechaInicioNom, fechaFinNom);
            }

            throw new Exception();
        }


    }
}