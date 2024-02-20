using SIGDA.CA.Biometricos.Libreria.Factorizadores;
using SIGDA.CA.Biometricos.Libreria.Models;
using SIGDA.CA.Biometricos.Libreria.Services;
using SIGDA.CA.Biometricos.Libreria.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SIGDA_BackEnd.CA.Biometricos.Controllers
{
    public class ConsultarDbController : ApiController
    {

        [HttpPost]
        [Route("api/ObtenerBiometriasDbEmpleado")]
        public List<ListaBiometriasEmpleado> PostObtenerBiometriasDbEmpleado([FromBody] ObtenerBiometriasDb biometrias)
        {
            ConsultaDbService service;


            using (var gestion = FactorizadorConsultaDb.CrearConexionBiometricos())
            {
                service = new ConsultaDbService(gestion);
                return service.ObtenerBiometriasEmpleadoDb(biometrias.IdEmpleado, biometrias.Fw);
            }

            throw new Exception();
        }



        [HttpPost]
        [Route("api/TerminalesConBiometriaEmpleado")]
        public List<TerminalesConBiometriaEmpleado> PostObtenerListaBiometriasDb([FromBody] ListaTerminalesBiometria biometrias)
        {
            ConsultaDbService service;


            using (var gestion = FactorizadorConsultaDb.CrearConexionBiometricos())
            {
                service = new ConsultaDbService(gestion);
                return service.ObtenerListaBiometriasDb(biometrias.IdEmpleado, biometrias.IdTerminal);
            }

            throw new Exception();
        }



        [HttpPost]
        [Route("api/ConsultaBiometriaDeEmpleadoPorTerminal")]
        public List<BiometriaTerminal> PostConsultaBiometriaDeEmpleadoPorTerminal([FromBody] ListaTerminalesBiometria biometrias)
        {
            ConsultaDbService service;


            using (var gestion = FactorizadorConsultaDb.CrearConexionBiometricos())
            {
                service = new ConsultaDbService(gestion);
                return service.ObtenerBiometriaTerminalDb(biometrias.IdEmpleado, biometrias.IdTerminal);
            }

            throw new Exception();
        }


    }
}