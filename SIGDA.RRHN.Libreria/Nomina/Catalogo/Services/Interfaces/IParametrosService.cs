using SIGDA.SRHN.Libreria.Nomina.Catalogo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Nomina.Catalogo.Services.Interfaces
{
    public interface IParametrosService : IDisposable
    {
        public bool AltaParametros(ParametrosBase parametros);
        public ParametrosBase ObtenerParametrosVigentes();
    }
}
