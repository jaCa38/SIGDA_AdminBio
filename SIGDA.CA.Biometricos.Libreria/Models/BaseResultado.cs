namespace SIGDA.CA.Biometricos.Libreria.Models
{
    public class BaseResultado
    {
        public bool Resultado { get; set; }

        public bool ConexionStatus { get; set; }

        public string ResultadoError { get; set; } = string.Empty;


    }
}
