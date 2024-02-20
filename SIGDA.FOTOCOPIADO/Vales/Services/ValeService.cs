using SIGDA.FOTOCOPIADO.Libreria.Vales.Models;
using SIGDA.FOTOCOPIADO.Libreria.Vales.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Vales.Services
{
    public class ValeService : IValeService
    {
        private readonly IValeService _valeService;
        public ValeService(IValeService valeService)
        {
            _valeService = valeService;
        }

        public bool Actualizar(Vale vale, long IdMinerva)
        {
            return _valeService.Actualizar(vale, IdMinerva);
        }

        public List<ValeBase> Consultar()
        {
            return _valeService.Consultar();
        }

        public ValeDetalle Consultar(long Id)
        {
            return _valeService.Consultar(Id);
        }

        public bool Desactivar(long Id, long IdMinerva)
        {
            return _valeService.Desactivar(Id, IdMinerva);
        }

        public void Dispose()
        {
            try { }
            catch { }
        }

        public bool Insertar(Vale vale, long IdMinerva)
        {
            return _valeService.Insertar(vale, IdMinerva);
        }
    }
}
