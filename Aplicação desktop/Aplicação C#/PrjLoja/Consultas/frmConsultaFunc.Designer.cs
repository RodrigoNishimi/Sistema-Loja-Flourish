namespace PrjLoja
{
    partial class frmConsultaFunc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaFunc));
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.dgvFunc = new System.Windows.Forms.DataGridView();
            this.cbOrder = new Bunifu.UI.WinForms.BunifuDropdown();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFiltro = new Bunifu.UI.WinForms.BunifuDropdown();
            this.txtFiltro = new Bunifu.UI.WinForms.BunifuTextBox();
            this.btnOrdenar = new System.Windows.Forms.PictureBox();
            this.btnBuscar = new System.Windows.Forms.PictureBox();
            this.btnShowAll = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFunc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOrdenar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShowAll)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFunc
            // 
            this.dgvFunc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFunc.Location = new System.Drawing.Point(0, 0);
            this.dgvFunc.Name = "dgvFunc";
            this.dgvFunc.Size = new System.Drawing.Size(1200, 287);
            this.dgvFunc.TabIndex = 0;
            // 
            // cbOrder
            // 
            this.cbOrder.BackColor = System.Drawing.Color.Transparent;
            this.cbOrder.BackgroundColor = System.Drawing.Color.White;
            this.cbOrder.BorderColor = System.Drawing.Color.Silver;
            this.cbOrder.BorderRadius = 17;
            this.cbOrder.Color = System.Drawing.Color.Silver;
            this.cbOrder.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.cbOrder.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cbOrder.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cbOrder.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cbOrder.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.cbOrder.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
            this.cbOrder.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbOrder.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.cbOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOrder.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.cbOrder.FillDropDown = true;
            this.cbOrder.FillIndicator = false;
            this.cbOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbOrder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbOrder.ForeColor = System.Drawing.Color.Black;
            this.cbOrder.FormattingEnabled = true;
            this.cbOrder.Icon = null;
            this.cbOrder.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.cbOrder.IndicatorColor = System.Drawing.Color.Gray;
            this.cbOrder.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.cbOrder.ItemBackColor = System.Drawing.Color.White;
            this.cbOrder.ItemBorderColor = System.Drawing.Color.White;
            this.cbOrder.ItemForeColor = System.Drawing.Color.Black;
            this.cbOrder.ItemHeight = 26;
            this.cbOrder.ItemHighLightColor = System.Drawing.Color.DodgerBlue;
            this.cbOrder.ItemHighLightForeColor = System.Drawing.Color.White;
            this.cbOrder.Items.AddRange(new object[] {
            "idFuncionario",
            "idCat_Funcionario",
            "nome",
            "email",
            "senha",
            "telefone",
            "cpf",
            "sexo",
            "data_Nasc",
            "salario",
            "estado",
            "cidade",
            "endereco",
            "cep"});
            this.cbOrder.ItemTopMargin = 3;
            this.cbOrder.Location = new System.Drawing.Point(389, 347);
            this.cbOrder.Name = "cbOrder";
            this.cbOrder.Size = new System.Drawing.Size(241, 32);
            this.cbOrder.TabIndex = 93;
            this.cbOrder.Text = null;
            this.cbOrder.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.cbOrder.TextLeftMargin = 5;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(385, 325);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 19);
            this.label9.TabIndex = 94;
            this.label9.Text = "Ordernar por:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(385, 399);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 19);
            this.label1.TabIndex = 96;
            this.label1.Text = "Buscar por:";
            // 
            // cbFiltro
            // 
            this.cbFiltro.BackColor = System.Drawing.Color.Transparent;
            this.cbFiltro.BackgroundColor = System.Drawing.Color.White;
            this.cbFiltro.BorderColor = System.Drawing.Color.Silver;
            this.cbFiltro.BorderRadius = 17;
            this.cbFiltro.Color = System.Drawing.Color.Silver;
            this.cbFiltro.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.cbFiltro.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cbFiltro.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cbFiltro.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cbFiltro.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.cbFiltro.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
            this.cbFiltro.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFiltro.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.cbFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiltro.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.cbFiltro.FillDropDown = true;
            this.cbFiltro.FillIndicator = false;
            this.cbFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbFiltro.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbFiltro.ForeColor = System.Drawing.Color.Black;
            this.cbFiltro.FormattingEnabled = true;
            this.cbFiltro.Icon = null;
            this.cbFiltro.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.cbFiltro.IndicatorColor = System.Drawing.Color.Gray;
            this.cbFiltro.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.cbFiltro.ItemBackColor = System.Drawing.Color.White;
            this.cbFiltro.ItemBorderColor = System.Drawing.Color.White;
            this.cbFiltro.ItemForeColor = System.Drawing.Color.Black;
            this.cbFiltro.ItemHeight = 26;
            this.cbFiltro.ItemHighLightColor = System.Drawing.Color.DodgerBlue;
            this.cbFiltro.ItemHighLightForeColor = System.Drawing.Color.White;
            this.cbFiltro.Items.AddRange(new object[] {
            "idFuncionario",
            "idCat_Funcionario",
            "nome",
            "email",
            "senha",
            "telefone",
            "cpf",
            "sexo",
            "data_Nasc",
            "salario",
            "estado",
            "cidade",
            "endereco",
            "cep"});
            this.cbFiltro.ItemTopMargin = 3;
            this.cbFiltro.Location = new System.Drawing.Point(389, 421);
            this.cbFiltro.Name = "cbFiltro";
            this.cbFiltro.Size = new System.Drawing.Size(241, 32);
            this.cbFiltro.TabIndex = 95;
            this.cbFiltro.Text = null;
            this.cbFiltro.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.cbFiltro.TextLeftMargin = 5;
            // 
            // txtFiltro
            // 
            this.txtFiltro.AcceptsReturn = false;
            this.txtFiltro.AcceptsTab = false;
            this.txtFiltro.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFiltro.AnimationSpeed = 200;
            this.txtFiltro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtFiltro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtFiltro.BackColor = System.Drawing.Color.Transparent;
            this.txtFiltro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtFiltro.BackgroundImage")));
            this.txtFiltro.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txtFiltro.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtFiltro.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txtFiltro.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtFiltro.BorderRadius = 20;
            this.txtFiltro.BorderThickness = 1;
            this.txtFiltro.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtFiltro.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFiltro.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
            this.txtFiltro.DefaultText = "";
            this.txtFiltro.FillColor = System.Drawing.Color.White;
            this.txtFiltro.HideSelection = true;
            this.txtFiltro.IconLeft = null;
            this.txtFiltro.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFiltro.IconPadding = 10;
            this.txtFiltro.IconRight = null;
            this.txtFiltro.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFiltro.Lines = new string[0];
            this.txtFiltro.Location = new System.Drawing.Point(389, 471);
            this.txtFiltro.MaxLength = 32767;
            this.txtFiltro.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtFiltro.Modified = false;
            this.txtFiltro.Multiline = false;
            this.txtFiltro.Name = "txtFiltro";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtFiltro.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtFiltro.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtFiltro.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtFiltro.OnIdleState = stateProperties4;
            this.txtFiltro.Padding = new System.Windows.Forms.Padding(3);
            this.txtFiltro.PasswordChar = '\0';
            this.txtFiltro.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtFiltro.PlaceholderText = "";
            this.txtFiltro.ReadOnly = false;
            this.txtFiltro.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtFiltro.SelectedText = "";
            this.txtFiltro.SelectionLength = 0;
            this.txtFiltro.SelectionStart = 0;
            this.txtFiltro.ShortcutsEnabled = true;
            this.txtFiltro.Size = new System.Drawing.Size(241, 37);
            this.txtFiltro.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txtFiltro.TabIndex = 99;
            this.txtFiltro.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtFiltro.TextMarginBottom = 0;
            this.txtFiltro.TextMarginLeft = 3;
            this.txtFiltro.TextMarginTop = 0;
            this.txtFiltro.TextPlaceholder = "";
            this.txtFiltro.UseSystemPasswordChar = false;
            this.txtFiltro.WordWrap = true;
            // 
            // btnOrdenar
            // 
            this.btnOrdenar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrdenar.BackColor = System.Drawing.SystemColors.Control;
            this.btnOrdenar.Image = ((System.Drawing.Image)(resources.GetObject("btnOrdenar.Image")));
            this.btnOrdenar.Location = new System.Drawing.Point(676, 347);
            this.btnOrdenar.Name = "btnOrdenar";
            this.btnOrdenar.Size = new System.Drawing.Size(35, 35);
            this.btnOrdenar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnOrdenar.TabIndex = 109;
            this.btnOrdenar.TabStop = false;
            this.btnOrdenar.Click += new System.EventHandler(this.btnOrdenar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.BackColor = System.Drawing.SystemColors.Control;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(676, 473);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(35, 35);
            this.btnBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnBuscar.TabIndex = 110;
            this.btnBuscar.TabStop = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowAll.BackColor = System.Drawing.SystemColors.Control;
            this.btnShowAll.Image = ((System.Drawing.Image)(resources.GetObject("btnShowAll.Image")));
            this.btnShowAll.Location = new System.Drawing.Point(789, 473);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(35, 35);
            this.btnShowAll.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnShowAll.TabIndex = 111;
            this.btnShowAll.TabStop = false;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // frmConsultaFunc
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1200, 586);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnOrdenar);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbFiltro);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbOrder);
            this.Controls.Add(this.dgvFunc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmConsultaFunc";
            this.Text = "Funcionário";
            this.Load += new System.EventHandler(this.frmConsultaFunc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFunc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOrdenar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShowAll)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFunc;
        private Bunifu.UI.WinForms.BunifuDropdown cbOrder;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private Bunifu.UI.WinForms.BunifuDropdown cbFiltro;
        private Bunifu.UI.WinForms.BunifuTextBox txtFiltro;
        private System.Windows.Forms.PictureBox btnOrdenar;
        private System.Windows.Forms.PictureBox btnBuscar;
        private System.Windows.Forms.PictureBox btnShowAll;
    }
}