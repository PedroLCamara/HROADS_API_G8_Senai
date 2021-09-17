using senai.HROADS.webAPI.Domains;
using System.Collections.Generic;

namespace senai.HROADS.webAPI.Interfaces
{
    interface IClasseRepository
    {
        void Cadastrar(Classe novaClasseC);

        void Deletar(int idClasseD);

        void Atualizar(Classe novaClasseA, int idClasseA);

        List<Classe> ListarTodos();

        Classe BuscarPorId(int idClasseB);


    }
}
