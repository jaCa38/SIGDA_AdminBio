using SIGDA.FOTOCOPIADO.Libreria.Vales.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Vales.Models
{
    public class ValeBase: IValeBase
    {
        public long IdVale { get; set; }
        public string SerieVale { get; set; }
        public string FolioVale { get; set; }
        public long IdCopiadora { get; set; }
        public string NombreCopiadora { get; set; }
    }
}
