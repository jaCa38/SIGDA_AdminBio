using SIGDA.Catalogos.Genericos.Genericos.Services.Interfaces;
using SIGDA.Catalogos.Genericos.Models;
using SIGDA.SRHN.Libreria.Deudo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Deudo.Controllers
{
    public class ConceptoController : IModelGenericoService, IDisposable
    {
        #region Constructor Variables
        DataTableReader? dtrResultado = null;
        private string? strCadena;

        public ConceptoController(string cadena)
        {
            strCadena = cadena;
        }
        #endregion
        public bool ActualizarCatalogoGenerico(long Identificador, string Descripcion)
        {
            ConceptoBase Base = new ConceptoBase(strCadena)
            {
                DescripPrincipal = Descripcion,
                IdPrincipal = Identificador,
            };
            return Base.ActualizarCatalogoGenerico();
        }        
        public List<BaseModel> ConsultarCatalogoGenerico()
        {
            ConceptoBase Base = new ConceptoBase(strCadena);
            return (List<BaseModel>)Base.ConsultarCatalogoGenerico();
        }
        public bool InsertarCatalogoGenerico(string Descripcion)
        {
            ConceptoBase Base = new ConceptoBase(strCadena)
            {
                DescripPrincipal = Descripcion,
            };
            return Base.InsertarCatalogoGenerico();
        }
        public BaseModel ConsultarCatalogoGenericoFiltroId(long Id)
        {
            ConceptoBase Base = new ConceptoBase(strCadena)
            {
                IdPrincipal = Id,
            };
            return (BaseModel)Base.ConsultarCatalogoGenericoFiltroID();
        }
        public List<BaseModel> ConsultarCatalogoGenerico(long Identificador)
        {
            throw new NotImplementedException();
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
