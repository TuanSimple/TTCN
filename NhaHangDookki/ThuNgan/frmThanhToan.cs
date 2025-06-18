using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NhaHangDookki.ThuNgan
{
    public partial class frmThanhToan : Form
    {
        public frmThanhToan(string maHDB, decimal tongTien)
        {
            InitializeComponent();

            lblMaHDB.Text = "Mã HĐ: " + maHDB;
            lblTongTien.Text = "Tổng tiền: " + tongTien.ToString("N0") + " VNĐ";

            // Tạo mã QR
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(maHDB, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            // Hiển thị lên PictureBox
            picQR.Image = qrCodeImage;
        }
    }
}
