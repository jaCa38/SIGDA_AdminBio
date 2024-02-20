using SIGDA.Documentos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Documentos.Models
{
    public class MetaDocumentoConsulta : MetaDocumentoBase, IDocumentoConsulta
    {
        public string GUIDDocumento { get; set; }
        public long IdMinervaDocumento { get; set; }
        public DateTime FechaCreacionDocumento { get; set; }
        public string RutaDocumento { get; set; }
        public long IdZonaMetaDocumento { get; set; }
        public string ZonaMetaDocumento { get; set; }
        public long IdCTMetaDocumento { get; set; }
        public string CTMetaDocumento { get; set; }
        public string URL { get; set; }
    }
}
