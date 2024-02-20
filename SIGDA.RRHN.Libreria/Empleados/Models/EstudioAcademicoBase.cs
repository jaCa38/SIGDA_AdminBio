using SIGDA.Catalogos.Genericos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Empleados.Models
{
    public class EstudioAcademicoBase
    {
        public int IdEmpleado { set; get; }
        public int IdEstudio { set; get; }
        public int IdNivelAcademico { set; get; }
        public string DescripcionNivelAcademico { set; get; }
        public int MesGrado { set; get; }
        public int AnioGrado { set; get; }
        public string Institucion { set; get; }
        public string Titulo { set; get; }
        public int IdEstatusEstudio { set; get; }
        public int CedulaProfesional { set; get; }
        public int Horas { set; get; }
        public string Ubicacion { set; get; }
        public int IdMuncipio { set; get; }
    }
}
