using Dapper;
using MySql.Data.MySqlClient;
using SIGDA.CA.Biometricos.Libreria.Services.Interfaces;
using System;
using System.Data;

namespace SIGDA.CA.Biometricos.Libreria.Controllers
{
    public class EjecutarPaDbController : IEjecutarPaDb, IDisposable
    {

        private string strConexionMYSQL;
        private string strConexionMSSQL;
        DataTableReader dtrResultado = null;

        public EjecutarPaDbController(string cadenaMysql, string cadenaMSSQL)
        {
            strConexionMYSQL = cadenaMysql;
            strConexionMSSQL = cadenaMSSQL;
        }



        #region Insertar registros en SICA_MYSQL
        public bool EjecutarPaProcesarInfo()
        {

            var sql = @"spProcesarInfo";


            try
            {
                using (var connection = new MySqlConnection(strConexionMYSQL))
                {
                    var recRevoc = connection.Execute(sql, commandType: CommandType.StoredProcedure, commandTimeout: 2000);
                    return true;
                }
            }
            catch (MySqlException MySqlEx)
            {
                //string MensajeError = "ERROR : " + MySqlEx.Message + ".";
                //throw new Exception(MensajeError, MySqlEx);
                return false;
            }

        }






        #endregion




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
