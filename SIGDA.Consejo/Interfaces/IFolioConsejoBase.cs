using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Consejo.Libreria.Interfaces
{
    public interface IFolioConsejoBase
    {
        public long IdentificadorPromocion { get; set; }
        public string ObservacionesPromocion { get; set; }
        public long IdentificadorPrecalificacion { get; set; }
    }
}
