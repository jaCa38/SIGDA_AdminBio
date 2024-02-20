using SIGDA.Consejo.Libreria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Consejo.Libreria.Services.Interfaces
{
    public interface IGestionConsejoService : IDisposable
    {
        //Proceso 1: Se busca por folio del consejo [Id Promoción
        List<SolicitudBase> ConsultarSolicitudes(long FolioConsejo);
        DetallePrecalificacion ConsultarDetallePrecalificacion(long FolioConsejo);

        DetalleFolioConsejo ConsultarDetalleFolioConsejo(long FolioConsejo);

        List<DetallePersonajes> ConsultarDetallePersonajes(long FolioConsejo);

        Boolean ContestarConsejoNuevoEmpleado(ContestacionFolioConsejo contestacionFolioConsejo);

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
