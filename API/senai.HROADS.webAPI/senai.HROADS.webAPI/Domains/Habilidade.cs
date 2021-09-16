using System;
using System.Collections.Generic;

#nullable disable

namespace senai.HROADS.webAPI.Domains
{
    public partial class Habilidade
    {
        public Habilidade()
        {
            ConClasseHabs = new HashSet<ConClasseHab>();
        }

        public byte IdHabilidade { get; set; }
        public byte? IdTipoHabilidade { get; set; }
        public string NomeHabilidade { get; set; }

        public virtual TipoHabilidade IdTipoHabilidadeNavigation { get; set; }
        public virtual ICollection<ConClasseHab> ConClasseHabs { get; set; }
    }
}
