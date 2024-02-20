namespace SIGDA.CA.Biometricos.Libreria.Models
{
    public class EnvioBiometria
    {
        public string IpTerminal { get; set; }
        public int Port { get; set; }
        public BiometriaEmpleado BiometriaDatos { get; set; }
    }
}
