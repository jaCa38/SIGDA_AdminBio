using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Catalogos.CentroCopiado.Enums
{
    public enum EstatusCentroFotocopiado: int
    {
        None = 0,
        Activo = 1,
        Bloqueado = 2,
        Cancelado = 3,
    }
}
