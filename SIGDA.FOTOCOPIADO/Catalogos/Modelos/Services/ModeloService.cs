using SIGDA.FOTOCOPIADO.Libreria.Catalogos.Modelos.Models;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.Modelos.Services.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Catalogos.Modelos.Services
{
    public class ModeloService : IModeloService
    {
        private readonly IModeloService _metodos;

        public ModeloService(IModeloService metodos)
        {
            _metodos = metodos;
        }
        public bool ActualizarModelo(long IdModelo, string Descripcion, long IdMarca)
        {
            return _metodos.ActualizarModelo(IdModelo, Descripcion, IdMarca);
        }

        public ModelosBase ConsultarModeloFiltroId(long IdModelo)
        {
            return _metodos.ConsultarModeloFiltroId(IdModelo);
        }

        public List<ModelosBase> ConsultarModelos()
        {
            return _metodos.ConsultarModelos();
        }

        public bool DesactivarModelo(long IdModelo)
        {
            return _metodos.DesactivarModelo(IdModelo);
        }

        public bool InsertarModelo(string Descripcion, long IdMarca)
        {
            return _metodos.InsertarModelo(Descripcion, IdMarca);
        }
        public List<ModelosBase> ConsultarModeloPorMarca(long IdMarca)
        {
            return _metodos.ConsultarModeloPorMarca(IdMarca);
        }
        public void Dispose()
        {
            try { }
            catch { }
        }

       
    }
}
