using System;

namespace SIGDA.CA.Biometricos.Libreria.Models
{
    public class RegistrosEmpleadoSICA
    {
        public int IdEmpleado { get; set; }
        public DateTime Fecha { get; set; }
        public string Entrada { get; set; }
        public string Salida { get; set; }
        public string Observaciones { get; set; }
        public string Incidencias { get; set; }

    }
}
