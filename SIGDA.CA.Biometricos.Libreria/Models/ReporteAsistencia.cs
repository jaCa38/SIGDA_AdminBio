using System;

namespace SIGDA.CA.Biometricos.Libreria.Models
{
    public class ReporteAsistencia
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string HoraEntrada { get; set; }
        public string HoraSalida { get; set; }
        public string Observacion { get; set; }
        public string Inicidencia { get; set; }
        public string Puesto { get; set; }
        public string CT { get; set; }
        public string Municipio { get; set; }
        public int Zona { get; set; }




    }
}
