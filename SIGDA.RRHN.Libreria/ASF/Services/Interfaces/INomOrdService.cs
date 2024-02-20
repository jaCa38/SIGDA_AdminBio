using SIGDA.SRHN.Libreria.ASF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.ASF.Services.Interfaces
{
    public  interface INomOrdService: IDisposable
    {
        List<EncabezadoNomOrdBase> ObtenerInformacionEncabezado(int anio);
        //List<ClaveMontoBase> ObtenerInformacionClavesMontos(int anio);
        List<ClaveMontoBase> ObtenerInformacionClavesMontos(int anio, long idGral);
    }
}
