using System;
using System.Linq;
using System.Windows.Forms;
using LocadoraClassic.VO;
using LocadoraClassic.DAL;

namespace LocadoraClassic.View
{
    public partial class FrmTelaGenero : Form
    {
        Genero genero = new Genero();
        int id = 0;
        GeneroDAL generoDAL = new GeneroDAL();
        public FrmTelaGenero()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
  
            Genero genero = new Genero();

        
 
            genero.Nome = txtGenero.Text;

            generoDAL.InserirGenero(genero);

            
            txtGenero.Text = "";        
            CarregarGrid();
            MessageBox.Show("Dados inseridos com sucesso!");


        }

        private void FrmTelaGenero_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        public void CarregarGrid()
        {
            dgvGeneros.DataSource = generoDAL.ObterGeneros().ToList();
        }

        private void dgvGeneros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtGenero_TextChanged(object sender, EventArgs e)
        {

        }

        private void excluirBnt_Click(object sender, EventArgs e)
        {
            int id = 0;

            if (dgvGeneros.SelectedRows.Count > 0) 
            {
                DataGridViewRow selectedRow = dgvGeneros.SelectedRows[0];
                id = Convert.ToInt32(selectedRow.Cells["id"].Value);

                MessageBox.Show("O valor do campo 'id' foi excluido com sucesso!");
            }
            GeneroDAL generoDAL = new GeneroDAL();
            generoDAL.ExcluirGenero(id);
            CarregarGrid();

        }

        private void dgvGeneros_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtém a linha em que ocorreu o duplo clique
                DataGridViewRow row = dgvGeneros.Rows[e.RowIndex];

                // Seleciona a linha inteira
                row.Selected = true;
            }

            //ETAPA 1 - SELECIONAR O ID DA TABELA

            // Verifica se há alguma linha selecionada no DataGridView
            if (dgvGeneros.SelectedRows.Count > 0)
            {
                // Obtém a linha selecionada
                DataGridViewRow selectedRow = dgvGeneros.SelectedRows[0];

                // Obtém o valor do campo "id" da célula selecionada
                id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                string nome = selectedRow.Cells["nome"].Value.ToString();
                txtGenero.Text = nome;
                // Faça o que precisar com o valor do campo "id"
                // Por exemplo, exiba-o em uma caixa de diálogo


            }
        }


            
        private void btnEditar_Click(object sender, EventArgs e)
        {

            genero.Nome = txtGenero.Text;
            genero.Id = id;
            generoDAL.AtualizarGenero(genero);
            txtGenero.Text = "";
            CarregarGrid();

        }    
    }
}
