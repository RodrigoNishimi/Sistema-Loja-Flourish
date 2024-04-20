using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrjLoja
{
    public partial class frmTrocarSenha : Form
    {
        Classe_Conexao con;
        public frmTrocarSenha()
        {
            InitializeComponent();
        }

        private void btnAlterar_Click_1(object sender, EventArgs e)
        {
            if (txtSenha.Text == txtConfSenha.Text)
            {
                con = new Classe_Conexao();
                SqlCommand cmd = new SqlCommand("update tblFuncionario set senha = '" + txtSenha.Text + "' where email = '" + txtEmail.Text + "' ");
                int x = con.manutencaoDB_Parametros(cmd);
                if (x > 0)
                {
                    MessageBox.Show("Senha alterada com sucesso!", "Sucesso");
                    txtEmail.Text = "";
                    txtSenha.Text = "";
                    txtConfSenha.Text = "";
                }
                else
                {
                    MessageBox.Show("Email incorreto", "Erro");
                }
            }
            else
            {
                MessageBox.Show("As senhas não conferem. Tente novamente.", "Erro");
            }
        }

        private void Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSenha_Leave(object sender, EventArgs e)
        {
            string senhaPattern = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$";
            if (Regex.IsMatch(txtSenha.Text, senhaPattern))
            {
                errorProvider1.Clear();
            }
            else
            {
                errorProvider1.SetError(this.txtSenha, "A senha deve ter pelo menos 8 caracteres, incluindo letras maiúsculas e minúsculas e números");
                return;
            }
        }

        private void txtConfSenha_Leave(object sender, EventArgs e)
        {
            string senhaPattern = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$";
            if (Regex.IsMatch(txtConfSenha.Text, senhaPattern))
            {
                errorProvider2.Clear();
            }
            else
            {
                errorProvider2.SetError(this.txtConfSenha, "A senha deve ter pelo menos 8 caracteres, incluindo letras maiúsculas e minúsculas e números");
                return;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(txtEmail.Text, pattern))
            {
                errorProvider3.Clear();
            }
            else
            {
                errorProvider3.SetError(this.txtEmail, "Email inválido. Formato exemplo: username@gmail.com");
                return;
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            txtEmail.Text = "rodrigo@gmail.com";
            txtConfSenha.Text = "Ro123456";
            txtSenha.Text = "Ro123456";
        }
    }
}