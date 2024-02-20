using SIGDA.FOTOCOPIADO.Libreria.Depositos.Models;
using SIGDA.FOTOCOPIADO.Libreria.Depositos.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Depositos.Services
{
    public class DepositoService : IDepositoService
    {
        private readonly IDepositoService _depositoService;
        public DepositoService(IDepositoService depositoService)
        {
            _depositoService = depositoService;
        }

        public bool Actualizar(Deposito deposito, long IdMinerva)
        {
            return _depositoService.Actualizar(deposito,IdMinerva);
        }

       
        public List<DepositoBase> Consultar()
        {
            return _depositoService.Consultar();
        }

        public DepositoDetalle Consultar(long Id)
        {
            return _depositoService.Consultar(Id);
        }

        public bool Desactivar(long Id, long IdMinerva)
        {
            return _depositoService.Desactivar(Id,IdMinerva);
        }

        public void Dispose()
        {
            try { } catch { }
        }

        public bool Insertar(Deposito deposito, long IdMinerva)
        {
            return _depositoService.Insertar(deposito, IdMinerva);
        }
    }
}
