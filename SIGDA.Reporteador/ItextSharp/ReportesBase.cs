using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGDA.Reporteador.ItextSharp
{
    public class ReportesBase
    {
        string _juzgado = string.Empty;
        string _articuloLey = string.Empty;
        string _idUsuario = string.Empty;
        string _iniciUsuario = string.Empty;

        public string Juzgado
        {
            set
            {
                _juzgado = value;
            }
            get
            {
                return _juzgado;
            }
        }
        public string IdUsuario { set { _idUsuario = value; } get { return _idUsuario; } }
        public string InicUsuario { set { _iniciUsuario = value; } get { return _iniciUsuario; } }
        public string ArticuloLey { set { _articuloLey = value; } get { return _articuloLey; } }
    }
}
