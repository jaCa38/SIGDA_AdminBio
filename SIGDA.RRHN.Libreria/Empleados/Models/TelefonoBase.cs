using SIGDA.SRHN.Libreria.Empleados.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Empleados.Models
{
    public class TelefonoBase : ITelefonoBase
    {
        public int IdTelefono { set; get; }
        public string Numero { set; get; }
        /// <summary>
        /// EL TIPO DE TELEFONO
        /// </summary>
        public long IdPrincipal { set; get; }
        /// <summary>
        /// DESCRIPCIÓN DEL TIPO DE TELEFONO
        /// </summary>
        public string DescripPrincipal { set; get; }
        public int IdEmpleado { set; get; }
    }
}
