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
    public partial class CadProfessor : Form
    {
        // instaciando nova conexão
        Conexao conexao = new Conexao();
        public CadProfessor()
        {
            InitializeComponent();
        }       

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            int codProfessor = 0;

            // comando SQL para jogar as informações no banco de dados
            MySqlCommand Query = new MySqlCommand("INSERT INTO professor(nome, cpf, data_nasc, genero, email, telefone, whatsapp) " +
                "VALUES (@nome,@cpf,@data_nasc,@genero,@email,@telefone, @whatsapp)", conexao.AbrirConexao());
            
            // string para masculino ou feminino
            string genero;
            if (radioButton1.Checked == true)
            {
                genero = "masculino";
            }
            else
            {
                genero = "feminino";
            }

            int whatsapp;
            if (checkBox1.Checked == true)
            {
                whatsapp = 1;
            }
            else
            {
                whatsapp = 0;
            }

            var CPF = Convert.ToInt64(txtCpf.Text);
            string CPFformatado = String.Format(@"{0:\000\.000\.000\-00}", CPF);
            txtCpf.Text = CPFformatado;

            Query.Parameters.Add("@nome", MySqlDbType.VarChar).Value = txtNome.Text;
            //Query.Parameters.Add("@sobrenome", MySqlDbType.VarChar).Value = txtSobrenome.Text;
            Query.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = txtCpf.Text;
            Query.Parameters.Add("@data_nasc", MySqlDbType.Date).Value = dateData_nasc.Value;
            Query.Parameters.Add("@genero", MySqlDbType.VarChar).Value = genero;
            Query.Parameters.Add("@email", MySqlDbType.VarChar).Value = txtEmail.Text;
            Query.Parameters.Add("@telefone", MySqlDbType.VarChar).Value = txtTelefone.Text;
            Query.Parameters.Add("@whatsapp", MySqlDbType.VarChar).Value = whatsapp;


            // autenticação do CPF do professor
            if (ChecarCPF())
            {
                MessageBox.Show("CPF já cadastrado");
                txtCpf.Clear();
                txtCpf.Focus();
            }
            else
            {
                if (Query.ExecuteNonQuery() == 1)
                {
                    codProfessor = Convert.ToInt32(Query.LastInsertedId);
                    MySqlCommand Query2 = new MySqlCommand("INSERT INTO endereco (logradouro, bairro, cidade, cep, prof_cod, estado) " +
                        "VALUES (@logradouro,@bairro,@cidade,@cep,@prof_cod,@estado)", conexao.AbrirConexao());
                    Query2.Parameters.Add("@logradouro", MySqlDbType.VarChar).Value = txtLogradouro.Text;
                    Query2.Parameters.Add("@cep", MySqlDbType.VarChar).Value = txtCep.Text;
                    Query2.Parameters.Add("@bairro", MySqlDbType.VarChar).Value = txtBairro.Text;
                    Query2.Parameters.Add("@cidade", MySqlDbType.VarChar).Value = txtCidade.Text;
                    Query2.Parameters.Add("@prof_cod", MySqlDbType.Int32).Value = codProfessor;
                    Query2.Parameters.Add("@estado", MySqlDbType.VarChar).Value = txtCidade.Text;
                    Query2.ExecuteNonQuery();

                    MessageBox.Show("Cadastro realizado");
                    txtNome.Clear();                    
                    txtCpf.Clear();
                    txtEmail.Clear();
                    txtTelefone.Clear();
                    txtLogradouro.Clear();
                    txtCep.Clear();
                    txtBairro.Clear();
                    txtCidade.Clear();
                    txtEstado.Clear();

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