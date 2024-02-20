using SIGDA.FOTOCOPIADO.Libreria.Depositos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Depositos.Services.Interfaces
{
    public interface IDepositoService:IDisposable
    {
        List<DepositoBase> Consultar();
        DepositoDetalle Consultar(long Id);
        bool Insertar(Deposito deposito, long IdMinerva);
        bool Actualizar(Deposito deposito, long IdMinerva);
        bool Desactivar(long Id, long IdMinerva);

        #region IDisposable Members
        public void Dispose()
        {
            try
            {
                //sqlCon.Dispose();
                //sqlCon = null;
                //_Parametros.Clear();
                //media.Close();
                //media = null;
            }
            catch { }
        }
        #endregion

    }
}
