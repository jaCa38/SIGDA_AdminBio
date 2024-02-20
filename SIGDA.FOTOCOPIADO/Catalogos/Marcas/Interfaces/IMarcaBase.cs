using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Catalogos.Marcas.Interfaces
{
    public interface IMarcaBase
    {
        public long IdMarca { get; set; }
        public string Marca { get; set; }

    }
}
