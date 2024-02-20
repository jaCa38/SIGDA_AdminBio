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
        public BaseResultado PostVerificaBiometria([FromBody] BorradorEmpleado infoBiometrico)
        {
            AdministracionBiometriasService service;

            using (var Gestion = FactorizadorAdministracionBiometrias.CrearConexionBiometricos())
            {
                service = new AdministracionBiometriasService(Gestion);
                return service.VerificaBiometria(infoBiometrico.Id, infoBiometrico.IpTerminal, infoBiometrico.PortConexion);
            }

            throw new Exception();        
        }


        [HttpPost]
        [Route("api/ObtenerBiometriaEmpleado")]
        public BiometriaEmpleado PostObtenerBiometriaEmpleado([FromBody] ObtenerBiometria biometria)
        {
            AdministracionBiometriasService service;


            using (var Gestion = FactorizadorAdministracionBiometrias.CrearConexionBiometricos())
            {
                service = new AdministracionBiometriasService(Gestion);
                return service.ObtenerBiometriaEmpleado(biometria.IdEmpleado, biometria.IpTerminal, biometria.PortConexion, biometria.Numserie);
            }

            throw new Exception();
        }


        [HttpPost]
        [Route("api/EnviarBiometriaEmpleado")]
       public  bool PostEnviarBiometriaEmpleado([FromBody] BiometriaEnvio bioEmpl)
        {
            AdministracionBiometriasService service;


            using (var gestion = FactorizadorAdministracionBiometrias.CrearConexionBiometricos())
            {
                service = new AdministracionBiometriasService(gestion);
                return service.EnviarBiometriaBio(bioEmpl.IpTerminal, bioEmpl.Port, bioEmpl.TemplateToSend);
            }

            throw new Exception();
        }



        [HttpPost]
        [Route("api/ObtenerListaEmpleadosTerminalBiometrica")]
        public List<int> PostObtenerListaEmpleadosTerminalBiometrica([FromBody] BusquedaTerminal bioTerminal)
        {
            AdministracionBiometriasService service;


            using (var gestion = FactorizadorAdministracionBiometrias.CrearConexionBiometricos())
            {
                service = new AdministracionBiometriasService(gestion);
                return service.ObtenerEmpleadosTerminalBiometrica(bioTerminal.IpTerminal, bioTerminal.PortTerminal);
            }

            throw new Exception();
        }







    }
}