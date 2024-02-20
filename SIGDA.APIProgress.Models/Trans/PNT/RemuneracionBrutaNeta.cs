using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.APIProgress.Models.Trans.PNT
{
    public class RemuneracionBrutaNeta
    {
        public int AnioTrimestre { set; get; }
        public int IdTrimestre { set; get; }
        public int AnioEjercicio { set; get; }
        public string InicioPeriodo { set; get; }
        public string FinPeriodo { set; get; }
        public string TipoIntegrante { set; get; }
        public string ClavePuesto { set; get; }
        public string Denominacion { set; get; }
        public string Cargo { set; get; }
        public string Area { set; get; }
        public string Nombre { set; get; }
        public string Paterno { set; get; }
        public string Materno { set; get; }
        public string Sexo { set; get; }
        public decimal MontoBruto { set; get; }
        public string TipoMonedaBruto { set; get; }
        public decimal MontoNeto { set; get; }
        public string TipoMonedaNeto { set; get; }
        public int Tabla386009 { set; get; }
        public int Tabla385996 { set; get; }
        public int Tabla386010 { set; get; }
        public int Tabla385980 { set; get; }
        public int Tabla386000 { set; get; }
        public int Tabla385987 { set; get; }
        public int Tabla385997 { set; get; }
        public int Tabla385988 { set; get; }
        public int Tabla385989 { set; get; }
        public int Tabla386007 { set; get; }
        public int Tabla386011 { set; get; }
        public int Tabla386008 { set; get; }
        public int Tabla386012 { set; get; }
        public string AreaResponsable { set; get; }
        public string FechaValidacion { set; get; }
        public string FechaActualizacion { set; get; }
    }
}
