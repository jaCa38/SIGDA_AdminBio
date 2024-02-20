using SIGDA.SRHN.Libreria.Empleados.Models;
using SIGDA.SRHN.Libreria.Empleados.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Empleados.Services
{
    public class TelefonoService : ITelefonoService
    {
        private readonly ITelefonoService _metodos;
        public TelefonoService(ITelefonoService metodos)
        {
            _metodos = metodos;
        }
        public bool Actualiza(TelefonoBase tel)
        {
            return _metodos.Actualiza(tel);
        }

        public bool Almacena(TelefonoBase tel)
        {
            return _metodos.Almacena(tel);
        }

        public void Dispose()
        {
            try { } catch (Exception) { }
        }

        public bool Elimina(TelefonoBase tel)
        {
            return _metodos.Elimina(tel);
        }

        public IEnumerable<TelefonoBase> ObtenerTodos(TelefonoBase tel)
        {
            return _metodos.ObtenerTodos(tel);
        }

        public TelefonoBase ObtenerUno(TelefonoBase tel)
        {
            return _metodos.ObtenerUno(tel);
        }
    }
}
