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

namespace NhaHangDookki.ThuKho
{
    public partial class frmThuKho: Form
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
        public frmThuKho()
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
            button.TextAlign = ContentAlignment.MiddleLeft;
            button.IconColor = defaultIconColor;
            button.TextImageRelation = TextImageRelation.ImageBeforeText;
            button.ImageAlign = ContentAlignment.MiddleLeft;
            button.Padding = new Padding(10, 0, 0, 0);
        }

        private void frmThuKho_Load(object sender, EventArgs e)
        {
            ActivateButton(btnTTTK);
            OpenForm(new frmThongTinTK(), "Trang Thông Tin Tài Khoản");
        }

        private void btnTTTK_Click(object sender, EventArgs e)
        {
            ActivateButton(btnTTTK);
            OpenForm(new frmThongTinTK(), "Trang Thông Tin Tài Khoản");
        }

        private void btnNguyenLieu_Click(object sender, EventArgs e)
        {
            ActivateButton(btnNguyenLieu);
            OpenForm(new frmNguyenLieu(), "Trang Nguyên Liệu");
        }

        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            ActivateButton(btnNhapKho);
            OpenForm(new frmKho(), "Trang Nhập Kho");
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            ActivateButton(btnBaoCao);
            OpenForm(new frmBaoCaoKho(), "Báo Cáo Kho");
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            ActivateButton(btnNhaCungCap);
            OpenForm(new frmNhaCungCap(), "Quản Lý Cung Cấp");
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
    }
}
