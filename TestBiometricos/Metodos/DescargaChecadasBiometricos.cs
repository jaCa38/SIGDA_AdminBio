using SIGDA.CA.Biometricos.Libreria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBiometricos
{
    public static class DescargaChecadasBiometricos
    {
        public static ApiControllers apiControllers = new ApiControllers();
        public static void DescargaChecadasTodos()
        {
            

            List<InfoBiometrico> biometricos = new List<InfoBiometrico>();
            List<RegistrosRelojes> reloj = new List<RegistrosRelojes>();
            List<DateTime> dayList = new List<DateTime>();

            DateTime dayOne = DateTime.Now.AddDays(-1).Date;
            DateTime dayTwo = DateTime.Now.Date;


            //DateTime dayOne = DateTime.Now.AddDays(-1).AddHours(-(DateTime.Now.Hour)).AddMinutes(-(DateTime.Now.Minute)).AddSeconds(-(DateTime.Now.Second));
            //DateTime dayTwo = DateTime.Now.AddHours(-(DateTime.Now.Hour)).AddMinutes(-(DateTime.Now.Minute)).AddSeconds(-(DateTime.Now.Second));

            dayList.Add(dayOne);
            dayList.Add(dayTwo);

            biometricos = (List<InfoBiometrico>)apiControllers.ObtenerListaRelojes().Result;

            bool guardarLog;
            bool guardarRegistrosSICA;
            bool guardarRegistrosSIGDA;

            if (biometricos != null && biometricos.ElementAt(0).ConexionEstatus)
                foreach (InfoBiometrico bio in biometricos)
                    foreach (DateTime day in dayList)
                    {
                        reloj = (List<RegistrosRelojes>)apiControllers.ObternerRegistrosTerminalPorRango(bio.IpTerminal, bio.PortTerminal, day, day.AddHours(23).AddMinutes(59).AddSeconds(59)).Result;
                        if (reloj.Count > 0)
                            if (!reloj.ElementAt(0).ConexionReloj)
                            {
                                guardarLog = apiControllers.InsertarLogErrorMSSQL(bio.IdTerminal, 1, day, reloj.ElementAt(0).ErrorMsj).Result;
                                Console.WriteLine($"Terminal {bio.IdTerminal} sin conexion");
                            }
                            else
                                foreach (var registro in reloj)
                                {
                                    guardarRegistrosSICA = apiControllers.InsertarRegistroSICA(bio.IdTerminal, registro.IdEmpleado, registro.Record).Result;
                                    guardarRegistrosSIGDA = apiControllers.InsertarRegistroSIGDA(bio.IdTerminal, registro.IdEmpleado, registro.Record).Result;
                                    if (!guardarRegistrosSICA)
                                    {
                                        guardarLog = apiControllers.InsertarLogErrorMSSQL(bio.IdTerminal, 1, day, "no se pudo inserar registro").Result;

                                        Console.WriteLine($"Terminal {bio.IdTerminal} no posible insertar el registro en la db");
                                        
                                    }
                                    else
                                    {
                                        //controlar Errores
                                        guardarLog = apiControllers.InsertarLogAuditMSSQL(bio.IdTerminal, day, reloj.Count()).Result;
                                        Console.WriteLine($"Terminal {bio.IdTerminal} insertaron los registros correctamente");

                                    }
                                }
                        else
                        {
                            guardarLog = apiControllers.InsertarLogAuditMSSQL(bio.IdTerminal, day, 0).Result;
                            Console.WriteLine($"Terminal {bio.IdTerminal}No se obtuvo ningun registro del reloj log: {guardarLog}");
                        }
                    }
            else
                Console.WriteLine($"Error al acceder a la Db");

        }




    }
}
