using Dapper;
using MySql.Data.MySqlClient;
using SIGDA.CA.Biometricos.Libreria.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SIGDA.CA.Biometricos.Libreria.Tools
{
    public class ConsultaRegistrosSICA: IDisposable
    {
        private string strConexionMYSQL;
        private string strConexionMSSQL;
        DataTableReader dtrResultado = null;

        public ConsultaRegistrosSICA(string cadenaMysql, string cadenaMSSQL)
        {

            strConexionMYSQL = cadenaMysql;
            strConexionMSSQL = cadenaMSSQL;
        }

        public   List<RegistrosEmpleadoSICA> GenerarReporteSICA(int IdEmpleado, DateTime fechaNomInicio, DateTime fechaFinNom)
        {

            var registrosEmpleados = new List<RegistrosEmpleadoSICA>();
            try
            {
                //var sql = @"sp_empleado_registros_procesados";
                var sql = @"sp_registro_empleado";
                var dpParametros = new DynamicParameters();
                dpParametros.Add("@idEmpleado", IdEmpleado);
                dpParametros.Add("@fechaInicio", fechaNomInicio.ToString("yyyy-MM-dd"));
                dpParametros.Add("@fechaFin", fechaFinNom.ToString("yyyy-MM-dd"));


                try
                {
                    using (MySqlConnection connection = new MySqlConnection(strConexionMYSQL))
                    {
                        var recRevoc =  connection.Query<RegistrosEmpleadoSICA>(sql, dpParametros,
                            commandType: CommandType.StoredProcedure, commandTimeout: 28800).ToList();
                        connection.Close();
                        connection.Dispose();
                        registrosEmpleados = recRevoc;
                        
                        return registrosEmpleados;
                        
                    }

                }
                catch (MySqlException MySqlEx)
                {
                    string MensajeError = "ERROR : " + MySqlEx.Message + ".";
                    throw new Exception(MensajeError, MySqlEx);
                }
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            

        }


        public List<InfoBiometrico> ObtenerTodasLasTerminales()
        {
            List<InfoBiometrico> infoConexion = new List<InfoBiometrico>();
            try
            {
                var sql = @"SELECT axs_idBiometrico AS IdTerminal, axs_ip AS IpTerminal, axs_puerto AS PortTerminal, axs_Descripcion AS NombreTerminal  FROM bio_Terminales WHERE axs_idEstatus = 1";

                try
                {
                    using (var connection = new MySqlConnection(strConexionMYSQL))
                    {
                        var recRevoc = connection.Query<InfoBiometrico>(
                        sql, commandType: CommandType.Text, commandTimeout: 28800).ToList();

                        infoConexion = recRevoc;
                    }
                }
                catch (MySqlException MySqlEx)
                {
                    infoConexion.Add(new InfoBiometrico { ConexionEstatus = false, ErrorMessage = MySqlEx.Message });
                }
                catch (Exception ex)
                {
                    infoConexion.Add(new InfoBiometrico { ConexionEstatus = false, ErrorMessage = ex.Message });
                }
            }
            catch (Exception ex)
            {
                infoConexion.Add(new InfoBiometrico { ConexionEstatus = false, ErrorMessage = ex.Message });
            }

            return infoConexion;
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
        public virtual void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
            // GC.SuppressFinalize(this);
        }


        #endregion


    }
}
