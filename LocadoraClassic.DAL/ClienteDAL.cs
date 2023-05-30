using LocadoraClassic.VO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraClassic.DAL
{
    public class ClienteDAL
    {
        public void InserirCliente(Cliente cliente)
        {
            Conexao.Instance.Open();
            string query = "INSERT IGNORE INTO cliente(nome, endereco, telefone, cpf, rg)values(@nome, @endereco, @telefone, @cpf, @rg)";

            MySqlCommand comando = Conexao.Instance.CreateCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = query;
            comando.Parameters.Add(new MySqlParameter("@nome", cliente.nome));
            comando.Parameters.Add(new MySqlParameter("@endereco", cliente.endereco));
            comando.Parameters.Add(new MySqlParameter("@telefone", cliente.telefone));
            comando.Parameters.Add(new MySqlParameter("@cpf", cliente.cpf));
            comando.Parameters.Add(new MySqlParameter("@rg", cliente.rg));
            comando.ExecuteNonQuery();
            Conexao.Instance.Close();

        }


        public List<Cliente> ObterCliente()
        {
            Conexao.Instance.Open();
            MySqlCommand comando = Conexao.Instance.CreateCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT * FROM cliente";
            MySqlDataReader reader = comando.ExecuteReader();
            List<Cliente> clientes = new List<Cliente>();
            while (reader.Read())
            {
                Cliente cliente = new Cliente();
                cliente.id = Convert.ToInt32(reader["id"]);
                cliente.nome = reader["nome"].ToString();
                cliente.endereco = reader["endereco"].ToString();
                cliente.telefone = reader["telefone"].ToString();
                cliente.cpf = reader["cpf"].ToString();
                cliente.rg = reader["rg"].ToString();
                clientes.Add(cliente);
            }
            // Fechar a conexão e retornar os gêneros obtidos
            reader.Close();
            Conexao.Instance.Close();
            return clientes;
        }
        public void AtualizarCliente(Cliente cliente)
        {
            // Abrir a Conexão
            Conexao.Instance.Open();

            // MySqlCommand
            MySqlCommand comando = Conexao.Instance.CreateCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "UPDATE cliente SET nome = @nome WHERE id = @id";
            comando.Parameters.AddWithValue("@nome", cliente.nome);
            comando.Parameters.AddWithValue("@id", cliente.id);

            comando.ExecuteNonQuery();

            // Fechar a conexão
            Conexao.Instance.Close();
        }
        public void ExcluirCliente(int id)
        {
            // Abrir a Conexão
            Conexao.Instance.Open();

            // MySqlCommand
            MySqlCommand comando = Conexao.Instance.CreateCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "DELETE FROM cliente WHERE id = @id";
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();

            // Fechar a conexão
            Conexao.Instance.Close();
        }
    }
}
