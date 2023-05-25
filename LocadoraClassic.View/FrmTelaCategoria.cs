using LocadoraClassic.DAL;
using LocadoraClassic.VO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraClassic.View
{
    public partial class FrmTelaCategoria : Form
    {
        CategoriaDAL categoriaDAL = new CategoriaDAL();
        public FrmTelaCategoria()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria();


            categoria.Nome = TxtCategoria.Text;
            categoria.ValorDiaria = Decimal.Parse(txtValor.Text);

            categoriaDAL.InserirCategoria(categoria);


            TxtCategoria.Text = "";
            txtValor.Text = "";
            CarregarGrid();
            MessageBox.Show("Dados inseridos com sucesso!");


        }
        private void FrmTelaCategoria_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        public void CarregarGrid()
        {
            dgvCategoria.DataSource = categoriaDAL.ObterCategoria().ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void excluirBtn_Click(object sender, EventArgs e)
        {
            int id = 0;

            if (dgvCategoria.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvCategoria.SelectedRows[0];
                id = Convert.ToInt32(selectedRow.Cells["id"].Value);

                MessageBox.Show("O valor do campo 'id' foi excluido com sucesso!");
            }
            CategoriaDAL categoriaDAL = new CategoriaDAL();
            categoriaDAL.ExcluirCategoria(id);
            CarregarGrid();

        }

        private void TxtCategoria_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
