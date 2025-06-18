namespace NhaHangDookki.QuanLy.FormBaoCao
{
    partial class frmChiPhiNhap
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dataGridViewNhapHang = new System.Windows.Forms.DataGridView();
            this.chartNhapHang = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnXuatBaoCao = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNhapHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartNhapHang)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewNhapHang
            // 
            this.dataGridViewNhapHang.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewNhapHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNhapHang.GridColor = System.Drawing.Color.White;
            this.dataGridViewNhapHang.Location = new System.Drawing.Point(27, 49);
            this.dataGridViewNhapHang.Name = "dataGridViewNhapHang";
            this.dataGridViewNhapHang.RowHeadersWidth = 62;
            this.dataGridViewNhapHang.Size = new System.Drawing.Size(824, 704);
            this.dataGridViewNhapHang.TabIndex = 3;
            // 
            // chartNhapHang
            // 
            chartArea4.Name = "ChartArea1";
            this.chartNhapHang.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartNhapHang.Legends.Add(legend4);
            this.chartNhapHang.Location = new System.Drawing.Point(909, 49);
            this.chartNhapHang.Name = "chartNhapHang";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartNhapHang.Series.Add(series4);
            this.chartNhapHang.Size = new System.Drawing.Size(847, 704);
            this.chartNhapHang.TabIndex = 2;
            this.chartNhapHang.Text = "chart1";
            // 
            // btnXuatBaoCao
            // 
            this.btnXuatBaoCao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatBaoCao.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnXuatBaoCao.IconColor = System.Drawing.Color.Black;
            this.btnXuatBaoCao.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnXuatBaoCao.Location = new System.Drawing.Point(1484, 867);
            this.btnXuatBaoCao.Name = "btnXuatBaoCao";
            this.btnXuatBaoCao.Size = new System.Drawing.Size(272, 104);
            this.btnXuatBaoCao.TabIndex = 4;
            this.btnXuatBaoCao.Text = "Xuất báo cáo";
            this.btnXuatBaoCao.UseVisualStyleBackColor = true;
            this.btnXuatBaoCao.Click += new System.EventHandler(this.btnXuatBaoCao_Click);
            // 
            // frmChiPhiNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1799, 1042);
            this.Controls.Add(this.btnXuatBaoCao);
            this.Controls.Add(this.dataGridViewNhapHang);
            this.Controls.Add(this.chartNhapHang);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmChiPhiNhap";
            this.Text = "frmChiPhiNhap";
            this.Load += new System.EventHandler(this.frmChiPhiNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNhapHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartNhapHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewNhapHang;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartNhapHang;
        private FontAwesome.Sharp.IconButton btnXuatBaoCao;
    }
}