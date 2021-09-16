using senai.HROADS.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.HROADS.webAPI.Interfaces
{
    interface ITipoUsuarioRepository
    {
        //C
        void Cadastrar(TipoUsuario NovoTipo);
        //R
        TipoUsuario BuscarPorId(int IdTipoUsuario);
        List<TipoUsuario> ListarTodos();
        //U
        void Atualizar(TipoUsuario TipoAtualizado, int IdTipoAtualizado);
        //D
        void Deletar(int IdTipoDeletado);
    }
}