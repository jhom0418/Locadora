using LocadoraClassic.DAL;
using LocadoraClassic.VO;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraClassic.View
{
    public partial class FrmTelaFilme : Form
    {
        FilmeDAL filmeDAL = new FilmeDAL();
        private SqlConnection connection = new SqlConnection(@"Server=127.0.0.1;Database=locadoraclassic;Uid=root;Pwd=");
        public FrmTelaFilme()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Filme filme = new Filme();



            filme.nome = txtNome.Text;
            filme.duracao = txtDuracao.Text;
            filme.sinopse = txtSinopse.Text;
            filme.locado = checkBox.Checked;


            filmeDAL.InserirFilme(filme);


            txtNome.Text = "";
            txtDuracao.Text = "";
            txtSinopse.Text = "";

;

            MessageBox.Show("Dados inseridos com sucesso!");
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
                CheckBox checkBox = new CheckBox();
                checkBox.Appearance = Appearance.Button;
                checkBox.AutoCheck = false;
                Controls.Add(checkBox);
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Abra a conexão com o banco de dados
                connection.Open();

                // Defina sua consulta SQL para recuperar os dados
                string query = "SELECT nome FROM categoria";

                // Crie um comando usando a consulta e a conexão
                SqlCommand command = new SqlCommand(query, connection);

                // Crie um adaptador de dados para preencher um DataTable
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                // Preencha o DataTable com os dados do banco de dados
                adapter.Fill(dataTable);

                // Defina as propriedades do ComboBox
                comboBox1.DisplayMember = "nome";
                comboBox1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                // Certifique-se de fechar a conexão com o banco de dados
                connection.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            


        }
    }
}
