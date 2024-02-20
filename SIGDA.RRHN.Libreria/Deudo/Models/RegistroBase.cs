using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Deudo.Models
{
    public class RegistroBase
    {
        public int IdRegistro { set; get; }
        public int IdEmpleado { set; get; }
        public decimal MontoAdeudo { set; get; }
        public int IdTipoRecuperacion { set; get; }
        public int IdConcepto { set; get; }
        public int IdEstatus { set; get; }
        public string Observaciones { set; get; }
        public int IdUsuario { set; get; }
        public string Fecha { set; get; } //UN COMENTARIO
        public decimal MontoAbono { set; get; }
        public string ListaFechas { set; get; }
    }
}
