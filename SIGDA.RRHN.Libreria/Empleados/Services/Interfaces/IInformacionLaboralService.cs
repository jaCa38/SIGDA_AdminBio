using SIGDA.SRHN.Libreria.Empleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Empleados.Services.Interfaces
{
    public interface IInformacionLaboralService : IDisposable
    {
        List<InformacionLaboralBase> ObtenerInformacionLaboral(long idEmpleado);
        InformacionLaboralBase ObtenerLaboral(InformacionLaboralBase info);
        InformacionLaboralBase ObtenerLaboralUnaLinea(long idEmpleado);
        bool AlmacenaLaboral(InformacionLaboralBase info);
        bool ModificaLaboral(InformacionLaboralBase info);
        bool EliminaLaboral(InformacionLaboralBase info);
    }
}
