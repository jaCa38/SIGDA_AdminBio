using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.APIProgress.Models.Vac
{
    public class Periodo
    {
        public string Puesto { get; set; }
        public string Materno { get; set; }
        public string Paterno { get; set; }
        public string Nombre { get; set; }
        public int IdPlazaConsec { get; set; }
        public int DiasLiq { get; set; }
        public string DescripEstatus { get; set; }
        public string PeriodoMostrar { get; }
        public string Comentarios { get; set; }
        public string FechaSesion { get; set; }
        public int IdSubCentroTrabajo { get; set; }
        public int IdUsuario { get; set; }
        public int IdEstatus { get; set; }
        public int Dias { get; set; }
        public string Fin { get; set; }
        public string Inicio { get; set; }
        public int Anio { get; set; }
        public string DescripTipoPeriodo { get; set; }
        public int IdTipoPeriodo { get; set; }
        public int IdEmpleado { get; set; }
        public int IdPeriodo { get; set; }
        public string Funcion { get; set; }
        public string IdentifCT { get; set; }
    }
}
