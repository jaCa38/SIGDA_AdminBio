using Microsoft.AspNetCore.Mvc;
using SIGDA.SRHN.Libreria.Asistencia.Enums;
using SIGDA.SRHN.Libreria.Asistencia.Factorizador;
using SIGDA.SRHN.Libreria.Asistencia.Models;
using SIGDA.SRHN.Libreria.Asistencia.Services;
using SIGDA.SRHN.Libreria.Deudo.Factorizadores;
using SIGDA.SRHN.Libreria.Deudo.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SIGDA_BackEnd.Controllers.API
{
    public class AsistenciaAPIController : ControllerBase
    {
        private IConfiguration _Config;
        public AsistenciaAPIController(IConfiguration Configuration) => _Config = Configuration;

        //[Authorize]
        [HttpPost]
        [Route("api/Asistencia/ConfigEmpleado/Catalogo/Obtener")]
        public List<CatalogoBase> ObtenerCatalogo([FromBody] ETipoCatalogo catalogo)
        {
            AsistenciaService service;

            using (var Gestion = FactorizadorAsistencia.CrearConexionCatalogoAsistencia())
            {
                service = new AsistenciaService(Gestion);
                return service.ObtenerCatalogoAsistencia(catalogo);
            }
            throw new Exception();
        }

        [HttpPost]
        [Route("api/Asistencia/ConfigEmpleado/Descuento/Obtener")]
        public List<DescuentoEmpleadoBase> ObtenerListado([FromBody] DescuentoEmpleadoBase descuentoEmpleado)
        {
            AsistenciaService service;
            using(var Gestion = FactorizadorAsistencia.CrearConexionDescuentoEmpleado())
            {
                service = new AsistenciaService(Gestion);
                return service.ObtenerListado(descuentoEmpleado);
            }
            throw new Exception();
        }
        [HttpPost]
        [Route("api/Asistencia/ConfigEmpleado/Descuento/Almacenar")]
        public bool Almacenar([FromBody] DescuentoEmpleadoBase descuentoEmpleado)
        {
            AsistenciaService service;
            using (var Gestion = FactorizadorAsistencia.CrearConexionDescuentoEmpleado())
            {
                service = new AsistenciaService(Gestion);
                return service.AlmacenarDescuentoEmpleado(descuentoEmpleado);
            }
            throw new Exception();
        }
        [HttpPost]
        [Route("api/Asistencia/ConfigEmpleado/Descuento/Modificar")]
        public bool Modificar([FromBody] DescuentoEmpleadoBase descuentoEmpleado)
        {
            AsistenciaService service;
            using (var Gestion = FactorizadorAsistencia.CrearConexionDescuentoEmpleado())
            {
                service = new AsistenciaService(Gestion);
                return service.ModificaDescuentoEmpleado(descuentoEmpleado);
            }
            throw new Exception();
        }
    }
}
