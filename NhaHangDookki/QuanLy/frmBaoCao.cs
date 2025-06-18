using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace NhaHangDookki.QuanLy
{
    public partial class frmBaoCao: Form
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
        public frmBaoCao()
        {
            InitializeComponent();
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            ActivateButton(btnDoanhThu); 
            OpenForm(new FormBaoCao.frmDoanhThu());
        }
        private void OpenForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                //open only form
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlDeskTop.Controls.Add(childForm);
            pnlDeskTop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
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
            button.TextImageRelation = TextImageRelation.ImageBeforeText;
            button.ImageAlign = ContentAlignment.MiddleLeft;
            button.Padding = new Padding(10, 0, 0, 0);
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenForm(new FormBaoCao.frmDoanhThu());
        }

        private void btnTonKho_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenForm(new FormBaoCao.frmTonKho());
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenForm(new FormBaoCao.frmChiPhiNhap());
        }
    }
}
