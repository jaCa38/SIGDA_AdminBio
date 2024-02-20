using SIGDA.Catalogos.Genericos.Interfaces;
using SIGDA.SRHN.Libreria.Empleados.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Empleados.Models
{
    public  class PlazaBase : IPlazaBase, IBaseModel
    {
        public int IdPlazaConsec { set; get; }
        public string IdentificadorNominaProgress { set; get; }
        public int IdPlazaNominaProgress { set; get; }
        public string Denominacion { set; get; }
        public string Funcion { set; get; }
        public string Nivel { set; get; }
        public int IdEstatusPlaza { set; get; }
        public string DescripcionEstatusPlaza { set; get; }
        /// <summary>
        /// IdSubCentroTrabajo
        /// </summary>
        public long IdPrincipal { get; set; }
        /// <summary>
        /// Descripción SubCentroTrabajo
        /// </summary>
        public string DescripPrincipal { get; set; }
    }
}
