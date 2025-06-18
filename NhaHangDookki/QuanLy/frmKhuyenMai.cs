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
    public partial class frmKhuyenMai: Form
    {
        DataTable tblKM;
        public frmKhuyenMai()
        {
            InitializeComponent();
        }

        private void frmKhuyenMai_Load(object sender, EventArgs e)
        {
            txtMaKM.Enabled = false;
            btnLuu.Enabled = false;
            btnLamMoi.Enabled = false;
            Load_DataGridView();
            DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ResetValues();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT MaKM, TenKM, PhanTramGiam, DieuKien, NgayBatDau, NgayKetThuc FROM KhuyenMai";
            tblKM = Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblKM;
            DataGridView.Columns[0].HeaderText = "Mã khuyến mãi";
            DataGridView.Columns[1].HeaderText = "Tên khuyến mãi";
            DataGridView.Columns[2].HeaderText = "Phần trăm giảm";
            DataGridView.Columns[3].HeaderText = "Điều kiện";
            DataGridView.Columns[4].HeaderText = "Ngày bắt đầu";
            DataGridView.Columns[5].HeaderText = "Ngày kết thúc";
            DataGridView.Columns[0].Width = 100;
            DataGridView.Columns[1].Width = 100;
            DataGridView.Columns[2].Width = 100;
            DataGridView.Columns[3].Width = 100;
            DataGridView.Columns[4].Width = 100;
            DataGridView.Columns[5].Width = 100;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void ResetValues()
        {
            txtMaKM.Text = "";
            txtTenKM.Text = "";
            txtPhanTramGiam.Text = "";
            txtDieuKien.Text = "";
            dtpNgayBD.Value = DateTime.Now;
            dtpNgayKT.Value = DateTime.Now;
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKM.Focus();
                return;
            }
            if (tblKM.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaKM.Text = DataGridView.CurrentRow.Cells["MaKM"].Value.ToString();
            txtTenKM.Text = DataGridView.CurrentRow.Cells["TenKM"].Value.ToString();
            txtPhanTramGiam.Text = DataGridView.CurrentRow.Cells["PhanTramGiam"].Value.ToString();
            txtDieuKien.Text = DataGridView.CurrentRow.Cells["DieuKien"].Value.ToString();
            dtpNgayBD.Value = DateTime.Parse(DataGridView.CurrentRow.Cells["NgayBatDau"].Value.ToString());
            dtpNgayKT.Value = DateTime.Parse(DataGridView.CurrentRow.Cells["NgayKetThuc"].Value.ToString());
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
            txtMaKM.Text = Functions.GetNextIdentityValue("KhuyenMai").ToString();
            txtTenKM.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblKM.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaKM.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE KhuyenMai WHERE MaKM=N'" + txtMaKM.Text + "'";
                Functions.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblKM.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaKM.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenKM.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên khuyến mãi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKM.Focus();
                return;
            }
            if (txtPhanTramGiam.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập phần trăm giảm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPhanTramGiam.Focus();
                return;
            }
            if (txtDieuKien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập điều kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDieuKien.Focus();
                return;
            }
            if (dtpNgayBD.Value > dtpNgayKT.Value)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpNgayBD.Focus();
                return;
            }
            sql = "UPDATE KhuyenMai SET TenKM=N'" + txtTenKM.Text.Trim().ToString() +
                "',PhanTramGiam='" + txtPhanTramGiam.Text.Trim().ToString() +
                "',DieuKien=N'" + txtDieuKien.Text.Trim().ToString() +
                "',NgayBatDau='" + dtpNgayBD.Value.ToString("yyyy-MM-dd") +
                "',NgayKetThuc='" + dtpNgayKT.Value.ToString("yyyy-MM-dd") +
                "' WHERE MaKM=N'" + txtMaKM.Text + "'";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnLamMoi.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaKM.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã khuyến mãi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKM.Focus();
                return;
            }
            if (txtTenKM.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên khuyến mãi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKM.Focus();
                return;
            }
            if (txtPhanTramGiam.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập phần trăm giảm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPhanTramGiam.Focus();
                return;
            }
            if (txtDieuKien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập điều kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDieuKien.Focus();
                return;
            }
            if (dtpNgayBD.Value > dtpNgayKT.Value)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpNgayBD.Focus();
                return;
            }
            sql = "SELECT MaKM FROM KhuyenMai WHERE MaKM=N'" + txtMaKM.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã khuyến mãi này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKM.Focus();
                txtMaKM.Text = "";
                return;
            }
            sql = "INSERT INTO KhuyenMai(TenKM, PhanTramGiam, DieuKien, NgayBatDau, NgayKetThuc) VALUES (N'" + txtTenKM.Text.Trim() +
                "','" + txtPhanTramGiam.Text.Trim() +
                "',N'" + txtDieuKien.Text.Trim() +
                "','" + dtpNgayBD.Value.ToString("yyyy-MM-dd") +
                "','" + dtpNgayKT.Value.ToString("yyyy-MM-dd") + "')";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnLamMoi.Enabled = false;
            btnLuu.Enabled = false;
            txtMaKM.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaKM.Text == "") && (txtTenKM.Text == "") && (txtPhanTramGiam.Text == "") && (txtDieuKien.Text == ""))
            {
                MessageBox.Show("Bạn phải nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM KhuyenMai WHERE 1=1";
            if (txtMaKM.Text != "")
                sql += " AND MaKM LIKE N'%" + txtMaKM.Text + "%'";
            if (txtTenKM.Text != "")
                sql += " AND TenKM LIKE N'%" + txtTenKM.Text + "%'";
            if (txtPhanTramGiam.Text != "")
                sql += " AND PhanTramGiam LIKE N'%" + txtPhanTramGiam.Text + "%'";
            if (txtDieuKien.Text != "")
                sql += " AND DieuKien LIKE N'%" + txtDieuKien.Text + "%'";
            if (dtpNgayBD.Value != DateTime.Now)
                sql += " AND NgayBatDau = '" + dtpNgayBD.Value.ToString("yyyy-MM-dd") + "'";
            if (dtpNgayKT.Value != DateTime.Now)
                sql += " AND NgayKetThuc = '" + dtpNgayKT.Value.ToString("yyyy-MM-dd") + "'";
            tblKM = Functions.GetDataToTable(sql);
            if (tblKM.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblKM.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            DataGridView.DataSource = tblKM;
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
            txtMaKM.Enabled = false;
        }
    }
}
