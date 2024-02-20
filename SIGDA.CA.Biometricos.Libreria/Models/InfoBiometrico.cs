namespace SIGDA.CA.Biometricos.Libreria.Models
{
    public class InfoBiometrico

    {
        public int IdTerminal { get; set; }
        public string IpTerminal { get; set; }
        public int PortTerminal { get; set; }
        public string NombreTerminal { get; set; }
        public bool ConexionEstatus { get; set; } = true;
        public string ErrorMessage { get; set; }




    }
}
