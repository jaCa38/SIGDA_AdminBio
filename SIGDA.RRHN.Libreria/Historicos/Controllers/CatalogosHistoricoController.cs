using SIGDA.Catalogos.Genericos.Models;
using SIGDA.SRHN.Libreria.Historicos.Models;
using SIGDA.SRHN.Libreria.Historicos.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Historicos.Controllers
{
    public class CatalogosHistoricoController : ICatalogosHistoricoService, IDisposable
    {
        #region Constructor Variables
        DataTableReader? dtrResultado = null;
        private string? strCadena;

        public CatalogosHistoricoController(string cadena)
        {
            strCadena = cadena;
        }
        #endregion
        public List<BaseModel> ConsultarCatalogoTipoPeriodo()
        {
            TipoPeriodo Base = new TipoPeriodo(strCadena);
            return (List<BaseModel>)Base.ConsultarCatalogoGenerico();
        }

        public void Dispose()
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
