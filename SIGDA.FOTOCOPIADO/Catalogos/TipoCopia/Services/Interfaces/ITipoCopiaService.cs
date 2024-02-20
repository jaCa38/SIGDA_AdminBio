using SIGDA.FOTOCOPIADO.Libreria.Catalogos.TipoCopia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Catalogos.TipoCopia.Services.Interfaces
{
    public interface ITipoCopiaService : IDisposable
    {
        List<TipoCopiaBase> ConsultarTiposCopia();

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
