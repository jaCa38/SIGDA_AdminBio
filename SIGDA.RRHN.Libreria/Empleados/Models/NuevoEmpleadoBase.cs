using SIGDA.SRHN.Libreria.Empleados.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Empleados.Models
{
    public class NuevoEmpleadoBase
    {
        public NuevoEmpleadoBase()
        {
            DatosCandidato = new BaseCandidato();
            DatosDomicilio = new DomicilioBase();
            ListaTelefonos = new List<TelefonoBase>();
            CorreosElectronicos = new List<CorreoElectronicoBase>();
            DatosPuesto = new PuestoBase();
        }
        public int IdEmpleado { set; get; }
        public BaseCandidato DatosCandidato { set; get; }
        public DomicilioBase DatosDomicilio { set; get; }
        public List<TelefonoBase> ListaTelefonos { set; get; }
        public List<CorreoElectronicoBase> CorreosElectronicos { set; get; }
        public PuestoBase DatosPuesto { set; get; }       
    }
}
