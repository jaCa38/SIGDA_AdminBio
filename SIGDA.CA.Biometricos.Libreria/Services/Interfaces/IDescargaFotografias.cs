using SIGDA.CA.Biometricos.Libreria.Models;
using System;
using System.Collections.Generic;

namespace SIGDA.CA.Biometricos.Libreria.Services.Interfaces
{
    public interface IDescargaFotografias : IDisposable
    {
        List<Foto> ObtenerFotosEmpleado(int EmpleadoId, int TerminalId, DateTime FechaFotos);

        List<FotoSorry> ObtenerFotosFailed(DateTime Fecha, string ipTerminal, int portTerminal);

        FotosResualtado DescargarFotosOkBiometrico(DateTime fechaFotos, string ipTerminal, int portTerminal, string nombreTerminal);

        bool InsertarLogDescargaFotosMSSQL(int idTerminal, DateTime fechaDescarga, int cantidadFotos, int CantidadRegistros);

        List<Foto> ObtenerFotosOkTerminal(DateTime fechaFotos, string ipTerminal, int portTerminal);

        FotosResualtado DescargarFotosSorryBiometrico(DateTime fechaFotos, string ipTerminal, int portTerminal, string nombreTerminal);
    }
}
