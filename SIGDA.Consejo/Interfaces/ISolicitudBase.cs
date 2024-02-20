using SIGDA.Consejo.Libreria.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Consejo.Libreria.Interfaces
{
    public interface ISolicitudBase
    {
        public long prom_Identificador { get; set; }
        public string prom_medio_presentacion_descripcion { get; set; }
        public ETipoEntrada prom_entrada { get; set; }
        public string prom_cata_municipio_descripcion { get; set; }
        public string prom_cata_centro_descripcion { get; set; }
        public string prom_cata_cargo_descripcion { get; set; }
        public string prom_presenta { get; set; }
        public string prom_oficio { get; set; }
        public string prom_anexos { get; set; }
        public string prom_resumen { get; set; }
        public DateTime prom_fecha { get; set; }
        public DateTime prom_hora { get; set; }
        public string prom_cata_descripcion { get; set; }
        public string prom_cata_observaciones { get; set; }
        public string prom_cata_calificacion_observaciones { get; set; }
        public ETiposSolicitud prom_tipo_solicitud { get; set; }
        public EVoboSC prom_vobo_sc { get; set; }
        public EPrecalificacionRH prom_precalificacion_rh { get; set; }
        public EVoboRH prom_vobo_rh { get; set; }
        public EPrecalificacionSC prom_precalificacion_sc { get; set; }
        public int prom_vuelta { get; set; }
        public string prom_texto_od { get; set; }
        public long prom_od_identificador { get; set; }
        public string prom_od_fecha { get; set; }
        public DateTime prom_fecha_captura { get; set; }
        public EEstadoSolicitud prom_estado { get; set; }
    }
}
