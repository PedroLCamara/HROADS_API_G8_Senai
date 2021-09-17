using senai.HROADS.webAPI.Domains;
using System.Collections.Generic;

namespace senai.HROADS.webAPI.Interfaces
{
    interface ITipoHabilidadeRepository
    {
        void Cadastrar(TipoHabilidade tipoHabilidadeC);

        void Deletar(int idTipoHabilidadeD);

        void Atualizar(int idTipoHabilidadeA, TipoHabilidade tipoHabilidadeA);

        List<TipoHabilidade> ListarTodos();

        TipoHabilidade BuscarPorId(int idTipoHabilidadeB);
    }
}
