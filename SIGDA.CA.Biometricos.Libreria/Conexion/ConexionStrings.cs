using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace SIGDA.CA.Biometricos.Libreria.Conexion
{
    internal class ConexionStrings
    {
        public static readonly string BDSICA_MYSQL = "server=192.168.1.12;Port=4499;uid=jcabrera ;pwd=SjVp2^dds%cThWUmfZ^@PC29uqcs$9;database=sicadb";
        //public static readonly string BDSICA_MYSQL = "server=192.168.1.12;Port=4499;uid=jcabrera ;pwd=SjVp2^dds%cThWUmfZ^@PC29uqcs$9;database=sicadb_desarrolo";

        public static string BDSIGDACA_MSSQL = "Data Source=192.168.1.63;Initial Catalog=SIGDA_CA;Persist Security Info=True;User Id=sa;Password=@S1st3m4$78;Encrypt=False;TrustServerCertificate=True";

        public static int TIMEOUT_CONEXION_TERMINAL = 30000;

        public static string IMAGES_STORAGE_FOLDER = "\\\\192.168.1.12\\fotosChecadoresSIGDA\\";

        public static string CONEXION_API_NOMBRAMIENTO = @"https://sistemas.poderjudicial-gto.gob.mx/api/progress/empleado/historia/periodos";
    }
}
