using SIGDA.CA.Libreria.Punch.Models;
using SIGDA.CA.Punch.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.CA.Libreria.Punch.Services
{
    public class PunchService : IPunchService
    {
        private readonly IPunchService _metodos;
        public PunchService(IPunchService metodos)
        {
            _metodos = metodos;
        }

        public List<BasePunch> ConsultarInformacionCruda(DateTime fechaInicio, DateTime fechaFin)
        {
            return _metodos.ConsultarInformacionCruda(fechaInicio, fechaFin);
        }

        public List<BasePunch> ConsultarInformacionCrudaBiometrico(DateTime fechaInicio, DateTime fechaFin, long IdBiometrico)
        {
            return _metodos.ConsultarInformacionCrudaBiometrico(fechaInicio, fechaFin, IdBiometrico);
        }

        //public List<BasePunch> ConsultarInformacionCruda(DateTime fechaInicio, DateTime fechaFin, long IdBiometrico)
        //{
        //    return _metodos.ConsultarInformacionCruda(fechaInicio,fechaFin, IdBiometrico);
        //}

        public List<BasePunch> ConsultarInformacionCrudaEmpleado(DateTime fechaInicio, DateTime fechaFin, long IdEmpleado)
        {
            return _metodos.ConsultarInformacionCrudaEmpleado(fechaInicio, fechaFin, IdEmpleado);
        }

        public Boolean InsertarInformacionCruda(List<BasePunch> registros)
        {
            return _metodos.InsertarInformacionCruda(registros);
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
