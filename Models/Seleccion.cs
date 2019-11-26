using System;
using System.Collections.Generic;

namespace gotohnbackend.Models
{
    public partial class Seleccion
    {
        public int Seleccionid { get; set; }
        public int Actividadid { get; set; }
        public int Prefeenciaid { get; set; }
        public int Prioridad { get; set; }

        public virtual Preferencia Prefeencia { get; set; }
    }
}
