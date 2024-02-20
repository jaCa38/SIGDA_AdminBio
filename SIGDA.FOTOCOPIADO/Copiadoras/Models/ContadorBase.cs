using SIGDA.FOTOCOPIADO.Libreria.Copiadoras.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Copiadoras.Models
{
    public class ContadorBase : IContadorBase
    {
        public long IdContador { get; set; }
        public DateTime FechaContador { get; set; }
        public long ContadorInicial { get; set; }
        public long ContadorFinal { get; set; }
        public long IdCopiadora { get; set; }
    }
}
