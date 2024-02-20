namespace SIGDA.CA.Biometricos.Libreria.Models
{
    public class BiometriaEnvio
    {
        public int IdTerminal { get; set; }
        public string IpTerminal { get; set; }
        public int Port { get; set; }
        public int Id { get; set; }
        public string BiometriaTemplate { get; set; }
        public byte[] TemplateToSend { get; set; }
    }
}
