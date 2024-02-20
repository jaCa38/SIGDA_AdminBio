using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGDA.Reporteador.ItextSharp
{
    public class descripcionCelda
    {
        private string valorCelda = "";
        private int expandeColumnasCelda = 0;
        private int expandeRenglonesCelda = 0;

        public string ValorCelda
        {
            get
            {
                return valorCelda;
            }
            set
            {
                valorCelda = value;
            }
        }
        public int ExpandeColumnasCelda
        {
            get
            {
                return expandeColumnasCelda;
            }
            set
            {
                expandeColumnasCelda = value;
            }
        }
        public int ExpandeRenglonesCelda
        {
            get
            {
                return expandeRenglonesCelda;
            }
            set
            {
                expandeRenglonesCelda = value;
            }
        }

    }
}
