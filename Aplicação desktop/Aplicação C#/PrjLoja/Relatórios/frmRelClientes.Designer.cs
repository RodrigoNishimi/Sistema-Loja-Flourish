namespace PrjLoja
{
    partial class frmRelClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRelClientes));
            this.chartClientesMes = new LiveCharts.WinForms.CartesianChart();
            this.label2 = new System.Windows.Forms.Label();
            this.gunaGradient2Panel1 = new Guna.UI.WinForms.GunaGradient2Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblNClientes = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gunaGradient2Panel4 = new Guna.UI.WinForms.GunaGradient2Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lblNPed = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gunaGradient2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gunaGradient2Panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // chartClientesMes
            // 
            this.chartClientesMes.Location = new System.Drawing.Point(12, 247);
            this.chartClientesMes.Name = "chartClientesMes";
            this.chartClientesMes.Size = new System.Drawing.Size(1176, 335);
            this.chartClientesMes.TabIndex = 0;
            this.chartClientesMes.Text = "cartesianChart1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(277, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "Número de clientes por mês (2021)";
            // 
            // gunaGradient2Panel1
            // 
            this.gunaGradient2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.gunaGradient2Panel1.Controls.Add(this.pictureBox1);
            this.gunaGradient2Panel1.Controls.Add(this.lblNClientes);
            this.gunaGradient2Panel1.Controls.Add(this.label1);
            this.gunaGradient2Panel1.GradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(170)))), ((int)(((byte)(231)))));
            this.gunaGradient2Panel1.GradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(170)))), ((int)(((byte)(231)))));
            this.gunaGradient2Panel1.Location = new System.Drawing.Point(346, 55);
            this.gunaGradient2Panel1.Name = "gunaGradient2Panel1";
            this.gunaGradient2Panel1.Radius = 20;
            this.gunaGradient2Panel1.Size = new System.Drawing.Size(220, 120);
            this.gunaGradient2Panel1.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(170)))), ((int)(((byte)(231)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(157, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // lblNClientes
            // 
            this.lblNClientes.AutoSize = true;
            this.lblNClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(170)))), ((int)(((byte)(231)))));
            this.lblNClientes.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNClientes.ForeColor = System.Drawing.Color.White;
            this.lblNClientes.Location = new System.Drawing.Point(16, 50);
            this.lblNClientes.Name = "lblNClientes";
            this.lblNClientes.Size = new System.Drawing.Size(63, 36);
            this.lblNClientes.TabIndex = 1;
            this.lblNClientes.Text = "102";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(170)))), ((int)(((byte)(231)))));
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(19, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nº Clientes";
            // 
            // gunaGradient2Panel4
            // 
            this.gunaGradient2Panel4.BackColor = System.Drawing.Color.Transparent;
            this.gunaGradient2Panel4.Controls.Add(this.pictureBox4);
            this.gunaGradient2Panel4.Controls.Add(this.lblNPed);
            this.gunaGradient2Panel4.Controls.Add(this.label8);
            this.gunaGradient2Panel4.GradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(133)))), ((int)(((byte)(27)))));
            this.gunaGradient2Panel4.GradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(133)))), ((int)(((byte)(27)))));
            this.gunaGradient2Panel4.Location = new System.Drawing.Point(664, 55);
            this.gunaGradient2Panel4.Name = "gunaGradient2Panel4";
            this.gunaGradient2Panel4.Radius = 20;
            this.gunaGradient2Panel4.Size = new System.Drawing.Size(220, 120);
            this.gunaGradient2Panel4.TabIndex = 10;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(133)))), ((int)(((byte)(27)))));
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(157, 13);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(40, 40);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // lblNPed
            // 
            this.lblNPed.AutoSize = true;
            this.lblNPed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(133)))), ((int)(((byte)(27)))));
            this.lblNPed.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNPed.ForeColor = System.Drawing.Color.White;
            this.lblNPed.Location = new System.Drawing.Point(16, 50);
            this.lblNPed.Name = "lblNPed";
            this.lblNPed.Size = new System.Drawing.Size(63, 36);
            this.lblNPed.TabIndex = 1;
            this.lblNPed.Text = "102";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(133)))), ((int)(((byte)(27)))));
            this.label8.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(19, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 18);
            this.label8.TabIndex = 0;
            this.label8.Text = "Nº Pedidos";
            // 
            // frmRelClientes
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1200, 586);
            this.Controls.Add(this.gunaGradient2Panel4);
            this.Controls.Add(this.gunaGradient2Panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chartClientesMes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRelClientes";
            this.Text = "Relatório Clientes";
            this.Load += new System.EventHandler(this.frmRelClientes_Load);
            this.gunaGradient2Panel1.ResumeLayout(false);
            this.gunaGradient2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gunaGradient2Panel4.ResumeLayout(false);
            this.gunaGradient2Panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart chartClientesMes;
        private System.Windows.Forms.Label label2;
        private Guna.UI.WinForms.GunaGradient2Panel gunaGradient2Panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblNClientes;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaGradient2Panel gunaGradient2Panel4;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label lblNPed;
        private System.Windows.Forms.Label label8;
    }
}