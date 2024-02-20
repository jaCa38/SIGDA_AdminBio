using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Autenticacion.Modelos
{
    public class BaseModel
    {
        public long Identificador { get; set; }
        public int Estatus { get; set; }
    }

    public class UsuarioModel : BaseModel
    {
        public List<TicketModel> Tickets { get; set; }
        public string Token { get; set; }
        public string Correo { get; set; }

    }
    public class TicketModel : BaseModel
    {
        public CentrosModel Centro { get; set; }
        public RolModel Rol { get; set; }
        public PlataformaModel Plataforma { get; set; }
        public List<ModuloModel> Modulos { get; set; }
    }
    public class OficinaModel : BaseModel
    {
        public string Clave { get; set; }
    }
    public class RolModel : BaseModel { }
    public class PlataformaModel : BaseModel { }
    public class ModuloModel : BaseModel { }

    public class UsuarioMinModel
    {
        public string Id { get; set; }
        public string Nick { get; set; }
        public string Pass { get; set; }
    }

    public class ContenedorMaestroModel<T>
    {
        public ContenedorModel<T> Contenedor { get; set; }
    }
    public class ContenedorModel<T>
    {
        public List<T> Elementos { get; set; }
    }
    
    public class ErrorModel
    {
        public string Mensaje { get; set; }
        public string Detalle { get; set; }
        public int StatusCode { get; set; }
    }
    public class MinervaGModel
    {
    }

    public class CentrosModel : BaseModel
    {
        public CentrosDgtiModel CentroDgti { get; set; }
        public Centro401 Centro401 { get; set; }
        public int Periodo { get; set; }
    }
    public class CentrosDgtiModel : BaseModel
    {
        public string CentroTrabajo { get; set; }
        public string Juzgado { get; set; }
        public MunicipioModel Municipio { get; set; }
        public long UbicacionesId { get; set; }
    }
    public class Centro401 : BaseModel
    {
        public string CentroCosto { get; set; }
        public string Denominacion { get; set; }
        public string CentroTrabajo { get; set; }
        public int Zona { get; set; }
    }

    public class MunicipioModel : BaseModel
    {
        public int EstadoId { get; set; }
    }
}
