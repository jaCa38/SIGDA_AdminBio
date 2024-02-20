using SIGDA.SRHN.Libreria.Empleados.Models;
using SIGDA.SRHN.Libreria.Empleados.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Empleados.Services
{
    public class EmpleadoNombramientoService : IEmpleadoNombramientoService
    {
        private readonly IEmpleadoNombramientoService _metodos;        
        public EmpleadoNombramientoService(IEmpleadoNombramientoService metodos)
        {
            _metodos = metodos; 
        }
        
        public IEnumerable<BaseCandidato> BuscarCandidato(string nombre, string paterno, string materno)
        {
            return _metodos.BuscarCandidato(nombre, paterno, materno);
        }
       
        public long InsertarNuevoEmpleado(EmpleadoNombramiento empleadoNombramiento, long IdMinerva)
        {
            return _metodos.InsertarNuevoEmpleado(empleadoNombramiento,IdMinerva);
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

        public BaseEmpleado ObtenerUltimaActualizacionCV(long idEmpleado)
        {
            return _metodos.ObtenerUltimaActualizacionCV(idEmpleado);
        }

        public IEnumerable<BaseCandidato> BuscarCandidatoPorRFC(string rfc)
        {
            return _metodos.BuscarCandidatoPorRFC(rfc);
        }
        public IEnumerable<BaseCandidato> BuscarCandidatoPorCURP(string curp)
        {
            return _metodos.BuscarCandidatoPorCURP(curp);
        }

        public IEnumerable<DomicilioBase> BuscarDomicilioCandidatoPorRFC(string rfc)
        {
            return _metodos.BuscarDomicilioCandidatoPorRFC(rfc);
        }
        public IEnumerable<DomicilioBase> BuscarDomicilioCandidatoPorCURP(string curp)
        {
            return _metodos.BuscarDomicilioCandidatoPorCURP(curp);
        }
        public int AlmacenaNuevoEmpleado(NuevoEmpleadoBase informacion)
        {
            return _metodos.AlmacenaNuevoEmpleado(informacion);
        }
    }
}
