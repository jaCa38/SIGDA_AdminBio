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

    public class BiometriasController : ApiController
    {



        [HttpPost]
        [Route("api/EliminarEmpleadoBiometrico")]
        public BaseResultado Post([FromBody] BorradorEmpleado borradorEmpleado)
        {
            AdministracionBiometriasService service;


            using (var Gestion = FactorizadorAdministracionBiometrias.CrearConexionBiometricos())
            {
                service = new AdministracionBiometriasService(Gestion);
                return service.EliminarEmpleadoBiometrico(borradorEmpleado.Id, borradorEmpleado.IpTerminal, borradorEmpleado.PortConexion);
            }

            throw new Exception();

        }

        [HttpPost]
        [Route("api/VerificaBiometria")]
        public BaseResultado PostVerificaBiometria([FromBody] InfoBiometrico infoBiometrico)
        {
            AdministracionBiometriasService service;


            using (var Gestion = FactorizadorAdministracionBiometrias.CrearConexionBiometricos())
            {
                service = new AdministracionBiometriasService(Gestion);
                return service.VerificaBiometria(infoBiometrico.IdTerminal, infoBiometrico.IpTerminal, infoBiometrico.PortTerminal);
            }

            throw new Exception();        
        }   

    
    }
}