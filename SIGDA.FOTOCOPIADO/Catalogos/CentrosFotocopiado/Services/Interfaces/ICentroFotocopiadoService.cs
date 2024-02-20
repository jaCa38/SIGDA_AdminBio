using SIGDA.FOTOCOPIADO.Libreria.Catalogos.CentrosFotocopiado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Catalogos.CentrosFotocopiado.Services.Interfaces
{
    public interface ICentroFotocopiadoService : IDisposable
    {
        List<CentroFotocopiadoDetalle> Consultar();
        CentroFotocopiadoDetalle Consultar(long Id);
        bool Insertar(CentroFotocopiadoBase centroFotocopiadoBase);
        bool Actualizar(CentroFotocopiadoBase centroFotocopiadoBase);
        bool Desactivar(long Id);

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
