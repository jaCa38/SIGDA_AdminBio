using SIGDA.Catalogos.Genericos.Models;
using SIGDA.Catalogos.Genericos.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Catalogos.Genericos.Services
{
    public class NivelAcademicoService: INivelAcademicoService
    {
        private readonly INivelAcademicoService _metodosNivelAcademico;
        public NivelAcademicoService(INivelAcademicoService metodos)
        {
            _metodosNivelAcademico = metodos;
        }
        public void Dispose()
        {
            try { } catch (Exception) { }
        }

        public List<BaseModel> ObtenerEstatusEstudio()
        {
            return _metodosNivelAcademico.ObtenerEstatusEstudio();
        }

        public List<BaseModel> ObtenerNivelesAcademicos()
        {
            return _metodosNivelAcademico.ObtenerNivelesAcademicos();
        }
    }
}
