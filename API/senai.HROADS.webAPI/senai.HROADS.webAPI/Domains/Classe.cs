using System;
using System.Collections.Generic;

#nullable disable

namespace senai.HROADS.webAPI.Domains
{
    public partial class Classe
    {
        public Classe()
        {
            ConClasseHabs = new HashSet<ConClasseHab>();
            Personagems = new HashSet<Personagem>();
        }

        public byte IdClasse { get; set; }
        public string NomeClasse { get; set; }

        public virtual ICollection<ConClasseHab> ConClasseHabs { get; set; }
        public virtual ICollection<Personagem> Personagems { get; set; }
    }
}
