using System;
using System.Collections.Generic;

namespace gotohnbackend.Models
{
    public partial class Lugar
    {
        public Lugar()
        {
            Actividades = new HashSet<Actividades>();
        }

        public int Lugarid { get; set; }
        public string Nombre { get; set; }
        public string Lugar1 { get; set; }
        public string Foto { get; set; }
        public DateTime? Horaentrada { get; set; }
        public DateTime? Horacierre { get; set; }

        public virtual ICollection<Actividades> Actividades { get; set; }
    }
}
