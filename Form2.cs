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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            CustomSubmenus();
        }

        private void CustomSubmenus()
        {
            SubmenuAluno.Visible = false;
            SubmenuProfessor.Visible = false;
            SubmenuCurso.Visible = false;
        }

        private void EsconderSubmenus()
        {
            if (SubmenuAluno.Visible == true)
                SubmenuAluno.Visible = false;
            if (SubmenuProfessor.Visible == true)
                SubmenuProfessor.Visible = false;
            if (SubmenuCurso.Visible == true)
                SubmenuCurso.Visible = false;
        }

        private void MostrarSubmenus(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                EsconderSubmenus();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;                
            }
        }

        private void BtnAluno_Click(object sender, EventArgs e)
        {
            MostrarSubmenus(SubmenuAluno);
        }

        private void BtnCadAluno_Click(object sender, EventArgs e)
        {
            AbrirFormsInternos(new Form3()); //Linkando forms cadastro do aluno
            EsconderSubmenus();
        }

        private void BtnConsAluno_Click(object sender, EventArgs e)
        {
            AbrirFormsInternos(new Form4());//Linkar um forms aqui
            EsconderSubmenus();
        }

        private void BtnProfessor_Click(object sender, EventArgs e)
        {
            MostrarSubmenus(SubmenuProfessor);
        }

        private void BtnCadProfessor_Click(object sender, EventArgs e)
        {
            AbrirFormsInternos(new Form5());//Linkar um forms aqui
            EsconderSubmenus();
        }

        private void BtnConsProfessor_Click(object sender, EventArgs e)
        {
            AbrirFormsInternos(new Form6());//Linkar um forms aqui
            EsconderSubmenus();
        }

        private void BtnCurso_Click(object sender, EventArgs e)
        {
            MostrarSubmenus(SubmenuCurso);
        }

        private void BtnCursosDisp_Click(object sender, EventArgs e)
        {
            AbrirFormsInternos(new Form7());
            EsconderSubmenus();
        }

        private Form activeForm = null;
        private void AbrirFormsInternos(Form formInterno)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = formInterno;
            formInterno.TopLevel = false;
            formInterno.FormBorderStyle = FormBorderStyle.None;
            formInterno.Dock = DockStyle.Fill;
            panelFormInterno.Controls.Add(formInterno);
            panelFormInterno.Tag = formInterno;
            formInterno.BringToFront();
            formInterno.Show();
        }
    }
}