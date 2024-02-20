using SIGDA.Reporteador.Factorizadores;
using SIGDA.Reporteador.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIGDA_BackEnd.Reporteador.Controllers
{
    public class ReportesFotocopiadoController : BaseController
    {
        //https://localhost/api/ReportesFotocopiado/GetReporteCopiadorasZona
        //[Authorize]
        [HttpGet]
        public string GetReporteCopiadorasZona()
        {
            ReportesServiceFotocopiado service;
            long IdUsuario = 1;
            //IdUsuario = long.Parse(GetIdUsuario());

            using (var Gestion = FactorizadorReporteador.CrearConexionReportesFotocopiado())
            {
                service = new ReportesServiceFotocopiado(Gestion);
                return service.ReporteCopiadorasZona(IdUsuario);
            }

            throw new Exception();
        }
    }
}