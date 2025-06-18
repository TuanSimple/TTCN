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
    public partial class frmDichVu: Form
    {
        DataTable tblDV;
        public frmDichVu()
        {
            InitializeComponent();
        }

        private void frmDichVu_Load(object sender, EventArgs e)
        {
            txtMaDV.Enabled = false;
            btnLuu.Enabled = false;
            btnLamMoi.Enabled = false;
            Load_DataGridView();
            DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ResetValues();
        }

        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT MaDichVu, TenDichVu, DonGia, DonViTinh FROM DichVu";
            tblDV = Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblDV;
            DataGridView.Columns[0].HeaderText = "Mã dịch vụ";
            DataGridView.Columns[1].HeaderText = "Tên dịch vụ";
            DataGridView.Columns[2].HeaderText = "Đơn giá";
            DataGridView.Columns[3].HeaderText = "Đơn vị tính";
            DataGridView.Columns[0].Width = 100;
            DataGridView.Columns[1].Width = 100;
            DataGridView.Columns[2].Width = 100;
            DataGridView.Columns[3].Width = 100;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void ResetValues()
        {
            txtMaDV.Text = "";
            txtTenDV.Text = "";
            txtDonGia.Text = "";
            txtDonViTinh.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLamMoi.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMaDV.Text = Functions.GetNextIdentityValue("DichVu").ToString();
            txtTenDV.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblDV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaDV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE DichVu WHERE MaDichVu=N'" + txtMaDV.Text + "'";
                Functions.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblDV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaDV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenDV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên dịch vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenDV.Focus();
                return;
            }
            if (txtDonGia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập đơn giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDonGia.Focus();
                return;
            }
            if (txtDonViTinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập đơn vị tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDonViTinh.Focus();
                return;
            }
            sql = "UPDATE DichVu SET TenDichVu=N'" + txtTenDV.Text.Trim().ToString() +
                "',DonGia='" + txtDonGia.Text.Trim().ToString() +
                "',DonViTinh=N'" + txtDonViTinh.Text.Trim().ToString() +
                "' WHERE MaDichVu=N'" + txtMaDV.Text + "'";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnLamMoi.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaDV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã dịch vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaDV.Focus();
                return;
            }
            if (txtTenDV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên dịch vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenDV.Focus();
                return;
            }
            if (txtDonGia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDonGia.Focus();
                return;
            }
            if (txtDonViTinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn vị tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDonViTinh.Focus();
                return;
            }
            sql = "SELECT MaDichVu FROM DichVu WHERE MaDichVu=N'" + txtMaDV.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã dịch vụ này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaDV.Focus();
                txtMaDV.Text = "";
                return;
            }
            sql = "INSERT INTO DichVu(TenDichVu, DonGia, DonViTinh) VALUES (N'" + txtTenDV.Text.Trim() +
                "','" + txtDonGia.Text.Trim() +
                "',N'" + txtDonViTinh.Text.Trim() + "')";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnLamMoi.Enabled = false;
            btnLuu.Enabled = false;
            txtMaDV.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaDV.Text == "") && (txtTenDV.Text == "") && (txtDonGia.Text == "") && (txtDonViTinh.Text == ""))
            {
                MessageBox.Show("Bạn phải nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM DichVu WHERE 1=1";
            if (txtMaDV.Text != "")
                sql += " AND MaDichVu LIKE N'%" + txtMaDV.Text + "%'";
            if (txtTenDV.Text != "")
                sql += " AND TenDichVu LIKE N'%" + txtTenDV.Text + "%'";
            if (txtDonGia.Text != "")
                sql += " AND DonGia LIKE N'%" + txtDonGia.Text + "%'";
            if (txtDonViTinh.Text != "")
                sql += " AND DonViTinh LIKE N'%" + txtDonViTinh.Text + "%'";
            tblDV = Functions.GetDataToTable(sql);
            if (tblDV.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblDV.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            DataGridView.DataSource = tblDV;
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
            txtMaDV.Enabled = false;
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaDV.Focus();
                return;
            }
            if (tblDV.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaDV.Text = DataGridView.CurrentRow.Cells["MaDichVu"].Value.ToString();
            txtTenDV.Text = DataGridView.CurrentRow.Cells["TenDichVu"].Value.ToString();
            txtDonGia.Text = DataGridView.CurrentRow.Cells["DonGia"].Value.ToString();
            txtDonViTinh.Text = DataGridView.CurrentRow.Cells["DonViTinh"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLamMoi.Enabled = true;
        }

        private void txtTenDV_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblLuong_Click(object sender, EventArgs e)
        {

        }

        private void lblTen_Click(object sender, EventArgs e)
        {

        }

        private void lblMSSV_Click(object sender, EventArgs e)
        {

        }

        private void txtMaDV_TextChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDonViTinh_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pcbNhanVien_Click(object sender, EventArgs e)
        {

        }
    }
}
