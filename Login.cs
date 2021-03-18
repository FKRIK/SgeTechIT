using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CadastroUIv3._0
{
    public partial class Login : Form
    {
        Conexao conexao = new Conexao();
        public Login()
        {
            InitializeComponent(); 
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string Query = "SELECT * FROM usuario WHERE usuario ='" + txtUserName.Text + "'and senha='" + txtSenha.Text + "'";
            MySqlCommand cmd = new MySqlCommand(Query, conexao.AbrirConexao());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                new MenuPrincipal().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos. Tente novamente");
                txtUserName.Clear();
                txtSenha.Clear();
                txtUserName.Focus();
            }
            // new MenuPrincipal().Show();
            // this.Hide();
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

        // isso é um comentario
    }
}
