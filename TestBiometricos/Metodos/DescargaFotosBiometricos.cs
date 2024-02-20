using SIGDA.CA.Biometricos.Libreria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBiometricos
{
    public static class DescargaFotosBiometricos
    {
        public static ApiControllers apiControllers = new ApiControllers();
        public static ApiFotosCotroller apiFotosCotroller = new ApiFotosCotroller();
        public static void DescargaFotosTodos()
        {
           
            List<InfoBiometrico> biometricos = new List<InfoBiometrico>();
            List<RegistrosRelojes> reloj = new List<RegistrosRelojes>();
            List<DateTime> dayList = new List<DateTime>();

            DateTime dayOne = DateTime.Now.AddDays(-1).AddHours(-(DateTime.Now.Hour)).AddMinutes(-(DateTime.Now.Minute)).AddSeconds(-(DateTime.Now.Second));
            // DateTime dayTwo = DateTime.Now.AddHours(-(DateTime.Now.Hour)).AddMinutes(-(DateTime.Now.Minute)).AddSeconds(-(DateTime.Now.Second));
            DateTime dayTwo = DateTime.Now.Date;

            dayList.Add(dayOne);
            dayList.Add(dayTwo);
             //DateTime testDay = Convert.ToDateTime("2024-02-11");
             //dayList.Add(testDay);
            //dayList.Add(dayTwo);

            biometricos = (List<InfoBiometrico>)apiControllers.ObtenerListaRelojes().Result;

            //var resultadoFotos = new FotosResualtado();


            if (biometricos != null && biometricos.ElementAt(0).ConexionEstatus)
            {
                if (biometricos != null && biometricos.ElementAt(0).ConexionEstatus)
                    foreach (InfoBiometrico bio in biometricos)
                        foreach (DateTime day in dayList)
                        {

                            FotosResualtado resultadoFotosOK = apiFotosCotroller.DescargaFotoOkBiometricos(day, bio.IpTerminal, bio.PortTerminal, bio.NombreTerminal).Result;
                            if (resultadoFotosOK.ConexionEstatus)
                            {


                                _ = apiFotosCotroller.InsertarLogFotosDescargaMSSQL(bio.IdTerminal, day, resultadoFotosOK.CantidadFotos, resultadoFotosOK.CantidadRegistros);
                            }
                            else
                            {
                                _ = apiControllers.InsertarLogErrorMSSQL(bio.IdTerminal, 2, day, resultadoFotosOK.MsjError);
                            }


                            FotosResualtado resultadoFotosSorry = apiFotosCotroller.DescargaFotoBioSorrymetricos(day, bio.IpTerminal, bio.PortTerminal, bio.NombreTerminal).Result;
                            if (resultadoFotosOK.ConexionEstatus)
                            {


                                _ = apiFotosCotroller.InsertarLogFotosDescargaMSSQL(bio.IdTerminal, day, resultadoFotosOK.CantidadFotos, resultadoFotosOK.CantidadRegistros);

                            }
                            else
                            {
                                _ = apiControllers.InsertarLogErrorMSSQL(bio.IdTerminal, 2, day, resultadoFotosOK.MsjError);

                            }


                        }
                else
                {
                    Console.WriteLine($"Error al acceder a la Db");
                }


            }

        }


    }
}
