using Dapper;
using Microsoft.Data.SqlClient;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.Enums;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.Marcas.Interfaces;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.Modelos.Interfaces;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.TipoCopia.Services.Interfaces;
using SIGDA.FOTOCOPIADO.Libreria.Copiadoras.Enums;
using SIGDA.FOTOCOPIADO.Libreria.Copiadoras.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Copiadoras.Models
{
    public class CopiadoraBase : ICopiadoraBase, IMarcaBase, IModeloBase
    {
        public long IdCopiadora { get; set; }
        public string NombreCopiadora { get; set; }
        public long IdAnterior { get; set; }
        public string Serie { get; set; }
        public DateTime FechaAlta { get; set; }
        public ETiposPropiedad TipoPropiedad { get; set; }
        public EstatusCopiadora EstatusCopiadora { get; set; }
        public long IdMarca { get; set; }
        public string Marca { get; set; }
        public long IdModelo { get; set; }
        public string Modelo { get; set; }
        public long IdCentroFotocopiado { get; set; }
    }
}
