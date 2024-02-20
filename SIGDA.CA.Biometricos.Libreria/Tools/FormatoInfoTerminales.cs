using SIGDA.CA.Biometricos.Libreria.Models;
using System;
using System.Collections.Generic;

namespace SIGDA.CA.Biometricos.Libreria.Tools
{
    public static class FormatoInfoTerminales
    {
        public static List<RutasFotos> FormatoRutasFotos(string rutas)
        {
            List<RutasFotos> rutasFotos = new List<RutasFotos>();
            rutas = rutas.Replace("Return(result=\"success\"", "").Replace(")", "").Trim();
            string[] record = rutas.Split(new string[] { " " }, StringSplitOptions.None);
            for (int i = 0; i < record.Length; i++)
            {
                string trimRecord = record[i].Replace("\"", "").Replace(")", "");
                int RutaStart = trimRecord.ToString().LastIndexOf("name=") + "name=".Length;
                int RutaEnd = trimRecord.Length - RutaStart;
                string RutaFotografia = trimRecord.ToString().Substring(RutaStart, RutaEnd);
                string TimeRecord = trimRecord.ToString().Substring(trimRecord.Length - 10, 6);
                rutasFotos.Add(new RutasFotos { RutaFoto = RutaFotografia, Hora = TimeRecord });
            }

            return rutasFotos;
        }

        public static List<RegistrosRelojes> FormatoRegistroRelojesPorEmpleado(string rec, int IdEmpleado)
        {
            List<RegistrosRelojes> registros = new List<RegistrosRelojes>();
            string[] record = rec.Split(new string[] { "time=" }, StringSplitOptions.None);

            for (int i = 1; i < record.Length; i++)
            {
                string TimeRecord = record[i].Replace("\n", "").Replace("\r", "").Replace(")", "");
                DateTime fechaRecord = DateTime.Parse(TimeRecord.ToString().Substring(1, 19));
                int idEmpleadoStart = TimeRecord.ToString().LastIndexOf("id=\"") + "id=\"".Length;
                int idEmpleadoEnd = TimeRecord.ToString().IndexOf("\" name=") - idEmpleadoStart;
                int idEmpleadoRecord = Convert.ToInt32(TimeRecord.ToString().Substring(idEmpleadoStart, idEmpleadoEnd));
                if (idEmpleadoRecord == IdEmpleado)
                {
                    registros.Add(new RegistrosRelojes { IdEmpleado = idEmpleadoRecord, Record = fechaRecord, Hora = fechaRecord.ToString("HHmmss") });
                }

            }

            return registros;
        }

        public static List<RegistrosRelojes> FormatoRegistrosTerminal(string rec)
        {
            List<RegistrosRelojes> registros = new List<RegistrosRelojes>();
            string[] record = rec.Split(new string[] { "time=" }, StringSplitOptions.None);

            for (int i = 1; i < record.Length; i++)
            {
                string TimeRecord = record[i].Replace("\n", "").Replace("\r", "").Replace(")", "");
                //int fechaRegitroStart = record[i].ToString().LastIndexOf("time=\"") + "time=\"".Length;
                //int fechaRegitroEnd = record[i].ToString().IndexOf("\" id=") - fechaRegitroStart;
                DateTime fechaRecord = DateTime.Parse(TimeRecord.ToString().Substring(1, 19));
                int idEmpleadoStart = TimeRecord.ToString().LastIndexOf("id=\"") + "id=\"".Length;
                int idEmpleadoEnd = TimeRecord.ToString().IndexOf("\" name=") - idEmpleadoStart;
                int idEmpleadoRecord = Convert.ToInt32(TimeRecord.ToString().Substring(idEmpleadoStart, idEmpleadoEnd));
                registros.Add(new RegistrosRelojes { IdEmpleado = idEmpleadoRecord, Record = fechaRecord, Hora = fechaRecord.ToString("HHmmss"), ConexionReloj = true });

            }

            return registros;
        }


        public static string FormatoFoto(string FotoRec)
        {
            string record = FotoRec;
            record = record.Replace("\n", "").Replace("\r", "");
            char[] charsToTrim = { '"', ')' };
            record = record.TrimEnd(charsToTrim);
            record = record.Trim();
            record = record.TrimEnd(charsToTrim);
            int FotoStart = record.ToString().LastIndexOf("photo=\"") + "photo=\"".Length;
            string FotoOk = record.ToString().Substring(FotoStart, record.Length - FotoStart);

            return FotoOk;
        }






    }
}
