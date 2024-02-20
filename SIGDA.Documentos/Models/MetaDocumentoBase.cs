using SIGDA.Documentos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Documentos.Models
{
    public class MetaDocumentoBase : IDocumentoBase, ITipoDocumento
    {
        public long IdentificadorDocumento { get; set; }
        public string NombreDocumento { get; set; }
        public long IdTipoDocumento { get; set; }
        public string DescripcionTipoDocumento { get; set; }
    }
}
