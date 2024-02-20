using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.ASF.Models
{
    public class EncabezadoNomOrdBase
    {
        public EncabezadoNomOrdBase()
        {
            LstClaves = new List<ClaveMontoBase>();
        }
        public long IdGeneral { set; get; }
        public string Serie { set; get; }
        public int IdEmpleado { set; get; }
        public string TipoNomina { set; get; }
        public string PeriodicidadPago { set; get; }
        public string Nombre { set; get; }
        public string RFC { set; get; }
        public string FechaInicioPago { set; get; }
        public string FechaFinPago { set; get; }
        public string FechaPago { set; get; }
        public int DiasPagados { set; get; }
        public string Antiguedad { set; get; }
        public string CuentaBanco { set; get; }
        public string TipoPago { set; get; }
        public string Banco { set; get; }
        public string Estatus { set; get; }
        public int Horas { set; get; }
        public decimal Total { set; get; }
        public string UUID { set; get; }
        public string UUIDRelacionado { set; get; }
        public List<ClaveMontoBase> LstClaves { set; get; }

    }
}
