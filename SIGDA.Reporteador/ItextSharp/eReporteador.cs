using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGDA.Reporteador.ItextSharp
{
    public enum eTipoHoja:int
    {
        Carta = 1,
        Oficio = 2,
        A4 = 9,
        Legal = 5
    }
    public enum eOrientacion:int
    {
        Horizontal = 1,
        Vertical = 2
    }
    public enum eTipoDato:int 
    {
        Int = 1,
        Double = 2,
        String = 3,
        Date = 4,
        Time = 5,
        Float = 6,
        SmallInt = 7,
        Bool = 8
    }
    public enum eTipoTabla : int
    {
        Datos = 1,
        Texto = 2
    }
    public enum eTipoFuente:int
    {
        Arial = 1,
        Tahoma = 2,
        TimesNewRoman = 3,
        BookAntiqua = 4,
        Verdana = 5
    }
    public enum eTipoReporte : int
    {
        Oficio = 1,
        AcuseRecibo = 2,
        Caratula = 3,
        ListaDeAcuerdos = 4,
        ListaDePromociones = 5,
        ReporteGenerico = 6
    }
    public enum eSizeFuente:int
    {
        Tiny = 7,
        VerySmall = 8,
        Small = 9,
        Medium = 10,
        Standar = 12,
        Large = 14
    }
    public enum eAlineacionTexto:int
    {
        Izquierda = 1,
        Derecha = 2,
        Centrador = 3
    }
}
