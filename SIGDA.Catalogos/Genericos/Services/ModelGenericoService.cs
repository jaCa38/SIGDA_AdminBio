
using SIGDA.Catalogos.Genericos.Genericos.Services.Interfaces;
using SIGDA.Catalogos.Genericos.Models;
using SIGDA.Catalogos.Genericos.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SIGDA.Catalogos.Genericos.Genericos.Services
{
    public class ModelGenericoService : IModelGenericoService, IModelCatalogoBaseService, IZonaBaseService
    {
        private readonly IZonaBaseService _metodosZona;
        private readonly IModelGenericoService _metodos;
        private readonly IModelCatalogoBaseService _metodosCatalogo;
       
        public ModelGenericoService(IModelGenericoService metodos)
        {
            _metodos = metodos;
        }        
        public ModelGenericoService(IModelCatalogoBaseService metodos)
        {
            _metodosCatalogo = metodos;
        }
        public ModelGenericoService(IZonaBaseService metodos)
        {
            _metodosZona = metodos;
        }

        public List<BaseModel> ConsultarCatalogoGenerico()
        {
            return _metodos.ConsultarCatalogoGenerico();
        }
        public bool InsertarCatalogoGenerico(string Descripcion)
        {
            return _metodos.InsertarCatalogoGenerico(Descripcion);
        }
        public bool ActualizarCatalogoGenerico(long Identificador, string Descripcion)
        {
            return _metodos.ActualizarCatalogoGenerico(Identificador, Descripcion);
        }
        public BaseModel ConsultarCatalogoGenericoFiltroId(long Id)
        {
            return _metodos.ConsultarCatalogoGenericoFiltroId(Id);
        }

        public List<BaseModel> ConsultarCatalogoGenerico(long Identificador)
        {
            return _metodos.ConsultarCatalogoGenerico(Identificador);
        }
        public void Dispose()
        {
            try {}
            catch { }
        }
        public List<CatalogoBaseModel> ObtenerCatalogo(CatalogoBaseModel catalogo)
        {
            return _metodosCatalogo.ObtenerCatalogo(catalogo);
        }
        public bool AlmacenaInformacionPrimeraVez(List<CatalogoBaseModel> lista)
        {
            return _metodosCatalogo.AlmacenaInformacionPrimeraVez(lista);
        }

        public List<ZonaBase> ConsultarZonas()
        {
            return _metodosZona.ConsultarZonas();
        }
    }
}
