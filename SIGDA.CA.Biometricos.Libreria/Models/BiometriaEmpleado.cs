namespace SIGDA.CA.Biometricos.Libreria.Models
{
    public class BiometriaEmpleado
    {
        public int Id { get; set; }
        public string Template { get; set; }
        public bool ConexionEstatus { get; set; } = false;
        public bool ExtraccionEstatus { get; set; } = false;
        public string MensajeErro { get; set; }
        public int IdTerminal { get; set; }







    }
}
