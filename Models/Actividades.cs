using System;
using System.Collections.Generic;

namespace gotohnbackend.Models
{
    public partial class Actividades
    {
        public Actividades()
        {
            ItinerarioDetalle = new HashSet<ItinerarioDetalle>();
        }

        public int Actividadid { get; set; }
        public string Nombre { get; set; }
        public string Description { get; set; }
        public string Horario { get; set; }
        public int Lugarid { get; set; }
        public int Categoriaid { get; set; }
        public int Jornadaid { get; set; }

        public virtual Categoria Categoria { get; set; }
        public virtual Jornada Jornada { get; set; }
        public virtual Lugar Lugar { get; set; }
        public virtual ICollection<ItinerarioDetalle> ItinerarioDetalle { get; set; }
    }
}
