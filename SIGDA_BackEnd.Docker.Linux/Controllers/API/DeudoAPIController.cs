using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGDA.Catalogos.Genericos.Genericos.Services;
using SIGDA.Catalogos.Genericos.Interfaces;
using SIGDA.SRHN.Libreria.Deudo.Factorizadores;
using SIGDA.SRHN.Libreria.Deudo.Models;
using SIGDA.SRHN.Libreria.Deudo.Services;

namespace SIGDA_BackEnd.Docker.Linux.Controllers.API
{
    public class DeudoAPIController : BaseControllerSIGDA
    {
        private IConfiguration _Config;
        public DeudoAPIController(IConfiguration Configuration) => _Config = Configuration;

        //[Authorize]
        [HttpPost]
        [Route("api/Deudo/Conceptos/Conceptos")]
        public IEnumerable<IBaseModel> ConsultarConceptos()
        {
            ModelGenericoService service;

            using (var Gestion = FactorizadorDeudo.CrearConexionConcepto())
            {
                service = new ModelGenericoService(Gestion);
                return service.ConsultarCatalogoGenerico();
            }

            throw new Exception();
        }

        //[Authorize]
        [HttpPost]
        [Route("api/Deudo/Conceptos/ConsultarFiltroId")]
        public IBaseModel ConsultarConceptosFiltroId([FromBody] long Id)
        {
            ModelGenericoService service;

            using (var Gestion = FactorizadorDeudo.CrearConexionConcepto())
            {
                service = new ModelGenericoService(Gestion);
                return service.ConsultarCatalogoGenericoFiltroId(Id);
            }

            throw new Exception();
        }
        //[Authorize]
        [HttpPost]
        [Route("api/Deudo/Conceptos/Actualizar")]
        public bool ActualizarConcepto([FromBody] long Id, [FromBody] string descripcion)
        {
            ModelGenericoService service;

            using (var Gestion = FactorizadorDeudo.CrearConexionConcepto())
            {
                service = new ModelGenericoService(Gestion);
                return service.ActualizarCatalogoGenerico(Id, descripcion);
            }

            throw new Exception();
        }
        //[Authorize]
        [HttpPost]
        [Route("api/Deudo/Conceptos/Almacenar")]
        public bool AlmacenarConcepto([FromBody] string descripcion)
        {
            ModelGenericoService service;

            using (var Gestion = FactorizadorDeudo.CrearConexionConcepto())
            {
                service = new ModelGenericoService(Gestion);
                return service.InsertarCatalogoGenerico(descripcion);
            }

            throw new Exception();
        }
        //[Authorize]
        [HttpPost]
        [Route("api/Deudo/Estatus/Consultar")]
        public IEnumerable<IBaseModel> ConsultarEstatus()
        {
            DeudoService service;

            using (var Gestion = FactorizadorDeudo.CrearConexionEstatus())
            {
                service = new DeudoService(Gestion);
                return service.ConsultarCatalogoEstatus();
            }
            throw new Exception();
        }
        //[Authorize]
        [HttpPost]
        [Route("api/Deudo/TipoRecuperacion/Consultar")]
        public IEnumerable<IBaseModel> ConsultarTipoRecuperacion()
        {
            DeudoService service;

            using (var Gestion = FactorizadorDeudo.CrearConexionTipoRecuperacion())
            {
                service = new DeudoService(Gestion);
                return service.ConsultarCatalogoTiposRecuperacion();
            }
            throw new Exception();
        }
        //[Authorize]
        [HttpPost]
        [Route("api/Deudo/Registro/Consultar")]
        public IEnumerable<RegistroBase> ConsultarRegistro()
        {
            DeudoService service;

            using (var Gestion = FactorizadorDeudo.CrearConexionRegistro())
            {
                service = new DeudoService(Gestion);
                return service.ConsultarRegistros();
            }
            throw new Exception();
        }
        //[Authorize]
        [HttpPost]
        [Route("api/Deudo/Registro/Consultar/{id}")]
        public IEnumerable<RegistroBase> ConsultarRegistro(long id)
        {
            DeudoService service;

            using (var Gestion = FactorizadorDeudo.CrearConexionRegistro())
            {
                service = new DeudoService(Gestion);
                return service.ConsultarRegistrosFiltro(id);
            }
            throw new Exception();
        }
        //[Authorize]
        [HttpPost]
        [Route("api/Deudo/Registro/Almacenar")]
        public bool AlmacenarRegistro([FromBody] RegistroBase registro)
        {
            DeudoService service;

            using (var Gestion = FactorizadorDeudo.CrearConexionRegistro())
            {
                service = new DeudoService(Gestion);
                return service.AlmacenaRegistro(registro);
            }
            throw new Exception();
        }
        //[Authorize]
        [HttpPost]
        [Route("api/Deudo/Registro/Eliminar/{id}")]
        public bool EliminarRegistro(long id)
        {
            DeudoService service;

            using (var Gestion = FactorizadorDeudo.CrearConexionRegistro())
            {
                service = new DeudoService(Gestion);
                return service.EliminaRegistro(id);
            }
            throw new Exception();
        }
        //[Authorize]
        [HttpPost]
        [Route("api/Deudo/Registro/Modificar")]
        public bool ModificarRegistro([FromBody] RegistroBase registro)
        {
            DeudoService service;

            using (var Gestion = FactorizadorDeudo.CrearConexionRegistro())
            {
                service = new DeudoService(Gestion);
                return service.ModificaRegistro(registro);
            }
            throw new Exception();
        }
        //[Authorize]
        [HttpPost]
        [Route("api/Deudo/Registro/Saldar")]
        public bool SaldarRegistro([FromBody] RegistroBase registro)
        {
            DeudoService service;

            using (var Gestion = FactorizadorDeudo.CrearConexionRegistro())
            {
                service = new DeudoService(Gestion);
                return service.SaldarRegistro(registro);
            }
            throw new Exception();
        }
        [HttpPost]
        [Route("api/Deudo/Registro/ModificarAdeudoPendiente")]
        public bool ModificarAdeudoPendiente([FromBody] RegistroBase registro)
        {
            DeudoService service;

            using (var Gestion = FactorizadorDeudo.CrearConexionRegistro())
            {
                service = new DeudoService(Gestion);
                return service.ModificaAdeudoPendiente(registro);
            }
            throw new Exception();
        }
        //[Authorize]
        [HttpPost]
        [Route("api/Deudo/Seguimiento/Consultar/{id}")]
        public IEnumerable<SeguimientoBase> ConsultarSeguimiento(long id)
        {
            DeudoService service;

            using (var Gestion = FactorizadorDeudo.CrearConexionSeguimiento())
            {
                service = new DeudoService(Gestion);
                return service.ConsultarSeguimiento(id);
            }
            throw new Exception();
        }
        //[Authorize]
        [HttpPost]
        [Route("api/Deudo/Seguimiento/Almacenar")]
        public bool AlmacenarSeguimiento([FromBody] SeguimientoBase seguimiento)
        {
            DeudoService service;

            using (var Gestion = FactorizadorDeudo.CrearConexionSeguimiento())
            {
                service = new DeudoService(Gestion);
                return service.AlmacenarSeguimiento(seguimiento);
            }
            throw new Exception();
        }
        //[Authorize]
        [HttpPost]
        [Route("api/Deudo/Destino/Consultar")]
        public IEnumerable<IBaseModel> ConsultarDestino()
        {
            DeudoService service;

            using (var Gestion = FactorizadorDeudo.CrearConexionDestino())
            {
                service = new DeudoService(Gestion);
                return service.ConsultarDestino();
            }
            throw new Exception();
        }
        //[Authorize]
        [HttpPost]
        [Route("api/Deudo/Destino/Consultar/{id}")]
        public IEnumerable<IBaseModel> ConsultarDestino(int id)
        {
            DeudoService service;

            using (var Gestion = FactorizadorDeudo.CrearConexionDestino())
            {
                service = new DeudoService(Gestion);
                return service.ConsultarDestinoHijo(id);
            }
            throw new Exception();
        }
        
    }
}
