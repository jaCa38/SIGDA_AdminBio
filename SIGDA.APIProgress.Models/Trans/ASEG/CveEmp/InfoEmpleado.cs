using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.APIProgress.Models.Trans.ASEG.CveEmp
{
    public class InfoEmpleado
    {
        public int IdQuincena { set; get; }
        public int AnioQuincena { set; get; }
        public int IdEmpleado { set; get; }
        public string Nombre { set; get; }
        public string RFC { set; get; }
        public string CURP { set; get; }
        public string Nivel { set; get; }
        public string Funcion { set; get; }
        public string Plaza { set; get; }
        public string Division { set; get; }
        public string Municipio { set; get; }
        public string Estado { set; get; }
        public string CentroGestor { set; get; }
        public string Direccion { set; get; }
        public string Departamento { set; get; }
        public int Anio { set; get; }
        public int Mes { set; get; }
        public int Quincena { set; get; }
        public decimal DiasLaborados { set; get; }
        public string NumCheque { set; get; }
        public string FechaEmision { set; get; }
        public string EstadoPago { set; get; }
        public string CtaBancaria { set; get; }
        public string InstBancaria { set; get; }
        public string CveInstBancaria { set; get; }
        public decimal Neto { set; get; }
    }
}
