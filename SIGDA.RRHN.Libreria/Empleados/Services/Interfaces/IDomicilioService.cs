using SIGDA.SRHN.Libreria.Empleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Empleados.Services.Interfaces
{
    public interface IDomicilioService : IDisposable
    {
        IEnumerable<DomicilioBase> ObtenerColoniasPorCP(int codPostal);
        bool AlmacenaDomicilio(DomicilioBase domicilio);
        IEnumerable<DomicilioBase> ObtenerDomicilios(DomicilioBase domicilio);
        
    }
}
