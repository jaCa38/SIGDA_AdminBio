using SIGDA.Consejo.Libreria.Enums;
using SIGDA.Consejo.Libreria.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Consejo.Libreria.Models
{
    public class DetallePrecalificacion : IDetallePrecalificacion
    {
        public long prpc_identificador { get; set; }
        public long prpc_identificador_promocion { get; set; }
        public long prpc_identificador_usuario { get; set; }
        public ETiposPrecalificaciones prpc_tipo_precalificacion { get; set; }
        public string prpc_case_descripcion { get; set; }
        public string prpc_observaciones { get; set; }
        public DateTime prpc_fecha_captura { get; set; }
        public long prpc_identificador_documento { get; set; }
    }
}
