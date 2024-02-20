using SIGDA.SRHN.Libreria.Empleados.Interfaces;
using SIGDA.SRHN.Libreria.Empleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Empleados.Services.Interfaces
{
    public interface IPlazaService : IDisposable
    {
        IEnumerable<PlazaBase> ObtenerPlazasByCT(PlazaBase ct);
        bool AlmacenaPlaza(PlazaBase plaza);
        //PlazaBase ObtenerPlaza(PlazaBase plaza);

    }
}
