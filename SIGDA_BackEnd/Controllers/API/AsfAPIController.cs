using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SIGDA.Catalogos.Genericos.Models;
using SIGDA.SRHN.Libreria.ASF.Factorizadores;
using SIGDA.SRHN.Libreria.ASF.Models;
using SIGDA.SRHN.Libreria.ASF.Services;
using SIGDA.SRHN.Libreria.Deudo.Factorizadores;
using System.Collections.Generic;

namespace SIGDA_BackEnd.Controllers.API
{

    public class AsfAPIController : ControllerBase
    {
        private IConfiguration _Config;
        public AsfAPIController(IConfiguration Configuration) => _Config = Configuration;
        //[Authorize]
        [HttpPost]
        [Route("api/asf/participaciones/auxiliar/cuotasissegissste/obtener")]
        public IEnumerable<CuotaISSEGISSSTEBase> ConsultarCuotas([FromBody] CuotaISSEGISSSTEBase identificador)
        {
            ASFService service;
            using (var Gestion = FactorizadorASF.CrearConexionCuotas())
            {
                service = new ASFService(Gestion);
                return service.ObtenerInformacion(identificador);
            }
            throw new Exception();
        }
        [HttpPost]
        [Route("api/asf/participaciones/auxiliar/cuotasissegissste/almacenar")]
        public bool AlmacenarCuotas([FromBody] List<CuotaISSEGISSSTEBase> cuotas)
        {
            ASFService service;
            using (var Gestion = FactorizadorASF.CrearConexionCuotas())
            {
                service = new ASFService(Gestion);
                return service.AlmacenarInformacion(cuotas);
            }
            throw new Exception();
        }
        [HttpPost]
        [Route("api/asf/participaciones/nomord/encabezado")]
        public List<EncabezadoNomOrdBase> ObtenerInfoEncabezado([FromBody] int anio)
        {
            ASFService service;
            using (var Gestion = FactorizadorASF.CrearConexionNomOrd())
            {
                service = new ASFService(Gestion);
                return service.ObtenerInformacionEncabezado(anio);
            }
            throw new Exception();
        }
        [HttpPost]
        [Route("api/asf/participaciones/nomord/clavesmontos")]
        public List<ClaveMontoBase> ObtenerInfoClavesMontos([FromBody] int anio, [FromBody] long idGral)
        {
            ASFService service;
            using (var Gestion = FactorizadorASF.CrearConexionNomOrd())
            {
                service = new ASFService(Gestion);
                return service.ObtenerInformacionClavesMontos(anio, idGral);
            }
            throw new Exception();
        }

        [HttpPost]
        [Route("api/asf/desafectacion/busquedaEmpleado")]
        public List<EmpleadoDesafectacionBase> BuscarCoincidencias([FromBody] EmpleadoDesafectacionBase empleado)
        {
            ASFService service;
            using (var Gestion = FactorizadorASF.CrearConexionDesafectacion())
            {
                service = new ASFService(Gestion);
                return service.BuscarCoincidenciaEmpleado(empleado);
            }
            throw new Exception();
        }
        [HttpPost]
        [Route("api/asf/desafectacion/obtener")]
        public List<EmpleadoDesafectacionBase> Obtener([FromBody] int anio)
        {
            ASFService service;
            using (var Gestion = FactorizadorASF.CrearConexionDesafectacion())
            {
                service = new ASFService(Gestion);
                return service.Obtener(anio);
            }
            throw new Exception();
        }
        [HttpPost]
        [Route("api/asf/desafectacion/obtenerUno")]
        public EmpleadoDesafectacionBase ObtenerUno([FromBody] string identif)
        {
            long idGeneral;
            int anio;
            string[] datos = identif.Split('-');
            idGeneral = Convert.ToInt64(datos[0]);
            anio = Convert.ToInt32(datos[1]);
            ASFService service;
            using (var Gestion = FactorizadorASF.CrearConexionDesafectacion())
            {
                service = new ASFService(Gestion);
                return service.ObtenerUno(idGeneral, anio);
            }
            throw new Exception();
        }
        [HttpPost]
        [Route("api/asf/desafectacion/almacenar")]
        public bool AlmacenaInformacion([FromBody] EmpleadoDesafectacionBase informacion)
        {
            EmpleadoDesafectacionBase encabezado = informacion;
            List<DetalleDesafectacion> detalle = informacion.ListaDetalle;
            ASFService service;
            using (var Gestion = FactorizadorASF.CrearConexionDesafectacion())
            {
                service = new ASFService(Gestion);
                return service.AlmacenaInformacion(encabezado, detalle);
            }
            throw new Exception();
        }
    }
}
