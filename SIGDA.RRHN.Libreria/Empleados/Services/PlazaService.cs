using SIGDA.SRHN.Libreria.Empleados.Models;
using SIGDA.SRHN.Libreria.Empleados.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Empleados.Services
{
    public class PlazaService : IPlazaService
    {
        private readonly IPlazaService _metodos;
        public PlazaService(IPlazaService metodos)
        {
            _metodos = metodos;
        }

        public bool AlmacenaPlaza(PlazaBase plaza)
        {
            return _metodos.AlmacenaPlaza(plaza);
        }

        public void Dispose()
        {
            try { }
            catch (Exception) { }
        }

        //public PlazaBase ObtenerPlaza(PlazaBase plaza)
        //{
        //    return _metodos.ObtenerPlaza(plaza);
        //}

        public IEnumerable<PlazaBase> ObtenerPlazasByCT(PlazaBase ct)
        {
            return _metodos.ObtenerPlazasByCT(ct);
        }
    }
}
