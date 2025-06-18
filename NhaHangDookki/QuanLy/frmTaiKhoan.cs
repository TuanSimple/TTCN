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
    public partial class frmTaiKhoan: Form
    {
        DataTable tblTK;
        public frmTaiKhoan()
        {
            InitializeComponent();
        }

        private void lblTen_Click(object sender, EventArgs e)
        {

        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            txtMaTK.Enabled = false;
            btnLuu.Enabled = false;
            btnLamMoi.Enabled = false;
            Load_DataGridView();
            Functions.FillCombo("SELECT MaNhanVien, HoTen FROM NhanVien", cboNhanVien, "MaNhanVien", "HoTen");
            cboNhanVien.SelectedIndex = -1;
            ResetValues();
            DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT a.MaTaiKhoan, b.MaNhanVien, b.HoTen, a.TenDangNhap, a.MatKhau from TaiKhoan a join NhanVien b on a.MaNhanVien = b.MaNhanVien";
            tblTK = Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblTK;
            DataGridView.Columns["MaNhanVien"].Visible = false;
            DataGridView.Columns[0].HeaderText = "Mã tài khoản";
            DataGridView.Columns[2].HeaderText = "Tên nhân viên";
            DataGridView.Columns[3].HeaderText = "Tên đăng nhập";
            DataGridView.Columns[4].HeaderText = "Mật khẩu";
            DataGridView.Columns[0].Width = 100;
            DataGridView.Columns[2].Width = 100;
            DataGridView.Columns[3].Width = 100;
            DataGridView.Columns[4].Width = 100;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void ResetValues()
        {
            txtMaTK.Text = "";
            txtTenDangNhap.Text = "";
            txtMatKhau.Text = "";
            cboNhanVien.SelectedIndex = -1;
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            string ma;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaTK.Focus();
                return;
            }
            if (tblTK.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaTK.Text = DataGridView.CurrentRow.Cells["MaTaiKhoan"].Value.ToString();
            ma = DataGridView.CurrentRow.Cells["MaNhanVien"].Value.ToString();
            cboNhanVien.Text = Functions.GetFieldValues("SELECT HoTen FROM NhanVien WHERE MaNhanVien = N'" + ma + "'");
            txtTenDangNhap.Text = DataGridView.CurrentRow.Cells["TenDangNhap"].Value.ToString();
            txtMatKhau.Text = DataGridView.CurrentRow.Cells["MatKhau"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLamMoi.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLamMoi.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMaTK.Text = Functions.GetNextIdentityValue("TaiKhoan").ToString();
            txtTenDangNhap.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblTK.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaTK.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE TaiKhoan WHERE MaTaiKhoan=N'" + txtMaTK.Text + "'";
                Functions.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblTK.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaTK.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenDangNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return;
            }
            if (txtMatKhau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }
            if (cboNhanVien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNhanVien.Focus();
                return;
            }
            sql = "UPDATE TaiKhoan SET TenDangNhap=N'" + txtTenDangNhap.Text.Trim().ToString() +
                "',MatKhau=N'" + txtMatKhau.Text.Trim().ToString() +
                "',MaNhanVien=N'" + cboNhanVien.SelectedValue.ToString() +
                "' WHERE MaTaiKhoan=N'" + txtMaTK.Text + "'";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnLamMoi.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaTK.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaTK.Focus();
                return;
            }
            if (txtTenDangNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return;
            }
            if (txtMatKhau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }
            if (cboNhanVien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNhanVien.Focus();
                return;
            }
            sql = "SELECT MaTaiKhoan FROM TaiKhoan WHERE MaTaiKhoan=N'" + txtMaTK.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã tài khoản này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaTK.Focus();
                txtMaTK.Text = "";
                return;
            }
            sql = "INSERT INTO TaiKhoan(TenDangNhap, MatKhau, MaNhanVien) VALUES (N'" + txtTenDangNhap.Text.Trim() +
                "',N'" + txtMatKhau.Text.Trim() +
                "',N'" + cboNhanVien.SelectedValue.ToString() + "')";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnLamMoi.Enabled = false;
            btnLuu.Enabled = false;
            txtMaTK.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaTK.Text == "") && (txtTenDangNhap.Text == "") && (txtMatKhau.Text == "") && (cboNhanVien.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM TaiKhoan WHERE 1=1";
            if (txtMaTK.Text != "")
                sql = sql + " AND MaTaiKhoan Like N'%" + txtMaTK.Text + "%'";
            if (txtTenDangNhap.Text != "")
                sql = sql + " AND TenDangNhap Like N'%" + txtTenDangNhap.Text + "%'";
            if (txtMatKhau.Text != "")
                sql = sql + " AND MatKhau Like N'%" + txtMatKhau.Text + "%'";
            if (cboNhanVien.Text != "")
                sql = sql + " AND MaNhanVien = (select MaNhanVien from NhanVien where HoTen = N'" + cboNhanVien.Text + "')";
            tblTK = Functions.GetDataToTable(sql);
            if (tblTK.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblTK.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            DataGridView.DataSource = tblTK;
            ResetValues();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnLamMoi.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaTK.Enabled = false;
        }
    }
}
