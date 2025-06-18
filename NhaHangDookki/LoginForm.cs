using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using NhaHangDookki.QuanLy;
using NhaHangDookki.ThuKho;
using NhaHangDookki.ThuNgan;

namespace NhaHangDookki
{
    public partial class LoginForm: Form
    {
        bool hidePass = true;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtTaikhoan.Text == "" || txtMatkhau.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string sql = @"
SELECT tk.MaNhanVien, nv.MaChucVu
FROM TaiKhoan tk
JOIN NhanVien nv ON tk.MaNhanVien = nv.MaNhanVien
WHERE tk.TenDangNhap = N'" + txtTaikhoan.Text + @"' 
  AND tk.MatKhau = N'" + txtMatkhau.Text + @"'";

                DataTable dt = Functions.GetDataToTable(sql);

                if (dt.Rows.Count > 0)
                {
                    string maNV = dt.Rows[0]["MaNhanVien"].ToString();
                    string MaCV = dt.Rows[0]["MaChucVu"].ToString();

                    StaticData.MaNV = maNV;

                    // Đóng form đăng nhập
                    this.Hide();

                    if (MaCV == "1") // Quản lý
                    {
                        frmQuanLy frm = new frmQuanLy();
                        frm.Show();
                    }
                    else if (MaCV == "4") // Thu ngân
                    {
                        frmThuNgan frm = new frmThuNgan();
                        frm.Show();
                    }
                    else if (MaCV == "5") // Thủ kho
                    {
                        frmThuKho frm = new frmThuKho();
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Chức vụ không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }




        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
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

        private void LoginForm_Load(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtMatkhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTaikhoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
