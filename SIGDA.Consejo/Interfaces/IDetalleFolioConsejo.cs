using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Consejo.Libreria.Interfaces
{
    public interface IDetalleFolioConsejo
    {
        public string FechaCaptura { get; set; }
        public string FechaRecepcion { get; set; }
        public string MedioPresentacion { get; set; }
        public string Presento { get; set; }
        public string Oficio { get; set; }
        public string Anexos { get; set; }
        public string Resumen { get; set; }
        public string Email { get; set; }
        public string Clasificacion { get; set; }
        public string SubClasificacion { get; set; }
        public string ListadoEl { get; set; }
        public string ListadoPara { get; set; }
        public string PrecalificacionRH { get; set; }
        public string PrecalificacionSC { get; set; }
        public string EstadoSolicitud { get; set; }
        public string FechaOrdenDia { get; set; }
        public string EstadoOrdenDia { get; set; }
        public string FechaActaSesion { get; set; }
        public string EstadoActaSesion { get; set; }
        public string CalificacionSesion { get; set; }
        public string ObservacionesCalificacionSesion { get; set; }

    }
}
