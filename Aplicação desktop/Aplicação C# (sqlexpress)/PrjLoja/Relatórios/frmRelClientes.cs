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
    public partial class frmRelClientes : Form
    {
        SqlConnection Conexao = new SqlConnection("DataBase=DB_SeedCode;Integrated Security=true;Data Source=" + Environment.MachineName + "\\SQLExpress");
        SqlCommand cmd;
        SqlDataReader dr;

        public frmRelClientes()
        {
            InitializeComponent();
        }

        private void frmRelClientes_Load(object sender, EventArgs e)
        {
            ClientesMes();
            Dados();
            NPedidos();
        }

        public static string MonthName(int num)
        {
            DateTimeFormatInfo dtfi = CultureInfo.GetCultureInfo("pt-BR").DateTimeFormat;
            return dtfi.GetMonthName(num);
        }

        private void ClientesMes()
        {
            try
            {
                cmd = new SqlCommand("NumeroClientesMensal", Conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                Conexao.Open();
                dr = cmd.ExecuteReader();

                LineSeries col = new LineSeries() { DataLabels = true, Values = new ChartValues<int>(), LabelPoint = point => point.Y.ToString() };
                Axis ax = new Axis() { Separator = new Separator() { Step = 1, IsEnabled = false } };
                ax.Labels = new List<string>();
                while (dr.Read())
                {
                    col.Values.Add(dr.GetInt32(2));
                    ax.Labels.Add(MonthName(dr.GetInt32(1)));
                }
                chartClientesMes.Series.Add(col);
                chartClientesMes.AxisX.Add(ax);
                chartClientesMes.AxisY.Add(new Axis
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
                lblNClientes.Text = cmd.Parameters["@nClientes"].Value.ToString();
                Conexao.Close();
            }
            catch
            {
                MessageBox.Show("Erro ao carregar os dados");
            }
        }

        private void NPedidos()
        {
            try
            {
                cmd = new SqlCommand("NPedidos", Conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter pedidos = new SqlParameter("@nPedidos", 0); pedidos.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pedidos);
                Conexao.Open();
                cmd.ExecuteNonQuery();
                lblNPed.Text = cmd.Parameters["@nPedidos"].Value.ToString();
                Conexao.Close();
            }
            catch
            {
                MessageBox.Show("Erro ao carregar os dados");
            }
        }
    }
}
