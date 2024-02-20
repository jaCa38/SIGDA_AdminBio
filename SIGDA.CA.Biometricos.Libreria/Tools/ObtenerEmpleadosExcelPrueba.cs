using SIGDA.CA.Biometricos.Libreria.Models;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace SIGDA.CA.Biometricos.Libreria.Tools
{
    public static class ObtenerEmpleadosExcelPrueba
    {

        public static List<EmpleadoRH> ObtenerEmpleadosPlantillaRH()
        {

            List<EmpleadoRH> empleadoRH = new List<EmpleadoRH>();

            Excel.Application excelApp = new Excel.Application();
            //Excel.Workbook excelWB = excelApp.Workbooks.Open(@"\\192.168.1.12\DescargaBiometriasPorTerminal\RHPLANTILLA.xlsx");
            Excel.Workbook excelWB = excelApp.Workbooks.Open(@"C:\PlantillaSilao.xlsx");
            Excel._Worksheet excelWS = excelWB.Sheets[1];
            Excel.Range excelRange = excelWS.UsedRange;

            int rowCount = excelRange.Rows.Count;
            int columnCount = excelRange.Columns.Count;


            for (int i = 2; i <= rowCount; i++)
            {
                string fechafinRH;

                if (excelRange.Cells[i, 1] != null)
                {
                    fechafinRH = excelRange.Cells[i, 21].Value2;
                    if (fechafinRH == null)
                    {
                        fechafinRH = DateTime.Now.Date.ToString();
                    }
                    else
                    {
                        fechafinRH = excelRange.Cells[i, 21].Value2.ToString();

                    }


                    empleadoRH.Add(new EmpleadoRH
                    {
                        IdEmpleadoRh = Convert.ToInt32(excelRange.Cells[i, 12].Value2.ToString()),
                        Municipio = excelRange.Cells[i, 8].Value2.ToString(),
                        CT = excelRange.Cells[i, 6].Value2.ToString(),
                        Puesto = excelRange.Cells[i, 10].Value2.ToString(),
                        InicioNombramiento = Convert.ToDateTime(excelRange.Cells[i, 20].Value2.ToString()),
                        FinNombramiento = Convert.ToDateTime(fechafinRH)
                    }); ;
                    //Console.WriteLine(excelRange.Cells[i,1].Value2.ToString()+"\n");
                }

            }

            Marshal.ReleaseComObject(excelWS);
            Marshal.ReleaseComObject(excelRange);
            excelWB.Close();
            Marshal.ReleaseComObject(excelWB);
            excelApp.Quit();
            Marshal.ReleaseComObject(excelApp);




            return empleadoRH;
        }
    }
}
