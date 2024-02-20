using SIGDA.CA.Biometricos.Libreria.Models;
using System;
using System.Collections.Generic;

namespace SIGDA.CA.Biometricos.Libreria.Services
{

    public class DescargaInfoBiometricosService : IDescargaInfoBiometricos
    {
        private readonly IDescargaInfoBiometricos _metodos;
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public DescargaInfoBiometricosService(IDescargaInfoBiometricos metodos)
        {
            _metodos = metodos;
        }

        public bool InsertarRegistrosSICA(int idTerminal, int IdEmpleado, DateTime record)
        {
            return _metodos.InsertarRegistrosSICA(idTerminal, IdEmpleado, record);
        }
        public bool InsertarRegistrosMSSQL(int idTerminal, int IdEmpleado, DateTime record)
        {
            return _metodos.InsertarRegistrosMSSQL(idTerminal, IdEmpleado, record);
        }

        public bool InsertarLogErrorDescargaMSSQL(int IdTerminal, int tipoEvento, DateTime FechaDescarga, string MsjError)
        {
            return _metodos.InsertarLogErrorDescargaMSSQL(IdTerminal, tipoEvento, FechaDescarga, MsjError);
        }

        public bool InsertarLogDescargaRegistrosMSSQL(int IdTerminal, DateTime FechaDescarga, int CantidadRegistros)
        {
            return _metodos.InsertarLogDescargaRegistrosMSSQL(IdTerminal, FechaDescarga, CantidadRegistros);

        }





        public List<RegistrosRelojes> ObtenerRegistrosTerminalPorRangoFechas(string ipTerminal, int puertoTerminal, DateTime fechaInicio, DateTime fechaFin)
        {
            return _metodos.ObtenerRegistrosTerminalPorRangoFechas(ipTerminal, puertoTerminal, fechaInicio, fechaFin);
        }





    }
}
