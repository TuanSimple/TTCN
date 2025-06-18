namespace NhaHangDookki.QuanLy.FormBaoCao
{
    partial class frmDoanhThu
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.cboDoanhThuTheo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpTgBD = new System.Windows.Forms.DateTimePicker();
            this.dtpTgKT = new System.Windows.Forms.DateTimePicker();
            this.btnTaoBaoCao = new FontAwesome.Sharp.IconButton();
            this.btnXuatBaoCao = new FontAwesome.Sharp.IconButton();
            this.btnDoanhThuCaoNhat = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            this.SuspendLayout();
            // 
            // chartDoanhThu
            // 
            chartArea1.Name = "ChartArea1";
            this.chartDoanhThu.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartDoanhThu.Legends.Add(legend1);
            this.chartDoanhThu.Location = new System.Drawing.Point(670, 56);
            this.chartDoanhThu.Name = "chartDoanhThu";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartDoanhThu.Series.Add(series1);
            this.chartDoanhThu.Size = new System.Drawing.Size(1037, 932);
            this.chartDoanhThu.TabIndex = 0;
            this.chartDoanhThu.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(74, 290);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Doanh thu theo:";
            // 
            // cboDoanhThuTheo
            // 
            this.cboDoanhThuTheo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDoanhThuTheo.FormattingEnabled = true;
            this.cboDoanhThuTheo.Location = new System.Drawing.Point(357, 287);
            this.cboDoanhThuTheo.Name = "cboDoanhThuTheo";
            this.cboDoanhThuTheo.Size = new System.Drawing.Size(200, 40);
            this.cboDoanhThuTheo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(74, 393);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Thời gian bắt đầu:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(74, 489);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(246, 32);
            this.label3.TabIndex = 4;
            this.label3.Text = "Thời gian kết thúc:";
            // 
            // dtpTgBD
            // 
            this.dtpTgBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTgBD.Location = new System.Drawing.Point(357, 388);
            this.dtpTgBD.Name = "dtpTgBD";
            this.dtpTgBD.Size = new System.Drawing.Size(200, 39);
            this.dtpTgBD.TabIndex = 5;
            // 
            // dtpTgKT
            // 
            this.dtpTgKT.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTgKT.Location = new System.Drawing.Point(357, 484);
            this.dtpTgKT.Name = "dtpTgKT";
            this.dtpTgKT.Size = new System.Drawing.Size(200, 39);
            this.dtpTgKT.TabIndex = 6;
            // 
            // btnTaoBaoCao
            // 
            this.btnTaoBaoCao.BackColor = System.Drawing.Color.White;
            this.btnTaoBaoCao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoBaoCao.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnTaoBaoCao.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnTaoBaoCao.IconColor = System.Drawing.Color.Black;
            this.btnTaoBaoCao.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTaoBaoCao.Location = new System.Drawing.Point(80, 684);
            this.btnTaoBaoCao.Name = "btnTaoBaoCao";
            this.btnTaoBaoCao.Size = new System.Drawing.Size(180, 79);
            this.btnTaoBaoCao.TabIndex = 7;
            this.btnTaoBaoCao.Text = "Tạo báo cáo";
            this.btnTaoBaoCao.UseVisualStyleBackColor = false;
            this.btnTaoBaoCao.Click += new System.EventHandler(this.btnTaoBaoCao_Click);
            // 
            // btnXuatBaoCao
            // 
            this.btnXuatBaoCao.BackColor = System.Drawing.Color.White;
            this.btnXuatBaoCao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatBaoCao.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnXuatBaoCao.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnXuatBaoCao.IconColor = System.Drawing.Color.Black;
            this.btnXuatBaoCao.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnXuatBaoCao.Location = new System.Drawing.Point(377, 684);
            this.btnXuatBaoCao.Name = "btnXuatBaoCao";
            this.btnXuatBaoCao.Size = new System.Drawing.Size(180, 79);
            this.btnXuatBaoCao.TabIndex = 8;
            this.btnXuatBaoCao.Text = "Xuất báo cáo";
            this.btnXuatBaoCao.UseVisualStyleBackColor = false;
            this.btnXuatBaoCao.Click += new System.EventHandler(this.btnXuatBaoCao_Click);
            // 
            // btnDoanhThuCaoNhat
            // 
            this.btnDoanhThuCaoNhat.BackColor = System.Drawing.Color.White;
            this.btnDoanhThuCaoNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoanhThuCaoNhat.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDoanhThuCaoNhat.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnDoanhThuCaoNhat.IconColor = System.Drawing.Color.Black;
            this.btnDoanhThuCaoNhat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDoanhThuCaoNhat.Location = new System.Drawing.Point(226, 856);
            this.btnDoanhThuCaoNhat.Name = "btnDoanhThuCaoNhat";
            this.btnDoanhThuCaoNhat.Size = new System.Drawing.Size(180, 79);
            this.btnDoanhThuCaoNhat.TabIndex = 9;
            this.btnDoanhThuCaoNhat.Text = "Doanh thu cao nhất";
            this.btnDoanhThuCaoNhat.UseVisualStyleBackColor = false;
            this.btnDoanhThuCaoNhat.Click += new System.EventHandler(this.btnDoanhThuCaoNhat_Click);
            // 
            // frmDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1799, 1042);
            this.Controls.Add(this.btnDoanhThuCaoNhat);
            this.Controls.Add(this.btnXuatBaoCao);
            this.Controls.Add(this.btnTaoBaoCao);
            this.Controls.Add(this.dtpTgKT);
            this.Controls.Add(this.dtpTgBD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboDoanhThuTheo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartDoanhThu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDoanhThu";
            this.Text = "frmDoanhThu";
            this.Load += new System.EventHandler(this.frmDoanhThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDoanhThuTheo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpTgBD;
        private System.Windows.Forms.DateTimePicker dtpTgKT;
        private FontAwesome.Sharp.IconButton btnTaoBaoCao;
        private FontAwesome.Sharp.IconButton btnXuatBaoCao;
        private FontAwesome.Sharp.IconButton btnDoanhThuCaoNhat;
    }
}