using SIGDA.Catalogos.Genericos.Genericos.Services.Interfaces;
using SIGDA.Catalogos.Genericos.Models;
using SIGDA.Catalogos.Genericos.Services.Interfaces;
using SIGDA.SRHN.Libreria.Catalogos.Municipios.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Catalogos.Municipios.Controllers
{
    public class MunicipioController : IModelGenericoService, IZonaBaseService, IDisposable
    {
        #region Constructor Variables
        DataTableReader? dtrResultado = null;
        private string? strCadena;

        public MunicipioController(string cadena)
        {
            strCadena = cadena;
        }
        #endregion
        public List<BaseModel> ConsultarCatalogoGenerico()
        {
            MunicipioBase Base = new MunicipioBase(strCadena);
            return (List<BaseModel>)Base.ConsultarCatalogoGenerico();
        }
        public List<ZonaBase> ConsultarZonas()
        {
            MunicipioBase Base = new MunicipioBase(strCadena);
            return (List<ZonaBase>)Base.ObtenerZonas();
        }
        public bool InsertarCatalogoGenerico(string Descripcion)
        {
            throw new NotImplementedException();
        }
        public bool ActualizarCatalogoGenerico(long Identificador, string Descripcion)
        {
            throw new NotImplementedException();
        }
        public BaseModel ConsultarCatalogoGenericoFiltroId(long Id)
        {
            throw new NotImplementedException();
        }
        List<BaseModel> IModelGenericoService.ConsultarCatalogoGenerico(long Identificador)
        {
            MunicipioBase Base = new MunicipioBase(strCadena);
            return (List<BaseModel>)Base.ConsultarCatalogoGenerico(Identificador);
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
