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
    public partial class frmNguyenLieu: Form
    {
        DataTable tblNL;
        public frmNguyenLieu()
        {
            InitializeComponent();
        }

        private void frmNguyenLieu_Load(object sender, EventArgs e)
        {
            txtMaNL.Enabled = false;
            btnLuu.Enabled = false;
            btnLamMoi.Enabled = false;
            Load_DataGridView();
            DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ResetValues();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT MaNL, TenNL, DonViTinh, SoLuongTon from NguyenLieu";
            tblNL = Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblNL;
            DataGridView.Columns[0].HeaderText = "Mã nguyên liệu";
            DataGridView.Columns[1].HeaderText = "Tên nguyên liệu";
            DataGridView.Columns[2].HeaderText = "Đơn vị tính";
            DataGridView.Columns[3].HeaderText = "Số lượng tồn";
            DataGridView.Columns[0].Width = 100;
            DataGridView.Columns[1].Width = 100;
            DataGridView.Columns[2].Width = 100;
            DataGridView.Columns[2].Width = 100;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void ResetValues()
        {
            txtMaNL.Text = "";
            txtTenNL.Text = "";
            txtDonViTinh.Text = "";
            txtSoLuongTon.Text = "";
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNL.Focus();
                return;
            }
            if (tblNL.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaNL.Text = DataGridView.CurrentRow.Cells["MaNL"].Value.ToString();
            txtTenNL.Text = DataGridView.CurrentRow.Cells["TenNL"].Value.ToString();
            txtDonViTinh.Text = DataGridView.CurrentRow.Cells["DonViTinh"].Value.ToString();
            txtSoLuongTon.Text = DataGridView.CurrentRow.Cells["SoLuongTon"].Value.ToString();
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
            txtMaNL.Text = Functions.GetNextIdentityValue("NguyenLieu").ToString();
            txtTenNL.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNL.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNL.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE NguyenLieu WHERE MaNL = '" + txtMaNL.Text.Trim() + "'";
                Functions.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNL.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNL.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenNL.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên nguyên liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNL.Focus();
                return;
            }
            if (txtDonViTinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập đơn vị tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDonViTinh.Focus();
                return;
            }
            if (txtSoLuongTon.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập số lượng tồn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuongTon.Focus();
                return;
            }
            if (MessageBox.Show("Bạn có muốn sửa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "UPDATE NguyenLieu SET TenNL=N'" + txtTenNL.Text.Trim().ToString() +
                    "',DonViTinh=N'" + txtDonViTinh.Text.Trim().ToString() +
                    "',SoLuongTon='" + txtSoLuongTon.Text.Trim().ToString() +
                    "' WHERE MaNL=N'" + txtMaNL.Text + "'";
                Functions.RunSql(sql);
                Load_DataGridView();
                ResetValues();
                btnLamMoi.Enabled = false;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaNL.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nguyên liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNL.Focus();
                return;
            }
            if (txtTenNL.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nguyên liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNL.Focus();
                return;
            }
            if (txtDonViTinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn vị tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonViTinh.Focus();
                return;
            }
            if (txtSoLuongTon.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng tồn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuongTon.Focus();
                return;
            }
            sql = "SELECT MaNL FROM NguyenLieu WHERE MaNL=N'" + txtMaNL.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã nguyên liệu này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNL.Focus();
                txtMaNL.Text = "";
                return;
            }
            sql = "INSERT INTO NguyenLieu(TenNL, DonViTinh, SoLuongTon) VALUES (N'" + txtTenNL.Text.Trim() +
                "',N'" + txtDonViTinh.Text.Trim() +
                "','" + txtSoLuongTon.Text.Trim() + "')";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnLamMoi.Enabled = false;
            btnLuu.Enabled = false;
            txtMaNL.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaNL.Text == "") && (txtTenNL.Text == "") && (txtDonViTinh.Text == "") && (txtSoLuongTon.Text == ""))
            {
                MessageBox.Show("Bạn phải nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM NguyenLieu WHERE 1=1";
            if (txtMaNL.Text != "")
                sql += " AND MaNL LIKE N'%" + txtMaNL.Text + "%'";
            if (txtTenNL.Text != "")
                sql += " AND TenNL LIKE N'%" + txtTenNL.Text + "%'";
            if (txtDonViTinh.Text != "")
                sql += " AND DonViTinh LIKE N'%" + txtDonViTinh.Text + "%'";
            if (txtSoLuongTon.Text != "")
                sql += " AND SoLuongTon LIKE N'%" + txtSoLuongTon.Text + "%'";
            tblNL = Functions.GetDataToTable(sql);
            if (tblNL.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblNL.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            DataGridView.DataSource = tblNL;
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
            txtMaNL.Enabled = false;
        }
    }
}
