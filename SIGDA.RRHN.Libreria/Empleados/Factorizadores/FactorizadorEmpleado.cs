using Microsoft.IdentityModel.Protocols;
using SIGDA.Conexion;
using SIGDA.SRHN.Libreria.Empleados.Controllers;
using SIGDA.SRHN.Libreria.Empleados.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Empleados.Factorizadores
{
    public class FactorizadorEmpleado
    {
        public static IEmpleadoNombramientoService CrearConexionEmpleadoNombramiento()
        {
            IEmpleadoNombramientoService nuevoMotor;

            //ConexionSql sql = ConexionSql.Conectar(CadenasConexion.BDRHN_LOCAL);
            nuevoMotor = new EmpleadoNombramientoController(CadenasConexion.BDRHN_LOCAL);

            return nuevoMotor;
        }
        public static IEmpleadoNombramientoService CrearConexionEmpleadoNombramiento_RH()
        {
            IEmpleadoNombramientoService nuevoMotor;

            //ConexionSql sql = ConexionSql.Conectar(CadenasConexion.BDRHN_LOCAL);
            nuevoMotor = new EmpleadoNombramientoController(CadenasConexion.BDRH_LOCAL);

            return nuevoMotor;
        }

        public static IEmpleadoNombramientoService CrearConexionSIGEIN()
        {
            IEmpleadoNombramientoService nuevoMotor;

            //ConexionSql sql = ConexionSql.Conectar(CadenasConexion.BDRHN_LOCAL);
            nuevoMotor = new EmpleadoNombramientoController(CadenasConexion.BDSIGEIN_LOCAL);

            return nuevoMotor;
        }
        public static IEmpleadoNombramientoService CrearConexionCurriculum()
        {
            IEmpleadoNombramientoService nuevoMotor;

            //ConexionSql sql = ConexionSql.Conectar(CadenasConexion.BDRHN_LOCAL);
            nuevoMotor = new EmpleadoNombramientoController(CadenasConexion.BDCV_LOCAL);

            return nuevoMotor;
        }
        //public static IEmpleadoHonorariosService CrearConexionEmpleadoHonorarios()
        //{
        //    IEmpleadoHonorariosService nuevoMotor;

        //    //ConexionSql sql = ConexionSql.Conectar(CadenasConexion.BDRHN_LOCAL);
        //    nuevoMotor = new EmpleadoBaseController(CadenasConexion.BDRHN_LOCAL);

        //    return nuevoMotor;
        //}

        public static IEstudioAcademicoService CrearConexionCVEstudioAcademico()
        {
            IEstudioAcademicoService motor;
            motor = new EstudioAcademicoController(CadenasConexion.BDCV_LOCAL);
            return motor;
        }
        public static IInformacionLaboralService CrearConexionCVInfoLaboral()
        {
            IInformacionLaboralService motor;
            motor = new InformacionLaboralController(CadenasConexion.BDCV_LOCAL);
            return motor;
        }
    }
}
