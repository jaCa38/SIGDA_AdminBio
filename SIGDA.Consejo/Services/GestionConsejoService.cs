using SIGDA.Consejo.Libreria.Models;
using SIGDA.Consejo.Libreria.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Consejo.Libreria.Services
{
    public class GestionConsejoService : IGestionConsejoService
    {
        private readonly IGestionConsejoService _metodos;
        public GestionConsejoService(IGestionConsejoService metodos) => _metodos = metodos;

        public DetalleFolioConsejo ConsultarDetalleFolioConsejo(long FolioConsejo)
        {
            return _metodos.ConsultarDetalleFolioConsejo(FolioConsejo);
        }

        public List<DetallePersonajes> ConsultarDetallePersonajes(long FolioConsejo)
        {
            return _metodos.ConsultarDetallePersonajes(FolioConsejo);
        }

        public DetallePrecalificacion ConsultarDetallePrecalificacion(long FolioConsejo)
        {
            return _metodos.ConsultarDetallePrecalificacion(FolioConsejo);
        }

        public List<SolicitudBase> ConsultarSolicitudes(long FolioConsejo)
        {
            return _metodos.ConsultarSolicitudes(FolioConsejo);
        }

        public bool ContestarConsejoNuevoEmpleado(ContestacionFolioConsejo contestacionFolioConsejo)
        {
            return _metodos.ContestarConsejoNuevoEmpleado(contestacionFolioConsejo);
        }

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
    }
}
