
using SIGDA.Catalogos.Genericos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Empleados.Interfaces
{
    public interface ITelefonoBase : IBaseModel
    {
        public int IdTelefono { set; get; }
        public string Numero { set; get; }
        
    }
}
