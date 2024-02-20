using SIGDA.Catalogos.Genericos.Models;
using SIGDA.SRHN.Libreria.Deudo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Deudo.Services.Interfaces
{
    public interface IEstatusService : IDisposable
    {
        public List<BaseModel> ConsultarCatalogoEstatus();
    }
}
