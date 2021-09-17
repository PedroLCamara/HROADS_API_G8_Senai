using senai.HROADS.webAPI.Contexts;
using senai.HROADS.webAPI.Domains;
using senai.HROADS.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.HROADS.webAPI.Repositories
{
    public class ConClasseHabRepository : IConClasseHabRepository
    {
        HroadsContext ctx = new HroadsContext();

        public void Atualizar(int idClasseHabA, ConClasseHab novaClasseHabA)
        {
            ConClasseHab conClasseHabBuscada = BuscarPorId(idClasseHabA);

            conClasseHabBuscada.IdClasse = novaClasseHabA.IdClasse;
            conClasseHabBuscada.IdHabilidade = novaClasseHabA.IdHabilidade;

            ctx.ConClasseHabs.Update(conClasseHabBuscada);

            ctx.SaveChanges();
        }

        public ConClasseHab BuscarPorId(int idClasseHabB)
        {
            return ctx.ConClasseHabs.FirstOrDefault(cc => cc.IdConClasseHab == idClasseHabB);
        }

        public void Cadastrar(ConClasseHab novaClasseHabC)
        {
            ctx.ConClasseHabs.Add(novaClasseHabC);

            ctx.SaveChanges();
        }

        public void Deletar(int idClasseHabD)
        {
            ctx.ConClasseHabs.Remove(BuscarPorId(idClasseHabD));

            ctx.SaveChanges();
        }

        public List<ConClasseHab> ListarTodos()
        {
            return ctx.ConClasseHabs.ToList();
        }
    }
}
