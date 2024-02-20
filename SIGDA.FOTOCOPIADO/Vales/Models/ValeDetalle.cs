using SIGDA.FOTOCOPIADO.Libreria.Catalogos.CentrosTrabajo.Interfaces;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.Enums;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.TipoCopia.Interfaces;
using SIGDA.FOTOCOPIADO.Libreria.Copiadoras.Enums;
using SIGDA.FOTOCOPIADO.Libreria.Copiadoras.Interfaces;
using SIGDA.FOTOCOPIADO.Libreria.Vales.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Vales.Models
{
    public class ValeDetalle : IValeBase, ICopiadoraBase, ITipoCopiaBase, ICentroTrabajoSAPBase, IEstatusVale
    {
        public long IdVale { get; set; }
        public string SerieVale { get; set; }
        public string FolioVale { get; set; }
        public DateTime FechaAsignadoVale { get; set; }
        public DateTime FechaRegistradoVale { get; set; }
        public DateTime FechaCapturadoVale { get; set; }
        public string CantidadCopias { get; set; }
        public ETiposHoja TipoHoja { get; set; }
        public string Observaciones { get; set; }
        public long IdCopiadora { get; set; }
        public string NombreCopiadora { get; set; }
        public long IdAnterior { get; set; }
        public string Serie { get; set; }
        public DateTime FechaAlta { get; set; }
        public ETiposPropiedad TipoPropiedad { get; set; }
        public EstatusCopiadora EstatusCopiadora { get; set; }
        public long IdentificadorTipoCopia { get; set; }
        public string DescripcionTipoCopia { get; set; }
        public string ClaveTipoCopia { get; set; }
        public long IdMunicipio { get; set; }
        public string Municipio { get; set; }
        public long IdentificadorCCS { get; set; }
        public string ClaveCSS { get; set; }
        public string DenominacionCSS { get; set; }
        public string DescripcionCSS { get; set; }
        public string CentroTrabajoCSS { get; set; }
        public long IdZona { get; set; }
        public string Zona { get; set; }
        public long IdEstatusVale { get; set; }
        public string EstatusVale { get; set; }
    }
}