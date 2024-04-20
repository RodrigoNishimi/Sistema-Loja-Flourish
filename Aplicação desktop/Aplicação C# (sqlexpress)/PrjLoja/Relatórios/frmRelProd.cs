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
using System.Collections;
using System.Globalization;
using LiveCharts.Wpf;
using LiveCharts;
using System.IO;

namespace PrjLoja
{
    public partial class frmRelProd : Form
    {
        SqlConnection Conexao = new SqlConnection("DataBase=DB_SeedCode;Integrated Security=true;Data Source=" + Environment.MachineName + "\\SQLExpress");
        SqlCommand cmd;
        SqlDataReader dr;

        public frmRelProd()
        {
            InitializeComponent();
        }

        private void frmRelProd_Load(object sender, EventArgs e)
        {
            CatDestaque();
            ProdDestaque();
            Dados();
        }

        ArrayList Cat = new ArrayList();
        ArrayList Vendas = new ArrayList();
        List<string> Prod = new List<string>();
        List<decimal> Qtde = new List<decimal>();
        List<Byte[]> img = new List<byte[]>();

        private void CatDestaque()
        {
            try
            {
                cmd = new SqlCommand("VendasCategoria", Conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                Conexao.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Cat.Add(dr.GetString(0));
                    Vendas.Add(dr.GetDecimal(1));
                }
                chartProdPref.Series[0].Points.DataBindXY(Cat, Vendas);
                dr.Close();
                Conexao.Close();
            }
            catch
            {
                MessageBox.Show("Erro ao carregar os dados");
            }
        }

        private void ProdDestaque()
        {
            try
            {
                cmd = new SqlCommand("ProdPreferidos", Conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                Conexao.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Prod.Add(dr.GetString(0));
                    Qtde.Add(dr.GetInt32(1));
                    img.Add((Byte[])(dr.GetSqlBinary(2)));
                }
                lblProd1.Text = Prod[0];
                lblProd2.Text = Prod[1];
                lblProd3.Text = Prod[2];
                lblProd4.Text = Prod[3];

                pbProd1.Image = Image.FromStream(new MemoryStream(img[0]));
                pbProd2.Image = Image.FromStream(new MemoryStream(img[1]));
                pbProd3.Image = Image.FromStream(new MemoryStream(img[2]));
                pbProd4.Image = Image.FromStream(new MemoryStream(img[3]));
                dr.Close();
                Conexao.Close();
            }
            catch
            {
                MessageBox.Show("Erro ao carregar os dados");
            }
        }

        private void Dados()
        {
            try
            {
                cmd = new SqlCommand("Dados", Conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter vendas = new SqlParameter("@totVendas", 0); vendas.Direction = ParameterDirection.Output;
                SqlParameter clientes = new SqlParameter("@nClientes", 0); clientes.Direction = ParameterDirection.Output;
                SqlParameter produtos = new SqlParameter("@nProd", 0); produtos.Direction = ParameterDirection.Output;
                SqlParameter marcas = new SqlParameter("@nMarcas", 0); marcas.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(vendas);
                cmd.Parameters.Add(clientes);
                cmd.Parameters.Add(produtos);
                cmd.Parameters.Add(marcas);
                Conexao.Open();
                cmd.ExecuteNonQuery();
                lblNProd.Text = cmd.Parameters["@nProd"].Value.ToString();
                lblNMarcas.Text = cmd.Parameters["@nMarcas"].Value.ToString();
                Conexao.Close();
            }
            catch
            {
                MessageBox.Show("Erro ao carregar os dados");
            } 
        }
    }
}
