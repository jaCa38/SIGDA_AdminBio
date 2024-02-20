using SIGDA.Catalogos.Genericos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Catalogos.Genericos.Models
{
    public class CatalogoBaseModel : ICatalogoBaseModel, IBaseModel
    {
        public CatalogoBaseModel()
        {
            IdRelacion = 0;
        }
        public long IdPrincipal { set; get; }
        public string DescripPrincipal { set; get; }
        public long IdPrincipalProgres { set; get; }
        public string Esquema { set; get; }
        public int IdRelacion { set; get; } //tipoClave

        public virtual IEnumerable<CatalogoBaseModel> ObtenerCatalogo(CatalogoBaseModel catalogo)
        {
            throw new NotImplementedException();
        }
        public virtual bool AlmacenaInformacionPrimeraVez(List<CatalogoBaseModel> lista)
        {
            throw new NotImplementedException();
        }


    }
}
