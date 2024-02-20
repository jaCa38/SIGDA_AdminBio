using SIGDA.SRHN.Libreria.Catalogos.Genericos.Enums;
using SIGDA.SRHN.Libreria.Catalogos.SubCentrosTrabajo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Catalogos.SubCentrosTrabajo.Services.Interfaces
{
    public interface ISubCentroTrabajoService : IDisposable
    {
        List<SubCentroTrabajoBase> ConsultarCatalogoGenerico();
        List<SubCentroTrabajoBase> ConsultarCatalogoGenerico(EDivision division, EInstancia instancia, long IdSistema, long IdMunicipio, long IdCentroTrabajo);

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
