using Dapper;
using MySql.Data.MySqlClient;
using SIGDA.CA.Biometricos.Libreria.Models;
using SIGDA.CA.Biometricos.Libreria.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SIGDA.CA.Biometricos.Libreria.Controllers
{
    public class ConsultarDbController : IConsultarDb
    {
        private string strConexionMYSQL;
        private string strConexionMSSQL;
        DataTableReader dtrResultado = null;

        public ConsultarDbController(string cadenaMysql, string cadenaMSSQL)
        {
            strConexionMYSQL = cadenaMysql;
            strConexionMSSQL = cadenaMSSQL;
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




        public List<ListaBiometriasEmpleado> ObtenerBiometriasEmpleadoDb(int IdEmpleado, string fw)
        {
            var listaBiometrias = new List<ListaBiometriasEmpleado>();
            try
            {
                var sql = @"[biometrico].[pa.Consulta_Biometrias_Empleado]";
                var dpParametros = new DynamicParameters();
                dpParametros.Add("@idEmpleado", IdEmpleado);
                dpParametros.Add("@versionFw", fw);

                try
                {
                    using (var connection = new SqlConnection(strConexionMSSQL))
                    {
                        var recRevoc = connection.Query<ListaBiometriasEmpleado>(sql, dpParametros,
                            commandType: CommandType.StoredProcedure, commandTimeout: 28800).ToList();

                        listaBiometrias = recRevoc;

                        return listaBiometrias;

                    }
                }
                catch (MySqlException MySqlEx)
                {
                    string MensajeError = "ERROR : " + MySqlEx.Message + ".";
                    throw new Exception(MensajeError, MySqlEx);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




        public List<TerminalesConBiometriaEmpleado> ObtenerListaBiometriasDb(int IdEmpleado, int idTerminal)
        {
            var listaBiometrias = new List<TerminalesConBiometriaEmpleado>();
            try
            {
                var sql = @"[biometrico].[pa.Consulta_Biometrias_Empleado_Terminal]";
                var dpParametros = new DynamicParameters();
                dpParametros.Add("@idEmpleado", IdEmpleado);
                dpParametros.Add("@idTerminal", idTerminal);

                try
                {
                    using (var connection = new SqlConnection(strConexionMSSQL))
                    {
                        var recRevoc = connection.Query<TerminalesConBiometriaEmpleado>(sql, dpParametros,
                            commandType: CommandType.StoredProcedure, commandTimeout: 28800).ToList();

                        listaBiometrias = recRevoc;

                        return listaBiometrias;

                    }
                }
                catch (MySqlException MySqlEx)
                {
                    string MensajeError = "ERROR : " + MySqlEx.Message + ".";
                    throw new Exception(MensajeError, MySqlEx);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public List<BiometriaTerminal> ObtenerBiometriaTerminalDb(int IdEmpleado, int idTerminal)
        {
            var listaBiometrias = new List<BiometriaTerminal>();
            try
            {
                var sql = @"[biometrico].[pa.Consulta_Biometria_Terminal]";
                var dpParametros = new DynamicParameters();
                dpParametros.Add("@idEmpleado", IdEmpleado);
                dpParametros.Add("@idTerminal", idTerminal);

                try
                {
                    using (var connection = new SqlConnection(strConexionMSSQL))
                    {
                        var recRevoc = connection.Query<BiometriaTerminal>(sql, dpParametros,
                            commandType: CommandType.StoredProcedure, commandTimeout: 28800).ToList();

                        listaBiometrias = recRevoc;

                        return listaBiometrias;

                    }
                }
                catch (MySqlException MySqlEx)
                {
                    string MensajeError = "ERROR : " + MySqlEx.Message + ".";
                    throw new Exception(MensajeError, MySqlEx);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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

    }
}
