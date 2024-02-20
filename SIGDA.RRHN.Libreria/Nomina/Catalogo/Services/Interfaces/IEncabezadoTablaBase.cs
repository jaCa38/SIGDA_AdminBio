using SIGDA.SRHN.Libreria.Nomina.Catalogo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Nomina.Catalogo.Services.Interfaces
{
    public interface IEncabezadoTablaBase
    {
        public int IdTabla { set; get; }
        public string Descripcion { set; get; }
        public int Anio { set; get; }        
        public ETipoTabla TipoTabla { set; get; }
    }
}
