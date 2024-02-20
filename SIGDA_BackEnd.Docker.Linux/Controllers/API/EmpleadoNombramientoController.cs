using Microsoft.AspNetCore.Mvc;
using SIGDA.SRHN.Libreria.Empleados.Factorizadores;
using SIGDA.SRHN.Libreria.Empleados.Models;
using SIGDA.SRHN.Libreria.Empleados.Services;

namespace SIGDA_BackEnd.Docker.Linux.Controllers.API
{
    public class EmpleadoNombramientoController : BaseControllerSIGDA
    {
        private IConfiguration _Config;
        public EmpleadoNombramientoController(IConfiguration Configuration) => _Config = Configuration;
        [HttpPost]
        [Route("api/EmpleadoBase/Curriculum/UltimaActualizacion")]
        public BaseEmpleado ConsultarCandidatos([FromBody] long idEmpleado)
        {
            EmpleadoNombramientoService service;
            using (var Gestion = FactorizadorEmpleado.CrearConexionCurriculum())
            {
                service = new EmpleadoNombramientoService(Gestion);
                return service.ObtenerUltimaActualizacionCV(idEmpleado);
            }
            throw new Exception();
        }
        [HttpPost]
        [Route("api/EmpleadoBase/Curriculum/EstudioAcademico/MaximoGradoEstudio")]
        public EstudioAcademicoBase MaximoEstudioAcademico([FromBody] long idEmpleado)
        {
            EstudioAcademicoService service;
            using (var Gestion = FactorizadorEmpleado.CrearConexionCVEstudioAcademico())
            {
                service = new EstudioAcademicoService(Gestion);
                return service.MaximoEstudioAcademico(idEmpleado);
            }
            throw new Exception();
        }
        [HttpPost]
        [Route("api/EmpleadoBase/Curriculum/InfoLaboral/Obtener")]
        public List<InformacionLaboralBase> InformacionLaboral([FromBody] long idEmpleado)
        {
            InformacionLaboralService service;
            using (var Gestion = FactorizadorEmpleado.CrearConexionCVInfoLaboral())
            {
                service = new InformacionLaboralService(Gestion);
                return service.ObtenerInformacionLaboral(idEmpleado);
            }
            throw new Exception();
        }
        [HttpPost]
        [Route("api/EmpleadoBase/Curriculum/InfoLaboral/ActividadesUnaLinea")]
        public InformacionLaboralBase ActividadesUnaLinea([FromBody] long idEmpleado)
        {
            InformacionLaboralService service;
            using (var Gestion = FactorizadorEmpleado.CrearConexionCVInfoLaboral())
            {
                service = new InformacionLaboralService(Gestion);
                return service.ObtenerLaboralUnaLinea(idEmpleado);
            }
            throw new Exception();
        }
        [HttpPost]
        [Route("api/EmpleadoBase/Curriculum/EstudioAcademico/Obtener")]
        public List<EstudioAcademicoBase> InformacionAcademica([FromBody] long idEmpleado)
        {
            EstudioAcademicoService service;
            using (var Gestion = FactorizadorEmpleado.CrearConexionCVEstudioAcademico())
            {
                service = new EstudioAcademicoService(Gestion);
                return service.ObtenerEstudios(idEmpleado);
            }
            throw new Exception();
        }
        //[Authorize]
        [HttpPost]
        [Route("api/EmpleadoBase/ConsultarCandidato")]
        public IEnumerable<BaseCandidato> ConsultarCandidatos([FromBody] BaseCandidato consulta)
        {
            EmpleadoNombramientoService service;
            using (var Gestion = FactorizadorEmpleado.CrearConexionSIGEIN())
            {
                service = new EmpleadoNombramientoService(Gestion);
                return service.BuscarCandidato(consulta.NombreCandidato, consulta.PaternoCandidato, consulta.MaternoCandidato);
            }
            throw new Exception();
        }
        //[Authorize]
        [HttpPost]
        [Route("api/EmpleadoBase/ConsultarCandidatoPorRFC")]
        public IEnumerable<BaseCandidato> ConsultarCandidatosPorPRFC([FromBody] BaseCandidato consulta)
        {
            EmpleadoNombramientoService service;
            using (var Gestion = FactorizadorEmpleado.CrearConexionSIGEIN())
            {
                service = new EmpleadoNombramientoService(Gestion);
                return service.BuscarCandidatoPorRFC(consulta.Rfc);
            }
            throw new Exception();
        }
        [HttpPost]
        [Route("api/EmpleadoBase/ConsultarCandidatoPorCURP")]
        public IEnumerable<BaseCandidato> ConsultarCandidatosPorCURP([FromBody] BaseCandidato consulta)
        {
            EmpleadoNombramientoService service;
            using (var Gestion = FactorizadorEmpleado.CrearConexionSIGEIN())
            {
                service = new EmpleadoNombramientoService(Gestion);
                return service.BuscarCandidatoPorCURP(consulta.Curp);
            }
            throw new Exception();
        }
        [HttpPost]
        [Route("api/EmpleadoBase/ConsultarDomicilioCandidatoPorRFC")]
        public IEnumerable<DomicilioBase> ConsultarDomicilioCandidatosPorRFC([FromBody] BaseCandidato consulta)
        {
            EmpleadoNombramientoService service;
            using (var Gestion = FactorizadorEmpleado.CrearConexionSIGEIN())
            {
                service = new EmpleadoNombramientoService(Gestion);
                return service.BuscarDomicilioCandidatoPorRFC(consulta.Rfc);
            }
            throw new Exception();
        }
        [HttpPost]
        [Route("api/EmpleadoBase/ConsultarDomicilioCandidatoPorCURP")]
        public IEnumerable<DomicilioBase> ConsultarDomicilioCandidatosPorCURP([FromBody] BaseCandidato consulta)
        {
            EmpleadoNombramientoService service;
            using (var Gestion = FactorizadorEmpleado.CrearConexionSIGEIN())
            {
                service = new EmpleadoNombramientoService(Gestion);
                return service.BuscarDomicilioCandidatoPorCURP(consulta.Curp);
            }
            throw new Exception();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="consulta">{"nombreEmpleado": "string","paternoEmpleado": "string","maternoEmpleado": "string","idCandidato": 127}</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        //[Authorize]
        [HttpPost]
        [Route("api/EmpleadoBase/InsertarNuevoEmpleado")]
        public long InsertarNuevoEmpleado([FromBody] EmpleadoNombramiento consulta)
        {
            EmpleadoNombramientoService service;
            using (var Gestion = FactorizadorEmpleado.CrearConexionEmpleadoNombramiento())
            {
                service = new EmpleadoNombramientoService(Gestion);
                /*string IdMinerva = GetIdUsuario(); 
                return service.InsertarNuevoEmpleado(consulta, long.Parse(IdMinerva));*/
                return service.InsertarNuevoEmpleado(consulta, 1);
            }
            throw new Exception();
        }
        [HttpPost]
        [Route("api/EmpleadoBase/AlmacenaNuevoEmpleado")]
        public long GeneraNuevoEmpleado([FromBody] NuevoEmpleadoBase informacion)
        {
            EmpleadoNombramientoService service;
            using (var Gestion = FactorizadorEmpleado.CrearConexionEmpleadoNombramiento_RH())
            {
                service = new EmpleadoNombramientoService(Gestion);
                /*string IdMinerva = GetIdUsuario(); 
                return service.InsertarNuevoEmpleado(consulta, long.Parse(IdMinerva));*/
                return service.AlmacenaNuevoEmpleado(informacion);
            }
            throw new Exception();
        }
        [HttpPost]
        [Route("api/EmpleadoBase/Domicilio/ConsultarColoniasPorCP")]
        public IEnumerable<DomicilioBase> ConsultarColoniasPorCP([FromBody] DomicilioBase consulta)
        {
            DomicilioService service;
            using (var Gestion = FactorizadorDomicilio.CrearConexionDomicilio())
            {
                service = new DomicilioService(Gestion);
                return service.ObtenerColoniasPorCP(consulta.CP);
            }
            throw new Exception();
        }
        [HttpPost]
        [Route("api/EmpleadoBase/Domicilio/Almacena")]
        public bool AlmacenaDomicilio([FromBody] DomicilioBase domicilio)
        {
            DomicilioService service;
            using (var Gestion = FactorizadorDomicilio.CrearConexionDomicilio())
            {
                service = new DomicilioService(Gestion);
                return service.AlmacenaDomicilio(domicilio);
            }
            throw new Exception();
        }
        [HttpPost]
        [Route("api/EmpleadoBase/Domicilio/ObtenerTodos")]
        public IEnumerable<DomicilioBase> ObtenerTodos([FromBody] DomicilioBase domicilio)
        {
            DomicilioService service;
            using (var Gestion = FactorizadorDomicilio.CrearConexionDomicilio())
            {
                service = new DomicilioService(Gestion);
                return service.ObtenerDomicilios(domicilio);
            }
            throw new Exception();
        }
        [HttpPost]
        [Route("api/EmpleadoBase/Email/ObtenerTodos")]
        public IEnumerable<CorreoElectronicoBase> ObtenerMails([FromBody] CorreoElectronicoBase mail)
        {
            CorreoElectronicoService service;
            using (var Gestion = FactorizadorCorreoElectronico.CrearConexion())
            {
                service = new CorreoElectronicoService(Gestion);
                return service.ObtenerCorreosElectronicos(mail);
            }
            throw new Exception();
        }
        [HttpPost]
        [Route("api/EmpleadoBase/Email/ObtenerUno")]
        public CorreoElectronicoBase ObtenerMail([FromBody] CorreoElectronicoBase mail)
        {
            CorreoElectronicoService service;
            using (var Gestion = FactorizadorCorreoElectronico.CrearConexion())
            {
                service = new CorreoElectronicoService(Gestion);
                return service.ObtenerCorreoElectronico(mail);
            }
            throw new Exception();
        }
        [HttpPost]
        [Route("api/EmpleadoBase/Email/Actualizar")]
        public bool ActualizarEmail([FromBody] CorreoElectronicoBase mail)
        {
            CorreoElectronicoService service;
            using (var Gestion = FactorizadorCorreoElectronico.CrearConexion())
            {
                service = new CorreoElectronicoService(Gestion);
                return service.ActualizarCorreoElectronico(mail);
            }
            throw new Exception();
        }
        [HttpPost]
        [Route("api/EmpleadoBase/Email/Almacenar")]
        public bool AlmacenarEmail([FromBody] CorreoElectronicoBase mail)
        {
            CorreoElectronicoService service;
            using (var Gestion = FactorizadorCorreoElectronico.CrearConexion())
            {
                service = new CorreoElectronicoService(Gestion);
                return service.AlmacenaCorreoElectronico(mail);
            }
            throw new Exception();
        }
        [HttpPost]
        [Route("api/EmpleadoBase/Email/Eliminar")]
        public bool EliminarEmail([FromBody] CorreoElectronicoBase mail)
        {
            CorreoElectronicoService service;
            using (var Gestion = FactorizadorCorreoElectronico.CrearConexion())
            {
                service = new CorreoElectronicoService(Gestion);
                return service.EliminarCorreoElectronico(mail);
            }
            throw new Exception();
        }
        [HttpPost]
        [Route("api/EmpleadoBase/Telefono/ObtenerTodos")]
        public IEnumerable<TelefonoBase> ObtenerTels([FromBody] TelefonoBase mail)
        {
            TelefonoService service;
            using (var Gestion = FactorizadorTelefono.CrearConexion())
            {
                service = new TelefonoService(Gestion);
                return service.ObtenerTodos(mail);
            }
            throw new Exception();
        }
        [HttpPost]
        [Route("api/EmpleadoBase/Telefono/ObtenerUno")]
        public TelefonoBase ObtenerUnTel([FromBody] TelefonoBase mail)
        {
            TelefonoService service;
            using (var Gestion = FactorizadorTelefono.CrearConexion())
            {
                service = new TelefonoService(Gestion);
                return service.ObtenerUno(mail);
            }
            throw new Exception();
        }
        [HttpPost]
        [Route("api/EmpleadoBase/Telefono/Almacena")]
        public bool AlmacenaTelefono([FromBody] TelefonoBase mail)
        {
            TelefonoService service;
            using (var Gestion = FactorizadorTelefono.CrearConexion())
            {
                service = new TelefonoService(Gestion);
                return service.Almacena(mail);
            }
            throw new Exception();
        }
        [HttpPost]
        [Route("api/EmpleadoBase/Telefono/Actualiza")]
        public bool ActualizaTelefono([FromBody] TelefonoBase mail)
        {
            TelefonoService service;
            using (var Gestion = FactorizadorTelefono.CrearConexion())
            {
                service = new TelefonoService(Gestion);
                return service.Actualiza(mail);
            }
            throw new Exception();
        }
        [HttpPost]
        [Route("api/EmpleadoBase/Telefono/Elimina")]
        public bool EliminaTelefono([FromBody] TelefonoBase mail)
        {
            TelefonoService service;
            using (var Gestion = FactorizadorTelefono.CrearConexion())
            {
                service = new TelefonoService(Gestion);
                return service.Elimina(mail);
            }
            throw new Exception();
        }
    }
}

