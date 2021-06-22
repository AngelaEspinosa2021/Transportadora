using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransportadoraService.Models
{
    public class ActividadDTO
    {
        public long Id { get; set; }
        public string CreadaPor { get; set; }
        public string AsignadaA { get; set; }
        public string RelacionadaCon { get; set; }
        public string Asunto { get; set; }
        public System.DateTime FechaVencimiento { get; set; }
        public string Observacion { get; set; }
        public string Estado { get; set; }
        public string Prioridad { get; set; }
    }
}