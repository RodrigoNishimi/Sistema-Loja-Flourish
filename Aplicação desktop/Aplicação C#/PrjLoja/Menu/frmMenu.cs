using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrjLoja
{
    public partial class frmMenu : Form
    {
        public frmMenu(string texto)
        {
            InitializeComponent();
            txtID.Text = texto;
            subMenu();
            openContentForm(new frmPainel());
        }
        private void subMenu()
        {
            panelCadSubMenu.Visible = false;
            panelAltSubMenu.Visible = false;
            panelConSubMenu.Visible = false;
            panelRelSubMenu.Visible = false;
        }

        private void hideSubMenu()
        {
            if(panelCadSubMenu.Visible == true)
            {panelCadSubMenu.Visible = false;}

            if(panelAltSubMenu.Visible == true)
            {panelAltSubMenu.Visible = false;}

            if(panelConSubMenu.Visible == true)
            {panelConSubMenu.Visible = false;}

            if(panelRelSubMenu.Visible == true)
            {panelRelSubMenu.Visible = false;}
        }

        private void showSubMenu(Panel subMenu)
        {
            if(subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private Form activeForm = null;
        private void openContentForm(Form contentForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = contentForm;
            contentForm.TopLevel = false;
            contentForm.FormBorderStyle = FormBorderStyle.None;
            contentForm.Dock = DockStyle.Fill;
            panelContent.Controls.Add(contentForm);
            panelContent.Tag = contentForm;
            contentForm.BringToFront();
            contentForm.Show();
            lblTitulo.Text = contentForm.Text;
        }

        private void btnPainel_Click(object sender, EventArgs e)
        {
            openContentForm(new frmPainel());
            hideSubMenu();
        }

        #region CadMenu
        private void btnCad_Click(object sender, EventArgs e)
        {
            showSubMenu(panelCadSubMenu);
        }

        private void btnCadProd_Click(object sender, EventArgs e)
        {
            openContentForm(new frmCadastroProduto());
            hideSubMenu();
        }

        private void btnCadFunc_Click(object sender, EventArgs e)
        {
            openContentForm(new frmCadastroFunc());
            hideSubMenu();
        }

        private void btnCadForn_Click(object sender, EventArgs e)
        {
            openContentForm(new frmCadFornecedor());
            hideSubMenu();
        }
        #endregion

        #region AltMenu
        private void btnAlt_Click(object sender, EventArgs e)
        {
            showSubMenu(panelAltSubMenu);
        }

        private void btnAltProd_Click(object sender, EventArgs e)
        {
            openContentForm(new frmAltProd());
            hideSubMenu();
        }

        private void btnAltFunc_Click(object sender, EventArgs e)
        {
            openContentForm(new frmAltFunc());
            hideSubMenu();
        }

        private void btnAltForn_Click(object sender, EventArgs e)
        {
            openContentForm(new frmAltFornecedor());
            hideSubMenu();
        }

        #endregion

        #region ConsMenu
        private void btnCon_Click(object sender, EventArgs e)
        {
            showSubMenu(panelConSubMenu);
        }

        private void btnConProd_Click(object sender, EventArgs e)
        {
            openContentForm(new frmConsultaProd());
            hideSubMenu();
        }

        private void btnConFunc_Click(object sender, EventArgs e)
        {
            openContentForm(new frmConsultaFunc());
            hideSubMenu();
        }

        private void btnConsultaForn_Click(object sender, EventArgs e)
        {
            openContentForm(new frmConsultaFornecedor());
            hideSubMenu();
        }

        private void btnConsultaPedidos_Click(object sender, EventArgs e)
        {
            openContentForm(new frmConsultaPedidos());
            hideSubMenu();
        }
        #endregion

        #region RelMenu
        private void btnRel_Click(object sender, EventArgs e)
        {
            showSubMenu(panelRelSubMenu);
        }

        private void btnRelProd_Click(object sender, EventArgs e)
        {
            openContentForm(new frmRelProd());
            hideSubMenu();
        }

        private void btnRelClientes_Click(object sender, EventArgs e)
        {
            openContentForm(new frmRelClientes());
            hideSubMenu();
        }

        private void btnRelVendas_Click(object sender, EventArgs e)
        {
            openContentForm(new frmRelVendas());
            hideSubMenu();
        }

        #endregion

        private void btnSobre_Click(object sender, EventArgs e)
        {
            openContentForm(new frmSobre());
            hideSubMenu();
        }

        private void btnConta_Click(object sender, EventArgs e)
        {
            openContentForm(new frmConta(txtID.Text));
            hideSubMenu();
        }
        
        private void Fechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Maximizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            Maximizar.Visible = false;
            Restaurar.Visible = true;
        }

        private void Restaurar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            Restaurar.Visible = false;
            Maximizar.Visible = true;
        }
    }
}