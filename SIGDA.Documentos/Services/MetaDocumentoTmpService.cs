using SIGDA.Documentos.Models;
using SIGDA.Documentos.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Documentos.Services
{
    public class MetaDocumentoTmpService: IMetaDocumentoTmpService
    {
        private readonly IMetaDocumentoTmpService _service;
        public MetaDocumentoTmpService(IMetaDocumentoTmpService service)
        {
            _service = service;
        }
        public long ArchivarDocumento(MetaDocumentoFile metaDocumentoFile, long IdMinerva)
        {
            return _service.ArchivarDocumento(metaDocumentoFile, IdMinerva);
        }

        public bool BorrarDocumento(long IdDocumento)
        {
            return _service.BorrarDocumento(IdDocumento);
        }

        public MetaDocumentoTmpConsulta ConsultarDocumento(long IdDocumento, string JWT)
        {
            return _service.ConsultarDocumento(IdDocumento, JWT);
        }

        public void Dispose()
        {
            try { }
            catch { }
        }
    }
}
