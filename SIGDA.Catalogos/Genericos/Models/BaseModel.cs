
using SIGDA.Catalogos.Genericos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Catalogos.Genericos.Models
{
    public class BaseModel : IBaseModel
    {
        public long IdPrincipal { get; set; }
        public string? DescripPrincipal { get; set; }
        public virtual IEnumerable<BaseModel> ConsultarCatalogoGenerico()
        {
            throw new NotImplementedException();
        }
        public virtual BaseModel ConsultarCatalogoGenericoFiltroID()
        {
            throw new NotImplementedException();
        }
        public virtual bool InsertarCatalogoGenerico()
        {
            throw new NotImplementedException();
        }
        public virtual bool ActualizarCatalogoGenerico()
        {
            throw new NotImplementedException();
        }
        public virtual IEnumerable<BaseModel> ConsultarCatalogoGenerico(long Identificador)
        {
            throw new NotImplementedException();
        }
        public virtual bool DesactivarRegistro()
        {
            throw new NotImplementedException();
        }
    }
}
