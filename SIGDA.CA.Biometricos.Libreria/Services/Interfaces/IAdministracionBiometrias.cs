using SIGDA.CA.Biometricos.Libreria.Models;
using System;
using System.Collections.Generic;

namespace SIGDA.CA.Biometricos.Libreria.Services.Interfaces
{
    public interface IAdministracionBiometrias : IDisposable
    {
        BaseResultado EliminarEmpleadoBiometrico(int IdEmpleado, string IpTerminal, int PuertoConexion);
        BaseResultado VerificaBiometria(int IdEmpleado, string IpTerminal, int PuertoConexion);

        BiometriaEmpleado ObtenerBiometriaEmpleado(int IdEmpleado, string IpTerminal, int PuertoConexion, long numSerie);

        bool EnviarBiometriaBio(string ipTerminal, int puertoConexion, byte[] bioTemplate);

        //bool EnviarBiometriaBioPorIdTerminal(int idEmpleado, int IdTerminal, string IpTerminal, string by);

        List<int> ObtenerEmpleadosTerminalBiometrica(string ipTerminal, int puertoConexion);



    }
}
