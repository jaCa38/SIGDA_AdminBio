using SIGDA.SRHN.Libreria.Empleados.Interfaces;
using SIGDA.SRHN.Libreria.Empleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Empleados.Services.Interfaces
{
    public interface ICorreoElectronicoService : IDisposable
    {
        bool AlmacenaCorreoElectronico(CorreoElectronicoBase mail);
        bool EliminarCorreoElectronico(CorreoElectronicoBase mail);
        bool ActualizarCorreoElectronico(CorreoElectronicoBase mail);
        IEnumerable<CorreoElectronicoBase> ObtenerCorreosElectronicos(CorreoElectronicoBase mail);
        CorreoElectronicoBase ObtenerCorreoElectronico(CorreoElectronicoBase mail);
    }
}
