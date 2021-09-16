using System;
using System.Collections.Generic;

#nullable disable

namespace senai.HROADS.webAPI.Domains
{
    public partial class TipoHabilidade
    {
        public TipoHabilidade()
        {
            Habilidades = new HashSet<Habilidade>();
        }

        public byte IdTipoHab { get; set; }
        public string NomeTipoHab { get; set; }

        public virtual ICollection<Habilidade> Habilidades { get; set; }
    }
}
