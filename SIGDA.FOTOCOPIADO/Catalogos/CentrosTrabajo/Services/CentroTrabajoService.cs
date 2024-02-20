
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.CentrosTrabajo.Models;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.CentrosTrabajo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Catalogos.CentrosTrabajo.Services
{
    public class CentroTrabajoService : ICentroTrabajoService
    {
        private readonly ICentroTrabajoService _metodos;

        public CentroTrabajoService(ICentroTrabajoService metodos)
        {
            _metodos = metodos;
        }

        public List<CentroTrabajoSAPBase> Consultar()
        {
            return _metodos.Consultar();
        }

        public void Dispose()
        {
            try { } catch { }
        }
    }
}
