﻿using SIGDA.Documentos.Enums;
using SIGDA.Documentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Documentos.Services.Interfaces
{
    public interface IMetaDocumentoTmpService: IDisposable
    {
        long ArchivarDocumento(MetaDocumentoFile metaDocumentoFile, long IdMinerva);
        Boolean BorrarDocumento(long IdDocumento);
        MetaDocumentoTmpConsulta ConsultarDocumento(long IdDocumento, string JWT);
    }
}
