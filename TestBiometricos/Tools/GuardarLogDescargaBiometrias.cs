using SIGDA.CA.Biometricos.Libreria;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBiometricos.Tools
{
    public static class GuardarLogDescargaBiometrias
    {
        public static void InsertarlogDescargaBiometrias(string evento){

            try
            {
                using (StreamWriter writer = new StreamWriter($@"\\192.168.1.12\DescargaRegistrosBiometricos\LogDescargaBiometrias{DateTime.Now.Date}.txt", append: true))
                {
                    writer.WriteLine($"{evento}");
                    
                }


            }
            catch (Exception ex)
            {
                
            }

        }
    }
}
