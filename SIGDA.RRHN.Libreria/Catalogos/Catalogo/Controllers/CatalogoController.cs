using SIGDA.Catalogos.Genericos.Models;
using SIGDA.Catalogos.Genericos.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Catalogos.Catalogo.Controllers
{
    public class CatalogoController : IModelCatalogoBaseService, IDisposable
    {
        #region Constructor Variables        
        private string? strCadena;

        public CatalogoController(string cadena)
        {
            strCadena = cadena;
        }
        #endregion
        public bool AlmacenaInformacionPrimeraVez(List<CatalogoBaseModel> lista)
        {
            Models.CatalogoBase cata = new Models.CatalogoBase(strCadena);
            return cata.AlmacenaInformacionPrimeraVez(lista);
        }
        public List<CatalogoBaseModel> ObtenerCatalogo(CatalogoBaseModel catalogo)
        {
            Models.CatalogoBase cata = new Models.CatalogoBase(strCadena);
            return cata.ObtenerCatalogo(catalogo);
        }
        public void Dispose()
        {
            try { }
            catch (Exception) { }
        }
    }
}
