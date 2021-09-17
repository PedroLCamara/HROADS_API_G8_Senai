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
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private HroadsContext Contexto = new HroadsContext();

        public void Atualizar(TipoUsuario TipoAtualizado, int IdTipoAtualizado)
        {
            TipoUsuario TipoBuscado = BuscarPorId(IdTipoAtualizado);
            if (TipoBuscado != null)
            {
                TipoBuscado.TituloTipoUsuario = TipoAtualizado.TituloTipoUsuario;
                Contexto.TipoUsuarios.Update(TipoBuscado);
                Contexto.SaveChanges();
            }
        }

        public TipoUsuario BuscarPorId(int IdTipoUsuario)
        {
            return Contexto.TipoUsuarios.Include(TpU => TpU.Usuarios).FirstOrDefault(TpU => TpU.IdTipoUsuario == IdTipoUsuario);
        }

        public void Cadastrar(TipoUsuario NovoTipo)
        {
            Contexto.TipoUsuarios.Add(NovoTipo);
            Contexto.SaveChanges();
        }

        public void Deletar(int IdTipoDeletado)
        {
            Contexto.TipoUsuarios.Remove(BuscarPorId(IdTipoDeletado));
        }

        public List<TipoUsuario> ListarTodos()
        {
            return Contexto.TipoUsuarios.Include(TpU => TpU.Usuarios).ToList();
        }
    }
}
