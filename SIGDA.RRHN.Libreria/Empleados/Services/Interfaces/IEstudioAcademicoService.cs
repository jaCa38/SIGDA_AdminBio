using SIGDA.SRHN.Libreria.Empleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Empleados.Services.Interfaces
{
    public interface IEstudioAcademicoService: IDisposable
    {
        List<EstudioAcademicoBase> ObtenerEstudios(long idEmpleado);
        EstudioAcademicoBase ObtenerEstudio(long idEstudio, long idEmpleado);
        bool AlmacenaEstudio(EstudioAcademicoBase estudio);
        bool ModificaEstudio(EstudioAcademicoBase estudio);
        bool EliminaEstudio(EstudioAcademicoBase estudio);
        EstudioAcademicoBase MaximoEstudioAcademico(long idEmpleado);
    }
}
