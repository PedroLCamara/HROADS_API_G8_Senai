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
    public class PersonagemRepository : IPersonagemRepository
    {

        private HroadsContext Contexto = new HroadsContext();

        public void Atualizar(Personagem PersonagemAtualizado, int IdPersonagemAtualizado)
        {
            Personagem PersonagemBuscado = BuscarPorId(IdPersonagemAtualizado);
            if (PersonagemBuscado != null)
            {
                PersonagemBuscado.Mana = PersonagemAtualizado.Mana;
                PersonagemBuscado.Vida = PersonagemAtualizado.Vida;
                PersonagemBuscado.NomePersonagem = PersonagemAtualizado.NomePersonagem;
                PersonagemBuscado.DataUpdate = DateTime.Now;
                PersonagemBuscado.IdClasse = PersonagemAtualizado.IdClasse;
                PersonagemBuscado.IdUsuario = PersonagemAtualizado.IdUsuario;
                Contexto.Personagems.Update(PersonagemBuscado);
                Contexto.SaveChanges();
            }
        }

        public Personagem BuscarPorId(int IdPersonagem)
        {
            return Contexto.Personagems.Include(P => P.IdClasseNavigation).Include(P => P.IdUsuarioNavigation).FirstOrDefault(P => P.IdPersonagem == IdPersonagem);
        }

        public void Cadastrar(Personagem NovoPersonagem)
        {
            NovoPersonagem.DataCriacao = DateTime.Now;
            NovoPersonagem.DataUpdate = DateTime.Now;
            Contexto.Add(NovoPersonagem);
            Contexto.SaveChanges();
        }

        public void Deletar(int IdPersonagemDeletado)
        {
            Contexto.Remove(BuscarPorId(IdPersonagemDeletado));
            Contexto.SaveChanges();
        }

        public List<Personagem> LerTodos()
        {
            return Contexto.Personagems.Include(P => P.IdClasseNavigation).Include(P => P.IdUsuarioNavigation).ToList();
        }
    }
}