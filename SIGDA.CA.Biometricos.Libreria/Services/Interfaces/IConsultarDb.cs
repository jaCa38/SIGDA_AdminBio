using SIGDA.CA.Biometricos.Libreria.Models;
using System;
using System.Collections.Generic;

namespace SIGDA.CA.Biometricos.Libreria.Services.Interfaces
{
    public interface IConsultarDb : IDisposable
    {
        List<InfoBiometrico> ObtenerTodasLasTerminales();
        List<ListaBiometriasEmpleado> ObtenerBiometriasEmpleadoDb(int IdEmpleado, string fw);

        List<TerminalesConBiometriaEmpleado> ObtenerListaBiometriasDb(int IdEmpleado, int idTerminal);
        List<BiometriaTerminal> ObtenerBiometriaTerminalDb(int IdEmpleado, int idTerminal);

    }
}
