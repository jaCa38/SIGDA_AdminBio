using SIGDA.SRHN.Libreria.Empleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Empleados.Services.Interfaces
{
    public interface IEmpleadoHonorariosService: IDisposable
    {
        long InsertarNuevoEmpleado(EmpleadoHonorarios empleadoHonorarios);

        #region IDisposable Members
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
        #endregion
    }
}
