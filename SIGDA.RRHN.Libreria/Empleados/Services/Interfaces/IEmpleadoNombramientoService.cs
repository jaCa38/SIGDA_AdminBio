using SIGDA.SRHN.Libreria.Empleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Empleados.Services.Interfaces
{
    public interface IEmpleadoNombramientoService: IDisposable
    {
        IEnumerable<BaseCandidato> BuscarCandidato(string nombre, string paterno, string materno);
        IEnumerable<BaseCandidato> BuscarCandidatoPorRFC(string rfc);
        IEnumerable<BaseCandidato> BuscarCandidatoPorCURP(string curp);
        IEnumerable<DomicilioBase> BuscarDomicilioCandidatoPorRFC(string rfc);
        IEnumerable<DomicilioBase> BuscarDomicilioCandidatoPorCURP(string curp);
        long InsertarNuevoEmpleado(EmpleadoNombramiento empleadoNombramiento, long IdMinerva);
        BaseEmpleado ObtenerUltimaActualizacionCV(long idEmpleado);
        int AlmacenaNuevoEmpleado(NuevoEmpleadoBase nuevoEmpleado);
        #region IDisposable Members
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
        #endregion
    }
}
