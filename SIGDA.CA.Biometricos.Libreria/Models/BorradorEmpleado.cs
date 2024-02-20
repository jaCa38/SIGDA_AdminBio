namespace SIGDA.CA.Biometricos.Libreria.Models
{
    public class BorradorEmpleado
    {
        public int Id { get; set; }
        public int TerminalId { get; set; }
        public string IpTerminal { get; set; }


        public int PortConexion { get; set; }
    }
}
