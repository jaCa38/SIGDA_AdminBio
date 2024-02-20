using SIGDA.Documentos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Documentos.Models
{
    public class MetaDocumentoFileStream: MetaDocumentoBase, IFileStream
    {
        public FileStream File { get; set; }
    }
}
