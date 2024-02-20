using Microsoft.AspNetCore.Mvc;
using SIGDA.CA.Libreria.Punch.Models;
using SIGDA.CA.Libreria.Punch.Services;
using SIGDA.CA.Punch.Factorizadores;

namespace SIGDA_BackEnd.Docker.Linux.Controllers.APICA
{
    public class PunchController : Controller
    {
        private IConfiguration _Config;
        public PunchController(IConfiguration Configuration) => _Config = Configuration;

        //[Authorize]
        [HttpPost]
        [Route("api/ca/Punchs/ConsultarInformacionCrudaEmpleado")]
        public List<BasePunch> Post([FromBody] BusquedaPuchEmpleado busquedaPunchEmpleado)
        {
            PunchService service;

            using (var Gestion = FactorizadorPunch.CrearConexionPunchs())
           {
                service = new PunchService(Gestion);
                return service.ConsultarInformacionCrudaEmpleado(busquedaPunchEmpleado.FechaInicio,busquedaPunchEmpleado.FechaFin, busquedaPunchEmpleado.IdClaveEmpleado);
            }
            throw new Exception();
        }

        //[Authorize]
        [HttpPost]
        [Route("api/ca/Punchs/ConsultarInformacionCrudaBiometrico")]
        public List<BasePunch> Post([FromBody] BusquedaPunch busquedaPunch)
        {
            PunchService service;


            using (var Gestion = FactorizadorPunch.CrearConexionPunchs())
            {
                service = new PunchService(Gestion);
                return service.ConsultarInformacionCrudaBiometrico(busquedaPunch.FechaInicio, busquedaPunch.FechaFin, busquedaPunch.IdBiometrico);
            }
            throw new Exception();
        }
    }
}
