using SIGDA.SRHN.Libreria.ASF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.ASF.Services.Interfaces
{
    public interface IDesafectacionService : IDisposable
    {
        List<EmpleadoDesafectacionBase> BuscarCoincidenciaEmpleado(EmpleadoDesafectacionBase empleado);
        bool AlmacenaInformacion(EmpleadoDesafectacionBase encabezado, List<DetalleDesafectacion> detalle);
        List<EmpleadoDesafectacionBase> Obtener(int anio);
        EmpleadoDesafectacionBase ObtenerUno(long IdGeneral, int anio);


    }
}
