using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace NhaHangDookki.QuanLy
{
    public partial class frmKho: Form
    {
        DataTable tblHDN;
        DataTable tblCTHDN;
        public frmKho()
        {
            InitializeComponent();
        }

        private void frmKho_Load(object sender, EventArgs e)
        {
            txtTongTien.Enabled = false;
            cboNguyenLieu.Enabled = false;
            txtMaHDN.Enabled = false;
            btnThem2.Enabled = false;
            btnXoa2.Enabled = false;
            btnSua2.Enabled = false;
            btnTimKiem2.Enabled = false;
            btnLuu1.Enabled = false;
            btnLuu2.Enabled = false;
            btnLamMoi1.Enabled = false;
            btnLamMoi2.Enabled = false;
            Load_DataGridView1();
            Functions.FillCombo("SELECT MaNhanVien, HoTen FROM NhanVien", cboNVNhap, "MaNhanVien", "HoTen");
            cboNVNhap.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaNCC, TenNCC FROM NhaCungCap", cboNhaCungCap, "MaNCC", "TenNCC");
            cboNhaCungCap.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaNL, TenNL FROM NguyenLieu", cboNguyenLieu, "MaNL", "TenNL");
            cboNguyenLieu.SelectedIndex = -1;
            ResetValues1();
            ResetValues2();
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Load_DataGridView1()
        {
            string sql;
            sql = "SELECT hd.MaHDN, nv.MaNhanVien, nv.HoTen AS TenNV, ncc.MaNCC, ncc.TenNCC, hd.NgayNhap, hd.TongTien\r\nFROM HoaDonNhap hd\r\nJOIN NhanVien nv ON hd.MaNV = nv.MaNhanVien\r\nJOIN NhaCungCap ncc ON hd.MaNCC = ncc.MaNCC\r\n";
            tblHDN = Functions.GetDataToTable(sql);
            DataGridView1.DataSource = tblHDN;
            DataGridView1.Columns["MaNhanVien"].Visible = false;
            DataGridView1.Columns["MaNCC"].Visible = false;
            DataGridView1.Columns[0].HeaderText = "Mã hóa đơn nhập";
            DataGridView1.Columns[2].HeaderText = "Nhân viên nhập";
            DataGridView1.Columns[4].HeaderText = "Nhà cung cấp";
            DataGridView1.Columns[5].HeaderText = "Ngày nhập";
            DataGridView1.Columns[6].HeaderText = "Tổng tiền";
            DataGridView1.Columns[0].Width = 100;
            DataGridView1.Columns[2].Width = 120;
            DataGridView1.Columns[4].Width = 50;
            DataGridView1.Columns[5].Width = 50;
            DataGridView1.Columns[6].Width = 50;
            DataGridView1.AllowUserToAddRows = false;
            DataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void Load_DataGridView2(string ma)
        {
            string sql;
            sql = "select b.MaNL, b.TenNL, a.SoLuongNhap, a.DonGiaNhap from ChiTietHoaDonNhap a\r\njoin NguyenLieu b on a.MaNL = b.MaNL WHERE a.MaHDN = " + ma;
            tblCTHDN = Functions.GetDataToTable(sql);
            DataGridView2.DataSource = tblCTHDN;
            DataGridView2.Columns["MaNL"].Visible = false;
            DataGridView2.Columns[1].HeaderText = "Tên nguyên liệu";
            DataGridView2.Columns[2].HeaderText = "Số lượng";
            DataGridView2.Columns[3].HeaderText = "Đơn giá";
            DataGridView2.Columns[1].Width = 50;
            DataGridView2.Columns[2].Width = 50;
            DataGridView2.Columns[3].Width = 50;
            DataGridView2.AllowUserToAddRows = false;
            DataGridView2.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void ResetValues1()
        {
            txtMaHDN.Text = "";
            dtpNgayNhap.Value = DateTime.Now;
            txtTongTien.Text = "";
            cboNVNhap.Text = "";
            cboNhaCungCap.Text = "";
        }
        private void ResetValues2()
        {
            txtSLNhap.Text = "";
            txtDonGiaNhap.Text = "";
            cboNguyenLieu.Text = "";
        }

        private void DataGridView1_Click(object sender, EventArgs e)
        {
            string manv, mancc;
            if (btnThem1.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHDN.Focus();
                return;
            }
            if (tblHDN.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaHDN.Text = DataGridView1.CurrentRow.Cells["MaHDN"].Value.ToString();
            manv = DataGridView1.CurrentRow.Cells["MaNhanVien"].Value.ToString();
            cboNVNhap.Text = Functions.GetFieldValues("SELECT HoTen FROM NhanVien WHERE MaNhanVien = N'" + manv + "'");
            mancc = DataGridView1.CurrentRow.Cells["MaNCC"].Value.ToString();
            cboNhaCungCap.Text = Functions.GetFieldValues("SELECT TenNCC FROM NhaCungCap WHERE MaNCC = N'" + mancc + "'");
            dtpNgayNhap.Value = Convert.ToDateTime(DataGridView1.CurrentRow.Cells["NgayNhap"].Value);
            txtTongTien.Text = DataGridView1.CurrentRow.Cells["TongTien"].Value.ToString();
            btnSua1.Enabled = true;
            btnXoa1.Enabled = true;
            btnThem2.Enabled = true;
            btnTimKiem2.Enabled = true;
            btnXoa2.Enabled = true;
            btnSua2.Enabled = true;
            btnTimKiem2.Enabled = true;
            btnLamMoi1.Enabled = true;
            Load_DataGridView2(txtMaHDN.Text);
        }

        private void DataGridView2_Click(object sender, EventArgs e)
        {
            string manl;
            if (btnThem2.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHDN.Focus();
                return;
            }
            if (tblCTHDN.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtSLNhap.Text = DataGridView2.CurrentRow.Cells["SoLuongNhap"].Value.ToString();
            txtDonGiaNhap.Text = DataGridView2.CurrentRow.Cells["DonGiaNhap"].Value.ToString();
            manl = DataGridView2.CurrentRow.Cells["MaNL"].Value.ToString();
            cboNguyenLieu.Text = Functions.GetFieldValues("SELECT TenNL FROM NguyenLieu WHERE MaNL = N'" + manl + "'");
            btnSua2.Enabled = true;
            btnXoa2.Enabled = true;
            btnLamMoi2.Enabled = true;
        }

        private void btnThem1_Click(object sender, EventArgs e)
        {
            btnSua1.Enabled = false;
            btnXoa1.Enabled = false;
            btnLamMoi1.Enabled = true;
            btnLuu1.Enabled = true;
            btnThem1.Enabled = false;
            ResetValues1();
            txtMaHDN.Text = Functions.GetNextIdentityValue("HoaDonNhap").ToString();
        }

        private void btnXoa1_Click(object sender, EventArgs e)
        {
            string sql1, sql2;
            if (tblHDN.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaHDN.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                //Xóa chi tiết hóa đơn nhập
                sql1 = "DELETE ChiTietHoaDonNhap WHERE MaHDN=N'" + txtMaHDN.Text + "'";
                Functions.RunSqlDel(sql1);
                sql2 = "DELETE HoaDonNhap WHERE MaHDN=N'" + txtMaHDN.Text + "'";
                Functions.RunSqlDel(sql2);
                Load_DataGridView1();
                Load_DataGridView2(txtMaHDN.Text);
                ResetValues1();
            }
        }

        private void btnSua1_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblHDN.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaHDN.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cboNVNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn nhân viên nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboNVNhap.Focus();
                return;
            }
            if (cboNhaCungCap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboNhaCungCap.Focus();
                return;
            }
            if (txtTongTien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tổng tiền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTongTien.Focus();
                return;
            }
            sql = "UPDATE HoaDonNhap SET MaNV=N'" + cboNVNhap.SelectedValue.ToString() +
                "',MaNCC=N'" + cboNhaCungCap.SelectedValue.ToString() +
                "',NgayNhap='" + dtpNgayNhap.Value.ToString("yyyy/MM/dd") +
                "',TongTien='" + txtTongTien.Text.Trim().ToString() +
                "' WHERE MaHDN=N'" + txtMaHDN.Text + "'";
            Functions.RunSql(sql);
            Load_DataGridView1();
            ResetValues1();
            btnLamMoi1.Enabled = false;
        }

        private void btnLuu1_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaHDN.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hoá đơn nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaHDN.Focus();
                return;
            }
            if (cboNVNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn nhân viên nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNVNhap.Focus();
                return;
            }
            if (cboNhaCungCap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNhaCungCap.Focus();
                return;
            }
            sql = "SELECT MaHDN FROM HoaDonNhap WHERE MaHDN=N'" + txtMaHDN.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaHDN.Focus();
                txtMaHDN.Text = "";
                return;
            }
            sql = "INSERT INTO HoaDonNhap(MaNV, MaNCC, NgayNhap) VALUES (N'" + cboNVNhap.SelectedValue.ToString() +
                "',N'" + cboNhaCungCap.SelectedValue.ToString() +
                "','" + dtpNgayNhap.Value.ToString("yyyy/MM/dd") + "')";
            Functions.RunSql(sql);
            Load_DataGridView1();
            ResetValues1();
            btnXoa1.Enabled = true;
            btnThem1.Enabled = true;
            btnSua1.Enabled = true;
            btnLamMoi1.Enabled = false;
            btnLuu1.Enabled = false;
            txtMaHDN.Enabled = false;
        }

        private void btnTimKiem1_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaHDN.Text == "") &&
                (cboNVNhap.Text == "") &&
                (cboNhaCungCap.Text == "") &&
                (dtpNgayNhap.Checked == false) &&
                (txtTongTien.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM HoaDonNhap WHERE 1=1";
            if (txtMaHDN.Text != "")
                sql = sql + " AND MaHDN LIKE N'%" + txtMaHDN.Text + "%'";
            if (cboNVNhap.Text != "")
                sql = sql + " AND MaNV LIKE N'%" + cboNVNhap.SelectedValue.ToString() + "%'";
            if (cboNhaCungCap.Text != "")
                sql = sql + " AND MaNCC LIKE N'%" + cboNhaCungCap.SelectedValue.ToString() + "%'";
            if (dtpNgayNhap.Checked == true)
                sql = sql + " AND NgayNhap = '" + dtpNgayNhap.Value.ToString("yyyy/MM/dd") + "'";
            tblHDN = Functions.GetDataToTable(sql);
            if (tblHDN.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblHDN.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            DataGridView1.DataSource = tblHDN;
            ResetValues1();
        }

        private void btnLamMoi1_Click(object sender, EventArgs e)
        {
            ResetValues1();
            btnLamMoi1.Enabled = false;
            btnThem1.Enabled = true;
            btnXoa1.Enabled = true;
            btnSua1.Enabled = true;
            btnLuu1.Enabled = false;
            txtMaHDN.Enabled = false;
            btnThem2.Enabled = false;
            btnXoa2.Enabled = false;
            btnSua2.Enabled = false;
            btnTimKiem2.Enabled = false;
            btnLuu2.Enabled = false;
            btnLamMoi2.Enabled = false;
        }

        private void btnThem2_Click(object sender, EventArgs e)
        {
            btnSua2.Enabled = false;
            btnXoa2.Enabled = false;
            btnLamMoi2.Enabled = true;
            btnLuu2.Enabled = true;
            btnThem2.Enabled = false;
            ResetValues2();
            cboNguyenLieu.Enabled = true;
            cboNguyenLieu.Focus();
        }

        private void btnXoa2_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblCTHDN.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cboNguyenLieu.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "delete ChiTietHoaDonNhap where MaNL = (select MaNL from NguyenLieu where TenNL =N'" + cboNguyenLieu.Text + "') and MaHDN =" + txtMaHDN.Text;
                Functions.RunSqlDel(sql);
                Load_DataGridView2(txtMaHDN.Text);
                ResetValues2();
            }
        }

        private void btnSua2_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblCTHDN.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cboNguyenLieu.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtSLNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSLNhap.Focus();
                return;
            }
            if (txtDonGiaNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGiaNhap.Focus();
                return;
            }
            sql = "UPDATE ChiTietHoaDonNhap SET SoLuongNhap='" + txtSLNhap.Text.Trim().ToString() +
                "',DonGiaNhap='" + txtDonGiaNhap.Text.Trim().ToString() +
                "' WHERE MaNL=N'" + cboNguyenLieu.SelectedValue.ToString() + "'";
            Functions.RunSql(sql);
            Load_DataGridView2(txtMaHDN.Text);
            ResetValues2();
            btnLamMoi2.Enabled = false;
        }

        private void btnLuu2_Click(object sender, EventArgs e)
        {
            string sql;
            if (cboNguyenLieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn nguyên liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNguyenLieu.Focus();
                return;
            }
            if (txtSLNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSLNhap.Focus();
                return;
            }
            if (txtDonGiaNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGiaNhap.Focus();
                return;
            }
            sql = "SELECT MaNL FROM ChiTietHoaDonNhap WHERE MaHDN=N'" + txtMaHDN.Text.Trim() + "' AND MaNL=(select MaNL from NguyenLieu where TenNL =N'" + cboNguyenLieu.SelectedValue.ToString() + "')";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Nguyên liệu này đã có rồi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNguyenLieu.Focus();
                cboNguyenLieu.SelectedIndex = -1;
                return;
            }
            sql = "INSERT INTO ChiTietHoaDonNhap(MaHDN, MaNL, SoLuongNhap, DonGiaNhap) VALUES (N'" + txtMaHDN.Text.Trim() +
                "',N'" + cboNguyenLieu.SelectedValue.ToString() +
                "','" + txtSLNhap.Text.Trim() +
                "','" + txtDonGiaNhap.Text.Trim() + "')";
            Functions.RunSql(sql);
            Load_DataGridView1();
            Load_DataGridView2(txtMaHDN.Text);
            ResetValues2();
            btnXoa2.Enabled = true;
            btnThem2.Enabled = true;
            btnSua2.Enabled = true;
            btnLamMoi2.Enabled = false;
            btnLuu2.Enabled = false;
            txtMaHDN.Enabled = false;
        }

        private void btnTimKiem2_Click(object sender, EventArgs e)
        {
            string sql;
            if ((cboNguyenLieu.SelectedIndex==-1) && (txtSLNhap.Text == "") &&
                (txtDonGiaNhap.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM ChiTietHoaDonNhap WHERE 1=1";
            if (cboNguyenLieu.Text != "")
                sql = sql + " AND MaNL Like N'%" + cboNguyenLieu.SelectedValue.ToString() + "%'";
            if (txtSLNhap.Text != "")
                sql = sql + " AND SoLuongNhap Like N'%" + txtSLNhap.Text + "%'";
            if (txtDonGiaNhap.Text != "")
                sql = sql + " AND DonGiaNhap Like N'%" + txtDonGiaNhap.Text + "%'";
            tblCTHDN = Functions.GetDataToTable(sql);
            if (tblCTHDN.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblCTHDN.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            DataGridView2.DataSource = tblCTHDN;
            ResetValues2();
        }

        private void btnLamMoi2_Click(object sender, EventArgs e)
        {
            ResetValues2();
            btnLamMoi2.Enabled = false;
            btnThem2.Enabled = true;
            btnXoa2.Enabled = true;
            btnSua2.Enabled = true;
            btnLuu2.Enabled = false;
            cboNguyenLieu.Enabled = false;
        }

        private void btnXuatPhieu_Click(object sender, EventArgs e)
        {
            if (txtMaHDN.Text == "")
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn nhập để xuất phiếu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook excelBook = excelApp.Workbooks.Add(Type.Missing);
            Excel.Worksheet excelSheet = (Excel.Worksheet)excelBook.Worksheets[1];

            excelApp.Visible = false;
            excelSheet.Name = "PhieuNhapHang";

            // Tiêu đề phiếu
            excelSheet.Range["A1", "E1"].Merge();
            excelSheet.Range["A1"].Value = "PHIẾU NHẬP HÀNG";
            excelSheet.Range["A1"].Font.Size = 18;
            excelSheet.Range["A1"].Font.Bold = true;
            excelSheet.Range["A1"].Font.Color = Color.DarkRed;
            excelSheet.Range["A1"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            // Thông tin chung
            excelSheet.Cells[3, 1] = "Mã hóa đơn:";
            excelSheet.Cells[3, 2] = txtMaHDN.Text;
            excelSheet.Cells[4, 1] = "Nhân viên nhập:";
            excelSheet.Cells[4, 2] = cboNVNhap.Text;
            excelSheet.Cells[5, 1] = "Nhà cung cấp:";
            excelSheet.Cells[5, 2] = cboNhaCungCap.Text;
            excelSheet.Cells[6, 1] = "Ngày nhập:";
            excelSheet.Cells[6, 2] = dtpNgayNhap.Value.ToString("dd/MM/yyyy");
            excelSheet.Cells[7, 1] = "Tổng tiền:";
            excelSheet.Cells[7, 2] = txtTongTien.Text + " VNĐ";

            // Cột tiêu đề chi tiết
            excelSheet.Cells[9, 1] = "STT";
            excelSheet.Cells[9, 2] = "Tên nguyên liệu";
            excelSheet.Cells[9, 3] = "Số lượng";
            excelSheet.Cells[9, 4] = "Đơn giá";
            excelSheet.Cells[9, 5] = "Thành tiền";

            Excel.Range headerRange = excelSheet.Range["A9", "E9"];
            headerRange.Font.Bold = true;
            headerRange.Interior.Color = Color.LightGray;
            headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            // Dữ liệu chi tiết
            double tongTien = 0;
            for (int i = 0; i < tblCTHDN.Rows.Count; i++)
            {
                excelSheet.Cells[i + 10, 1] = i + 1;
                excelSheet.Cells[i + 10, 2] = tblCTHDN.Rows[i]["TenNL"].ToString();
                excelSheet.Cells[i + 10, 3] = tblCTHDN.Rows[i]["SoLuongNhap"].ToString();
                excelSheet.Cells[i + 10, 4] = tblCTHDN.Rows[i]["DonGiaNhap"].ToString();

                double sl = Convert.ToDouble(tblCTHDN.Rows[i]["SoLuongNhap"]);
                double dg = Convert.ToDouble(tblCTHDN.Rows[i]["DonGiaNhap"]);
                double thanhTien = sl * dg;
                excelSheet.Cells[i + 10, 5] = thanhTien.ToString("N0");
                tongTien += thanhTien;
            }

            // Tự động căn chỉnh độ rộng
            excelSheet.Columns.AutoFit();

            // Hiển thị Excel
            excelApp.Visible = true;
        }

    }
}
