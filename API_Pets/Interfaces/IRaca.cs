using API_Pets.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pets.Interfaces
{
    interface IRaca
    {
        List<Raca> ListarTodos();
        Raca Adicionar(Raca r);
        Raca Alterar(Raca r);
        Raca BuscarId(int id);
        void Remover(int id);
    }
}
