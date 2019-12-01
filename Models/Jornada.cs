using System;
using System.Collections.Generic;

namespace gotohnbackend.Models
{
    public partial class Jornada
    {
        public Jornada()
        {
            Actividades = new HashSet<Actividades>();
        }

        public int Jornadaid { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Actividades> Actividades { get; set; }
    }
}
