using SIGDA.CA.Libreria.Biometrico.Interfaces;
using SIGDA.CA.Libreria.Punch.Interfaces;
using SIGDA.CA.Libreria.TarjetaChecadora.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.CA.Libreria.Punch.Models
{
    public class BasePunch : IBasePunch, IBaseBiometrico, IBaseTarjetaChecadora
    {
        public long IdRegistroSICA { get; set; }
        public int IdEstatus { get; set; }
        public long IdBiometrico { get; set; }
        public string? DescripcionBiometrico { get; set; }
        public long IdClaveEmpleado { get; set; }
        public DateTime FechaChecada { get; set; }
        public TimeSpan HoraChecada { get; set; }
    }
}
