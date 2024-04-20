using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PrjLoja
{
    public partial class frmAltProd : Form
    {
        Classe_Conexao con;
        DataSet ds;
        private string caminhoImagem = null;
        byte[] imgAnt = null;

        public frmAltProd()
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

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofl = new OpenFileDialog();
            ofl.Title = "Adicionar Imagem";
            ofl.Filter = "All files (*.*)|*.*";
            if (ofl.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pbImg.Image = new Bitmap(ofl.OpenFile());
                    caminhoImagem = ofl.FileName;
                }
                catch (Exception)
                {
                    MessageBox.Show("Falha ao carregar a imagem");
                }
            }
            ofl.Dispose();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            con = new Classe_Conexao();
            byte[] imagem = ImgToByte(caminhoImagem);

            int IdCatProd = 0, IdCatLoja = 0;

            if (cbCatLoja.Text == "Lançamento")
                IdCatLoja = 1;
            else if (cbCatLoja.Text == "Popular")
                IdCatLoja = 2;
            else
                IdCatLoja = 3;

            if (cbIdCatProd.Text == "Plantas")
                IdCatProd = 1;
            else if (cbIdCatProd.Text == "Ferramentas")
                IdCatProd = 2;
            else if (cbIdCatProd.Text == "Vasos")
                IdCatProd = 3;
            else if (cbIdCatProd.Text == "Solo")
                IdCatProd = 4;
            else
                IdCatProd = 5;

            //SqlCommand cmd = new SqlCommand("Exec AlterarProduto'" + txtID.Text + "','" + txtIdFornecedor.Text + "','" + txtIdFunc.Text + "','" + txtIdCatProd.Text + "', '" + txtNome.Text + "','" + txtDesc.Text + "','" + txtPreco.Text + "','" + txtQtde.Text + "','" + txtTamanho.Text + "','" + txtMarca.Text + "'");

            if (imagem != null)
            {
                SqlCommand cmd = new SqlCommand("update tblProduto set idFornecedor = @idFornecedor, idFuncionario = @idFuncionario, idCat_Produto = @idCat_Produto, idCat_Loja = @idCat_Loja, nome_produto = @nome_produto, desc_Produto = @desc_Produto, preco_Produto = @preco_Produto, Quant_Produto = @Quant_Produto, tamanho = @tamanho, marca = @marca, nivel_cuidado = @nivel_cuidado, ambiente = @ambiente, tipo = @tipo, seguro = @seguro, imagem = @imagem where idProduto ='" + txtID.Text + "'");
                cmd.Parameters.Add("@idFornecedor", SqlDbType.Int).Value = txtIdFornecedor.Text;
                cmd.Parameters.Add("@idFuncionario", SqlDbType.Int).Value = txtIdFunc.Text;
                cmd.Parameters.Add("@idCat_Produto", SqlDbType.Int).Value = IdCatProd;
                cmd.Parameters.Add("@idCat_Loja", SqlDbType.Int).Value = IdCatLoja;
                cmd.Parameters.Add("@nome_produto", SqlDbType.NVarChar, 45).Value = txtNome.Text;
                cmd.Parameters.Add("@desc_Produto", SqlDbType.NVarChar, 255).Value = txtDesc.Text;
                cmd.Parameters.Add(new SqlParameter("@preco_Produto", SqlDbType.Decimal) { Precision = 10, Scale = 2 }).Value = txtPreco.Text.Replace(".", ",");
                cmd.Parameters.Add("@Quant_Produto", SqlDbType.Int).Value = txtQtde.Text;
                cmd.Parameters.Add("@tamanho", SqlDbType.NVarChar, 45).Value = txtTamanho.Text;
                cmd.Parameters.Add("@marca", SqlDbType.NVarChar, 45).Value = txtMarca.Text;
                cmd.Parameters.Add("@nivel_cuidado", SqlDbType.NVarChar, 255).Value = cbCuidado.Text;
                cmd.Parameters.Add("@ambiente", SqlDbType.NVarChar, 255).Value = cbAmbiente.Text;
                cmd.Parameters.Add("@tipo", SqlDbType.NVarChar, 255).Value = cbTipo.Text;
                cmd.Parameters.Add("@seguro", SqlDbType.NVarChar, 255).Value = cbSeguro.Text;
                cmd.Parameters.Add("@imagem", SqlDbType.VarBinary, imagem.Length).Value = imagem;

                int x = con.manutencaoDB_Parametros(cmd);
                if (x > 0)
                {
                    MessageBox.Show("Registro alterado com sucesso");
                    txtID.Text = "";
                    txtIdFornecedor.Text = "";
                    txtIdFunc.Text = "";
                    cbIdCatProd.Text = "";
                    txtNome.Text = "";
                    txtDesc.Text = "";
                    txtPreco.Text = "";
                    txtQtde.Text = "";
                    txtTamanho.Text = "";
                    txtMarca.Text = "";
                    cbAmbiente.Text = "";
                    cbCatLoja.Text = "";
                    cbCuidado.Text = "";
                    cbSeguro.Text = "";
                    cbTipo.Text = "";
                    pbImg.Image = null;
                }
                else
                {
                    MessageBox.Show("Falha ao alterar");
                }
            }
            else if (imgAnt != null)
            {
                SqlCommand cmd = new SqlCommand("update tblProduto set idFornecedor = @idFornecedor, idFuncionario = @idFuncionario, idCat_Produto = @idCat_Produto, idCat_Loja = @idCat_Loja, nome_produto = @nome_produto, desc_Produto = @desc_Produto, preco_Produto = @preco_Produto, Quant_Produto = @Quant_Produto, tamanho = @tamanho, marca = @marca, nivel_cuidado = @nivel_cuidado, ambiente = @ambiente, tipo = @tipo, seguro = @seguro, imagem = @imagem where idProduto ='" + txtID.Text + "'");
                cmd.Parameters.Add("@idFornecedor", SqlDbType.Int).Value = txtIdFornecedor.Text;
                cmd.Parameters.Add("@idFuncionario", SqlDbType.Int).Value = txtIdFunc.Text;
                cmd.Parameters.Add("@idCat_Produto", SqlDbType.Int).Value = IdCatProd;
                cmd.Parameters.Add("@nome_produto", SqlDbType.NVarChar, 45).Value = txtNome.Text;
                cmd.Parameters.Add("@desc_Produto", SqlDbType.NVarChar, 255).Value = txtDesc.Text;
                cmd.Parameters.Add(new SqlParameter("@preco_Produto", SqlDbType.Decimal) { Precision = 10, Scale = 2 }).Value = txtPreco.Text.Replace(".", ",");
                cmd.Parameters.Add("@Quant_Produto", SqlDbType.Int).Value = txtQtde.Text;
                cmd.Parameters.Add("@tamanho", SqlDbType.NVarChar, 45).Value = txtTamanho.Text;
                cmd.Parameters.Add("@marca", SqlDbType.NVarChar, 45).Value = txtMarca.Text;
                cmd.Parameters.Add("@idCat_Loja", SqlDbType.Int).Value = IdCatLoja;
                cmd.Parameters.Add("@nivel_cuidado", SqlDbType.NVarChar, 255).Value = cbCuidado.Text;
                cmd.Parameters.Add("@ambiente", SqlDbType.NVarChar, 255).Value = cbAmbiente.Text;
                cmd.Parameters.Add("@tipo", SqlDbType.NVarChar, 255).Value = cbTipo.Text;
                cmd.Parameters.Add("@seguro", SqlDbType.NVarChar, 255).Value = cbSeguro.Text;
                cmd.Parameters.Add("@imagem", SqlDbType.VarBinary, imgAnt.Length).Value = imgAnt;

                int x = con.manutencaoDB_Parametros(cmd);
                if (x > 0)
                {
                    MessageBox.Show("Registro alterado com sucesso");
                    txtID.Text = "";
                    txtIdFornecedor.Text = "";
                    txtIdFunc.Text = "";
                    cbIdCatProd.Text = "";
                    txtNome.Text = "";
                    txtDesc.Text = "";
                    txtPreco.Text = "";
                    txtQtde.Text = "";
                    txtTamanho.Text = "";
                    txtMarca.Text = "";
                    cbAmbiente.Text = "";
                    cbCatLoja.Text = "";
                    cbCuidado.Text = "";
                    cbSeguro.Text = "";
                    cbTipo.Text = "";
                    pbImg.Image = null;
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            con = new Classe_Conexao();

            SqlCommand cmd = new SqlCommand("Exec ExcluirProduto '" + txtID.Text + "' ");

            int x = con.manutencaoDB_Parametros(cmd);
            if (x > 0)
            {
                MessageBox.Show("Registro excluído com sucesso");
                txtID.Text = "";
                txtIdFornecedor.Text = "";
                txtIdFunc.Text = "";
                cbIdCatProd.Text = "";
                txtNome.Text = "";
                txtDesc.Text = "";
                txtPreco.Text = "";
                txtQtde.Text = "";
                txtTamanho.Text = "";
                txtMarca.Text = "";
                cbAmbiente.Text = "";
                cbCatLoja.Text = "";
                cbCuidado.Text = "";
                cbSeguro.Text = "";
                cbTipo.Text = "";
                pbImg.Image = null;
            }
            else
            {
                MessageBox.Show("Falha ao excluir");
            }
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            con = new Classe_Conexao();
            ds = new DataSet();

            if (txtID.Text != "")
            {
                ds = con.executa_sql("select * from tblProduto where idProduto = '" + txtID.Text + "'");

                try
                {
                    int IdCatProd =  Convert.ToInt32(ds.Tables[0].Rows[0]["idCat_Produto"]);
                    int IdCatLoja = Convert.ToInt32(ds.Tables[0].Rows[0]["idCat_Loja"]);

                    if (IdCatLoja == 1)
                        cbCatLoja.Text = "Lançamento";
                    else if (IdCatLoja == 2 )
                        cbCatLoja.Text = "Popular";
                    else
                        cbCatLoja.Text = "Inovador";

                    if (IdCatProd == 1)
                        cbIdCatProd.Text = "Plantas";
                    else if (IdCatProd == 2)
                        cbIdCatProd.Text = "Ferramentas";
                    else if (IdCatProd == 3)
                        cbIdCatProd.Text = "Vasos";
                    else if (IdCatProd == 4)
                        cbIdCatProd.Text = "Solo";
                    else
                        cbIdCatProd.Text = "Sementes";

                    txtIdFornecedor.Text = ds.Tables[0].Rows[0]["idFornecedor"].ToString();
                    txtIdFunc.Text = ds.Tables[0].Rows[0]["idFuncionario"].ToString();
                    txtNome.Text = ds.Tables[0].Rows[0]["nome_produto"].ToString().Trim();
                    txtDesc.Text = ds.Tables[0].Rows[0]["desc_Produto"].ToString().Trim();
                    txtPreco.Text = ds.Tables[0].Rows[0]["preco_Produto"].ToString();
                    txtQtde.Text = ds.Tables[0].Rows[0]["Quant_Produto"].ToString().Trim();
                    txtTamanho.Text = ds.Tables[0].Rows[0]["tamanho"].ToString().Trim();
                    txtMarca.Text = ds.Tables[0].Rows[0]["marca"].ToString().Trim();
                    cbTipo.Text = ds.Tables[0].Rows[0]["tipo"].ToString().Trim();
                    cbAmbiente.Text = ds.Tables[0].Rows[0]["ambiente"].ToString().Trim();
                    cbCuidado.Text = ds.Tables[0].Rows[0]["nivel_cuidado"].ToString().Trim();
                    cbSeguro.Text = ds.Tables[0].Rows[0]["seguro"].ToString().Trim();
                    
                }
                catch
                { MessageBox.Show("Erro. Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

                try
                {
                    imgAnt = (Byte[])(ds.Tables[0].Rows[0]["imagem"]);
                    pbImg.Image = Image.FromStream(new MemoryStream(imgAnt));
                }
                catch { { pbImg.Image = null; MessageBox.Show("Registro sem imagem!"); } }
            }
            else if (txtNome.Text != "")
            {
                ds = con.executa_sql("select * from tblProduto where nome_produto = '" + txtNome.Text + "'");

                try
                {
                    txtID.Text = ds.Tables[0].Rows[0]["idProduto"].ToString();
                    txtIdFornecedor.Text = ds.Tables[0].Rows[0]["idFornecedor"].ToString();
                    txtIdFunc.Text = ds.Tables[0].Rows[0]["idFuncionario"].ToString();
                    cbIdCatProd.Text = ds.Tables[0].Rows[0]["idCat_Produto"].ToString();
                    cbCatLoja.Text = ds.Tables[0].Rows[0]["idCat_Loja"].ToString();
                    txtDesc.Text = ds.Tables[0].Rows[0]["desc_Produto"].ToString().Trim();
                    txtPreco.Text = ds.Tables[0].Rows[0]["preco_Produto"].ToString();
                    txtQtde.Text = ds.Tables[0].Rows[0]["Quant_Produto"].ToString().Trim();
                    txtTamanho.Text = ds.Tables[0].Rows[0]["tamanho"].ToString().Trim();
                    txtMarca.Text = ds.Tables[0].Rows[0]["marca"].ToString().Trim();
                    cbTipo.Text = ds.Tables[0].Rows[0]["tipo"].ToString().Trim();
                    cbAmbiente.Text = ds.Tables[0].Rows[0]["ambiente"].ToString().Trim();
                    cbCuidado.Text = ds.Tables[0].Rows[0]["nivel_cuidado"].ToString().Trim();
                    cbSeguro.Text = ds.Tables[0].Rows[0]["seguro"].ToString().Trim();
                }
                catch
                { MessageBox.Show("Erro. Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

                try
                {
                    imgAnt = (Byte[])(ds.Tables[0].Rows[0]["imagem"]);
                    pbImg.Image = Image.FromStream(new MemoryStream(imgAnt));
                }
                catch { { pbImg.Image = null; MessageBox.Show("Registro sem imagem!"); } }
            }
            else { MessageBox.Show("Insira um Nome ou ID"); }
        }

        private void txtPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            decNumber.DecNumber(sender, e);
        }

        private void txtQtde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtIdFornecedor.Text = "";
            txtIdFunc.Text = "";
            cbIdCatProd.Text = "";
            txtNome.Text = "";
            txtDesc.Text = "";
            txtPreco.Text = "";
            txtQtde.Text = "";
            txtTamanho.Text = "";
            txtMarca.Text = "";
            cbAmbiente.Text = "";
            cbCatLoja.Text = "";
            cbCuidado.Text = "";
            cbSeguro.Text = "";
            cbTipo.Text = "";
            pbImg.Image = null;
        }
    }
}
