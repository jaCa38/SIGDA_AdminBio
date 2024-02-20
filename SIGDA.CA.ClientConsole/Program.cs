// See https://aka.ms/new-console-template for more information
/*Proceso 1: Se obtiene información en crudo en un rango de fechas
 exe que se ejecuta en una tarea de windows a las 9 am*/
/*using SIGDA.CA.Libreria.Punch.Models;
using SIGDA.CA.Libreria.Punch.Services;
using SIGDA.CA.Punch.Factorizadores;

PunchService service;

using (var Gestion = FactorizadorPunch.CrearConexionPunchs())
{
    service = new PunchService(Gestion);
    List<BasePunch> res = service.ConsultarInformacionCruda(DateTime.Now.AddDays(-1), DateTime.Now);
    Boolean registroInsert = service.InsertarInformacionCruda(res);
}*/

/*Proceso 2: Se ejecuta una sola vez cuando se vaya a migrar la configuración de turnos del personal en base a como se tiene en SICA en la tabla sicadb.bio_empleados_tur*/

using SIGDA.CA.Libreria.Turno.Factorizadores;
using SIGDA.CA.Libreria.Turno.Models;
using SIGDA.CA.Libreria.Turno.Services;

TurnoSICAService service;
using (var Gestion = FactorizadorTurno.CrearConexionTurnoSICA())
{
    service = new TurnoSICAService(Gestion);
    List<ConfigTurnoSICA> res = service.ConsultarConfiguracionTurnadoEmpleado();
    Boolean registroInsert = service.InsertarConfiguracionTurnadoEmpleado(res);
    Boolean registrosUpdate = service.ActualizarTurnosFijos();
    Boolean registrosTurnoVariable = service.ActualizarTurnosVariables();


}

//Console.WriteLine("Terminado, presione tecla");
//Console.ReadKey();

