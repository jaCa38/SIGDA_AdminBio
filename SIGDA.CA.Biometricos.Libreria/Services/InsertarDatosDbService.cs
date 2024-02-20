using SIGDA.CA.Biometricos.Libreria.Services.Interfaces;
using System;

namespace SIGDA.CA.Biometricos.Libreria.Services
{
    public class InsertarDatosDbService : IInsertarDatosDb
    {

        private readonly IInsertarDatosDb _metodos;
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public InsertarDatosDbService(IInsertarDatosDb metodos)
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


        public bool InsertarLogDescargaFotosMSSQL(int idTerminal, DateTime fechaDescarga, int cantidadFotos, int CantidadRegistros)
        {
            return _metodos.InsertarLogDescargaFotosMSSQL(idTerminal, fechaDescarga, cantidadFotos, CantidadRegistros);
        }

        public bool InsertarBiometriaDBMSSQL(int idEmpleado, int idTerminal, string bioPlantilla)
        {
            return _metodos.InsertarBiometriaDBMSSQL(idEmpleado, idTerminal, bioPlantilla);
        }



    }
}
