using System;
using System.Collections.Generic;
using System.Linq;

namespace SIGDA.CA.Biometricos.Libreria.Tools
{
    public static class ExtraerListaEmpleadosTerminalBiometrica
    {
        public static List<int> ObtenerListaEmpleadosTerminalBiometrica(string lista)
        {
            List<int> listaEmpleado = new List<int>();

            try
            {
                lista = lista.Replace("Return(result=\"success\"", "");
                lista = lista.Replace(")", "");
                lista = lista.Replace("\"", "").Replace(" ", "");
                string[] listaIdEmp = lista.Split(new string[] { "id=" }, StringSplitOptions.None);
                var listaIds = listaIdEmp.ToList();
                listaIds.RemoveAt(0);
                listaEmpleado = listaIds.Select(int.Parse).ToList();


            }
            catch (Exception ex)
            {
                listaEmpleado = null;

            }
            return listaEmpleado;

        }

    }
}
