using SIGDA.SRHN.Libreria.Deudo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Deudo.Services.Interfaces
{
    public interface IRegistroService : IDisposable
    {
        List<RegistroBase> ConsultarRegistros();
        List<RegistroBase> ConsultarRegistrosFiltro(long idEmpleado);
        bool AlmacenaRegistro(RegistroBase registro);
        bool EliminaRegistro(long idRegistro);
        bool ModificaRegistro(RegistroBase registro);
        bool SaldarRegistro(RegistroBase registro);
        bool ModificaAdeudoPendiente(RegistroBase registro);
    }
}
