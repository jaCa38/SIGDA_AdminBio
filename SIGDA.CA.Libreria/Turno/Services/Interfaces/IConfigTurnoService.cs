using SIGDA.CA.Libreria.Turno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.CA.Libreria.Turno.Services.Interfaces
{
    public interface IConfigTurnoService : IDisposable
    {
        List<ConfigTurno> ConsultarConfiguracionTurnos();
        long InsertarConfiguracionTurnos(ConfigTurnoBase configTurnoBase);

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
