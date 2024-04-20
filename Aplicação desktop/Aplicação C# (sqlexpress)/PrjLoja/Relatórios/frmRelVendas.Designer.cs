namespace PrjLoja
{
    partial class frmRelVendas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRelVendas));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartVendasMensais = new LiveCharts.WinForms.CartesianChart();
            this.label2 = new System.Windows.Forms.Label();
            this.gunaGradient2Panel3 = new Guna.UI.WinForms.GunaGradient2Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblVendas = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chartVendaAnual = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.gunaGradient2Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVendaAnual)).BeginInit();
            this.SuspendLayout();
            // 
            // chartVendasMensais
            // 
            this.chartVendasMensais.Location = new System.Drawing.Point(33, 261);
            this.chartVendasMensais.Name = "chartVendasMensais";
            this.chartVendasMensais.Size = new System.Drawing.Size(1155, 321);
            this.chartVendasMensais.TabIndex = 0;
            this.chartVendasMensais.Text = "cartesianChart1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "Vendas mensais (2021)";
            // 
            // gunaGradient2Panel3
            // 
            this.gunaGradient2Panel3.BackColor = System.Drawing.Color.Transparent;
            this.gunaGradient2Panel3.Controls.Add(this.pictureBox3);
            this.gunaGradient2Panel3.Controls.Add(this.lblVendas);
            this.gunaGradient2Panel3.Controls.Add(this.label6);
            this.gunaGradient2Panel3.GradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(196)))), ((int)(((byte)(70)))));
            this.gunaGradient2Panel3.GradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(196)))), ((int)(((byte)(70)))));
            this.gunaGradient2Panel3.Location = new System.Drawing.Point(78, 51);
            this.gunaGradient2Panel3.Name = "gunaGradient2Panel3";
            this.gunaGradient2Panel3.Radius = 20;
            this.gunaGradient2Panel3.Size = new System.Drawing.Size(220, 120);
            this.gunaGradient2Panel3.TabIndex = 10;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(196)))), ((int)(((byte)(70)))));
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(157, 13);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(40, 40);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // lblVendas
            // 
            this.lblVendas.AutoSize = true;
            this.lblVendas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(196)))), ((int)(((byte)(70)))));
            this.lblVendas.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendas.ForeColor = System.Drawing.Color.White;
            this.lblVendas.Location = new System.Drawing.Point(16, 54);
            this.lblVendas.Name = "lblVendas";
            this.lblVendas.Size = new System.Drawing.Size(63, 36);
            this.lblVendas.TabIndex = 1;
            this.lblVendas.Text = "102";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(196)))), ((int)(((byte)(70)))));
            this.label6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(19, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "Vendas Totais";
            // 
            // chartVendaAnual
            // 
            this.chartVendaAnual.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.Name = "ChartArea1";
            this.chartVendaAnual.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.SystemColors.Control;
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chartVendaAnual.Legends.Add(legend1);
            this.chartVendaAnual.Location = new System.Drawing.Point(406, 42);
            this.chartVendaAnual.Name = "chartVendaAnual";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartVendaAnual.Series.Add(series1);
            this.chartVendaAnual.Size = new System.Drawing.Size(782, 198);
            this.chartVendaAnual.TabIndex = 11;
            this.chartVendaAnual.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(402, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = "Vendas Anuais";
            // 
            // frmRelVendas
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1200, 586);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartVendaAnual);
            this.Controls.Add(this.gunaGradient2Panel3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chartVendasMensais);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRelVendas";
            this.Text = "Relatório Vendas";
            this.Load += new System.EventHandler(this.frmRelVendas_Load);
            this.gunaGradient2Panel3.ResumeLayout(false);
            this.gunaGradient2Panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVendaAnual)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart chartVendasMensais;
        private System.Windows.Forms.Label label2;
        private Guna.UI.WinForms.GunaGradient2Panel gunaGradient2Panel3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblVendas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVendaAnual;
        private System.Windows.Forms.Label label1;
    }
}