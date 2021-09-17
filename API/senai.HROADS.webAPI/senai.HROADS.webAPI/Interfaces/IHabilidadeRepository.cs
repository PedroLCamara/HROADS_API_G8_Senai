using senai.HROADS.webAPI.Domains;
using System.Collections.Generic;

namespace senai.HROADS.webAPI.Interfaces
{
    interface IHabilidadeRepository
    {
        void Cadastrar(Habilidade novaHabilidadeC);

        void Deletar(int idHabilidadeD);

        void Atualizar(int idHabilidadeA, Habilidade novaHabilidadeA);

        List<Habilidade> ListarTodos();

        Habilidade BuscarPorId(int idHabilidadeB);


    }
}
