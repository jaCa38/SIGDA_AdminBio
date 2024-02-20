using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGDA.FOTOCOPIADO.Libreria.Vales.Factorizadores;
using SIGDA.FOTOCOPIADO.Libreria.Vales.Models;
using SIGDA.FOTOCOPIADO.Libreria.Vales.Services;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace SIGDA_BackEnd.Docker.Linux.Controllers.APIFOTOCOPIADO
{
    public class ValesFotocopiadoAPIController : BaseControllerSIGDA
    {
        private IConfiguration _Config;
        public ValesFotocopiadoAPIController(IConfiguration Configuration) => _Config = Configuration;

        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/vales/Consultar")]
        public IEnumerable<ValeBase> Consultar()
        {
            ValeService service;

            using (var Gestion = FactorizadorVale.CrearConexionGenerica())
            {
                service = new ValeService(Gestion);
                return service.Consultar();
            }

            throw new Exception();
        }

        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/vales/ConsultarDetalle")]
        public ValeDetalle ConsultarDetalle([FromBody] long Id)
        {
            ValeService service;

            using (var Gestion = FactorizadorVale.CrearConexionGenerica())
            {
                service = new ValeService(Gestion);
                return service.Consultar(Id);
            }

            throw new Exception();
        }

        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/vales/Actualizar")]
        public bool Actualizar([FromBody] Vale vale)
        {
            ValeService service;
            long IdMinerva = long.Parse(GetIdUsuario());
            using (var Gestion = FactorizadorVale.CrearConexionGenerica())
            {
                service = new ValeService(Gestion);
                return service.Actualizar(vale,IdMinerva);
            }

            throw new Exception();
        }

        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/vales/Insertar")]
        public bool Insertar([FromBody] Vale vale)
        {
            ValeService service;
            long IdMinerva = long.Parse(GetIdUsuario());
            using (var Gestion = FactorizadorVale.CrearConexionGenerica())
            {
                service = new ValeService(Gestion);
                return service.Insertar(vale, IdMinerva);
            }

            throw new Exception();
        }

        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/vales/Desactivar")]
        public bool Desactivar([FromBody] long IdVale)
        {
            ValeService service;
            long IdMinerva = long.Parse(GetIdUsuario());
            using (var Gestion = FactorizadorVale.CrearConexionGenerica())
            {
                service = new ValeService(Gestion);
                return service.Desactivar(IdVale, IdMinerva);
            }

            throw new Exception();
        }

    }
}
