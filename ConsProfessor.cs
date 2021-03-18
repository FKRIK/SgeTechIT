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
    public partial class ConsProfessor : Form
    {
        Conexao conexao = new Conexao();

        public ConsProfessor()
        {
            InitializeComponent();
        }

       
        private void btnProcurar_Click(object sender, EventArgs e)
        {
            // comando e parâmetros
            MySqlCommand Query7 = new MySqlCommand("SELECT professor.nome, professor.cpf, professor.genero, professor.email, professor.telefone, endereco.logradouro, endereco.bairro, endereco.cidade, endereco.cep, endereco.estado FROM professor INNER JOIN endereco on endereco.prof_cod = professor.cod_prof " +
                "WHERE professor.cod_prof = ?", conexao.AbrirConexao());
            Query7.Parameters.Clear();
            Query7.Parameters.AddWithValue("@cod_prof", txtProcurar.Text);

            // executa o comando
            Query7.CommandType = CommandType.Text;

            // recebe o conteúdo do banco
            MySqlDataReader leia;
            leia = Query7.ExecuteReader();
            leia.Read();

            txtNome.Text = leia.GetString(0);
            txtCpf.Text = leia.GetString(1);
            txtGenero.Text = leia.GetString(2);
            txtEmail.Text = leia.GetString(3);
            txtTelefone.Text = leia.GetString(4);            
            txtLogradouro.Text = leia.GetString(5);
            txtBairro.Text = leia.GetString(6);
            txtCidade.Text = leia.GetString(7);
            txtCep.Text = leia.GetString(8);
            txtEstado.Text = leia.GetString(9);

            conexao.FecharConexao();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MySqlCommand Query8 = new MySqlCommand("UPDATE professor SET nome = ?, cpf = ?, email = ?, telefone = ? " +
                "WHERE cod_prof = ?", conexao.AbrirConexao());
            Query8.Parameters.Clear();
            Query8.Parameters.Add("@nome", MySqlDbType.VarChar, 55).Value = txtNome.Text;
            Query8.Parameters.Add("@cpf", MySqlDbType.VarChar, 18).Value = txtCpf.Text;
            Query8.Parameters.Add("@email", MySqlDbType.VarChar, 50).Value = txtEmail.Text;
            Query8.Parameters.Add("@telefone", MySqlDbType.VarChar, 15).Value = txtTelefone.Text;            
            Query8.Parameters.Add("@cod_prof", MySqlDbType.Int32).Value = txtProcurar.Text;

            // executando a Query SQl
            Query8.CommandType = CommandType.Text;
            Query8.ExecuteNonQuery();

            // Fechando a conexão
            conexao.FecharConexao();

            MessageBox.Show("Atualização efetuada com sucesso");
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            // comando MySQL e parâmetros
            MySqlCommand Query6 = new MySqlCommand("DELETE FROM professor WHERE cod_prof = ?", conexao.AbrirConexao());
            Query6.Parameters.Clear();
            Query6.Parameters.Add("@cod_prof", MySqlDbType.Int32).Value = txtProcurar.Text;

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

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
