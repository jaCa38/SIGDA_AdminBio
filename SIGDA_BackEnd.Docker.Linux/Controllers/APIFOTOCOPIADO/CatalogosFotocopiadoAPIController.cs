using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGDA.Catalogos.Genericos.Genericos.Services;
using SIGDA.Catalogos.Genericos.Interfaces;
using SIGDA.Catalogos.Genericos.Models;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.CentrosFotocopiado.Factorizadores;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.CentrosFotocopiado.Models;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.CentrosFotocopiado.Services;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.CentrosTrabajo.Factorizadores;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.CentrosTrabajo.Models;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.CentrosTrabajo.Services;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.Marcas.Factorizadores;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.Modelos.Factorizadores;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.Modelos.Models;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.Modelos.Services;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.Services;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.TipoCopia.Factorizadores;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.TipoCopia.Models;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.TipoCopia.Services;
using SIGDA.FOTOCOPIADO.Libreria.Copiadoras.Factorizadores;
using SIGDA.FOTOCOPIADO.Libreria.Copiadoras.Models;
using SIGDA.FOTOCOPIADO.Libreria.Copiadoras.Services;

namespace SIGDA_BackEnd.Docker.Linux.Controllers.APIFOTOCOPIADO
{
    public class CatalogosFotocopiadoAPIController : BaseControllerSIGDA
    {
        private IConfiguration _Config;
        public CatalogosFotocopiadoAPIController(IConfiguration Configuration) => _Config = Configuration;

        #region Copiadoras
        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/catalogos/ConsultarCopiadoras")]
        public IEnumerable<CopiadoraBase> ConsultarCopiadoras()
        {
            CopiadoraService service;
            //string idusuario = GetIdUsuario();
            using (var Gestion = FactorizadorCopiadora.CrearConexionGenerica())
            {
                service = new CopiadoraService(Gestion);
                return service.Consultar();
            }

            throw new Exception();
        }

        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/catalogos/ConsultarDetalleCopiadoras")]
        public IEnumerable<CopiadoraDetalle> ConsultarDetalleCopiadoras()
        {
            CopiadoraService service;

            using (var Gestion = FactorizadorCopiadora.CrearConexionGenerica())
            {
                service = new CopiadoraService(Gestion);
                return service.ConsultarDetalle();
            }

            throw new Exception();
        }
        [Authorize]
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

        [Authorize]
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

        [Authorize]
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

        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/catalogos/ActualizarUbicacionCopiadora")]
        public bool ActualizarUbicacionCopiadora([FromBody] CopiadoraBase catalogo)
        {
            CopiadoraService service;

            using (var Gestion = FactorizadorCopiadora.CrearConexionGenerica())
            {
                service = new CopiadoraService(Gestion);
                return service.ActualizarUbicacion(catalogo);
            }

            throw new Exception();
        }

        [Authorize]
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

        #region Marcas
        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/catalogos/ConsultarMarcas")]
        public IEnumerable<IBaseModel> ConsultarMarcas()
        {
            ModelGenericoService service;

            using (var Gestion = FactorizadorMarca.CrearConexionGenerica())
            {
                service = new ModelGenericoService(Gestion);
                return service.ConsultarCatalogoGenerico();
            }

            throw new Exception();
        }

        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/catalogos/InsertarMarca")]
        public bool InsertarMarca([FromBody] CatalogoBaseModel catalogo)
        {
            ModelGenericoService service;

            using (var Gestion = FactorizadorMarca.CrearConexionGenerica())
            {
                service = new ModelGenericoService(Gestion);
                return service.InsertarCatalogoGenerico(catalogo.DescripPrincipal);
            }

            throw new Exception();
        }
        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/catalogos/ActualizarMarca")]
        public bool ActualizarMarca([FromBody] CatalogoBaseModel catalogo)
        {
            ModelGenericoService service;

            using (var Gestion = FactorizadorMarca.CrearConexionGenerica())
            {
                service = new ModelGenericoService(Gestion);
                return service.ActualizarCatalogoGenerico(catalogo.IdPrincipal,catalogo.DescripPrincipal);
            }

            throw new Exception();
        }
        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/catalogos/DesactivarMarca")]
        public bool DesactivarMarca([FromBody] CatalogoBaseModel catalogo)
        {
            CatalogoGenericoService service;

            using (var Gestion = FactorizadorMarca.CrearConexionDesactivarMarca())
            {
                service = new CatalogoGenericoService(Gestion);
                return service.DesactivarCatalogoGenerico(catalogo.IdPrincipal);
            }

            throw new Exception();
        }

        #endregion

        #region Modelos
        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/catalogos/ConsultarModelos")]
        public List<ModelosBase> ConsultarModelos()
        {
            ModeloService service;

            using (var Gestion = FactorizadorModelo.CrearConexionGenerica())
            {
                service = new ModeloService(Gestion);
                return service.ConsultarModelos();
            }

            throw new Exception();
        }

        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/catalogos/InsertarModelo")]
        public bool InsertarModelo([FromBody] ModelosBase catalogo)
        {
            ModeloService service;

            using (var Gestion = FactorizadorModelo.CrearConexionGenerica())
            {
                service = new ModeloService(Gestion);
                return service.InsertarModelo(catalogo.DescripcionModelo,catalogo.IdentificadorMarca);
            }

            throw new Exception();
        }
        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/catalogos/ActualizarModelo")]
        public bool ActualizarModelo([FromBody] ModelosBase catalogo)
        {
            ModeloService service;

            using (var Gestion = FactorizadorModelo.CrearConexionGenerica())
            {
                service = new ModeloService(Gestion);
                return service.ActualizarModelo(catalogo.IdentificadorModelo, catalogo.DescripcionModelo, catalogo.IdentificadorMarca);
            }

            throw new Exception();
        }
        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/catalogos/DesactivarModelo")]
        public bool DesactivarModelo([FromBody] ModelosBase catalogo)
        {
            ModeloService service;

            using (var Gestion = FactorizadorModelo.CrearConexionGenerica())
            {
                service = new ModeloService(Gestion);
                return service.DesactivarModelo(catalogo.IdentificadorModelo);
            }

            throw new Exception();
        }
        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/catalogos/ConsultarModeloPorMarca")]
        public List<ModelosBase> ConsultarModeloPorMarca([FromBody] ModelosBase catalogo)
        {
            ModeloService service;

            using (var Gestion = FactorizadorModelo.CrearConexionGenerica())
            {
                service = new ModeloService(Gestion);
                return service.ConsultarModeloPorMarca(catalogo.IdentificadorMarca);
            }

            throw new Exception();
        }
        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/catalogos/ConsultarModeloFiltroId")]
        public ModelosBase ConsultarModeloFiltroId([FromBody] ModelosBase catalogo)
        {
            ModeloService service;

            using (var Gestion = FactorizadorModelo.CrearConexionGenerica())
            {
                service = new ModeloService(Gestion);
                return service.ConsultarModeloFiltroId(catalogo.IdentificadorModelo);
            }

            throw new Exception();
        }
        #endregion

        #region Tipos Copia
        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/catalogos/ConsultarTiposCopia")]
        public List<TipoCopiaBase> ConsultarTiposCopia()
        {
            TipoCopiaService service;

            using (var Gestion = FactorizadorTipoCopia.CrearConexionGenerica())
            {
                service = new TipoCopiaService(Gestion);
                return service.ConsultarTiposCopia();
            }

            throw new Exception();
        }
        #endregion

        #region Centros Fotocopiado
        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/catalogos/ConsultarCentrosFotocopiado")]
        public IEnumerable<CentroFotocopiadoDetalle> ConsultarCentrosFotocopiado()
        {
            CentroFotocopiadoService service;

            using (var Gestion = FactorizadorCentroFotocopiado.CrearConexionGenerica())
            {
                service = new CentroFotocopiadoService(Gestion);
                return service.Consultar();
            }

            throw new Exception();
        }
        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/catalogos/ConsultarCentrosFotocopiadoFiltroId")]
        public CentroFotocopiadoDetalle ConsultarCentrosFotocopiadoFiltroId([FromBody] CentroFotocopiadoBase catalogo)
        {
            CentroFotocopiadoService service;

            using (var Gestion = FactorizadorCentroFotocopiado.CrearConexionGenerica())
            {
                service = new CentroFotocopiadoService(Gestion);
                return service.Consultar(catalogo.IdCentroFotocopiado);
            }

            throw new Exception();
        }

        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/catalogos/InsertarCentrosFotocopiado")]
        public bool InsertarCentrosFotocopiado([FromBody] CentroFotocopiadoBase catalogo)
        {
            CentroFotocopiadoService service;

            using (var Gestion = FactorizadorCentroFotocopiado.CrearConexionGenerica())
            {
                service = new CentroFotocopiadoService(Gestion);
                return service.Insertar(catalogo);
            }

            throw new Exception();
        }

        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/catalogos/ActualizarCentrosFotocopiado")]
        public bool ActualizarCentrosFotocopiado([FromBody] CentroFotocopiadoBase catalogo)
        {
            CentroFotocopiadoService service;

            using (var Gestion = FactorizadorCentroFotocopiado.CrearConexionGenerica())
            {
                service = new CentroFotocopiadoService(Gestion);
                return service.Actualizar(catalogo);
            }

            throw new Exception();
        }

        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/catalogos/DesactivarCentrosFotocopiado")]
        public bool DesactivarCentrosFotocopiado([FromBody] CentroFotocopiadoBase catalogo)
        {
            CentroFotocopiadoService service;

            using (var Gestion = FactorizadorCentroFotocopiado.CrearConexionGenerica())
            {
                service = new CentroFotocopiadoService(Gestion);
                return service.Desactivar(catalogo.IdCentroFotocopiado);
            }

            throw new Exception();
        }
        #endregion

        #region Centros de Trabajo 401 SAP
        [Authorize]
        [HttpPost]
        [Route("api/fotocopiado/catalogos/ConsultarCentrosTrabajoSAP")]
        public IEnumerable<CentroTrabajoSAPBase> ConsultarCentrosTrabajoSAP()
        {
            CentroTrabajoService service;

            using (var Gestion = FactorizadorCentroTrabajo.CrearConexionGenerica())
            {
                service = new CentroTrabajoService(Gestion);
                return service.Consultar();
            }

            throw new Exception();
        }
        #endregion
    }
}
