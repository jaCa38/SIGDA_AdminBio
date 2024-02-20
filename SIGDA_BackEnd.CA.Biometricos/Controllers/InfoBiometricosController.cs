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

    public class InfoBiometricosController : ApiController
    {

        /// <summary>
        /// Retrieves a specific product by unique id
        /// </summary>
        [HttpPost]
        [Route("api/ObtenerRegistrosTerminal")]
        public List<RegistrosRelojes> PostObtenerRegistrosTerminal(DescargaRegistros descargaRegistros)
        {
            AdministracionBaseService service;


            using (var gestion = FactorizadorAdministracionBase.CrearConexionAdministracionBase())
            {
                service = new AdministracionBaseService(gestion);
                return service.ObtenerRegistrosTerminal(descargaRegistros.IpTerminal, descargaRegistros.PortTerminal,descargaRegistros.Fecha);
            }

            throw new Exception();

        }



      

        [HttpPost]
        [Route("api/InsertarRegistrosMYSQL")]
        public bool PostInsertarRegistroMySQL(RegistrosRelojes descargaRegistros)
        {
             DescargaInfoBiometricosService service;


            using (var gestion = FactorizadorDescargaInfoBiometricos.CrearConexionBiometricos())
            {
                service = new DescargaInfoBiometricosService(gestion);
                return service.InsertarRegistrosSICA(descargaRegistros.IdTerminal, descargaRegistros.IdEmpleado, descargaRegistros.Record);
            }

            throw new Exception();

        }

        [HttpPost]
        [Route("api/InsertarRegistrosMSSQL")]
        public bool PostInsertarRegistroMSSQL(RegistrosRelojes descargaRegistros)
        {
            DescargaInfoBiometricosService service;


            using (var gestion = FactorizadorDescargaInfoBiometricos.CrearConexionBiometricos())
            {
                service = new DescargaInfoBiometricosService(gestion);
                return service.InsertarRegistrosMSSQL(descargaRegistros.IdTerminal, descargaRegistros.IdEmpleado, descargaRegistros.Record);
            }

            throw new Exception();

        }






        [HttpPost]
        [Route("api/InsertarLogErrorMSSQL")]
        public bool PostInsertarLogErrorMSSQL(LogAudit logAudit)
        {
            DescargaInfoBiometricosService service;


            using (var gestion = FactorizadorDescargaInfoBiometricos.CrearConexionBiometricos())
            {
                service = new DescargaInfoBiometricosService(gestion);
                return service.InsertarLogErrorDescargaMSSQL(logAudit.IdTerminal,logAudit.TipoTarea,logAudit.FechaDescarga,logAudit.MsjError);
            }

            throw new Exception();

        }


        [HttpPost]
        [Route("api/InsertarLogDescargaRegistrosMSSQL")]
        public bool PostInsertarLogDescargaRegistrosMSSQL(LogAudit logAudit)
        {
            DescargaInfoBiometricosService service;


            using (var gestion = FactorizadorDescargaInfoBiometricos.CrearConexionBiometricos())
            {
                service = new DescargaInfoBiometricosService(gestion);
                return service.InsertarLogDescargaRegistrosMSSQL(logAudit.IdTerminal, logAudit.FechaDescarga, logAudit.CantidadRegistros);
            }

            throw new Exception();

        }





        [HttpPost]
        [Route("api/ObtenerRegistrosTerminalPorRangoFechas")]
        public List<RegistrosRelojes> Post(DescargaRegistrosPorFecha descargaPorRango)
        {
            DescargaInfoBiometricosService service;


            using (var gestion = FactorizadorDescargaInfoBiometricos.CrearConexionBiometricos())
            {
                service = new DescargaInfoBiometricosService(gestion);
                return service.ObtenerRegistrosTerminalPorRangoFechas(descargaPorRango.IpTerminal, descargaPorRango.PortTerminal, descargaPorRango.FechaInicio, descargaPorRango.FechaFin);
            }

            throw new Exception();

        }




    }
}