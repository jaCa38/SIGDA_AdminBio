using SIGDA.SRHN.Libreria.Catalogos.Genericos.Enums;
using SIGDA.SRHN.Libreria.Catalogos.SubCentrosTrabajo.Models;
using SIGDA.SRHN.Libreria.Catalogos.SubCentrosTrabajo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Catalogos.SubCentrosTrabajo.Services
{
    public class SubCentroTrabajoService : ISubCentroTrabajoService
    {
        private readonly ISubCentroTrabajoService _metodos;
        public SubCentroTrabajoService(ISubCentroTrabajoService metodos)
        {
            _metodos = metodos;
        }
        public List<SubCentroTrabajoBase> ConsultarCatalogoGenerico()
        {
            return _metodos.ConsultarCatalogoGenerico();
        }

        public List<SubCentroTrabajoBase> ConsultarCatalogoGenerico(EDivision division, EInstancia instancia, long IdSistema, long IdMunicipio, long IdCentroTrabajo)
        {
            return _metodos.ConsultarCatalogoGenerico(division, instancia, IdSistema, IdMunicipio, IdCentroTrabajo);
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
    }
}
