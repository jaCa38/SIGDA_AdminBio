using SIGDA.SRHN.Libreria.Empleados.Models;
using SIGDA.SRHN.Libreria.Empleados.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Empleados.Services
{
    public class InformacionLaboralService : IInformacionLaboralService
    {
        private readonly IInformacionLaboralService _metodos;
        public InformacionLaboralService(IInformacionLaboralService metodos)
        {
            _metodos = metodos;
        }

        public bool AlmacenaLaboral(InformacionLaboralBase info)
        {
            return _metodos.AlmacenaLaboral(info);
        }

        public void Dispose()
        {
            try { } catch (Exception) { }
        }

        public bool EliminaLaboral(InformacionLaboralBase info)
        {
            return _metodos.EliminaLaboral(info);
        }

        public bool ModificaLaboral(InformacionLaboralBase info)
        {
            return _metodos.ModificaLaboral(info);
        }

        public List<InformacionLaboralBase> ObtenerInformacionLaboral(long idEmpleado)
        {
            return _metodos.ObtenerInformacionLaboral(idEmpleado);
        }

        public InformacionLaboralBase ObtenerLaboral(InformacionLaboralBase info)
        {
            return _metodos.ObtenerLaboral(info);
        }

        public InformacionLaboralBase ObtenerLaboralUnaLinea(long idEmpleado)
        {
            return _metodos.ObtenerLaboralUnaLinea(idEmpleado);
        }
    }
}
