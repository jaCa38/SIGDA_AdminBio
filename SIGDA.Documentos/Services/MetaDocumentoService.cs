using SIGDA.Documentos.Enums;
using SIGDA.Documentos.Models;
using SIGDA.Documentos.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Documentos.Services
{
    public class MetaDocumentoService: IMetaDocumentoService
    {
        private readonly IMetaDocumentoService _metaDocumentoService;
        public MetaDocumentoService(IMetaDocumentoService metaDocumentoService)
        {
            _metaDocumentoService = metaDocumentoService;
        }

        public long ArchivarDocumento(MetaDocumentoFile metaDocumentoFile, long IdMinerva, EModuloSIGDA eModuloSIGDA, long IdCT, long IdZona)
        {
            return _metaDocumentoService.ArchivarDocumento(metaDocumentoFile,IdMinerva,eModuloSIGDA,IdCT,IdZona);
        }

        public long ArchivarDocumento(MetaDocumentoFileStream metaDocumentoFileStream, long IdMinerva, EModuloSIGDA eModuloSIGDA, long IdCT, long IdZona)
        {
            return _metaDocumentoService.ArchivarDocumento(metaDocumentoFileStream, IdMinerva, eModuloSIGDA, IdCT, IdZona);
        }

        public bool BorrarDocumento(long IdDocumento, long IdMinerva)
        {
            return _metaDocumentoService.BorrarDocumento(IdDocumento, IdMinerva);
        }

        public MetaDocumentoConsulta ConsultarDocumento(long IdDocumento, string JWT)
        {
            return _metaDocumentoService.ConsultarDocumento(IdDocumento,JWT);
        }

        public void Dispose()
        {
            try { }
            catch { }
        }
    }
}
