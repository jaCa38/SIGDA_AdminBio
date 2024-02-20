using Newtonsoft.Json;
using SIGDA.Autenticacion.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Autenticacion.Servicios
{
   public class TicketsUsuarioService : BaseService<TicketModel>
    {
        public TicketsUsuarioService(IConexionBD<MaterialesModel> conexion) : base(conexion)
        {
        }

        public List<TicketModel> ObtenerTickets(UsuarioModel usuario)
        {
            try
            {
                _parametros.Add(new Tuple<string, object, int>("@p_usuario_ID", usuario.Identificador, 12));
                return ReadAll("dbo.pa_Ticket_get");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                _parametros.Clear();
            }
        }

        public long SetSession(UsuarioModel usuario)
        {
            try
            {
                _parametros.Add(new Tuple<string, object, int>("@p_usuario_json", JsonConvert.SerializeObject(usuario), 12));

                return Create("dbo.pa_SessionCentros_Set");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                _parametros.Clear();
            }
        }



    }
}