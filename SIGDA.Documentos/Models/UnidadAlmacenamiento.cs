using SIGDA.Documentos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Documentos.Models
{
    public class UnidadAlmacenamiento : IUnidadAlmacenamiento
    {
        public long IdUnidadAlmacenamiento { get; set; }
        public string RutaUnidadAlmacenamiento { get; set; }
    }
}
