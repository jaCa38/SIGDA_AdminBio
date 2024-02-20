using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Catalogos.Modelos.Interfaces
{
    public interface IModeloBase
    {
        public long IdModelo { get; set; }
        public string Modelo { get; set; }
    }
}
