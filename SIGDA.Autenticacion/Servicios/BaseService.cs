using Newtonsoft.Json;
using PlataformaCore.ConexionBD.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Autenticacion.Servicios
{
    public delegate void CallBack();
    public class BaseService<T>
    {
        public virtual event CallBack Call_Back;
        public bool disposedValue;
        public IConexionBD<MaterialesModel> _conexion;

        public List<Tuple<string, object, int>> _parametros;

        public BaseService(IConexionBD<MaterialesModel> conexion)
        {
            _conexion = conexion;
            _parametros = new List<Tuple<string, object, int>>();
        }
        public long Create(string procedimiento)
        {
            try
            {
                long respuesta = 0;

                _conexion.PrepararProcedimiento(procedimiento, _parametros);

                DataTableReader DTRResultados = _conexion.EjecutarTableReader();
                while (DTRResultados.Read())
                {
                    if (!string.IsNullOrEmpty(DTRResultados[0].ToString()))
                    {
                        respuesta = long.Parse(DTRResultados[0].ToString());
                    }
                }

                return respuesta;
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

        public bool Delete(T model, string parametro, string procedimiento)
        {
            throw new NotImplementedException();
        }

        public T Read(string procedimiento)
        {
            try
            {
                T respuesta = default;

                _conexion.PrepararProcedimiento(procedimiento, _parametros);

                DataTableReader DTRResultados = _conexion.EjecutarTableReader();
                while (DTRResultados.Read())
                {
                    if (!string.IsNullOrEmpty(DTRResultados[0].ToString()))
                    {
                        // respuesta = JsonConvert.DeserializeObject<T>(DTRResultados[0].ToString());

                        string resp = DTRResultados[0].ToString().Replace("\"[", "[").Replace("]\"", "]").Replace("/O PAGO", "O PAGO").Replace("\\", "");

                        respuesta = JsonConvert.DeserializeObject<T>(resp);

                    }
                }

                return respuesta;
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

        public List<T> ReadAll(string procedimiento)
        {
            try
            {
                List<T> respuesta = null;

                _conexion.PrepararProcedimiento(procedimiento, _parametros);

                DataTableReader DTRResultados = _conexion.EjecutarTableReader();
                while (DTRResultados.Read())
                {
                    if (!string.IsNullOrEmpty(DTRResultados[0].ToString()))
                    {
                        string resp = DTRResultados[0].ToString();

                        respuesta = JsonConvert.DeserializeObject<List<T>>(resp);
                    }
                }

                return respuesta;
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

        public bool Update(string procedimiento)
        {
            try
            {
                bool respuesta = false;
                _conexion.PrepararProcedimiento(procedimiento, _parametros);

                DataTableReader DTRResultados = _conexion.EjecutarTableReader();
                while (DTRResultados.Read())
                {
                    if (!string.IsNullOrEmpty(DTRResultados[0].ToString()))
                    {
                        respuesta = long.Parse(DTRResultados[0].ToString()) > 0;
                    }
                }

                return respuesta;
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

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _conexion.Dispose();
                    _parametros.Clear();
                    // TODO: eliminar el estado administrado (objetos administrados)
                }

                // TODO: liberar los recursos no administrados (objetos no administrados) y reemplazar el finalizador
                // TODO: establecer los campos grandes como NULL
                disposedValue = true;
            }
        }

        // // TODO: reemplazar el finalizador solo si "Dispose(bool disposing)" tiene código para liberar los recursos no administrados
        // ~BaseService()
        // {
        //     // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}