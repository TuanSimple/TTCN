using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NhaHangDookki.ThuNgan
{
    public partial class frmInHoaDon: Form
    {
        private PrintDocument printDocument = new PrintDocument();
        private string billContent = "";
        public frmInHoaDon(string billText)
        {
            InitializeComponent();
            billContent = billText;
            rtbHoaDon.Text = billContent;

            printDocument.PrintPage += PrintDocument_PrintPage;
        }


        private void btnIn_Click(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            pd.Document = printDocument;
            if (pd.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(
                billContent,
                new Font("Consolas", 10),
                Brushes.Black,
                new RectangleF(0, 0, e.MarginBounds.Width, e.MarginBounds.Height));
        }
    }
}
