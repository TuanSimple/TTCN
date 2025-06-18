namespace NhaHangDookki.QuanLy.FormBaoCao
{
    partial class frmTonKho
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartTonKho = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridViewTonKho = new System.Windows.Forms.DataGridView();
            this.btnXuatBaoCao = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.chartTonKho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTonKho)).BeginInit();
            this.SuspendLayout();
            // 
            // chartTonKho
            // 
            chartArea3.Name = "ChartArea1";
            this.chartTonKho.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartTonKho.Legends.Add(legend3);
            this.chartTonKho.Location = new System.Drawing.Point(993, 77);
            this.chartTonKho.Name = "chartTonKho";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartTonKho.Series.Add(series3);
            this.chartTonKho.Size = new System.Drawing.Size(772, 801);
            this.chartTonKho.TabIndex = 0;
            this.chartTonKho.Text = "chart1";
            // 
            // dataGridViewTonKho
            // 
            this.dataGridViewTonKho.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewTonKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTonKho.GridColor = System.Drawing.Color.White;
            this.dataGridViewTonKho.Location = new System.Drawing.Point(25, 77);
            this.dataGridViewTonKho.Name = "dataGridViewTonKho";
            this.dataGridViewTonKho.RowHeadersWidth = 62;
            this.dataGridViewTonKho.Size = new System.Drawing.Size(889, 801);
            this.dataGridViewTonKho.TabIndex = 1;
            // 
            // btnXuatBaoCao
            // 
            this.btnXuatBaoCao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatBaoCao.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnXuatBaoCao.IconColor = System.Drawing.Color.Black;
            this.btnXuatBaoCao.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnXuatBaoCao.Location = new System.Drawing.Point(1493, 907);
            this.btnXuatBaoCao.Name = "btnXuatBaoCao";
            this.btnXuatBaoCao.Size = new System.Drawing.Size(272, 104);
            this.btnXuatBaoCao.TabIndex = 5;
            this.btnXuatBaoCao.Text = "Xuất báo cáo";
            this.btnXuatBaoCao.UseVisualStyleBackColor = true;
            this.btnXuatBaoCao.Click += new System.EventHandler(this.btnXuatBaoCao_Click);
            // 
            // frmTonKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1799, 1042);
            this.Controls.Add(this.btnXuatBaoCao);
            this.Controls.Add(this.dataGridViewTonKho);
            this.Controls.Add(this.chartTonKho);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTonKho";
            this.Text = "frmTonKho";
            this.Load += new System.EventHandler(this.frmTonKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartTonKho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTonKho)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartTonKho;
        private System.Windows.Forms.DataGridView dataGridViewTonKho;
        private FontAwesome.Sharp.IconButton btnXuatBaoCao;
    }
}