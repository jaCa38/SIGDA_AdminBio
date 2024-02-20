using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Vales.Interfaces
{
    public interface IEstatusVale
    {
        public long IdEstatusVale { get; set; }
        public string EstatusVale { get; set; }
    }
}
