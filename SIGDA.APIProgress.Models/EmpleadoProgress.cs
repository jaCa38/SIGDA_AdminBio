using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.APIProgress.Models
{
    public class EmpleadoProgress
    {
        public int IdEmpleado { set; get; }
        public string Nombre { set; get; }
        public string ApellidoUno { set; get; }
        public string ApellidoDos { set; get; }
        public string Estatus { set; get; }
        public string Ingreso { set; get; }
        public string NombreEmpleado
        {
            get; set;
        }
        public string LlaveSeguimiento
        {
            get; set;
        }
        public string NombreOriginal { set; get; }
        public string ApellidoUnoOriginal { set; get; }
        public string ApellidoDosOriginal { set; get; }
        public string LlaveIncidencias
        {
            get; set;
        }
    }
}
