using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Catalogos.Modelos.Models
{
    public class ModelosBase
    {
        public long IdentificadorModelo { get; set; }
        public string DescripcionModelo { get; set; }
        public long IdentificadorMarca { get; set; }
        public string DescripcionMarca { get; set; }
    }
}
