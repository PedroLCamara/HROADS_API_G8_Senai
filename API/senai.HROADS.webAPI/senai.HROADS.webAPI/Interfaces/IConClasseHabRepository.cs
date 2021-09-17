using senai.HROADS.webAPI.Domains;
using System.Collections.Generic;

namespace senai.HROADS.webAPI.Interfaces
{
    interface IConClasseHabRepository
    {
        void Cadastrar(ConClasseHab novaClasseHabC);

        void Deletar(int idClasseHabD);

        void Atualizar(int idClasseHabA, ConClasseHab novaClasseHabA);

        List<ConClasseHab> ListarTodos();

        ConClasseHab BuscarPorId(int idClasseHabB);
    }
}
