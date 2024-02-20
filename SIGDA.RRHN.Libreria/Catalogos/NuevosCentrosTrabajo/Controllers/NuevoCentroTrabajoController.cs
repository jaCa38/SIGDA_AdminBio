using Dapper;
using SIGDA.SRHN.Libreria.Catalogos.Genericos.Enums;
using SIGDA.Catalogos.Genericos.Models;
using SIGDA.SRHN.Libreria.Catalogos.NuevosCentrosTrabajo.Models;
using SIGDA.SRHN.Libreria.Catalogos.NuevosCentrosTrabajo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Catalogos.NuevosCentrosTrabajo.Controllers
{
    public class NuevoCentroTrabajoController : INuevoCentroTrabajoService, IDisposable
    {
        #region Constructor Variables
        DataTableReader? dtrResultado = null;
        private string? _cadenaConexion;

        public NuevoCentroTrabajoController(string cadena)
        {
            _cadenaConexion = cadena;
        }
        #endregion
        public bool InsertarNuevoCentroTrabajo(NuevoCentroTrabajoBase nuevoCentroTrabajoBase)
        {
            var sql = @"[catalogo].[sp_AlmacenarNuevoCentroTrabajo]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idDivision", (int)nuevoCentroTrabajoBase.Division);
            dpParametros.Add("@idInstancia", (int)nuevoCentroTrabajoBase.Instancia);
            dpParametros.Add("@idSistema", nuevoCentroTrabajoBase.IdSistema);
            dpParametros.Add("@idMun", nuevoCentroTrabajoBase.IdMunicipio);
            dpParametros.Add("@idCentroTrabajo", nuevoCentroTrabajoBase.IdCentroTrabajo);
            dpParametros.Add("@descripSubCT", nuevoCentroTrabajoBase.DescripcionSubCT);
            dpParametros.Add("@identif", nuevoCentroTrabajoBase.ClaveNomina);
            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var rowsAf = connection.Execute(sql, dpParametros, commandType: CommandType.StoredProcedure, commandTimeout: 2000);
                    return true;
                }
            }
            catch (SqlException SqlEx)
            {
                string MensajeError = "ERROR : " + SqlEx.Message + ". " + "LINEA : " + SqlEx.LineNumber + ".";
                throw new Exception(MensajeError, SqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public bool ActivarNuevoCentroTrabajo(long Identificador)
        {
            var sql = @"[catalogo].[sp_ActivarDesactivarCentroTrabajo]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@id", Identificador);
            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var rowsAf = connection.Execute(sql, dpParametros, commandType: CommandType.StoredProcedure, commandTimeout: 2000);
                    return true;
                }
            }
            catch (SqlException SqlEx)
            {
                string MensajeError = "ERROR : " + SqlEx.Message + ". " + "LINEA : " + SqlEx.LineNumber + ".";
                throw new Exception(MensajeError, SqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<BaseModel> ConsultarNuevoCentroTrabajo(EDivision division, EInstancia instancia, long IdSistema, long IdMunicipio)
        {
            List<BaseModel> lstResultado = new List<BaseModel>();

            var sql = @"[catalogo].[sp_Obtener_InfoCatalogoCTs_CentroTrabajo]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idDivision", (int)division);
            dpParametros.Add("@idInstancia", (int)instancia);
            dpParametros.Add("@idSistema", IdSistema);
            dpParametros.Add("@idMunicipio", IdMunicipio);

            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<BaseModel>(
                        sql,
           dpParametros, commandType: CommandType.StoredProcedure
           //, splitOn: "IdentificadorElementoIndice"
           , commandTimeout: 2000
           ).ToList();
                    lstResultado = recRevoc;
                }
            }
            catch (SqlException SqlEx)
            {
                string MensajeError = "ERROR : " + SqlEx.Message + ". " + "LINEA : " + SqlEx.LineNumber + ".";
                throw new Exception(MensajeError, SqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return lstResultado;
        }


        public List<NuevoCentroTrabajoDetalle> ConsultarNuevoCentroTrabajoDetalle(long IdCentroTrabajo)
        {
            List<NuevoCentroTrabajoDetalle> lstResultado = new List<NuevoCentroTrabajoDetalle>();

            var sql = @"[catalogo].[sp_ObtenerNuevoCentroTrabajo]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@id", IdCentroTrabajo);

            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<NuevoCentroTrabajoDetalle>(
                        sql,
           dpParametros, commandType: CommandType.StoredProcedure
           //, splitOn: "IdentificadorElementoIndice"
           , commandTimeout: 2000
           ).ToList();
                    lstResultado = recRevoc;
                }
            }
            catch (SqlException SqlEx)
            {
                string MensajeError = "ERROR : " + SqlEx.Message + ". " + "LINEA : " + SqlEx.LineNumber + ".";
                throw new Exception(MensajeError, SqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return lstResultado;
        }

        public List<NuevoCentroTrabajoDetalle> ConsultarNuevoCentroTrabajoDetalle(string busqueda)
        {
            List<NuevoCentroTrabajoDetalle> lstResultado = new List<NuevoCentroTrabajoDetalle>();

            var sql = @"[catalogo].[sp_ObtenerNuevosCentrosTrabajoFiltro]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@busq", busqueda);

            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<NuevoCentroTrabajoDetalle>(
                        sql,
           dpParametros, commandType: CommandType.StoredProcedure
           //, splitOn: "IdentificadorElementoIndice"
           , commandTimeout: 2000
           ).ToList();
                    lstResultado = recRevoc;
                }
            }
            catch (SqlException SqlEx)
            {
                string MensajeError = "ERROR : " + SqlEx.Message + ". " + "LINEA : " + SqlEx.LineNumber + ".";
                throw new Exception(MensajeError, SqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return lstResultado;
        }

        public List<NuevoCentroTrabajoDetalle> ConsultarNuevoCentroTrabajoDetalle(string busqueda, EDivision division, EInstancia instancia, long IdSistema, long IdMunicipio, long IdCentroTrabajo)
        {
            List<NuevoCentroTrabajoDetalle> lstResultado = new List<NuevoCentroTrabajoDetalle>();
            var sql = @"[catalogo].[sp_ObtenerNuevosCentrosTrabajoFiltro2]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@busq", busqueda);
            dpParametros.Add("@idDivision", (int)division);
            dpParametros.Add("@idInstancia", (int)instancia);
            dpParametros.Add("@idSistema", IdSistema);
            dpParametros.Add("@idMunicipio", IdMunicipio);
            dpParametros.Add("@idCT", IdCentroTrabajo);

            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<NuevoCentroTrabajoDetalle>(
                        sql,
           dpParametros, commandType: CommandType.StoredProcedure
           //, splitOn: "IdentificadorElementoIndice"
           , commandTimeout: 2000
           ).ToList();
                    lstResultado = recRevoc;
                }
            }
            catch (SqlException SqlEx)
            {
                string MensajeError = "ERROR : " + SqlEx.Message + ". " + "LINEA : " + SqlEx.LineNumber + ".";
                throw new Exception(MensajeError, SqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return lstResultado;
        }

        public List<NuevoCentroTrabajoDetalle> ConsultarNuevoCentroTrabajoRelacion(string Relacion)
        {
            List<NuevoCentroTrabajoDetalle> lstResultado = new List<NuevoCentroTrabajoDetalle>();

            var sql = @"[catalogo].[sp_ObtenerNuevoCentroTrabajo_Relacion]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@relacion", Relacion);

            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<NuevoCentroTrabajoDetalle>(
                        sql,
           dpParametros, commandType: CommandType.StoredProcedure
           //, splitOn: "IdentificadorElementoIndice"
           , commandTimeout: 2000
           ).ToList();
                    lstResultado = recRevoc;
                }
            }
            catch (SqlException SqlEx)
            {
                string MensajeError = "ERROR : " + SqlEx.Message + ". " + "LINEA : " + SqlEx.LineNumber + ".";
                throw new Exception(MensajeError, SqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return lstResultado;
        }

        public List<NuevoCentroTrabajoSeleccion> ConsultarNuevoCentroTrabajoSeleccion(long IdSubCentroTrabajo)
        {
            List<NuevoCentroTrabajoSeleccion> lstResultado = new List<NuevoCentroTrabajoSeleccion>();

            var sql = @"[catalogo].[sp_ObtenerNuevoCentroTrabajoSeleccion]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idSubCentro", IdSubCentroTrabajo);

            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<NuevoCentroTrabajoSeleccion>(
                        sql,
           dpParametros, commandType: CommandType.StoredProcedure
           //, splitOn: "IdentificadorElementoIndice"
           , commandTimeout: 2000
           ).ToList();
                    lstResultado = recRevoc;
                }
            }
            catch (SqlException SqlEx)
            {
                string MensajeError = "ERROR : " + SqlEx.Message + ". " + "LINEA : " + SqlEx.LineNumber + ".";
                throw new Exception(MensajeError, SqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return lstResultado;
        }
        #region IDisposable Support
        bool disposedValue = false; // Para detectar llamadas redundantes
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (dtrResultado != null) { dtrResultado.Close(); dtrResultado.Dispose(); }
                    // TODO: elimine el estado administrado (objetos administrados).
                }

                // TODO: libere los recursos no administrados (objetos no administrados) y reemplace el siguiente finalizador.
                // TODO: configure los campos grandes en nulos.

                disposedValue = true;
            }
        }

        // TODO: reemplace un finalizador solo si el anterior Dispose(bool disposing) tiene código para liberar los recursos no administrados.
        // ~GestionFamiliarService()
        // {
        //   // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
        //   Dispose(false);
        // }

        // Este código se agrega para implementar correctamente el patrón descartable.
        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
            // GC.SuppressFinalize(this);
        }
        #endregion
        List<BaseModel> INuevoCentroTrabajoService.ConsultarNuevoCentroTrabajo(EDivision division, EInstancia instancia, long IdSistema, long IdMunicipio)
        {
            List<BaseModel> lstResultado = new List<BaseModel>();
            var sql = @"[catalogo].[sp_Obtener_InfoCatalogoCTs_CentroTrabajo]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idDivision", division);
            dpParametros.Add("@idInstancia", instancia);
            dpParametros.Add("@idSistema", IdSistema);
            dpParametros.Add("@idMunicipio", IdMunicipio);
            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<BaseModel>(
                        sql, dpParametros, commandType: CommandType.StoredProcedure
                       , commandTimeout: 2000
                       ).ToList();
                    lstResultado = recRevoc;
                }
            }
            catch (SqlException SqlEx)
            {
                string MensajeError = "ERROR : " + SqlEx.Message + ". " + "LINEA : " + SqlEx.LineNumber + ".";
                throw new Exception(MensajeError, SqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return lstResultado;
        }

        public List<BaseModel> ObtenerDivision()
        {
            List<BaseModel> lstResultado = new List<BaseModel>();
            var sql = @"[catalogo].[sp_Obtener_InfoCatalogoCTs_Division]";
            var dpParametros = new DynamicParameters();
            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<BaseModel>(
                        sql, dpParametros, commandType: CommandType.StoredProcedure
                       , commandTimeout: 2000
                       ).ToList();
                    lstResultado = recRevoc;
                }
            }
            catch (SqlException SqlEx)
            {
                string MensajeError = "ERROR : " + SqlEx.Message + ". " + "LINEA : " + SqlEx.LineNumber + ".";
                throw new Exception(MensajeError, SqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return lstResultado;
        }

        public List<BaseModel> ObtenerInstancias(EDivision division)
        {
            List<BaseModel> lstResultado = new List<BaseModel>();
            var sql = @"[catalogo].[sp_Obtener_InfoCatalogoCTs_Instancia]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@id", division);
            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<BaseModel>(
                        sql, dpParametros, commandType: CommandType.StoredProcedure
                       , commandTimeout: 2000
                       ).ToList();
                    lstResultado = recRevoc;
                }
            }
            catch (SqlException SqlEx)
            {
                string MensajeError = "ERROR : " + SqlEx.Message + ". " + "LINEA : " + SqlEx.LineNumber + ".";
                throw new Exception(MensajeError, SqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return lstResultado;
        }

        public List<BaseModel> ObtenerSistemas(EDivision division, EInstancia instancia)
        {
            List<BaseModel> lstResultado = new List<BaseModel>();
            var sql = @"[catalogo].[sp_Obtener_InfoCatalogoCTs_Sistema]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idDivision", division);
            dpParametros.Add("@idInstancia", instancia);
            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<BaseModel>(
                        sql, dpParametros, commandType: CommandType.StoredProcedure
                       , commandTimeout: 2000
                       ).ToList();
                    lstResultado = recRevoc;
                }
            }
            catch (SqlException SqlEx)
            {
                string MensajeError = "ERROR : " + SqlEx.Message + ". " + "LINEA : " + SqlEx.LineNumber + ".";
                throw new Exception(MensajeError, SqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return lstResultado;
        }

        public List<BaseModel> ObtenerMunicipios(EDivision division, EInstancia instancia, long idSistema)
        {
            List<BaseModel> lstResultado = new List<BaseModel>();
            var sql = @"[catalogo].[sp_Obtener_InfoCatalogoCTs_Municipio]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idDivision", division);
            dpParametros.Add("@idInstancia", instancia);
            dpParametros.Add("@idSistema", idSistema);
            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<BaseModel>(
                        sql, dpParametros, commandType: CommandType.StoredProcedure
                       , commandTimeout: 2000
                       ).ToList();
                    lstResultado = recRevoc;
                }
            }
            catch (SqlException SqlEx)
            {
                string MensajeError = "ERROR : " + SqlEx.Message + ". " + "LINEA : " + SqlEx.LineNumber + ".";
                throw new Exception(MensajeError, SqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return lstResultado;
        }

        /*
        public List<BaseModel> ConsultarNuevoCentroTrabajoDetalle(EDivision division, EInstancia instancia, long IdSistema, long IdMunicipio, long IdCentroTrabajo)
        {
            List<BaseModel> lstResultado = new List<BaseModel>();
            var sql = @"[catalogo].[sp_Obtener_InfoCatalogoCTs_SubCentroTrabajo]";
            var dpParametros = new DynamicParameters();
            dpParametros.Add("@idDivision", division);
            dpParametros.Add("@idInstancia", instancia);
            dpParametros.Add("@idSistema", IdSistema);
            dpParametros.Add("@idMunicipio", IdMunicipio);
            dpParametros.Add("@idCT", IdCentroTrabajo);
            try
            {
                using (var connection = new SqlConnection(_cadenaConexion))
                {
                    var recRevoc = connection.Query<BaseModel>(
                        sql, dpParametros, commandType: CommandType.StoredProcedure
                       , commandTimeout: 2000
                       ).ToList();
                    lstResultado = recRevoc;
                }
            }
            catch (SqlException SqlEx)
            {
                string MensajeError = "ERROR : " + SqlEx.Message + ". " + "LINEA : " + SqlEx.LineNumber + ".";
                throw new Exception(MensajeError, SqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return lstResultado;
        }
        */
    }
}
