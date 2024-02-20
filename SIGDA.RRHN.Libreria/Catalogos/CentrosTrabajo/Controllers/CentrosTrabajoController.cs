using SIGDA.Catalogos.Genericos.Genericos.Services.Interfaces;
using SIGDA.Catalogos.Genericos.Models;
using SIGDA.SRHN.Libreria.Catalogos.CentrosTrabajo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Catalogos.CentrosTrabajo.Controllers
{
    public class CentrosTrabajoController : IModelGenericoService, IDisposable
    {
        #region Constructor Variables
        DataTableReader? dtrResultado = null;
        private string? strCadena;

        public CentrosTrabajoController(string cadena)
        {
            strCadena = cadena;
        }
        #endregion
        public List<BaseModel> ConsultarCatalogoGenerico()
        {
            CentroTrabajoBase Base = new CentroTrabajoBase(strCadena);
            return (List<BaseModel>)Base.ConsultarCatalogoGenerico();
        }
        public bool InsertarCatalogoGenerico(string Descripcion)
        {
            CentroTrabajoBase Base = new CentroTrabajoBase(strCadena)
            {
                DescripPrincipal = Descripcion,
            };
            return Base.InsertarCatalogoGenerico();
        }

        public bool ActualizarCatalogoGenerico(long Identificador, string Descripcion)
        {
            CentroTrabajoBase Base = new CentroTrabajoBase(strCadena)
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
