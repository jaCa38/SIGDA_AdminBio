using SIGDA.CA.Biometricos.Libreria.Conexion;
using SIGDA.CA.Biometricos.Libreria.Models;
using SIGDA.CA.Biometricos.Libreria.Services.Interfaces;
using SIGDA.CA.Biometricos.Libreria.Tools;
using Splash;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SIGDA.CA.Biometricos.Libreria.Controllers
{
    public class AdministracionBiometriasController : IAdministracionBiometrias, IDisposable
    {
        private string strConexionMYSQL;
        private string strConexionMSSQL;
        DataTableReader dtrResultado = null;

        public AdministracionBiometriasController(string cadenaMysql, string cadenaMSSQL)
        {
            strConexionMYSQL = cadenaMysql;
            strConexionMSSQL = cadenaMSSQL;
        }


        public BaseResultado EliminarEmpleadoBiometrico(int IdEmpleado, string IpTerminal, int PuertoConexion)
        {

            BaseResultado ResuldatoBorrado = new BaseResultado();

            try
            {
                using (FaceId Client = new FaceId(IpTerminal, PuertoConexion))
                {
                    String Answer;
                    string consulta = "DeleteEmployee(id=\"" + IdEmpleado.ToString() + "\")";
                    Client.ReceiveTimeout = ConexionStrings.TIMEOUT_CONEXION_TERMINAL;
                    FaceId_ErrorCode ErrorCode = Client.Execute(consulta, out Answer);
                    if (ErrorCode == FaceId_ErrorCode.Success)

                    {
                        ResuldatoBorrado.Resultado = true;
                        ResuldatoBorrado.ConexionStatus = true;
                    }
                    else
                    {
                        ResuldatoBorrado.Resultado = false;
                        ResuldatoBorrado.ConexionStatus = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ResuldatoBorrado.Resultado = false;
                ResuldatoBorrado.ConexionStatus = false;
                ResuldatoBorrado.ResultadoError = ex.Message;
            }
            return ResuldatoBorrado;


        }


        public BaseResultado VerificaBiometria(int IdEmpleado, string IpTerminal, int PuertoConexion)
        {
            BaseResultado resultadoVerificacion = new BaseResultado();
            //string IpTerminal = ObtenerIpTerminal(IdTerminal);

            try
            {
                using (FaceId Client = new FaceId(IpTerminal, PuertoConexion))
                {
                    String Answer;
                    string consulta = "GetEmployee(id=\"" + IdEmpleado + "\")";
                    Client.ReceiveTimeout = ConexionStrings.TIMEOUT_CONEXION_TERMINAL; ;
                    FaceId_ErrorCode ErrorCode = Client.Execute(consulta, out Answer);
                    if (ErrorCode == FaceId_ErrorCode.Success)

                    {
                        //   resultadoVerificacion.Add(new ResultadoVeficacionBiometria { ResultadoVerificacion = true, ConexionStatus = true });
                        resultadoVerificacion.Resultado = true;
                        resultadoVerificacion.ConexionStatus = true;
                    }
                    else
                    {
                        resultadoVerificacion.Resultado = false;
                        resultadoVerificacion.ConexionStatus = true;
                    }
                }
            }
            catch (Exception ex)
            {

                resultadoVerificacion.Resultado = false;
                resultadoVerificacion.ConexionStatus = false;
                resultadoVerificacion.ResultadoError = ex.Message;
            }
            return resultadoVerificacion;

        }

        public BiometriaEmpleado ObtenerBiometriaEmpleado(int idEmpleado, string ipTerminal, int puertoConexion, long numSerie)
        {
            var biometriaEmpleado = new BiometriaEmpleado();

            try
            {
                using (FaceId Client = new FaceId(ipTerminal, puertoConexion))
                {
                    String answer;
                    string consulta = "GetEmployee(id=\"" + idEmpleado + "\")";
                    Client.ReceiveTimeout = ConexionStrings.TIMEOUT_CONEXION_TERMINAL; ;
                    FaceId_ErrorCode ErrorCode = Client.Execute(consulta, out answer);
                    if (ErrorCode == FaceId_ErrorCode.Success)

                    {
                        biometriaEmpleado.Id = idEmpleado;
                        biometriaEmpleado.Template = ExtraerInfoBiometria.ObtenerdatosBiometria(answer, numSerie);
                        biometriaEmpleado.ExtraccionEstatus = true;
                        biometriaEmpleado.ConexionEstatus = true;

                    }
                    else
                    {
                        biometriaEmpleado.Id = idEmpleado;
                        biometriaEmpleado.ConexionEstatus = true;


                    }
                }
            }
            catch (Exception ex)
            {
                biometriaEmpleado.Id = idEmpleado;
                biometriaEmpleado.MensajeErro = ex.Message;
            }
            return biometriaEmpleado;

        }



        public bool EnviarBiometriaBio(string ipTerminal, int puertoConexion, byte[] bioTemplate)
        {
            bool envioResultado = false;

            string stringBiometria = Encoding.UTF8.GetString(bioTemplate);

            try
            {
                using (FaceId Client = new FaceId(ipTerminal, puertoConexion))
                {
                    string answer;
                    //string consulta = "SetEmployee(id=\"" + idEmpleado + "\" name=\""+ "" + "\" authority=\""+ authority + "\" card_num=\"" + cardNum + "\" calid=\""+"0" + "\" check_type=\"" + checkType + "\" opendoor_type=\"" + openDoorType + "\" password=\"" +""+ "\" face_data=\"" + face+"\")";
                    string consulta = "SetEmployee(" + stringBiometria + ")";
                    Client.ReceiveTimeout = ConexionStrings.TIMEOUT_CONEXION_TERMINAL;
                    Client.NoDelay = true;
                    FaceId_ErrorCode ErrorCode = Client.Execute(consulta, out answer);
                    if (ErrorCode == FaceId_ErrorCode.Success)

                    {

                        envioResultado = true;

                    }
                    else
                    {
                        envioResultado = false;
                    }
                }
            }
            catch (Exception ex)
            {
                envioResultado = false;
            }
            return envioResultado;

        }


        public List<int> ObtenerEmpleadosTerminalBiometrica(string ipTerminal, int puertoConexion)
        {
            List<int> listaBiometricos = new List<int>();
            //string IpTerminal = ObtenerIpTerminal(IdTerminal);

            try
            {
                using (FaceId Client = new FaceId(ipTerminal, puertoConexion))
                {
                    String answer;
                    string consulta = "GetEmployeeID()";
                    Client.ReceiveTimeout = ConexionStrings.TIMEOUT_CONEXION_TERMINAL; ;
                    FaceId_ErrorCode ErrorCode = Client.Execute(consulta, out answer);
                    if (ErrorCode == FaceId_ErrorCode.Success)

                    {
                        listaBiometricos = ExtraerListaEmpleadosTerminalBiometrica.ObtenerListaEmpleadosTerminalBiometrica(answer);
                        //biometriaEmpleado.Template = answer;

                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {

            }
            return listaBiometricos;

        }


        //public bool EnviarBiometriaBioPorIdTerminal(int idEmpleado, int IdTerminal)
        //{
        //    bool envioResultado = false;

        //    string stringBiometria = Encoding.UTF8.GetString(bioTemplate);



        //    try
        //    {
        //        using (FaceId Client = new FaceId(ipTerminal, puertoConexion))
        //        {
        //            string answer;
        //            //string consulta = "SetEmployee(id=\"" + idEmpleado + "\" name=\""+ "" + "\" authority=\""+ authority + "\" card_num=\"" + cardNum + "\" calid=\""+"0" + "\" check_type=\"" + checkType + "\" opendoor_type=\"" + openDoorType + "\" password=\"" +""+ "\" face_data=\"" + face+"\")";
        //            string consulta = "SetEmployee(" + stringBiometria + ")";
        //            Client.ReceiveTimeout = ConexionStrings.TIMEOUT_CONEXION_TERMINAL;
        //            Client.NoDelay = true;
        //            FaceId_ErrorCode ErrorCode = Client.Execute(consulta, out answer);
        //            if (ErrorCode == FaceId_ErrorCode.Success)

        //            {

        //                envioResultado = true;

        //            }
        //            else
        //            {
        //                envioResultado = false;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        envioResultado = false;
        //    }
        //    return envioResultado;

        //}




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
