using SIGDA.SRHN.Libreria.Empleados.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Empleados.Models
{
    public class BaseCandidato : IBaseCandidato
    {
        public long IdCandidato { get; set; }
        public string NombreCandidato { get; set; }
        public string PaternoCandidato { get; set; }
        public string MaternoCandidato { get; set; }
        public string Rfc { set; get; }
        public string Curp { set; get; }
        public string FechaNacimiento { set; get; }
        public int IdSexo { set; get; }
        public int IdEstadoNacimiento { set; get; }
        public int IdEstadoCivil { set; get; }
        public int IdTipoSanguineo { set; get; }
    }
}
