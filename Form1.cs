using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroUIv3._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "admin" && txtSenha.Text == "admin")
            {
                new Form2().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos. Tente novamente");
                txtUserName.Clear();
                txtSenha.Clear();
                txtUserName.Focus();
            }
        }

        private void BtnLimparcampos_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtSenha.Clear();
            txtUserName.Focus();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TxtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtSenha_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
