using SIGDA.CA.Biometricos.Libreria.Factorizadores;
using SIGDA.CA.Biometricos.Libreria.Models;
using SIGDA.CA.Biometricos.Libreria.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web.Compilation;
using System.Web.Http;

namespace SIGDA_BackEnd.CA.Biometricos.Controllers
{

    public class EjecutaPaController : ApiController
    {


        [HttpPost]
        [Route("api/EjecutarProcesarInformacion")]
        public bool PostEjecutarProcesarInformacion()
        {
            EjecutarPaDbService service;


            using (var gestion = FactorizadorEjecutarPaDb.CrearConexionAdministracionEjecutarPa())
            {
                service = new EjecutarPaDbService(gestion);
                return service.EjecutarPaProcesarInfo();
            }

            throw new Exception();

        }




    }
}