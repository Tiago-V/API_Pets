using API_Pets.Context;
using API_Pets.Domains;
using API_Pets.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pets.Repositories
{
    public class TipoDoPetRepository : ITipoDoPet
    {
        PetsContext conexao = new PetsContext();

        SqlCommand cmd = new SqlCommand();    

        public TipoDoPet Adicionar(TipoDoPet t)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "INSERT INTO tipoPet " +
                "(Descricao)" +
                "Values" +
                "(@descricao)";
            cmd.Parameters.AddWithValue("@descricao", t.Descricao);

            cmd.ExecuteNonQuery();
            conexao.Desconectar();

            return t;
        }

        public TipoDoPet Alterar(int id, TipoDoPet t)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE FROM tipoPet" +
                "Descricao = @descricao" +
                "WHERE" +
                "IdTipoPet = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.Parameters.AddWithValue("@descricao", t.Descricao);

            cmd.ExecuteNonQuery();
            conexao.Desconectar();

            return t;
        }

        public TipoDoPet BuscarId(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM tipoPet WHERE idTipoPet = @id";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            TipoDoPet t = new TipoDoPet();

            while (dados.Read())
            {
                t.IdTipoPet = Convert.ToInt32(dados.GetValue(0));
                t.Descricao = dados.GetValue(1).ToString();
            }

            conexao.Desconectar();

            return t;
        }

        public List<TipoDoPet> ListarTodos()
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM tipoPet";

            SqlDataReader dados = cmd.ExecuteReader();

            List<TipoDoPet> tipos = new List<TipoDoPet>();

            while(dados.Read())
            {
                tipos.Add
                (
                    new TipoDoPet()
                    {
                        IdTipoPet = Convert.ToInt32(dados.GetValue(0)),
                        Descricao = dados.GetValue(1).ToString()    
                    }
                );
            }
            conexao.Desconectar();

            return tipos;
        }

        public void Remover(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM Raca WHERE idTipoPet = @id";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }
    }
}
