using SIGDA.SRHN.Libreria.Empleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Empleados.Services.Interfaces
{
    public interface ITelefonoService : IDisposable
    {
        IEnumerable<TelefonoBase> ObtenerTodos(TelefonoBase tel);
        TelefonoBase ObtenerUno(TelefonoBase tel);
        bool Almacena(TelefonoBase tel);
        bool Actualiza(TelefonoBase tel);
        bool Elimina(TelefonoBase tel);
    }
}
