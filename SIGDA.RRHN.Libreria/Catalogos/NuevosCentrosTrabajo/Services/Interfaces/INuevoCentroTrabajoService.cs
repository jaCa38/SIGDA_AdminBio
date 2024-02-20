using SIGDA.Catalogos.Genericos.Models;
using SIGDA.SRHN.Libreria.Catalogos.Genericos.Enums;
using SIGDA.SRHN.Libreria.Catalogos.NuevosCentrosTrabajo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Catalogos.NuevosCentrosTrabajo.Services.Interfaces
{
    public interface INuevoCentroTrabajoService : IDisposable
    {
        bool InsertarNuevoCentroTrabajo(NuevoCentroTrabajoBase nuevoCentroTrabajoBase);
        bool ActivarNuevoCentroTrabajo(long Identificador);
        
        List<NuevoCentroTrabajoDetalle> ConsultarNuevoCentroTrabajoDetalle(long IdCentroTrabajo);
        List<NuevoCentroTrabajoDetalle> ConsultarNuevoCentroTrabajoDetalle(string busqueda);
        List<NuevoCentroTrabajoDetalle> ConsultarNuevoCentroTrabajoDetalle(string busqueda, EDivision division, EInstancia instancia, long IdSistema, long IdMunicipio, long IdCentroTrabajo);
        List<NuevoCentroTrabajoDetalle> ConsultarNuevoCentroTrabajoRelacion(string Relacion);
        List<NuevoCentroTrabajoSeleccion> ConsultarNuevoCentroTrabajoSeleccion(long IdSubCentroTrabajo);

        List<BaseModel> ObtenerDivision();
        List<BaseModel> ObtenerInstancias(EDivision division);
        List<BaseModel> ObtenerSistemas(EDivision division, EInstancia instancia);
        List<BaseModel> ObtenerMunicipios(EDivision division, EInstancia instancia, long idSistema);
        List<BaseModel> ConsultarNuevoCentroTrabajo(EDivision division, EInstancia instancia, long IdSistema, long IdMunicipio);
        //List<BaseModel> ConsultarNuevoCentroTrabajoDetalle(EDivision division, EInstancia instancia, long IdSistema, long IdMunicipio, long IdCentroTrabajo);



        #region IDisposable Members
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
        #endregion
    }
}
