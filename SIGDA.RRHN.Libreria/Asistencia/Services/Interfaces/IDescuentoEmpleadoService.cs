using SIGDA.SRHN.Libreria.Asistencia.Enums;
using SIGDA.SRHN.Libreria.Asistencia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Asistencia.Services.Interfaces
{
    public interface IDescuentoEmpleadoService : IDisposable
    {
        List<DescuentoEmpleadoBase> ObtenerListado(DescuentoEmpleadoBase descuentoEmpleado);
        bool AlmacenarDescuentoEmpleado(DescuentoEmpleadoBase descuentoEmpleado);
        bool ModificaDescuentoEmpleado(DescuentoEmpleadoBase descuentoEmpleado);
    }
}
