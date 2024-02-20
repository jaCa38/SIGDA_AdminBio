using SIGDA.FOTOCOPIADO.Libreria.Catalogos.TipoCopia.Models;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.TipoCopia.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Catalogos.TipoCopia.Services
{
    public class TipoCopiaService : ITipoCopiaService
    {
        private readonly ITipoCopiaService _metodos;

        public TipoCopiaService(ITipoCopiaService metodos)
        {
            _metodos = metodos;
        }
        public List<TipoCopiaBase> ConsultarTiposCopia()
        {
            return _metodos.ConsultarTiposCopia();
        }

        public void Dispose()
        {
            try
            {

            }
            catch 
            {
            }
        }
    }
}
