﻿using SIGDA.SRHN.Libreria.Asistencia.Enums;
using SIGDA.SRHN.Libreria.Asistencia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Asistencia.Services.Interfaces
{
    public interface ICatalogoService: IDisposable
    {
        List<CatalogoBase> ObtenerCatalogoAsistencia(ETipoCatalogo catalogo);
    }
}
