using senai.HROADS.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.HROADS.webAPI.Interfaces
{
    interface IUsuarioRepository
    {
        //C
        void Cadastrar(Usuario NovoUsuario);
        //R
        List<Usuario> ListarTodos();
        Usuario BuscarPorId(int IdUsuario);
        Usuario Logar(string Email, string Senha);
        //U
        void Atualizar(Usuario UsuarioAtualizado, int IdUsuarioAtualizado);
        //D
        void Deletar(int IdUsuarioDeletado);
    }
}
