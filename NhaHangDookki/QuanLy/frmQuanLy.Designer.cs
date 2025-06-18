namespace NhaHangDookki.QuanLy
{
    partial class frmQuanLy
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnQLTK = new FontAwesome.Sharp.IconButton();
            this.btnQLDV = new FontAwesome.Sharp.IconButton();
            this.btnQLKM = new FontAwesome.Sharp.IconButton();
            this.btnBaoCao = new FontAwesome.Sharp.IconButton();
            this.btnQLBA = new FontAwesome.Sharp.IconButton();
            this.btnLLV = new FontAwesome.Sharp.IconButton();
            this.btnQLNV = new FontAwesome.Sharp.IconButton();
            this.btnTK = new FontAwesome.Sharp.IconButton();
            this.pnlTieuDe = new System.Windows.Forms.Panel();
            this.btnDangXuat = new FontAwesome.Sharp.IconButton();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.pnlDeskTop = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.pnlTieuDe.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(314, 262);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NhaHangDookki.Properties.Resources.IconNhaHang1;
            this.pictureBox1.Location = new System.Drawing.Point(12, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(296, 247);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panelMenu.Controls.Add(this.btnQLTK);
            this.panelMenu.Controls.Add(this.btnQLDV);
            this.panelMenu.Controls.Add(this.btnQLKM);
            this.panelMenu.Controls.Add(this.btnBaoCao);
            this.panelMenu.Controls.Add(this.btnQLBA);
            this.panelMenu.Controls.Add(this.btnLLV);
            this.panelMenu.Controls.Add(this.btnQLNV);
            this.panelMenu.Controls.Add(this.btnTK);
            this.panelMenu.Location = new System.Drawing.Point(0, 262);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(314, 1087);
            this.panelMenu.TabIndex = 1;
            this.panelMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // btnQLTK
            // 
            this.btnQLTK.FlatAppearance.BorderSize = 0;
            this.btnQLTK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLTK.ForeColor = System.Drawing.Color.Yellow;
            this.btnQLTK.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            this.btnQLTK.IconColor = System.Drawing.Color.Yellow;
            this.btnQLTK.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnQLTK.IconSize = 40;
            this.btnQLTK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLTK.Location = new System.Drawing.Point(0, 583);
            this.btnQLTK.Name = "btnQLTK";
            this.btnQLTK.Size = new System.Drawing.Size(314, 110);
            this.btnQLTK.TabIndex = 20;
            this.btnQLTK.Text = "     Quản lý tài khoản";
            this.btnQLTK.UseVisualStyleBackColor = false;
            this.btnQLTK.Click += new System.EventHandler(this.btnQLTK_Click);
            // 
            // btnQLDV
            // 
            this.btnQLDV.FlatAppearance.BorderSize = 0;
            this.btnQLDV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLDV.ForeColor = System.Drawing.Color.Yellow;
            this.btnQLDV.IconChar = FontAwesome.Sharp.IconChar.ConciergeBell;
            this.btnQLDV.IconColor = System.Drawing.Color.Yellow;
            this.btnQLDV.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnQLDV.IconSize = 40;
            this.btnQLDV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLDV.Location = new System.Drawing.Point(0, 351);
            this.btnQLDV.Name = "btnQLDV";
            this.btnQLDV.Size = new System.Drawing.Size(314, 110);
            this.btnQLDV.TabIndex = 14;
            this.btnQLDV.Text = "     Quản lý dịch vụ";
            this.btnQLDV.UseVisualStyleBackColor = false;
            this.btnQLDV.Click += new System.EventHandler(this.btnQLDV_Click);
            // 
            // btnQLKM
            // 
            this.btnQLKM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnQLKM.FlatAppearance.BorderSize = 0;
            this.btnQLKM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLKM.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLKM.ForeColor = System.Drawing.Color.Yellow;
            this.btnQLKM.IconChar = FontAwesome.Sharp.IconChar.Tags;
            this.btnQLKM.IconColor = System.Drawing.Color.Yellow;
            this.btnQLKM.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnQLKM.IconSize = 40;
            this.btnQLKM.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLKM.Location = new System.Drawing.Point(0, 467);
            this.btnQLKM.Name = "btnQLKM";
            this.btnQLKM.Size = new System.Drawing.Size(314, 110);
            this.btnQLKM.TabIndex = 18;
            this.btnQLKM.Text = "     Quản lý khuyến mãi";
            this.btnQLKM.UseVisualStyleBackColor = false;
            this.btnQLKM.Click += new System.EventHandler(this.btnQLKM_Click);
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.FlatAppearance.BorderSize = 0;
            this.btnBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaoCao.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaoCao.ForeColor = System.Drawing.Color.Yellow;
            this.btnBaoCao.IconChar = FontAwesome.Sharp.IconChar.ChartColumn;
            this.btnBaoCao.IconColor = System.Drawing.Color.Yellow;
            this.btnBaoCao.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBaoCao.IconSize = 40;
            this.btnBaoCao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaoCao.Location = new System.Drawing.Point(0, 815);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(314, 110);
            this.btnBaoCao.TabIndex = 25;
            this.btnBaoCao.Text = "     Báo cáo";
            this.btnBaoCao.UseVisualStyleBackColor = false;
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            // 
            // btnQLBA
            // 
            this.btnQLBA.FlatAppearance.BorderSize = 0;
            this.btnQLBA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLBA.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLBA.ForeColor = System.Drawing.Color.Yellow;
            this.btnQLBA.IconChar = FontAwesome.Sharp.IconChar.Table;
            this.btnQLBA.IconColor = System.Drawing.Color.Yellow;
            this.btnQLBA.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnQLBA.IconSize = 40;
            this.btnQLBA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLBA.Location = new System.Drawing.Point(0, 235);
            this.btnQLBA.Name = "btnQLBA";
            this.btnQLBA.Size = new System.Drawing.Size(314, 110);
            this.btnQLBA.TabIndex = 13;
            this.btnQLBA.Text = "     Quản lý bàn ăn";
            this.btnQLBA.UseVisualStyleBackColor = false;
            this.btnQLBA.Click += new System.EventHandler(this.btnQLBA_Click);
            // 
            // btnLLV
            // 
            this.btnLLV.FlatAppearance.BorderSize = 0;
            this.btnLLV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLLV.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLLV.ForeColor = System.Drawing.Color.Yellow;
            this.btnLLV.IconChar = FontAwesome.Sharp.IconChar.CalendarCheck;
            this.btnLLV.IconColor = System.Drawing.Color.Yellow;
            this.btnLLV.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLLV.IconSize = 40;
            this.btnLLV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLLV.Location = new System.Drawing.Point(0, 699);
            this.btnLLV.Name = "btnLLV";
            this.btnLLV.Size = new System.Drawing.Size(314, 110);
            this.btnLLV.TabIndex = 21;
            this.btnLLV.Text = "     Lịch làm việc";
            this.btnLLV.UseVisualStyleBackColor = false;
            this.btnLLV.Click += new System.EventHandler(this.btnLLV_Click);
            // 
            // btnQLNV
            // 
            this.btnQLNV.FlatAppearance.BorderSize = 0;
            this.btnQLNV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLNV.ForeColor = System.Drawing.Color.Yellow;
            this.btnQLNV.IconChar = FontAwesome.Sharp.IconChar.UserGear;
            this.btnQLNV.IconColor = System.Drawing.Color.Yellow;
            this.btnQLNV.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnQLNV.IconSize = 40;
            this.btnQLNV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLNV.Location = new System.Drawing.Point(0, 119);
            this.btnQLNV.Name = "btnQLNV";
            this.btnQLNV.Size = new System.Drawing.Size(314, 110);
            this.btnQLNV.TabIndex = 13;
            this.btnQLNV.Text = "     Quản lý nhân viên";
            this.btnQLNV.UseVisualStyleBackColor = false;
            this.btnQLNV.Click += new System.EventHandler(this.btnQLNV_Click);
            // 
            // btnTK
            // 
            this.btnTK.FlatAppearance.BorderSize = 0;
            this.btnTK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTK.ForeColor = System.Drawing.Color.Yellow;
            this.btnTK.IconChar = FontAwesome.Sharp.IconChar.UserEdit;
            this.btnTK.IconColor = System.Drawing.Color.Yellow;
            this.btnTK.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTK.IconSize = 40;
            this.btnTK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTK.Location = new System.Drawing.Point(0, 3);
            this.btnTK.Name = "btnTK";
            this.btnTK.Size = new System.Drawing.Size(314, 110);
            this.btnTK.TabIndex = 12;
            this.btnTK.Text = "     Thông tin tài khoản";
            this.btnTK.UseVisualStyleBackColor = false;
            this.btnTK.Click += new System.EventHandler(this.btnTK_Click);
            // 
            // pnlTieuDe
            // 
            this.pnlTieuDe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pnlTieuDe.Controls.Add(this.btnDangXuat);
            this.pnlTieuDe.Controls.Add(this.lblTieuDe);
            this.pnlTieuDe.Location = new System.Drawing.Point(314, 0);
            this.pnlTieuDe.Name = "pnlTieuDe";
            this.pnlTieuDe.Size = new System.Drawing.Size(1850, 124);
            this.pnlTieuDe.TabIndex = 1;
            this.pnlTieuDe.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTieuDe_MouseDown);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangXuat.ForeColor = System.Drawing.Color.Yellow;
            this.btnDangXuat.IconChar = FontAwesome.Sharp.IconChar.SignOut;
            this.btnDangXuat.IconColor = System.Drawing.Color.Yellow;
            this.btnDangXuat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDangXuat.IconSize = 40;
            this.btnDangXuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangXuat.Location = new System.Drawing.Point(1612, 10);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(218, 105);
            this.btnDangXuat.TabIndex = 22;
            this.btnDangXuat.Text = "     Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.Yellow;
            this.lblTieuDe.Location = new System.Drawing.Point(46, 42);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(0, 37);
            this.lblTieuDe.TabIndex = 2;
            // 
            // pnlDeskTop
            // 
            this.pnlDeskTop.Location = new System.Drawing.Point(314, 126);
            this.pnlDeskTop.Name = "pnlDeskTop";
            this.pnlDeskTop.Size = new System.Drawing.Size(1850, 1223);
            this.pnlDeskTop.TabIndex = 2;
            this.pnlDeskTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlDeskTop_MouseDown);
            // 
            // frmQuanLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2165, 1349);
            this.Controls.Add(this.pnlDeskTop);
            this.Controls.Add(this.pnlTieuDe);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmQuanLy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmQuanLy";
            this.Load += new System.EventHandler(this.frmQuanLy_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.pnlTieuDe.ResumeLayout(false);
            this.pnlTieuDe.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlTieuDe;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Panel pnlDeskTop;
        private FontAwesome.Sharp.IconButton btnQLNV;
        private FontAwesome.Sharp.IconButton btnTK;
        private FontAwesome.Sharp.IconButton btnDangXuat;
        private FontAwesome.Sharp.IconButton btnQLDV;
        private FontAwesome.Sharp.IconButton btnLLV;
        private FontAwesome.Sharp.IconButton btnQLTK;
        private FontAwesome.Sharp.IconButton btnQLBA;
        private FontAwesome.Sharp.IconButton btnQLKM;
        private FontAwesome.Sharp.IconButton btnBaoCao;
    }
}