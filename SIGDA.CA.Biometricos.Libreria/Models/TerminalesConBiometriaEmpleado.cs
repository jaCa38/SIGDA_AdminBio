namespace SIGDA.CA.Biometricos.Libreria.Models
{
    public class TerminalesConBiometriaEmpleado
    {
        public int IdTerminal { get; set; }
        public string DescripcionTerminal { get; set; }

        public byte[] TemplateBio { get; set; }
        // public string Municipicio { get; set; }

    }
}
