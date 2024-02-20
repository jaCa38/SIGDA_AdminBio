using SIGDA.FOTOCOPIADO.Libreria.Catalogos.Enums;
using SIGDA.FOTOCOPIADO.Libreria.Copiadoras.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Copiadoras.Interfaces
{
    public interface ICopiadoraBase
    {
        public long IdCopiadora { get; set; }
        public string NombreCopiadora { get; set; }
        public long IdAnterior { get; set; }
        public string Serie { get; set; }
        public DateTime FechaAlta { get; set; }
        public ETiposPropiedad TipoPropiedad { get; set; }
        public EstatusCopiadora EstatusCopiadora { get; set; }

    }
}
