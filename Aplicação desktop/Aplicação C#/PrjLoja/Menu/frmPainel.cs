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
    public partial class frmPainel : Form
    {
        SqlConnection Conexao = new SqlConnection("DataBase=DB_SeedCode;Integrated Security=true;Data Source=" + Environment.MachineName);
        SqlCommand cmd;
        SqlDataReader dr;

        public frmPainel()
        {
            InitializeComponent();
        }

        private void frmPainel_Load(object sender, EventArgs e)
        {
            VendaMensal();
            Dados();
        }

        /* ArrayList Ano = new ArrayList();
        ArrayList Mes = new ArrayList();
        ArrayList Vendas = new ArrayList(); */

        public static string MonthName(int num)
        {
            DateTimeFormatInfo dtfi = CultureInfo.GetCultureInfo("pt-BR").DateTimeFormat;
            return dtfi.GetMonthName(num);
        }

        /*private void VendaMensal()
        {
            cmd = new SqlCommand("VendaMensal", Conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            Conexao.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Ano.Add(dr.GetInt32(0));
                Mes.Add(MonthName(dr.GetInt32(1)));
                Vendas.Add(dr.GetDecimal(2));
            }
            chartVendasMensais.Series[0].Points.DataBindXY(Mes, Vendas);
            dr.Close();
            Conexao.Close();
        }*/

        List<int> ano = new List<int>();
        List<string> Mes = new List<string>();
        List<decimal> Vendas = new List<decimal>();

        private void VendaMensal()
        {
            chartVendasMensais.Series.Clear();
            //chartVendasMensais.LegendLocation = LiveCharts.LegendLocation.Right;
            cmd = new SqlCommand("VendaMensal", Conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            Conexao.Open();
            dr = cmd.ExecuteReader();
            LineSeries col = new LineSeries() { DataLabels = true ,Values = new ChartValues<decimal>(), LabelPoint = point => point.Y.ToString() };
            Axis ax = new Axis() { Separator = new Separator() { Step = 1, IsEnabled = false } };
            ax.Labels = new List<string>();
            while (dr.Read())
            {
                ano.Add(dr.GetInt32(0));
                ax.Labels.Add(MonthName(dr.GetInt32(1)));
                col.Values.Add(dr.GetDecimal(2));
            }
            chartVendasMensais.Series.Add(col);
            chartVendasMensais.AxisX.Add(ax);
            chartVendasMensais.AxisY.Add(new Axis
            {
                LabelFormatter = value => value.ToString("C"),
                Separator = new Separator()
            });

            dr.Close();
            Conexao.Close();
        }

    private void Dados()
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
            lblVendas.Text =cmd.Parameters["@totVendas"].Value.ToString();
            lblNClientes.Text = cmd.Parameters["@nClientes"].Value.ToString();
            lblNProd.Text = cmd.Parameters["@nProd"].Value.ToString();
            lblNMarcas.Text = cmd.Parameters["@nMarcas"].Value.ToString();
            Conexao.Close();
        }
    }
}
