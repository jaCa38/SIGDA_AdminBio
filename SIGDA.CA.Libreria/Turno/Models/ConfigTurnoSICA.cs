using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.CA.Libreria.Turno.Models
{
    public class ConfigTurnoSICA
    {
        public long IdentificadorSICA { get; set; }
        public long IdClaveEmpleado { get; set; }
        public long IdTurnoDia1 { get; set; }
        public long IdTurnoDia2 { get; set; }
        public long IdTurnoDia3 { get; set; }
        public long IdTurnoDia4 { get; set; }
        public long IdTurnoDia5 { get; set; }
        public long IdTurnoDia6 { get; set; }
        public long IdTurnoDia7 { get; set; }
        public long DescansoDia1 { get; set; }
        public long DescansoDia2 { get; set; }
        public long DescansoDia3 { get; set; }
        public long DescansoDia4 { get; set; }
        public long DescansoDia5 { get; set; }
        public long DescansoDia6 { get; set; }
        public long DescansoDia7 { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
