using SIGDA.CA.Biometricos.Libreria.Models;
using SIGDA.CA.Biometricos.Libreria.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace SIGDA.CA.Biometricos.Libreria.Services
{
    public class DescargaFotografiasService : IDescargaFotografias
    {

        private readonly IDescargaFotografias _metodos;
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public DescargaFotografiasService(IDescargaFotografias metodos)
        {
            _metodos = metodos;
        }


        public List<Foto> ObtenerFotosEmpleado(int EmpleadoId, int TerminalId, DateTime FechaFotos)
        {
            return _metodos.ObtenerFotosEmpleado(EmpleadoId, TerminalId, FechaFotos);
        }

        public List<FotoSorry> ObtenerFotosFailed(DateTime Fecha, string ipTerminal, int portTerminal)
        {
            return _metodos.ObtenerFotosFailed(Fecha, ipTerminal, portTerminal);
        }

        public FotosResualtado DescargarFotosOkBiometrico(DateTime fechaFotos, string ipTerminal, int portTerminal, string nombreTerminal)
        {
            return _metodos.DescargarFotosOkBiometrico(fechaFotos, ipTerminal, portTerminal, nombreTerminal);
        }

        public FotosResualtado DescargarFotosSorryBiometrico(DateTime fechaFotos, string ipTerminal, int portTerminal, string nombreTerminal)
        {
            return _metodos.DescargarFotosSorryBiometrico(fechaFotos, ipTerminal, portTerminal, nombreTerminal);
        }

        public bool InsertarLogDescargaFotosMSSQL(int idTerminal, DateTime fechaDescarga, int cantidadFotos, int CantidadRegistros)
        {
            return _metodos.InsertarLogDescargaFotosMSSQL(idTerminal, fechaDescarga, cantidadFotos, CantidadRegistros);
        }


        public List<Foto> ObtenerFotosOkTerminal(DateTime fechaFotos, string ipTerminal, int portTerminal)
        {
            return _metodos.ObtenerFotosOkTerminal(fechaFotos, ipTerminal, portTerminal);
        }




    }
}
