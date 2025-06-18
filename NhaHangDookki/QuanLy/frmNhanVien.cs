using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NhaHangDookki.QuanLy
{
    public partial class frmNhanVien : Form
    {
        DataTable tblNV;
        public frmNhanVien()
        {
            InitializeComponent();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT nv.MaNhanVien, nv.HoTen, nv.GioiTinh, nv.NgaySinh, nv.QueQuan, nv.SDT, cv.MaChucVu, cv.TenChucVu, nv.Luong FROM NhanVien nv JOIN ChucVu cv ON nv.MaChucVu = cv.MaChucVu";
            tblNV = Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblNV;
            DataGridView.Columns["MaChucVu"].Visible = false;
            DataGridView.Columns[0].HeaderText = "Mã nhân viên";
            DataGridView.Columns[1].HeaderText = "Tên nhân viên";
            DataGridView.Columns[2].HeaderText = "Giới tính";
            DataGridView.Columns[3].HeaderText = "Ngày sinh";
            DataGridView.Columns[4].HeaderText = "Quê quán";
            DataGridView.Columns[5].HeaderText = "Số điện thoại";
            DataGridView.Columns[7].HeaderText = "Chức vụ";
            DataGridView.Columns[8].HeaderText = "Lương";
            DataGridView.Columns[0].Width = 80;
            DataGridView.Columns[1].Width = 100;
            DataGridView.Columns[2].Width = 80;
            DataGridView.Columns[3].Width = 80;
            DataGridView.Columns[4].Width = 80;
            DataGridView.Columns[5].Width = 80;
            DataGridView.Columns[7].Width = 80;
            DataGridView.Columns[8].Width = 80;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLamMoi.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMaNV.Text = Functions.GetNextIdentityValue("NhanVien").ToString();
            txtHoTen.Focus();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            txtMaNV.Enabled = false;
            btnLuu.Enabled = false;
            btnLamMoi.Enabled = false;
            cboGioiTinh.Items.Add("Nam");
            cboGioiTinh.Items.Add("Nữ");
            cboGioiTinh.Items.Add("Khác");
            Load_DataGridView();
            Functions.FillCombo("SELECT MaChucVu, TenChucVu FROM ChucVu", cboChucVu, "MaChucVu", "TenChucVu");
            cboChucVu.SelectedIndex = -1;
            ResetValues();
            DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void ResetValues()
        {
            txtMaNV.Text = "";
            txtHoTen.Text = "";
            cboChucVu.SelectedIndex = -1;
            cboGioiTinh.Text = "";
            dtpNgaySinh.Text = "";
            txtQueQuan.Text = "";
            txtSoDienThoai.Text = "";
            txtLuong.Text = "";
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            string ma;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNV.Focus();
                return;
            }
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaNV.Text = DataGridView.CurrentRow.Cells["MaNhanVien"].Value.ToString();
            txtHoTen.Text = DataGridView.CurrentRow.Cells["HoTen"].Value.ToString();
            ma = DataGridView.CurrentRow.Cells["MaChucVu"].Value.ToString();
            cboChucVu.Text = Functions.GetFieldValues("SELECT TenChucVu FROM ChucVu WHERE MaChucVu = N'" + ma + "'");
            cboGioiTinh.Text = DataGridView.CurrentRow.Cells["GioiTinh"].Value.ToString();
            dtpNgaySinh.Value = Convert.ToDateTime(DataGridView.CurrentRow.Cells["NgaySinh"].Value);
            txtQueQuan.Text = DataGridView.CurrentRow.Cells["QueQuan"].Value.ToString();
            txtSoDienThoai.Text = DataGridView.CurrentRow.Cells["SDT"].Value.ToString();
            txtLuong.Text = DataGridView.CurrentRow.Cells["Luong"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLamMoi.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE NhanVien WHERE MaNhanVien=N'" + txtMaNV.Text + "'";
                Functions.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtHoTen.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }
            if (cboChucVu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboChucVu.Focus();
                return;
            }
            if (cboGioiTinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboGioiTinh.Focus();
                return;
            }
            if (txtQueQuan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập quê quán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQueQuan.Focus();
                return;
            }
            if (txtSoDienThoai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return;
            }
            if (txtLuong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập lương", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLuong.Focus();
                return;
            }
            sql = "UPDATE NhanVien SET HoTen=N'" + txtHoTen.Text.Trim().ToString() +
                "',GioiTinh=N'" + cboGioiTinh.Text.Trim().ToString() +
                "',NgaySinh='" + dtpNgaySinh.Value.ToString("yyyy/MM/dd") +
                "',QueQuan=N'" + txtQueQuan.Text.Trim().ToString() +
                "',SDT='" + txtSoDienThoai.Text.Trim().ToString() +
                "',MaChucVu=N'" + cboChucVu.SelectedValue.ToString() +
                "',Luong='" + txtLuong.Text.Trim().ToString() +
                "' WHERE MaNhanVien=N'" + txtMaNV.Text + "'";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnLamMoi.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtHoTen.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }
            if (cboChucVu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboChucVu.Focus();
                return;
            }
            if (cboGioiTinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboGioiTinh.Focus();
                return;
            }
            if (txtQueQuan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập quê quán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQueQuan.Focus();
                return;
            }
            if (txtSoDienThoai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return;
            }
            if (txtLuong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập lương", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLuong.Focus();
                return;
            }
            sql = "INSERT INTO NhanVien(HoTen, GioiTinh, NgaySinh, QueQuan, SDT, MaChucVu, Luong) VALUES (N'" + txtHoTen.Text.Trim() +
                "',N'" + cboGioiTinh.Text.Trim().ToString() +
                "','" + dtpNgaySinh.Value.ToString("yyyy/MM/dd") +
                "',N'" + txtQueQuan.Text.Trim() +
                "','" + txtSoDienThoai.Text.Trim() +
                "',N'" + cboChucVu.SelectedValue.ToString() +
                "','" + txtLuong.Text.Trim() + "')";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnLamMoi.Enabled = false;
            btnLuu.Enabled = false;
            txtMaNV.Enabled = false;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnLamMoi.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaNV.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaNV.Text == "") && (txtHoTen.Text == "") && (cboChucVu.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM NhanVien WHERE 1=1";
            if (txtMaNV.Text != "")
                sql = sql + " AND MaNhanVien Like N'%" + txtMaNV.Text + "%'";
            if (txtHoTen.Text != "")
                sql = sql + " AND HoTen Like N'%" + txtHoTen.Text + "%'";
            if (cboChucVu.Text != "")
                sql = sql + " AND MaChucVu Like N'%" + cboChucVu.SelectedValue + "%'";
            if (cboGioiTinh.Text != "")
                sql = sql + " AND GioiTinh Like N'%" + cboGioiTinh.Text + "%'";
            if (txtQueQuan.Text != "")
                sql = sql + " AND QueQuan Like N'%" + txtQueQuan.Text + "%'";
            if (dtpNgaySinh.Checked)
                sql += " AND NgaySinh = '" + dtpNgaySinh.Value.ToString("yyyy-MM-dd") + "'";
            if (txtSoDienThoai.Text != "")
                sql = sql + " AND SDT Like N'%" + txtSoDienThoai.Text + "%'";
            if (txtLuong.Text != "")
                sql = sql + " AND Luong Like N'%" + txtLuong.Text + "%'";
            tblNV = Functions.GetDataToTable(sql);
            if (tblNV.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblNV.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            DataGridView.DataSource = tblNV;
            ResetValues();
        }

        private void dtpNgaySinh_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtLuong_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSoDienThoai_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQueQuan_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblMatKhau_Click(object sender, EventArgs e)
        {

        }

        private void cboChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblLoaiNV_Click(object sender, EventArgs e)
        {

        }

        private void lblLuong_Click(object sender, EventArgs e)
        {

        }

        private void lblLop_Click(object sender, EventArgs e)
        {

        }

        private void lblNgaySinh_Click(object sender, EventArgs e)
        {

        }
    }
}
