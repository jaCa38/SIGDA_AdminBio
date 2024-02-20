using SIGDA.CA.Biometricos.Libreria.Factorizadores;
using SIGDA.CA.Biometricos.Libreria.Models;
using SIGDA.CA.Biometricos.Libreria.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Compilation;
using System.Web.Http;

namespace SIGDA_BackEnd.CA.Biometricos.Controllers
{

    public class FotosController : ApiController
    {   
        [HttpPost]
        [Route("api/ObtenerFotosPorEmpleado")]
        public List<Foto> PostFotosOk([FromBody] BusquedaFotos busquedaFotos)
        {
            DescargaFotografiasService service;

            using (var Gestion = FactorizadorDescargaFotografias.CrearConexionBiometricos())
            {
                service = new DescargaFotografiasService(Gestion);
                return service.ObtenerFotosEmpleado(busquedaFotos.EmpleadoId, busquedaFotos.TerminalId, busquedaFotos.FechaFotos);
            }

            throw new Exception();
        }


        [HttpPost]
        [Route("api/ObtenerFotosSorry")]
        public List<FotoSorry> PostFotosSorry([FromBody] BusquedaFotoFailed busquedaFotosSorry)
        {
            DescargaFotografiasService service;

            using (var Gestion = FactorizadorDescargaFotografias.CrearConexionBiometricos())
            {
                service = new DescargaFotografiasService(Gestion);
                return service.ObtenerFotosFailed(busquedaFotosSorry.FechaBusqueda, busquedaFotosSorry.IpTerminal, busquedaFotosSorry.PortTerminal);
            }

            throw new Exception();

        }


        [HttpPost]
        [Route("api/DescargaFotosBiometrico")]
        public FotosResualtado PostDescargFotosBiometrico([FromBody] BusquedaFotoFailed busquedaFotoFailed)
        {
            DescargaFotografiasService service;


            using (var Gestion = FactorizadorDescargaFotografias.CrearConexionBiometricos())
            {
                service = new DescargaFotografiasService(Gestion);
                return service.DescargarFotosOkBiometrico(busquedaFotoFailed.FechaBusqueda, busquedaFotoFailed.IpTerminal, busquedaFotoFailed.PortTerminal, busquedaFotoFailed.NombreTerminal);
            }

            throw new Exception();

        }



        [HttpPost]
        [Route("api/DescargaFotosSorryBiometrico")]
        public FotosResualtado PostDescargFotosSorryBiometrico([FromBody] BusquedaFotoFailed busquedaFotoFailed)
        {
            DescargaFotografiasService service;


            using (var Gestion = FactorizadorDescargaFotografias.CrearConexionBiometricos())
            {
                service = new DescargaFotografiasService(Gestion);
                return service.DescargarFotosSorryBiometrico(busquedaFotoFailed.FechaBusqueda, busquedaFotoFailed.IpTerminal, busquedaFotoFailed.PortTerminal, busquedaFotoFailed.NombreTerminal);
            }

            throw new Exception();

        }


        [HttpPost]
        [Route("api/InsertarLogDescargaFotosMSSQL")]
        public bool PostInsertarLogDescargaFotosMSSQL([FromBody] LogAudit logAudit)
        {
            DescargaFotografiasService service;


            using (var Gestion = FactorizadorDescargaFotografias.CrearConexionBiometricos())
            {
                service = new DescargaFotografiasService(Gestion);
                return service.InsertarLogDescargaFotosMSSQL(logAudit.IdTerminal, logAudit.FechaDescarga,logAudit.CantidadFotos, logAudit.CantidadRegistros);
            }

            throw new Exception();

        }


        [HttpPost]
        [Route("api/ObtenerFotosOkTerminal")]
        public List<Foto> PostObtenerFotosOkTerminal([FromBody] BusquedaFotoFailed busquedaFotoFailed)
        {
            DescargaFotografiasService service;


            using (var Gestion = FactorizadorDescargaFotografias.CrearConexionBiometricos())
            {
                service = new DescargaFotografiasService(Gestion);
                return service.ObtenerFotosOkTerminal(busquedaFotoFailed.FechaBusqueda, busquedaFotoFailed.IpTerminal, busquedaFotoFailed.PortTerminal);
            }

            throw new Exception();

        }







    }
}