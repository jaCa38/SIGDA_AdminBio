using SIGDA.Consejo.Libreria.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Consejo.Libreria.Models
{
    public class DetallePersonajes : IDetallePersonajes
    {
        public long prpe_identificador { get; set; }
        public string prpe_nombre { get; set; }
        public string prpe_cata_municipio_descripcion { get; set; }
        public string prpe_cata_centro_descripcion { get; set; }
        public string prpe_cata_cargo_descripcion { get; set; }
        public string caas_descripcion { get; set; }
        public string caas_clasificacion { get; set; }
        public string prpe_cata_observaciones { get; set; }
        public string prpe_cata_json { get; set; }
        public DateTime prpe_fecha_captura { get; set; }
    }
}
