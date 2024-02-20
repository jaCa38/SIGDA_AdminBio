using System;

namespace SIGDA.CA.Biometricos.Libreria.Models
{
    public class DescargaRegistrosPorFecha
    {
        public string IpTerminal { get; set; }
        public int PortTerminal { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
