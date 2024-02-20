using SIGDA.SRHN.Libreria.Empleados.Models;
using SIGDA.SRHN.Libreria.Empleados.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Empleados.Services
{
    public class EmpleadoHonorariosService : IEmpleadoHonorariosService
    {
        private readonly IEmpleadoHonorariosService _metodos;
        public EmpleadoHonorariosService(IEmpleadoHonorariosService metodos)
        {
            _metodos = metodos;
        }

        public long InsertarNuevoEmpleado(EmpleadoHonorarios empleadoHonorarios)
        {
            return _metodos.InsertarNuevoEmpleado(empleadoHonorarios);
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
    }
}
