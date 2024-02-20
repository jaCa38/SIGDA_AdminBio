using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Depositos.Interfaces
{
    public interface IDepositoDetalle
    {
        public long IdCentroFotocopiado { get; set; }
        public string NombreCentroFotocopiado { get; set; }
        public long idMunicipio { get; set; }
        public string Municipio { get; set; }
    }
}