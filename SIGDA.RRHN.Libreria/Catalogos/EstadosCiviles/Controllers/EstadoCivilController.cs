using SIGDA.Catalogos.Genericos.Genericos.Services.Interfaces;
using SIGDA.Catalogos.Genericos.Models;
using SIGDA.SRHN.Libreria.Catalogos.EstadosCiviles.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Catalogos.EstadosCiviles.Controllers
{
    public class EstadoCivilController : IModelGenericoService, IDisposable
    {
        #region Constructor Variables
        DataTableReader? dtrResultado = null;
        private string? strCadena;

        public EstadoCivilController(string cadena)
        {
            strCadena = cadena;
        }

        public bool ActualizarCatalogoGenerico(long Identificador, string Descripcion)
        {
            throw new NotImplementedException();
        }
        #endregion
        public List<BaseModel> ConsultarCatalogoGenerico()
        {
            EstadoCivilBase Base = new EstadoCivilBase(strCadena);
            return (List<BaseModel>)Base.ConsultarCatalogoGenerico();
        }
        public bool InsertarCatalogoGenerico(string Descripcion)
        {
            throw new NotImplementedException();
        }
        public BaseModel ConsultarCatalogoGenericoFiltroId(long Id)
        {
            throw new NotImplementedException();
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
