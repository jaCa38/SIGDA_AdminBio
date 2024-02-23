using SIGDA.CA.Biometricos.Libreria.Models;
using SIGDA.CA.Biometricos.Libreria.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBiometricos.Tools;

namespace TestBiometricos.Metodos
{
    public static class DescargaTodasLasBiometrias
    {
        public static ConfiguracionBiometrico confTerminalBio;

        
           public static ApiControllers apiControllers = new ApiControllers();
           public static ApiFotosCotroller apiFotosCotroller = new ApiFotosCotroller();
           public static ApiBiometriasController apiBiometriasController = new ApiBiometriasController();
            


        //int idEmpleado = 42329;
        //string ipTerminal = "ocampojuzgadomenor.dyndns.biz";
        //int portTerminal = 9922;
        //int idTerminal = 140;

        //DateTime dayOne = DateTime.Now.AddDays(-1).AddHours(-(DateTime.Now.Hour)).AddMinutes(-(DateTime.Now.Minute)).AddSeconds(-(DateTime.Now.Second));
        // DateTime dayTwo = DateTime.Now.AddHours(-(DateTime.Now.Hour)).AddMinutes(-(DateTime.Now.Minute)).AddSeconds(-(DateTime.Now.Second));
        // DateTime dayTwo = DateTime.Now.Date;

        //dayList.Add(dayOne);
        //dayList.Add(dayTwo);

        public static void DescargaBiometriasTerminales()
        {
            List<InfoBiometrico> biometricos = new List<InfoBiometrico>();
            List<RegistrosRelojes> reloj = new List<RegistrosRelojes>();
            biometricos = (List<InfoBiometrico>)apiControllers.ObtenerListaRelojes().Result;




            if (biometricos != null && biometricos.ElementAt(0).ConexionEstatus)
            {


                foreach (InfoBiometrico terminal in biometricos)
                {

                    var ipTerminalBio = HerramientasIp.ComprobarDireccionDeRed(terminal.IpTerminal);

                    confTerminalBio = apiBiometriasController.ObtenerConfiguracionTerminalBiometrica(ipTerminalBio, terminal.PortTerminal).Result;

                    if (confTerminalBio.ConexionEstatus)
                    {
                        GuardarLogDescargaBiometrias.InsertarlogDescargaBiometrias($"{DateTime.Now} Evento = Obtener configuracion Terminal, Terminal={terminal.NombreTerminal}, id= {terminal.IdTerminal}, Resultado= {confTerminalBio.Fw}, {confTerminalBio.Sn}, {confTerminalBio.Algoritmo}, {confTerminalBio.Modelo} ");
                        var listaEmpleadosTerminalBiometrica = (List<int>)apiBiometriasController.ObtenerListadoEmpleadosTerminalBiometrica(ipTerminalBio, terminal.PortTerminal).Result;
                        if (listaEmpleadosTerminalBiometrica.Count() > 0)
                        {
                            GuardarLogDescargaBiometrias.InsertarlogDescargaBiometrias($"{DateTime.Now} Evento = Descarga lista biometrias, Terminal={terminal.NombreTerminal}, id= {terminal.IdTerminal}, Resultado=cantidad de biometrias{listaEmpleadosTerminalBiometrica.Count()}");

                            foreach (int id in listaEmpleadosTerminalBiometrica)
                            {
                                var biometriaEmpleado = apiBiometriasController.DescargaBiometriaEmpleado(id, ipTerminalBio, terminal.PortTerminal, long.Parse(confTerminalBio.Sn)).Result;

                                if (biometriaEmpleado.ConexionEstatus)
                                {
                                    GuardarLogDescargaBiometrias.InsertarlogDescargaBiometrias($"{DateTime.Now} Evento = Descarga biometria terminal, IdEmpleado ={id} Terminal={terminal.NombreTerminal}, id= {terminal.IdTerminal}, Resultado=correcto");

                                    bool enviarBiometria = apiBiometriasController.GuardarBiometriaReloj(id, terminal.IdTerminal, biometriaEmpleado.Template).Result;
                                    GuardarLogDescargaBiometrias.InsertarlogDescargaBiometrias($"{DateTime.Now} Evento = insertar biometria db, IdEmpleado ={id} Terminal={terminal.NombreTerminal}, id= {terminal.IdTerminal}, Resultado={enviarBiometria}");
                                }
                                else
                                {
                                    Console.WriteLine("No se pudo establecer conexion con la terminal");
                                    GuardarLogDescargaBiometrias.InsertarlogDescargaBiometrias($"{DateTime.Now} Evento = Descarga de biometria, Terminal={terminal.NombreTerminal}, id= {terminal.IdTerminal}, Resultado=no se concreto la conexion con el reloj");

                                }
                            }

                        }
                        else
                        {
                            Console.WriteLine("No hay Empleados en la terminal");
                            GuardarLogDescargaBiometrias.InsertarlogDescargaBiometrias($"{DateTime.Now} Evento = Descarga lista biometrias, Terminal={terminal.NombreTerminal}, id= {terminal.IdTerminal}, Resultado=no hay empleados registrados en la terminal");
                        }

                    }
                    else
                    {
                        Console.WriteLine("No se pudo establecer conexion con la terminal");
                        GuardarLogDescargaBiometrias.InsertarlogDescargaBiometrias($"{DateTime.Now} Evento = Descarga lista biometrias, Terminal={terminal.NombreTerminal}, id= {terminal.IdTerminal}, Resultado=no se concreto la conexion con el reloj");
                    }
                }

            }
            else
            {
                Console.WriteLine("no se obtuvo el listado de relojes.");
                GuardarLogDescargaBiometrias.InsertarlogDescargaBiometrias($"{DateTime.Now} Evento = Descarga lista biometricos, Resultado=no se pudo concretar la conexion con la db para descargar listado de relojes");
            }











            Console.ReadKey();



            //var resultadoFotos = new FotosResualtado();
        }

        }
    }
