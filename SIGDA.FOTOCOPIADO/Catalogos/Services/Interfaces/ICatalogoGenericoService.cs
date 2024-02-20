using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Catalogos.Services.Interfaces
{
    public interface ICatalogoGenericoService : IDisposable
    {
        bool DesactivarCatalogoGenerico(long Identificador);

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
