using Dapper;
using MySql.Data.MySqlClient;
using SIGDA.CA.Biometricos.Libreria.Conexion;
using SIGDA.CA.Biometricos.Libreria.Models;
using SIGDA.CA.Biometricos.Libreria.Services.Interfaces;
using SIGDA.CA.Biometricos.Libreria.Tools;
using Splash;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace SIGDA.CA.Biometricos.Libreria.Controllers
{
    public class DescargaFotografiasController : AdministracionBaseController, IDescargaFotografias, IDisposable
    {

        private string strConexionMYSQL;
        private string strConexionMSSQL;
        DataTableReader dtrResultado = null;
        InfoBiometrico infoBiometrico;
        public DescargaFotografiasController(string cadenaMysql, string cadenaMSSQL) : base(cadenaMysql, cadenaMSSQL)
        {
            strConexionMYSQL = cadenaMysql;
            strConexionMSSQL = cadenaMSSQL;
        }

        public List<Foto> ObtenerFotosEmpleado(int empleadoId, int terminalId, DateTime fechaFotos)
        {
            List<RegistrosRelojes> registrosEmpleado = new List<RegistrosRelojes>();
            List<RutasFotos> rutasFoto = new List<RutasFotos>();
            List<Foto> fotoBase64 = new List<Foto>();

            try
            {
                infoBiometrico = ObtenerInfoTerminal(terminalId);
                string ipTerminal = HerramientasIp.ComprobarDireccionDeRed(infoBiometrico.IpTerminal);

                registrosEmpleado = ObtenerEmpleadoRegistrosTerminal(ipTerminal, infoBiometrico.PortTerminal, empleadoId, fechaFotos);
                if (!registrosEmpleado.Any())
                {

                    fotoBase64.Add(new Foto { FotoBase64 = null, IdEmpleado = 0, Registro = fechaFotos, EmpleadoEncontrado = false, ConexionReloj = false });
                }
                else
                {
                    using (FaceId Client = new FaceId(infoBiometrico.IpTerminal, infoBiometrico.PortTerminal))
                    {
                        String Answer;
                        string consulta = "GetPictureName(time=\"" + fechaFotos.ToString("yyyy-MM-dd") + "\" type=\"face\")";

                        Client.ReceiveTimeout = 35000;
                        FaceId_ErrorCode ErrorCode01 = Client.Execute(consulta, out Answer);
                        if (ErrorCode01 == FaceId_ErrorCode.Success)
                            rutasFoto = FormatoInfoTerminales.FormatoRutasFotos(Answer);

                    }
                    foreach (RutasFotos rut in rutasFoto)
                    {
                        var horaEmpleado = from hora in registrosEmpleado where hora.Record.ToString("HHmmss") == rut.Hora select hora;
                        if (horaEmpleado.Count() > 0)
                        {
                            fotoBase64.Add(new Foto { FotoBase64 = ObtenerFoto(rut.RutaFoto, infoBiometrico.IpTerminal, infoBiometrico.PortTerminal), Registro = horaEmpleado.ElementAt(0).Record, Hora = rut.Hora, EmpleadoEncontrado = true, ConexionReloj = true });
                        };
                    }
                }

            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);

                fotoBase64.Add(new Foto { FotoBase64 = null, IdEmpleado = 0, Registro = fechaFotos, EmpleadoEncontrado = false, ConexionReloj = false, ErrorMessagge = ex.ToString() });

            }
            return fotoBase64;
        }


        public List<Foto> ObtenerFotosOkTerminal(DateTime fechaFotos, string ipTerminal, int portTerminal)
        {
            //infoBiometrico = ObtenerInfoTerminal(TerminalId);
            List<RegistrosRelojes> RegistrosEmpleado = new List<RegistrosRelojes>();
            List<RutasFotos> RutasFoto = new List<RutasFotos>();
            List<Foto> FotoBase64 = new List<Foto>();




            try
            {
                RegistrosEmpleado = ObtenerRegistrosTerminal(ipTerminal, portTerminal, fechaFotos);

                if (RegistrosEmpleado.Count > 0)
                {
                    using (FaceId Client = new FaceId(ipTerminal, portTerminal))
                    {
                        String Answer;

                        string consulta = "GetPictureName(time=\"" + fechaFotos.ToString("yyyy-MM-dd") + "\" type=\"face\")";

                        Client.ReceiveTimeout = 35000;
                        FaceId_ErrorCode ErrorCode01 = Client.Execute(consulta, out Answer);
                        if (ErrorCode01 == FaceId_ErrorCode.Success)

                        {
                            RutasFoto = FormatoInfoTerminales.FormatoRutasFotos(Answer);
                        }
                        else
                        {
                            FotoBase64.Add(new Foto { ConexionReloj = false, CantidadRegistros = 0, CantidadFotos = 0 });
                        }
                    }
                    if (RegistrosEmpleado.Count > 0)
                    {
                        if (RutasFoto.Count > 0)
                        {
                            foreach (RutasFotos rut in RutasFoto)
                            {

                                var horaEmpleado = from hora in RegistrosEmpleado where hora.Hora.Equals(rut.Hora) select hora;

                                if (horaEmpleado.Count() > 0)
                                    FotoBase64.Add(new Foto { FotoBase64 = ObtenerFoto(rut.RutaFoto, ipTerminal, portTerminal), IdEmpleado = horaEmpleado.ElementAt(0).IdEmpleado, Registro = horaEmpleado.ElementAt(0).Record, ConexionReloj = true, CantidadRegistros = RegistrosEmpleado.Count(), CantidadFotos = RutasFoto.Count() });

                            }
                        }
                        else
                        {
                            FotoBase64.Add(new Foto { ConexionReloj = true, CantidadRegistros = RegistrosEmpleado.Count(), CantidadFotos = RutasFoto.Count() });
                        }
                    }
                    else
                    {
                        FotoBase64.Add(new Foto { ConexionReloj = true, CantidadRegistros = RegistrosEmpleado.Count(), CantidadFotos = RutasFoto.Count() });
                    }

                }
                else
                {
                    FotoBase64.Add(new Foto { FotoBase64 = null, IdEmpleado = 0, Registro = fechaFotos, CantidadRegistros = 0, EmpleadoEncontrado = false, CantidadFotos = 0, ConexionReloj = true, });
                }


            }
            catch (Exception ex)
            {
                // throw new Exception(ex.Message);
                FotoBase64.Add(new Foto { FotoBase64 = null, IdEmpleado = 0, Registro = fechaFotos, EmpleadoEncontrado = false, ConexionReloj = false, ErrorMessagge = ex.ToString() });
            }

            return FotoBase64;

        }



        public string ObtenerFoto(string ruta, string ipTerminal, int portConexion)
        {
            string FotoOk = "";
            try
            {
                using (FaceId Client = new FaceId(ipTerminal, portConexion))
                {
                    String Answer;
                    string consulta = "GetPicture(name=\"" + ruta + "\")";
                    Client.ReceiveTimeout = 35000;
                    FaceId_ErrorCode ErrorCode01 = Client.Execute(consulta, out Answer);
                    if (ErrorCode01 == FaceId_ErrorCode.Success)

                    {

                        FotoOk = FormatoInfoTerminales.FormatoFoto(Answer);

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

            return FotoOk;
        }




        public List<FotoSorry> ObtenerFotosFailed(DateTime Fecha, string ipTerminal, int puertoTerminal)
        {
            List<FotoSorry> FotosSorry = new List<FotoSorry>();
            List<RutasFotos> RutasFotosSorry = new List<RutasFotos>();
            ipTerminal = HerramientasIp.ComprobarDireccionDeRed(ipTerminal);
            string fotosFailed = string.Empty;
            //infoBiometrico = ObtenerInfoTerminal(IdTerminal);
            try
            {
                using (FaceId Client = new FaceId(ipTerminal, puertoTerminal))
                {
                    String Answer;

                    string consulta = "GetPictureName(time=\"" + Fecha.ToString("yyyy-MM-dd") + "\"type=\"photo\")";

                    Client.ReceiveTimeout = ConexionStrings.TIMEOUT_CONEXION_TERMINAL;
                    FaceId_ErrorCode ErrorCode01 = Client.Execute(consulta, out Answer);
                    if (ErrorCode01 == FaceId_ErrorCode.Success)

                    {
                        fotosFailed = Answer;

                    }
                    else
                    {
                        FotosSorry.Add(new FotoSorry { FotoSorryExist = false, ConexionReloj = true });
                    }

                }

                fotosFailed = fotosFailed.Replace("Return(result=\"success\")", "").Replace("Return(result=\"success\" )", "").Trim();

                if (fotosFailed == "")
                {
                    FotosSorry.Add(new FotoSorry { FotoSorryExist = false, ConexionReloj = true });
                }
                else
                {
                    RutasFotosSorry = FormatoInfoTerminales.FormatoRutasFotos(fotosFailed);


                    foreach (RutasFotos rutaFotosSorry in RutasFotosSorry)
                    {
                        string SigleFotoSorry = ObtenerFoto(rutaFotosSorry.RutaFoto, ipTerminal, puertoTerminal);
                        FotosSorry.Add(new FotoSorry { FotoBase64 = SigleFotoSorry, Hora = rutaFotosSorry.Hora, ConexionReloj = true, CantidadFotos = RutasFotosSorry.Count() });
                    }
                }





            }
            catch (Exception ex)
            {
                FotosSorry.Add(new FotoSorry { ConexionReloj = false, ErrorMessagge = ex.Message });
            }

            return FotosSorry;
        }


        public FotosResualtado DescargarFotosOkBiometrico(DateTime fechaFotos, string ipTerminal, int portTerminal, string nombreTerminal)
        {

            List<Foto> fotosbase64 = new List<Foto>();
            var fotosResultado = new FotosResualtado();

            try
            {

                string directorioimagenes = ConexionStrings.IMAGES_STORAGE_FOLDER + fechaFotos.ToString("yyyy-MM-dd") + "\\" + nombreTerminal + "\\OK";
                Directory.CreateDirectory(directorioimagenes);
                fotosbase64 = ObtenerFotosOkTerminal(fechaFotos, ipTerminal, portTerminal);

                if (fotosbase64.Count > 0)
                {
                    if (fotosbase64.ElementAt(0).ConexionReloj == false)
                    {
                        fotosResultado.ConexionEstatus = false;
                        fotosResultado.MsjError = fotosbase64.ElementAt(0).ErrorMessagge;

                    }
                    else
                    {
                        if (fotosbase64.ElementAt(0).CantidadRegistros > 0 && fotosbase64.ElementAt(0).CantidadFotos > 0)
                        {
                            foreach (Foto foto in fotosbase64)
                            {

                                string imagename = foto.IdEmpleado.ToString() + "_" + foto.Registro.ToString("yyyy_MM_dd HH_mm_ss") + ".jpg";

                                //set the image path
                                string imgpath = Path.Combine(directorioimagenes, imagename);

                                byte[] imagebytes = Convert.FromBase64String(foto.FotoBase64);

                                File.WriteAllBytes(imgpath, imagebytes);

                            }
                            fotosResultado.CantidadFotos = fotosbase64.ElementAt(0).CantidadFotos;
                            fotosResultado.CantidadRegistros = fotosbase64.ElementAt(0).CantidadRegistros;
                            fotosResultado.ConexionEstatus = true;
                        }
                        else
                        {
                            fotosResultado.CantidadFotos = fotosbase64.ElementAt(0).CantidadFotos;
                            fotosResultado.CantidadRegistros = fotosbase64.ElementAt(0).CantidadRegistros;
                            fotosResultado.ConexionEstatus = true;

                        }

                    }
                }



            }
            catch
            {
                fotosResultado.ConexionEstatus = false;
                fotosResultado.MsjError = fotosbase64.ElementAt(0).ErrorMessagge;
            }

            return fotosResultado;
        }


        public FotosResualtado DescargarFotosSorryBiometrico(DateTime fechaFotos, string ipTerminal, int portTerminal, string nombreTerminal)
        {

            var fotosSorrybase64 = new List<FotoSorry>();
            var fotosResultado = new FotosResualtado();

            try
            {

                string directorioimagenes = ConexionStrings.IMAGES_STORAGE_FOLDER + fechaFotos.ToString("yyyy-MM-dd") + "\\" + nombreTerminal + "\\SORRY";
                Directory.CreateDirectory(directorioimagenes);
                fotosSorrybase64 = ObtenerFotosFailed(fechaFotos, ipTerminal, portTerminal);

                if (fotosSorrybase64.Count > 0)
                {
                    if (fotosSorrybase64.ElementAt(0).ConexionReloj == false)
                    {
                        fotosResultado.ConexionEstatus = false;
                        fotosResultado.MsjError = fotosSorrybase64.ElementAt(0).ErrorMessagge;

                    }
                    else
                    {
                        if (fotosSorrybase64.ElementAt(0).CantidadFotos > 0)
                        {
                            foreach (FotoSorry foto in fotosSorrybase64)
                            {

                                //string imagename = foto.IdEmpleado.ToString() + "_" + foto.Registro.ToString("yyyy_MM_dd HH_mm_ss") + ".jpg";
                                string imagename = foto.Hora + ".jpg";
                                //set the image path
                                string imgpath = Path.Combine(directorioimagenes, imagename);

                                byte[] imagebytes = Convert.FromBase64String(foto.FotoBase64);

                                File.WriteAllBytes(imgpath, imagebytes);

                            }
                            fotosResultado.CantidadFotos = fotosSorrybase64.ElementAt(0).CantidadFotos;
                            //fotosResultado.CantidadRegistros = fotosSorrybase64.ElementAt(0).CantidadRegistros;
                            fotosResultado.ConexionEstatus = true;
                        }
                        else
                        {
                            fotosResultado.CantidadFotos = fotosSorrybase64.ElementAt(0).CantidadFotos;
                            //fotosResultado.CantidadRegistros = fotosSorrybase64.ElementAt(0).CantidadRegistros;
                            fotosResultado.ConexionEstatus = true;

                        }

                    }
                }



            }
            catch
            {
                fotosResultado.ConexionEstatus = false;
                fotosResultado.MsjError = fotosSorrybase64.ElementAt(0).ErrorMessagge;
            }

            return fotosResultado;
        }







        public bool InsertarLogDescargaFotosMSSQL(int idTerminal, DateTime fechaDescarga, int cantidadFotos, int CantidadRegistros)
        {
            try
            {
                var sql = @"[biometrico].[pa_Log_Fotos_Descarga]";
                var dpParametros = new DynamicParameters();
                dpParametros.Add("@idTerminal", idTerminal);
                dpParametros.Add("@fechaFotos", fechaDescarga);
                dpParametros.Add("@cantidadFotografias", cantidadFotos);
                dpParametros.Add("@cantidadRegistros", CantidadRegistros);


                try
                {
                    using (var connection = new SqlConnection(strConexionMSSQL))
                    {
                        var recRevoc = connection.Execute(sql, dpParametros, commandType: CommandType.StoredProcedure, commandTimeout: 2500);
                        return true;

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
        protected new void Dispose(bool disposing)
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
        public new void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
            // GC.SuppressFinalize(this);
        }


        #endregion

    }
}

