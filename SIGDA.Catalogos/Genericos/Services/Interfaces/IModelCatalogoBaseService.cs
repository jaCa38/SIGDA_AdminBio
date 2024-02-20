using SIGDA.Catalogos.Genericos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Catalogos.Genericos.Services.Interfaces
{
    public interface IModelCatalogoBaseService: IDisposable
    {
        List<CatalogoBaseModel> ObtenerCatalogo(CatalogoBaseModel catalogo);
        bool AlmacenaInformacionPrimeraVez(List<CatalogoBaseModel> lista);
    }
}
