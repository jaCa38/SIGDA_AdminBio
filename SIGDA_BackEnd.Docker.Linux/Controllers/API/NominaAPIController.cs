using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIGDA.Catalogos.Genericos.Genericos.Services;
using SIGDA.Catalogos.Genericos.Interfaces;
using SIGDA.SRHN.Libreria.Deudo.Factorizadores;
using SIGDA.SRHN.Libreria.Nomina.Catalogo.Enums;
using SIGDA.SRHN.Libreria.Nomina.Catalogo.Factorizadores;
using SIGDA.SRHN.Libreria.Nomina.Catalogo.Models;
using SIGDA.SRHN.Libreria.Nomina.Catalogo.Services;

namespace SIGDA_BackEnd.Docker.Linux.Controllers.API
{   
    public class NominaAPIController : ControllerBase
    {
        private IConfiguration _Config;
        public NominaAPIController(IConfiguration Configuration) => _Config = Configuration;        

        [HttpPost]
        [Route("api/Nomina/Catalogo/AlmacenaTablaImpuestos")]
        public bool AlmacenaTabla([FromBody] EncabezadoTabla tabla)
        {
            TablaImpuestosService service;
            using (var Gestion = TablaImpuestosFactorizador.CrearConexionTablaLimites())
            {
                service = new TablaImpuestosService(Gestion);
                return service.AlmacenaTabla(tabla);
            }
            throw new Exception();
        }
        [HttpPost]
        [Route("api/Nomina/Catalogo/ObtenerTablaImpuestos")]
        public EncabezadoTabla ObtenerTabla([FromBody] ETipoTabla tipoTabla)
        {
            TablaImpuestosService service;
            using (var Gestion = TablaImpuestosFactorizador.CrearConexionTablaLimites())
            {
                service = new TablaImpuestosService(Gestion);
                return service.ObtenerTablaVigente(tipoTabla);
            }
            throw new Exception();
        }

        [HttpPost]
        [Route("api/Nomina/Catalogo/AlmacenaParametrosTabulador")]
        public bool AlmacenaParametrosTabulador([FromBody] ParametrosBase parametros)
        {
            ParametrosService service;
            using (var Gestion = ParametrosFactorizador.CrearConexionParametros())
            {
                service = new ParametrosService(Gestion);
                return service.AltaParametros(parametros);
            }
            throw new Exception();
        }
        [HttpPost]
        [Route("api/Nomina/Catalogo/ObtenerPararmetrosTabuladorVigente")]
        public ParametrosBase ObtenerParametrosTabuladorVigente()
        {
            ParametrosService service;
            using (var Gestion = ParametrosFactorizador.CrearConexionParametros())
            {
                service = new ParametrosService(Gestion);
                return service.ObtenerParametrosVigentes();
            }
            throw new Exception();
        }

        [HttpPost]
        [Route("api/Nomina/Catalogo/Tabulador/Almacena")]
        public bool AlmacenaTabulador([FromBody] TabuladorBase tabulador)
        {
            TabuladorService service;
            using (var Gestion = TabuladorFactorizador.CrearConexionTabulador())
            {
                service = new TabuladorService(Gestion);
                return service.AlmacenaTabulador(tabulador);
            }
            throw new Exception();
        }

        [HttpPost]
        [Route("api/Nomina/Catalogo/Tabulador/ObtenerVigente")]
        public TabuladorBase ObtenerTabuladorVigente()
        {
            TabuladorService service;
            using (var Gestion = TabuladorFactorizador.CrearConexionTabulador())
            {
                service = new TabuladorService(Gestion);
                return service.ObtenerTabuladorVigente();
            }
            throw new Exception();
        }
    }
}
