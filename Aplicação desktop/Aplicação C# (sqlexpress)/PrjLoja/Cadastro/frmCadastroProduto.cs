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

namespace PrjLoja
{
    public partial class frmCadastroProduto : Form
    {
        Classe_Conexao con;
        private string caminhoImagem = null;

        public frmCadastroProduto()
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            con = new Classe_Conexao();
            byte[] imagem = ImgToByte(caminhoImagem);
            int IdCatProd = 0, IdCatLoja = 0;

            if (cbCatLoja.Text == "Lançamento")
                IdCatLoja = 1;
            else if(cbCatLoja.Text == "Popular")
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


            // SqlCommand cmd = new SqlCommand("Exec CadastrarProduto '" + txtIdFornecedor.Text + "' , '" + txtIdFunc.Text + "' , '" + txtIdCatProd.Text + "' , '" + txtNome.Text + "' , '" + txtDesc.Text + "' , '" + txtPreco.Text + "' , '" + txtQtde.Text + "' , '" + txtTamanho.Text + "' , '" + txtMarca.Text + "' ");

            if (imagem != null)
            {
                SqlCommand cmd = new SqlCommand("insert into tblProduto(idFornecedor, idFuncionario, idCat_Produto, idCat_Loja, nome_produto, desc_Produto, preco_Produto, Quant_Produto, tamanho, marca, nivel_cuidado, ambiente, tipo, seguro, imagem)values(@idFornecedor, @idFuncionario, @idCat_Produto, @idCat_Loja, @nome_produto, @desc_Produto, @preco_Produto, @Quant_Produto, @tamanho, @marca, @nivel_cuidado, @ambiente, @tipo, @seguro, @imagem)");
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
                cmd.Parameters.Add("@imagem", SqlDbType.VarBinary, imagem.Length).Value = imagem;

                int x = con.manutencaoDB_Parametros(cmd);
                if (x > 0)
                {
                    MessageBox.Show("Registro cadastrado com sucesso", "Sucesso");
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
                    MessageBox.Show("Falha ao cadastrar");
                }
            }
            else
            {
                MessageBox.Show("Insira uma imagem!");
            }
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

        private void panel1_Click(object sender, EventArgs e)
        {
            txtIdFornecedor.Text = "2";
            txtIdFunc.Text = "2";
            cbIdCatProd.Text = "Plantas";
            txtNome.Text = "Philodendron";
            txtDesc.Text = "Se suas folhas ficarem amarelas em vez de laranja, ele está recebendo muito sol. Se eles ficarem verdes imediatamente, ele está recebendo muito pouca luz";
            txtPreco.Text = "28,56";
            txtQtde.Text = "35";
            txtTamanho.Text = "Mediano";
            txtMarca.Text = "Flourish";
            cbAmbiente.Text = "Sol e Sombra";
            cbCatLoja.Text = "Popular";
            cbCuidado.Text = "Fácil";
            cbSeguro.Text = "Sim";
            cbTipo.Text = "Básico";
        }
    }
}
