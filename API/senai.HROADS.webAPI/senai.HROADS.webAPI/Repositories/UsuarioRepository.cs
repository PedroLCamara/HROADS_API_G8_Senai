using Microsoft.EntityFrameworkCore;
using senai.HROADS.webAPI.Contexts;
using senai.HROADS.webAPI.Domains;
using senai.HROADS.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.HROADS.webAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private HroadsContext Contexto = new HroadsContext();

        public void Atualizar(Usuario UsuarioAtualizado, int IdUsuarioAtualizado)
        {
            Usuario UsuarioBuscado = BuscarPorId(IdUsuarioAtualizado);
            if (UsuarioBuscado != null)
            {
                UsuarioBuscado.Email = UsuarioAtualizado.Email;
                UsuarioBuscado.Senha = UsuarioAtualizado.Senha;
                if (UsuarioBuscado.Personagems.Count() <= 0)
                {
                    UsuarioBuscado.IdTipoUsuario = UsuarioAtualizado.IdTipoUsuario;
                }
                Contexto.Update(UsuarioBuscado);
                Contexto.SaveChanges();
            }
        }

        public Usuario BuscarPorId(int IdUsuario)
        {
            return Contexto.Usuarios.Include(U => U.Personagems).Include(U => U.IdTipoUsuarioNavigation).FirstOrDefault(U => U.IdUsuario == IdUsuario);
        }

        public void Cadastrar(Usuario NovoUsuario)
        {
            Contexto.Usuarios.Add(NovoUsuario);
            Contexto.SaveChanges();
        }

        public void Deletar(int IdUsuarioDeletado)
        {
            Contexto.Usuarios.Remove(BuscarPorId(IdUsuarioDeletado));
            Contexto.SaveChanges();
        }

        public List<Usuario> ListarTodos()
        {
            return Contexto.Usuarios.Include(U => U.Personagems).Include(U => U.IdTipoUsuarioNavigation).ToList();
        }

        public Usuario Logar(string Email, string Senha)
        {
            return Contexto.Usuarios.Include(U => U.IdTipoUsuarioNavigation).FirstOrDefault(U => U.Email == Email && U.Senha == Senha);
        }
    }
}
