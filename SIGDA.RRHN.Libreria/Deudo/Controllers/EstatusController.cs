using SIGDA.Catalogos.Genericos.Models;
using SIGDA.SRHN.Libreria.Deudo.Models;
using SIGDA.SRHN.Libreria.Deudo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Deudo.Controllers
{
    public class EstatusController : IEstatusService, IDisposable
    {
        #region Constructor Variables
        DataTableReader? dtrResultado = null;
        private string? strCadena;

        public EstatusController(string cadena)
        {
            strCadena = cadena;
        }

        public List<BaseModel> ConsultarCatalogoEstatus()
        { 
            EstatusBase Base = new EstatusBase(strCadena);
            return (List<BaseModel>)Base.ConsultarCatalogoGenerico();
        }
        #endregion
        
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
