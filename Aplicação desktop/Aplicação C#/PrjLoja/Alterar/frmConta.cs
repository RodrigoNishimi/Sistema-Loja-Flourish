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
using System.IO;
using System.Text.RegularExpressions;

namespace PrjLoja
{
    public partial class frmConta : Form
    {

        Classe_Conexao con;
        DataSet ds;
        private string caminhoImagem = null;
        byte[] imgAnt = null;

        public frmConta(string texto)
        {
            InitializeComponent();
            txtID.Text = texto;
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

        private void btnAddImg_Click(object sender, EventArgs e)
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

        private void frmConta_Load(object sender, EventArgs e)
        {
            con = new Classe_Conexao();
            ds = new DataSet();
            ds = con.executa_sql("select * from tblFuncionario where idFuncionario = '" + txtID.Text + "'");
            try
            {
                    txtEmail.Text = ds.Tables[0].Rows[0]["email"].ToString().Trim();
                    txtSenha.Text = ds.Tables[0].Rows[0]["senha"].ToString().Trim();
                    txtFone.Text = ds.Tables[0].Rows[0]["telefone"].ToString().Trim();
                    txtNome.Text = ds.Tables[0].Rows[0]["nome"].ToString().Trim();
                    cbEstado.Text = ds.Tables[0].Rows[0]["estado"].ToString();
                    txtCidade.Text = ds.Tables[0].Rows[0]["cidade"].ToString().Trim();
                    txtEndereco.Text = ds.Tables[0].Rows[0]["endereco"].ToString().Trim();
                    txtCep.Text = ds.Tables[0].Rows[0]["cep"].ToString().Trim();
            }
            catch
            { MessageBox.Show("Erro. Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

            try
            {
                imgAnt = (Byte[])(ds.Tables[0].Rows[0]["foto"]);
                pbFoto.Image = Image.FromStream(new MemoryStream(imgAnt));
            }
            catch { { MessageBox.Show("Registro sem imagem!"); } }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            con = new Classe_Conexao();
            byte[] imagem = ImgToByte(caminhoImagem);
            string emailPattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            string senhaPattern = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$";
            string cepPattern = "^\\d{5}-\\d{3}$";
            string fonePattern = "\\(\\d{2,}\\) \\d{4,}\\-\\d{4}";

            //SqlCommand cmd = new SqlCommand("Exec AlterarFuncionarios2 '" + txtID.Text + "','" + txtEmail.Text + "','" + txtSenha.Text + "','" + txtFone.Text + "','" + txtCpf.Text + "','" + cbEstado.Text + "','" + txtCidade.Text + "','" + txtEndereco.Text + "','" + txtCep.Text + "' ");

            if (Regex.IsMatch(txtCep.Text, cepPattern) && Regex.IsMatch(txtFone.Text, fonePattern) && Regex.IsMatch(txtEmail.Text, emailPattern) && Regex.IsMatch(txtSenha.Text, senhaPattern))
            {
                if (imagem != null)
                {
                    SqlCommand cmd = new SqlCommand("Update tblFuncionario set nome = @nome, email = @email, senha = @senha, telefone = @telefone, estado = @estado, cidade = @cidade, endereco = @endereco, cep = @cep, foto = @foto where idFuncionario ='" + txtID.Text + "'");
                    cmd.Parameters.Add("@nome", SqlDbType.NVarChar, 50).Value = txtNome.Text;
                    cmd.Parameters.Add("@email", SqlDbType.NVarChar, 40).Value = txtEmail.Text;
                    cmd.Parameters.Add("@senha", SqlDbType.NVarChar, 40).Value = txtSenha.Text;
                    cmd.Parameters.Add("@telefone", SqlDbType.NVarChar, 30).Value = txtFone.Text;
                    cmd.Parameters.Add("@estado", SqlDbType.NVarChar, 40).Value = cbEstado.Text;
                    cmd.Parameters.Add("@cidade", SqlDbType.NVarChar, 40).Value = txtCidade.Text;
                    cmd.Parameters.Add("@endereco", SqlDbType.NVarChar, 90).Value = txtEndereco.Text;
                    cmd.Parameters.Add("@cep", SqlDbType.NVarChar, 40).Value = txtCep.Text;
                    cmd.Parameters.Add("@foto", SqlDbType.VarBinary, imagem.Length).Value = imagem;

                    int x = con.manutencaoDB_Parametros(cmd);
                    if (x > 0)
                    {
                        MessageBox.Show("Registro alterado com sucesso");
                    }
                    else
                    {
                        MessageBox.Show("Falha ao alterar");
                    }
                }
                else if (imgAnt != null)
                {
                    SqlCommand cmd = new SqlCommand("Update tblFuncionario set nome = @nome, email = @email, senha = @senha, telefone = @telefone, estado = @estado, cidade = @cidade, endereco = @endereco, cep = @cep, foto = @foto where idFuncionario ='" + txtID.Text + "'");
                    cmd.Parameters.Add("@nome", SqlDbType.NVarChar, 50).Value = txtNome.Text;
                    cmd.Parameters.Add("@email", SqlDbType.NVarChar, 40).Value = txtEmail.Text;
                    cmd.Parameters.Add("@senha", SqlDbType.NVarChar, 40).Value = txtSenha.Text;
                    cmd.Parameters.Add("@telefone", SqlDbType.NVarChar, 30).Value = txtFone.Text;
                    cmd.Parameters.Add("@estado", SqlDbType.NVarChar, 40).Value = cbEstado.Text;
                    cmd.Parameters.Add("@cidade", SqlDbType.NVarChar, 40).Value = txtCidade.Text;
                    cmd.Parameters.Add("@endereco", SqlDbType.NVarChar, 90).Value = txtEndereco.Text;
                    cmd.Parameters.Add("@cep", SqlDbType.NVarChar, 40).Value = txtCep.Text;
                    cmd.Parameters.Add("@foto", SqlDbType.VarBinary, imgAnt.Length).Value = imgAnt;

                    int x = con.manutencaoDB_Parametros(cmd);
                    if (x > 0)
                    {
                        MessageBox.Show("Registro alterado com sucesso");
                    }
                    else
                    {
                        MessageBox.Show("Falha ao alterar");
                    }
                }
                else
                {
                    MessageBox.Show("Insira uma imagem!");
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos corretamente.");
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
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

        private void txtSenha_Leave(object sender, EventArgs e)
        {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(txtEmail.Text, pattern))
            {
                senhaError.Clear();
            }
            else
            {
                senhaError.SetError(this.txtEmail, "Email inválido. Formato exemplo: username@gmail.com");
                return;
            }
        }

        private void txtCep_Leave(object sender, EventArgs e)
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

        private void txtFone_Leave(object sender, EventArgs e)
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
    }
}
