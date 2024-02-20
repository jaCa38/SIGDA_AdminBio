using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Consejo.Libreria.Enums
{
    public enum EEstadoSolicitud : int
    {
        SINDEFINIR = 0,
        CAPTURADA = 1,
        CLASIFICADA = 2,
        ENORDEN = 3,
        SESIONADA = 4,
        CALIFICADA = 5,
        CONCLUIDA = 6,
        BLOQUEADA = 100,
    }
}
