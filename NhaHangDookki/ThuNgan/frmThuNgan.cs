using FontAwesome.Sharp;
using NhaHangDookki.QuanLy;
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

namespace NhaHangDookki.ThuNgan
{
    public partial class frmThuNgan: Form
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
        public frmThuNgan()
        {
            InitializeComponent();
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
        private void ActivateButton(object senderBtn)
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

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenForm(new frmBanHang(), "Trang Bán Hàng");
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                LoginForm f = new LoginForm();
                f.Show();
            }
        }

        private void frmThuNgan_Load(object sender, EventArgs e)
        {
            ActivateButton(btnTTTK);
            OpenForm(new frmThongTinTK(), "Thông tin tài khoản");
        }

        private void btnTTTK_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenForm(new frmThongTinTK(), "Thông tin tài khoản");
        }

        private void btnQuanLyKhachCho_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenForm(new frmKhachCho(), "Quản lý khách chờ");
        }
    }
}
