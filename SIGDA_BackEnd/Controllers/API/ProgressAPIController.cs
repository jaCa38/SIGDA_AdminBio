using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGDA.APIProgress.Models;
using SIGDA.APIProgress.Models.ASF;
using SIGDA.APIProgress.Models.CA;
using SIGDA.APIProgress.Models.Trans.ASEG;
using SIGDA.APIProgress.Models.Trans.ASEG.CveEmp;
using SIGDA.APIProgress.Models.Trans.PNT;
using SIGDA.APIProgress.Models.Vac;
using SIGDA.SRHN.Libreria.Catalogos.Municipios.Factorizadores;
using SIGDA.SRHN.Libreria.Herramientas;
using SIGDA.SRHN.Libreria.Herramientas.ASF;
using SIGDA.SRHN.Libreria.Herramientas.CA;
using SIGDA.SRHN.Libreria.Herramientas.Transp;      
using SIGDA.SRHN.Libreria.Herramientas.Vac;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace SIGDA_BackEnd.Controllers.API
{
    public class ProgressAPIController : BaseControllerSIGDA
    {
        private IConfiguration _Config;
        public ProgressAPIController(IConfiguration Configuration) => _Config = Configuration;

        /// <summary>
        /// Login para generar JWT en API de Ángel desde donde se conecta a Progress
        /// </summary>
        /// <param name="loginRequest">	{"Username": "adminSRHN","Passwd": "C3cilio1804."}</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Progress/Login")]
        public async Task<SecToken> LoginProgress(LoginRequest loginRequest)
        {
            APIConnection apiConnecion = new APIConnection();
            return await apiConnecion.ObtenerSecureToken(loginRequest);
        }

        //[Authorize]
        [HttpPost]
        [Route("api/Progress/Empleado/GetAll")]
        public async Task<EmpleadosProgress> GetAll([FromBody] SecToken token, string cve, string nombre, string paterno, string materno)
        {
            APIConnection apiConnecion = new APIConnection();
            return await apiConnecion.BuscarEmpleadosProgress(token,cve,nombre,paterno,materno);
        }
        [HttpPost]
        [Route("api/Progress/CA/falta/omisionES")]
        public async Task<bool> RegistroOmisionES([FromBody] SecToken token, RegistroCAProgress[] lstRegistros)
        {
            APIConnection apiConnection = new APIConnection();
            return false;
        }

        [HttpPost]
        [Route("api/Progress/ASF/participaciones/auxiliar/cuotasIssegIssste")]
        public async Task<List<CuotaISSEGISSSTEProgress>> ObtenerInformacionCuotas([FromBody] CuotaISSEGISSSTEProgress identif)
        {
            CuotasProgress cuotas = new CuotasProgress();
            return await cuotas.ObtenerInformacionCuotas(identif);
        }
        [HttpPost]
        [Route("api/Progress/ASF/participaciones/clavesPago")]
        public async Task<List<ClavesPagoProgress>> ObtenerListaClaves()
        {
            ClavesPagoProgress cuotas = new ClavesPagoProgress();
            return await cuotas.ObtenerListaClaves();
        }
        [HttpPost]
        [Route("api/Progress/Vacacion/diasDisponibles")]
        public async Task<int> ObtenerDias([FromBody] DatosVacacion datos)
        {
            VacacionProgress vaca = new VacacionProgress();
            return await vaca.ObtenerDiasProgress(datos.IdEmpleado, datos.IdPeriodo, datos.Anio);
        }
        [HttpPost]
        [Route("api/Progress/Vacacion/ReporteByCT")]
        public async Task<List<Periodo>> ReporteByCT([FromBody] DatosVacacion datos)
        {
            VacacionProgress vaca = new VacacionProgress();
            return await vaca.GetReportebyCT(datos.IdentificadorNomina, datos.IdPeriodo, datos.Anio);
        }
        [HttpPost]
        [Route("api/Progress/Vacacion/ReportePlantilla")]
        public async Task<List<Periodo>> ReportePlantilla([FromBody] DatosVacacion datos)
        {
            VacacionProgress vaca = new VacacionProgress();
            return await vaca.GetReportePlantilla(datos.IdPeriodo, datos.Anio);
        }
        [HttpPost]
        [Route("api/Progress/Vacacion/PuestosTodos")]
        public async Task<List<Puesto>> PuestosTodos()
        {
            VacacionProgress vaca = new VacacionProgress();
            return await vaca.GetTodosPuestos();
        }
        [HttpPost]
        [Route("api/Progress/Vacacion/PuestosByCT")]
        public async Task<List<PuestoEmpleado>> PuestosByCT([FromBody] DatosVacacion datos)
        {
            VacacionProgress vaca = new VacacionProgress();
            return await vaca.GetPuestosByCT(datos);
        }
        [HttpPost]
        [Route("api/Progress/Transparencia/aseg/cuentasEmpleado")]
        public async Task<List<CuentaEmpleado>> CuentasEmpleado([FromBody] CuentaEmpleado datos)
        {
            AsegProgress vaca = new AsegProgress();
            return await vaca.CuentasEmpleado(datos);
        }
        [HttpPost]
        [Route("api/Progress/Transparencia/aseg/licencias")]
        public async Task<List<MovimientoLicencia>> Licencias([FromBody] MovimientoLicencia datos)
        {
            AsegProgress vaca = new AsegProgress();
            return await vaca.ObtenerLicencias(datos);
        }
        [HttpPost]
        [Route("api/Progress/Transparencia/aseg/movimientos")]
        public async Task<List<MovimientoLicencia>> Movimientos([FromBody] MovimientoLicencia datos)
        {
            AsegProgress vaca = new AsegProgress();
            return await vaca.ObtenerMovimientos(datos);
        }
        [HttpPost]
        [Route("api/Progress/Transparencia/aseg/clavesPorEmpleado/uno")]
        public async Task<List<QnaTrimestre>> ObtenerQnasTrim([FromBody] QnaTrimestre datos)
        {
            AsegProgress vaca = new AsegProgress();
            return await vaca.ObtenerQnasTrimestre(datos);
        }
        [HttpPost]
        [Route("api/Progress/Transparencia/aseg/clavesPorEmpleado/dos")]
        public async Task<List<InfoEmpleado>> ObtenerDatosEmpleado([FromBody] InfoEmpleado datos)
        {
            AsegProgress vaca = new AsegProgress();
            return await vaca.ObtenerDatosEmpleado(datos);
        }
        [HttpPost]
        [Route("api/Progress/Transparencia/aseg/clavesPorEmpleado/tres")]
        public async Task<List<ClaveEmpleadoTrim>> ObtenerCvesEmpTrim([FromBody] ClaveEmpleadoTrim datos)
        {
            AsegProgress vaca = new AsegProgress();
            return await vaca.ObtenerClavesEmpleadoTrimestre(datos);
        }
        [HttpPost]
        [Route("api/Progress/Transparencia/pnt/curricular")]
        public async Task<List<InfoEmp>> ObtenerInformacionParaCurricular([FromBody] InfoEmp datos)
        {
            PntProgress vaca = new PntProgress();
            return await vaca.InfoCurricular(datos);
        }
        [HttpPost]
        [Route("api/Progress/Transparencia/pnt/RemuneracionBrutaNeta")]
        public async Task<List<RemuneracionBrutaNeta>> ObtenerRemuneracionBrutaNeta([FromBody] RemuneracionBrutaNeta datos)
        {
            PntProgress vaca = new PntProgress();
            return await vaca.InfoRemuneracionBrutaNeta(datos);
        }
        [HttpPost]
        [Route("api/Progress/Transparencia/pnt/RemuneracionBrutaNetaTabla")]
        public async Task<List<RemuneracionBrutaNetaTabla>> ObtenerRemuneracionBrutaNetaTabla([FromBody] RemuneracionBrutaNetaTabla datos)
        {
            PntProgress vaca = new PntProgress();
            return await vaca.InfoRemuneracionBrutaNetaTabla(datos);
        }
    }
}
