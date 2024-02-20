using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGDA.FOTOCOPIADO.Libreria.Depositos.Factorizadores;
using SIGDA.FOTOCOPIADO.Libreria.Depositos.Models;
using SIGDA.FOTOCOPIADO.Libreria.Depositos.Services;

namespace SIGDA_BackEnd.Docker.Linux.Controllers.APIFOTOCOPIADO
{
    public class DepositosFotocopiadoAPIController : BaseControllerSIGDA
    {
        private IConfiguration _Config;
        public DepositosFotocopiadoAPIController(IConfiguration Configuration) => _Config = Configuration;

        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/depositos/Consultar")]
        public IEnumerable<DepositoBase> Consultar()
        {
            DepositoService service;

            using (var Gestion = FactorizadorDeposito.CrearConexionGenerica())
            {
                service = new DepositoService(Gestion);
                return service.Consultar();
            }

            throw new Exception();
        }

        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/depositos/ConsultarDetalle")]
        public DepositoDetalle ConsultarDetalle([FromBody] long Id)
        {
            DepositoService service;

            using (var Gestion = FactorizadorDeposito.CrearConexionGenerica())
            {
                service = new DepositoService(Gestion);
                return service.Consultar(Id);
            }

            throw new Exception();
        }

        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/depositos/Actualizar")]
        public bool Actualizar([FromBody] Deposito vale)
        {
            DepositoService service;
            long IdMinerva = long.Parse(GetIdUsuario());
            using (var Gestion = FactorizadorDeposito.CrearConexionGenerica())
            {
                service = new DepositoService(Gestion);
                return service.Actualizar(vale, IdMinerva);
            }

            throw new Exception();
        }

        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/depositos/Insertar")]
        public bool Insertar([FromBody] Deposito vale)
        {
            DepositoService service;
            long IdMinerva = long.Parse(GetIdUsuario());
            using (var Gestion = FactorizadorDeposito.CrearConexionGenerica())
            {
                service = new DepositoService(Gestion);
                return service.Insertar(vale, IdMinerva);
            }

            throw new Exception();
        }

        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/depositos/Desactivar")]
        public bool Desactivar([FromBody] long IdVale)
        {
            DepositoService service;
            long IdMinerva = long.Parse(GetIdUsuario());
            using (var Gestion = FactorizadorDeposito.CrearConexionGenerica())
            {
                service = new DepositoService(Gestion);
                return service.Desactivar(IdVale, IdMinerva);
            }

            throw new Exception();
        }
    }
}
