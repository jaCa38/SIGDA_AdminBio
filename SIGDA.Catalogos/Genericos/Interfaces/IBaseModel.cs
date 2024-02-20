using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Catalogos.Genericos.Interfaces
{
    public interface IBaseModel
    {
        public long IdPrincipal { get; set; }
        public string DescripPrincipal { get; set; }
    }
}
