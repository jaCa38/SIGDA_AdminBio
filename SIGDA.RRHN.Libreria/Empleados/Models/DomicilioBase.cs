﻿using SIGDA.SRHN.Libreria.Empleados.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Empleados.Models
{
    public class DomicilioBase : IDomicilioBase
    {
        public string Calle { set; get; }
        public int CP { set; get; }
        public string NumExt { set; get; }
        public string NumInt { set; get; }
        public int IdMunicipio { set; get; }
        public int IdEstado { set; get; }
        public string Municipio { set; get; }
        public string Estado { set; get; }
        public int IdEmpleado { set; get; }
        public int IdCandidato { set; get; }
        public int IdDomicilio { set; get; }
        public int IdColonia { set; get; }
        public string Colonia { set; get; }
        public int IdPais { set; get; }
        public string Pais { set; get; }

    }
}
