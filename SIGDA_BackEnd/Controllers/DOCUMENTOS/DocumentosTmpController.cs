using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGDA.Documentos.Factorizadores;
using SIGDA.Documentos.Models;
using SIGDA.Documentos.Services;

namespace SIGDA_BackEnd.Controllers.DOCUMENTOS
{
    public class DocumentosTmpController : BaseControllerSIGDA
    {
        private IConfiguration _Config;
        public DocumentosTmpController(IConfiguration Configuration) => _Config = Configuration;

        // [Authorize]
        [HttpPost]
        [Route("api/documentostmp/ArchivarDocumento")]
        public long ArchivarDocumento([FromBody] MetaDocumentoFile metaDocumentoFile)
        {
            MetaDocumentoTmpService service;
            long IdUsuario = 1;
            IdUsuario = long.Parse(GetIdUsuario());

            using (var Gestion = FactorizadorDocumentos.CrearConexionGenericaDocumentosTmp())
            {
                service = new MetaDocumentoTmpService(Gestion);
                return service.ArchivarDocumento(metaDocumentoFile, IdUsuario);
            }

            throw new Exception();
        }

        [Authorize]
        [HttpPost]
        [Route("api/documentostmp/BorrarDocumento")]
        public bool BorrarDocumento([FromBody] long IdDocumento)
        {
            MetaDocumentoTmpService service;
            /*
             long IdUsuario = 1;
             IdUsuario = long.Parse(GetIdUsuario());
            */
            using (var Gestion = FactorizadorDocumentos.CrearConexionGenericaDocumentosTmp())
            {
                service = new MetaDocumentoTmpService(Gestion);
                return service.BorrarDocumento(IdDocumento);
            }

            throw new Exception();
        }

        [Authorize]
        [HttpPost]
        [Route("api/documentostmp/ConsultarDocumento")]
        public MetaDocumentoTmpConsulta ConsultarDocumento([FromBody] long IdDocumento)
        {
            MetaDocumentoTmpService service;
            string jwt = "123123";
            jwt = GetIdUsuario();
            using (var Gestion = FactorizadorDocumentos.CrearConexionGenericaDocumentosTmp())
            {
                service = new MetaDocumentoTmpService(Gestion);
                return service.ConsultarDocumento(IdDocumento, jwt);
            }

            throw new Exception();
        }
    }
}
