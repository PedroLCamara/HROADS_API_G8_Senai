using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.HROADS.webAPI.Domains
{
    public partial class Personagem
    {
        public byte IdPersonagem { get; set; }
        [Required (ErrorMessage = "Id da classe precisa ser especificado!")]
        public byte? IdClasse { get; set; }
        [Required(ErrorMessage = "Nome do personagem precisa ser especificado!")]
        public string NomePersonagem { get; set; }
        [Required(ErrorMessage = "Quantidade de vida precisa ser especificada!")]
        public byte Vida { get; set; }
        [Required(ErrorMessage = "Quantidade de mana precisa ser especificada!")]
        public byte Mana { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataUpdate { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}