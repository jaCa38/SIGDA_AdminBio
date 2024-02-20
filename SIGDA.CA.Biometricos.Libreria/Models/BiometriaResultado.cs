using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.CA.Biometricos.Libreria.Models
{
    public class BiometriaResultado
    {
        public string IdEmpleado {  get; set; }
        public string Name { get; set; }
        public string Authority { get; set; }
        public string Card_num { get; set; }
        public string Calid {  get; set; }
        
        public  string Check_type { get; set; }
        public string Opendoor_type {  get; set; }
        
        public string Password { get; set; }
        public string Face_data {  get; set; }  


        public bool ConexionStatus { get; set; }
        public string ResultadoError { get; set; } = string.Empty;

    }
}
