using System;

namespace SIGDA.CA.Biometricos.Libreria.Models
{
    public class EmpleadoRH
    {
        public int IdEmpleadoRh { get; set; }
        public string Municipio { get; set; }
        public string CT { get; set; }

        public string Puesto { get; set; }
        public DateTime InicioNombramiento { get; set; }
        public DateTime FinNombramiento { get; set; }

    }
}
