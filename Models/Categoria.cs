using System;
using System.Collections.Generic;

namespace gotohnbackend.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Actividades = new HashSet<Actividades>();
        }

        public int Categoriaid { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Actividades> Actividades { get; set; }
    }
}
