using SIGDA.FOTOCOPIADO.Libreria.Catalogos.Modelos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Catalogos.Modelos.Services.Interfaces
{
    public interface IModeloService : IDisposable
    {
        List<ModelosBase> ConsultarModelos();

        ModelosBase ConsultarModeloFiltroId(long IdModelo);
        bool InsertarModelo(string Descripcion, long IdMarca);
        bool ActualizarModelo(long IdModelo, string Descripcion, long IdMarca);
        bool DesactivarModelo(long IdModelo);
        List<ModelosBase> ConsultarModeloPorMarca(long IdMarca);

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
