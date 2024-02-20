using SIGDA.SRHN.Libreria.Nomina.Catalogo.Models;
using SIGDA.SRHN.Libreria.Nomina.Catalogo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Nomina.Catalogo.Services
{
    public class ParametrosService : IParametrosService, IDisposable
    {
        private readonly IParametrosService _metodos;
        public ParametrosService(IParametrosService metodos)
        {
            _metodos = metodos;
        }
        public bool AltaParametros(ParametrosBase parametros)
        {
            return _metodos.AltaParametros(parametros);
        }

        public void Dispose()
        {
            try { }
            catch (Exception) { }
        }

        public ParametrosBase ObtenerParametrosVigentes()
        {
            return _metodos.ObtenerParametrosVigentes();
        }
    }
}
