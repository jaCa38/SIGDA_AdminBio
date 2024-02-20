using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIGDA.SRHN.Libreria.Deudo.Factorizadores;
using SIGDA.SRHN.Libreria.Secure.Factorizadores;
using SIGDA.SRHN.Libreria.Secure.Models;
using SIGDA.SRHN.Libreria.Secure.Services;
using SIGDA.SRHN.Libreria.Secure.Services.Interfaces;

namespace SIGDA_BackEnd.Controllers.API
{
   
    public class SecureAPIController : ControllerBase
    {
        private IConfiguration _Config;
        public SecureAPIController(IConfiguration Configuration) => _Config = Configuration;

        [HttpPost]
        [Route("api/Secure/Permisos/Modulo/Obtener")]
        public IEnumerable<PermisoBase> ConsultarPermisosModulo([FromBody] PermisoBase permiso)
        {
            SecureService service;
            using (var Gestion = FactorizadorSecure.CrearConexionPermiso())
            {
                service = new SecureService(Gestion);
                return service.ObtenerPermisosModulo(permiso);
            }
            throw new Exception();
        }
        [HttpPost]
        [Route("api/Secure/Permisos/Modulo/Usuario/Obtener")]
        public PermisoBase ConsultarPermisosModuloUsuario([FromBody] PermisoBase permiso)
        {
            SecureService service;
            using (var Gestion = FactorizadorSecure.CrearConexionPermiso())
            {
                service = new SecureService(Gestion);
                return service.ObtenerPermisosModuloUsuario(permiso);
            }
            throw new Exception();
        }

        [HttpPost]
        [Route("api/Secure/Permisos/Almacenar")]
        public bool AlmacenarPermisos([FromBody] PermisoBase permiso)
        {
            SecureService service;
            using (var Gestion = FactorizadorSecure.CrearConexionPermiso())
            {
                service = new SecureService(Gestion);
                return service.AlmacenaPermiso(permiso);
            }
            throw new Exception();
        }
        [HttpPost]
        [Route("api/Secure/Usuarios/Obtener")]
        public IEnumerable<PermisoBase> ConsultarUsuarios()
        {
            SecureService service;
            using (var Gestion = FactorizadorSecure.CrearConexionUsuario())
            {
                service = new SecureService(Gestion);
                return service.ObtenerUsuarios();
            }
            throw new Exception();
        }
    }
    
}
