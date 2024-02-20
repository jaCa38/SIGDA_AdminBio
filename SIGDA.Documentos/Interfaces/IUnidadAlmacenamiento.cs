using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Documentos.Interfaces
{
    public interface IUnidadAlmacenamiento
    {
        public long IdUnidadAlmacenamiento { get; set; }
        public string RutaUnidadAlmacenamiento { get; set; }
    }
}
