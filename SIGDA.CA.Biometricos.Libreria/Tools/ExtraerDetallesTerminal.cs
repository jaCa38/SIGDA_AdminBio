using SIGDA.CA.Biometricos.Libreria.Models;
using System;
using System.Text.RegularExpressions;

namespace SIGDA.CA.Biometricos.Libreria.Tools
{
    public static class ExtraerDetallesTerminal
    {
        public static ConfiguracionBiometrico ExtraerConfigBiometrico(string bioConf)
        {
            ConfiguracionBiometrico confBiometrico = new ConfiguracionBiometrico();
            bioConf = bioConf.Replace("Return(result=\"success\"", "").Replace(")", "").Trim();

            try
            {
                ;
                //string[] record = biometriaBio.Split(new string[] { " " }, StringSplitOptions.None);
                string[] record = bioConf.Split(new string[] { "\" " }, StringSplitOptions.RemoveEmptyEntries);



                for (int i = 0; i < record.Length; i++)
                {


                    if (Regex.IsMatch(record[i], "dev_id="))
                    {
                        char[] charsToTrim = { '"' };
                        string recordTrim = record[i].Trim().TrimEnd(charsToTrim);
                        int snStart = recordTrim.ToString().LastIndexOf("dev_id=\"") + "dev_id=\"".Length;
                        string snBiometrico = record[i].ToString().Substring(snStart, (recordTrim.ToString().Length) - snStart);
                        confBiometrico.Sn = snBiometrico;
                    }


                    if (Regex.IsMatch(record[i], "time="))
                    {
                        char[] charsToTrim = { '"' };
                        string recordTrim = record[i].Trim().TrimEnd(charsToTrim);
                        int timeStart = recordTrim.ToString().LastIndexOf("time=\"") + "time=\"".Length;
                        string timeBio = record[i].ToString().Substring(timeStart, (recordTrim.ToString().Length) - timeStart);
                        confBiometrico.FechaHora = Convert.ToDateTime(timeBio);

                    }


                    if (Regex.IsMatch(record[i], "edition="))
                    {
                        if (!Regex.IsMatch(record[i], "alg_edition="))
                        {
                            char[] charsToTrim = { '"' };
                            string recordTrim = record[i].Trim().TrimEnd(charsToTrim);
                            int fwStart = recordTrim.ToString().LastIndexOf("edition=\"") + "edition=\"".Length;
                            string fwBio = record[i].ToString().Substring(fwStart, (recordTrim.ToString().Length) - fwStart);
                            confBiometrico.Fw = fwBio;
                        }

                    }

                    if (Regex.IsMatch(record[i], "type="))
                    {
                        char[] charsToTrim = { '"' };
                        string recordTrim = record[i].Trim().TrimEnd(charsToTrim);
                        int modeloStart = recordTrim.ToString().LastIndexOf("type=\"") + "type=\"".Length;
                        string modeloBio = record[i].ToString().Substring(modeloStart, (recordTrim.ToString().Length) - modeloStart);
                        confBiometrico.Modelo = modeloBio;

                    }

                    if (Regex.IsMatch(record[i], "alg_edition="))
                    {

                        char[] charsToTrim = { '"' };
                        string recordTrim = record[i].Trim().TrimEnd(charsToTrim);
                        int fwStart = recordTrim.ToString().LastIndexOf("alg_edition=\"") + "alg_edition=\"".Length;
                        string fwBio = record[i].ToString().Substring(fwStart, (recordTrim.ToString().Length) - fwStart);
                        confBiometrico.Algoritmo = fwBio;


                    }


                }
            }
            catch (Exception ex)
            {

            }
            return confBiometrico;
        }
    }
}
