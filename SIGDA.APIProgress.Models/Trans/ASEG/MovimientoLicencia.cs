using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.APIProgress.Models.Trans.ASEG
{
    public class MovimientoLicencia
    {
        public int IdQuincena { set; get; }
        public int Anio { set; get; }
        public int IdTrimestre { set; get; }
        public int IdEmpleado { set; get; }
        public string Nombre { set; get; }
        public int IdMovto { set; get; }
        public string DescripMovto { set; get; }
        public string Inicio { set; get; }
        public string Fin { set; get; }
        public int Dias { set; get; }
        public string UROrigen { set; get; }
        public string AreaOrigen { set; get; }
        public string MunicipioOrigen { set; get; }
        public string CTOrigen { set; get; }
        public string PlazaOrigen { set; get; }
        public string FuncionOrigen { set; get; }
        public string NivelOrigen { set; get; }
        public string URDestino { set; get; }
        public string AreaDestino { set; get; }
        public string MunicipioDestino { set; get; }
        public string CTDestino { set; get; }
        public string PlazaDestino { set; get; }
        public string FuncionDestino { set; get; }
        public string NivelDestino { set; get; }
    }
}
