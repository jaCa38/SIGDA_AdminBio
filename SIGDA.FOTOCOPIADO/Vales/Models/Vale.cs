using SIGDA.FOTOCOPIADO.Libreria.Catalogos.Enums;
using SIGDA.FOTOCOPIADO.Libreria.Vales.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Vales.Models
{
    public class Vale : IValeBase
    {
        public long IdVale { get; set; }
        public string SerieVale { get; set; }
        public string FolioVale { get; set; }
        public DateTime FechaAsignadoVale { get; set; }
        public DateTime FechaRegistradoVale { get; set; }
        public string CantidadCopias { get; set; }
        public long IdentificadorTipoCopia { get; set; }
        public ETiposHoja TipoHoja { get; set; }
        public string Observaciones { get; set; }
        public long IdCopiadora { get; set; }
        public long IdZona { get; set; }
        public long IdMunicipio { get; set; }
        public long IdentificadorCCS { get; set; }
        public long IdEstatusVale { get; set; }
    }
}
