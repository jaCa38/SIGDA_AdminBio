using SIGDA.Autenticacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Autenticacion.Modelos.Controllers
{
    public class AuthController : IAutenticacion
    {
        private string? strCadena;

        public AuthController(string cadena)
        {
            strCadena = cadena;
        }
 

        void IAutenticacion.Dispose()
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        UsuarioModel IAutenticacion.Login(UsuarioMinModel modUsuario)
        {
            throw new NotImplementedException();
        }


    }
}