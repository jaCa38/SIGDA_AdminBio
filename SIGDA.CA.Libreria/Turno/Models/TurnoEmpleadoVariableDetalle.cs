﻿using SIGDA.CA.Libreria.Turno.Enums;
using SIGDA.CA.Libreria.Turno.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.CA.Libreria.Turno.Models
{
    public class TurnoEmpleadoVariableDetalle : ITurnoEmpleadoBase
    {
        public long IdEmpleado { get; set; }
        public ETipoTurnoEmpleado TipoTurno { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Domingo { get; set; }
        public string Lunes { get; set; }
        public string Martes { get; set; }
        public string Miercoles { get; set; }
        public string Jueves { get; set; }
        public string Viernes { get; set; }
        public string Sabado { get; set; }
    }
}
