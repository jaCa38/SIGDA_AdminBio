namespace SIGDA.CA.Biometricos.Libreria.Models
{
    public class ListaBiometriasEmpleado
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public byte[] Template { get; set; }
    }
}
