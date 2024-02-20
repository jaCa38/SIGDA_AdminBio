using SIGDA.SRHN.Libreria.Empleados.Models;
using SIGDA.SRHN.Libreria.Empleados.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Empleados.Services
{
    public class DomicilioService : IDomicilioService
    {
        private readonly IDomicilioService _metodos;
        public DomicilioService(IDomicilioService metodos)
        {
            _metodos = metodos;
        }
        public bool AlmacenaDomicilio(DomicilioBase domicilio)
        {
            return _metodos.AlmacenaDomicilio(domicilio);
        }

        public void Dispose()
        {
            try
            {
                //sqlCon.Dispose();
                //sqlCon = null;
                //_Parametros.Clear();
                //media.Close();
                //media = null;
            }
            catch { }
        }

        public IEnumerable<DomicilioBase> ObtenerColoniasPorCP(int codPostal)
        {
            return _metodos.ObtenerColoniasPorCP(codPostal);
        }

        public IEnumerable<DomicilioBase> ObtenerDomicilios(DomicilioBase domicilio)
        {
            return _metodos.ObtenerDomicilios(domicilio);
        }
    }
}
