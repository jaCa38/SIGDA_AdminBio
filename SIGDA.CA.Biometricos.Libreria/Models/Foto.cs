using System;

namespace SIGDA.CA.Biometricos.Libreria.Models
{
    public class Foto
    {
        public string FotoBase64 { get; set; }
        public int IdEmpleado { get; set; }

        public DateTime Registro { get; set; }

        public string Hora { get; set; }

        public bool EmpleadoEncontrado { get; set; }

        public bool ConexionReloj { get; set; }

        public string ErrorMessagge { get; set; }

        public int CantidadRegistros { get; set; }
        public int CantidadFotos { get; set; }



    }
}
