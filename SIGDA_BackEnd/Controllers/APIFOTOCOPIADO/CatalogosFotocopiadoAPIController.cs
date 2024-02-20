using Microsoft.AspNetCore.Mvc;
using SIGDA.Catalogos.Genericos.Genericos.Services;
using SIGDA.Catalogos.Genericos.Interfaces;
using SIGDA.FOTOCOPIADO.Libreria.Copiadoras.Factorizadores;
using SIGDA.FOTOCOPIADO.Libreria.Copiadoras.Models;
using SIGDA.FOTOCOPIADO.Libreria.Copiadoras.Services;

namespace SIGDA_BackEnd.Controllers.APIFOTOCOPIADO
{
    public class CatalogosFotocopiadoAPIController : BaseControllerSIGDA
    {
        private IConfiguration _Config;
        public CatalogosFotocopiadoAPIController(IConfiguration Configuration) => _Config = Configuration;

        #region Copiadoras
        //[Authorize]
        [HttpPost]
        [Route("api/fotocopiado/catalogos/ConsultarCopiadoras")]
        public IEnumerable<CopiadoraBase> ConsultarCopiadoras()
        {
            CopiadoraService service;

            using (var Gestion = FactorizadorCopiadora.CrearConexionGenerica())
            {
                service = new CopiadoraService(Gestion);
                return service.Consultar();
            }

            throw new Exception();
        }
        //[Authorize]
        [HttpPost]
        [Route("api/fotocopiado/catalogos/ConsultarCopiadorasFiltroId")]
        public CopiadoraBase ConsultarCopiadorasFiltroId([FromBody] CopiadoraBase catalogo)
        {
            CopiadoraService service;

            using (var Gestion = FactorizadorCopiadora.CrearConexionGenerica())
            {
                service = new CopiadoraService(Gestion);
                return service.Consultar(catalogo.IdCopiadora);
            }

            throw new Exception();
        }

        //[Authorize]
        [HttpPost]
        [Route("api/fotocopiado/catalogos/InsertarCopiadora")]
        public bool InsertarCopiadora([FromBody] CopiadoraBase catalogo)
        {
            CopiadoraService service;

            using (var Gestion = FactorizadorCopiadora.CrearConexionGenerica())
            {
                service = new CopiadoraService(Gestion);
                return service.Insertar(catalogo);
            }

            throw new Exception();
        }

        //[Authorize]
        [HttpPost]
        [Route("api/fotocopiado/catalogos/ActualizarCopiadora")]
        public bool ActualizarCopiadora([FromBody] CopiadoraBase catalogo)
        {
            CopiadoraService service;

            using (var Gestion = FactorizadorCopiadora.CrearConexionGenerica())
            {
                service = new CopiadoraService(Gestion);
                return service.Actualizar(catalogo);
            }

            throw new Exception();
        }

        //[Authorize]
        [HttpPost]
        [Route("api/fotocopiado/catalogos/DesactivarCopiadora")]
        public bool DesactivarCopiadora([FromBody] CopiadoraBase catalogo)
        {
            CopiadoraService service;

            using (var Gestion = FactorizadorCopiadora.CrearConexionGenerica())
            {
                service = new CopiadoraService(Gestion);
                return service.Desactivar(catalogo.IdCopiadora);
            }

            throw new Exception();
        }
        #endregion

    }
}
