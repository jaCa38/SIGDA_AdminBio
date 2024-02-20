namespace SIGDA.CA.Biometricos.Libreria.Models
{
    public class ObtenerBiometria
    {
        public int IdEmpleado { get; set; }
        public int TerminalId { get; set; }
        public string IpTerminal { get; set; }
        public int PortConexion { get; set; }

        public long Numserie { get; set; }
    }
}
