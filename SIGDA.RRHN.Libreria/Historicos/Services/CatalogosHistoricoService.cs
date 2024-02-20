using SIGDA.Catalogos.Genericos.Models;
using SIGDA.SRHN.Libreria.Historicos.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Historicos.Services
{
    public class CatalogosHistoricoService: ICatalogosHistoricoService
    {
        private readonly ICatalogosHistoricoService _metodos;
        public CatalogosHistoricoService(ICatalogosHistoricoService metodos) 
        {
            _metodos = metodos;
        }

        public List<BaseModel> ConsultarCatalogoTipoPeriodo()
        {
            return _metodos.ConsultarCatalogoTipoPeriodo();
        }

        public void Dispose()
        {
            try
            {
                //sqlCon.Dispose();
                //sqlCon = null;
                //_Parametros.Clear();
                //media.Close();
                //media = null;
            }
            catch { }
        }
    }
}
