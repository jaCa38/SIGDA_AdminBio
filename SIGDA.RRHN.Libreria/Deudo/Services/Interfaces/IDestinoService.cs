using SIGDA.Catalogos.Genericos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Deudo.Services.Interfaces
{
    public interface IDestinoService : IDisposable
    {
        List<BaseModel> ConsultarCatalogoDestino();
        List<BaseModel> ConsultarCatalogoDestinoHijo(long Identificador);
    }
}
