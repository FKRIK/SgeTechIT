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
    public partial class Form3 : Form
    {
        // instanciando nova conexão
        Conexao conexao = new Conexao();
        public Form3()
        {
            InitializeComponent();
        }              

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            // comando SQL para jogar as informações no banco de dados
            MySqlCommand Query = new MySqlCommand("INSERT INTO `aluno`(`nome`,`sobrenome`,`cpf`,`email`,`telefone`,`responsavel`, `rua`, `numero`, `complemento`, `cep`, `bairro`, `cidade`, `estado` ) VALUES (@nome,@sobrenome,@cpf,@email,@telefone,@responsavel,@rua,@numero,@complemento,@cep,@bairro,@cidade,@estado)", conexao.AbrirConexao());

            Query.Parameters.Add("@nome", MySqlDbType.VarChar).Value = txtNome.Text;
            Query.Parameters.Add("@sobrenome", MySqlDbType.VarChar).Value = txtSobrenome.Text;
            Query.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = txtCpf.Text;
            Query.Parameters.Add("@email", MySqlDbType.VarChar).Value = txtEmail.Text;
            Query.Parameters.Add("@telefone", MySqlDbType.VarChar).Value = txtTelefone.Text;
            Query.Parameters.Add("@responsavel", MySqlDbType.VarChar).Value = txtResponsavel.Text;
            Query.Parameters.Add("@rua", MySqlDbType.VarChar).Value = txtRua.Text;
            Query.Parameters.Add("@numero", MySqlDbType.VarChar).Value = txtNumero.Text;
            Query.Parameters.Add("@complemento", MySqlDbType.VarChar).Value = txtComplemento.Text;
            Query.Parameters.Add("@cep", MySqlDbType.VarChar).Value = txtCep.Text;
            Query.Parameters.Add("@bairro", MySqlDbType.VarChar).Value = txtBairro.Text;
            Query.Parameters.Add("@cidade", MySqlDbType.VarChar).Value = txtCidade.Text;
            Query.Parameters.Add("@estado", MySqlDbType.VarChar).Value = txtEstado.Text;
            

            // autenticação do CPF do aluno
            if (ChecarCPF())
            {
                MessageBox.Show("CPF já cadastrado");
                txtCpf.Clear();
                txtCpf.Focus();
            }
            else
            {
                if(Query.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Cadastro realizado");
                    txtNome.Clear();
                    txtSobrenome.Clear();
                    txtCpf.Clear();                    
                }
                else
                {
                    MessageBox.Show("Falha no cadastro. Tente Novamente");
                }
            }

            conexao.FecharConexao();
        }

        // método para checar se o CPF já está cadastrado
        public Boolean ChecarCPF()
        {
            Conexao conexao = new Conexao();

            string consultaCPF = "SELECT cpf FROM aluno WHERE cpf = @cpf";
            MySqlCommand comando = new MySqlCommand(consultaCPF, conexao.AbrirConexao());
            comando.Parameters.AddWithValue("@cpf", txtCpf.Text);
            MySqlDataReader leia = comando.ExecuteReader();

            if (leia.Read())
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void BtnX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}