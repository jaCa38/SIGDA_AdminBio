using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Reporteador.Tools
{
    public static class ConnectionStrings
    {
        public static string BDFOTOCOPIADO = ConfigurationManager.ConnectionStrings["SIGDA_FOTO_QA_CNN"].ToString();

        public static string BDREPORTES = ConfigurationManager.ConnectionStrings["SIGDA_REPORTES"].ToString();

        public static string BDDOCUMENTOS = ConfigurationManager.ConnectionStrings["SIGDA_DOCUMENTOS"].ToString();

        public static string PathReportesTemp = ConfigurationManager.ConnectionStrings["Reporteador"].ToString();

        public static string Leyenda = ConfigurationManager.ConnectionStrings["Leyenda"].ToString();
    }
}
