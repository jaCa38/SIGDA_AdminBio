using System;

namespace SIGDA.CA.Biometricos.Libreria.Models
{
    public class RegistrosRelojes
    {
        public int IdTerminal { get; set; }
        public int IdEmpleado { get; set; }
        public DateTime Record { get; set; }

        public string Hora { get; set; }



        public bool ConexionReloj { get; set; }

        public string ErrorMsj { get; set; }
    }
}
