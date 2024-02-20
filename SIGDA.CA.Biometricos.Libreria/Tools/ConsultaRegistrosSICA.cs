using Dapper;
using MySql.Data.MySqlClient;
using SIGDA.CA.Biometricos.Libreria.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SIGDA.CA.Biometricos.Libreria.Tools
{
    public class ConsultaRegistrosSICA
    {
        private string strConexionMYSQL;
        private string strConexionMSSQL;
        DataTableReader dtrResultado = null;

        public ConsultaRegistrosSICA(string cadenaMysql, string cadenaMSSQL)
        {

            strConexionMYSQL = cadenaMysql;
            strConexionMSSQL = cadenaMSSQL;
        }

        public List<RegistrosEmpleadoSICA> GenerarReporteSICA(int IdEmpleado, DateTime fechaNomInicio, DateTime fechaFinNom)
        {

            var registrosEmpleados = new List<RegistrosEmpleadoSICA>();
            try
            {
                var sql = @"sp_empleado_registros_procesados";
                var dpParametros = new DynamicParameters();
                dpParametros.Add("@idEmpleado", IdEmpleado);
                dpParametros.Add("@fechaInicio", fechaNomInicio);
                dpParametros.Add("@fechaFin", fechaFinNom);


                try
                {
                    using (var connection = new MySqlConnection(strConexionMYSQL))
                    {
                        var recRevoc = connection.Query<RegistrosEmpleadoSICA>(sql, dpParametros,
                            commandType: CommandType.StoredProcedure, commandTimeout: 28800).ToList();

                        registrosEmpleados = recRevoc;

                        return registrosEmpleados;

                    }
                }
                catch (MySqlException MySqlEx)
                {
                    string MensajeError = "ERROR : " + MySqlEx.Message + ".";
                    throw new Exception(MensajeError, MySqlEx);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }


    }
}
