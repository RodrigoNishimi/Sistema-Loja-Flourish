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

namespace PrjLoja
{
    public partial class frmRelVendas : Form
    {
        SqlConnection Conexao = new SqlConnection("DataBase=DB_SeedCode;Integrated Security=true;Data Source=" + Environment.MachineName);
        SqlCommand cmd;
        SqlDataReader dr;

        public frmRelVendas()
        {
            InitializeComponent();
        }

        private void frmRelVendas_Load(object sender, EventArgs e)
        {
            VendaMensal();
            VendaAnual();
            Dados();
        }
        public static string MonthName(int num)
        {
            DateTimeFormatInfo dtfi = CultureInfo.GetCultureInfo("pt-BR").DateTimeFormat;
            return dtfi.GetMonthName(num);
        }

        private void VendaMensal()
        {
            try
            {
                cmd = new SqlCommand("VendaMensal", Conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                Conexao.Open();
                dr = cmd.ExecuteReader();

                LineSeries col = new LineSeries() { DataLabels = true, Values = new ChartValues<decimal>(), LabelPoint = point => point.Y.ToString() };
                Axis ax = new Axis() { Separator = new Separator() { Step = 1, IsEnabled = false } };
                ax.Labels = new List<string>();
                while (dr.Read())
                {
                    col.Values.Add(dr.GetDecimal(2));
                    ax.Labels.Add(MonthName(dr.GetInt32(1)));
                }
                chartVendasMensais.Series.Add(col);
                chartVendasMensais.AxisX.Add(ax);
                chartVendasMensais.AxisY.Add(new Axis
                {
                    LabelFormatter = value => value.ToString(),
                    Separator = new Separator()
                });

                dr.Close();
                Conexao.Close();
            }
            catch
            {
                MessageBox.Show("Erro ao carregar os dados");
            }
        }

        List<string> Ano = new List<string>();
        ArrayList Vendas = new ArrayList();

        private void VendaAnual()
        {
            try
            {
                cmd = new SqlCommand("VendaAnual", Conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                Conexao.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Ano.Add(dr.GetInt32(0).ToString());
                    Vendas.Add(dr.GetDecimal(1));
                }
                chartVendaAnual.Series[0].Points.DataBindXY(Ano, Vendas);
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
                lblVendas.Text = cmd.Parameters["@totVendas"].Value.ToString();
                Conexao.Close();
            }
            catch
            {
                MessageBox.Show("Erro ao carregar os dados");
            }
            
        }
    }
}
