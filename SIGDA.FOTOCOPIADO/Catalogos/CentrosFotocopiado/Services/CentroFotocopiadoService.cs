using SIGDA.FOTOCOPIADO.Libreria.Catalogos.CentrosFotocopiado.Models;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.CentrosFotocopiado.Models;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.CentrosFotocopiado.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Catalogos.CentrosFotocopiado.Services
{
    public class CentroFotocopiadoService : ICentroFotocopiadoService
    {
        private readonly ICentroFotocopiadoService _metodos;

        public CentroFotocopiadoService(ICentroFotocopiadoService metodos)
        {
            _metodos = metodos;
        }

        public bool Actualizar(CentroFotocopiadoBase centroFotocopiadoBase)
        {
            return _metodos.Actualizar(centroFotocopiadoBase);
        }

        public List<CentroFotocopiadoDetalle> Consultar()
        {
            return _metodos.Consultar();
        }

        public CentroFotocopiadoDetalle Consultar(long Id)
        {
            throw new NotImplementedException();
        }

        public bool Desactivar(long Id)
        {
            return _metodos.Desactivar(Id);
        }

        public void Dispose()
        {
            try { } catch { }
        }

        public bool Insertar(CentroFotocopiadoBase centroFotocopiadoBase)
        {
            return _metodos.Insertar(centroFotocopiadoBase);
        }
    }
}
