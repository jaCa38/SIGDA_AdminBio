
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.CentrosTrabajo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Catalogos.CentrosTrabajo.Services.Interfaces
{
    public interface ICentroTrabajoService : IDisposable
    {
        List<CentroTrabajoSAPBase> Consultar();

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
