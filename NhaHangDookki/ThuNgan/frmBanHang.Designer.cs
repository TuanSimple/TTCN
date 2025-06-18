namespace NhaHangDookki.ThuNgan
{
    partial class frmBanHang
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flpBanAn = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMaHDB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPhanTramGiam = new System.Windows.Forms.Label();
            this.btnThanhToan = new FontAwesome.Sharp.IconButton();
            this.cboHTTT = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnKhuyenMai = new System.Windows.Forms.Button();
            this.cboKhuyenMai = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.btnLamMoi = new FontAwesome.Sharp.IconButton();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.dgvChiTietHoaDon = new System.Windows.Forms.DataGridView();
            this.btnLuu = new FontAwesome.Sharp.IconButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboDichVu = new System.Windows.Forms.ComboBox();
            this.btnThem = new FontAwesome.Sharp.IconButton();
            this.btnSua = new FontAwesome.Sharp.IconButton();
            this.btnXoa = new FontAwesome.Sharp.IconButton();
            this.cboMaBan = new System.Windows.Forms.ComboBox();
            this.btnInHoaDon = new FontAwesome.Sharp.IconButton();
            this.btnLienHeKhachCho = new FontAwesome.Sharp.IconButton();
            this.btnChuyenBan = new FontAwesome.Sharp.IconButton();
            this.btnThemKH = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flpBanAn);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(18, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(731, 1191);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách bàn";
            // 
            // flpBanAn
            // 
            this.flpBanAn.Location = new System.Drawing.Point(9, 52);
            this.flpBanAn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flpBanAn.Name = "flpBanAn";
            this.flpBanAn.Size = new System.Drawing.Size(712, 1116);
            this.flpBanAn.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtMaHDB);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lblPhanTramGiam);
            this.groupBox2.Controls.Add(this.btnThanhToan);
            this.groupBox2.Controls.Add(this.cboHTTT);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnKhuyenMai);
            this.groupBox2.Controls.Add(this.cboKhuyenMai);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtTongTien);
            this.groupBox2.Controls.Add(this.lblTongTien);
            this.groupBox2.Controls.Add(this.btnLamMoi);
            this.groupBox2.Controls.Add(this.nudSoLuong);
            this.groupBox2.Controls.Add(this.dgvChiTietHoaDon);
            this.groupBox2.Controls.Add(this.btnLuu);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cboDichVu);
            this.groupBox2.Controls.Add(this.btnThem);
            this.groupBox2.Controls.Add(this.btnSua);
            this.groupBox2.Controls.Add(this.btnXoa);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(757, 18);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(1080, 953);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin hóa đơn";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // txtMaHDB
            // 
            this.txtMaHDB.Location = new System.Drawing.Point(865, 85);
            this.txtMaHDB.Name = "txtMaHDB";
            this.txtMaHDB.Size = new System.Drawing.Size(184, 35);
            this.txtMaHDB.TabIndex = 32;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(719, 88);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 29);
            this.label8.TabIndex = 31;
            this.label8.Text = "Mã HDB:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(34, 673);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(215, 32);
            this.label7.TabIndex = 30;
            this.label7.Text = "Thuế (VAT): 8%";
            // 
            // lblPhanTramGiam
            // 
            this.lblPhanTramGiam.AutoSize = true;
            this.lblPhanTramGiam.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhanTramGiam.Location = new System.Drawing.Point(518, 571);
            this.lblPhanTramGiam.Name = "lblPhanTramGiam";
            this.lblPhanTramGiam.Size = new System.Drawing.Size(97, 32);
            this.lblPhanTramGiam.TabIndex = 29;
            this.lblPhanTramGiam.Text = "Giảm: ";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.ForeColor = System.Drawing.Color.Yellow;
            this.btnThanhToan.IconChar = FontAwesome.Sharp.IconChar.MoneyBill1Wave;
            this.btnThanhToan.IconColor = System.Drawing.Color.Yellow;
            this.btnThanhToan.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnThanhToan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThanhToan.Location = new System.Drawing.Point(840, 854);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(190, 70);
            this.btnThanhToan.TabIndex = 28;
            this.btnThanhToan.Text = "     Thanh toán";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // cboHTTT
            // 
            this.cboHTTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboHTTT.FormattingEnabled = true;
            this.cboHTTT.Location = new System.Drawing.Point(364, 772);
            this.cboHTTT.Name = "cboHTTT";
            this.cboHTTT.Size = new System.Drawing.Size(280, 40);
            this.cboHTTT.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 775);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(284, 32);
            this.label3.TabIndex = 25;
            this.label3.Text = "Hình thức thanh toán:";
            // 
            // btnKhuyenMai
            // 
            this.btnKhuyenMai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnKhuyenMai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhuyenMai.ForeColor = System.Drawing.Color.Yellow;
            this.btnKhuyenMai.Location = new System.Drawing.Point(840, 554);
            this.btnKhuyenMai.Name = "btnKhuyenMai";
            this.btnKhuyenMai.Size = new System.Drawing.Size(190, 70);
            this.btnKhuyenMai.TabIndex = 24;
            this.btnKhuyenMai.Text = "Áp dụng";
            this.btnKhuyenMai.UseVisualStyleBackColor = false;
            this.btnKhuyenMai.Click += new System.EventHandler(this.btnKhuyenMai_Click);
            // 
            // cboKhuyenMai
            // 
            this.cboKhuyenMai.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboKhuyenMai.FormattingEnabled = true;
            this.cboKhuyenMai.Location = new System.Drawing.Point(211, 568);
            this.cboKhuyenMai.Name = "cboKhuyenMai";
            this.cboKhuyenMai.Size = new System.Drawing.Size(280, 40);
            this.cboKhuyenMai.TabIndex = 23;
            this.cboKhuyenMai.SelectedIndexChanged += new System.EventHandler(this.cboKhuyenMai_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 571);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 32);
            this.label2.TabIndex = 22;
            this.label2.Text = "Khuyến mãi:";
            // 
            // txtTongTien
            // 
            this.txtTongTien.AutoSize = true;
            this.txtTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTien.Location = new System.Drawing.Point(238, 775);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(0, 32);
            this.txtTongTien.TabIndex = 21;
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.Location = new System.Drawing.Point(33, 871);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(141, 32);
            this.lblTongTien.TabIndex = 20;
            this.lblTongTien.Text = "Tổng tiền:";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForeColor = System.Drawing.Color.Yellow;
            this.btnLamMoi.IconChar = FontAwesome.Sharp.IconChar.Sync;
            this.btnLamMoi.IconColor = System.Drawing.Color.Yellow;
            this.btnLamMoi.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLamMoi.IconSize = 30;
            this.btnLamMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLamMoi.Location = new System.Drawing.Point(916, 421);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(150, 70);
            this.btnLamMoi.TabIndex = 19;
            this.btnLamMoi.Text = "     Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.Location = new System.Drawing.Point(865, 276);
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(184, 35);
            this.nudSoLuong.TabIndex = 13;
            // 
            // dgvChiTietHoaDon
            // 
            this.dgvChiTietHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietHoaDon.Location = new System.Drawing.Point(19, 52);
            this.dgvChiTietHoaDon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvChiTietHoaDon.Name = "dgvChiTietHoaDon";
            this.dgvChiTietHoaDon.RowHeadersWidth = 62;
            this.dgvChiTietHoaDon.Size = new System.Drawing.Size(657, 339);
            this.dgvChiTietHoaDon.TabIndex = 12;
            this.dgvChiTietHoaDon.Click += new System.EventHandler(this.dgvChiTietHoaDon_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.Yellow;
            this.btnLuu.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnLuu.IconColor = System.Drawing.Color.Yellow;
            this.btnLuu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLuu.IconSize = 30;
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(696, 421);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(150, 70);
            this.btnLuu.TabIndex = 18;
            this.btnLuu.Text = "     Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(719, 278);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 29);
            this.label6.TabIndex = 11;
            this.label6.Text = "Số lượng:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(719, 185);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 29);
            this.label5.TabIndex = 10;
            this.label5.Text = "Dịch vụ:";
            // 
            // cboDichVu
            // 
            this.cboDichVu.FormattingEnabled = true;
            this.cboDichVu.Location = new System.Drawing.Point(865, 182);
            this.cboDichVu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboDichVu.Name = "cboDichVu";
            this.cboDichVu.Size = new System.Drawing.Size(184, 37);
            this.cboDichVu.TabIndex = 8;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.Yellow;
            this.btnThem.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.btnThem.IconColor = System.Drawing.Color.Yellow;
            this.btnThem.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnThem.IconSize = 30;
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(40, 421);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(150, 70);
            this.btnThem.TabIndex = 14;
            this.btnThem.Text = "     Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.Yellow;
            this.btnSua.IconChar = FontAwesome.Sharp.IconChar.Edit;
            this.btnSua.IconColor = System.Drawing.Color.Yellow;
            this.btnSua.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSua.IconSize = 30;
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSua.Location = new System.Drawing.Point(483, 421);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(150, 70);
            this.btnSua.TabIndex = 15;
            this.btnSua.Text = "     Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.Yellow;
            this.btnXoa.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.btnXoa.IconColor = System.Drawing.Color.Yellow;
            this.btnXoa.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnXoa.IconSize = 30;
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(263, 421);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(150, 70);
            this.btnXoa.TabIndex = 16;
            this.btnXoa.Text = "     Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // cboMaBan
            // 
            this.cboMaBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMaBan.FormattingEnabled = true;
            this.cboMaBan.Location = new System.Drawing.Point(1044, 1146);
            this.cboMaBan.Name = "cboMaBan";
            this.cboMaBan.Size = new System.Drawing.Size(217, 40);
            this.cboMaBan.TabIndex = 27;
            // 
            // btnInHoaDon
            // 
            this.btnInHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnInHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInHoaDon.ForeColor = System.Drawing.Color.Yellow;
            this.btnInHoaDon.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.btnInHoaDon.IconColor = System.Drawing.Color.Yellow;
            this.btnInHoaDon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnInHoaDon.Location = new System.Drawing.Point(1620, 1011);
            this.btnInHoaDon.Name = "btnInHoaDon";
            this.btnInHoaDon.Size = new System.Drawing.Size(217, 107);
            this.btnInHoaDon.TabIndex = 31;
            this.btnInHoaDon.Text = "In hóa đơn";
            this.btnInHoaDon.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInHoaDon.UseVisualStyleBackColor = false;
            this.btnInHoaDon.Click += new System.EventHandler(this.btnInHoaDon_Click);
            // 
            // btnLienHeKhachCho
            // 
            this.btnLienHeKhachCho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnLienHeKhachCho.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLienHeKhachCho.ForeColor = System.Drawing.Color.Yellow;
            this.btnLienHeKhachCho.IconChar = FontAwesome.Sharp.IconChar.Phone;
            this.btnLienHeKhachCho.IconColor = System.Drawing.Color.Yellow;
            this.btnLienHeKhachCho.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLienHeKhachCho.Location = new System.Drawing.Point(1331, 1011);
            this.btnLienHeKhachCho.Name = "btnLienHeKhachCho";
            this.btnLienHeKhachCho.Size = new System.Drawing.Size(217, 107);
            this.btnLienHeKhachCho.TabIndex = 30;
            this.btnLienHeKhachCho.Text = "Liên hệ khách chờ";
            this.btnLienHeKhachCho.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLienHeKhachCho.UseVisualStyleBackColor = false;
            this.btnLienHeKhachCho.Click += new System.EventHandler(this.btnLienHeKhachCho_Click);
            // 
            // btnChuyenBan
            // 
            this.btnChuyenBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnChuyenBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChuyenBan.ForeColor = System.Drawing.Color.Yellow;
            this.btnChuyenBan.IconChar = FontAwesome.Sharp.IconChar.ExchangeAlt;
            this.btnChuyenBan.IconColor = System.Drawing.Color.Yellow;
            this.btnChuyenBan.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnChuyenBan.Location = new System.Drawing.Point(1044, 1011);
            this.btnChuyenBan.Name = "btnChuyenBan";
            this.btnChuyenBan.Size = new System.Drawing.Size(217, 107);
            this.btnChuyenBan.TabIndex = 29;
            this.btnChuyenBan.Text = "Chuyển bàn";
            this.btnChuyenBan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnChuyenBan.UseVisualStyleBackColor = false;
            this.btnChuyenBan.Click += new System.EventHandler(this.btnChuyenBan_Click);
            // 
            // btnThemKH
            // 
            this.btnThemKH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnThemKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemKH.ForeColor = System.Drawing.Color.Yellow;
            this.btnThemKH.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.btnThemKH.IconColor = System.Drawing.Color.Yellow;
            this.btnThemKH.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnThemKH.Location = new System.Drawing.Point(757, 1011);
            this.btnThemKH.Name = "btnThemKH";
            this.btnThemKH.Size = new System.Drawing.Size(217, 107);
            this.btnThemKH.TabIndex = 28;
            this.btnThemKH.Text = "Thêm khách hàng mới";
            this.btnThemKH.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThemKH.UseVisualStyleBackColor = false;
            this.btnThemKH.Click += new System.EventHandler(this.btnThemKH_Click);
            // 
            // iconButton1
            // 
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.Location = new System.Drawing.Point(27, 1263);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(241, 118);
            this.iconButton1.TabIndex = 2;
            this.iconButton1.Text = "iconButton1";
            this.iconButton1.UseVisualStyleBackColor = true;
            // 
            // frmBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1850, 1223);
            this.Controls.Add(this.btnInHoaDon);
            this.Controls.Add(this.btnLienHeKhachCho);
            this.Controls.Add(this.btnChuyenBan);
            this.Controls.Add(this.btnThemKH);
            this.Controls.Add(this.cboMaBan);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmBanHang";
            this.Text = "frmBanHang";
            this.Load += new System.EventHandler(this.frmBanHang_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flpBanAn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboDichVu;
        private System.Windows.Forms.DataGridView dgvChiTietHoaDon;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private FontAwesome.Sharp.IconButton btnLamMoi;
        private FontAwesome.Sharp.IconButton btnLuu;
        private FontAwesome.Sharp.IconButton btnThem;
        private FontAwesome.Sharp.IconButton btnSua;
        private FontAwesome.Sharp.IconButton btnXoa;
        private System.Windows.Forms.Label txtTongTien;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Button btnKhuyenMai;
        private System.Windows.Forms.ComboBox cboKhuyenMai;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btnThanhToan;
        private System.Windows.Forms.ComboBox cboHTTT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPhanTramGiam;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboMaBan;
        private FontAwesome.Sharp.IconButton btnThemKH;
        private FontAwesome.Sharp.IconButton btnChuyenBan;
        private FontAwesome.Sharp.IconButton btnLienHeKhachCho;
        private FontAwesome.Sharp.IconButton btnInHoaDon;
        private System.Windows.Forms.TextBox txtMaHDB;
        private System.Windows.Forms.Label label8;
    }
}