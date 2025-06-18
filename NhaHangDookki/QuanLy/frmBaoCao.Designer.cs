namespace NhaHangDookki.QuanLy
{
    partial class frmBaoCao
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
            this.pnlDeskTop = new System.Windows.Forms.Panel();
            this.btnNhapHang = new FontAwesome.Sharp.IconButton();
            this.btnTonKho = new FontAwesome.Sharp.IconButton();
            this.btnDoanhThu = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // pnlDeskTop
            // 
            this.pnlDeskTop.BackColor = System.Drawing.Color.White;
            this.pnlDeskTop.Location = new System.Drawing.Point(18, 152);
            this.pnlDeskTop.Margin = new System.Windows.Forms.Padding(4);
            this.pnlDeskTop.Name = "pnlDeskTop";
            this.pnlDeskTop.Size = new System.Drawing.Size(1799, 1042);
            this.pnlDeskTop.TabIndex = 1;
            // 
            // btnNhapHang
            // 
            this.btnNhapHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnNhapHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhapHang.ForeColor = System.Drawing.Color.Yellow;
            this.btnNhapHang.IconChar = FontAwesome.Sharp.IconChar.TruckMoving;
            this.btnNhapHang.IconColor = System.Drawing.Color.Yellow;
            this.btnNhapHang.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNhapHang.IconSize = 35;
            this.btnNhapHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhapHang.Location = new System.Drawing.Point(1208, 31);
            this.btnNhapHang.Margin = new System.Windows.Forms.Padding(4);
            this.btnNhapHang.Name = "btnNhapHang";
            this.btnNhapHang.Size = new System.Drawing.Size(252, 93);
            this.btnNhapHang.TabIndex = 3;
            this.btnNhapHang.Text = "     Báo cáo chi phí nhập hàng";
            this.btnNhapHang.UseVisualStyleBackColor = false;
            this.btnNhapHang.Click += new System.EventHandler(this.btnNhapHang_Click);
            // 
            // btnTonKho
            // 
            this.btnTonKho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnTonKho.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTonKho.ForeColor = System.Drawing.Color.Yellow;
            this.btnTonKho.IconChar = FontAwesome.Sharp.IconChar.Box;
            this.btnTonKho.IconColor = System.Drawing.Color.Yellow;
            this.btnTonKho.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTonKho.IconSize = 35;
            this.btnTonKho.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTonKho.Location = new System.Drawing.Point(815, 31);
            this.btnTonKho.Margin = new System.Windows.Forms.Padding(4);
            this.btnTonKho.Name = "btnTonKho";
            this.btnTonKho.Size = new System.Drawing.Size(252, 93);
            this.btnTonKho.TabIndex = 2;
            this.btnTonKho.Text = "     Báo cáo tồn kho";
            this.btnTonKho.UseVisualStyleBackColor = false;
            this.btnTonKho.Click += new System.EventHandler(this.btnTonKho_Click);
            // 
            // btnDoanhThu
            // 
            this.btnDoanhThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoanhThu.ForeColor = System.Drawing.Color.Yellow;
            this.btnDoanhThu.IconChar = FontAwesome.Sharp.IconChar.ChartColumn;
            this.btnDoanhThu.IconColor = System.Drawing.Color.Yellow;
            this.btnDoanhThu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDoanhThu.IconSize = 35;
            this.btnDoanhThu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDoanhThu.Location = new System.Drawing.Point(413, 31);
            this.btnDoanhThu.Margin = new System.Windows.Forms.Padding(4);
            this.btnDoanhThu.Name = "btnDoanhThu";
            this.btnDoanhThu.Size = new System.Drawing.Size(252, 93);
            this.btnDoanhThu.TabIndex = 1;
            this.btnDoanhThu.Text = "     Báo cáo doanh thu";
            this.btnDoanhThu.UseVisualStyleBackColor = false;
            this.btnDoanhThu.Click += new System.EventHandler(this.btnDoanhThu_Click);
            // 
            // frmBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1850, 1223);
            this.Controls.Add(this.btnNhapHang);
            this.Controls.Add(this.btnTonKho);
            this.Controls.Add(this.btnDoanhThu);
            this.Controls.Add(this.pnlDeskTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBaoCao";
            this.Text = "frmBaoCao";
            this.Load += new System.EventHandler(this.frmBaoCao_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlDeskTop;
        private FontAwesome.Sharp.IconButton btnDoanhThu;
        private FontAwesome.Sharp.IconButton btnTonKho;
        private FontAwesome.Sharp.IconButton btnNhapHang;
    }
}