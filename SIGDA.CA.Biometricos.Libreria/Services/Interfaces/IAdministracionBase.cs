using SIGDA.CA.Biometricos.Libreria.Models;
using System;
using System.Collections.Generic;

namespace SIGDA.CA.Biometricos.Libreria.Services.Interfaces
{
    public interface IAdministracionBase : IDisposable
    {
        InfoBiometrico ObtenerInfoTerminal(int IdTerminal);
        List<RegistrosRelojes> ObtenerRegistrosTerminal(string IpTerminal, int PuertoTerminal, DateTime Fecha);
        List<RegistrosRelojes> ObtenerEmpleadoRegistrosTerminal(string IpTerminal, int PuertoTerminal, int IdEmpleado, DateTime Fecha);


    }
}
