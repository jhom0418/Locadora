using LocadoraClassic.VO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraClassic.DAL
{
    public class FilmeDAL
    {


        public void InserirFilme(Filme filme)
        {
            Conexao.Instance.Open();
            string query = "INSERT IGNORE INTO filme(nome, duracao, sinopse, locado)values(@nome, @duracao, @sinopse, @locado)";

            MySqlCommand comando = Conexao.Instance.CreateCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = query;
            comando.Parameters.Add(new MySqlParameter("@nome", filme.nome));
            comando.Parameters.Add(new MySqlParameter("@duracao", filme.duracao));
            comando.Parameters.Add(new MySqlParameter("@sinopse", filme.sinopse));
            comando.Parameters.Add(new MySqlParameter("@locado", filme.locado));
            comando.ExecuteNonQuery();
            Conexao.Instance.Close();
        }

            
            public List<Filme> ObterFilme()
            {
            Conexao.Instance.Open();
            MySqlCommand comando = Conexao.Instance.CreateCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT * FROM filme";
            MySqlDataReader reader = comando.ExecuteReader();
            List<Filme> filmes = new List<Filme>();
            while (reader.Read())
            {
                Filme filme = new Filme();
                filme.id = Convert.ToInt32(reader["id"]);
                filme.nome = reader["nome"].ToString();
                filme.duracao = reader["duracao"].ToString();
                filme.sinopse = reader["sinopse"].ToString();
                filme.locado = Convert.ToBoolean(reader["locado"]);
                filmes.Add(filme);
            }
            // Fechar a conexão e retornar os gêneros obtidos
            reader.Close();
            Conexao.Instance.Close();
            return filmes;
            }
        public void AparecerComboBox(Filme filme)
        {

  
        }


    }
}
