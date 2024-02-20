using SIGDA.Documentos.Controllers;
using SIGDA.Documentos.Services.Interfaces;
using SIGDA.Documentos.Tools;
using SIGDA.Reporteador.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Documentos.Factorizadores
{
    public static class FactorizadorDocumentos
    {
        public static IMetaDocumentoTmpService CrearConexionGenericaDocumentosTmp()
        {
            IMetaDocumentoTmpService nuevoMotor;

            nuevoMotor = new MetaDocumentoTmpController(ConnectionStrings.BDDOCUMENTOS);

            return nuevoMotor;
        }
    }
}
