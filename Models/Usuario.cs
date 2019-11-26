using System;
using System.Collections.Generic;

namespace gotohnbackend.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Preferencia = new HashSet<Preferencia>();
        }

        public int Usuarioid { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public int Tipo { get; set; }

        public virtual ICollection<Preferencia> Preferencia { get; set; }
    }
}
