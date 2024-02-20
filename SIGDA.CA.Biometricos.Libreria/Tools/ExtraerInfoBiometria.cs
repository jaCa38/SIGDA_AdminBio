using System;

namespace SIGDA.CA.Biometricos.Libreria.Tools
{
    public static class ExtraerInfoBiometria
    {

        public static string ObtenerdatosBiometria(string biometria, long numSerie)
        {

            try
            {
                biometria = biometria.Replace("Return(result=\"success\"", "").Trim();
                biometria = biometria.Replace("sn=\"" + numSerie + "\"", "");
                biometria = biometria.Replace(")", "");

            }
            catch (Exception ex)
            {
                biometria = "";

            }
            return biometria;

        }

    }
}
