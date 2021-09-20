using senai.HROADS.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.HROADS.webAPI.Interfaces
{
    interface IPersonagemRepository
    {
        //C
        void Cadastrar(Personagem NovoPersonagem);
        //R
        List<Personagem> LerTodos();
        Personagem BuscarPorId(int IdPersonagem);
        List<Personagem> LerComJogador();
        //U
        void Atualizar(Personagem PersonagemAtualizado, int IdPersonagemAtualizado);
        //D
        void Deletar(int IdPersonagemDeletado);
    }
}
