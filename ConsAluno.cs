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
    public partial class ConsAluno : Form
    {
        // instanciando nova conexão
        Conexao conexao = new Conexao();

        public ConsAluno()
        {
            InitializeComponent();
        }
        
        private void BtnProcurar_Click(object sender, EventArgs e)
        {            
            // comando e parâmetros
            MySqlCommand Query4 = new MySqlCommand("SELECT aluno.nome, aluno.cpf, aluno.genero, aluno.email, aluno.telefone, aluno.responsavel, endereco.logradouro, endereco.bairro, endereco.cidade, endereco.cep, endereco.estado FROM aluno INNER JOIN endereco on endereco.aluno_cod = aluno.cod_aluno " +
                "WHERE aluno.cod_aluno = ?", conexao.AbrirConexao());
            Query4.Parameters.Clear();
            Query4.Parameters.AddWithValue("@cod_aluno", txtProcurar.Text);            

            // executa o comando
            Query4.CommandType = CommandType.Text;            

            // recebe o conteúdo do banco
            MySqlDataReader leia;
            leia = Query4.ExecuteReader();
            leia.Read();

            txtNome.Text = leia.GetString(0);
            txtCpf.Text = leia.GetString(1);
            txtGenero.Text = leia.GetString(2);
            txtEmail.Text = leia.GetString(3);
            txtTelefone.Text = leia.GetString(4);
            txtResponsavel.Text = leia.GetString(5);
            txtLogradouro.Text = leia.GetString(6);
            txtBairro.Text = leia.GetString(7);
            txtCidade.Text = leia.GetString(8);
            txtCep.Text = leia.GetString(9);
            txtEstado.Text = leia.GetString(10);

            //codAluno = Convert.ToInt32(Query4.);
            /*MySqlCommand Query5 = new MySqlCommand("SELECT logradouro, bairro, cidade, cep, estado FROM endereco WHERE aluno_cod = ?", conexao.AbrirConexao());
            Query5.Parameters.Clear();
            Query5.Parameters.AddWithValue("@aluno_cod", Convert.ToInt32(txtProcurar.Text));

            Query5.ExecuteNonQuery();

            MySqlDataReader leia2;
            leia2 = Query5.ExecuteReader();
            leia2.Read();
            */
            

            // fecha a conexão com o banco de dados
            conexao.FecharConexao();
        }        
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            MySqlCommand Query5 = new MySqlCommand("UPDATE aluno SET nome = ?, cpf = ?, email = ?, telefone = ?, responsavel = ? " +
                "WHERE cod_aluno = ?", conexao.AbrirConexao());
            Query5.Parameters.Clear();
            Query5.Parameters.Add("@nome", MySqlDbType.VarChar, 55).Value = txtNome.Text;
            Query5.Parameters.Add("@cpf", MySqlDbType.VarChar, 18).Value = txtCpf.Text;
            Query5.Parameters.Add("@email", MySqlDbType.VarChar, 50).Value = txtEmail.Text;
            Query5.Parameters.Add("@telefone", MySqlDbType.VarChar, 15).Value = txtTelefone.Text;
            Query5.Parameters.Add("@responsavel", MySqlDbType.VarChar, 55).Value = txtResponsavel.Text;
            Query5.Parameters.Add("@cod_aluno", MySqlDbType.Int32).Value = txtProcurar.Text;

            // executando a Query SQl
            Query5.CommandType = CommandType.Text;
            Query5.ExecuteNonQuery();
            
            // Fechando a conexão
            conexao.FecharConexao();

            MessageBox.Show("Atualização efetuada com sucesso");

        }

        private void BtnDeletar_Click(object sender, EventArgs e)
        {
            // comando MySQL e parâmetros
            MySqlCommand Query6 = new MySqlCommand("DELETE FROM aluno WHERE cod_aluno = ?", conexao.AbrirConexao());
            Query6.Parameters.Clear();
            Query6.Parameters.Add("@cod_aluno", MySqlDbType.Int32).Value = txtProcurar.Text;

            // executa o comando
            Query6.CommandType = CommandType.Text;
            Query6.ExecuteNonQuery();
            
            // fecha a conexão
            conexao.FecharConexao();
            MessageBox.Show("Registro removido com sucesso");
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