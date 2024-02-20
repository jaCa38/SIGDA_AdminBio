using System;

namespace SIGDA.CA.Biometricos.Libreria.Models
{
    public class BusquedaFotoFailed
    {
        public DateTime FechaBusqueda { get; set; }
        public int IdTerminal { get; set; }

        public string IpTerminal { get; set; }

        public int PortTerminal { get; set; }

        public string NombreTerminal { get; set; }
    }
}
