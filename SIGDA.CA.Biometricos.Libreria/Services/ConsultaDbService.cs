using SIGDA.CA.Biometricos.Libreria.Models;
using System;
using System.Collections.Generic;

namespace SIGDA.CA.Biometricos.Libreria.Services.Interfaces
{
    public class ConsultaDbService : IConsultarDb
    {

        private readonly IConsultarDb _metodos;


        public ConsultaDbService(IConsultarDb metodos)
        {
            _metodos = metodos;
        }

        public List<InfoBiometrico> ObtenerTodasLasTerminales()
        {
            return _metodos.ObtenerTodasLasTerminales();
        }



        public List<ListaBiometriasEmpleado> ObtenerBiometriasEmpleadoDb(int IdEmpleado, string fw)
        {
            return _metodos.ObtenerBiometriasEmpleadoDb(IdEmpleado, fw);
        }


        public List<TerminalesConBiometriaEmpleado> ObtenerListaBiometriasDb(int IdEmpleado, int idTerminal)
        {
            return _metodos.ObtenerListaBiometriasDb(IdEmpleado, idTerminal);
        }


        public List<BiometriaTerminal> ObtenerBiometriaTerminalDb(int IdEmpleado, int idTerminal)
        {
            return _metodos.ObtenerBiometriaTerminalDb(IdEmpleado, idTerminal);
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
