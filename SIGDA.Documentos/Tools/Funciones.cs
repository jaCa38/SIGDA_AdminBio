using SIGDA.Documentos.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Documentos.Tools
{
    public static class Funciones
    {
        public static EClasificadorMedia ObtenerTipo(int Tipo)
        {
            EClasificadorMedia Resultado = new EClasificadorMedia();
            switch (Tipo)
            {
                case 1:
                    Resultado = EClasificadorMedia.PDF;
                    break;
                case 2:
                    Resultado = EClasificadorMedia.DOCUMENTOS;
                    break;
                case 3:
                    Resultado = EClasificadorMedia.TIFF;
                    break;
                case 4:
                    Resultado = EClasificadorMedia.AUDIO;
                    break;
                case 5:
                    Resultado = EClasificadorMedia.VIDEO;
                    break;
                case 6:
                    Resultado = EClasificadorMedia.JPEG;
                    break;
                case 7:
                    Resultado = EClasificadorMedia.PNG;
                    break;
                case 8:
                    Resultado = EClasificadorMedia.CSV;
                    break;
            }
            return Resultado;
        }
        public static string ObtenerRutaModuloSIGDA(EModuloSIGDA eModuloSIGDA)
        {
            string rutaEspecifica = string.Empty;
            switch (eModuloSIGDA)
            {
                case EModuloSIGDA.None:
                    break;
                case EModuloSIGDA.FOTOCOPIADO:
                    rutaEspecifica = Paths.RepositorioFotocopiado;
                    break;
                case EModuloSIGDA.RH:
                    rutaEspecifica = Paths.RepositorioRH;
                    break;
                case EModuloSIGDA.CA:
                    rutaEspecifica = Paths.RepositorioCA;
                    break;
                default:
                    break;
            }
            return rutaEspecifica;
        }
        public static string ObtenerRutaEspecifica(string rutaModuloSIGDA)
        {
            string dia = DateTime.Now.Day.ToString();
            string mes = DateTime.Now.Month.ToString();
            string anio = DateTime.Now.Year.ToString();

            string rutaEspecifica = Path.Combine(rutaModuloSIGDA, anio, mes, dia);

            if (!Directory.Exists(Path.Combine(rutaModuloSIGDA, anio)))
                Directory.CreateDirectory(Path.Combine(rutaModuloSIGDA, anio));

            if (!Directory.Exists(Path.Combine(rutaModuloSIGDA, anio, mes)))
                Directory.CreateDirectory(Path.Combine(rutaModuloSIGDA, anio, mes));

            if (!Directory.Exists(Path.Combine(rutaModuloSIGDA, anio, mes, dia)))
                Directory.CreateDirectory(Path.Combine(rutaModuloSIGDA, anio, mes, dia));

            return rutaEspecifica;
        }
        public static ClasificadorServicios ObtenerServicio(long Tipo)
        {
            ClasificadorServicios Resultado = new ClasificadorServicios();
            switch (Tipo)
            {
                case 1:
                    Resultado = ClasificadorServicios.MediaPdf;
                    break;
                case 2:
                    Resultado = ClasificadorServicios.MediaDocs;
                    break;
                case 3:
                    Resultado = ClasificadorServicios.MediaTiff;
                    break;
                case 4:
                    Resultado = ClasificadorServicios.MediaAudio;
                    break;
                case 5:
                    Resultado = ClasificadorServicios.MediaVideo;
                    break;
                case 6:
                    Resultado = ClasificadorServicios.MediaJpeg;
                    break;
                case 7:
                    Resultado = ClasificadorServicios.MediaPng;
                    break;
                case 8:
                    Resultado = ClasificadorServicios.MediaCsv;
                    break;
            }
            return Resultado;
        }
    }
    public static class EncripcionSHA256
    {
        public static string SALTHash(string input)
        {
            //Creamos un codificador
            UnicodeEncoding uEncode = new UnicodeEncoding();
            //Obtenemos los bytes de la cadena
            byte[] Cadena = uEncode.GetBytes(input);
            // Creamos una nueva instancias
            System.Security.Cryptography.SHA256Managed sha = new System.Security.Cryptography.SHA256Managed();
            byte[] hash = sha.ComputeHash(Cadena);
            return Convert.ToBase64String(hash);
        }

        //Verificamos de Nuestros hash
        public static bool VerificarSALTHash(string input, string hash)
        {
            //Lo que vamos a SALTHash
            string hashOfInput = SALTHash(input);

            // Creamos un comparador decadenas
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public class EncripcionMD5
    {
        private static string clave = "$1Gd42024*";

        public string Md5Hash(string input)
        {
            // Creamos una nueva instancias
            MD5 md5Hasher = MD5.Create();

            // le sacamos los byte a la cadea
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            //Creamos un string builder para aterrizar la cadena
            StringBuilder sBuilder = new StringBuilder();

            // recorremos byte por byte hasta que se transforme toda en una cadena hex
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // la regresamos
            return sBuilder.ToString();
        }
        //Verificamos de Nuestros hash
        public bool VerificarMd5Hash(string input, string hash)
        {
            //Lo que vamos a comparar
            string hashOfInput = input;

            // Creamos un comparador decadenas
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //cifrar cadena de texto
        public string CifrarCadena(string cadena)
        {

            byte[] llave; //Arreglo donde guardaremos la llave para el cifrado 3DES.

            byte[] arreglo = UTF8Encoding.UTF8.GetBytes(cadena); //Arreglo donde guardaremos la cadena descifrada.

            // Ciframos utilizando el Algoritmo MD5.
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            llave = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(clave));
            md5.Clear();

            //Ciframos utilizando el Algoritmo 3DES.
            TripleDESCryptoServiceProvider tripledes = new TripleDESCryptoServiceProvider();
            tripledes.Key = llave;
            tripledes.Mode = CipherMode.ECB;
            tripledes.Padding = PaddingMode.PKCS7;
            ICryptoTransform convertir = tripledes.CreateEncryptor(); // Iniciamos la conversión de la cadena
            byte[] resultado = convertir.TransformFinalBlock(arreglo, 0, arreglo.Length); //Arreglo de bytes donde guardaremos la cadena cifrada.
            tripledes.Clear();

            return Convert.ToBase64String(resultado, 0, resultado.Length); // Convertimos la cadena y la regresamos.
        }

        // Función para descifrar una cadena.
        public string DescifrarCadena(string cadena)
        {

            byte[] llave;

            byte[] arreglo = Convert.FromBase64String(cadena); // Arreglo donde guardaremos la cadena descovertida.

            // Ciframos utilizando el Algoritmo MD5.
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            llave = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(clave));
            md5.Clear();

            //Ciframos utilizando el Algoritmo 3DES.
            TripleDESCryptoServiceProvider tripledes = new TripleDESCryptoServiceProvider();
            tripledes.Key = llave;
            tripledes.Mode = CipherMode.ECB;
            tripledes.Padding = PaddingMode.PKCS7;
            ICryptoTransform convertir = tripledes.CreateDecryptor();
            byte[] resultado = convertir.TransformFinalBlock(arreglo, 0, arreglo.Length);
            tripledes.Clear();

            string cadena_descifrada = UTF8Encoding.UTF8.GetString(resultado); // Obtenemos la cadena
            return cadena_descifrada; // Devolvemos la cadena
        }

        //Cifrar archivo
        public string GetMD5HashFromFile(Stream file, bool Cerrar)
        {
            file.Position = 0;
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(file);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            if (Cerrar)
            {
                file.Close();
            }
            return sb.ToString();
        }

    }
    public static class Checksums
    {
        public static bool Checksum(string CadenaBase, string Sum)
        {
            EncripcionMD5 md5 = new EncripcionMD5();
            return md5.VerificarMd5Hash(CrearSum(CadenaBase), Sum);
        }

        public static string CrearSum(string CadenaBase)
        {
            EncripcionMD5 md5 = new EncripcionMD5();
            return md5.Md5Hash(EncripcionSHA256.SALTHash(CadenaBase));
        }
    }

}
