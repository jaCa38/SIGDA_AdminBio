using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Documentos.Interfaces
{
    public interface IDocumentoBase
    {
        public long IdentificadorDocumento { get; set; }
        public string NombreDocumento { get; set; }
    }
}
