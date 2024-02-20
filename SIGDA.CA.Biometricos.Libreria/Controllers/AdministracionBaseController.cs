using Dapper;
using MySql.Data.MySqlClient;
using SIGDA.CA.Biometricos.Libreria.Models;
using SIGDA.CA.Biometricos.Libreria.Services.Interfaces;
using SIGDA.CA.Biometricos.Libreria.Tools;
using Splash;
using System;
using System.Collections.Generic;
using System.Data;

namespace SIGDA.CA.Biometricos.Libreria.Controllers
{
    public class AdministracionBaseController : IAdministracionBase, IDisposable
    {
        private string strConexionMYSQL;
        private string strConexionMSSQL;
        DataTableReader dtrResultado = null;

        public AdministracionBaseController(string cadenaMysql, string cadenaMSSQL)
        {
            strConexionMYSQL = cadenaMysql;
            strConexionMSSQL = cadenaMSSQL;
        }

        public InfoBiometrico ObtenerInfoTerminal(int IdTerminal)
        {
            InfoBiometrico infobiometrico = new InfoBiometrico();
            try
            {
                var sql = @"SELECT axs_idBiometrico AS IdTerminal, axs_ip AS IpTerminal, axs_puerto AS PortTerminal, axs_Descripcion AS NombreTerminal  FROM bio_Terminales WHERE axs_idBiometrico in(" + IdTerminal + ")";

                using (var connection = new MySqlConnection(strConexionMYSQL))
                {
                    var recRevoc = connection.QuerySingle<InfoBiometrico>(
                    sql, commandType: CommandType.Text, commandTimeout: 28800);
                    infobiometrico.IdTerminal = recRevoc.IdTerminal;
                    infobiometrico.IpTerminal = recRevoc.IpTerminal;
                    infobiometrico.PortTerminal = recRevoc.PortTerminal;
                    infobiometrico.NombreTerminal = recRevoc.NombreTerminal;
                    infobiometrico.ConexionEstatus = true;
                    infobiometrico.ErrorMessage = null;


                }
            }
            catch (MySqlException MySqlEx)
            {
                infobiometrico.ConexionEstatus = false;
                infobiometrico.ErrorMessage = MySqlEx.Message;
            }
            catch (Exception ex)
            {
                infobiometrico.ConexionEstatus = false;
                infobiometrico.ErrorMessage = ex.Message;
            }

            return infobiometrico;

        }


        public List<RegistrosRelojes> ObtenerEmpleadoRegistrosTerminal(string ipTerminal, int puertoTerminal, int idEmpleado, DateTime fecha)
        {
            List<RegistrosRelojes> EmpleadoRegistros = new List<RegistrosRelojes>();
            string feInicio = fecha.Date.ToString("yyyy-MM-dd HH:mm:ss");
            string feFin = fecha.Date.AddHours(23).AddMinutes(59).AddSeconds(59).ToString("yyyy-MM-dd HH:mm:ss");
            try
            {
                using (FaceId Client = new FaceId(ipTerminal, puertoTerminal))
                {
                    String Answer;
                    string consulta = "GetRecord(start_time=\"" + feInicio + "\" end_time=\"" + feFin + "\")";
                    Client.ReceiveTimeout = 360000;
                    FaceId_ErrorCode ErrorCode = Client.Execute(consulta, out Answer);
                    if (ErrorCode == FaceId_ErrorCode.Success)

                    {
                        EmpleadoRegistros = FormatoInfoTerminales.FormatoRegistroRelojesPorEmpleado(Answer, idEmpleado);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return EmpleadoRegistros;
        }


        public List<RegistrosRelojes> ObtenerRegistrosTerminal(string IpTerminal, int PuertoTerminal, DateTime Fecha)
        {
            List<RegistrosRelojes> RegistrosTerminal = new List<RegistrosRelojes>();
            DateTime DiaInicio = Fecha.Date;
            DateTime DiaFin = DiaInicio.AddHours(23).AddMinutes(59).AddSeconds(59);


            try
            {
                using (FaceId Client = new FaceId(IpTerminal, PuertoTerminal))
                {

                    string Answer;
                    string consulta = "GetRecord(start_time=\"" + DiaInicio.ToString("yyyy-MM-dd HH:mm:ss") + "\"end_time=\"" + DiaFin.ToString("yyyy-MM-dd HH:mm:ss") + "\")";
                    Client.ReceiveTimeout = 360000;
                    FaceId_ErrorCode ErrorCode = Client.Execute(consulta, out Answer);
                    if (ErrorCode == FaceId_ErrorCode.Success)

                    {

                        RegistrosTerminal = FormatoInfoTerminales.FormatoRegistrosTerminal(Answer);

                    }
                }
            }

            catch (Exception ex)
            {
                RegistrosTerminal.Add(new RegistrosRelojes { ConexionReloj = false, ErrorMsj = ex.Message });
            }
            return RegistrosTerminal;
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
