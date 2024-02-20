using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Conexion
{
    public static class CadenasConexion
    {
#if false
        public static string BDRHN_LOCAL = Environment.GetEnvironmentVariable("SIGDA_RH_QA_CNN");
#endif
        public static string BDRH_LOCAL = Environment.GetEnvironmentVariable("SIGDA_RH1_QA_CNN");
#if true
        public static string BDRHN_LOCAL = Environment.GetEnvironmentVariable("SIGDA_RH_PROD_CNN");
#endif
        //public static string BDCV_LOCAL = Environment.GetEnvironmentVariable("SIGDA_CV_PROD_CNN");
        public static string BDCV_LOCAL = "Data Source=192.168.1.63;Initial Catalog=rechum;Persist Security Info=True;User Id=sa;Password=@S1st3m4$78;Encrypt=False;TrustServerCertificate=True";

        public static string BDSIGEIN_LOCAL = Environment.GetEnvironmentVariable("SIGEIN_PROD_CNN");

#if true
        public static string BDFOTOCOPIADO_LOCAL = Environment.GetEnvironmentVariable("SIGDA_FOTO_QA_CNN");
#endif

#if false
        public static string BDFOTOCOPIADO_LOCAL = Environment.GetEnvironmentVariable("SIGDA_FOTO_PROD_CNN");
#endif

#if false
        public static string BDSIGDA_CA_MSSQL = Environment.GetEnvironmentVariable("SIGDA_CA_QA_CNN");
#endif
#if true
        public static string BDSIGDA_CA_MSSQL = Environment.GetEnvironmentVariable("SIGDA_CA_PROD_CNN");
#endif

        public static string BDSICA_MYSQL= Environment.GetEnvironmentVariable("SICA_PROD_CNN");
#if true
        public static string BDCONSEJO_MSSQL = Environment.GetEnvironmentVariable("CONSEJO_QA");
#endif
#if false
        public static string BDCONSEJO_MSSQL = Environment.GetEnvironmentVariable("CONSEJO_PROD");
#endif
    }
}
