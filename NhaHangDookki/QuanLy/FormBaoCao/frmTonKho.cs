using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Excel = Microsoft.Office.Interop.Excel;

namespace NhaHangDookki.QuanLy.FormBaoCao
{
    public partial class frmTonKho: Form
    {
        public frmTonKho()
        {
            InitializeComponent();
        }

        private void frmTonKho_Load(object sender, EventArgs e)
        {
            string sql = @"
        SELECT 
            nl.TenNL, 
            nl.SoLuongTon,
            MAX(hdn.NgayNhap) AS NgayNhapGanNhat
        FROM 
            NguyenLieu nl
        LEFT JOIN 
            ChiTietHoaDonNhap cthdn ON nl.MaNL = cthdn.MaNL
        LEFT JOIN 
            HoaDonNhap hdn ON hdn.MaHDN = cthdn.MaHDN
        GROUP BY 
            nl.TenNL, nl.SoLuongTon
        ORDER BY 
            nl.SoLuongTon DESC
    ";

            // Dùng lớp Functions để lấy dữ liệu
            DataTable dt = Functions.GetDataToTable(sql);

            // Hiển thị lên DataGridView
            dataGridViewTonKho.DataSource = dt;
            dataGridViewTonKho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Cấu hình chart hiển thị tồn kho
            chartTonKho.Series.Clear();
            Series series = new Series("Tồn kho")
            {
                ChartType = SeriesChartType.Column,
                XValueMember = "TenNL",
                YValueMembers = "SoLuongTon"
            };

            chartTonKho.Series.Add(series);
            chartTonKho.DataSource = dt;
            chartTonKho.DataBind();

            // Cấu hình trục
            chartTonKho.ChartAreas[0].AxisX.Title = "Nguyên liệu";
            chartTonKho.ChartAreas[0].AxisY.Title = "Số lượng tồn";
            chartTonKho.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chartTonKho.Titles.Add("Báo cáo tồn kho nguyên liệu");
        }

        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewTonKho.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Excel._Worksheet worksheet = workbook.Sheets[1];
                worksheet.Name = "BaoCaoTonKho";

                // --- Tiêu đề
                worksheet.Cells[1, 1] = "NHÀ HÀNG DOOKKI";
                worksheet.Cells[2, 1] = "BÁO CÁO TỒN KHO NGUYÊN LIỆU";
                worksheet.Cells[3, 1] = $"Ngày lập báo cáo: {DateTime.Now:dd/MM/yyyy HH:mm}";

                Excel.Range title = worksheet.Range["A2", "C2"];
                title.Merge();
                title.Font.Size = 16;
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                // --- Header cột
                worksheet.Cells[5, 1] = "Nguyên liệu";
                worksheet.Cells[5, 2] = "Số lượng tồn";
                worksheet.Cells[5, 3] = "Ngày nhập gần nhất";
                Excel.Range header = worksheet.Range["A5", "C5"];
                header.Font.Bold = true;
                header.Interior.Color = Color.LightGray;

                // --- Dữ liệu từ DataGridView
                int row = 6;
                foreach (DataGridViewRow dgRow in dataGridViewTonKho.Rows)
                {
                    if (!dgRow.IsNewRow)
                    {
                        worksheet.Cells[row, 1] = dgRow.Cells["TenNL"].Value?.ToString();
                        worksheet.Cells[row, 2] = dgRow.Cells["SoLuongTon"].Value?.ToString();
                        worksheet.Cells[row, 3] = dgRow.Cells["NgayNhapGanNhat"].Value?.ToString();
                        row++;
                    }
                }

                // --- Định dạng bảng
                Excel.Range dataRange = worksheet.Range["A5", $"C{row - 1}"];
                dataRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                dataRange.Columns.AutoFit();

                // --- Chèn biểu đồ từ dữ liệu
                Excel.ChartObjects chartObjects = (Excel.ChartObjects)worksheet.ChartObjects();
                Excel.ChartObject chartObject = chartObjects.Add(60, row * 15, 500, 300);
                Excel.Chart chart = chartObject.Chart;

                Excel.Range chartDataRange = worksheet.Range["A5", $"B{row - 1}"];
                chart.SetSourceData(chartDataRange);
                chart.ChartType = Excel.XlChartType.xlColumnClustered;

                chart.HasTitle = true;
                chart.ChartTitle.Text = "Biểu đồ tồn kho nguyên liệu";
                chart.Axes(Excel.XlAxisType.xlCategory).HasTitle = true;
                chart.Axes(Excel.XlAxisType.xlCategory).AxisTitle.Text = "Nguyên liệu";
                chart.Axes(Excel.XlAxisType.xlValue).HasTitle = true;
                chart.Axes(Excel.XlAxisType.xlValue).AxisTitle.Text = "Số lượng tồn";

                // --- Mở Excel
                excelApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xuất báo cáo thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
