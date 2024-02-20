using SIGDA.SRHN.Libreria.Nomina.Catalogo.Enums;
using SIGDA.SRHN.Libreria.Nomina.Catalogo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Nomina.Catalogo.Models
{
    public class TabuladorBase : IEncabezadoTablaBase
    {
        public int IdTabla { set; get; }
        public string Descripcion { set; get; }
        public int Anio { set; get; }
        public ETipoTabla TipoTabla { set; get; }
        public List<DetalleTabuladorBase> ListaDetalleTabulador { set; get; } = new List<DetalleTabuladorBase>();
    }
}
