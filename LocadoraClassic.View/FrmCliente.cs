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
    public partial class FrmCliente : Form
    {
        ClienteDAL clienteDAL = new ClienteDAL();
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();



            cliente.nome = txtNome.Text;
            cliente.endereco = txtEndereco.Text;
            cliente.telefone = txtTelefone.Text;
            cliente.cpf = txtCpf.Text;
            cliente.rg = txtRg.Text;

            clienteDAL.InserirCliente(cliente);


            txtNome.Text = "";
            txtEndereco.Text = "";
            txtTelefone.Text = "";
            txtCpf.Text = "";
            txtRg.Text = "";

            MessageBox.Show("Dados inseridos com sucesso!");
        }

 
    }
}
