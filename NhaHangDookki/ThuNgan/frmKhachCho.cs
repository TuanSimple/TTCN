using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NhaHangDookki.ThuNgan
{
    public partial class frmKhachCho: Form
    {
        DataTable tblKH;
        public frmKhachCho()
        {
            InitializeComponent();
        }

        private void frmKhachCho_Load(object sender, EventArgs e)
        {
            txtMaKH.Enabled = false;
            btnLuu.Enabled = false;
            btnLamMoi.Enabled = false;
            Load_DataGridView();
            DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ResetValues();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT MaKH, TenKH, SoNguoi, SDT FROM KhachCho";
            tblKH = Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblKH;
            DataGridView.Columns[0].HeaderText = "Mã khách hàng";
            DataGridView.Columns[1].HeaderText = "Tên khách hàng";
            DataGridView.Columns[2].HeaderText = "Số người";
            DataGridView.Columns[3].HeaderText = "Số điện thoại";
            DataGridView.Columns[0].Width = 80;
            DataGridView.Columns[1].Width = 80;
            DataGridView.Columns[2].Width = 80;
            DataGridView.Columns[3].Width = 80;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ResetValues()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            nudSoNguoi.Text = "";
            txtSoDienThoai.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLamMoi.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMaKH.Text = Functions.GetCurrentTimestampID().ToString();
            txtTenKH.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaKH.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE KhachCho WHERE MaKH=N'" + txtMaKH.Text + "'";
                Functions.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaKH.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(txtTenKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKH.Focus();
                return;
            }
            if (nudSoNguoi.Value <= 0)
            {
                MessageBox.Show("Số người phải lớn hơn 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nudSoNguoi.Focus();
                return;
            }
            if (txtSoDienThoai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoDienThoai.Focus();
                return;
            }
            sql = "UPDATE KhachCho SET TenKH=N'" + txtTenKH.Text.Trim().ToString() +
                "',SoNguoi='" + nudSoNguoi.Value.ToString() +
                "',SDT='" + txtSoDienThoai.Text.Trim().ToString() +
                "' WHERE MaKH=N'" + txtMaKH.Text + "'";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnLamMoi.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKH.Focus();
                return;
            }
            if (txtTenKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKH.Focus();
                return;
            }
            if (nudSoNguoi.Value <= 0)
            {
                MessageBox.Show("Số người phải lớn hơn 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nudSoNguoi.Focus();
                return;
            }
            if (txtSoDienThoai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoDienThoai.Focus();
                return;
            }
            sql = "INSERT INTO KhachCho(TenKH, SoNguoi, SDT) VALUES (N'" + txtTenKH.Text.Trim() +
                "','" + nudSoNguoi.Value.ToString() +
                "','" + txtSoDienThoai.Text.Trim() + "')";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnLamMoi.Enabled = false;
            btnLuu.Enabled = false;
            txtMaKH.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaKH.Text == "") && (txtTenKH.Text == "") &&
                (nudSoNguoi.Value == 0) && (txtSoDienThoai.Text == ""))
            {
                MessageBox.Show("Bạn phải nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM KhachCho WHERE 1=1";
            if (txtMaKH.Text != "")
                sql += " AND MaKH LIKE N'%" + txtMaKH.Text + "%'";
            if (txtTenKH.Text != "")
                sql += " AND TenKH LIKE N'%" + txtTenKH.Text + "%'";
            if (nudSoNguoi.Value > 0)
                sql += " AND SoNguoi = " + nudSoNguoi.Value.ToString();
            if (txtSoDienThoai.Text != "")
                sql += " AND SDT LIKE N'%" + txtSoDienThoai.Text + "%'";
            tblKH = Functions.GetDataToTable(sql);
            if (tblKH.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblKH.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            DataGridView.DataSource = tblKH;
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
            txtMaKH.Enabled = false;
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKH.Focus();
                return;
            }
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaKH.Text = DataGridView.CurrentRow.Cells["MaKH"].Value.ToString();
            txtTenKH.Text = DataGridView.CurrentRow.Cells["TenKH"].Value.ToString();
            nudSoNguoi.Value = Convert.ToDecimal(DataGridView.CurrentRow.Cells["SoNguoi"].Value);
            txtSoDienThoai.Text = DataGridView.CurrentRow.Cells["SDT"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLamMoi.Enabled = true;
        }
    }
}
