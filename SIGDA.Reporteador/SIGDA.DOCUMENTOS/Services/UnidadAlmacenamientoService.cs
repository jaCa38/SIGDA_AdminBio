using SIGDA.Documentos.Models;
using SIGDA.Documentos.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Documentos.Services
{
    public class UnidadAlmacenamientoService : IUnidadAlmacenamientoService
    {
        private readonly IUnidadAlmacenamientoService _unidadService;
        public UnidadAlmacenamientoService(IUnidadAlmacenamientoService unidadService)
        {
            _unidadService = unidadService;
        }

        public UnidadAlmacenamiento ConsultarUnidadActiva()
        {
            return _unidadService.ConsultarUnidadActiva();
        }

        public void Dispose()
        {
            try { }
            catch { }
        }
    }
}
