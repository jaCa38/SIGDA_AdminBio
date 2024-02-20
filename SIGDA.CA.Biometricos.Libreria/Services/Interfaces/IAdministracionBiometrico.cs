using SIGDA.CA.Biometricos.Libreria.Models;
using System;
using System.Collections.Generic;

namespace SIGDA.CA.Biometricos.Libreria.Services
{
    public interface IAdministracionBiometrico : IDisposable
    {

        List<InfoBiometrico> ObtenerTodasLasTerminales();

        ConfiguracionBiometrico ObtenerConfigTerminal(string ipTerminal, int puertoTerminal);

        BaseResultado FijarFechaHoraTerminal(string ipTerminal, int puertoTerminal);

        string ExtraerFechaHoraTerminal(string ipTerminal, int puertoTerminal);

        bool ReiniciarTerminal(string ipTerminal, int puertoTerminal);









    }
}
