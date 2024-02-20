using SIGDA.FOTOCOPIADO.Libreria.Catalogos.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Catalogos.Services
{
    public class CatalogoGenericoService: ICatalogoGenericoService
    {
        private readonly ICatalogoGenericoService _metodos;
       
        public CatalogoGenericoService(ICatalogoGenericoService metodos)
        {
            _metodos = metodos;
        }
        public bool DesactivarCatalogoGenerico(long Identificador)
        {
            return _metodos.DesactivarCatalogoGenerico(Identificador);
        }

        public void Dispose()
        {
            try { }
            catch { }
        }
    }
}
