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
    public class TipoRecuperacionController : ITipoRecuperacionService, IDisposable
    {
        DataTableReader? dtrResultado = null;
        private string? strCadena;

        public TipoRecuperacionController(string cadena)
        {
            strCadena = cadena;
        }

        public List<BaseModel> ConsultarCatalogoTiposRecuperacion()
        {
            TipoRecuperacionBase Base = new TipoRecuperacionBase(strCadena);
            return (List<BaseModel>)Base.ConsultarCatalogoGenerico();
        }

        public void Dispose()
        {
            try
            {

            }
            catch (Exception)
            {

            }
        }

        
    }
}
