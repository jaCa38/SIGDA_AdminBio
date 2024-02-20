using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGDA.Catalogos.Genericos.Genericos.Services;
using SIGDA.Catalogos.Genericos.Interfaces;
using SIGDA.Catalogos.Genericos.Models;
using SIGDA.SRHN.Libreria.Catalogos.Catalogo.Factorizadores;
using SIGDA.SRHN.Libreria.Catalogos.CentrosTrabajo.Factorizadores;
using SIGDA.SRHN.Libreria.Catalogos.CentrosTrabajo.Models;
using SIGDA.SRHN.Libreria.Catalogos.EntidadesFederativas.Factorizadores;
using SIGDA.SRHN.Libreria.Catalogos.Escolaridades.Factorizadores;
using SIGDA.SRHN.Libreria.Catalogos.EstadosCiviles.Factorizadores;
using SIGDA.SRHN.Libreria.Catalogos.Genericos.Enums;
using SIGDA.SRHN.Libreria.Catalogos.Generos.Factorizadores;
using SIGDA.SRHN.Libreria.Catalogos.GruposSanguineos.Factorizadores;
using SIGDA.SRHN.Libreria.Catalogos.Municipios.Factorizadores;
using SIGDA.SRHN.Libreria.Catalogos.Municipios.Models;
using SIGDA.SRHN.Libreria.Catalogos.NuevosCentrosTrabajo.Factorizadores;
using SIGDA.SRHN.Libreria.Catalogos.NuevosCentrosTrabajo.Models;
using SIGDA.SRHN.Libreria.Catalogos.NuevosCentrosTrabajo.Services;
using SIGDA.SRHN.Libreria.Catalogos.Paises.Factorizadores;
using SIGDA.SRHN.Libreria.Catalogos.Sistemas.Factorizadores;
using SIGDA.SRHN.Libreria.Catalogos.Sistemas.Models;
using SIGDA.SRHN.Libreria.Catalogos.SubCentrosTrabajo.Factorizadores;
using SIGDA.SRHN.Libreria.Catalogos.SubCentrosTrabajo.Models;
using SIGDA.SRHN.Libreria.Catalogos.SubCentrosTrabajo.Services;
using SIGDA.SRHN.Libreria.Empleados.Factorizadores;
using SIGDA.SRHN.Libreria.Empleados.Models;
using SIGDA.SRHN.Libreria.Empleados.Services;

namespace SIGDA_BackEnd.Docker.Linux.Controllers.API
{
    public class CatalogosAPIController : BaseControllerSIGDA
    {
        private IConfiguration _Config;
        public CatalogosAPIController(IConfiguration Configuration) => _Config = Configuration;

        //[Authorize]
        [HttpPost]
        [Route("api/Catalogos/ConsultarMunicipios")]
        public IEnumerable<IBaseModel> ConsultarMunicipios()
        {
            ModelGenericoService service;

            using (var Gestion = FactorizadorMunicipio.CrearConexionGenerica())
            {
                service = new ModelGenericoService(Gestion);
                return service.ConsultarCatalogoGenerico();
            }

            throw new Exception();
        }
        [HttpPost]
        [Route("api/Catalogos/ConsultarZonas")]
        public IEnumerable<ZonaBase> ConsultarZonas()
        {
            ModelGenericoService service;

            using (var Gestion = FactorizadorMunicipio.CrearConexionGenericaZona())
            {
                service = new ModelGenericoService(Gestion);
                return service.ConsultarZonas();
            }

            throw new Exception();
        }

        //[Authorize]
        [HttpPost]
        [Route("api/Catalogos/ConsultarSistemas")]
        public IEnumerable<IBaseModel> ConsultarSistemas()
        {
            ModelGenericoService service;

            using (var Gestion = FactorizadorSistema.CrearConexionGenerica())
            {
                service = new ModelGenericoService(Gestion);
                return service.ConsultarCatalogoGenerico();
            }

            throw new Exception();
        }

        //[Authorize]
        [HttpPost]
        [Route("api/Catalogos/ConsultarCentrosTrabajo")]
        public IEnumerable<IBaseModel> ConsultarCentrosTrabajo()
        {
            ModelGenericoService service;

            using (var Gestion = FactorizadorCentroTrabajo.CrearConexionGenerica())
            {
                service = new ModelGenericoService(Gestion);
                return service.ConsultarCatalogoGenerico();
            }

            throw new Exception();
        }

        //[Authorize]
        [HttpPost]
        [Route("api/Catalogos/ConsultarTodosSubCentrosTrabajo")]
        public List<SubCentroTrabajoBase> ConsultarSubCentrosTrabajo()
        {
            SubCentroTrabajoService service;

            using (var Gestion = FactorizadorSubCentroTrabajo.CrearConexionSubCentroTrabajo())
            {
                service = new SubCentroTrabajoService(Gestion);
                return service.ConsultarCatalogoGenerico();
            }

            throw new Exception();
        }

        //[Authorize]
        [HttpPost]
        [Route("api/Catalogos/ConsultarFiltroSubCentrosTrabajo")]
        public List<SubCentroTrabajoBase> ConsultarFiltroSubCentrosTrabajo([FromBody] BusquedaBaseSubCT busquedaBaseSubCT)
        {
            SubCentroTrabajoService service;

            using (var Gestion = FactorizadorSubCentroTrabajo.CrearConexionSubCentroTrabajo())
            {
                service = new SubCentroTrabajoService(Gestion);
                return service.ConsultarCatalogoGenerico(busquedaBaseSubCT.Division, busquedaBaseSubCT.Instancia,busquedaBaseSubCT.IdSistema, busquedaBaseSubCT.IdMunicipio, busquedaBaseSubCT.IdCentroTrabajo);
            }

            throw new Exception();
        }

        //[Authorize]
        [HttpPost]
        [Route("api/Catalogos/InsertarSistema")]
        public Boolean InsertarSistema([FromBody] string Descripcion)
        {
            ModelGenericoService service;

            using (var Gestion = FactorizadorSistema.CrearConexionGenerica())
            {
                service = new ModelGenericoService(Gestion);
                return service.InsertarCatalogoGenerico(Descripcion);
            }

            throw new Exception();
        }

        //[Authorize]
        [HttpPost]
        [Route("api/Catalogos/InsertarCentroTrabajo")]
        public Boolean InsertarCentroTrabajo([FromBody] string Descripcion)
        {
            ModelGenericoService service;

            using (var Gestion = FactorizadorCentroTrabajo.CrearConexionGenerica())
            {
                service = new ModelGenericoService(Gestion);
                return service.InsertarCatalogoGenerico(Descripcion);
            }

            throw new Exception();
        }

        //[Authorize]
        [HttpPost]
        [Route("api/Catalogos/InsertarNuevoCentroTrabajo")]
        public Boolean InsertarNuevoCentroTrabajo([FromBody] NuevoCentroTrabajoBase nuevoCentroTrabajoBase)
        {
            NuevoCentroTrabajoService service;

            using (var Gestion = FactorizadorNuevoCentroTrabajo.CrearConexionNuevoCentroTrabajo())
            {
                service = new NuevoCentroTrabajoService(Gestion);
                return service.InsertarNuevoCentroTrabajo(nuevoCentroTrabajoBase);
            }

            throw new Exception();
        }

        //[Authorize]
        [HttpPost]
        [Route("api/Catalogos/ActivarNuevoCentroTrabajo")]
        public Boolean ActivarNuevoCentroTrabajo([FromBody] long Identificador)
        {
            NuevoCentroTrabajoService service;

            using (var Gestion = FactorizadorNuevoCentroTrabajo.CrearConexionNuevoCentroTrabajo())
            {
                service = new NuevoCentroTrabajoService(Gestion);
                return service.ActivarNuevoCentroTrabajo(Identificador);
            }

            throw new Exception();
        }
        /// <summary>
        /// Filtro 01: Obtener las divisiones de los centros de trabajo
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Catalogos/NCT/obtenerDivisiones")]
        public List<BaseModel> ConsultarDvisiones()
        {
            NuevoCentroTrabajoService service;
            using(var Gestion = FactorizadorNuevoCentroTrabajo.CrearConexionNuevoCentroTrabajo())
            {
                service = new NuevoCentroTrabajoService(Gestion);
                return service.ObtenerDivision();
            }
        }
        /// <summary>
        /// Filtro 02: Obtener las instancias de los centros de trabajo por division
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Catalogos/NCT/obtenerInstancias")]
        public List<BaseModel> ConsultarInstancias([FromBody] EDivision division)
        {
            NuevoCentroTrabajoService service;
            using (var Gestion = FactorizadorNuevoCentroTrabajo.CrearConexionNuevoCentroTrabajo())
            {
                service = new NuevoCentroTrabajoService(Gestion);
                return service.ObtenerInstancias(division);
            }
        }
        /// <summary>
        /// Filtro 03: Obtener los sitemas de los centros de trabajo (division, instancia)
        /// </summary>
        /// <param name="filtro">Edivision,EInstancia</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Catalogos/NCT/obtenerSistemas")]
        public List<BaseModel> ConsultarSistemas([FromBody] NuevoCentroTrabajoBase filtro)
        {
            NuevoCentroTrabajoService service;
            using (var Gestion = FactorizadorNuevoCentroTrabajo.CrearConexionNuevoCentroTrabajo())
            {
                service = new NuevoCentroTrabajoService(Gestion);
                return service.ObtenerSistemas(filtro.Division, filtro.Instancia);
            }
        }
        /// <summary>
        /// Filtro 04: Obtener los municipios de los centros de trabajo (division, instancia, sistema)
        /// </summary>
        /// <param name="filtro">Edivision,EInstancia, idSistema</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Catalogos/NCT/obtenerMunicipios")]
        public List<BaseModel> ConsultarMunicipios([FromBody] NuevoCentroTrabajoBase filtro)
        {
            NuevoCentroTrabajoService service;
            using (var Gestion = FactorizadorNuevoCentroTrabajo.CrearConexionNuevoCentroTrabajo())
            {
                service = new NuevoCentroTrabajoService(Gestion);
                return service.ObtenerMunicipios(filtro.Division, filtro.Instancia, filtro.IdSistema);
            }
        }
        /// <summary>
        /// Filtro 05: Obtiene el penultimo árbol de relación de los centros de trabajo
        /// </summary>
        /// <param name="filtro">Edivision,EInstancia, idSistema, idMunicipio</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Catalogos/NCT/obtenerCentrosTrabajoGlobal")]
        public List<BaseModel> ConsultarCTGlobal([FromBody] NuevoCentroTrabajoBase filtro)
        {
            NuevoCentroTrabajoService service;
            using (var Gestion = FactorizadorNuevoCentroTrabajo.CrearConexionNuevoCentroTrabajo())
            {
                service = new NuevoCentroTrabajoService(Gestion);
                return service.ConsultarNuevoCentroTrabajo(filtro.Division, filtro.Instancia, filtro.IdSistema, filtro.IdMunicipio);
            }
        }

        /// <summary>
        /// Filtro 06: Listado final de subCentros de trabajo
        /// <para>EndPoint para ejecutar procedimiento de la base [catalogo].[sp_ObtenerNuevoCentroTrabajo]</para>
        /// </summary>
        /// <param name="IdCentroTrabajo"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        //[Authorize]
        [HttpPost]
        [Route("api/Catalogos/NCT/ConsultarNuevoCentroTrabajoDetalle")]
        public List<NuevoCentroTrabajoDetalle> ConsultarNuevoCentroTrabajoDetalle([FromBody] long IdCentroTrabajo)
        {
            NuevoCentroTrabajoService service;

            using (var Gestion = FactorizadorNuevoCentroTrabajo.CrearConexionNuevoCentroTrabajo())
            {
                service = new NuevoCentroTrabajoService(Gestion);
                return service.ConsultarNuevoCentroTrabajoDetalle(IdCentroTrabajo);
            }

            throw new Exception();
        }
        /// <summary>
        /// Adicional: Búsqueda de coincidencias para subCentro de trabajo
        /// <para>Endpoint para ejecutar procedimiento [catalogo].[sp_ObtenerNuevosCentrosTrabajoFiltro]</para>
        /// </summary>
        /// <param name="Busqueda"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        //[Authorize]
        [HttpPost]
        [Route("api/Catalogos/NCT/ConsultarNuevoCentroTrabajoDetalleFiltro")]
        public List<NuevoCentroTrabajoDetalle> ConsultarNuevoCentroTrabajoDetalleFiltro([FromBody] string Busqueda)
        {
            NuevoCentroTrabajoService service;

            using (var Gestion = FactorizadorNuevoCentroTrabajo.CrearConexionNuevoCentroTrabajo())
            {
                service = new NuevoCentroTrabajoService(Gestion);
                return service.ConsultarNuevoCentroTrabajoDetalle(Busqueda);
            }

            throw new Exception();
        }
        /// <summary>
        ///  Endpoint para ejecutar procedimiento [catalogo].[sp_ObtenerNuevosCentrosTrabajoFiltro2]
        /// </summary>
        /// <param name="Busqueda"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        //[Authorize]
        [HttpPost]
        [Route("api/Catalogos/ConsultarNuevoCentroTrabajoDetalleFiltro2")]
        public List<NuevoCentroTrabajoDetalle> ConsultarNuevoCentroTrabajoDetalleFiltro2([FromBody] BusquedaDetalleNuevoCT Busqueda)
        {
            NuevoCentroTrabajoService service;

            using (var Gestion = FactorizadorNuevoCentroTrabajo.CrearConexionNuevoCentroTrabajo())
            {
                service = new NuevoCentroTrabajoService(Gestion);
                return service.ConsultarNuevoCentroTrabajoDetalle(Busqueda.Busqueda, Busqueda.Division, Busqueda.Instancia, Busqueda.IdSistema, Busqueda.IdMunicipio, Busqueda.IdCentroTrabajo);
            }

            throw new Exception();
        }

        /// <summary>
        /// Endpoint para ejecutar procedimiento [catalogo].[sp_ObtenerNuevoCentroTrabajo_Relacion]
        /// </summary>
        /// <param name="Busqueda"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        //[Authorize]
        [HttpPost]
        [Route("api/Catalogos/ConsultarNuevoCentroTrabajoRelacion")]
        public List<NuevoCentroTrabajoDetalle> ConsultarNuevoCentroTrabajoRelacion([FromBody] string Relacion)
        {
            NuevoCentroTrabajoService service;

            using (var Gestion = FactorizadorNuevoCentroTrabajo.CrearConexionNuevoCentroTrabajo())
            {
                service = new NuevoCentroTrabajoService(Gestion);
                return service.ConsultarNuevoCentroTrabajoRelacion(Relacion);
            }

            throw new Exception();
        }

        //[Authorize]
        [HttpPost]
        [Route("api/Catalogos/ConsultarNuevoCentroTrabajoSeleccion")]
        public List<NuevoCentroTrabajoSeleccion> ConsultarNuevoCentroTrabajoSeleccion([FromBody] long IdSubCentroTrabajo)
        {
            NuevoCentroTrabajoService service;

            using (var Gestion = FactorizadorNuevoCentroTrabajo.CrearConexionNuevoCentroTrabajo())
            {
                service = new NuevoCentroTrabajoService(Gestion);
                return service.ConsultarNuevoCentroTrabajoSeleccion(IdSubCentroTrabajo);
            }

            throw new Exception();
        }
        [HttpPost]
        [Route("api/catalogos/NCT/plazasByNCT")]
        public IEnumerable<PlazaBase> ObtenerPlazasdeCentroTrabajo([FromBody] PlazaBase identifCT)
        {
            PlazaService service;
            using(var Gestion = FactorizadorPlaza.CrearConexion())
            {
                service = new PlazaService(Gestion);
                return service.ObtenerPlazasByCT(identifCT);
            }
        }
        //[Authorize]
        [HttpPost]
        [Route("api/Catalogos/ActualizarSistema")]
        public Boolean ActualizarSistema([FromBody] SistemaBase sistemaBase)
        {
            ModelGenericoService service;

            using (var Gestion = FactorizadorSistema.CrearConexionGenerica())
            {
                service = new ModelGenericoService(Gestion);
                return service.ActualizarCatalogoGenerico(sistemaBase.IdPrincipal, sistemaBase.DescripPrincipal);
            }

            throw new Exception();
        }

        //[Authorize]
        [HttpPost]
        [Route("api/Catalogos/ActualizarCentroTrabajo")]
        public Boolean ActualizarCentroTrabajo([FromBody] CentroTrabajoBase centroTrabajoBase)
        {
            ModelGenericoService service;

            using (var Gestion = FactorizadorCentroTrabajo.CrearConexionGenerica())
            {
                service = new ModelGenericoService(Gestion);
                return service.ActualizarCatalogoGenerico(centroTrabajoBase.IdPrincipal, centroTrabajoBase.DescripPrincipal);
            }

            throw new Exception();
        }

        //[Authorize]
        [HttpPost]
        [Route("api/Catalogos/ConsultarEscolaridades")]
        public IEnumerable<IBaseModel> ConsultarEscolaridades()
        {
            ModelGenericoService service;

            using (var Gestion = FactorizadorEscolaridad.CrearConexionGenerica())
            {
                service = new ModelGenericoService(Gestion);
                return service.ConsultarCatalogoGenerico();
            }

            throw new Exception();
        }

        //[Authorize]
        [HttpPost]
        [Route("api/Catalogos/ConsultarEstadosCiviles")]
        public IEnumerable<IBaseModel> ConsultarEstadosCiviles()
        {
            ModelGenericoService service;

            using (var Gestion = FactorizadorEstadoCivil.CrearConexionGenerica())
            {
                service = new ModelGenericoService(Gestion);
                return service.ConsultarCatalogoGenerico();
            }

            throw new Exception();
        }

        //[Authorize]
        [HttpPost]
        [Route("api/Catalogos/ConsultarEntidadesFederativas")]
        public IEnumerable<BaseModel> ConsultarEntidadesFederativas([FromBody] long IdPais)
        {
            ModelGenericoService service;

            using (var Gestion = FactorizadorEntidadFederativa.CrearConexionGenerica())
            {
                service = new ModelGenericoService(Gestion);
                return service.ConsultarCatalogoGenerico(IdPais);
            }

            throw new Exception();
        }

        //[Authorize]
        [HttpPost]
        [Route("api/Catalogos/ConsultarMunicipiosFiltroEstado")]
        public IEnumerable<BaseModel> ConsultarMunicipiosFiltroEstado([FromBody] long IdEstado)
        {
            ModelGenericoService service;

            using (var Gestion = FactorizadorMunicipio.CrearConexionGenerica())
            {
                service = new ModelGenericoService(Gestion);
                return service.ConsultarCatalogoGenerico(IdEstado);
            }

            throw new Exception();
        }

        //[Authorize]
        [HttpPost]
        [Route("api/Catalogos/ConsultarPaises")]
        public IEnumerable<IBaseModel> ConsultarPaises()
        {
            ModelGenericoService service;

            using (var Gestion = FactorizadorPais.CrearConexionGenerica())
            {
                service = new ModelGenericoService(Gestion);
                return service.ConsultarCatalogoGenerico();
            }

            throw new Exception();
        }

        //[Authorize]
        [HttpPost]
        [Route("api/Catalogos/ConsultarGeneros")] //Catalogos "sexos"
        public IEnumerable<IBaseModel> ConsultarGeneros()
        {
            ModelGenericoService service;

            using (var Gestion = FactorizadorGenero.CrearConexionGenerica())
            {
                service = new ModelGenericoService(Gestion);
                return service.ConsultarCatalogoGenerico();
            }

            throw new Exception();
        }

        //[Authorize]
        [HttpPost]
        [Route("api/Catalogos/ConsultarGruposSanguineos")] //Catalogos "Tipos Sangre"
        public IEnumerable<IBaseModel> ConsultarGruposSanguineos()
        {
            ModelGenericoService service;

            using (var Gestion = FactorizadorGrupoSanguineo.CrearConexionGenerica())
            {
                service = new ModelGenericoService(Gestion);
                return service.ConsultarCatalogoGenerico();
            }

            throw new Exception();
        }
        [HttpPost]
        [Route("api/Catalogos/Global/Obtener")] //Catalogos global
        public IEnumerable<CatalogoBaseModel> ObtenerListaItems([FromBody] CatalogoBaseModel esquema)
        {
            ModelGenericoService service;
            using (var Gestion = FactorizadorCatalogo.CrearConexionCatalogo())
            {
                service = new ModelGenericoService(Gestion);
                return service.ObtenerCatalogo(esquema);
            }
            throw new Exception();
        }

        [HttpPost]
        [Route("api/Catalogos/Global/AlmacenaPV")] //Catalogos global (Elimina existentes y guarda)
        public bool AlmacenaListaItems([FromBody] List<CatalogoBaseModel> lista)
        //public bool AlmacenaListaItems(JArray paramList)
        {
            //if (paramList.Count > 0)
            //{
            //    List<CatalogoBaseModel> lista = (List<CatalogoBaseModel>)JsonConvert.DeserializeObject(paramList[0].ToString());
            //    CatalogoBaseModel esquema = JsonConvert.DeserializeObject<CatalogoBaseModel>(paramList[1].ToString());
            ModelGenericoService service;
            using (var Gestion = FactorizadorCatalogo.CrearConexionCatalogo())
            {
                service = new ModelGenericoService(Gestion);
                return service.AlmacenaInformacionPrimeraVez(lista);
            }

            //}
            throw new Exception();
        }
    }
}
