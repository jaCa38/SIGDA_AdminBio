using System;
using System.Net;

namespace SIGDA.CA.Biometricos.Libreria.Tools
{
    public static class HerramientasIp
    {


        public static string ComprobarDireccionDeRed(string direccion)
        {
            string direccionIp = direccion;

            if (Uri.CheckHostName(direccion).ToString() == "Dns")
            {
                direccionIp = Convert.ToString(Dns.GetHostEntry(direccion).AddressList[0]);

            }
            else if (Uri.CheckHostName(direccion).ToString() == "IPv4")
            {
                direccionIp = direccion;
            }

            return direccionIp;
        }
    }
}
