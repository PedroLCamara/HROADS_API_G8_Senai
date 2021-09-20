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
    public class ClasseRepository : IClasseRepository
    {
        HroadsContext ctx = new HroadsContext();

        public void Atualizar(Classe novaClasseA, int idClasseA)
        {
            Classe classeBuscada = BuscarPorId(idClasseA);

            if (novaClasseA.NomeClasse !=  null)
            {
                classeBuscada.NomeClasse = novaClasseA.NomeClasse;

                ctx.Classes.Update(classeBuscada);

                ctx.SaveChanges();
            }
        }

        public Classe BuscarPorId(int idClasseB)
        {
            return ctx.Classes.Include(C => C.Personagems).Include(C => C.ConClasseHabs).ThenInclude(CCH => CCH.IdHabilidadeNavigation).FirstOrDefault(c => c.IdClasse == idClasseB);
        }

        public void Cadastrar(Classe novaClasseC)
        {
            ctx.Classes.Add(novaClasseC);

            ctx.SaveChanges();
        }

        public void Deletar(int idClasseD)
        {
            ctx.Classes.Remove(BuscarPorId(idClasseD));

            ctx.SaveChanges();
        }

        public List<Classe> ListarTodos()
        {
            return ctx.Classes.Include(C => C.Personagems).Include(C => C.ConClasseHabs).ThenInclude(CCH => CCH.IdHabilidadeNavigation).ToList();
        }
    }
}
