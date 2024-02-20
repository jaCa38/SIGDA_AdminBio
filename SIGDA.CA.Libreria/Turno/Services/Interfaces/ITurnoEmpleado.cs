using SIGDA.CA.Libreria.Turno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.CA.Libreria.Turno.Services.Interfaces
{
    public interface ITurnoEmpleado:IDisposable
    {
        #region Turnos fijos
        TurnoEmpleadoFijo ConsultarTurnoEmpleadoFijo(long IdEmpleado);
        long InsertarTurnoEmpleadoFijo(TurnoEmpleadoFijo Fijo);
        Boolean EliminarTurnoEmpleadoFijo(long IdEmpleado);
        List<TurnoEmpleadoFijo> ConsultarHistoricoTurnoEmpleadoFijo(long IdEmpleado);
        #endregion

        #region Turnos variables
        TurnoEmpleadoVariableDetalle ConsultarTurnoEmpleadoVariable(long IdEmpleado);
        long InsertarTurnoEmpleadoVariable(TurnoEmpleadoVariable Variable);
        Boolean EliminarTurnoEmpleadoVariable(long IdEmpleado);
        List<TurnoEmpleadoVariableDetalle> ConsultarHistoricoTurnoEmpleadoVariable(long IdEmpleado);
        #endregion



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
