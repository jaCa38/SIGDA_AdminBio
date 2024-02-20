using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGDA.Documentos.Factorizadores;
using SIGDA.Documentos.Models;
using SIGDA.Documentos.Services;
using SIGDA.FOTOCOPIADO.Libreria.Copiadoras.Factorizadores;
using SIGDA.FOTOCOPIADO.Libreria.Copiadoras.Models;
using SIGDA.FOTOCOPIADO.Libreria.Copiadoras.Services;
using System.Security.Claims;

namespace SIGDA_BackEnd.Controllers.DOCUMENTOS
{
    public class DocumentosController : BaseControllerSIGDA
    {
        private IConfiguration _Config;
        public DocumentosController(IConfiguration Configuration) => _Config = Configuration;

        //[HttpGet]
        //[Route("api/documentos/Get")]
        //public IActionResult GetDocument()
        //{
        //    var stream = new FileStream(@"G:\Cristopher 5 días .pdf", FileMode.Open);
        //    return File(stream, "application/pdf", "FileDownloadName.pdf");
        //}

        [Authorize]
        [HttpPost]
        [Route("api/documentos/ArchivarDocumentoFotocopiado")]
        public long ArchivarDocumentoFotocopiado([FromBody] MetaDocumentoFile metaDocumentoFile)
        {
            MetaDocumentoService service;
            long IdUsuario = 1;
            long IdCT = 1;
            long IdZona = 1;
            IdUsuario =  long.Parse(GetIdUsuario());
            IdCT = long.Parse(GetIdCT());
            IdZona = long.Parse(GetIdZona());

            using (var Gestion = FactorizadorDocumentos.CrearConexionGenerica())
            {
                service = new MetaDocumentoService(Gestion);
                return service.ArchivarDocumento(metaDocumentoFile,IdUsuario, SIGDA.Documentos.Enums.EModuloSIGDA.FOTOCOPIADO,IdCT,IdZona);
            }

            throw new Exception();
        }

        /*Este método es para el cliente Angular que me manda un FileStream*/
        [Authorize]
        [HttpPost]
        [Route("api/documentos/ArchivarDocumentoStreamFotocopiado")]
        public ActionResult<long> ArchivarDocumentoStreamFotocopiado( IFormCollection archivos)
        {
            MetaDocumentoService service;
            long IdUsuario = 1;
            long IdCT = 1;
            long IdZona = 1;
            IdUsuario =  long.Parse(GetIdUsuario());
            IdCT = long.Parse(GetIdCT());
            IdZona = long.Parse(GetIdZona());

            /************AJUSTAR CÓDIGO DE LILI AQUÍ PARA QUE SE MANDE UN FILESTREAM********/

            var file = archivos.Files[0];
            MetaDocumentoFileStream metaDocumentoFileStream = new MetaDocumentoFileStream();
            metaDocumentoFileStream.File = new FileStream(file.FileName, FileMode.Create);
            metaDocumentoFileStream.NombreDocumento = file.FileName;
            metaDocumentoFileStream.IdTipoDocumento = 1;
                
             file.CopyToAsync(metaDocumentoFileStream.File);

            using (var Gestion = FactorizadorDocumentos.CrearConexionGenerica())
            {
                service = new MetaDocumentoService(Gestion);
                return service.ArchivarDocumento(metaDocumentoFileStream, IdUsuario, SIGDA.Documentos.Enums.EModuloSIGDA.FOTOCOPIADO, IdCT, IdZona);
            }

            throw new Exception();
        }

        [Authorize]
        [HttpPost]
        [Route("api/documentos/BorrarDocumento")]
        public bool BorrarDocumento([FromBody] long IdDocumento)
        {
            MetaDocumentoService service;
            long IdUsuario = 1;
            IdUsuario =  long.Parse(GetIdUsuario());

            using (var Gestion = FactorizadorDocumentos.CrearConexionGenerica())
            {
                service = new MetaDocumentoService(Gestion);
                return service.BorrarDocumento(IdDocumento, IdUsuario);
            }

            throw new Exception();
        }

        [Authorize]
        [HttpPost]
        [Route("api/documentos/ConsultarDocumento")]
        public MetaDocumentoConsulta ConsultarDocumento([FromBody] long IdDocumento)
        {
            MetaDocumentoService service;
            string jwt = "123123";
            jwt = GetIdCT() + GetIdZona() + GetIdUsuario();
            using (var Gestion = FactorizadorDocumentos.CrearConexionGenerica())
            {
                service = new MetaDocumentoService(Gestion);
                return service.ConsultarDocumento(IdDocumento, jwt);
            }

            throw new Exception();
        }

    }
}
