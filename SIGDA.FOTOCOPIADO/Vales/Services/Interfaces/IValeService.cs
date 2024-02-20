using SIGDA.FOTOCOPIADO.Libreria.Vales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Vales.Services.Interfaces
{
    public interface IValeService : IDisposable
    {
        List<ValeBase> Consultar();
        ValeDetalle Consultar(long Id);
        bool Insertar(Vale vale, long IdMinerva);
        bool Actualizar(Vale vale, long IdMinerva);
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
