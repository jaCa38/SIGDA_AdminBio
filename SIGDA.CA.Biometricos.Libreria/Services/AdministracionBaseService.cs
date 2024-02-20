using SIGDA.CA.Biometricos.Libreria.Models;
using SIGDA.CA.Biometricos.Libreria.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace SIGDA.CA.Biometricos.Libreria.Services
{
    public class AdministracionBaseService : IAdministracionBase
    {
        private readonly IAdministracionBase _metodos;

        public AdministracionBaseService(IAdministracionBase metodos)
        {
            _metodos = metodos;

        }
        public InfoBiometrico ObtenerInfoTerminal(int IdTerminal)
        {
            return _metodos.ObtenerInfoTerminal(IdTerminal);
        }

        public List<RegistrosRelojes> ObtenerRegistrosTerminal(string IpTerminal, int PuertoTeminal, DateTime Fecha)
        {
            return _metodos.ObtenerRegistrosTerminal(IpTerminal, PuertoTeminal, Fecha);
        }



        public List<RegistrosRelojes> ObtenerEmpleadoRegistrosTerminal(string IpTerminal, int PuertoTeminal, int IdEmpleado, DateTime Fecha)
        {
            return _metodos.ObtenerEmpleadoRegistrosTerminal(IpTerminal, PuertoTeminal, IdEmpleado, Fecha);
        }




        public void Dispose()
        {
            try { } catch { }
        }
    }
}
