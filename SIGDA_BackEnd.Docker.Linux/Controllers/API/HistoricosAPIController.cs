using Microsoft.AspNetCore.Mvc;
using SIGDA.Catalogos.Genericos.Interfaces;
using SIGDA.SRHN.Libreria.Historicos.Factorizadores;
using SIGDA.SRHN.Libreria.Historicos.Services;

namespace SIGDA_BackEnd.Docker.Linux.Controllers.API
{
    public class HistoricosAPIController: BaseControllerSIGDA
    {
        private IConfiguration _Config;
        public HistoricosAPIController(IConfiguration Configuration) => _Config = Configuration;

        //[Authorize]
        [HttpPost]
        [Route("api/Historicos/Catalogos/ConsultarTiposPeriodo")]
        public IEnumerable<IBaseModel> ConsultarTiposPeriodo()
        {
            CatalogosHistoricoService service;

            using (var Gestion = FactorizadorCatalogosHistorico.CrearConexionCatalogosHistorico())
            {
                service = new CatalogosHistoricoService(Gestion);
                return service.ConsultarCatalogoTipoPeriodo();
            }

            throw new Exception();
        }
    }
}
