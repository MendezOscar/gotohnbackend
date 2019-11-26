using System;
using System.Collections.Generic;

namespace gotohnbackend.Models
{
    public partial class ItinerarioDetalle
    {
        public int ItinerarioDetalleid { get; set; }
        public int Itinierarioid { get; set; }
        public int Actividadid { get; set; }

        public virtual Actividades Actividad { get; set; }
        public virtual ItinerarioEncabezado Itinierario { get; set; }
    }
}
