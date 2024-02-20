using Microsoft.Identity.Client;
using SIGDA.Consejo.Libreria.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Consejo.Libreria.Interfaces
{
    public interface IDetallePrecalificacion
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


