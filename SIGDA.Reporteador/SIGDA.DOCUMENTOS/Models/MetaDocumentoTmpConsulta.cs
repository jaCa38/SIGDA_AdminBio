
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Documentos.Models
{
    public class MetaDocumentoTmpConsulta : MetaDocumentoBase
    {
        public string GUIDDocumento { get; set; }
        public long IdMinervaDocumento { get; set; }
        public DateTime FechaCreacionDocumento { get; set; }
        public string RutaDocumento { get; set; }
        public string URL { get; set; }
    }
}
