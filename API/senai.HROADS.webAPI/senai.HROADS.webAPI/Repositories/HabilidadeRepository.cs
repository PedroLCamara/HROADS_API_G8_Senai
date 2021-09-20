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
    public class HabilidadeRepository : IHabilidadeRepository
    {
        HroadsContext ctx = new HroadsContext();

        public void Atualizar(int idHabilidadeA, Habilidade novaHabilidadeA)
        {
            Habilidade habilidadeBuscada = BuscarPorId(idHabilidadeA);

            habilidadeBuscada.IdTipoHabilidade = novaHabilidadeA.IdTipoHabilidade;
            habilidadeBuscada.NomeHabilidade = novaHabilidadeA.NomeHabilidade;

            ctx.Habilidades.Update(habilidadeBuscada);

            ctx.SaveChanges();
        }

        public Habilidade BuscarPorId(int idHabilidadeB)
        {
            return ctx.Habilidades.Include(H => H.IdTipoHabilidadeNavigation).Include(H => H.ConClasseHabs).ThenInclude(CCH => CCH.IdClasseNavigation).FirstOrDefault(h => h.IdHabilidade == idHabilidadeB);
        }

        public void Cadastrar(Habilidade novaHabilidadeC)
        {
            ctx.Habilidades.Add(novaHabilidadeC);

            ctx.SaveChanges();
        }

        public void Deletar(int idHabilidadeD)
        {
            ctx.Habilidades.Remove(BuscarPorId(idHabilidadeD));

            ctx.SaveChanges();
        }

        public List<Habilidade> ListarTodos()
        {
            return ctx.Habilidades.Include(H => H.IdTipoHabilidadeNavigation).Include(H => H.ConClasseHabs).ThenInclude(CCH => CCH.IdClasseNavigation).ToList();
        }
    }
}
