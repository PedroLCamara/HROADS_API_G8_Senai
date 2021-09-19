using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.HROADS.webAPI.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Personagems = new HashSet<Personagem>();
        }

        public int IdUsuario { get; set; }
        public byte? IdTipoUsuario { get; set; }
        [Required(ErrorMessage = "Email necessário para a criação de um usuário!!!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Senha necessária para a criação de um usuário!!!")]
        public string Senha { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Personagem> Personagems { get; set; }
    }
}
