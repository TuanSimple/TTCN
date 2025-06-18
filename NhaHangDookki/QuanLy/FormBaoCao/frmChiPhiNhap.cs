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
using System.IO;

namespace NhaHangDookki.QuanLy.FormBaoCao
{
    public partial class frmChiPhiNhap: Form
    {
        public frmChiPhiNhap()
        {
            InitializeComponent();
        }

        private void frmChiPhiNhap_Load(object sender, EventArgs e)
        {
            string sql = @"
        SELECT 
            hdn.MaHDN,
            hdn.NgayNhap,
            ncc.TenNCC,
            nv.HoTen AS NhanVienNhap,
            ISNULL(SUM(cthdn.SoLuongNhap * cthdn.DonGiaNhap), 0) AS TongTien
        FROM 
            HoaDonNhap hdn
        LEFT JOIN 
            NhanVien nv ON hdn.MaNV = nv.MaNhanVien
        LEFT JOIN 
            NhaCungCap ncc ON hdn.MaNCC = ncc.MaNCC
        LEFT JOIN 
            ChiTietHoaDonNhap cthdn ON hdn.MaHDN = cthdn.MaHDN
        GROUP BY 
            hdn.MaHDN, hdn.NgayNhap, ncc.TenNCC, nv.HoTen
        ORDER BY 
            hdn.NgayNhap DESC
    ";

            DataTable dt = Functions.GetDataToTable(sql);

            // Gán dữ liệu vào DataGridView
            dataGridViewNhapHang.DataSource = dt;

            // Reset biểu đồ
            chartNhapHang.Series.Clear();
            chartNhapHang.ChartAreas.Clear();
            chartNhapHang.Titles.Clear();

            // Tạo ChartArea
            ChartArea area = new ChartArea("Area1");
            area.AxisX.Title = "Ngày nhập";
            area.AxisY.Title = "Tổng tiền (VNĐ)";
            area.AxisX.LabelStyle.Format = "dd/MM/yyyy";
            area.AxisX.IntervalType = DateTimeIntervalType.Days;
            area.AxisX.MajorGrid.LineColor = Color.LightGray;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartNhapHang.ChartAreas.Add(area);

            // Tạo Series
            Series series = new Series("Chi phí nhập hàng");
            series.ChartType = SeriesChartType.Column; // thử đổi sang cột cho dễ nhìn
            series.XValueType = ChartValueType.Date;

            foreach (DataRow row in dt.Rows)
            {
                DateTime ngayNhap = Convert.ToDateTime(row["NgayNhap"]);
                double tongTien = row["TongTien"] != DBNull.Value ? Convert.ToDouble(row["TongTien"]) : 0;
                series.Points.AddXY(ngayNhap, tongTien);
            }

            chartNhapHang.Series.Add(series);
            chartNhapHang.Titles.Add("Báo cáo chi phí nhập hàng");
        }

        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewNhapHang.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Excel._Worksheet worksheet = workbook.Sheets[1];
                worksheet.Name = "BaoCaoChiPhiNhap";

                int rowStart = 5; // Bắt đầu ghi từ dòng 5 (dòng trên để ghi tiêu đề)

                // --- Ghi tiêu đề báo cáo
                worksheet.Cells[1, 1] = "NHÀ HÀNG DOOKKI";
                worksheet.Cells[2, 1] = "BÁO CÁO CHI PHÍ NHẬP HÀNG";
                worksheet.Cells[3, 1] = $"Ngày xuất báo cáo: {DateTime.Now:dd/MM/yyyy HH:mm}";

                Excel.Range title = worksheet.Range["A2", "E2"];
                title.Merge();
                title.Font.Size = 16;
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                // --- Ghi tiêu đề cột
                for (int i = 0; i < dataGridViewNhapHang.Columns.Count; i++)
                {
                    worksheet.Cells[rowStart, i + 1] = dataGridViewNhapHang.Columns[i].HeaderText;
                    worksheet.Cells[rowStart, i + 1].Font.Bold = true;
                    worksheet.Cells[rowStart, i + 1].Interior.Color = Color.LightGray;
                }

                // --- Ghi dữ liệu từ DataGridView
                for (int i = 0; i < dataGridViewNhapHang.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewNhapHang.Columns.Count; j++)
                    {
                        worksheet.Cells[i + rowStart + 1, j + 1] = dataGridViewNhapHang.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                // --- Format bảng dữ liệu
                Excel.Range usedRange = worksheet.Range[worksheet.Cells[rowStart, 1], worksheet.Cells[dataGridViewNhapHang.Rows.Count + rowStart, dataGridViewNhapHang.Columns.Count]];
                usedRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                usedRange.Columns.AutoFit();

                // --- Chèn biểu đồ (chart)
                int chartRow = dataGridViewNhapHang.Rows.Count + rowStart + 3;
                Excel.ChartObjects chartObjects = (Excel.ChartObjects)worksheet.ChartObjects();
                Excel.ChartObject chartObject = chartObjects.Add(50, chartRow * 15, 600, 300);
                Excel.Chart chart = chartObject.Chart;

                // Tạo bảng tạm cho biểu đồ
                int chartDataStartRow = chartRow + 20;
                worksheet.Cells[chartDataStartRow, 1] = "Ngày nhập";
                worksheet.Cells[chartDataStartRow, 2] = "Tổng tiền";

                int row = 1;
                foreach (DataGridViewRow dgRow in dataGridViewNhapHang.Rows)
                {
                    if (dgRow.Cells["NgayNhap"].Value != null && dgRow.Cells["TongTien"].Value != null)
                    {
                        worksheet.Cells[chartDataStartRow + row, 1] = Convert.ToDateTime(dgRow.Cells["NgayNhap"].Value).ToString("dd/MM/yyyy");
                        worksheet.Cells[chartDataStartRow + row, 2] = dgRow.Cells["TongTien"].Value.ToString();
                        row++;
                    }
                }

                Excel.Range chartRange = worksheet.Range[
                    worksheet.Cells[chartDataStartRow, 1],
                    worksheet.Cells[chartDataStartRow + row - 1, 2]
                ];

                chart.SetSourceData(chartRange);
                chart.ChartType = Excel.XlChartType.xlColumnClustered;
                chart.HasTitle = true;
                chart.ChartTitle.Text = "Biểu đồ chi phí nhập hàng theo ngày";
                chart.Axes(Excel.XlAxisType.xlCategory).HasTitle = true;
                chart.Axes(Excel.XlAxisType.xlCategory).AxisTitle.Text = "Ngày nhập";
                chart.Axes(Excel.XlAxisType.xlValue).HasTitle = true;
                chart.Axes(Excel.XlAxisType.xlValue).AxisTitle.Text = "Tổng tiền (VNĐ)";

                // Hiển thị Excel
                excelApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xuất báo cáo thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
