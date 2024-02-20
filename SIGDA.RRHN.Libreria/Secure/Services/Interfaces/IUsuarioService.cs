using SIGDA.SRHN.Libreria.Secure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Secure.Services.Interfaces
{
    public interface IUsuarioService:IDisposable
    {
        List<PermisoBase> ObtenerUsuarios();
    }
}
