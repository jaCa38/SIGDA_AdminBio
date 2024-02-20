using SIGDA.SRHN.Libreria.ASF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.ASF.Services.Interfaces
{
    public interface ICuotasService: IDisposable
    {
        List<CuotaISSEGISSSTEBase> ObtenerInformacion(CuotaISSEGISSSTEBase identificadorQna);
        bool AlmacenarInformacion(List<CuotaISSEGISSSTEBase> cuotas);
    }
}
