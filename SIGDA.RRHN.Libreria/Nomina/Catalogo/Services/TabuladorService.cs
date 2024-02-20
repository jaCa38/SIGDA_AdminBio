using SIGDA.SRHN.Libreria.Nomina.Catalogo.Models;
using SIGDA.SRHN.Libreria.Nomina.Catalogo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Nomina.Catalogo.Services
{
    public class TabuladorService : ITabuladorService, IDisposable
    {
        private readonly ITabuladorService _metodos;
        public TabuladorService(ITabuladorService metodos)
        {
            _metodos = metodos;
        }
        public bool AlmacenaTabulador(TabuladorBase tabulador)
        {
            return _metodos.AlmacenaTabulador(tabulador);
        }

        public void Dispose()
        {
            try { }
            catch (Exception) { }
        }

        public TabuladorBase ObtenerTabuladorVigente()
        {
            return _metodos.ObtenerTabuladorVigente();
        }
    }
}
