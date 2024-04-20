using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrjLoja
{
    public partial class Form1 : Form
    {
        Classe_Conexao con;
        DataTable dt;
        public Form1()
        {
            InitializeComponent();
        }

        private void transferir()
        {
            con = new Classe_Conexao();
            dt = new DataTable();

            String email = txtEmail.Text;
            String senha = txtSenha.Text;
            
            String sql = "select idFuncionario from tblFuncionario where email = '" + email + "' and senha = '" + senha + "' ";
            dt = con.executarSQL(sql);
            txtID.Text = dt.Rows[0]["idFuncionario"].ToString();

            frmMenu menu = new frmMenu(txtID.Text);
            menu.ShowDialog();
        }

        private void transferir2()
        {
            con = new Classe_Conexao();
            dt = new DataTable();

            String email = txtEmail.Text;
            String senha = txtSenha.Text;

            String sql = "select idFuncionario from tblFuncionario where email = '" + email + "' and senha = '" + senha + "' ";
            dt = con.executarSQL(sql);
            txtID.Text = dt.Rows[0]["idFuncionario"].ToString();

            frmMenuFunc menuFunc = new frmMenuFunc(txtID.Text);
            menuFunc.ShowDialog();
        }

        private void txtEmail_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email")
            {
                txtEmail.Clear();
            }
            panel1.BackColor = Color.FromArgb(2, 111, 103);
            txtEmail.ForeColor = Color.FromArgb(2, 111, 103);
            panel2.BackColor = Color.FromArgb(51, 51, 51);
            txtSenha.ForeColor = Color.DimGray;
        }

        private void txtSenha_Click(object sender, EventArgs e)
        {
            if (txtSenha.Text == "Senha")
            {
                txtSenha.Clear();
            }
            txtSenha.PasswordChar = '*';
            panel2.BackColor = Color.FromArgb(2, 111, 103);
            txtSenha.ForeColor = Color.FromArgb(2, 111, 103);
            panel1.BackColor = Color.FromArgb(51, 51, 51);
            txtEmail.ForeColor = Color.DimGray;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            con = new Classe_Conexao();
            dt = new DataTable();

            String email = txtEmail.Text;
            String sen = txtSenha.Text;
            if (email != "" && sen != "" )
            {
                dt = con.executarSQL("select * from tblFuncionario where email = '" + email + "' and senha = '" + sen + "' ");
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["idCat_Funcionario"].ToString() == "1")
                    {
                        this.Hide();
                        transferir();
                    }
                    else
                    {
                        this.Hide();
                        transferir2();
                    }
                }
                else
                {
                    MessageBox.Show("Email ou senha incorretos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtEmail.Clear();
                    txtSenha.Clear();
                }
            }
        }
        private void Fechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void txtTrocarSenha_Click(object sender, EventArgs e)
        {
            frmTrocarSenha trocarSenha = new frmTrocarSenha();
            trocarSenha.ShowDialog();
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            txtEmail.Text = "rodrigo@gmail.com";
        }
    }
}
