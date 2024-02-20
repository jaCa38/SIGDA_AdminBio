using SIGDA.Catalogos.Genericos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Catalogos.Genericos.Models
{
    public class ZonaBase : IBaseModel
    {
        public long IdPrincipal { set; get; }
        public string DescripPrincipal { set; get; }
        public int IdZona { set; get; }
        public string DescripZona { set; get; }
    }
}
