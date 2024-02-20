using System;

namespace SIGDA.CA.Biometricos.Libreria.Services.Interfaces
{
    public interface IInsertarDatosDb : IDisposable
    {
        bool InsertarRegistrosSICA(int idTerminal, int IdEmpleado, DateTime record);
        bool InsertarRegistrosMSSQL(int idTerminal, int IdEmpleado, DateTime record);
        bool InsertarLogErrorDescargaMSSQL(int IdTerminal, int tipoEvento, DateTime FechaDescarga, string MsjError);

        bool InsertarLogDescargaRegistrosMSSQL(int IdTerminal, DateTime FechaDescarga, int CantidadRegistros);

        bool InsertarLogDescargaFotosMSSQL(int idTerminal, DateTime fechaDescarga, int cantidadFotos, int CantidadRegistros);

        bool InsertarBiometriaDBMSSQL(int idEmpleado, int idTerminal, string bioPlantilla);
    }
}
