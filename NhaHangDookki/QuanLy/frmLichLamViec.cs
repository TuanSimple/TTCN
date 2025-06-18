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
    public partial class frmLichLamViec: Form
    {
        DataTable tblLLV;
        public frmLichLamViec()
        {
            InitializeComponent();
        }

        private void frmLichLamViec_Load(object sender, EventArgs e)
        {
            cboNhanVien.Enabled = false;
            cboCaLamViec.Enabled = false;
            dtpNgayLamViec.Enabled = false;
            btnLuu.Enabled = false;
            btnLamMoi.Enabled = false;
            Load_DataGridView();
            Functions.FillCombo("SELECT MaNhanVien, HoTen FROM NhanVien", cboNhanVien, "MaNhanVien", "HoTen");
            Functions.FillCombo("SELECT MaCa, TenCa FROM CaLamViec", cboCaLamViec, "MaCa", "TenCa");
            cboNhanVien.SelectedIndex = -1;
            ResetValues();
            DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "select a.MaNhanVien, a.HoTen, b.MaCa, b.TenCa, c.NgayLamViec from NhanVien a join PhanCong c on a.MaNhanVien = c.MaNhanVien join CaLamViec b on c.MaCa = b.MaCa";
            tblLLV = Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblLLV;
            DataGridView.Columns["MaNhanVien"].Visible = false;
            DataGridView.Columns["MaCa"].Visible = false;
            DataGridView.Columns[1].HeaderText = "Tên nhân viên";
            DataGridView.Columns[3].HeaderText = "Tên ca làm";
            DataGridView.Columns[4].HeaderText = "Ngày làm";
            DataGridView.Columns[1].Width = 100;
            DataGridView.Columns[3].Width = 100;
            DataGridView.Columns[4].Width = 100;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void ResetValues()
        {
            cboNhanVien.Text = "";
            cboCaLamViec.Text = "";
            dtpNgayLamViec.Text = DateTime.Now.ToString();
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            string manv, maca;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tblLLV.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            manv = DataGridView.CurrentRow.Cells["MaNhanVien"].Value.ToString();
            cboNhanVien.Text = Functions.GetFieldValues("SELECT HoTen FROM NhanVien WHERE MaNhanVien = N'" + manv + "'");
            maca = DataGridView.CurrentRow.Cells["MaCa"].Value.ToString();
            cboCaLamViec.Text = Functions.GetFieldValues("SELECT TenCa FROM CaLamViec WHERE MaCa = N'" + maca + "'");
            dtpNgayLamViec.Value = Convert.ToDateTime(DataGridView.CurrentRow.Cells["NgayLamViec"].Value);
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
            cboNhanVien.Enabled = true;
            cboCaLamViec.Enabled = true;
            dtpNgayLamViec.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblLLV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cboNhanVien.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE PhanCong WHERE MaNhanVien = N'" + Functions.GetFieldValues("SELECT MaNhanVien FROM NhanVien WHERE HoTen = N'" + cboNhanVien.Text + "'") + "' AND MaCa = N'" + Functions.GetFieldValues("SELECT MaCa FROM CaLamViec WHERE TenCa = N'" + cboCaLamViec.Text + "'") + "' AND NgayLamViec = '" + dtpNgayLamViec.Value.ToString("yyyy-MM-dd") + "'";
                Functions.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblLLV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cboNhanVien.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cboCaLamViec.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn ca làm việc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "UPDATE PhanCong SET MaCa = N'" + Functions.GetFieldValues("SELECT MaCa FROM CaLamViec WHERE TenCa = N'" + cboCaLamViec.Text + "'") +
                "', NgayLamViec = '" + dtpNgayLamViec.Value.ToString("yyyy-MM-dd") +
                "' WHERE MaNhanVien = N'" + Functions.GetFieldValues("SELECT MaNhanVien FROM NhanVien WHERE HoTen = N'" + cboNhanVien.Text + "'") + "'";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnLamMoi.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (cboNhanVien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNhanVien.Focus();
                return;
            }
            if (cboCaLamViec.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn ca làm việc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCaLamViec.Focus();
                return;
            }
            sql = "SELECT MaNhanVien FROM NhanVien WHERE MaNhanVien= (select MaNhanVien from NhanVien where HoTen = N'"+cboNhanVien.Text+"') and MaCa = (select MaCa from CaLamViec where TenCa = N'" +cboCaLamViec.Text+"') and NgayLamViec = "+dtpNgayLamViec;
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Lịch làm việc này đã có, bạn phải nhập lịch khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCaLamViec.SelectedIndex=-1;
                cboNhanVien.SelectedIndex = -1;
                dtpNgayLamViec.Value = DateTime.Now;
                return;
            }
            sql = "INSERT INTO PhanCong(MaNhanVien, MaCa, NgayLamViec) VALUES (N'" + Functions.GetFieldValues("SELECT MaNhanVien FROM NhanVien WHERE HoTen = N'" + cboNhanVien.Text + "'") +
                "',N'" + Functions.GetFieldValues("SELECT MaCa FROM CaLamViec WHERE TenCa = N'" + cboCaLamViec.Text + "'") +
                "','" + dtpNgayLamViec.Value.ToString("yyyy-MM-dd") + "')";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnLamMoi.Enabled = false;
            btnLuu.Enabled = false;
            cboNhanVien.Enabled = false;
            cboCaLamViec.Enabled = false;
            dtpNgayLamViec.Enabled = false;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnLamMoi.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            cboNhanVien.Enabled = false;
            cboCaLamViec.Enabled = false;
            dtpNgayLamViec.Enabled = false;
        }
    }
}
