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
        public int Prefeenciaid { get; set; }

        public virtual Preferencia Prefeencia { get; set; }
        public virtual ICollection<ItinerarioDetalle> ItinerarioDetalle { get; set; }
    }
}
