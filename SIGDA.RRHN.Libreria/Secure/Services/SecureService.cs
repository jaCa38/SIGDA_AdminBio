using SIGDA.Catalogos.Genericos.Models;
using SIGDA.SRHN.Libreria.Deudo.Services.Interfaces;
using SIGDA.SRHN.Libreria.Secure.Models;
using SIGDA.SRHN.Libreria.Secure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Secure.Services
{
    public class SecureService : IPermisoService, IUsuarioService, IDisposable
    {
        private readonly IPermisoService _metodosPermiso;
        private readonly IUsuarioService _metodosUsuario;
        public SecureService(IPermisoService metodosPermiso)
        {
            _metodosPermiso = metodosPermiso;
        }
        public SecureService(IUsuarioService metodosUsuario)
        {
            _metodosUsuario = metodosUsuario;
        }
        public bool AlmacenaPermiso(PermisoBase permiso)
        {
            return _metodosPermiso.AlmacenaPermiso(permiso);
        }
        public List<PermisoBase> ObtenerPermisosModulo(PermisoBase permiso)
        {
            return _metodosPermiso.ObtenerPermisosModulo(permiso);
        }
        public void Dispose()
        {
            try
            {
                //sqlCon.Dispose();
                //sqlCon = null;
                //_Parametros.Clear();
                //media.Close();
                //media = null;
            }
            catch { }
        }

        public List<PermisoBase> ObtenerUsuarios()
        {
            return _metodosUsuario.ObtenerUsuarios();
        }

        public PermisoBase ObtenerPermisosModuloUsuario(PermisoBase permiso)
        {
            return _metodosPermiso.ObtenerPermisosModuloUsuario(permiso);
        }
    }
}
