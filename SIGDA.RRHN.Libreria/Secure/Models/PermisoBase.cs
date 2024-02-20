using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Secure.Models
{
    public class PermisoBase 
    {
        //public long IdPrincipal { get; set; }
        //public string? DescripPrincipal { get; set; }
        public string? Datos { set; get; }
        public int IdModulo { set; get; }
        public int IdUsuario { set; get; }
        public string UserName { set; get; }
        public string Nombre { set; get; }
        public string Paterno { set; get; }
        public string Materno { set; get; }
        public string ListaAcciones { set; get; }
    }
}
