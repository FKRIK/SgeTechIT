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
    class Conexao
    {
        //variáveis de conexão
        public string db = "SERVER=br924.hostgator.com.br;" +
                           "DATABASE=modain69_grupo3;" +
                           "UID=modain69_grupo3;" +
                           "PORT=3306;" +
                           "PWD=grupo3;";

        public MySqlConnection con = null;

        //método para abrir conexão
        public MySqlConnection AbrirConexao()
        {
            try
            {
                con = new MySqlConnection(db);
                con.Open();
                Console.Write("Conexão aberta.");
            }
            catch (Exception e)
            {
                Console.Write("Erro: '" + e + "' ao abrir conexão.");
            }

            return con;
        }

        public void FecharConexao()
        {
            try
            {
                con.Close();
                MessageBox.Show("Conexão fechada.");
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro: '" + e + "' ao fechar conexão.");
            }
        }
    }
}
