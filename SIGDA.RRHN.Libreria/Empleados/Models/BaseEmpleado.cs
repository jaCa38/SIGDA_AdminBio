using Dapper;
using SIGDA.Conexion;
using SIGDA.SRHN.Libreria.Empleados.Enums;
using SIGDA.SRHN.Libreria.Empleados.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Empleados.Models
{
    public class BaseEmpleado : IBaseEmpleado
    {
        public long IdEmpleado { get; set; }
        public long ClaveEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public string PaternoEmpleado { get; set; }
        public string MaternoEmpleado { get; set; }
        public DateTime FechaAltaEmpleado { get; set; }
        public ETipoEmpleado TipoEmpleado { get; set; }
        public string UltimaActualizacion { set; get; }
        
    }
}
