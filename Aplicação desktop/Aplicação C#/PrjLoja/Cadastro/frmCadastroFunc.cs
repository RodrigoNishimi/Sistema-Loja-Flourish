using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace PrjLoja
{
    public partial class frmCadastroFunc : Form
    {
        Classe_Conexao con;
        private string caminhoImagem = null;

        public frmCadastroFunc()
        {
            InitializeComponent();
        }

        public static byte[] ImgToByte(string camImg) //converte a imagem em []bytes
        {
            if (camImg != null)
            {
                FileStream fs = new FileStream(camImg, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] imgByte = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();
                return imgByte;
            }
            else 
            {
                return null;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofl = new OpenFileDialog();
            ofl.Title = "Adicionar Imagem";
            ofl.Filter = "All files (*.*)|*.*";
            if (ofl.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pbFoto.Image = new Bitmap(ofl.OpenFile());
                    caminhoImagem = ofl.FileName;
                }
                catch (Exception)
                {
                    MessageBox.Show("Falha ao carregar a imagem");
                }
            }
            ofl.Dispose();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            con = new Classe_Conexao();
            byte[] imagem = ImgToByte(caminhoImagem);
            string emailPattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            string senhaPattern = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$";
            string cepPattern = "^\\d{5}-\\d{3}$";
            string cpfPattern = "^\\d{3}\\.\\d{3}\\.\\d{3}-\\d{2}$";
            string fonePattern = "\\(\\d{2,}\\) \\d{4,}\\-\\d{4}";
            DateTime Temp;

            int IdCatFunc = 0;
            if (cbIDCatFunc.Text == "Administrador")
                IdCatFunc = 1;
            else
                IdCatFunc = 2;

            //SqlCommand cmd = new SqlCommand("Exec CadastrarFuncionarios '" + cbIDCatFunc.Text + "' , '" + txtNome.Text + "' , '" + txtEmail.Text + "' , '" + txtSenha.Text + "' , '" + txtFone.Text + "' , '" + txtCpf.Text + "' , '" + cbSexo.Text + "' , '" + txtDataNasc.Text + "' , '" + txtSalario.Text + "' , '" + cbEstado.Text + "' , '" + txtCidade.Text + "' , '" + txtEndereco.Text + "' , '" + txtCep.Text + "', '" + imagem + "'");
            if (Regex.IsMatch(txtCep.Text, cepPattern) && Regex.IsMatch(txtCpf.Text, cpfPattern) && Regex.IsMatch(txtFone.Text, fonePattern) && DateTime.TryParse(txtDataNasc.Text, out Temp) == true && Temp.Year > 1941 && Temp > DateTime.MinValue && Temp.Year < 2003)
            {
                if (Regex.IsMatch(txtEmail.Text, emailPattern) && Regex.IsMatch(txtSenha.Text, senhaPattern))
                {
                    if (imagem != null)
                    {
                        SqlCommand cmd = new SqlCommand("insert into tblFuncionario (idCat_Funcionario, nome, email, senha, telefone, cpf, sexo, data_Nasc, salario, estado, cidade, endereco, cep, foto)values(@idCat_Funcionario, @nome, @email, @senha, @telefone, @cpf, @sexo, @dataNasc, @salario, @estado, @cidade, @endereco, @cep, @foto)");
                        cmd.Parameters.Add("@idCat_Funcionario", SqlDbType.Int).Value = IdCatFunc;
                        cmd.Parameters.Add("@nome", SqlDbType.NVarChar, 50).Value = txtNome.Text;
                        cmd.Parameters.Add("@email", SqlDbType.NVarChar, 40).Value = txtEmail.Text;
                        cmd.Parameters.Add("@senha", SqlDbType.NVarChar, 40).Value = txtSenha.Text;
                        cmd.Parameters.Add("@telefone", SqlDbType.NVarChar, 30).Value = txtFone.Text;
                        cmd.Parameters.Add("@cpf", SqlDbType.NVarChar, 20).Value = txtCpf.Text;
                        cmd.Parameters.Add("@sexo", SqlDbType.NVarChar, 20).Value = cbSexo.Text;
                        cmd.Parameters.Add("@dataNasc", SqlDbType.Date).Value = txtDataNasc.Text;
                        cmd.Parameters.Add(new SqlParameter("@salario", SqlDbType.Decimal) { Precision = 10, Scale = 2 }).Value = txtSalario.Text.Replace(".", ",");
                        cmd.Parameters.Add("@estado", SqlDbType.NVarChar, 40).Value = cbEstado.Text;
                        cmd.Parameters.Add("@cidade", SqlDbType.NVarChar, 40).Value = txtCidade.Text;
                        cmd.Parameters.Add("@endereco", SqlDbType.NVarChar, 90).Value = txtEndereco.Text;
                        cmd.Parameters.Add("@cep", SqlDbType.NVarChar, 40).Value = txtCep.Text;
                        cmd.Parameters.Add("@foto", SqlDbType.VarBinary, imagem.Length).Value = imagem;

                        int x = con.manutencaoDB_Parametros(cmd);
                        if (x > 0)
                        {
                            MessageBox.Show("Registro cadastrado com sucesso", "Sucesso");
                            cbIDCatFunc.Text = "";
                            txtNome.Text = "";
                            txtEmail.Text = "";
                            txtSenha.Text = "";
                            txtFone.Text = "";
                            txtCpf.Text = "";
                            cbSexo.Text = "";
                            txtDataNasc.Text = "";
                            txtSalario.Text = "";
                            cbEstado.Text = "";
                            txtCidade.Text = "";
                            txtEndereco.Text = "";
                            txtCep.Text = "";
                            pbFoto.Image = null;
                        }
                        else
                        {
                            MessageBox.Show("Falha ao cadastrar.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Insira uma imagem!"); 
                    }
                }
                else
                {
                    MessageBox.Show("Email ou senha inválidos"); 
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos corretamente.");
            }
                    
        }

        private void txtSalario_KeyPress(object sender, KeyPressEventArgs e)
        {
            decNumber.DecNumber(sender, e);
        }

        private void txtEmail_TextChange(object sender, EventArgs e)
        {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(txtEmail.Text, pattern))
            {
                emailError.Clear();
            }
            else
            {
                emailError.SetError(this.txtEmail, "Email inválido. Formato exemplo: username@gmail.com");
                return;
            }
        }

        private void txtSenha_TextChange(object sender, EventArgs e)
        {
            string senhaPattern = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$";
            if (Regex.IsMatch(txtSenha.Text, senhaPattern))
            {
                senhaError.Clear();
            }
            else
            {
                senhaError.SetError(this.txtSenha, "A senha deve ter pelo menos 8 caracteres, incluindo letras maiúsculas e minúsculas e números");
                return;
            }
        }

        private void txtDataNasc_TextChanged(object sender, EventArgs e)
        {
            DateTime Temp;
            if (DateTime.TryParse(txtDataNasc.Text, out Temp) == true && Temp.Year > 1941 && Temp > DateTime.MinValue && Temp.Year < 2003)
            {
                dataNascError.Clear();
            }
            else
            {
                dataNascError.SetError(this.txtDataNasc, "Data inválida. O ano deve estar entre 1941 e 2002");
                return;
            }
        }

        private void txtFone_TextChanged(object sender, EventArgs e)
        {
            string fonePattern = "\\(\\d{2,}\\) \\d{4,}\\-\\d{4}";
            if (Regex.IsMatch(txtFone.Text, fonePattern))
            {
                foneError.Clear();
            }
            else
            {
                foneError.SetError(this.txtFone, "Número inválido. Formato aceito: (99) 99999-9999");
                return;
            }
        }

        private void txtCpf_TextChanged(object sender, EventArgs e)
        {
            string cpfPattern = "^\\d{3}\\.\\d{3}\\.\\d{3}-\\d{2}$";
            if (Regex.IsMatch(txtCpf.Text, cpfPattern))
            {
                cpfError.Clear();
            }
            else
            {
                cpfError.SetError(this.txtCpf, "CPF inválido. Formato aceito: 999.999.999-99");
                return;
            }
        }

        private void txtCep_TextChanged(object sender, EventArgs e)
        {
                        string cepPattern = "^\\d{5}-\\d{3}$";
            if (Regex.IsMatch(txtCep.Text, cepPattern))
            {
                cepError.Clear();
            }
            else
            {
                cepError.SetError(this.txtCep, "CEP inválido. Formato aceito: 99999-999");
                return;
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            cbIDCatFunc.Text = "Administrador";
            txtNome.Text = "Mariano Souza Lima";
            txtEmail.Text = "mariano@";
            txtSenha.Text = "Mariano";
            txtFone.Text = "11554843479";
            txtCpf.Text = "8495869604";
            cbSexo.Text = "Masculino";
            txtDataNasc.Text = "12132000";
            txtSalario.Text = "3456,56";
            cbEstado.Text = "SP";
            txtCidade.Text = "São Paulo";
            txtEndereco.Text = "Av. Tiradentes, 576";
            txtCep.Text = "46757901";
        }
    }
}