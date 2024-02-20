
using SIGDA.Catalogos.Genericos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Catalogos.Genericos.Genericos.Services.Interfaces
{
    public interface IModelGenericoService : IDisposable
    {
        List<BaseModel> ConsultarCatalogoGenerico();
        List<BaseModel> ConsultarCatalogoGenerico(long Identificador);
        BaseModel ConsultarCatalogoGenericoFiltroId(long Id);
        bool InsertarCatalogoGenerico(string Descripcion);
        bool ActualizarCatalogoGenerico(long Identificador, string Descripcion);

        #region IDisposable Members
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
        #endregion
    }
}
