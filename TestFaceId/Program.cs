using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Dapper;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Net;
using Splash;

namespace TestFaceId
{
    internal class Program
    {
        private const Int32 DeviceCodePage = 65001;
        private static DateTime fechaInicio = DateTime.Parse("2023-08-23");
        private static DateTime fechaFin = DateTime.Now;
        private static string strCadenaMSQL = "Data Source=192.168.1.12;Initial Catalog=SIGDA_CA;Persist Security Info=True;User Id=sa;Password=Sa12345;Encrypt=False;TrustServerCertificate=True";
        private static string strCadenaSQL = "Data Source=192.168.1.63;Initial Catalog=SIGDA_CA;Persist Security Info=True;User Id=docker;Password=@S1st3m4!78;Encrypt=False;TrustServerCertificate=True";

        #region Test de conexión a Relojes con FaceId
#if true
        static void Main(string[] args)
        {
            //string Info = ObtenerNumeroSerial("10.6.11.125");
            //Console.WriteLine(Info);
            //Console.ReadKey();

            string result2 = "";

            //ListadoImagenes("172.12.1.26", 9922, "", DateTime.Now, 9);

            List<RegistroBiometricoRequest> listaRegistros = new List<RegistroBiometricoRequest>();
            try
            {
                using (FaceId Client = new FaceId("172.12.1.27", Convert.ToInt32("9922")))
                {
                    String Answer;
                    string consulta = "GetRecord(start_time=\"" + fechaInicio.AddDays(-1).ToString("yyyy-MM-dd") + " 00:00:00\" end_time=\"" + fechaFin.AddDays(1).ToString("yyyy-MM-dd") + " 23:59:59\")";
                    Client.ReceiveTimeout = 360000;
                    FaceId_ErrorCode ErrorCode = Client.Execute(consulta, out Answer, DeviceCodePage);
                    if (ErrorCode == FaceId_ErrorCode.Success)
                    {
                        String Pattern = "\\b(time=.+\r\n(?:photo=\"[^\"]+\")*)";
                        String[] subcadena = Answer.Split('\"');
                        string id = subcadena[3];
                        MatchCollection matches = Regex.Matches(Answer, Pattern);
                        if (matches != null)
                        {
                            foreach (Match match in matches)
                            {
                                result2 = match.Groups[1].Value + "\r\n";
                                listaRegistros.Add(Division(result2, id, Client));

                            }
                        }
                    }
                    else
                    {
                        //MessageBox.Show("Error Code: " + ErrorCode.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Console.ReadKey();
        }
         public static String ObtenerNumeroSerial(String ip)
        {
            String result = null;

            if (ip != "")
            {

                try
                {
                    using (FaceId Client = new FaceId(ip, 9922))
                    {
                        String Answer;
                        FaceId_ErrorCode ErrorCode = Client.Execute("GetDeviceInfo()", out Answer, DeviceCodePage);
                        if (ErrorCode == FaceId_ErrorCode.Success)
                        {
                            String Pattern = "\\b(time=.+\r\n(?:photo=\"[^\"]+\")*)";
                            String[] subcadena = Answer.Split('\"');
                            string id = subcadena[5];
                            result = id;
                        }

                    }

                }
                catch (Exception e)
                {
                    result = null;//errorDescarga(idBiometrico, horaInicio, e.ToString());
                }

            }

            return result;
        }
        public static RegistroBiometricoRequest Division(String Resultado, string id, FaceId Client)
        {
            String[] subcadenas = Resultado.Split('\"');
            String[] fechaHora = subcadenas[1].Split(' ');
            RegistroBiometricoRequest registroBiometricoRequests = new RegistroBiometricoRequest();
            int intEstatus = 0;
            int.TryParse(subcadenas[9], out intEstatus);
           
            registroBiometricoRequests.IdUsuario = Convert.ToInt32(subcadenas[3]);
            /*
             * 44121 Marcos SAP
             * 40772 Ismael SMA
            */
            if (registroBiometricoRequests.IdUsuario == 44121)
            {
                registroBiometricoRequests.SerialBiometrico = id;
                registroBiometricoRequests.NombreUsuario = subcadenas[5];
                registroBiometricoRequests.Estatus = intEstatus;
                registroBiometricoRequests.Fecha = fechaHora[0];
                registroBiometricoRequests.Hora = fechaHora[1];
                registroBiometricoRequests.FechaSubida = DateTime.Today;
                GetPhotoEmployee(registroBiometricoRequests.IdUsuario.ToString(), registroBiometricoRequests.Fecha, Client);
                Console.WriteLine(Resultado);
            }
          
            return registroBiometricoRequests;
        }
        static List<FotografiaBiometricoViewModel> ListadoImagenes(string ip, int puerto, string tipo, DateTime fecha, int idBiometrico)
        {
            String ipGenerado = BusquedaIP(ip);
            if (puerto == 0)
            {
                puerto = 9922;
            }
            //String consulta = "GetPictureName(time=\"" + fecha.ToString("yyyy-MM-dd") + "\" type=\"" + tipo + "\")";

            String consulta = "GetPictureNameByID(id=\""+ "41243" + "time=\"" + "2023-09-20" + " type=\"" + "face \")";
            try
            {

                List<FotografiaBiometricoViewModel> fotografiaBiometricoViewModelsList = new List<FotografiaBiometricoViewModel>();
                String respuesta = "";
                using (FaceId Client = new FaceId(ipGenerado, puerto))
                {
                    Client.ReceiveTimeout = 240000;
                    String Answer = "";
                    FaceId_ErrorCode ErrorCode = Client.Execute(consulta, out Answer, DeviceCodePage);
                    if (ErrorCode == FaceId_ErrorCode.Success)
                    {
                        respuesta = Answer;

                    }
                }

                if (!String.IsNullOrEmpty(respuesta))
                {
                    //fotografiaBiometricoViewModelsList = ObtenerListadoImagenes(respuesta, ip, idBiometrico, puerto);
                }

                return fotografiaBiometricoViewModelsList;
            }
            catch (Exception e)
            {
                // System.Console.WriteLine(consulta + idBiometrico + " " + ip);
                // System.Console.WriteLine("L168");
                System.Console.WriteLine(e.Message);
                // System.Console.WriteLine(e.StackTrace);
                // System.Diagnostics.Debug.WriteLine(e.Message);
                return null;
            }
        }
       /* private List<FotografiaBiometricoViewModel> ObtenerListadoImagenes(string respuesta, string ipBiometrico, int idBiometrico, int puerto)
        {
            String Pattern = "name=\\\"(.*?)\\\"";
            List<string> listadoImagenes = ProcesarListados(Pattern, respuesta);
            List<FotografiaBiometricoViewModel> listaFotografias = new List<FotografiaBiometricoViewModel>();


            foreach (string datosImagen in listadoImagenes)
            {

                FotografiaBiometricoViewModel foto = new FotografiaBiometricoViewModel();
                foto.rutaCompleta = datosImagen;

                String valores = datosImagen.Replace(".JPG\"", "");

                foto.hora = valores.Substring(valores.Length - 6, 6);
                foto.ipBiometrico = ipBiometrico;
                foto.idBiometrico = idBiometrico;
                foto.puerto = puerto;

                if (valores.Contains("OK"))
                {
                    foto.tipo = "OK";
                }
                else
                {
                    foto.tipo = "SORRY";
                }

                listaFotografias.Add(foto);


            }

            return listaFotografias;

        }
       */
        static string BusquedaIP(string direccionUrl)
        {
            String addresses = "";

            if (direccionUrl != "")
            {
                char[] caracteres = direccionUrl.ToCharArray();

                if (Char.IsDigit(caracteres[0]) && Char.IsDigit(caracteres[1]))
                {
                    addresses = direccionUrl;
                }
                else
                {
                    IPAddress[] dir = Dns.GetHostAddresses(direccionUrl);
                    addresses = dir[0].ToString();
                }
            }
            else
            {
                addresses = "";
            }

            return addresses;
        }
        static void GetPhotoEmployee(string NumeroEmpleado,string Fecha, FaceId Client)
        {

            //GetPictureNameByID(id = "1220" time = "2014-02-03" type = "face/card")

            String Answer;
            string consulta = "GetPictureNameByID(id=" + NumeroEmpleado + " time = \"" + Fecha + "\" type = face/card)";
            //Client.ReceiveTimeout = 360000;
            FaceId_ErrorCode ErrorCode = Client.Execute(consulta, out Answer, DeviceCodePage);
            if (ErrorCode == FaceId_ErrorCode.Success)
            {
                String[] subcadena = Answer.Split('\"');
            }
        }
#endif
        #endregion

        #region Proceso de depuración de relojes 
#if false
        static void Main(string[] args)
        {
            string result2 = "";
            List<BiometricoDepurado> listaRegistros = new List<BiometricoDepurado>();
            var sql = @"SELECT [bide_id] AS Identificador,[bide_idEmpleado] AS IdentificadorEmpleado,[bide_idReloj] AS IdentificadorReloj,[bide_IP] AS BideIP FROM [SIGDA_CA].[biometrico].[BIOMETRICO_DEPURACION] WHERE bide_depurado=0";

            try
            {
                using (var connection = new SqlConnection(strCadenaMSQL))
                {
                    var recRevoc = connection.Query<BiometricoDepurado>(
                        sql,
           new { FechaI = fechaInicio, FechaF = fechaFin }, commandType: CommandType.Text
           , commandTimeout: 28800
           ).ToList();
                    listaRegistros = recRevoc;
                }

                if (listaRegistros.Count > 0)
                {
                    foreach (var rec in listaRegistros) {
                        using (FaceId Client = new FaceId(rec.BideIP, Convert.ToInt32("9922")))
                        {
                            String Answer;
                            string consulta = "DeleteEmployee(id=\"" + rec.IdentificadorEmpleado + "\")";
                            Client.ReceiveTimeout = 360000;
                            FaceId_ErrorCode ErrorCode = Client.Execute(consulta, out Answer, DeviceCodePage);
                            if (ErrorCode == FaceId_ErrorCode.Success)
                            {
                                var sql2 = @"UPDATE [biometrico].[BIOMETRICO_DEPURACION] SET [bide_depurado] = 1, [bide_fechaDepuracion] = GETDATE() WHERE bide_id= @Identificador";

                                try
                                {
                                    using (var connection = new SqlConnection(strCadenaMSQL))
                                    {
                                        var rowsAffected = connection.Execute(sql2, new { Identificador = rec.Identificador }, commandType: CommandType.Text
           , commandTimeout: 28800);
                                    }
                                }
                                catch (SqlException SqlEx)
                                {
                                    string MensajeError = "ERROR : " + SqlEx.Message + ".";
                                    throw new Exception(MensajeError, SqlEx);
                                }
                                catch (Exception ex)
                                {
                                    throw new Exception(ex.Message, ex);
                                }
                            }
                            else
                                throw new Exception("Error Code: " + ErrorCode.ToString());
                        }
                    }
                }
            }
            catch (SqlException MySqlEx)
            {
                string MensajeError = "ERROR : " + MySqlEx.Message + ".";
                throw new Exception(MensajeError, MySqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            Console.WriteLine("Proceso terminado??.. Verificar!!!! =)");
            Console.ReadKey();
        }
#endif
        #endregion

        #region Proceso de Ángel para Participaciones
#if false
        static void Main(string[] args)
        {
            string result2 = "";
            var sql = @"exec [asf].[pa_auxTimbresNomOrd_ObtenerInfoEncabezado_JSON_v1] 2023";

            try
            {
                using (var connection = new SqlConnection("Data Source=192.168.1.63;Initial Catalog=SRHN;User Id=sa;Password=@S1st3m4$78;Encrypt=False;TrustServerCertificate=True"))
                {
                    var recRevoc = connection.ExecuteScalar(
                        sql, commandType: CommandType.Text
           , commandTimeout: 28800
           );
                    Root m = JsonConvert.DeserializeObject<Root>(recRevoc.ToString());

                }

            }
            catch (SqlException MySqlEx)
            {
                string MensajeError = "ERROR : " + MySqlEx.Message + ".";
                throw new Exception(MensajeError, MySqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            Console.WriteLine("Proceso terminado??.. Verificar!!!! =)");
            Console.ReadKey();
        }
#endif
        #endregion

        #region Reestructura de directorios y archivos para generar neuronas de entrada bajo el proceso descrito en:  https://www.codemag.com/Article/2205081/Implementing-Face-Recognition-Using-Deep-Learning-and-Support-Vector-Machines Uso de Transfer Learning para reconocimiento de caras

#if true
        #region Reestructura de ruta a las fotos 2019,2020,2021 y 2022
#if false
        static void Main(string[] args)
        {
            string pathPrincipal = @"C:\fotosChecadores";
            string pathFotosTraining = @"C:\fotosChecadoresTraining\";

            /*//original dimension of image 223 x 240
            Bitmap img = new Bitmap(@"G:\Xochilt Files\TEMP\Foto de Ramon Atilano.jpg");
            //we are resizing to 110 x 120
            var resizedImg = ResizeImage(img, 28, 21);
            //save file
            resizedImg.Save(@"G:\Xochilt Files\TEMP\resize.jpg");*/

            //Proceso 1 leer todos los directorios de las fotografías de los checadores como se descargaron del servidor
            string[] folders = Directory.GetDirectories(pathPrincipal);

            foreach (var item in folders)
            {
                //Proceso 2: Se leen subfolder del path principal
                string[] subFoldersDia = Directory.GetDirectories(item);
                foreach (var subFolder in subFoldersDia)
                {
                    //Proceso 3: Se leen subfolder por juzgado
                    string[] subsubFolderJuzgado = Directory.GetDirectories(subFolder);

                    foreach (var subsubFolder in subsubFolderJuzgado)
                    {
                        //Proceso 4: Solo se leen imagenes que fueron OK en el registro
                        if (subsubFolder.Contains("OK"))
                        {
                            string[] fotos = Directory.GetFiles(subsubFolder);
                            if (fotos.Length > 0)
                                foreach (string foto in fotos)
                                {
                                    //Proceso 5: Discriminar split con \
                                    string[] estructuraRutaCompleta = foto.Split('\\');
                                    string[] estructuraJPG = null;
                                    try
                                    {
                                        //Proceso 6: Split por guión bajo para obtener primera posición con el numero de empleado
                                        estructuraJPG = estructuraRutaCompleta[5].Split('_');
                                        if (estructuraJPG.Length > 0)
                                        {
                                            long numeroEmpleado = long.Parse(estructuraJPG[0]);
                                            if (numeroEmpleado > 0 && (numeroEmpleado == 42396 ||
                                                                        numeroEmpleado == 38231 ||
                                                                        numeroEmpleado == 40587 ||
                                                                        numeroEmpleado == 44299 ||
                                                                        numeroEmpleado == 23258 ||
                                                                        numeroEmpleado == 34439 ||
                                                                        numeroEmpleado == 19960 ||
                                                                        numeroEmpleado == 8117 ||
                                                                        numeroEmpleado == 44242 ||
                                                                        numeroEmpleado == 14374 ||
                                                                        numeroEmpleado == 44321 ||
                                                                        numeroEmpleado == 21858 ||
                                                                        numeroEmpleado == 29616 ||
                                                                        numeroEmpleado == 44907 ||
                                                                        numeroEmpleado == 40247 ||
                                                                        numeroEmpleado == 43925 ||
                                                                        numeroEmpleado == 42397 ||
                                                                        numeroEmpleado == 44872 ||
                                                                        numeroEmpleado == 44619 ||
                                                                        numeroEmpleado == 43418 ||
                                                                        numeroEmpleado == 40573 ||
                                                                        numeroEmpleado == 44718 ||
                                                                        numeroEmpleado == 42612 ||
                                                                        numeroEmpleado == 34996 ||
                                                                        numeroEmpleado == 17510 ||
                                                                        numeroEmpleado == 41297 ||
                                                                        numeroEmpleado == 44225 ||
                                                                        numeroEmpleado == 41892 ||
                                                                        numeroEmpleado == 8272 ||
                                                                        numeroEmpleado == 40660 ||
                                                                        numeroEmpleado == 43799 ||
                                                                        numeroEmpleado == 43221 ||
                                                                        numeroEmpleado == 44854 ||
                                                                        numeroEmpleado == 40084 ||
                                                                        numeroEmpleado == 42620 ||
                                                                        numeroEmpleado == 44223 ||
                                                                        numeroEmpleado == 44731 ||
                                                                        numeroEmpleado == 41510 ||
                                                                        numeroEmpleado == 37132 ||
                                                                        numeroEmpleado == 44851 ||
                                                                        numeroEmpleado == 40655 ||
                                                                        numeroEmpleado == 43164 ||
                                                                        numeroEmpleado == 1004562 ||
                                                                        numeroEmpleado == 40650 ||
                                                                        numeroEmpleado == 9575 ||
                                                                        numeroEmpleado == 45100 ||
                                                                        numeroEmpleado == 40352 ||
                                                                        numeroEmpleado == 2125 ||
                                                                        numeroEmpleado == 43580 ||
                                                                        numeroEmpleado == 42501 ||
                                                                        numeroEmpleado == 44686 ||
                                                                        numeroEmpleado == 42881 ||
                                                                        numeroEmpleado == 43402 ||
                                                                        numeroEmpleado == 40284 ||
                                                                        numeroEmpleado == 44052 ||
                                                                        numeroEmpleado == 44017 ||
                                                                        numeroEmpleado == 30043 ||
                                                                        numeroEmpleado == 36633 ||
                                                                        numeroEmpleado == 44919 ||
                                                                        numeroEmpleado == 43524 ||
                                                                        numeroEmpleado == 12558 ||
                                                                        numeroEmpleado == 5268 ||
                                                                        numeroEmpleado == 43755 ||
                                                                        numeroEmpleado == 41839 ||
                                                                        numeroEmpleado == 41873 ||
                                                                        numeroEmpleado == 43593 ||
                                                                        numeroEmpleado == 37833 ||
                                                                        numeroEmpleado == 45231 ||
                                                                        numeroEmpleado == 42940 ||
                                                                        numeroEmpleado == 28703 ||
                                                                        numeroEmpleado == 34570 ||
                                                                        numeroEmpleado == 14582 ||
                                                                        numeroEmpleado == 8727 ||
                                                                        numeroEmpleado == 43152 ||
                                                                        numeroEmpleado == 42001 ||
                                                                        numeroEmpleado == 41609 ||
                                                                        numeroEmpleado == 42335 ||
                                                                        numeroEmpleado == 42926 ||
                                                                        numeroEmpleado == 45273 ||
                                                                        numeroEmpleado == 44346 ||
                                                                        numeroEmpleado == 28583 ||
                                                                        numeroEmpleado == 40520 ||
                                                                        numeroEmpleado == 45295 ||
                                                                        numeroEmpleado == 1004136 ||
                                                                        numeroEmpleado == 42479 ||
                                                                        numeroEmpleado == 44958 ||
                                                                        numeroEmpleado == 44839))
                                            {
                                                //Proceso 7: Validar si existe directorio de numero de empleado y si no crear
                                                if (!Directory.Exists(pathFotosTraining + numeroEmpleado.ToString()))
                                                    Directory.CreateDirectory(pathFotosTraining + numeroEmpleado.ToString());

                                                //Proceso 8: Mover imagen a la nueva ruta
                                                //File.Move(foto, pathFotosTraining + numeroEmpleado.ToString() + @"\" + estructuraRutaCompleta[5].ToString());
                                                File.Copy(foto, pathFotosTraining + numeroEmpleado.ToString() + @"\" + estructuraRutaCompleta[5].ToString());

                                            }
                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        //Al día 26-07-2023 que estoy desarrollando esto, cae en el catch los archivos Thumbnails [se omiten]
                                    }
                                }
                        }
                    }

                }
            }

            Console.WriteLine("Ya terminé");
            Console.ReadKey();
        }
#endif
        #endregion

#if false
        #region Reestructura de ruta a las fotos 2023 con conexión a BD del 63 para crear relación Empleado-Reloj
        static void Main(string[] args)
        {
            string pathPrincipal = @"C:\fotosChecadores2023";
            string pathFotosTraining = @"C:\fotosChecadoresTraining\";

            //Proceso 1 leer todos los directorios de las fotografías de los checadores como se descargaron del servidor
            string[] folders = Directory.GetDirectories(pathPrincipal);

            foreach (var item in folders)
            {
                //Proceso 2: Se leen subfolder del path principal [Nombre del reloj]
                string[] subFoldersDia = Directory.GetDirectories(item);
                foreach (var subFolder in subFoldersDia)
                {

                    string[] estructuraFolderReloj = subFolder.Split('_');
                    string[] estructuraFolderRelojSede = estructuraFolderReloj[2].Split('\\');
                    string Sede = estructuraFolderRelojSede[1];
                    string Dispositivo = estructuraFolderReloj[3];

                    //Proceso 3: Se leen subfolder por juzgado
                    string[] subsubFolderJuzgado = Directory.GetDirectories(subFolder);

                    foreach (var subsubFolder in subsubFolderJuzgado)
                    {
                        //Proceso 4: Solo se leen imagenes que fueron OK en el registro
                        if (subsubFolder.Contains("OK"))
                        {
                            string[] fotos = Directory.GetFiles(subsubFolder);
                            if (fotos.Length > 0)
                                foreach (string foto in fotos)
                                {
                                    //Proceso 5: Discriminar split con \
                                    string[] estructuraRutaCompleta = foto.Split('\\');
                                    string[] estructuraJPG = null;
                                    try
                                    {
                                        //Proceso 6: Split por guión bajo para obtener primera posición con el numero de empleado
                                        estructuraJPG = estructuraRutaCompleta[5].Split('_');
                                        if (estructuraJPG.Length > 0)
                                        {
                                            long numeroEmpleado = long.Parse(estructuraJPG[0]);
                                            if (numeroEmpleado > 0)
                                            {
                                                //Proceso 7: Validar si existe directorio de numero de empleado y si no crear
                                                if (!Directory.Exists(pathFotosTraining + numeroEmpleado.ToString()))
                                                    Directory.CreateDirectory(pathFotosTraining + numeroEmpleado.ToString());

                                                //Insertar relación Reloj y Empleado
                                                var sql = @"[biometrico].[pa_EmpleadoBiometricoReloj_Almacena]";
                                                var dpParametros = new DynamicParameters();
                                                dpParametros.Add("@Sede", Sede);
                                                dpParametros.Add("@Dispositivo", Dispositivo);
                                                dpParametros.Add("@idEmpleado", numeroEmpleado);
                                                try
                                                {
                                                    using (var connection = new SqlConnection(strCadenaSQL))
                                                    {
                                                        var recRevoc = connection.Execute(
                                                            sql,
                                                            dpParametros, commandType: CommandType.StoredProcedure
                                                            //, splitOn: "IdentificadorElementoIndice"
                                                            , commandTimeout: 2000);
                                                    }

                                                    //Proceso 8: Mover imagen a la nueva ruta
                                                    File.Move(foto, pathFotosTraining + numeroEmpleado.ToString() + @"\" + estructuraRutaCompleta[5].ToString());
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
                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        //Al día 26-07-2023 que estoy desarrollando esto, cae en el catch los archivos Thumbnails [se omiten]
                                    }
                                }
                        }
                    }

                }
            }

            Console.WriteLine("Ya terminé");
            Console.ReadKey();
        }
        #endregion
#endif
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            //create new destImage object
            var destImage = new Bitmap(width, height);

            //maintains DPI regardless of physical size
            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                //determines whether pixels from a source image overwrite or are combined with background pixels.
                graphics.CompositingMode = CompositingMode.SourceCopy;
                //determines the rendering quality level of layered images.
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                // determines how intermediate values between two endpoints are calculated
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                //specifies whether lines, curves, and the edges of filled areas use smoothing 
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                //affects rendering quality when drawing the new image
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    //prevents ghosting around the image borders
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

#endif
#endregion
    }


    public class RegistroBiometricoRequest
    {
        public Int32 IdRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public int Estatus { get; set; }
        public String SerialBiometrico { get; set; }
        public DateTime FechaSubida { get; set; }
        public int IdBiometrico { get; set; }
    }
    public class BiometricoDepurado
    {
        public long Identificador { get; set; }
        public long IdentificadorEmpleado { get; set; }
        public long IdentificadorReloj { get; set; }
        public string BideIP { get; set; }
    }

    public class Deduccione
    {
        public string Clave { get; set; }
        public double Importe { get; set; }
        public int TipoClave { get; set; }
    }

    public class EncabezadoNomOrdBase
    {
        public int IdGeneral { get; set; }
        public string Serie { get; set; }
        public int IdEmpleado { get; set; }
        //public string TipoNomina { get; set; }
        public string PeriodicidadPago { get; set; }
        public List<Percepcione> Percepciones { get; set; }
        public List<Deduccione> Deducciones { get; set; }
        public List<Otro> Otros { get; set; }
    }

    public class Otro
    {
        public string Clave { get; set; }
        public double Importe { get; set; }
        public int TipoClave { get; set; }
    }

    public class Percepcione
    {
        public string Clave { get; set; }
        public double Importe { get; set; }
        public int TipoClave { get; set; }
    }

    public class Root
    {
        public List<EncabezadoNomOrdBase> EncabezadoNomOrdBase { get; set; }
    }

    public class FotografiaBiometricoViewModel
    {
        public string fecha { get; set; }
        public string tipo { get; set; }
        public string hora { get; set; }

        public string rutaCompleta { get; set; }

        public string imagen { get; set; }

        public int idBiometrico { get; set; }

        public string ipBiometrico { get; set; }

        public int puerto { get; set; }

    }

}
