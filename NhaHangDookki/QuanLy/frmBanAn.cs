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
    public partial class frmBanAn: Form
    {
        DataTable tblBA;
        public frmBanAn()
        {
            InitializeComponent();
        }

        private void frmBanAn_Load(object sender, EventArgs e)
        {
            cboTrangThai.SelectedIndex = -1;
            txtMaBan.Enabled = false;
            btnLuu.Enabled = false;
            btnLamMoi.Enabled = false;
            cboTrangThai.Enabled = false;
            Load_DataGridView();
            DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ResetValues();
        }

        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT MaBan, SoGhe, CASE when TrangThai = 0 then N'Trống' when TrangThai = 1 then N'Có khách' else N'Không xác định' end as TrangThai FROM BanAn";
            tblBA = Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblBA;
            DataGridView.Columns[0].HeaderText = "Mã bàn ăn";
            DataGridView.Columns[1].HeaderText = "Số ghế";
            DataGridView.Columns[2].HeaderText = "Trạng thái";
            DataGridView.Columns[0].Width = 100;
            DataGridView.Columns[1].Width = 100;
            DataGridView.Columns[2].Width = 100;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void ResetValues()
        {
            txtMaBan.Text = "";
            txtSoGhe.Text = "";
            cboTrangThai.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLamMoi.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMaBan.Text = Functions.GetNextIdentityValue("BanAn").ToString();
            txtSoGhe.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblBA.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaBan.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE BanAn WHERE MaBan=N'" + txtMaBan.Text + "'";
                Functions.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblBA.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaBan.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cboTrangThai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập trạng thái", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboTrangThai.Focus();
                return;
            }
            if (txtSoGhe.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập số ghế", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoGhe.Focus();
                return;
            }
            sql = "UPDATE BanAn SET SoGhe='" + txtSoGhe.Text.Trim().ToString() +
                "',TrangThai=N'" + cboTrangThai.Text.Trim().ToString() +
                "' WHERE MaBan=N'" + txtMaBan.Text + "'";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnLamMoi.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaBan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã bàn ăn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaBan.Focus();
                return;
            }
            if (txtSoGhe.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số ghế", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoGhe.Focus();
                return;
            }
            sql = "SELECT MaBan FROM BanAn WHERE MaBan=N'" + txtMaBan.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã bàn này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaBan.Focus();
                txtMaBan.Text = "";
                return;
            }
            sql = "INSERT INTO BanAn(SoGhe) VALUES (" + txtSoGhe.Text.Trim() + ")";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnLamMoi.Enabled = false;
            btnLuu.Enabled = false;
            txtMaBan.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaBan.Text == "") && (txtSoGhe.Text == "") && (cboTrangThai.Text == ""))
            {
                MessageBox.Show("Bạn phải nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM BanAn WHERE 1=1";
            if (txtMaBan.Text != "")
                sql += " AND MaBan LIKE N'%" + txtMaBan.Text + "%'";
            if (txtSoGhe.Text != "")
                sql += " AND SoGhe LIKE N'%" + txtSoGhe.Text + "%'";
            tblBA = Functions.GetDataToTable(sql);
            if (tblBA.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblBA.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            DataGridView.DataSource = tblBA;
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
            txtMaBan.Enabled = false;
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaBan.Focus();
                return;
            }
            if (tblBA.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaBan.Text = DataGridView.CurrentRow.Cells["MaBan"].Value.ToString();
            txtSoGhe.Text = DataGridView.CurrentRow.Cells["SoGhe"].Value.ToString();
            cboTrangThai.Text = DataGridView.CurrentRow.Cells["TrangThai"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLamMoi.Enabled = true;
        }
    }
}
