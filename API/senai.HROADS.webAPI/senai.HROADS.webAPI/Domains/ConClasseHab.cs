using System;
using System.Collections.Generic;

#nullable disable

namespace senai.HROADS.webAPI.Domains
{
    public partial class ConClasseHab
    {
        public short IdConClasseHab { get; set; }
        public byte? IdClasse { get; set; }
        public byte? IdHabilidade { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
        public virtual Habilidade IdHabilidadeNavigation { get; set; }
    }
}
