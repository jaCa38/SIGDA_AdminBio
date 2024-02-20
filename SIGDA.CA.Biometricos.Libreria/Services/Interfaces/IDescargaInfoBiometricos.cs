using SIGDA.CA.Biometricos.Libreria.Models;
using System;
using System.Collections.Generic;

namespace SIGDA.CA.Biometricos.Libreria.Services
{
    public interface IDescargaInfoBiometricos : IDisposable
    {

        bool InsertarRegistrosSICA(int idTerminal, int IdEmpleado, DateTime record);
        bool InsertarRegistrosMSSQL(int idTerminal, int IdEmpleado, DateTime record);
        bool InsertarLogErrorDescargaMSSQL(int IdTerminal, int tipoEvento, DateTime FechaDescarga, string MsjError);

        bool InsertarLogDescargaRegistrosMSSQL(int IdTerminal, DateTime FechaDescarga, int CantidadRegistros);

        List<RegistrosRelojes> ObtenerRegistrosTerminalPorRangoFechas(string ipTerminal, int puertoTerminal, DateTime fechaInicio, DateTime fechaFin);


    }
}
