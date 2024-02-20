using SIGDA.FOTOCOPIADO.Libreria.Copiadoras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Copiadoras.Services.Interfaces
{
    public interface ICopiadoraService : IDisposable
    {
        #region CRUD
        List<CopiadoraBase> Consultar();
        CopiadoraBase Consultar(long Id);
        List<CopiadoraDetalle> ConsultarDetalle();
        bool Insertar(CopiadoraBase copiadoraBase);
        bool Actualizar(CopiadoraBase copiadoraBase);
        bool ActualizarUbicacion(CopiadoraBase copiadoraBase);
        bool Desactivar(long Id);
        #endregion

        #region Contadores
        List<ContadorBase> ConsultarContadores();
        ContadorDetalle ConsultarContadores(long Id);
        bool InsertarContador(ContadorBase copiadoraBase, long IdMinerva);
        bool ActualizarContador(ContadorBase copiadoraBase, long IdMinerva);
        bool DesactivarContador(long Id, long IdMinerva);
        #endregion

        #region Costo por Copia
        List<CostoDetalle> ConsultarCostosCopia();
        List<CostoDetalle> ConsultarCostosCopiaZona(long IdZona);
        bool InsertarCostoCopia(CostoBase costoBase, long IdMinerva);
        bool ActualizarCostoCopia(CostoBase costoBase, long IdMinerva);
        bool DesactivarCostoCopia(long Id, long IdMinerva);
        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            try
            {
                //sqlCon.Dispose();
                //sqlCon = null;
                //_Parametros.Clear();
                //media.Close();
                //media = null;
            }
            catch { }
        }
        #endregion
    }
}
