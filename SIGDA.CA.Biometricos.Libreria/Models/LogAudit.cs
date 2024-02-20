using System;

namespace SIGDA.CA.Biometricos.Libreria.Models
{
    public class LogAudit
    {
        public int IdTerminal { get; set; }
        public DateTime FechaDescarga { get; set; }
        public int CantidadFotos { get; set; }
        public int CantidadRegistros { get; set; }

        public int TipoTarea { get; set; }
        public int ConexionEstatus { get; set; }
        public string MsjError { get; set; }
    }
}
