namespace SIGDA.CA.Biometricos.Libreria.Models
{
    public class FotoSorry
    {
        public string FotoBase64 { get; set; }

        public bool FotoSorryExist { get; set; }

        public string Hora { get; set; }
        public bool ConexionReloj { get; set; }

        public int CantidadFotos { get; set; }

        public string ErrorMessagge { get; set; }




    }
}
