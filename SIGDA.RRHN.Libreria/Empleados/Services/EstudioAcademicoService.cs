using SIGDA.SRHN.Libreria.Empleados.Models;
using SIGDA.SRHN.Libreria.Empleados.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Empleados.Services
{
    public class EstudioAcademicoService: IEstudioAcademicoService
    {
        private readonly IEstudioAcademicoService _metodos;
        public EstudioAcademicoService(IEstudioAcademicoService metodos)
        {
            _metodos = metodos;
        }
        public bool AlmacenaEstudio(EstudioAcademicoBase estudio)
        {
            return _metodos.AlmacenaEstudio(estudio);
        }

        public void Dispose()
        {
            try { } catch (Exception) { }
        }

        public bool EliminaEstudio(EstudioAcademicoBase estudio)
        {
            return _metodos.EliminaEstudio(estudio);
        }

        public EstudioAcademicoBase MaximoEstudioAcademico(long idEmpleado)
        {
            return _metodos.MaximoEstudioAcademico(idEmpleado);
        }

        public bool ModificaEstudio(EstudioAcademicoBase estudio)
        {
            return _metodos.ModificaEstudio(estudio);
        }

        public EstudioAcademicoBase ObtenerEstudio(long idEstudio, long idEmpleado)
        {
            return _metodos.ObtenerEstudio(idEstudio, idEmpleado);
        }

        public List<EstudioAcademicoBase> ObtenerEstudios(long idEmpleado)
        {
            return _metodos.ObtenerEstudios(idEmpleado);
        }
    }
}
