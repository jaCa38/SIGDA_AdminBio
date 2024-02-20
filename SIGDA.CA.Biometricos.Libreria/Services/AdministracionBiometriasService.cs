using SIGDA.CA.Biometricos.Libreria.Models;
using SIGDA.CA.Biometricos.Libreria.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace SIGDA.CA.Biometricos.Libreria.Services
{
    public class AdministracionBiometriasService : IAdministracionBiometrias
    {
        private readonly IAdministracionBiometrias _metodos;
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public AdministracionBiometriasService(IAdministracionBiometrias metodos)
        {
            _metodos = metodos;
        }


        public BaseResultado EliminarEmpleadoBiometrico(int IdEmpleado, string IpTerminal, int PuertoConexion)
        {
            return _metodos.EliminarEmpleadoBiometrico(IdEmpleado, IpTerminal, PuertoConexion);
        }


        public BaseResultado VerificaBiometria(int IdEmpleado, string IpTerminal, int PuertoConexion)
        {
            return _metodos.VerificaBiometria(IdEmpleado, IpTerminal, PuertoConexion);
        }

        public BiometriaEmpleado ObtenerBiometriaEmpleado(int idEmpleado, string ipTerminal, int puertoConexion, long numSerie)
        {
            return _metodos.ObtenerBiometriaEmpleado(idEmpleado, ipTerminal, puertoConexion, numSerie);
        }


        public bool EnviarBiometriaBio(string ipTerminal, int puertoConexion, byte[] bioTemplate)
        {
            return _metodos.EnviarBiometriaBio(ipTerminal, puertoConexion, bioTemplate);
        }

        public List<int> ObtenerEmpleadosTerminalBiometrica(string ipTerminal, int puertoConexion)
        {
            return _metodos.ObtenerEmpleadosTerminalBiometrica(ipTerminal, puertoConexion);
        }


        //public bool EnviarBiometriaBioPorIdTerminal(int idEmpleado, int IdTerminal)
        //{
        //    return _metodos.EnviarBiometriaBioPorIdTerminal( idEmpleado,  IdTerminal);
        //}



    }
}
