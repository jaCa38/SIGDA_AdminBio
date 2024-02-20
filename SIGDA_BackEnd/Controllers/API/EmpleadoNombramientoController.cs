using Microsoft.AspNetCore.Mvc;
using SIGDA.SRHN.Libreria.Empleados.Factorizadores;
using SIGDA.SRHN.Libreria.Empleados.Models;
using SIGDA.SRHN.Libreria.Empleados.Services;

namespace SIGDA_BackEnd.Controllers.API
{
    public class EmpleadoNombramientoController : BaseControllerSIGDA
    {
        private IConfiguration _Config;
        public EmpleadoNombramientoController(IConfiguration Configuration) => _Config = Configuration;

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
        [Route("api/EmpleadoBase/Curriculum/UltimaActualizacion")]
        public BaseEmpleado ObtenerUltimaActualizacion([FromBody] long idEmpleado)
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
        [Route("api/EmpleadoBase/Curriculum/EstudioAcademico/Obtener")]
        public List<EstudioAcademicoBase> ObtenerTodos([FromBody] long idEmpleado)
        {
            EstudioAcademicoService service;
            using(var Gestion = FactorizadorEmpleado.CrearConexionCVEstudioAcademico())
            {
                service = new EstudioAcademicoService(Gestion);
                return service.ObtenerEstudios(idEmpleado);
            }
            throw new Exception();
        }
        [HttpPost]
        [Route("api/EmpleadoBase/Curriculum/EstudioAcademico/ObtenerUno")]
        public EstudioAcademicoBase ObtenerUno([FromBody] EstudioAcademicoBase estudio)
        {
            EstudioAcademicoService service;
            using (var Gestion = FactorizadorEmpleado.CrearConexionCVEstudioAcademico())
            {
                service = new EstudioAcademicoService(Gestion);
                return service.ObtenerEstudio(estudio.IdEstudio, estudio.IdEmpleado);
            }
            throw new Exception();
        }
        [HttpPost]
        [Route("api/EmpleadoBase/Curriculum/EstudioAcademico/Almacenar")]
        public bool AlmacenaEstudio([FromBody] EstudioAcademicoBase estudio)
        {
            EstudioAcademicoService service;
            using (var Gestion = FactorizadorEmpleado.CrearConexionCVEstudioAcademico())
            {
                service = new EstudioAcademicoService(Gestion);
                return service.AlmacenaEstudio(estudio);
            }
            throw new Exception();
        }
        [HttpPost]
        [Route("api/EmpleadoBase/Curriculum/EstudioAcademico/Modificar")]
        public bool ModificaEstudio([FromBody] EstudioAcademicoBase estudio)
        {
            EstudioAcademicoService service;
            using (var Gestion = FactorizadorEmpleado.CrearConexionCVEstudioAcademico())
            {
                service = new EstudioAcademicoService(Gestion);
                return service.ModificaEstudio(estudio);
            }
            throw new Exception();
        }
        [HttpPost]
        [Route("api/EmpleadoBase/Curriculum/EstudioAcademico/Elimina")]
        public bool EliminaEstudio([FromBody] EstudioAcademicoBase estudio)
        {
            EstudioAcademicoService service;
            using (var Gestion = FactorizadorEmpleado.CrearConexionCVEstudioAcademico())
            {
                service = new EstudioAcademicoService(Gestion);
                return service.EliminaEstudio(estudio);
            }
            throw new Exception();
        }
        [HttpPost]
        [Route("api/EmpleadoBase/Curriculum/EstudioAcademico/MaximoGradoEstudio")]
        public EstudioAcademicoBase ObtenerMaximoGradoEstudio([FromBody] long idEmpleado)
        {
            EstudioAcademicoService service;
            using (var Gestion = FactorizadorEmpleado.CrearConexionCVEstudioAcademico())
            {
                service = new EstudioAcademicoService(Gestion);
                return service.MaximoEstudioAcademico(idEmpleado);
            }
            throw new Exception();
        }
        /// <summary>
        /// Obtiene todos los registros laboral de un empleado
        /// </summary>
        /// <param name="idEmpleado">El Id del empleado</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost]
        [Route("api/EmpleadoBase/Curriculum/InfoLaboral/Obtener")]
        public List<InformacionLaboralBase> ObtenerTodosLaboral([FromBody] long idEmpleado)
        {
            InformacionLaboralService service;
            using (var Gestion = FactorizadorEmpleado.CrearConexionCVInfoLaboral())
            {
                service = new InformacionLaboralService(Gestion);
                return service.ObtenerInformacionLaboral(idEmpleado);
            }
            throw new Exception();
        }
        /// <summary>
        /// Obtiene un registro laboral
        /// </summary>
        /// <param name="info">{IdLaboral: el id del registro laboral; IdEmpleado: el Id del empleado}</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost]
        [Route("api/EmpleadoBase/Curriculum/InfoLaboral/ObtenerUno")]
        public InformacionLaboralBase ObtenerUnoLaboral([FromBody] InformacionLaboralBase info)
        {
            InformacionLaboralService service;
            using (var Gestion = FactorizadorEmpleado.CrearConexionCVInfoLaboral())
            {
                service = new InformacionLaboralService(Gestion);
                return service.ObtenerLaboral(info);
            }
            throw new Exception();
        }
        /// <summary>
        /// Almacena un nuevo registro de información laboral
        /// </summary>
        /// <param name="info">{No se incluye la propiedad IdLaboral}</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost]
        [Route("api/EmpleadoBase/Curriculum/InfoLaboral/Almacenar")]
        public bool AlmacenaLaboral([FromBody] InformacionLaboralBase info)
        {
            InformacionLaboralService service;
            using (var Gestion = FactorizadorEmpleado.CrearConexionCVInfoLaboral())
            {
                service = new InformacionLaboralService(Gestion);
                return service.AlmacenaLaboral(info);
            }
            throw new Exception();
        }
        /// <summary>
        /// Modifica la información de un registro laboral
        /// </summary>
        /// <param name="info">{Todo el objeto}</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost]
        [Route("api/EmpleadoBase/Curriculum/InfoLaboral/Modificar")]
        public bool ModificaLaboral([FromBody] InformacionLaboralBase info)
        {
            InformacionLaboralService service;
            using (var Gestion = FactorizadorEmpleado.CrearConexionCVInfoLaboral())
            {
                service = new InformacionLaboralService(Gestion);
                return service.ModificaLaboral(info);
            }
            throw new Exception();
        }
        /// <summary>
        /// Elimina un registro laboral
        /// </summary>
        /// <param name="info">{IdEmpleado: numero de empleado}</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost]
        [Route("api/EmpleadoBase/Curriculum/InfoLaboral/Elimina")]
        public bool EliminaEstudio([FromBody] InformacionLaboralBase info)
        {
            InformacionLaboralService service;
            using (var Gestion = FactorizadorEmpleado.CrearConexionCVInfoLaboral())
            {
                service = new InformacionLaboralService(Gestion);
                return service.EliminaLaboral(info);
            }
            throw new Exception();
        }
        /// <summary>
        /// Obtiene todas las actividades laborales de un empleado, en una sola línea concatenada
        /// </summary>
        /// <param name="idEmpleado">Id de Empleado para obtener </param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost]
        [Route("api/EmpleadoBase/Curriculum/InfoLaboral/ActividadesUnaLinea")]
        public InformacionLaboralBase ObtenerActividadesUnaLinea([FromBody] long idEmpleado)
        {
            InformacionLaboralService service;
            using (var Gestion = FactorizadorEmpleado.CrearConexionCVInfoLaboral())
            {
                service = new InformacionLaboralService(Gestion);
                return service.ObtenerLaboralUnaLinea(idEmpleado);
            }
            throw new Exception();
        }
    }
}

