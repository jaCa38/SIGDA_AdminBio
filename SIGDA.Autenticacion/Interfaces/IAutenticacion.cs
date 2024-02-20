using SIGDA.Autenticacion.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Autenticacion.Interfaces
{
    public interface IAutenticacion : IDisposable
    {
        UsuarioModel Login(UsuarioMinModel modUsuario);


        #region IDisposable Members
        public void Dispose()
        {
            try
            {
            }
            catch { }
        }
        #endregion
    }
}
