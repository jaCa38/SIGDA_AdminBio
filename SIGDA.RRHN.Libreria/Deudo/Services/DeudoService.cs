using SIGDA.Catalogos.Genericos.Models;
using SIGDA.SRHN.Libreria.Deudo.Models;
using SIGDA.SRHN.Libreria.Deudo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Deudo.Services
{
    public class DeudoService : IEstatusService, IRegistroService, ITipoRecuperacionService, ISeguimientoService, IDisposable
    {
        private readonly IEstatusService _metodosEstatus;
        private readonly IRegistroService _metodosRegistro;
        private readonly ITipoRecuperacionService _metodosTipoRecuperacion;
        private readonly ISeguimientoService _metodosSeguimiento;
        private readonly IDestinoService _metodosDestino;

        public DeudoService(IEstatusService metodosEstatus)
        {
            _metodosEstatus = metodosEstatus;
        }
        public DeudoService(IRegistroService metodosRegistro)
        {
            _metodosRegistro = metodosRegistro;
        }
        public DeudoService(ITipoRecuperacionService metodosTipoRecuperacion)
        {
            _metodosTipoRecuperacion = metodosTipoRecuperacion;
        }
        public DeudoService(ISeguimientoService metodosSeguimiento)
        {
            _metodosSeguimiento = metodosSeguimiento;
        }
        public DeudoService(IDestinoService metodosDestino)
        {
            _metodosDestino = metodosDestino;
        }       

        public bool AlmacenaRegistro(RegistroBase registro)
        {
            return _metodosRegistro.AlmacenaRegistro(registro);
        }

        public List<BaseModel> ConsultarCatalogoEstatus()
        {
            return _metodosEstatus.ConsultarCatalogoEstatus();
        }

        public List<BaseModel> ConsultarCatalogoTiposRecuperacion()
        {
            return _metodosTipoRecuperacion.ConsultarCatalogoTiposRecuperacion();
        }

        public List<RegistroBase> ConsultarRegistros()
        {
            return _metodosRegistro.ConsultarRegistros();   
        }

        public List<RegistroBase> ConsultarRegistrosFiltro(long idEmpleado)
        {
            return _metodosRegistro.ConsultarRegistrosFiltro(idEmpleado);
        }
      
        public bool EliminaRegistro(long idRegistro)
        {
            return _metodosRegistro.EliminaRegistro(idRegistro);
        }

        public bool ModificaRegistro(RegistroBase registro)
        {
            return _metodosRegistro.ModificaRegistro(registro);
        }
        public bool SaldarRegistro(RegistroBase registro)
        {
            return _metodosRegistro.SaldarRegistro(registro);
        }
        public List<SeguimientoBase> ConsultarSeguimiento(long idRegistro)
        {
            return _metodosSeguimiento.ConsultarSeguimiento(idRegistro);
        }

        public bool AlmacenarSeguimiento(SeguimientoBase seguimiento)
        {
            return _metodosSeguimiento.AlmacenarSeguimiento(seguimiento);
        }
        public List<BaseModel> ConsultarDestino()
        {
            return _metodosDestino.ConsultarCatalogoDestino();
        }
        public List<BaseModel> ConsultarDestinoHijo(long idItem)
        {
            return _metodosDestino.ConsultarCatalogoDestinoHijo(idItem);
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

        public bool ModificaAdeudoPendiente(RegistroBase registro)
        {
            return _metodosRegistro.ModificaAdeudoPendiente(registro);
        }
    }
}
