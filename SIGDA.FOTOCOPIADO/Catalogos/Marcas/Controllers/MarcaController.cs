using SIGDA.Catalogos.Genericos.Genericos.Services.Interfaces;
using SIGDA.Catalogos.Genericos.Models;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.Marcas.Models;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Catalogos.Marcas.Controllers
{
    public class MarcaController : IModelGenericoService, ICatalogoGenericoService, IDisposable
    {
        #region Constructor Variables
        DataTableReader? dtrResultado = null;
        private string? strCadena;

        public MarcaController(string cadena)
        {
            strCadena = cadena;
        }
        #endregion

        public bool ActualizarCatalogoGenerico(long Identificador, string Descripcion)
        {
            MarcaBase Base = new MarcaBase(strCadena)
            {
                DescripPrincipal = Descripcion,
                IdPrincipal = Identificador
            };
            return Base.ActualizarCatalogoGenerico();
        }

        public List<BaseModel> ConsultarCatalogoGenerico()
        {
            MarcaBase Base = new MarcaBase(strCadena);
            return (List<BaseModel>)Base.ConsultarCatalogoGenerico();
        }

        public List<BaseModel> ConsultarCatalogoGenerico(long Identificador)
        {
            throw new NotImplementedException();
        }

        public BaseModel ConsultarCatalogoGenericoFiltroId(long Id)
        {
            throw new NotImplementedException();
        }

        public bool InsertarCatalogoGenerico(string Descripcion)
        {
            MarcaBase Base = new MarcaBase(strCadena)
            {
                DescripPrincipal = Descripcion,
            };
            return Base.InsertarCatalogoGenerico();
        }
        public bool DesactivarCatalogoGenerico(long Identificador)
        {
            MarcaBase Base = new MarcaBase(strCadena)
            {
                IdPrincipal = Identificador
            };
            return Base.DesactivarRegistro();
        }
        public void Dispose()
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

       
    }
}
