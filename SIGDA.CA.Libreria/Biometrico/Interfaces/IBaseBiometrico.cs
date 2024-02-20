using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.CA.Libreria.Biometrico.Interfaces
{
    public interface IBaseBiometrico
    {
        public long IdBiometrico { get; set; }
        public string? DescripcionBiometrico { get; set; }

    }
}
