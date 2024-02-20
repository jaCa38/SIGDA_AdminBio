using SIGDA.SRHN.Libreria.Nomina.Catalogo.Enums;
using SIGDA.SRHN.Libreria.Nomina.Catalogo.Models;
using SIGDA.SRHN.Libreria.Nomina.Catalogo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Nomina.Catalogo.Services
{
    public class TablaImpuestosService : ITablaImpuestosService, IDisposable
    {
        private readonly ITablaImpuestosService _metodos;
        public TablaImpuestosService(ITablaImpuestosService metodos)
        {
            _metodos = metodos;
        }

        public bool AlmacenaTabla(EncabezadoTabla tablaISR)
        {
            return _metodos.AlmacenaTabla(tablaISR);
        }       

        public EncabezadoTabla ObtenerTablaVigente(ETipoTabla tipoTabla)
        {
            return _metodos.ObtenerTablaVigente(tipoTabla);
        }
        public void Dispose()
        {
            try { }
            catch (Exception) { }
        }
    }
}
