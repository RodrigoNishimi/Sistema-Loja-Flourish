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

namespace PrjLoja
{
    public partial class frmConsultaPedidos : Form
    {
        private string strConexao = "DataBase = DB_SeedCode; Integrated Security = true; Data Source = " + Environment.MachineName + "\\SQLExpress";
        SqlCommand Command = null;
        SqlConnection Connect = null;

        public frmConsultaPedidos()
        {
            InitializeComponent();
        }

        private void frmConsultaPedidos_Load(object sender, EventArgs e)
        {
            string strSQL = "select * from tblPedido";

            Connect = new SqlConnection(strConexao);
            Command = new SqlCommand(strSQL, Connect);

            try
            {
                SqlDataAdapter objAdp = new SqlDataAdapter(Command);
                DataTable dtLista = new DataTable();
                objAdp.Fill(dtLista);

                dgvFunc.DataSource = dtLista;
            }
            catch
            {
                MessageBox.Show("Erro", "Atenção",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

            private void btnOrdenar_Click(object sender, EventArgs e)
        {
            string strSQL = "select * from tblPedido order by '" + cbOrder.Text + "'";

            Connect = new SqlConnection(strConexao);
            Command = new SqlCommand(strSQL, Connect);


            if (cbOrder.Text != "")
            {
                try
                {
                    SqlDataAdapter objAdp = new SqlDataAdapter(Command);
                    DataTable dtLista = new DataTable();
                    objAdp.Fill(dtLista);

                    dgvFunc.DataSource = dtLista;
                }
                catch
                {
                    MessageBox.Show("Erro", "Atenção",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                Command = new SqlCommand("select * from tblPedido", Connect);
                SqlDataAdapter objAdp = new SqlDataAdapter(Command);
                DataTable dtLista = new DataTable();
                objAdp.Fill(dtLista);

                dgvFunc.DataSource = dtLista;
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string strSQL = "select * from tblPedido where " + cbFiltro.Text + " = '" + txtFiltro.Text + "' ";

            Connect = new SqlConnection(strConexao);
            Command = new SqlCommand(strSQL, Connect);

            if (cbFiltro.Text != "" && txtFiltro.Text != "")
            {
                try
                {
                    SqlDataAdapter objAdp = new SqlDataAdapter(Command);
                    DataTable dtLista = new DataTable();
                    objAdp.Fill(dtLista);

                    dgvFunc.DataSource = dtLista;
                }
                catch
                {
                    MessageBox.Show("Erro", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Erro! Um ou mais campos em branco!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            string strSQL = "select * from tblPedido";

            Connect = new SqlConnection(strConexao);
            Command = new SqlCommand(strSQL, Connect);

            try
            {
                SqlDataAdapter objAdp = new SqlDataAdapter(Command);
                DataTable dtLista = new DataTable();
                objAdp.Fill(dtLista);

                dgvFunc.DataSource = dtLista;
            }
            catch
            {
                MessageBox.Show("Erro", "Atenção",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        
    }
}