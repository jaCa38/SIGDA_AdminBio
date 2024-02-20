using SIGDA.CA.Libreria.Turno.Models;
using SIGDA.CA.Libreria.Turno.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.CA.Libreria.Turno.Services
{
    public class TurnoService: ITipoTurnoService, IConfigTurnoService, ITurnoEmpleado
    {
        private readonly ITipoTurnoService _metodos;
        private readonly IConfigTurnoService _metodosConfigTurnos;
        private readonly ITurnoEmpleado _metodosEmpleadoTurno;

        public TurnoService(ITipoTurnoService metodos) => _metodos = metodos;
        public TurnoService(IConfigTurnoService metodos) => _metodosConfigTurnos = metodos;
        public TurnoService(ITurnoEmpleado metodos) => _metodosEmpleadoTurno = metodos;

        #region CATALOGOS.TURNOS
        public List<TipoTurnoBase> ConsultarCatalogoTiposTurno()
        {
            return _metodos.ConsultarCatalogoTiposTurno();
        }
        #endregion

        #region CONFIGURACION.TURNO
        public List<ConfigTurno> ConsultarConfiguracionTurnos()
        {
            return _metodosConfigTurnos.ConsultarConfiguracionTurnos();
        }
        public long InsertarConfiguracionTurnos(ConfigTurnoBase configTurnoBase)
        {
            return _metodosConfigTurnos.InsertarConfiguracionTurnos(configTurnoBase);
        }
        #endregion

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

        #region Turno Empleado Fijo
        public TurnoEmpleadoFijo ConsultarTurnoEmpleadoFijo(long IdEmpleado)
        {
            return _metodosEmpleadoTurno.ConsultarTurnoEmpleadoFijo(IdEmpleado);
        }

        public long InsertarTurnoEmpleadoFijo(TurnoEmpleadoFijo Fijo)
        {
            return _metodosEmpleadoTurno.InsertarTurnoEmpleadoFijo(Fijo);
        }

        public bool EliminarTurnoEmpleadoFijo(long IdEmpleado)
        {
            return _metodosEmpleadoTurno.EliminarTurnoEmpleadoFijo(IdEmpleado);
        }

        public List<TurnoEmpleadoFijo> ConsultarHistoricoTurnoEmpleadoFijo(long IdEmpleado)
        {
            return _metodosEmpleadoTurno.ConsultarHistoricoTurnoEmpleadoFijo(IdEmpleado);
        }

        #endregion
        #region Turno Empleado Variable
        public TurnoEmpleadoVariableDetalle ConsultarTurnoEmpleadoVariable(long IdEmpleado)
        {
            return _metodosEmpleadoTurno.ConsultarTurnoEmpleadoVariable(IdEmpleado);
        }

        public long InsertarTurnoEmpleadoVariable(TurnoEmpleadoVariable Variable)
        {
            return _metodosEmpleadoTurno.InsertarTurnoEmpleadoVariable(Variable);
        }

        public bool EliminarTurnoEmpleadoVariable(long IdEmpleado)
        {
            return _metodosEmpleadoTurno.EliminarTurnoEmpleadoVariable(IdEmpleado);
        }

        public List<TurnoEmpleadoVariableDetalle> ConsultarHistoricoTurnoEmpleadoVariable(long IdEmpleado)
        {
            return _metodosEmpleadoTurno.ConsultarHistoricoTurnoEmpleadoVariable(IdEmpleado);
        }
        #endregion
    }
}
