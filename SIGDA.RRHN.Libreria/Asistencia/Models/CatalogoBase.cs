using SIGDA.Catalogos.Genericos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace SIGDA.SRHN.Libreria.Asistencia.Models
{
    public class CatalogoBase : IBaseModel
    {
        public long IdPrincipal { get; set; }
        public string DescripPrincipal { get; set; }
        public string Esquema { set; get; }
    }
}
