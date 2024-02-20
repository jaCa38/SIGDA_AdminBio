using SIGDA.SRHN.Libreria.Nomina.Catalogo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Nomina.Catalogo.Services.Interfaces
{
    public interface ITabuladorService: IDisposable
    {
        public bool AlmacenaTabulador(TabuladorBase tabulador);
        public TabuladorBase ObtenerTabuladorVigente();
    }
}
