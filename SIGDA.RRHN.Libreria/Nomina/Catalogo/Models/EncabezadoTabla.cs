using SIGDA.SRHN.Libreria.Nomina.Catalogo.Enums;
using SIGDA.SRHN.Libreria.Nomina.Catalogo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Nomina.Catalogo.Models
{
    public class EncabezadoTabla : IEncabezadoTablaBase
    {
        public EncabezadoTabla()
        {
            ListaDetalle = new List<DetalleTabla>();
        }
        public int IdTabla { set; get; }
        public string Descripcion { set; get; }
        public int Anio { set; get; }
        public ETipoTabla TipoTabla { set; get; }
        public List<DetalleTabla> ListaDetalle { set; get; } 
    }
}
