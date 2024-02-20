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
    public class DestinoController : IDestinoService, IDisposable
    {
        DataTableReader? dtrResultado = null;
        private string? strCadena;
        public DestinoController(string cadena)
        {
            strCadena = cadena;
        }
        public List<BaseModel> ConsultarCatalogoDestino()
        {
            DestinoBase Base = new DestinoBase(strCadena);
            return (List<BaseModel>)Base.ConsultarCatalogoGenerico();
        }

        public List<BaseModel> ConsultarCatalogoDestinoHijo(long Identificador)
        {
            DestinoBase Base = new DestinoBase(strCadena);
            return (List<BaseModel>)Base.ConsultarCatalogoGenerico(Identificador);
        }

        public void Dispose()
        {
            try { }
            catch (Exception)
            { }
        }
    }
}
