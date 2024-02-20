using Microsoft.AspNetCore.Mvc;
using SIGDA.Consejo.Libreria.Factorizadores;
using SIGDA.Consejo.Libreria.Models;
using SIGDA.Consejo.Libreria.Services;

namespace SIGDA_BackEnd.Docker.Linux.Controllers.CONSEJO
{
    public class ConsejoAPIController : BaseControllerSIGDA
    {
        private IConfiguration _Config;
        public ConsejoAPIController(IConfiguration Configuration) => _Config = Configuration;

        //[Authorize]
        [HttpPost]
        [Route("api/Consejo/ConsultarSolicitudes")]
        public List<SolicitudBase> ConsultarSolicitudes([FromBody] long FolioConsejo)
        {
            //long IdMinerva = long.Parse(GetIdUsuario());
            long IdMinerva = 0;

            GestionConsejoService service;

            using (var Gestion = FactorizadorConsejo.CrearConexion(IdMinerva))
            {
                service = new GestionConsejoService(Gestion);
                return service.ConsultarSolicitudes(FolioConsejo);
            }
            throw new Exception();
        }

        //[Authorize]
        [HttpPost]
        [Route("api/Consejo/ConsultarDetallePrecalificacion")]
        public DetallePrecalificacion ConsultarDetallePrecalificacion([FromBody] long FolioConsejo)
        {
            //long IdMinerva = long.Parse(GetIdUsuario());
            long IdMinerva = 0;

            GestionConsejoService service;

            using (var Gestion = FactorizadorConsejo.CrearConexion(IdMinerva))
            {
                service = new GestionConsejoService(Gestion);
                return service.ConsultarDetallePrecalificacion(FolioConsejo);
            }
            throw new Exception();
        }

        //[Authorize]
        [HttpPost]
        [Route("api/Consejo/ConsultarDetalleFolioConsejo")]
        public DetalleFolioConsejo ConsultarDetalleFolioConsejo([FromBody] long FolioConsejo)
        {
            //long IdMinerva = long.Parse(GetIdUsuario());
            long IdMinerva = 0;

            GestionConsejoService service;

            using (var Gestion = FactorizadorConsejo.CrearConexion(IdMinerva))
            {
                service = new GestionConsejoService(Gestion);
                return service.ConsultarDetalleFolioConsejo(FolioConsejo);
            }
            throw new Exception();
        }

        //[Authorize]
        [HttpPost]
        [Route("api/Consejo/ConsultarDetallePersonajes")]
        public List<DetallePersonajes> ConsultarDetallePersonajes([FromBody] long FolioConsejo)
        {
            //long IdMinerva = long.Parse(GetIdUsuario());
            long IdMinerva = 0;

            GestionConsejoService service;

            using (var Gestion = FactorizadorConsejo.CrearConexion(IdMinerva))
            {
                service = new GestionConsejoService(Gestion);
                return service.ConsultarDetallePersonajes(FolioConsejo);
            }
            throw new Exception();
        }

        //[Authorize]
        [HttpPost]
        [Route("api/Consejo/ContestarFolioNuevoEmpleado")]
        public Boolean ContestarFolioNuevoEmpleado([FromBody] ContestacionFolioConsejo contestacionFolioConsejo)
        {
            //long IdMinerva = long.Parse(GetIdUsuario());
            long IdMinerva = 0;

            GestionConsejoService service;

            using (var Gestion = FactorizadorConsejo.CrearConexionAmbasBD(IdMinerva))
            {
                service = new GestionConsejoService(Gestion);
                return service.ContestarConsejoNuevoEmpleado(contestacionFolioConsejo);
            }
            throw new Exception();
        }

    }
}
