using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Catalogos.Genericos.Interfaces
{
    public interface ICatalogoBaseModel
    {
        public long IdPrincipalProgres { set; get; }
        public string Esquema { set; get; }
    }
}
