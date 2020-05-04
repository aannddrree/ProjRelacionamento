using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjRelacionamento
{
    public partial class TesteChamada : Form
    {
        public TesteChamada()
        {
            InitializeComponent();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new FormCliente().Show();

            FormCliente c = new FormCliente();
            c.MdiParent = this;
            c.Show();

        }
    }
}
