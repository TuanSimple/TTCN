// Đảm bảo bạn đã thêm FontAwesome.Sharp vào dự án qua NuGet
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace NhaHangDookki.QuanLy
{
    public partial class frmQuanLy : Form
    {
        private Form currentChildForm;
        private IconButton currentBtn;
        private Dictionary<IconButton, string> originalButtonTexts = new Dictionary<IconButton, string>();

        private Color defaultIconColor = Color.Yellow;
        private Color defaultTextColor = Color.Yellow;
        private Color defaultButtonColor = Color.FromArgb(255, 128, 0);

        private Color activeIconColor = Color.Yellow;
        private Color activeTextColor = Color.Yellow;
        private Color activeButtonColor = Color.FromArgb(192, 0, 0);

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        public frmQuanLy()
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
        }

        private void OpenForm(Form childForm, string tenTrang)
        {
            if (currentChildForm != null) currentChildForm.Close();

            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlDeskTop.Controls.Add(childForm);
            pnlDeskTop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTieuDe.Text = tenTrang;
        }

        private void ActivateButton(object senderBtn, string tenTrang)
        {
            if (senderBtn == null) return;

            IconButton clickedBtn = (IconButton)senderBtn;

            if (currentBtn != null && currentBtn != clickedBtn)
            {
                DisableButton(currentBtn);
            }

            if (!originalButtonTexts.ContainsKey(clickedBtn))
                originalButtonTexts[clickedBtn] = clickedBtn.Text;

            currentBtn = clickedBtn;
            currentBtn.BackColor = activeButtonColor;
            currentBtn.ForeColor = activeTextColor;
            currentBtn.Text = string.Empty;
            currentBtn.IconColor = activeIconColor;
            currentBtn.ImageAlign = ContentAlignment.MiddleCenter;
            currentBtn.TextImageRelation = TextImageRelation.Overlay;
            currentBtn.Padding = new Padding(0);

            lblTieuDe.Text = tenTrang;
        }

        private void DisableButton(IconButton button)
        {
            if (button == null) return;

            button.BackColor = defaultButtonColor;
            button.ForeColor = defaultTextColor;
            if (originalButtonTexts.ContainsKey(button))
                button.Text = originalButtonTexts[button];
            button.TextAlign = ContentAlignment.MiddleCenter;
            button.IconColor = defaultIconColor;
            button.TextImageRelation = TextImageRelation.Overlay;
            button.ImageAlign = ContentAlignment.MiddleLeft;
            button.Padding = new Padding(10, 0, 0, 0);
        }

        // Các sự kiện click
        private void frmQuanLy_Load(object sender, EventArgs e)
        {
            ActivateButton(btnTK, "Trang Thông Tin Tài Khoản");
            OpenForm(new frmThongTinTK(), "Trang Thông Tin Tài Khoản");
        }

        private void btnQLNV_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, "Trang Quản Lý Nhân Viên");
            OpenForm(new frmNhanVien(), "Trang Quản Lý Nhân Viên");
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, "Trang Thông Tin Tài Khoản");
            OpenForm(new frmThongTinTK(), "Trang Thông Tin Tài Khoản");
        }

        private void btnQLBA_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, "Trang Quản Lý Bàn Ăn");
            OpenForm(new frmBanAn(), "Trang Quản Lý Bàn Ăn");
        }

        private void btnQLDV_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, "Trang Quản Lý Dịch Vụ");
            OpenForm(new frmDichVu(), "Trang Quản Lý Dịch Vụ");
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                LoginForm f = new LoginForm();
                f.Show();
            }
        }

        private void btnQLNL_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, "Trang Quản Lý Nguyên Liệu");
            OpenForm(new frmNguyenLieu(), "Trang Quản Lý Nguyên Liệu");
        }

        private void btnQLK_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, "Trang Quản Lý Kho");
            OpenForm(new frmKho(), "Trang Quản Lý Kho");
        }

        private void btnQLKM_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, "Trang Quản Lý Khuyến Mãi");
            OpenForm(new frmKhuyenMai(), "Trang Quản Lý Khuyến Mãi");
        }

        private void btnQLTK_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, "Trang Quản Lý Tài Khoản");
            OpenForm(new frmTaiKhoan(), "Trang Quản Lý Tài Khoản");
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, "Trang Quản Lý Nhà Cung Cấp");
            OpenForm(new frmNhaCungCap(), "Trang Quản Lý Nhà Cung Cấp");
        }

        private void btnLLV_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, "Trang Lịch Làm Việc");
            OpenForm(new frmLichLamViec(), "Trang Lịch Làm Việc");
        }

        private void btnCaLamViec_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, "Trang Quản Lý Ca Làm Việc");
            OpenForm(new frmCaLamViec(), "Trang Quản Lý Ca Làm Việc");
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, "Trang Báo Cáo");
            OpenForm(new frmBaoCao(), "Trang Báo Cáo");
        }

        private void pnlTieuDe_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e) => pnlTieuDe_MouseDown(sender, e);
        private void pnlDeskTop_MouseDown(object sender, MouseEventArgs e) => pnlTieuDe_MouseDown(sender, e);
        private void panel2_MouseDown(object sender, MouseEventArgs e) => pnlTieuDe_MouseDown(sender, e);
    }
}