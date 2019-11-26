using System;
using System.Collections.Generic;

namespace gotohnbackend.Models
{
    public partial class Preferencia
    {
        public Preferencia()
        {
            ItinerarioEncabezado = new HashSet<ItinerarioEncabezado>();
            Seleccion = new HashSet<Seleccion>();
        }

        public int Prefeenciaid { get; set; }
        public int Usuarioid { get; set; }
        public int Lugarid { get; set; }
        public int Categoriaid { get; set; }
        public int Jornadaid { get; set; }

        public virtual Categoria Categoria { get; set; }
        public virtual Jornada Jornada { get; set; }
        public virtual Lugar Lugar { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<ItinerarioEncabezado> ItinerarioEncabezado { get; set; }
        public virtual ICollection<Seleccion> Seleccion { get; set; }
    }
}
