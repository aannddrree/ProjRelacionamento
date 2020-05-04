using DB;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjRelacionamento
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //Incluindo as informações da tela no objeto Cliente
            Cliente cliente = new Cliente()
            {
                Id = int.Parse(txtId.Text),
                Nome = txtNome.Text,
                Cidade = new Cidade()
                {
                    Id = int.Parse(cboCidade.SelectedValue.ToString()),
                    Nome = cboCidade.Text
                }
            };

            //Inserir dados
            CreateCliente(cliente);
            //Atualizar dados na grid
            LoadGridCliente();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadComboCidade();
            LoadGridCliente();
        }

        private void LoadComboCidade()
        {
            cboCidade.DataSource = ConnectionSQLite.GetCidadeAll();
            cboCidade.ValueMember = "id";
            cboCidade.DisplayMember = "nome";
        }

        private void LoadGridCliente()
        {
            dgvCliente.DataSource = ConnectionSQLite.GetClienteAll();
        }

        private void CreateCliente(Cliente cliente)
        {
            try
            {
                ConnectionSQLite.Add(cliente);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message);
            }
        }

        private void btnChamar_Click(object sender, EventArgs e)
        {
            TesteChamada t = new TesteChamada();
            t.Show();
        }
    }
}
