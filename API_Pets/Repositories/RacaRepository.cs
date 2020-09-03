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
    public class RacaRepository : IRaca
    {
        // Contexto conexão
        PetsContext conexao = new PetsContext();

        // Classe que permite consultar
        SqlCommand cmd = new SqlCommand();

        public Raca Adicionar(Raca r)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "INSERT INTO Raca " +
                "(Descricao, IdTipoPet)" +
                "Values" +
                "(@descricao, @idTipoPet)";
            cmd.Parameters.AddWithValue("@descricao", r.Descricao);
            cmd.Parameters.AddWithValue("@idTipoPet", r.IdTipoPet);

            cmd.ExecuteNonQuery();
            conexao.Desconectar();

            return r;
        }

        public Raca Alterar(Raca r)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE FROM Raca" +
                "Descricao = @descricao" +
                "IdTipoPet = @idTipo" +
                "WHERE" +
                "IdRaca = @id";
            cmd.Parameters.AddWithValue("@id", r.IdRaca);

            cmd.Parameters.AddWithValue("@idTipo", r.IdTipoPet);
            cmd.Parameters.AddWithValue("@descricao", r.Descricao);

            cmd.ExecuteNonQuery();
            conexao.Desconectar();

            return r;
        }

        public Raca BuscarId(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Raca WHERE IdRaca = @id";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            Raca r = new Raca();

            while (dados.Read())
            {
                r.IdRaca    = Convert.ToInt32(dados.GetValue(0));
                r.Descricao = dados.GetValue(1).ToString();
                r.IdTipoPet = Convert.ToInt32(dados.GetValue(2));
            }

            conexao.Desconectar();

            return r;
        }

        public List<Raca> ListarTodos()
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Raca";

            SqlDataReader dados = cmd.ExecuteReader();

            List<Raca> racas = new List<Raca>();

            while (dados.Read())
            {
                racas.Add
                (
                    new Raca()
                    {
                        IdRaca    = Convert.ToInt32(dados.GetValue(0)),
                        Descricao = dados.GetValue(1).ToString(),
                        IdTipoPet = Convert.ToInt32(dados.GetValue(2))
                    }
                );
            }
            conexao.Desconectar();

            return racas;
        }

            public void Remover(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM Raca WHERE IdRaca = @id";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }
    }
}
