using SIGDA.CA.Biometricos.Libreria.Models;
using System;
using System.Collections.Generic;

namespace SIGDA.CA.Biometricos.Libreria.Services
{
    public class AdministracionBiometricoService : IAdministracionBiometrico

    {
        private readonly IAdministracionBiometrico _metodos;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public AdministracionBiometricoService(IAdministracionBiometrico metodos)
        {
            _metodos = metodos;
        }



        public List<InfoBiometrico> ObtenerTodasLasTerminales()
        {
            return _metodos.ObtenerTodasLasTerminales();
        }


        public ConfiguracionBiometrico ObtenerConfigTerminal(string ipTerminal, int puertoTerminal)
        {
            return _metodos.ObtenerConfigTerminal(ipTerminal, puertoTerminal);
        }


        public BaseResultado FijarFechaHoraTerminal(string ipTerminal, int puertoTerminal)
        {
            return _metodos.FijarFechaHoraTerminal(ipTerminal, puertoTerminal);
        }


        public string ExtraerFechaHoraTerminal(string ipTerminal, int puertoTerminal)
        {
            return _metodos.ExtraerFechaHoraTerminal(ipTerminal, puertoTerminal);
        }


        public bool ReiniciarTerminal(string ipTerminal, int puertoTerminal)
        {
            return _metodos.ReiniciarTerminal(ipTerminal, puertoTerminal);
        }


    }
}
