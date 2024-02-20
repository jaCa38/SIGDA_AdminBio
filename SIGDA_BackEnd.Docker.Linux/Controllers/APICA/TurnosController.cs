using Microsoft.AspNetCore.Mvc;
using SIGDA.CA.Libreria.Turno.Factorizadores;
using SIGDA.CA.Libreria.Turno.Models;
using SIGDA.CA.Libreria.Turno.Services;

namespace SIGDA_BackEnd.Docker.Linux.Controllers.APICA
{
    public class TurnosController : Controller
    {
        private IConfiguration _Config;
        public TurnosController(IConfiguration Configuration) => _Config = Configuration;

        #region CATALOGOS.TURNOS
        //[Authorize]
        [HttpPost]
        [Route("api/ca/Turnos/ConsultarTiposTurno")]
        public List<TipoTurnoBase> ConsultarTiposTurno()
        {
            TurnoService service;

            using (var Gestion = FactorizadorTurno.CrearConexionTipoTurno())
            {
                service = new TurnoService(Gestion);
                return service.ConsultarCatalogoTiposTurno();
            }
            throw new Exception();
        }
        #endregion

        #region CONFIGURACION.TURNO
        //[Authorize]
        [HttpPost]
        [Route("api/ca/Turnos/ConsultarConfiguracionTurnos")]
        public List<ConfigTurno> ConsultarConfiguracionTurnos()
        {
            TurnoService service;

            using (var Gestion = FactorizadorTurno.CrearConexionConfigTurno())
            {
                service = new TurnoService(Gestion);
                return service.ConsultarConfiguracionTurnos();
            }
            throw new Exception();
        }
        //[Authorize]
        [HttpPost]
        [Route("api/ca/Turnos/InsertarConfiguracionTurno")]
        public long InsertarConfiguracionTurno([FromBody] ConfigTurnoBase configTurnoBase)
        {
            TurnoService service;

            using (var Gestion = FactorizadorTurno.CrearConexionConfigTurno())
            {
                service = new TurnoService(Gestion);
                return service.InsertarConfiguracionTurnos(configTurnoBase);
            }
            throw new Exception();
        }
        #endregion

        #region Turno Fijo
        //[Authorize]
        [HttpPost]
        [Route("api/ca/Turnos/InsertarTurnoEmpleadoFijo")]
        public long InsertarTurnoEmpleadoFijo([FromBody] TurnoEmpleadoFijo fijo)
        {
            TurnoService service;

            using (var Gestion = FactorizadorTurno.CrearConexionTurnoEmpleado())
            {
                service = new TurnoService(Gestion);
                return service.InsertarTurnoEmpleadoFijo(fijo);
            }
            throw new Exception();
        }
        //[Authorize]
        [HttpPost]
        [Route("api/ca/Turnos/EliminarTurnoEmpleadoFijo")]
        public bool EliminarTurnoEmpleadoFijo([FromBody] long IdEmpleado)
        {
            TurnoService service;

            using (var Gestion = FactorizadorTurno.CrearConexionTurnoEmpleado())
            {
                service = new TurnoService(Gestion);
                return service.EliminarTurnoEmpleadoFijo(IdEmpleado);
            }
            throw new Exception();
        }
        //[Authorize]
        [HttpPost]
        [Route("api/ca/Turnos/ConsultarTurnoEmpleadoFijo")]
        public TurnoEmpleadoFijo ConsultarTurnoEmpleadoFijo([FromBody] long IdEmpleado)
        {
            TurnoService service;

            using (var Gestion = FactorizadorTurno.CrearConexionTurnoEmpleado())
            {
                service = new TurnoService(Gestion);
                return service.ConsultarTurnoEmpleadoFijo(IdEmpleado);
            }
            throw new Exception();
        }
        //[Authorize]
        [HttpPost]
        [Route("api/ca/Turnos/ConsultarHistoricoTurnoEmpleadoFijo")]
        public List<TurnoEmpleadoFijo> ConsultarHistoricoTurnoEmpleadoFijo([FromBody] long IdEmpleado)
        {
            TurnoService service;

            using (var Gestion = FactorizadorTurno.CrearConexionTurnoEmpleado())
            {
                service = new TurnoService(Gestion);
                return service.ConsultarHistoricoTurnoEmpleadoFijo(IdEmpleado);
            }
            throw new Exception();
        }
        #endregion

        #region Turno Variable
        //[Authorize]
        [HttpPost]
        [Route("api/ca/Turnos/InsertarTurnoEmpleadoVariable")]
        public long InsertarTurnoEmpleadoVariable([FromBody] TurnoEmpleadoVariable variable)
        {
            TurnoService service;

            using (var Gestion = FactorizadorTurno.CrearConexionTurnoEmpleado())
            {
                service = new TurnoService(Gestion);
                return service.InsertarTurnoEmpleadoVariable(variable);
            }
            throw new Exception();
        }
        //[Authorize]
        [HttpPost]
        [Route("api/ca/Turnos/EliminarTurnoEmpleadoVariable")]
        public bool EliminarTurnoEmpleadoVariable([FromBody] long IdEmpleado)
        {
            TurnoService service;

            using (var Gestion = FactorizadorTurno.CrearConexionTurnoEmpleado())
            {
                service = new TurnoService(Gestion);
                return service.EliminarTurnoEmpleadoVariable(IdEmpleado);
            }
            throw new Exception();
        }
        //[Authorize]
        [HttpPost]
        [Route("api/ca/Turnos/ConsultarTurnoEmpleadoVariable")]
        public TurnoEmpleadoVariableDetalle ConsultarTurnoEmpleadoVariable([FromBody] long IdEmpleado)
        {
            TurnoService service;

            using (var Gestion = FactorizadorTurno.CrearConexionTurnoEmpleado())
            {
                service = new TurnoService(Gestion);
                return service.ConsultarTurnoEmpleadoVariable(IdEmpleado);
            }
            throw new Exception();
        }
        //[Authorize]
        [HttpPost]
        [Route("api/ca/Turnos/ConsultarHistoricoTurnoEmpleadoVariable")]
        public List<TurnoEmpleadoVariableDetalle> ConsultarHistoricoTurnoEmpleadoVariable([FromBody] long IdEmpleado)
        {
            TurnoService service;

            using (var Gestion = FactorizadorTurno.CrearConexionTurnoEmpleado())
            {
                service = new TurnoService(Gestion);
                return service.ConsultarHistoricoTurnoEmpleadoVariable(IdEmpleado);
            }
            throw new Exception();
        }
        #endregion
    }
}
