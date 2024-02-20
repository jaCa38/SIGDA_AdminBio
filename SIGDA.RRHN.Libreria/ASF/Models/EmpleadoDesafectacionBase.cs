using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.ASF.Models
{
    public class EmpleadoDesafectacionBase
    {
        public EmpleadoDesafectacionBase()
        {
            ListaDetalle = new List<DetalleDesafectacion>();
        }
        public long IdGeneral { set; get; }
        public int IdEmpleado { set; get; }
        public string NombreCompleto { set; get; }
        public string Nombre { set; get; }
        public string Paterno { set; get; }
        public string Materno { set; get; }
        public string Puesto { set; get; }
        public string Serie { set; get; }
        public int MesPago { set; get; }
        public int EsHonorarios { set; get; }
        public int IdQuincena { set; get; }
        public int AnioQuincena { set; get; }
        public string Funcion { set; get; }
        public string Nivel { set; get; }
        public string Antiguedad { set; get; }
        public List<DetalleDesafectacion> ListaDetalle { set; get; }
    }
}
