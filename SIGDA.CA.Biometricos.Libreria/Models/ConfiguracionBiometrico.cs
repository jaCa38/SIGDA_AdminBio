using System;

namespace SIGDA.CA.Biometricos.Libreria.Models
{
    public class ConfiguracionBiometrico
    {

        public string Sn { get; set; }
        public string Fw { get; set; }
        public string Algoritmo { get; set; }
        public string Modelo { get; set; }
        public DateTime FechaHora { get; set; }

        public bool ConexionEstatus { get; set; } = false;








    }
}
