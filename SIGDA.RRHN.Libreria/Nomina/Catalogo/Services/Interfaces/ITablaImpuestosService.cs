using Newtonsoft.Json.Bson;
using SIGDA.SRHN.Libreria.Nomina.Catalogo.Enums;
using SIGDA.SRHN.Libreria.Nomina.Catalogo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Nomina.Catalogo.Services.Interfaces
{
    public interface ITablaImpuestosService : IDisposable
    {
        public bool AlmacenaTabla(EncabezadoTabla tabla);
        
        public EncabezadoTabla ObtenerTablaVigente(ETipoTabla tipoTabla);
        
    }
}
