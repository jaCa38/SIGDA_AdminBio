using SIGDA.CA.Biometricos.Libreria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.Remoting.Channels;
using System.Threading;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using Microsoft.Office.Interop.Excel;
using System.Security.Policy;
using SIGDA.CA.Biometricos.Libreria.Tools;
using TestBiometricos.Tools;
using Microsoft.Office.Core;
using TestBiometricos.Metodos;

namespace TestBiometricos
{
    internal class Program
    {
        //private static ApiEjecucionPaController apiEjecucionPa;
           public static void Main(string[] args)
          {
            
            Console.WriteLine("Panel de Control Biometricos\r\n");
            Console.WriteLine("Selecciona una Opcion");
            Console.WriteLine("1.- Descargar Todos los Relojes");
            Console.WriteLine("2.- Descargar Todas Las Fotodos");
            Console.WriteLine("3.- Ajustar Horario");

            int tareaSeleccion; 

            if (args.Length == 0)
            {
                tareaSeleccion = Convert.ToInt32(Console.ReadLine());
            }
            else
            {
                tareaSeleccion = Convert.ToInt32(args[0]);
            }


            switch(tareaSeleccion)
            {
                case 1:
                     _= 1;
                     DescargaChecadasBiometricos.DescargaChecadasTodos();
                     break;
                    case 2:
                    _= 2;
                     DescargaFotosBiometricos.DescargaFotosTodos();
                    break;     
                    case 3:
                    _=3;
                    AjusteHorarioBiometricos.AjustarHoraTerminales();
                    break;
            }       

          }




        #region Test Descarga Informacion Biometricos Por biometrico
        //static void Main(string[] args)
        //{
        //    ApiControllers apiControllers = new ApiControllers();

        //    InfoBiometrico Biometrico = new InfoBiometrico();
        //    List<RegistrosRelojes> Reloj = new List<RegistrosRelojes>();
        //    DateTime dateTime = Convert.ToDateTime( "2023-10-01");
        //    int IdTerminalBiometrica = 497;



        //    Biometrico = apiControllers.ObtenerInformacionTerminal(IdTerminalBiometrica).Result;

        //    if (Biometrico != null && Biometrico.ConexionEstatus == true)
        //    {
        //        while (dateTime <= Convert.ToDateTime("2023-10-31"))
        //        {
        //            Reloj = (List<RegistrosRelojes>)apiControllers.ObternerRegistrosTerminal(Biometrico.IpTerminal, Biometrico.PortTerminal, dateTime).Result;
        //            if (Reloj.Count > 0)
        //            {
        //                if (Reloj.ElementAt(0).ConexionReloj == false)
        //                {
        //                    bool logInsert = apiControllers.InsertarLogAudit(Biometrico.IdTerminal, dateTime, 0, 0, Reloj.ElementAt(0).ErrorMsj).Result;
        //                    Console.WriteLine($"Terminal {IdTerminalBiometrica} Estatus: sin conexion log Almacenado {logInsert}");
        //                    break;
        //                }
        //                else
        //                {

        //                    foreach (var registro in Reloj)
        //                    {
        //                        bool InsertRegistros = apiControllers.InsertarRegistro(IdTerminalBiometrica, registro.IdEmpleado, registro.Record).Result;

        //                    }

        //                    bool logInsert = apiControllers.InsertarLogAudit(Biometrico.IdTerminal, dateTime, Reloj.Count(), 1,"").Result;
        //                    Console.WriteLine($"Resgitros Guardatos, log:{logInsert}");

        //                }
        //            }
        //            else
        //            {
        //                bool logInsert = apiControllers.InsertarLogAudit(Biometrico.IdTerminal, dateTime, 0, 1, "").Result;
        //                Console.WriteLine($"No se obtuvo ningun registro del reloj log: {logInsert}");
        //            }
        //            dateTime = dateTime.AddDays(1);

        //        }
        //        }
        //    else
        //        {
        //        bool logInsert = apiControllers.InsertarLogAudit(Biometrico.IdTerminal, dateTime, 0, 0, "").Result;
        //        Console.WriteLine ( $"No se pudo obtener informacion del reloj en la base de datos log: {logInsert}");

        //        }

        //    Console.WriteLine("procesoTermino");
        //    Console.ReadKey();
        //}

        #endregion

        #region BorrarEmpleados Honorarios
        //static void Main(string[] args)
        //{


        //    ApiControllers apiControllers = new ApiControllers();


        //    Program program = new Program();
        //    List<Honorarios> empleadosHonorarios = new List<Honorarios>();
        //    List<EliminarBiometria> listaParaBorrar = new List<EliminarBiometria>();

        //    empleadosHonorarios = program.ObtenerEmpleadosHonorarios();
        //    var result = (List<InfoBiometrico>)apiControllers.ObtenerListaRelojes().Result;


        //    foreach (var item in result)
        //    {
        //        foreach (var h in empleadosHonorarios)
        //        {

        //            var resultadoV = apiControllers.ValidadBiometria(Int32.Parse(h.Id), item.IpTerminal, item.PortTerminal).Result;

        //            if (resultadoV.Resultado == true && resultadoV.ConexionStatus == true)
        //            {
        //                string BorradoJob = apiControllers.EliminarBiometria(Int32.Parse(h.Id), item.IpTerminal, item.PortTerminal).Result;
        //                program.EscribirBlock(Int32.Parse(h.Id), item.IdTerminal, true, true);
        //                Console.WriteLine($" Id:{h.Id} en Terminal: {item.IdTerminal} con biometria, resultado del borrado: {BorradoJob}");
        //                //listaParaBorrar.Add(new EliminarBiometria { Id = h.Id, IdTerminal = item.IdTerminal, Ip = item.IpTerminal });
        //            }
        //            else if (resultadoV.Resultado == false && resultadoV.ConexionStatus == true)
        //            {
        //                program.EscribirBlock(Int32.Parse(h.Id), item.IdTerminal, false, true);
        //                Console.WriteLine($" Id:{h.Id} en Terminal: {item.IdTerminal} no existe biometria, resultado del borrado: false");
        //            }
        //            else
        //            {
        //                program.EscribirBlock(Int32.Parse(h.Id), item.IdTerminal, false, false);
        //                Console.WriteLine($" Id:{h.Id} en Terminal: {item.IdTerminal} sin conexion, resultado del borrado: false");
        //                break;
        //            }

        //        }

        //    }







        //    Console.WriteLine("procesoTerminado");
        //    Console.ReadKey();
        //}

        //public List<Honorarios> ObtenerEmpleadosHonorarios()
        //{

        //    List<Honorarios> empleHonorarios = new List<Honorarios>();

        //    Excel.Application excelApp = new Excel.Application();
        //    Excel.Workbook excelWB = excelApp.Workbooks.Open(@"\\192.168.1.12\DescargaRegistrosBiometricos\Honorarios2023.xlsx");
        //    Excel._Worksheet excelWS = excelWB.Sheets[1];
        //    Excel.Range excelRange = excelWS.UsedRange;

        //    int rowCount = excelRange.Rows.Count;
        //    int columnCount = excelRange.Columns.Count;

        //    for (int i = 2; i <= rowCount; i++)
        //    {

        //        if (excelRange.Cells[i, 1] != null)


        //        {

        //            empleHonorarios.Add(new Honorarios { Id = excelRange.Cells[i, 1].Value2.ToString() });


        //            //Console.WriteLine(excelRange.Cells[i,1].Value2.ToString()+"\n");
        //        }

        //    }

        //    Marshal.ReleaseComObject(excelWS);
        //    Marshal.ReleaseComObject(excelRange);
        //    excelWB.Close();
        //    Marshal.ReleaseComObject(excelWB);
        //    excelApp.Quit();
        //    Marshal.ReleaseComObject(excelApp);




        //    return empleHonorarios;
        //}

        //public bool EscribirBlock(int idEmpleado, int IdTerminal, bool EstatusBorrado, bool ConexionEstatus)
        //{
        //    try
        //    {
        //        using (StreamWriter writer = new StreamWriter(@"\\192.168.1.12\DescargaRegistrosBiometricos\HonorariosBorrado.txt", append: true))
        //        {
        //            writer.WriteLine($"id={idEmpleado}, idTerminal = {IdTerminal}, EstatusBorrado = {EstatusBorrado}, ConexionEstatus = {ConexionEstatus}");
        //            return true;
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }

        //}
        //public class Honorarios
        //{
        //    public string Id { get; set; }
        //}

        //public class EliminarBiometria
        //{
        //    public string Id { get; set; }
        //    public int IdTerminal { get; set; }
        //    public string Ip { get; set; }
        //}
        #endregion

        #region Tarea de descarga biometricos
        //static void Main(string[] args)
        //{
        //    ApiControllers apiControllers = new ApiControllers();

        //    List<InfoBiometrico> biometricos = new List<InfoBiometrico>();
        //    List<RegistrosRelojes> reloj = new List<RegistrosRelojes>();
        //    List<DateTime> dayList = new List<DateTime>();

        //    DateTime dayOne = DateTime.Now.AddDays(-1).Date;
        //    DateTime dayTwo = DateTime.Now.Date;


        //    //DateTime dayOne = DateTime.Now.AddDays(-1).AddHours(-(DateTime.Now.Hour)).AddMinutes(-(DateTime.Now.Minute)).AddSeconds(-(DateTime.Now.Second));
        //    //DateTime dayTwo = DateTime.Now.AddHours(-(DateTime.Now.Hour)).AddMinutes(-(DateTime.Now.Minute)).AddSeconds(-(DateTime.Now.Second));

        //    dayList.Add(dayOne);
        //    dayList.Add(dayTwo);

        //    biometricos = (List<InfoBiometrico>)apiControllers.ObtenerListaRelojes().Result;

        //    bool guardarLog;
        //    bool guardarRegistrosSICA;
        //    bool guardarRegistrosSIGDA;

        //    if (biometricos != null && biometricos.ElementAt(0).ConexionEstatus)
        //        foreach (InfoBiometrico bio in biometricos)
        //            foreach (DateTime day in dayList)
        //            {
        //                reloj = (List<RegistrosRelojes>)apiControllers.ObternerRegistrosTerminalPorRango(bio.IpTerminal, bio.PortTerminal, day, day.AddHours(23).AddMinutes(59).AddSeconds(59)).Result;
        //                if (reloj.Count > 0)
        //                    if (!reloj.ElementAt(0).ConexionReloj)
        //                    {
        //                        guardarLog = apiControllers.InsertarLogErrorMSSQL(bio.IdTerminal, 1, day, reloj.ElementAt(0).ErrorMsj).Result;
        //                        Console.WriteLine($"Terminal {bio.IdTerminal} sin conexion");
        //                    }
        //                    else
        //                        foreach (var registro in reloj)
        //                        {
        //                            guardarRegistrosSICA = apiControllers.InsertarRegistroSICA(bio.IdTerminal, registro.IdEmpleado, registro.Record).Result;
        //                            guardarRegistrosSIGDA = apiControllers.InsertarRegistroSIGDA(bio.IdTerminal, registro.IdEmpleado, registro.Record).Result;
        //                            if (!guardarRegistrosSICA)
        //                            {
        //                                guardarLog = apiControllers.InsertarLogErrorMSSQL(bio.IdTerminal, 1, day, "no se pudo inserar registro").Result;

        //                                Console.WriteLine($"Terminal {bio.IdTerminal} no posible insertar el registro en la db");
        //                            }
        //                            else
        //                            {
        //                                //controlar Errores
        //                                guardarLog = apiControllers.InsertarLogAuditMSSQL(bio.IdTerminal, day, reloj.Count()).Result;
        //                                Console.WriteLine($"Terminal {bio.IdTerminal} insertaron los registros correctamente");
        //                            }
        //                        }
        //                else
        //                {
        //                    guardarLog = apiControllers.InsertarLogAuditMSSQL(bio.IdTerminal, day, 0).Result;
        //                    Console.WriteLine($"Terminal {bio.IdTerminal}No se obtuvo ningun registro del reloj log: {guardarLog}");
        //                }
        //            }
        //    else
        //        Console.WriteLine($"Error al acceder a la Db");


        //}
        #endregion

        #region Tarea Descarga Fotografias
        //static void Main(string[] args)
        //{
        //    ApiControllers apiControllers = new ApiControllers();
        //    ApiFotosCotroller apiFotosCotroller = new ApiFotosCotroller();
        //    List<InfoBiometrico> biometricos = new List<InfoBiometrico>();
        //    List<RegistrosRelojes> reloj = new List<RegistrosRelojes>();
        //    List<DateTime> dayList = new List<DateTime>();

        //    DateTime dayOne = DateTime.Now.AddDays(-1).AddHours(-(DateTime.Now.Hour)).AddMinutes(-(DateTime.Now.Minute)).AddSeconds(-(DateTime.Now.Second));
        //    // DateTime dayTwo = DateTime.Now.AddHours(-(DateTime.Now.Hour)).AddMinutes(-(DateTime.Now.Minute)).AddSeconds(-(DateTime.Now.Second));
        //    DateTime dayTwo = DateTime.Now.Date;

        //    dayList.Add(dayOne);
        //    dayList.Add(dayTwo);

        //    biometricos = (List<InfoBiometrico>)apiControllers.ObtenerListaRelojes().Result;

        //    //var resultadoFotos = new FotosResualtado();


        //    if (biometricos != null && biometricos.ElementAt(0).ConexionEstatus)
        //    {
        //        if (biometricos != null && biometricos.ElementAt(0).ConexionEstatus)
        //            foreach (InfoBiometrico bio in biometricos)
        //                foreach (DateTime day in dayList)
        //                {

        //                    FotosResualtado resultadoFotosOK = apiFotosCotroller.DescargaFotoOkBiometricos(day, bio.IpTerminal, bio.PortTerminal, bio.NombreTerminal).Result;
        //                    if (resultadoFotosOK.ConexionEstatus)
        //                    {


        //                        _ = apiFotosCotroller.InsertarLogFotosDescargaMSSQL(bio.IdTerminal, day, resultadoFotosOK.CantidadFotos, resultadoFotosOK.CantidadRegistros);
        //                    }
        //                    else
        //                    {
        //                        _ = apiControllers.InsertarLogErrorMSSQL(bio.IdTerminal, 2, day, resultadoFotosOK.MsjError);
        //                    }


        //                    FotosResualtado resultadoFotosSorry = apiFotosCotroller.DescargaFotoBioSorrymetricos(day, bio.IpTerminal, bio.PortTerminal, bio.NombreTerminal).Result;
        //                    if (resultadoFotosOK.ConexionEstatus)
        //                    {


        //                        _ = apiFotosCotroller.InsertarLogFotosDescargaMSSQL(bio.IdTerminal, day, resultadoFotosOK.CantidadFotos, resultadoFotosOK.CantidadRegistros);

        //                    }
        //                    else
        //                    {
        //                        _ = apiControllers.InsertarLogErrorMSSQL(bio.IdTerminal, 2, day, resultadoFotosOK.MsjError);

        //                    }


        //                }
        //        else
        //        {
        //            Console.WriteLine($"Error al acceder a la Db");
        //        }


        //    }

        //}
        #endregion


        #region Tarea Descarga Fotografias Prueba Por Terminal

        #endregion

        #region Tarea Descarga FotografiasTarea Prueba Por Fecha
        //static void Main(string[] args)
        //{
        //    ApiControllers apiControllers = new ApiControllers();
        //    ApiFotosCotroller apiFotosCotroller = new ApiFotosCotroller();
        //    List<InfoBiometrico> biometricos = new List<InfoBiometrico>();
        //    List<RegistrosRelojes> reloj = new List<RegistrosRelojes>();
        //    List<DateTime> dayList = new List<DateTime>();

        //    //DateTime dayOne = DateTime.Now.AddDays(-1).AddHours(-(DateTime.Now.Hour)).AddMinutes(-(DateTime.Now.Minute)).AddSeconds(-(DateTime.Now.Second));
        //    // DateTime dayTwo = DateTime.Now.AddHours(-(DateTime.Now.Hour)).AddMinutes(-(DateTime.Now.Minute)).AddSeconds(-(DateTime.Now.Second));
        //    //DateTime dayTwo = DateTime.Now.Date;
        //    DateTime dayOne = Convert.ToDateTime("2023-12-05");
        //    dayList.Add(dayOne);
        //    //dayList.Add(dayTwo);

        //    biometricos = (List<InfoBiometrico>)apiControllers.ObtenerListaRelojes().Result;

        //    //var resultadoFotos = new FotosResualtado();


        //    if (biometricos != null && biometricos.ElementAt(0).ConexionEstatus)
        //    {
        //        if (biometricos != null && biometricos.ElementAt(0).ConexionEstatus)
        //            foreach (InfoBiometrico bio in biometricos)
        //                foreach (DateTime day in dayList)
        //                {

        //                    FotosResualtado resultadoFotosOK = apiFotosCotroller.DescargaFotoOkBiometricos(day, bio.IpTerminal, bio.PortTerminal, bio.NombreTerminal).Result;
        //                    if (resultadoFotosOK.ConexionEstatus)
        //                    {


        //                        _ = apiFotosCotroller.InsertarLogFotosDescargaMSSQL(bio.IdTerminal, day, resultadoFotosOK.CantidadFotos, resultadoFotosOK.CantidadRegistros);
        //                    }
        //                    else
        //                    {
        //                        _ = apiControllers.InsertarLogErrorMSSQL(bio.IdTerminal, 2, day, resultadoFotosOK.MsjError);
        //                    }


        //                    FotosResualtado resultadoFotosSorry = apiFotosCotroller.DescargaFotoBioSorrymetricos(day, bio.IpTerminal, bio.PortTerminal, bio.NombreTerminal).Result;
        //                    if (resultadoFotosOK.ConexionEstatus)
        //                    {


        //                        _ = apiFotosCotroller.InsertarLogFotosDescargaMSSQL(bio.IdTerminal, day, resultadoFotosOK.CantidadFotos, resultadoFotosOK.CantidadRegistros);

        //                    }
        //                    else
        //                    {
        //                        _ = apiControllers.InsertarLogErrorMSSQL(bio.IdTerminal, 2, day, resultadoFotosOK.MsjError);

        //                    }


        //                }
        //        else
        //        {
        //            Console.WriteLine($"Error al acceder a la Db");
        //        }


        //    }
        //    Console.WriteLine("procesoTerminado");
        //    Console.ReadKey();

        //}
        #endregion


        #region Envio de Biometria Empleado

        //static void Main(string[] args) {
        //BiometriaEmpleado biometriaEmpleado = new BiometriaEmpleado();

        //ApiBiometriasController biometria = new ApiBiometriasController();


        //    biometriaEmpleado = biometria.DescargaBiometriaEmpleado(41399, "172.12.1.27", 9922).Result;


        //    _ = biometria.GuardarBiometriaReloj("10.11.1.204", 9922, biometriaEmpleado.Template); 



        //}




        #endregion

        #region Descarga Registros de Biometricos por Rango de Fecha
        //static void Main(string[] args)
        //{
        //    ApiControllers apiControllers = new ApiControllers();

        //    List<InfoBiometrico> biometricos = new List<InfoBiometrico>();
        //    List<RegistrosRelojes> reloj = new List<RegistrosRelojes>();
        //    List<DateTime> dayList = new List<DateTime>();

        //    //DateTime dayOne = DateTime.Now.AddDays(-1).Date;
        //    //DateTime dayTwo = DateTime.Now.Date;


        //    //DateTime dayOne = DateTime.Now.AddDays(-1).AddHours(-(DateTime.Now.Hour)).AddMinutes(-(DateTime.Now.Minute)).AddSeconds(-(DateTime.Now.Second));
        //    //DateTime dayTwo = DateTime.Now.AddHours(-(DateTime.Now.Hour)).AddMinutes(-(DateTime.Now.Minute)).AddSeconds(-(DateTime.Now.Second));

        //    //dayList.Add(dayOne);
        //    //dayList.Add(dayTwo);

        //    Console.WriteLine("Ingresa la fecha de incio:");
        //    DateTime dayOne = Convert.ToDateTime(Console.ReadLine().Trim());

        //    Console.WriteLine("Ingresa la fecha de Final:");
        //    DateTime dayTwo = Convert.ToDateTime(Console.ReadLine().Trim()); ;
        //    //DateTime dayOne = DateTime.Now.AddDays(-1).Date;
        //    //DateTime dayTwo = DateTime.Now.Date;

        //    for (var i = dayOne; i <= dayTwo; i = i.AddDays(1))
        //    {
        //        dayList.Add(i);
        //    }


        //    biometricos = (List<InfoBiometrico>)apiControllers.ObtenerListaRelojes().Result;

        //    bool guardarLog;
        //    bool guardarRegistrosSICA;
        //    bool guardarRegistrosSIGDA;

        //    if (biometricos != null && biometricos.ElementAt(0).ConexionEstatus)
        //    {
        //        foreach (InfoBiometrico bio in biometricos)
        //        {
        //            foreach (DateTime day in dayList)
        //            {
        //                reloj = (List<RegistrosRelojes>)apiControllers.ObternerRegistrosTerminalPorRango(bio.IpTerminal, bio.PortTerminal, day, day.AddHours(23).AddMinutes(59).AddSeconds(59)).Result;
        //                if (reloj.Count > 0)
        //                    if (!reloj.ElementAt(0).ConexionReloj)
        //                    {
        //                        guardarLog = apiControllers.InsertarLogErrorMSSQL(bio.IdTerminal, 1, day, reloj.ElementAt(0).ErrorMsj).Result;
        //                        Console.WriteLine($"Terminal {bio.IdTerminal} sin conexion");
        //                    }
        //                    else
        //                        foreach (var registro in reloj)
        //                        {
        //                            guardarRegistrosSICA = apiControllers.InsertarRegistroSICA(bio.IdTerminal, registro.IdEmpleado, registro.Record).Result;
        //                            guardarRegistrosSIGDA = apiControllers.InsertarRegistroSIGDA(bio.IdTerminal, registro.IdEmpleado, registro.Record).Result;
        //                            if (!guardarRegistrosSICA)
        //                            {
        //                                guardarLog = apiControllers.InsertarLogErrorMSSQL(bio.IdTerminal, 1, day, "no se pudo inserar registro").Result;

        //                                Console.WriteLine($"Terminal {bio.IdTerminal} no posible insertar el registro en la db");
        //                            }
        //                            else
        //                            {
        //                                //controlar Errores
        //                                guardarLog = apiControllers.InsertarLogAuditMSSQL(bio.IdTerminal, day, reloj.Count()).Result;
        //                                Console.WriteLine($"Terminal {bio.IdTerminal} insertaron los registros correctamente");
        //                            }
        //                        }
        //                else
        //                {
        //                    guardarLog = apiControllers.InsertarLogAuditMSSQL(bio.IdTerminal, day, 0).Result;
        //                    Console.WriteLine($"Terminal {bio.IdTerminal}No se obtuvo ningun registro del reloj log: {guardarLog}");
        //                }
        //            }


        //        }


        //            Console.WriteLine("Ejecutando Procesamiento de informacion");
        //            apiEjecucionPa = new ApiEjecucionPaController();
        //            var resultadoEjecucionPa = apiEjecucionPa.EjecutaPaDbProcesarInfoSICA();
        //            resultadoEjecucionPa.Wait();
        //            Console.WriteLine("se termino de procesar la informacion");
        //            Console.ReadLine();


        //    }
        //    else
        //    {
        //        Console.WriteLine($"Error al acceder a la Db");
        //    }

        //}
        #endregion


        #region Descarga Registros de Biometricos por Terminal
        //static void Main(string[] args)
        //{
        //    ApiControllers apiControllers = new ApiControllers();
        //    ApiEjecucionPaController apiEjecucionPa = new ApiEjecucionPaController();

        //    List<InfoBiometrico> biometricos = new List<InfoBiometrico>();
        //    List<RegistrosRelojes> reloj = new List<RegistrosRelojes>();
        //    List<DateTime> dayList = new List<DateTime>();
        //    int idTerminalBiometrica;
        //    //DateTime dayOne = DateTime.Now.AddDays(-1).Date;
        //    //DateTime dayTwo = DateTime.Now.Date;


        //    //DateTime dayOne = DateTime.Now.AddDays(-1).AddHours(-(DateTime.Now.Hour)).AddMinutes(-(DateTime.Now.Minute)).AddSeconds(-(DateTime.Now.Second));
        //    //DateTime dayTwo = DateTime.Now.AddHours(-(DateTime.Now.Hour)).AddMinutes(-(DateTime.Now.Minute)).AddSeconds(-(DateTime.Now.Second));

        //    //dayList.Add(dayOne);
        //    //dayList.Add(dayTwo);
        //    Console.WriteLine("Ingresa el id de la terminal:");
        //    idTerminalBiometrica = Convert.ToInt32(Console.ReadLine().Trim());

        //    Console.WriteLine("Ingresa la fecha de incio:");
        //    DateTime dayOne = Convert.ToDateTime(Console.ReadLine().Trim());

        //    Console.WriteLine("Ingresa la fecha de Final:");
        //    DateTime dayTwo = Convert.ToDateTime(Console.ReadLine().Trim()); ;
        //    //DateTime dayOne = DateTime.Now.AddDays(-1).Date;
        //    //DateTime dayTwo = DateTime.Now.Date;

        //    Console.WriteLine("Ejecutar Procedimiento NO = 0, Si = 1");
        //    int ejecutarPa = Convert.ToInt32(Console.ReadLine().Trim());

        //    for (var i = dayOne; i <= dayTwo; i = i.AddDays(1))
        //    {
        //        dayList.Add(i);
        //    }





        //    biometricos = (List<InfoBiometrico>)apiControllers.ObtenerListaRelojes().Result;

        //    bool guardarLog;
        //    bool guardarRegistrosSICA;
        //    bool guardarRegistrosSIGDA;

        //    if (biometricos != null && biometricos.ElementAt(0).ConexionEstatus)
        //    {

        //        var datosBiometrico = from id in biometricos where id.IdTerminal == idTerminalBiometrica select id;





        //        foreach (InfoBiometrico bio in datosBiometrico)
        //            foreach (DateTime day in dayList)
        //            {

        //                reloj = (List<RegistrosRelojes>)apiControllers.ObternerRegistrosTerminalPorRango(bio.IpTerminal, bio.PortTerminal, day, day.AddHours(23).AddMinutes(59).AddSeconds(59)).Result;
        //                if (reloj.Count > 0)
        //                {
        //                    if (!reloj.ElementAt(0).ConexionReloj)
        //                    {
        //                        guardarLog = apiControllers.InsertarLogErrorMSSQL(bio.IdTerminal, 1, day, reloj.ElementAt(0).ErrorMsj).Result;
        //                        Console.WriteLine($"Terminal {bio.IdTerminal} sin conexion");
        //                    }
        //                    else
        //                    {
        //                        foreach (var registro in reloj)
        //                        {
        //                            guardarRegistrosSICA = apiControllers.InsertarRegistroSICA(bio.IdTerminal, registro.IdEmpleado, registro.Record).Result;
        //                            guardarRegistrosSIGDA = apiControllers.InsertarRegistroSIGDA(bio.IdTerminal, registro.IdEmpleado, registro.Record).Result;
        //                            if (!guardarRegistrosSICA)
        //                            {
        //                                guardarLog = apiControllers.InsertarLogErrorMSSQL(bio.IdTerminal, 1, day, "no se pudo inserar registro").Result;

        //                                Console.WriteLine($"Terminal {bio.IdTerminal} no posible insertar el registro en la db");
        //                            }
        //                            else
        //                            {
        //                                //controlar Errores
        //                                guardarLog = apiControllers.InsertarLogAuditMSSQL(bio.IdTerminal, day, reloj.Count()).Result;
        //                                Console.WriteLine($"Terminal {bio.IdTerminal} insertaron los registros correctamente");


        //                            }




        //                        }


        //                    }
        //                }
        //                else
        //                {
        //                    guardarLog = apiControllers.InsertarLogAuditMSSQL(bio.IdTerminal, day, 0).Result;
        //                    Console.WriteLine($"Terminal {bio.IdTerminal}No se obtuvo ningun registro del reloj log: {guardarLog}");
        //                }
        //            }

        //        if (ejecutarPa == 1)
        //        {
        //            //int prueba = 2;
        //            //int prueba2 = 41399;
        //            //DateTime prueba3 = DateTime.Now;

        //            Console.WriteLine("Ejecutando Procesamiento de informacion");
        //            apiEjecucionPa = new ApiEjecucionPaController();
        //            var resultadoEjecucionPa = apiEjecucionPa.EjecutaPaDbProcesarInfoSICA();
        //            resultadoEjecucionPa.Wait();


        //            Console.WriteLine("se termino de procesar la informacion");
        //            Console.ReadLine();
        //        }


        //    }
        //    else
        //        Console.WriteLine($"Error al acceder a la Db");


        //}



        #endregion


        #region Tarea Descarga Fotografias por fecha
        //static void Main(string[] args)
        //{
        //    ApiControllers apiControllers = new ApiControllers();
        //    ApiFotosCotroller apiFotosCotroller = new ApiFotosCotroller();
        //    List<InfoBiometrico> biometricos = new List<InfoBiometrico>();
        //    List<RegistrosRelojes> reloj = new List<RegistrosRelojes>();
        //    List<DateTime> dayList = new List<DateTime>();

        //    //DateTime dayOne = DateTime.Now.AddDays(-1).AddHours(-(DateTime.Now.Hour)).AddMinutes(-(DateTime.Now.Minute)).AddSeconds(-(DateTime.Now.Second));
        //    // DateTime dayTwo = DateTime.Now.AddHours(-(DateTime.Now.Hour)).AddMinutes(-(DateTime.Now.Minute)).AddSeconds(-(DateTime.Now.Second));
        //    // DateTime dayTwo = DateTime.Now.Date;

        //    //dayList.Add(dayOne);
        //    //dayList.Add(dayTwo);


        //    Console.WriteLine("Ingresa la fecha de incio:");
        //    DateTime dayOne = Convert.ToDateTime(Console.ReadLine().Trim());

        //    Console.WriteLine("Ingresa la fecha de Final:");
        //    DateTime dayTwo = Convert.ToDateTime(Console.ReadLine().Trim()); ;
        //    //DateTime dayOne = DateTime.Now.AddDays(-1).Date;
        //    //DateTime dayTwo = DateTime.Now.Date;

        //    for (var i = dayOne; i <= dayTwo; i = i.AddDays(1))
        //    {
        //        dayList.Add(i);
        //    }



        //    biometricos = (List<InfoBiometrico>)apiControllers.ObtenerListaRelojes().Result;

        //    //var resultadoFotos = new FotosResualtado();


        //    if (biometricos != null && biometricos.ElementAt(0).ConexionEstatus)
        //    {

        //        foreach (InfoBiometrico bio in biometricos)
        //        {

        //            foreach (DateTime day in dayList)
        //            {

        //                FotosResualtado resultadoFotosOK = apiFotosCotroller.DescargaFotoOkBiometricos(day, bio.IpTerminal, bio.PortTerminal, bio.NombreTerminal).Result;
        //                if (resultadoFotosOK.ConexionEstatus)
        //                {


        //                    _ = apiFotosCotroller.InsertarLogFotosDescargaMSSQL(bio.IdTerminal, day, resultadoFotosOK.CantidadFotos, resultadoFotosOK.CantidadRegistros);



        //                    FotosResualtado resultadoFotosSorry = apiFotosCotroller.DescargaFotoBioSorrymetricos(day, bio.IpTerminal, bio.PortTerminal, bio.NombreTerminal).Result;
        //                    if (resultadoFotosOK.ConexionEstatus)
        //                    {


        //                        _ = apiFotosCotroller.InsertarLogFotosDescargaMSSQL(bio.IdTerminal, day, resultadoFotosOK.CantidadFotos, resultadoFotosOK.CantidadRegistros);

        //                    }
        //                    else
        //                    {
        //                        _ = apiControllers.InsertarLogErrorMSSQL(bio.IdTerminal, 2, day, resultadoFotosOK.MsjError);

        //                    }


        //                }
        //                else
        //                {
        //                    _ = apiControllers.InsertarLogErrorMSSQL(bio.IdTerminal, 2, day, resultadoFotosOK.MsjError);
        //                    break;
        //                }


        //            }





        //        }



        //    }
        //    else
        //    {
        //        Console.WriteLine($"Error al acceder a la Db");
        //    }









        //}

        #endregion


        #region Tarea Descarga Fotografias por Terminal
        //static void Main(string[] args)
        //{
        //    ApiControllers apiControllers = new ApiControllers();
        //    ApiFotosCotroller apiFotosCotroller = new ApiFotosCotroller();
        //    List<InfoBiometrico> biometricos = new List<InfoBiometrico>();
        //    List<RegistrosRelojes> reloj = new List<RegistrosRelojes>();
        //    List<DateTime> dayList = new List<DateTime>();
        //    int idTerminalBiometrica;

        //    //DateTime dayOne = DateTime.Now.AddDays(-1).AddHours(-(DateTime.Now.Hour)).AddMinutes(-(DateTime.Now.Minute)).AddSeconds(-(DateTime.Now.Second));
        //    // DateTime dayTwo = DateTime.Now.AddHours(-(DateTime.Now.Hour)).AddMinutes(-(DateTime.Now.Minute)).AddSeconds(-(DateTime.Now.Second));
        //    // DateTime dayTwo = DateTime.Now.Date;

        //    //dayList.Add(dayOne);
        //    //dayList.Add(dayTwo);

        //    Console.WriteLine("Ingresa el id de la terminal:");
        //    idTerminalBiometrica = Convert.ToInt32(Console.ReadLine().Trim());

        //    Console.WriteLine("Ingresa la fecha de incio:");
        //    DateTime dayOne = Convert.ToDateTime(Console.ReadLine().Trim());

        //    Console.WriteLine("Ingresa la fecha de Final:");
        //    DateTime dayTwo = Convert.ToDateTime(Console.ReadLine().Trim()); ;
        //    //DateTime dayOne = DateTime.Now.AddDays(-1).Date;
        //    //DateTime dayTwo = DateTime.Now.Date;

        //    for (var i = dayOne; i <= dayTwo; i = i.AddDays(1))
        //    {
        //        dayList.Add(i);
        //    }



        //    biometricos = (List<InfoBiometrico>)apiControllers.ObtenerListaRelojes().Result;

        //    //var resultadoFotos = new FotosResualtado();


        //    if (biometricos != null && biometricos.ElementAt(0).ConexionEstatus)
        //    {

        //        var datosBiometrico = from id in biometricos where id.IdTerminal == idTerminalBiometrica select id;

        //        foreach (InfoBiometrico bio in datosBiometrico)
        //        {
        //            foreach (DateTime day in dayList)
        //            {

        //                FotosResualtado resultadoFotosOK = apiFotosCotroller.DescargaFotoOkBiometricos(day, bio.IpTerminal, bio.PortTerminal, bio.NombreTerminal).Result;
        //                if (resultadoFotosOK.ConexionEstatus)
        //                {


        //                    _ = apiFotosCotroller.InsertarLogFotosDescargaMSSQL(bio.IdTerminal, day, resultadoFotosOK.CantidadFotos, resultadoFotosOK.CantidadRegistros);
        //                }
        //                else
        //                {
        //                    _ = apiControllers.InsertarLogErrorMSSQL(bio.IdTerminal, 2, day, resultadoFotosOK.MsjError);
        //                }


        //                FotosResualtado resultadoFotosSorry = apiFotosCotroller.DescargaFotoBioSorrymetricos(day, bio.IpTerminal, bio.PortTerminal, bio.NombreTerminal).Result;
        //                if (resultadoFotosOK.ConexionEstatus)
        //                {


        //                    _ = apiFotosCotroller.InsertarLogFotosDescargaMSSQL(bio.IdTerminal, day, resultadoFotosOK.CantidadFotos, resultadoFotosOK.CantidadRegistros);

        //                }
        //                else
        //                {
        //                    _ = apiControllers.InsertarLogErrorMSSQL(bio.IdTerminal, 2, day, resultadoFotosOK.MsjError);

        //                }


        //            }
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Error al acceder a la Db");
        //    }


        //}


        #endregion


        #region Extraer y enviar Biometria Empleado
        //static void Main(string[] args)
        //{
        //    ApiControllers apiControllers = new ApiControllers();
        //    ApiFotosCotroller apiFotosCotroller = new ApiFotosCotroller();
        //    ApiBiometriasController apiBiometriasController = new ApiBiometriasController();
        //    List<InfoBiometrico> biometricos = new List<InfoBiometrico>();
        //    List<RegistrosRelojes> reloj = new List<RegistrosRelojes>();
        //    List<DateTime> dayList = new List<DateTime>();
        //    int idEmpleado = 42329;
        //    string ipTerminal = "ocampojuzgadomenor.dyndns.biz";
        //    int portTerminal = 9922;

        //    //DateTime dayOne = DateTime.Now.AddDays(-1).AddHours(-(DateTime.Now.Hour)).AddMinutes(-(DateTime.Now.Minute)).AddSeconds(-(DateTime.Now.Second));
        //    // DateTime dayTwo = DateTime.Now.AddHours(-(DateTime.Now.Hour)).AddMinutes(-(DateTime.Now.Minute)).AddSeconds(-(DateTime.Now.Second));
        //    // DateTime dayTwo = DateTime.Now.Date;

        //    //dayList.Add(dayOne);
        //    //dayList.Add(dayTwo);

        //    ipTerminal = HerramientasIp.ComprobarDireccionDeRed(ipTerminal);

        //    var listaEmpleadosTerminalBiometrica = (List<int>)apiBiometriasController.ObtenerListadoEmpleadosTerminalBiometrica(ipTerminal, portTerminal).Result;



        //    if (listaEmpleadosTerminalBiometrica.Count() > 0)
        //    {
        //        ConfiguracionBiometrico DetallesTerminalBiometrica = apiBiometriasController.ObtenerConfiguracionTerminalBiometrica(ipTerminal, portTerminal).Result;

        //        var biometriaEmpleado = apiBiometriasController.DescargaBiometriaEmpleado(idEmpleado, ipTerminal, portTerminal, long.Parse(DetallesTerminalBiometrica.Sn)).Result;

        //        bool enviarBiometria = apiBiometriasController.GuardarBiometriaReloj(ipTerminal, portTerminal, biometriaEmpleado.Template).Result;
        //    }
        //    else
        //    {
        //        Console.WriteLine("No se obtuvo ningun empleado");

        //    }






        //    //var resultadoFotos = new FotosResualtado();





        // }





        //static void Main(string[] args)
        //{
        //    var apiControllers = new ApiControllers();
        //    var apiFotosCotroller = new ApiFotosCotroller();
        //    var apiBiometriasController = new ApiBiometriasController();
        //    var apiAdminBio = new ApiAdminBiometricos();
        //    var apiQueryDb = new ApiConsultarDbController();
        //    var biometricos = new List<InfoBiometrico>();
        //    var reloj = new List<RegistrosRelojes>();


        //    //int idEmpleado = 42329;
        //    //string ipTerminal = "ocampojuzgadomenor.dyndns.biz";
        //    //int portTerminal = 9922;
        //    //int idTerminal = 140;

        //    //DateTime dayOne = DateTime.Now.AddDays(-1).AddHours(-(DateTime.Now.Hour)).AddMinutes(-(DateTime.Now.Minute)).AddSeconds(-(DateTime.Now.Second));
        //    // DateTime dayTwo = DateTime.Now.AddHours(-(DateTime.Now.Hour)).AddMinutes(-(DateTime.Now.Minute)).AddSeconds(-(DateTime.Now.Second));
        //    // DateTime dayTwo = DateTime.Now.Date;

        //    //dayList.Add(dayOne);
        //    //dayList.Add(dayTwo);


        //    Console.WriteLine("Ingresar el numero de Empleado");
        //    var idEmpleado = Convert.ToInt32(Console.ReadLine().Trim());

        //    Console.WriteLine("Ingrese id de la terminal a la que desea enviar la biometria");
        //    var identificadorTerminal = Convert.ToInt32(Console.ReadLine().Trim());

        //    var infoTerminalBio = apiControllers.ObtenerInformacionTerminal(identificadorTerminal).Result;



        //    var ipTerminal = HerramientasIp.ComprobarDireccionDeRed(infoTerminalBio.IpTerminal);


        //    var fw = apiAdminBio.ConfiguracionTerminalBiometrica(ipTerminal, infoTerminalBio.PortTerminal).Result;
        //    var listaDeBiometrias = apiQueryDb.ObtenerListaDeBiometriasDb(idEmpleado, fw.Fw).Result;

        //    int loop = 0;
        //    foreach (ListaBiometriasEmpleado bio in listaDeBiometrias)
        //    {

        //        Console.WriteLine($"{loop}.-  Identificador:{bio.Id}, Descripcion: {bio.Descripcion}");


        //        loop++;
        //    }
        //    bool resultadoEnvio = false;
        //    while (resultadoEnvio == false)
        //    {

        //        Console.WriteLine($"Selecciona la biometria de la terminal que deseas Enviar:");
        //        var idSeleccion = Convert.ToInt32(Console.ReadLine());

        //        var estatusEnvioBio = apiBiometriasController.EnviarBiometriaBio(infoTerminalBio.IpTerminal, infoTerminalBio.PortTerminal, listaDeBiometrias.ElementAt(idSeleccion).Template).Result;
        //        if (estatusEnvioBio)
        //        {
        //            Console.WriteLine("Se ha enviado correctamente la biometria");
        //            break;
        //        }
        //        else
        //        {
        //            Console.WriteLine("no se pudo enviar la biometria");
        //        }

        //    }

        //    Console.ReadKey();







        //}

        #endregion


        #region Extraer y Guardar Biometrias de las Terminales Biometricas
        //public static ConfiguracionBiometrico confTerminalBio;

        //static void Main(string[] args)
        //{
        //ApiControllers apiControllers = new ApiControllers();
        //    ApiFotosCotroller apiFotosCotroller = new ApiFotosCotroller();
        //    ApiBiometriasController apiBiometriasController = new ApiBiometriasController();
        //    List<InfoBiometrico> biometricos = new List<InfoBiometrico>();
        //    List<RegistrosRelojes> reloj = new List<RegistrosRelojes>();


        //    //int idEmpleado = 42329;
        //    //string ipTerminal = "ocampojuzgadomenor.dyndns.biz";
        //    //int portTerminal = 9922;
        //    //int idTerminal = 140;

        //    //DateTime dayOne = DateTime.Now.AddDays(-1).AddHours(-(DateTime.Now.Hour)).AddMinutes(-(DateTime.Now.Minute)).AddSeconds(-(DateTime.Now.Second));
        //    // DateTime dayTwo = DateTime.Now.AddHours(-(DateTime.Now.Hour)).AddMinutes(-(DateTime.Now.Minute)).AddSeconds(-(DateTime.Now.Second));
        //    // DateTime dayTwo = DateTime.Now.Date;

        //    //dayList.Add(dayOne);
        //    //dayList.Add(dayTwo);

        //    biometricos = (List<InfoBiometrico>)apiControllers.ObtenerListaRelojes().Result;




        //    if (biometricos != null && biometricos.ElementAt(0).ConexionEstatus)
        //    {


        //        foreach (InfoBiometrico terminal in biometricos)
        //        {

        //            var ipTerminalBio = HerramientasIp.ComprobarDireccionDeRed(terminal.IpTerminal);

        //            confTerminalBio = apiBiometriasController.ObtenerConfiguracionTerminalBiometrica(ipTerminalBio, terminal.PortTerminal).Result;

        //            if (confTerminalBio.ConexionEstatus)
        //            {
        //                GuardarLogDescargaBiometrias.InsertarlogDescargaBiometrias($"{DateTime.Now} Evento = Obtener configuracion Terminal, Terminal={terminal.NombreTerminal}, id= {terminal.IdTerminal}, Resultado= {confTerminalBio.Fw }, {confTerminalBio.Sn}, {confTerminalBio.Algoritmo}, {confTerminalBio.Modelo} ");
        //                var listaEmpleadosTerminalBiometrica = (List<int>)apiBiometriasController.ObtenerListadoEmpleadosTerminalBiometrica(ipTerminalBio, terminal.PortTerminal).Result;
        //                if (listaEmpleadosTerminalBiometrica.Count() > 0)
        //                {
        //                    GuardarLogDescargaBiometrias.InsertarlogDescargaBiometrias($"{DateTime.Now} Evento = Descarga lista biometrias, Terminal={terminal.NombreTerminal}, id= {terminal.IdTerminal}, Resultado=cantidad de biometrias{listaEmpleadosTerminalBiometrica.Count()}");

        //                    foreach (int id in listaEmpleadosTerminalBiometrica)
        //                    {
        //                        var biometriaEmpleado = apiBiometriasController.DescargaBiometriaEmpleado(id, ipTerminalBio, terminal.PortTerminal, long.Parse(confTerminalBio.Sn)).Result;

        //                        if (biometriaEmpleado.ConexionEstatus)
        //                        {
        //                            GuardarLogDescargaBiometrias.InsertarlogDescargaBiometrias($"{DateTime.Now} Evento = Descarga biometria terminal, IdEmpleado ={id} Terminal={terminal.NombreTerminal}, id= {terminal.IdTerminal}, Resultado=correcto");

        //                            bool enviarBiometria = apiBiometriasController.GuardarBiometriaReloj(id, terminal.IdTerminal, biometriaEmpleado.Template).Result;
        //                            GuardarLogDescargaBiometrias.InsertarlogDescargaBiometrias($"{DateTime.Now} Evento = insertar biometria db, IdEmpleado ={id} Terminal={terminal.NombreTerminal}, id= {terminal.IdTerminal}, Resultado={enviarBiometria}");
        //                        }
        //                        else
        //                        {
        //                            Console.WriteLine("No se pudo establecer conexion con la terminal");
        //                            GuardarLogDescargaBiometrias.InsertarlogDescargaBiometrias($"{DateTime.Now} Evento = Descarga de biometria, Terminal={terminal.NombreTerminal}, id= {terminal.IdTerminal}, Resultado=no se concreto la conexion con el reloj");

        //                        }
        //                    }

        //                }
        //                else
        //                {
        //                    Console.WriteLine("No hay Empleados en la terminal");
        //                    GuardarLogDescargaBiometrias.InsertarlogDescargaBiometrias($"{DateTime.Now} Evento = Descarga lista biometrias, Terminal={terminal.NombreTerminal}, id= {terminal.IdTerminal}, Resultado=no hay empleados registrados en la terminal");
        //                }

        //            }
        //            else
        //            {
        //                Console.WriteLine("No se pudo establecer conexion con la terminal");
        //                GuardarLogDescargaBiometrias.InsertarlogDescargaBiometrias($"{DateTime.Now} Evento = Descarga lista biometrias, Terminal={terminal.NombreTerminal}, id= {terminal.IdTerminal}, Resultado=no se concreto la conexion con el reloj");
        //            }
        //        }

        //    }
        //    else
        //    {
        //        Console.WriteLine("no se obtuvo el listado de relojes.");
        //        GuardarLogDescargaBiometrias.InsertarlogDescargaBiometrias($"{DateTime.Now } Evento = Descarga lista biometricos, Resultado=no se pudo concretar la conexion con la db para descargar listado de relojes");
        //    }











        //    Console.ReadKey();



        //    //var resultadoFotos = new FotosResualtado();





        //}
        #endregion

        #region Extraer caracteristicas terminales
        //static void Main(string[] args)
        //{
        //    var apiControllers = new ApiControllers();
        //    var apiFotosCotroller = new ApiFotosCotroller();
        //    var apiBiometriasController = new ApiBiometriasController();
        //    var apiAdminBio = new ApiAdminBiometricos();
        //    var apiQueryDb = new ApiConsultarDbController();

        //    var biometricos = (List<InfoBiometrico>)apiControllers.ObtenerListaRelojes().Result;
        //    if (biometricos != null && biometricos.ElementAt(0).ConexionEstatus)
        //    {
        //        foreach (var b in biometricos)
        //        {
        //            var caracteristicasTerminal = apiAdminBio.ConfiguracionTerminalBiometrica(b.IpTerminal, b.PortTerminal).Result;

        //            Console.WriteLine(b.NombreTerminal+" "+caracteristicasTerminal.Sn+ " "+ caracteristicasTerminal.Fw +" " + caracteristicasTerminal.Algoritmo+" "+ caracteristicasTerminal.Modelo);

        //        }
        //    }


        //    Console.ReadKey();



        //}

        #endregion



        #region  Extraer y Guardar Biometrias Por Teminal

        //public static ConfiguracionBiometrico confTerminalBio;

        //static void Main(string[] args)
        //{
        //    ApiControllers apiControllers = new ApiControllers();
        //    ApiFotosCotroller apiFotosCotroller = new ApiFotosCotroller();
        //    ApiBiometriasController apiBiometriasController = new ApiBiometriasController();
        //    List<InfoBiometrico> biometricos = new List<InfoBiometrico>();
        //    List<RegistrosRelojes> reloj = new List<RegistrosRelojes>();


        //    //int idEmpleado = 42329;
        //    //string ipTerminal = "ocampojuzgadomenor.dyndns.biz";
        //    //int portTerminal = 9922;
        //    //int idTerminal = 140;

        //    //DateTime dayOne = DateTime.Now.AddDays(-1).AddHours(-(DateTime.Now.Hour)).AddMinutes(-(DateTime.Now.Minute)).AddSeconds(-(DateTime.Now.Second));
        //    // DateTime dayTwo = DateTime.Now.AddHours(-(DateTime.Now.Hour)).AddMinutes(-(DateTime.Now.Minute)).AddSeconds(-(DateTime.Now.Second));
        //    // DateTime dayTwo = DateTime.Now.Date;

        //    //dayList.Add(dayOne);
        //    //dayList.Add(dayTwo);



        //    Console.WriteLine("Ingresa el id de la terminal:");
        //    var idTerminalBiometrica = Convert.ToInt32(Console.ReadLine().Trim());

        //    biometricos = (List<InfoBiometrico>)apiControllers.ObtenerListaRelojes().Result;





        //    if (biometricos != null && biometricos.ElementAt(0).ConexionEstatus)
        //    {

        //        var datosBiometrico = from id in biometricos where id.IdTerminal == idTerminalBiometrica select id;

        //        foreach (InfoBiometrico terminal in datosBiometrico)
        //        {

        //            var ipTerminalBio = HerramientasIp.ComprobarDireccionDeRed(terminal.IpTerminal);

        //            confTerminalBio = apiBiometriasController.ObtenerConfiguracionTerminalBiometrica(ipTerminalBio, terminal.PortTerminal).Result;

        //            if (confTerminalBio.ConexionEstatus)
        //            {
        //                GuardarLogDescargaBiometrias.InsertarlogDescargaBiometrias($"{DateTime.Now} Evento = Obtener configuracion Terminal, Terminal={terminal.NombreTerminal}, id= {terminal.IdTerminal}, Resultado= {confTerminalBio.Fw}, {confTerminalBio.Sn}, {confTerminalBio.Algoritmo}, {confTerminalBio.Modelo} ");
        //                var listaEmpleadosTerminalBiometrica = (List<int>)apiBiometriasController.ObtenerListadoEmpleadosTerminalBiometrica(ipTerminalBio, terminal.PortTerminal).Result;
        //                if (listaEmpleadosTerminalBiometrica.Count() > 0)
        //                {
        //                    GuardarLogDescargaBiometrias.InsertarlogDescargaBiometrias($"{DateTime.Now} Evento = Descarga lista biometrias, Terminal={terminal.NombreTerminal}, id= {terminal.IdTerminal}, Resultado=cantidad de biometrias{listaEmpleadosTerminalBiometrica.Count()}");

        //                    foreach (int id in listaEmpleadosTerminalBiometrica)
        //                    {
        //                        var biometriaEmpleado = apiBiometriasController.DescargaBiometriaEmpleado(id, ipTerminalBio, terminal.PortTerminal, long.Parse(confTerminalBio.Sn)).Result;

        //                        if (biometriaEmpleado.ConexionEstatus)
        //                        {
        //                            GuardarLogDescargaBiometrias.InsertarlogDescargaBiometrias($"{DateTime.Now} Evento = Descarga biometria terminal, IdEmpleado ={id} Terminal={terminal.NombreTerminal}, id= {terminal.IdTerminal}, Resultado=correcto");

        //                            bool enviarBiometria = apiBiometriasController.GuardarBiometriaReloj(id, terminal.IdTerminal, biometriaEmpleado.Template).Result;
        //                            GuardarLogDescargaBiometrias.InsertarlogDescargaBiometrias($"{DateTime.Now} Evento = insertar biometria db, IdEmpleado ={id} Terminal={terminal.NombreTerminal}, id= {terminal.IdTerminal}, Resultado={enviarBiometria}");
        //                        }
        //                        else
        //                        {
        //                            Console.WriteLine("No se pudo establecer conexion con la terminal");
        //                            GuardarLogDescargaBiometrias.InsertarlogDescargaBiometrias($"{DateTime.Now} Evento = Descarga de biometria, Terminal={terminal.NombreTerminal}, id= {terminal.IdTerminal}, Resultado=no se concreto la conexion con el reloj");

        //                        }
        //                    }

        //                }
        //                else
        //                {
        //                    Console.WriteLine("No hay Empleados en la terminal");
        //                    GuardarLogDescargaBiometrias.InsertarlogDescargaBiometrias($"{DateTime.Now} Evento = Descarga lista biometrias, Terminal={terminal.NombreTerminal}, id= {terminal.IdTerminal}, Resultado=no hay empleados registrados en la terminal");
        //                }

        //            }
        //            else
        //            {
        //                Console.WriteLine("No se pudo establecer conexion con la terminal");
        //                GuardarLogDescargaBiometrias.InsertarlogDescargaBiometrias($"{DateTime.Now} Evento = Descarga lista biometrias, Terminal={terminal.NombreTerminal}, id= {terminal.IdTerminal}, Resultado=no se concreto la conexion con el reloj");
        //            }
        //        }

        //    }
        //    else
        //    {
        //        Console.WriteLine("no se obtuvo el listado de relojes.");
        //        GuardarLogDescargaBiometrias.InsertarlogDescargaBiometrias($"{DateTime.Now} Evento = Descarga lista biometricos, Resultado=no se pudo concretar la conexion con la db para descargar listado de relojes");
        //    }









        //    Console.WriteLine("Proceso Terminado");

        //    Console.ReadKey();



        //    //var resultadoFotos = new FotosResualtado();





        //}








        #endregion



        #region Actualizar horario terminales biometricas






        #endregion



    }
}

    
