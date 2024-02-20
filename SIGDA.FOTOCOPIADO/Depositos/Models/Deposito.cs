using SIGDA.FOTOCOPIADO.Libreria.Depositos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Depositos.Models
{
    public class Deposito : IDepositoBase
    {
        public long IdDeposito { get; set; }
        public DateTime FechaDeposito { get; set; }
        public string SucursalDeposito { get; set; }
        public string FolioDeposito { get; set; }
        public DateTime FechaInicioDeposito { get; set; }
        public DateTime FechaFinDeposito { get; set; }
        public decimal ImporteDeposito { get; set; }
        public long IdCentroFotocopiado { get; set; }
        public long idMunicipio { get; set; }
        public long IdDocumento { get; set; }
    }
}
