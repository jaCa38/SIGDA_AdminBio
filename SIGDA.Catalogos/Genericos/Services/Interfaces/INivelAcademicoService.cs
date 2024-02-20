using SIGDA.Catalogos.Genericos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Catalogos.Genericos.Services.Interfaces
{
    public interface INivelAcademicoService : IDisposable
    {
        List<BaseModel> ObtenerNivelesAcademicos();
        List<BaseModel> ObtenerEstatusEstudio();
    }
}
