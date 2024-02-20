using SIGDA.CA.Libreria.Punch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.CA.Punch.Services.Interfaces
{
    public interface IPunchService: IDisposable
    {
        List<BasePunch> ConsultarInformacionCruda(DateTime fechaInicio, DateTime fechaFin);

        List<BasePunch> ConsultarInformacionCrudaBiometrico(DateTime fechaInicio, DateTime fechaFin, long IdBiometrico);

        List<BasePunch> ConsultarInformacionCrudaEmpleado(DateTime fechaInicio, DateTime fechaFin, long IdEmpleado);
        public Boolean InsertarInformacionCruda(List<BasePunch> registros);

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
