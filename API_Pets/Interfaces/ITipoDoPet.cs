using API_Pets.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pets.Interfaces
{
    interface ITipoDoPet
    {
        List<TipoDoPet> ListarTodos();
        TipoDoPet Adicionar(TipoDoPet t);
        TipoDoPet Alterar(int id, TipoDoPet t);
        TipoDoPet BuscarId(int id);
        void Remover(int id);

    }
}
