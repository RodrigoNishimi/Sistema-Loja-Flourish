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
    public partial class frmAltFornecedor : Form
    {
        Classe_Conexao con;
        DataSet ds;
        private string caminhoImagem = null;
        byte[] imgAnt = null;

        public frmAltFornecedor()
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

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            con = new Classe_Conexao();
            ds = new DataSet();

            if (txtID.Text != "")
            {
                ds = con.executa_sql("select * from tblFornecedor where idFornecedor = '" + txtID.Text + "'");

                try
                {
                    txtNome.Text = ds.Tables[0].Rows[0]["nome_Fornecedor"].ToString().Trim();
                    txtFone.Text = ds.Tables[0].Rows[0]["telefone"].ToString().Trim();
                    txtEmail.Text = ds.Tables[0].Rows[0]["email"].ToString().Trim();
                    cbEstado.Text = ds.Tables[0].Rows[0]["estado"].ToString();
                    txtCidade.Text = ds.Tables[0].Rows[0]["cidade"].ToString().Trim();
                    txtEndereco.Text = ds.Tables[0].Rows[0]["endereco"].ToString().Trim();
                    txtCep.Text = ds.Tables[0].Rows[0]["cep"].ToString().Trim();
                    txtDataNasc.Text = ds.Tables[0].Rows[0]["data_Nasc"].ToString();
                    txtCpf.Text = ds.Tables[0].Rows[0]["cpf"].ToString().Trim();
                    cbSexo.Text = ds.Tables[0].Rows[0]["sexo"].ToString();
                }
                catch
                { MessageBox.Show("Erro. Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

                try
                {
                    imgAnt = (Byte[])(ds.Tables[0].Rows[0]["foto"]);
                    pbFoto.Image = Image.FromStream(new MemoryStream(imgAnt));
                }
                catch { { pbFoto.Image = null; MessageBox.Show("Registro sem imagem!"); } }
            }
            else if (txtNome.Text != "")
            {
                ds = con.executa_sql("select * from tblFornecedor where nome_Fornecedor = '" + txtNome.Text + "'");

                try
                {
                    txtID.Text = ds.Tables[0].Rows[0]["idFornecedor"].ToString().Trim();
                    txtFone.Text = ds.Tables[0].Rows[0]["telefone"].ToString().Trim();
                    txtEmail.Text = ds.Tables[0].Rows[0]["email"].ToString().Trim();
                    cbEstado.Text = ds.Tables[0].Rows[0]["estado"].ToString();
                    txtCidade.Text = ds.Tables[0].Rows[0]["cidade"].ToString().Trim();
                    txtEndereco.Text = ds.Tables[0].Rows[0]["endereco"].ToString().Trim();
                    txtCep.Text = ds.Tables[0].Rows[0]["cep"].ToString().Trim();
                    txtDataNasc.Text = ds.Tables[0].Rows[0]["data_Nasc"].ToString();
                    txtCpf.Text = ds.Tables[0].Rows[0]["cpf"].ToString().Trim();
                    cbSexo.Text = ds.Tables[0].Rows[0]["sexo"].ToString();
                }
                catch
                { MessageBox.Show("Erro. Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

                try
                {
                    imgAnt = (Byte[])(ds.Tables[0].Rows[0]["foto"]);
                    pbFoto.Image = Image.FromStream(new MemoryStream(imgAnt));
                }
                catch { { pbFoto.Image = null; MessageBox.Show("Registro sem imagem!"); } }
            }
            else { MessageBox.Show("Insira um Nome ou ID"); }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            con = new Classe_Conexao();
            byte[] imagem = ImgToByte(caminhoImagem);
            string emailPattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            string cepPattern = "^\\d{5}-\\d{3}$";
            string cpfPattern = "^\\d{3}\\.\\d{3}\\.\\d{3}-\\d{2}$";
            string fonePattern = "\\(\\d{2,}\\) \\d{4,}\\-\\d{4}";
            DateTime Temp;

            //SqlCommand cmd = new SqlCommand("Exec AlterarFornecedor'" + txtID.Text + "','" + txtNome.Text + "','" + txtFone.Text + "','" + txtEmail.Text + "','" + cbEstado.Text + "','" + txtCidade.Text + "','" + txtEndereco.Text + "','" + txtCep.Text + "','" + txtDataNasc.Text + "','" + txtCpf.Text + "','" + cbSexo.Text + "' ");

            if (Regex.IsMatch(txtCep.Text, cepPattern) && Regex.IsMatch(txtCpf.Text, cpfPattern) && Regex.IsMatch(txtFone.Text, fonePattern) && Regex.IsMatch(txtEmail.Text, emailPattern) && DateTime.TryParse(txtDataNasc.Text, out Temp) == true && Temp.Year > 1941 && Temp > DateTime.MinValue && Temp.Year < 2003)
            {
                if (imagem != null)
                {
                    SqlCommand cmd = new SqlCommand("Update tblFornecedor set nome_Fornecedor = @nome_Fornecedor, telefone = @telefone, email = @email, estado = @estado, cidade = @cidade, endereco = @endereco, cep = @cep, data_Nasc = @data_Nasc, cpf = @cpf, sexo = @sexo, foto = @foto where idFornecedor ='" + txtID.Text + "'");
                    cmd.Parameters.Add("@nome_Fornecedor", SqlDbType.NVarChar, 40).Value = txtNome.Text;
                    cmd.Parameters.Add("@telefone", SqlDbType.NVarChar, 40).Value = txtFone.Text;
                    cmd.Parameters.Add("@email", SqlDbType.NVarChar, 40).Value = txtEmail.Text;
                    cmd.Parameters.Add("@estado", SqlDbType.NVarChar, 20).Value = cbEstado.Text;
                    cmd.Parameters.Add("@cidade", SqlDbType.NVarChar, 30).Value = txtCidade.Text;
                    cmd.Parameters.Add("@endereco", SqlDbType.NVarChar, 50).Value = txtEndereco.Text;
                    cmd.Parameters.Add("@cep", SqlDbType.NVarChar, 30).Value = txtCep.Text;
                    cmd.Parameters.Add("@data_Nasc", SqlDbType.Date).Value = txtDataNasc.Text;
                    cmd.Parameters.Add("@cpf", SqlDbType.NVarChar, 30).Value = txtCpf.Text;
                    cmd.Parameters.Add("@sexo", SqlDbType.NVarChar, 20).Value = cbSexo.Text;
                    cmd.Parameters.Add("@foto", SqlDbType.VarBinary, imagem.Length).Value = imagem;

                    int x = con.manutencaoDB_Parametros(cmd);
                    if (x > 0)
                    {
                        MessageBox.Show("Registro alterado com sucesso");
                        txtID.Text = "";
                        txtNome.Text = "";
                        txtFone.Text = "";
                        txtEmail.Text = "";
                        cbEstado.Text = "";
                        txtCidade.Text = "";
                        txtEndereco.Text = "";
                        txtCep.Text = "";
                        txtDataNasc.Text = "";
                        txtCpf.Text = "";
                        cbSexo.Text = "";
                        pbFoto.Image = null;
                    }
                    else
                    {
                        MessageBox.Show("Falha ao alterar");
                    }
                }
                else if (imgAnt != null)
                {
                    SqlCommand cmd = new SqlCommand("Update tblFornecedor set nome_Fornecedor = @nome_Fornecedor, telefone = @telefone, email = @email, estado = @estado, cidade = @cidade, endereco = @endereco, cep = @cep, data_Nasc = @data_Nasc, cpf = @cpf, sexo = @sexo, foto = @foto where idFornecedor ='" + txtID.Text + "'");
                    cmd.Parameters.Add("@nome_Fornecedor", SqlDbType.NVarChar, 40).Value = txtNome.Text;
                    cmd.Parameters.Add("@telefone", SqlDbType.NVarChar, 40).Value = txtFone.Text;
                    cmd.Parameters.Add("@email", SqlDbType.NVarChar, 40).Value = txtEmail.Text;
                    cmd.Parameters.Add("@estado", SqlDbType.NVarChar, 20).Value = cbEstado.Text;
                    cmd.Parameters.Add("@cidade", SqlDbType.NVarChar, 30).Value = txtCidade.Text;
                    cmd.Parameters.Add("@endereco", SqlDbType.NVarChar, 50).Value = txtEndereco.Text;
                    cmd.Parameters.Add("@cep", SqlDbType.NVarChar, 30).Value = txtCep.Text;
                    cmd.Parameters.Add("@data_Nasc", SqlDbType.Date).Value = txtDataNasc.Text;
                    cmd.Parameters.Add("@cpf", SqlDbType.NVarChar, 30).Value = txtCpf.Text;
                    cmd.Parameters.Add("@sexo", SqlDbType.NVarChar, 20).Value = cbSexo.Text;
                    cmd.Parameters.Add("@foto", SqlDbType.VarBinary, imgAnt.Length).Value = imgAnt;

                    int x = con.manutencaoDB_Parametros(cmd);
                    if (x > 0)
                    {
                        MessageBox.Show("Registro alterado com sucesso");
                        txtID.Text = "";
                        txtNome.Text = "";
                        txtFone.Text = "";
                        txtEmail.Text = "";
                        cbEstado.Text = "";
                        txtCidade.Text = "";
                        txtEndereco.Text = "";
                        txtCep.Text = "";
                        txtDataNasc.Text = "";
                        txtCpf.Text = "";
                        cbSexo.Text = "";
                        pbFoto.Image = null;
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            con = new Classe_Conexao();

            SqlCommand cmd = new SqlCommand("Exec ExcluirFornecedor '" + txtID.Text + "' ");

            int x = con.manutencaoDB_Parametros(cmd);
            if (x > 0)
            {
                MessageBox.Show("Registro excluído com sucesso");
                txtID.Text = "";
                txtNome.Text = "";
                txtFone.Text = "";
                txtEmail.Text = "";
                cbEstado.Text = "";
                txtCidade.Text = "";
                txtEndereco.Text = "";
                txtCep.Text = "";
                txtDataNasc.Text = "";
                txtCpf.Text = "";
                cbSexo.Text = "";
                pbFoto.Image = null;
            }
            else
            {
                MessageBox.Show("Falha ao excluir");
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtNome.Text = "";
            txtFone.Text = "";
            txtEmail.Text = "";
            cbEstado.Text = "";
            txtCidade.Text = "";
            txtEndereco.Text = "";
            txtCep.Text = "";
            txtDataNasc.Text = "";
            txtCpf.Text = "";
            cbSexo.Text = "";
            pbFoto.Image = null;
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
    }
}
