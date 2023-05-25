using System;
using System.Linq;
using System.Windows.Forms;
using LocadoraClassic.VO;
using LocadoraClassic.DAL;

namespace LocadoraClassic.View
{
    public partial class FrmTelaGenero : Form
    {
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
    }
}
