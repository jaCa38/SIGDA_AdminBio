using Dapper;

using SIGDA.SRHN.Libreria.Catalogos.Generos.Models;
using SIGDA.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using SIGDA.Catalogos.Genericos.Genericos.Services.Interfaces;
using SIGDA.Catalogos.Genericos.Models;

namespace SIGDA.SRHN.Libreria.Catalogos.Generos.Controllers
{
    public class GeneroController : IModelGenericoService, IDisposable
    {
        #region Constructor Variables
        DataTableReader? dtrResultado = null;
        private string? strCadena;
        #endregion
        public GeneroController(string cadena)
        {
            strCadena = cadena;
        }

        public bool ActualizarCatalogoGenerico(long Identificador, string Descripcion)
        {
            throw new NotImplementedException();
        }

        public List<BaseModel> ConsultarCatalogoGenerico()
        {
            GeneroBase Base = new GeneroBase(strCadena);
            return (List<BaseModel>)Base.ConsultarCatalogoGenerico();
        }
        public BaseModel ConsultarCatalogoGenericoFiltroId(long Id)
        {
            throw new NotImplementedException();
        }
        public bool InsertarCatalogoGenerico(string Descripcion)
        {
            throw new NotImplementedException();
        }
        public List<BaseModel> ConsultarCatalogoGenerico(long Identificador)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
