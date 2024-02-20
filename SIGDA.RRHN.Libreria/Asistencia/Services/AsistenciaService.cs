using SIGDA.SRHN.Libreria.Asistencia.Enums;
using SIGDA.SRHN.Libreria.Asistencia.Models;
using SIGDA.SRHN.Libreria.Asistencia.Services.Interfaces;
using SIGDA.SRHN.Libreria.Deudo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Asistencia.Services
{
    public class AsistenciaService : ICatalogoService, IDescuentoEmpleadoService, IDisposable
    {
        private readonly ICatalogoService _metodosCatalogoAsistencia;
        private readonly IDescuentoEmpleadoService _metodosDescuentoEmpleado;
        public AsistenciaService(ICatalogoService metodosCatalogoAsistencia)
        {
            _metodosCatalogoAsistencia = metodosCatalogoAsistencia;
        }
        public AsistenciaService(IDescuentoEmpleadoService metodosDescuentoEmpleado)
        {
            _metodosDescuentoEmpleado = metodosDescuentoEmpleado;
        }
        public List<CatalogoBase> ObtenerCatalogoAsistencia(ETipoCatalogo catalogo)
        {
            return _metodosCatalogoAsistencia.ObtenerCatalogoAsistencia(catalogo);
        }        
        public List<DescuentoEmpleadoBase> ObtenerListado(DescuentoEmpleadoBase descuentoEmpleado)
        {
            return _metodosDescuentoEmpleado.ObtenerListado(descuentoEmpleado);
        }
        public bool AlmacenarDescuentoEmpleado(DescuentoEmpleadoBase descuentoEmpleado)
        {
            return _metodosDescuentoEmpleado.AlmacenarDescuentoEmpleado(descuentoEmpleado);
        }
        public bool ModificaDescuentoEmpleado(DescuentoEmpleadoBase descuentoEmpleado)
        {
            return _metodosDescuentoEmpleado.ModificaDescuentoEmpleado(descuentoEmpleado);
        }
        public void Dispose()
        {
            try { } catch (Exception) { }
        }
    }
}
