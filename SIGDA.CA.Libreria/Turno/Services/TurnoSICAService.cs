using SIGDA.CA.Libreria.Turno.Models;
using SIGDA.CA.Libreria.Turno.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.CA.Libreria.Turno.Services
{
    public class TurnoSICAService : ITurnoSICAService
    {
        private readonly ITurnoSICAService _metodos;
        public TurnoSICAService(ITurnoSICAService metodos) {
            _metodos = metodos;
        }

        public List<ConfigTurnoSICA> ConsultarConfiguracionTurnadoEmpleado()
        {
            return _metodos.ConsultarConfiguracionTurnadoEmpleado();
        }

        public bool InsertarConfiguracionTurnadoEmpleado(List<ConfigTurnoSICA> configTurnos)
        {
            return _metodos.InsertarConfiguracionTurnadoEmpleado(configTurnos);
        }
        public bool ActualizarTurnosFijos()
        {
            return _metodos.ActualizarTurnosFijos();
        }
        public bool ActualizarTurnosVariables()
        {
            return _metodos.ActualizarTurnosVariables();
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
