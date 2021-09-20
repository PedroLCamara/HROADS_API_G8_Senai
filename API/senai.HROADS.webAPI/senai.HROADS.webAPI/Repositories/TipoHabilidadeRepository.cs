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
    public class TipoHabilidadeRepository : ITipoHabilidadeRepository
    {
        HroadsContext ctx = new HroadsContext();

        public void Atualizar(int idTipoHabilidadeA, TipoHabilidade tipoHabilidadeA)
        {
            TipoHabilidade tipoHabilidadeBuscada = BuscarPorId(idTipoHabilidadeA);

            tipoHabilidadeBuscada.NomeTipoHab = tipoHabilidadeA.NomeTipoHab;

            ctx.TipoHabilidades.Update(tipoHabilidadeBuscada);

            ctx.SaveChanges();
        }

        public TipoHabilidade BuscarPorId(int idTipoHabilidadeB)
        {
            return ctx.TipoHabilidades.Include(TpH => TpH.Habilidades).FirstOrDefault(t => t.IdTipoHab == idTipoHabilidadeB);
        }

        public void Cadastrar(TipoHabilidade tipoHabilidadeC)
        {
            ctx.TipoHabilidades.Add(tipoHabilidadeC);

            ctx.SaveChanges();
        }

        public void Deletar(int idTipoHabilidadeD)
        {
            ctx.TipoHabilidades.Remove(BuscarPorId(idTipoHabilidadeD));

            ctx.SaveChanges();
        }

        public List<TipoHabilidade> ListarTodos()
        {
            return ctx.TipoHabilidades.Include(TpH => TpH.Habilidades).ToList();
        }
    }
}
