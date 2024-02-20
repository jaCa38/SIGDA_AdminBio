using SIGDA.CA.Biometricos.Libreria.Controllers;
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

    public class AdministracionBioController : ApiController
    {
     
      
        [HttpPost]
        [Route("api/ObtenerIpTerminales")]
        public List<InfoBiometrico> PostObtenerTerminales()
        {
            AdministracionBiometricoService service;


            using (var gestion = FactorizadorAdministracionBiometricos.CrearConexionBiometricos())
            {
                service = new AdministracionBiometricoService(gestion);
                return service.ObtenerTodasLasTerminales();
            }

            throw new Exception();

        }

        [HttpPost]
        [Route("api/ObtenerInfoTerminal")]
        public InfoBiometrico Post([FromBody] BusquedaTerminal busquedaTerminal)
        {
            AdministracionBaseService service;

            using (var Gestion = FactorizadorAdministracionBase.CrearConexionAdministracionBase())
            {
                service = new AdministracionBaseService(Gestion);
                return service.ObtenerInfoTerminal(busquedaTerminal.IdTerminal);
            }

            throw new Exception();
        }


     

    }
}