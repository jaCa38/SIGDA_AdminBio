using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGDA.FOTOCOPIADO.Libreria.Copiadoras.Factorizadores;
using SIGDA.FOTOCOPIADO.Libreria.Copiadoras.Models;
using SIGDA.FOTOCOPIADO.Libreria.Copiadoras.Services;

namespace SIGDA_BackEnd.Docker.Linux.Controllers.APIFOTOCOPIADO
{
    public class ContadoresFotocopiadoAPIController : BaseControllerSIGDA
    {
        private IConfiguration _Config;
        public ContadoresFotocopiadoAPIController(IConfiguration Configuration) => _Config = Configuration;

        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/contadores/Consultar")]
        public IEnumerable<ContadorBase> Consultar()
        {
            CopiadoraService service;

            using (var Gestion = FactorizadorCopiadora.CrearConexionGenerica())
            {
                service = new CopiadoraService(Gestion);
                return service.ConsultarContadores();
            }

            throw new Exception();
        }

        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/contadores/ConsultarDetalle")]
        public ContadorDetalle ConsultarDetalle([FromBody] long Id)
        {
            CopiadoraService service;

            using (var Gestion = FactorizadorCopiadora.CrearConexionGenerica())
            {
                service = new CopiadoraService(Gestion);
                return service.ConsultarContadores(Id);
            }

            throw new Exception();
        }

        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/contadores/Actualizar")]
        public bool Actualizar([FromBody] ContadorBase vale)
        {
            CopiadoraService service;
            long IdMinerva = long.Parse(GetIdUsuario());
            using (var Gestion = FactorizadorCopiadora.CrearConexionGenerica())
            {
                service = new CopiadoraService(Gestion);
                return service.ActualizarContador(vale, IdMinerva);
            }

            throw new Exception();
        }

        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/contadores/Insertar")]
        public bool Insertar([FromBody] ContadorBase vale)
        {
            CopiadoraService service;
            long IdMinerva = long.Parse(GetIdUsuario());
            using (var Gestion = FactorizadorCopiadora.CrearConexionGenerica())
            {
                service = new CopiadoraService(Gestion);
                return service.InsertarContador(vale, IdMinerva);
            }

            throw new Exception();
        }

        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/contadores/Desactivar")]
        public bool Desactivar([FromBody] long IdContador)
        {
            CopiadoraService service;
            long IdMinerva = long.Parse(GetIdUsuario());
            using (var Gestion = FactorizadorCopiadora.CrearConexionGenerica())
            {
                service = new CopiadoraService(Gestion);
                return service.DesactivarContador(IdContador, IdMinerva);
            }

            throw new Exception();
        }
    }
}
