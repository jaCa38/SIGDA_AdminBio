using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Documentos.Models
{
    public class MetaDocumentoFile : MetaDocumentoBase
    {
        public byte[] File { get; set; }
    }
}
