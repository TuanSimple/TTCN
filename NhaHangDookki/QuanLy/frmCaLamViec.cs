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
    public partial class frmCaLamViec: Form
    {
        DataTable tblCLV;
        public frmCaLamViec()
        {
            InitializeComponent();
        }

        private void frmCaLamViec_Load(object sender, EventArgs e)
        {
            txtMaCa.Enabled = false;
            btnLuu.Enabled = false;
            btnLamMoi.Enabled = false;
            Load_DataGridView();
            DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ResetValues();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT MaCa, TenCa, GioBatDau, GioKetThuc FROM CaLamViec";
            tblCLV = Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblCLV;
            DataGridView.Columns[0].HeaderText = "Mã ca";
            DataGridView.Columns[1].HeaderText = "Tên ca";
            DataGridView.Columns[2].HeaderText = "Giờ bắt đầu";
            DataGridView.Columns[3].HeaderText = "Giờ kết thúc";
            DataGridView.Columns[0].Width = 100;
            DataGridView.Columns[1].Width = 100;
            DataGridView.Columns[2].Width = 100;
            DataGridView.Columns[3].Width = 100;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaCa.Focus();
                return;
            }
            if (tblCLV.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaCa.Text = DataGridView.CurrentRow.Cells["MaCa"].Value.ToString();
            txtTenCa.Text = DataGridView.CurrentRow.Cells["TenCa"].Value.ToString();
            mskGioBD.Text = DataGridView.CurrentRow.Cells["GioBatDau"].Value.ToString();
            mskGioKT.Text = DataGridView.CurrentRow.Cells["GioKetThuc"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLamMoi.Enabled = true;
        }
        private void ResetValues()
        {
            txtMaCa.Text = "";
            txtTenCa.Text = "";
            mskGioBD.Text = "  :";
            mskGioKT.Text = "  :";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLamMoi.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMaCa.Text = Functions.GetNextIdentityValue("CaLamViec").ToString();
            txtTenCa.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblCLV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaCa.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE CaLamViec WHERE MaCa=N'" + txtMaCa.Text + "'";
                Functions.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblCLV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaCa.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenCa.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên ca", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenCa.Focus();
                return;
            }
            if (mskGioBD.Text == "  :")
            {
                MessageBox.Show("Bạn chưa nhập giờ bắt đầu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskGioBD.Focus();
                return;
            }
            if (mskGioKT.Text == "  :")
            {
                MessageBox.Show("Bạn chưa nhập giờ kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskGioKT.Focus();
                return;
            }
            sql = "UPDATE CaLamViec SET TenCa=N'" + txtTenCa.Text.Trim().ToString() +
                "',GioBatDau='" + mskGioBD.Text.Trim().ToString() +
                "',GioKetThuc='" + mskGioKT.Text.Trim().ToString() +
                "' WHERE MaCa=N'" + txtMaCa.Text + "'";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnLamMoi.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaCa.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã ca", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaCa.Focus();
                return;
            }
            if (txtTenCa.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên ca", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenCa.Focus();
                return;
            }
            if (mskGioBD.Text == "  :")
            {
                MessageBox.Show("Bạn phải nhập giờ bắt đầu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskGioBD.Focus();
                return;
            }
            if (mskGioKT.Text == "  :")
            {
                MessageBox.Show("Bạn phải nhập giờ kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskGioKT.Focus();
                return;
            }
            if (mskGioBD.Text.Trim() == mskGioKT.Text.Trim())
            {
                MessageBox.Show("Giờ bắt đầu và giờ kết thúc không được giống nhau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskGioBD.Focus();
                return;
            }
            sql = "SELECT MaCa FROM CaLamViec WHERE MaCa=N'" + txtMaCa.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã ca này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaCa.Focus();
                txtMaCa.Text = "";
                return;
            }
            sql = "INSERT INTO CaLamViec(TenCa, GioBatDau, GioKetThuc) VALUES (N'" + txtTenCa.Text.Trim() +
                "','" + mskGioBD.Text.Trim() +
                "','" + mskGioKT.Text.Trim() + "')";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnLamMoi.Enabled = false;
            btnLuu.Enabled = false;
            txtMaCa.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaCa.Text == "") && (txtTenCa.Text == "") && (mskGioBD.Text == "  :") && (mskGioKT.Text == "  :"))
            {
                MessageBox.Show("Bạn phải nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM CaLamViec WHERE 1=1";
            if (txtMaCa.Text != "")
                sql += " AND MaCa LIKE N'%" + txtMaCa.Text + "%'";
            if (txtTenCa.Text != "")
                sql += " AND TenCa LIKE N'%" + txtTenCa.Text + "%'";
            if (mskGioBD.Text != "  :")
                sql += " AND GioBatDau LIKE N'%" + mskGioBD.Text + "%'";
            if (mskGioKT.Text != "  :")
                sql += " AND GioKetThuc LIKE N'%" + mskGioKT.Text + "%'";
            tblCLV = Functions.GetDataToTable(sql);
            if (tblCLV.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblCLV.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            DataGridView.DataSource = tblCLV;
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
            txtMaCa.Enabled = false;
        }
    }
}
