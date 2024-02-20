using SIGDA.Catalogos.Genericos.Models;
using SIGDA.SRHN.Libreria.Catalogos.Genericos.Enums;
using SIGDA.SRHN.Libreria.Catalogos.NuevosCentrosTrabajo.Models;
using SIGDA.SRHN.Libreria.Catalogos.NuevosCentrosTrabajo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Catalogos.NuevosCentrosTrabajo.Services
{
    public class NuevoCentroTrabajoService : INuevoCentroTrabajoService
    {
        private readonly INuevoCentroTrabajoService _metodos;
        public NuevoCentroTrabajoService(INuevoCentroTrabajoService metodos)
        {
            _metodos = metodos;
        }
        public bool InsertarNuevoCentroTrabajo(NuevoCentroTrabajoBase nuevoCentroTrabajoBase)
        {
            return _metodos.InsertarNuevoCentroTrabajo(nuevoCentroTrabajoBase);
        }
        public bool ActivarNuevoCentroTrabajo(long Identificador)
        {
            return _metodos.ActivarNuevoCentroTrabajo(Identificador);
        }
        public List<BaseModel> ConsultarNuevoCentroTrabajo(EDivision division, EInstancia instancia, long IdSistema, long IdMunicipio)
        {
            return _metodos.ConsultarNuevoCentroTrabajo(division, instancia, IdSistema, IdMunicipio);
        }
      
        public List<NuevoCentroTrabajoDetalle> ConsultarNuevoCentroTrabajoDetalle(long IdCentroTrabajo)
        {
            return _metodos.ConsultarNuevoCentroTrabajoDetalle(IdCentroTrabajo);
        }

        public List<NuevoCentroTrabajoDetalle> ConsultarNuevoCentroTrabajoDetalle(string busqueda)
        {
            return _metodos.ConsultarNuevoCentroTrabajoDetalle(busqueda);
        }

        public List<NuevoCentroTrabajoDetalle> ConsultarNuevoCentroTrabajoDetalle(string busqueda, EDivision division, EInstancia instancia, long IdSistema, long IdMunicipio, long IdCentroTrabajo)
        {
            return _metodos.ConsultarNuevoCentroTrabajoDetalle(busqueda,division,instancia,IdSistema,IdMunicipio,IdCentroTrabajo);
        }

        public List<NuevoCentroTrabajoDetalle> ConsultarNuevoCentroTrabajoRelacion(string Relacion)
        {
            return _metodos.ConsultarNuevoCentroTrabajoRelacion(Relacion);
        }

        public List<NuevoCentroTrabajoSeleccion> ConsultarNuevoCentroTrabajoSeleccion(long IdSubCentroTrabajo)
        {
            return _metodos.ConsultarNuevoCentroTrabajoSeleccion(IdSubCentroTrabajo);
        }

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

        public List<BaseModel> ObtenerDivision()
        {
            return _metodos.ObtenerDivision();
        }

        public List<BaseModel> ObtenerInstancias(EDivision division)
        {
            return _metodos.ObtenerInstancias(division);
        }

        public List<BaseModel> ObtenerSistemas(EDivision division, EInstancia instancia)
        {
            return _metodos.ObtenerSistemas(division, instancia);
        }

        public List<BaseModel> ObtenerMunicipios(EDivision division, EInstancia instancia, long idSistema)
        {
            return _metodos.ObtenerMunicipios(division, instancia, idSistema);
        }

        //public List<BaseModel> ConsultarNuevoCentroTrabajoDetalle(EDivision division, EInstancia instancia, long IdSistema, long IdMunicipio, long IdCentroTrabajo)
        //{
        //    return _metodos.ConsultarNuevoCentroTrabajoDetalle(division, instancia, IdSistema, IdMunicipio, IdCentroTrabajo);
        //}
    }
}
