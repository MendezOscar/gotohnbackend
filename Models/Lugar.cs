using System;
using System.Collections.Generic;

namespace gotohnbackend.Models
{
    public partial class Lugar
    {
        public Lugar()
        {
            Actividades = new HashSet<Actividades>();
            Preferencia = new HashSet<Preferencia>();
        }

        public int Lugarid { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Actividades> Actividades { get; set; }
        public virtual ICollection<Preferencia> Preferencia { get; set; }
    }
}
