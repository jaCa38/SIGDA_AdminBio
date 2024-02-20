using SIGDA.FOTOCOPIADO.Libreria.Catalogos.TipoCopia.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Catalogos.TipoCopia.Models
{
    public class TipoCopiaBase:ITipoCopiaBase
    {
        public long IdentificadorTipoCopia { get; set; }
        public string DescripcionTipoCopia { get; set; }
        public string ClaveTipoCopia { get; set; }
    }
}
