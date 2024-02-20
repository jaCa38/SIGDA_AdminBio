using SIGDA.CA.Biometricos.Libreria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBiometricos.Metodos
{

    public static class AjusteHorarioBiometricos
    {
        public static ApiControllers apiControllers = new ApiControllers();
        public static ApiAdminBiometricos apiAdminBiometricos = new ApiAdminBiometricos();
        public static void AjustarHoraTerminales()
        {
            var biometricos = new List<InfoBiometrico>();
            var reloj = new List<RegistrosRelojes>();
            var dayList = new List<DateTime>();

            biometricos = (List<InfoBiometrico>)apiControllers.ObtenerListaRelojes().Result;

            bool guardarLog;
            //bool guardarRegistrosSICA;
            //bool guardarRegistrosSIGDA;

            if (biometricos != null && biometricos.ElementAt(0).ConexionEstatus)
            {

                foreach (InfoBiometrico bio in biometricos)
                {
                    var ajusteHorario = apiAdminBiometricos.AjusteHorarioBiometricos(bio.IpTerminal, bio.PortTerminal).Result;

                    if (!ajusteHorario.ConexionStatus)
                    {
                        guardarLog = apiControllers.InsertarLogErrorMSSQL(bio.IdTerminal, 3, DateTime.Now, ajusteHorario.ResultadoError).Result;
                        Console.WriteLine("No se pudo ajustar el Horario");
                    }
                    Console.WriteLine("Horario Ajustado");
                }

            }



        }
    }
}
