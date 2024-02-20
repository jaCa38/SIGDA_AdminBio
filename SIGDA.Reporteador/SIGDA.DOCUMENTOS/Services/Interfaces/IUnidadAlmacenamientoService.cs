using SIGDA.Documentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Documentos.Services.Interfaces
{
    public interface IUnidadAlmacenamientoService : IDisposable
    {
        UnidadAlmacenamiento ConsultarUnidadActiva();
    }
}
