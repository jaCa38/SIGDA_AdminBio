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
    public class InsertarDbController : ApiController
    {


        [HttpPost]
        [Route("api/InsertarBiometriaMSSQL")]
        public bool PostInsertarBiometriaMSSQLL([FromBody] BiometriaEnvio biometria)
        {
            InsertarDatosDbService service;


            using (var gestion = FactorizadorInsertarDatosDb.CrearConexionBiometricos())
            {
                service = new InsertarDatosDbService(gestion);
                return service.InsertarBiometriaDBMSSQL(biometria.Id, biometria.IdTerminal, biometria.BiometriaTemplate);
            }

            throw new Exception();

        }


    }
}