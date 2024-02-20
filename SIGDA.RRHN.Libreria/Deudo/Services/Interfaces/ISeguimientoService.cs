using SIGDA.SRHN.Libreria.Deudo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Deudo.Services.Interfaces
{
    public interface ISeguimientoService: IDisposable
    {
        List<SeguimientoBase> ConsultarSeguimiento(long idRegistro);
        bool AlmacenarSeguimiento(SeguimientoBase seguimiento);

    }
}
