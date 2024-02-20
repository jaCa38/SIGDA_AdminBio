using SIGDA.SRHN.Libreria.ASF.Models;
using SIGDA.SRHN.Libreria.ASF.Services.Interfaces;
using SIGDA.SRHN.Libreria.Deudo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.ASF.Services
{
    public class ASFService : ICuotasService, INomOrdService, IDesafectacionService, IDisposable
    {
        private readonly ICuotasService _metodoCuotas;
        private readonly INomOrdService _metodosNomOrd;
        private readonly IDesafectacionService _metodosDesafectacion;
        public ASFService(ICuotasService metodosCuotas)
        {
            _metodoCuotas = metodosCuotas;
        }
        public ASFService(INomOrdService metodosNomOrd)
        {
            _metodosNomOrd = metodosNomOrd;
        }
        public ASFService(IDesafectacionService metodosDesafectacion)
        {
            _metodosDesafectacion = metodosDesafectacion;
        }

        public bool AlmacenaInformacion(EmpleadoDesafectacionBase encabezado, List<DetalleDesafectacion> detalle)
        {
            return _metodosDesafectacion.AlmacenaInformacion(encabezado, detalle);
        }

        public bool AlmacenarInformacion(List<CuotaISSEGISSSTEBase> cuotas)
        {
            return _metodoCuotas.AlmacenarInformacion(cuotas);
        }

        public List<EmpleadoDesafectacionBase> BuscarCoincidenciaEmpleado(EmpleadoDesafectacionBase empleado)
        {
            return _metodosDesafectacion.BuscarCoincidenciaEmpleado(empleado);
        }

        public void Dispose()
        {
            try { }
            catch (Exception) { }
        }

        public List<EmpleadoDesafectacionBase> Obtener(int anio)
        {
            return _metodosDesafectacion.Obtener(anio);
        }

        public List<CuotaISSEGISSSTEBase> ObtenerInformacion(CuotaISSEGISSSTEBase identificadorQna)
        {
            return _metodoCuotas.ObtenerInformacion(identificadorQna);
        }

        public List<ClaveMontoBase> ObtenerInformacionClavesMontos(int anio, long idGral)
        {
            return _metodosNomOrd.ObtenerInformacionClavesMontos(anio, idGral);
        }

        public List<EncabezadoNomOrdBase> ObtenerInformacionEncabezado(int anio)
        {
            return _metodosNomOrd.ObtenerInformacionEncabezado(anio);
        }        

        public EmpleadoDesafectacionBase ObtenerUno(long IdGeneral, int anio)
        {
            return _metodosDesafectacion.ObtenerUno(IdGeneral, anio);
        }
    }
}
