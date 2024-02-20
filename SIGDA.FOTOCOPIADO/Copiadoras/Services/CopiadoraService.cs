using SIGDA.FOTOCOPIADO.Libreria.Copiadoras.Models;
using SIGDA.FOTOCOPIADO.Libreria.Copiadoras.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Copiadoras.Services
{
    public class CopiadoraService : ICopiadoraService
    {
        private readonly ICopiadoraService _metodos;

        #region CRUD
        public CopiadoraService(ICopiadoraService metodos)
        {
            _metodos = metodos;
        }
        public bool Actualizar(CopiadoraBase copiadoraBase)
        {
            return _metodos.Actualizar(copiadoraBase);
        }

        public bool ActualizarUbicacion(CopiadoraBase copiadoraBase)
        {
            return _metodos.ActualizarUbicacion(copiadoraBase);
        }

        public List<CopiadoraBase> Consultar()
        {
            return _metodos.Consultar();
        }

        public CopiadoraBase Consultar(long Id)
        {
            return _metodos.Consultar(Id);
        }

        public List<CopiadoraDetalle> ConsultarDetalle()
        {
            return _metodos.ConsultarDetalle();
        }

        public bool Desactivar(long Id)
        {
            return _metodos.Desactivar(Id);
        }

        public bool Insertar(CopiadoraBase copiadoraBase)
        {
            return _metodos.Insertar(copiadoraBase);
        }
        #endregion
        public void Dispose()
        {
            try { } catch { }
        }

        #region Contadores
        public List<ContadorBase> ConsultarContadores()
        {
            return _metodos.ConsultarContadores();
        }

        public ContadorDetalle ConsultarContadores(long Id)
        {
            return _metodos.ConsultarContadores(Id);
        }

        public bool InsertarContador(ContadorBase copiadoraBase, long IdMinerva)
        {
            return _metodos.InsertarContador(copiadoraBase, IdMinerva);
        }

        public bool ActualizarContador(ContadorBase copiadoraBase, long IdMinerva)
        {
            return _metodos.ActualizarContador(copiadoraBase, IdMinerva);
        }

        public bool DesactivarContador(long Id, long IdMinerva)
        {
            return _metodos.DesactivarContador(Id, IdMinerva);
        }
        #endregion

        #region Costo por Copia

        public List<CostoDetalle> ConsultarCostosCopia()
        {
            return _metodos.ConsultarCostosCopia();
        }

        public List<CostoDetalle> ConsultarCostosCopiaZona(long IdZona)
        {
            return _metodos.ConsultarCostosCopiaZona(IdZona);
        }

        public bool InsertarCostoCopia(CostoBase costoBase, long IdMinerva)
        {
            return _metodos.InsertarCostoCopia(costoBase, IdMinerva);
        }

        public bool ActualizarCostoCopia(CostoBase costoBase, long IdMinerva)
        {
            return _metodos.ActualizarCostoCopia(costoBase, IdMinerva);
        }

        public bool DesactivarCostoCopia(long Id, long IdMinerva)
        {
            return _metodos.DesactivarCostoCopia(Id, IdMinerva);
        }

        #endregion
    }
}
