using SIGDA.Catalogos.Genericos.Genericos.Services.Interfaces;
using SIGDA.Catalogos.Genericos.Models;
using SIGDA.SRHN.Libreria.Catalogos.Sistemas.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Catalogos.Sistemas.Controllers
{
    public class SistemaController : IModelGenericoService, IDisposable
    {
        #region Constructor Variables
        DataTableReader? dtrResultado = null;
        private string? strCadena;

        public SistemaController(string cadena)
        {
            strCadena = cadena;
        }
        #endregion
        public List<BaseModel> ConsultarCatalogoGenerico()
        {
            SistemaBase Base = new SistemaBase(strCadena);
            return (List<BaseModel>)Base.ConsultarCatalogoGenerico();
        }
        public bool InsertarCatalogoGenerico(string Descripcion)
        {
            SistemaBase Base = new SistemaBase(strCadena)
            {
                DescripPrincipal = Descripcion,
            };
            return Base.InsertarCatalogoGenerico();
        }

        public bool ActualizarCatalogoGenerico(long Identificador, string Descripcion)
        {
            SistemaBase Base = new SistemaBase(strCadena)
            {
                DescripPrincipal = Descripcion,
                IdPrincipal = Identificador,
            };
            return Base.ActualizarCatalogoGenerico();
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
