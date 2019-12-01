using System;
using System.Collections.Generic;

namespace gotohnbackend.Models
{
    public partial class ItinerarioEncabezado
    {
        public ItinerarioEncabezado()
        {
            ItinerarioDetalle = new HashSet<ItinerarioDetalle>();
        }

        public int Itinierarioid { get; set; }
        public DateTime? Fechainicio { get; set; }
        public int? Fechafinal { get; set; }
        public string Nombre { get; set; }
        public int? Lugarid { get; set; }

        public virtual ICollection<ItinerarioDetalle> ItinerarioDetalle { get; set; }
    }
}
