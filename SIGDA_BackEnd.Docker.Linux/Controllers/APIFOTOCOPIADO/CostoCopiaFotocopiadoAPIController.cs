using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGDA.FOTOCOPIADO.Libreria.Copiadoras.Factorizadores;
using SIGDA.FOTOCOPIADO.Libreria.Copiadoras.Models;
using SIGDA.FOTOCOPIADO.Libreria.Copiadoras.Services;

namespace SIGDA_BackEnd.Docker.Linux.Controllers.APIFOTOCOPIADO
{
    public class CostoCopiaFotocopiadoAPIController : BaseControllerSIGDA
    {
        private IConfiguration _Config;
        public CostoCopiaFotocopiadoAPIController(IConfiguration Configuration) => _Config = Configuration;

        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/costocopia/Consultar")]
        public IEnumerable<CostoDetalle> Consultar()
        {
            CopiadoraService service;

            using (var Gestion = FactorizadorCopiadora.CrearConexionGenerica())
            {
                service = new CopiadoraService(Gestion);
                return service.ConsultarCostosCopia();
            }

            throw new Exception();
        }

        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/costocopia/ConsultarZona")]
        public IEnumerable<CostoDetalle> ConsultarZona([FromBody] long IdZona)
        {
            CopiadoraService service;

            using (var Gestion = FactorizadorCopiadora.CrearConexionGenerica())
            {
                service = new CopiadoraService(Gestion);
                return service.ConsultarCostosCopiaZona(IdZona);
            }

            throw new Exception();
        }

        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/costocopia/Actualizar")]
        public bool Actualizar([FromBody] CostoBase costoBase)
        {
            CopiadoraService service;
            long IdMinerva = long.Parse(GetIdUsuario());
            using (var Gestion = FactorizadorCopiadora.CrearConexionGenerica())
            {
                service = new CopiadoraService(Gestion);
                return service.ActualizarCostoCopia(costoBase, IdMinerva);
            }

            throw new Exception();
        }

        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/costocopia/Insertar")]
        public bool Insertar([FromBody] CostoBase costoBase)
        {
            CopiadoraService service;
            long IdMinerva = long.Parse(GetIdUsuario());
            using (var Gestion = FactorizadorCopiadora.CrearConexionGenerica())
            {
                service = new CopiadoraService(Gestion);
                return service.InsertarCostoCopia(costoBase, IdMinerva);
            }

            throw new Exception();
        }

        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/costocopia/Desactivar")]
        public bool Desactivar([FromBody] long IdCoco)
        {
            CopiadoraService service;
            long IdMinerva = long.Parse(GetIdUsuario());
            using (var Gestion = FactorizadorCopiadora.CrearConexionGenerica())
            {
                service = new CopiadoraService(Gestion);
                return service.DesactivarCostoCopia(IdCoco, IdMinerva);
            }

            throw new Exception();
        }

    }
}
