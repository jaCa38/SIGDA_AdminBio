using SIGDA.SRHN.Libreria.Empleados.Models;
using SIGDA.SRHN.Libreria.Empleados.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Empleados.Services
{
    public class CorreoElectronicoService : ICorreoElectronicoService
    {
        private readonly ICorreoElectronicoService _metodos;
        public CorreoElectronicoService(ICorreoElectronicoService metodos)
        {
            _metodos = metodos;
        }
        public bool ActualizarCorreoElectronico(CorreoElectronicoBase mail)
        {
            return _metodos.ActualizarCorreoElectronico(mail);
        }

        public bool AlmacenaCorreoElectronico(CorreoElectronicoBase mail)
        {
            return _metodos.AlmacenaCorreoElectronico(mail);
        }

        public void Dispose()
        {
            try { } catch (Exception) { }
        }

        public bool EliminarCorreoElectronico(CorreoElectronicoBase mail)
        {
            return _metodos.EliminarCorreoElectronico(mail);
        }

        public CorreoElectronicoBase ObtenerCorreoElectronico(CorreoElectronicoBase mail)
        {
            return _metodos.ObtenerCorreoElectronico(mail);
        }

        public IEnumerable<CorreoElectronicoBase> ObtenerCorreosElectronicos(CorreoElectronicoBase mail)
        {
            return _metodos.ObtenerCorreosElectronicos(mail);
        }
    }
}
