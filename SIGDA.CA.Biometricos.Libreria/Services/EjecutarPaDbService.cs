using SIGDA.CA.Biometricos.Libreria.Services.Interfaces;
using System;

namespace SIGDA.CA.Biometricos.Libreria.Services
{
    public class EjecutarPaDbService : IEjecutarPaDb, IDisposable
    {
        private readonly IEjecutarPaDb _metodos;


        public EjecutarPaDbService(IEjecutarPaDb metodos)
        {
            _metodos = metodos;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool EjecutarPaProcesarInfo()
        {
            return _metodos.EjecutarPaProcesarInfo();
        }

    }
}
