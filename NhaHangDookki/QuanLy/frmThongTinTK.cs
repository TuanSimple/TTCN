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
    public partial class frmThongTinTK: Form
    {
        bool hidePass = true;
        public frmThongTinTK()
        {
            InitializeComponent();
        }

        private void frmThongTinTK_Load(object sender, EventArgs e)
        {
            txtMatkhau.UseSystemPasswordChar = true;
            int maNV;
            if(StaticData.MaNV!="")
            {
                 maNV = int.Parse(StaticData.MaNV);
            } else
            {
                 maNV = 1;
            }
            string sql = "select nv.MaNhanVien, nv.HoTen, tk.TenDangNhap, tk.MatKhau, cv.TenChucVu from NhanVien nv\r\njoin TaiKhoan tk on nv.MaNhanVien = tk.MaNhanVien\r\njoin ChucVu cv on nv.MaChucVu = cv.MaChucVu WHERE nv.MaNhanVien = " + maNV;
            DataTable dt = Functions.GetDataToTable(sql);

            if (dt.Rows.Count > 0)
            {
                txtMaNV.Text = dt.Rows[0]["MaNhanVien"].ToString();
                txtHoTen.Text = dt.Rows[0]["HoTen"].ToString();
                txtTenDangNhap.Text = dt.Rows[0]["TenDangNhap"].ToString();
                txtMatkhau.Text = dt.Rows[0]["MatKhau"].ToString();
                txtChucVu.Text = dt.Rows[0]["TenChucVu"].ToString();
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }

        private void txtMatkhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtChucVu_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTenDangNhap_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (hidePass)
            {
                txtMatkhau.UseSystemPasswordChar = true;
                hidePass = false;
            }
            else
            {
                txtMatkhau.UseSystemPasswordChar = false;
                hidePass = true;
            }
        }
    }
}
