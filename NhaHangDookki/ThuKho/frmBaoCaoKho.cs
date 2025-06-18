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
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart; // dùng để thêm biểu đồ
using OfficeOpenXml.Style;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Runtime.InteropServices;

namespace NhaHangDookki.ThuKho
{
    public partial class frmBaoCaoKho: Form
    {
        public frmBaoCaoKho()
        {
            InitializeComponent();
        }

        private void frmBaoCaoKho_Load(object sender, EventArgs e)
        {
            // ========================== BIỂU ĐỒ CHI PHÍ NHẬP ==========================
            string sqlNhap = @"
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

            DataTable dtNhap = Functions.GetDataToTable(sqlNhap);

            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.Titles.Clear();

            ChartArea area1 = new ChartArea("AreaNhap");
            area1.AxisX.Title = "Ngày nhập";
            area1.AxisY.Title = "Tổng tiền (VNĐ)";
            area1.AxisX.LabelStyle.Format = "dd/MM/yyyy";
            area1.AxisX.IntervalType = DateTimeIntervalType.Days;
            area1.AxisX.MajorGrid.LineColor = Color.LightGray;
            area1.AxisY.MajorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas.Add(area1);

            Series seriesNhap = new Series("Chi phí nhập hàng");
            seriesNhap.ChartType = SeriesChartType.Column;
            seriesNhap.XValueType = ChartValueType.Date;

            foreach (DataRow row in dtNhap.Rows)
            {
                DateTime ngayNhap = Convert.ToDateTime(row["NgayNhap"]);
                double tongTien = row["TongTien"] != DBNull.Value ? Convert.ToDouble(row["TongTien"]) : 0;
                seriesNhap.Points.AddXY(ngayNhap, tongTien);
            }

            chart1.Series.Add(seriesNhap);
            chart1.Titles.Add("Báo cáo chi phí nhập hàng");

            // ========================== BIỂU ĐỒ TỒN KHO (Pie Chart) ==========================
            string sqlTon = @"
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

            DataTable dtTon = Functions.GetDataToTable(sqlTon);

            chart2.Series.Clear();
            chart2.ChartAreas.Clear();
            chart2.Titles.Clear();

            ChartArea area2 = new ChartArea("AreaTonKho");
            chart2.ChartAreas.Add(area2);

            Series seriesTon = new Series("Tồn kho")
            {
                ChartType = SeriesChartType.Pie
            };

            // Thêm dữ liệu vào Pie chart
            foreach (DataRow row in dtTon.Rows)
            {
                string tenNL = row["TenNL"].ToString();
                double soLuongTon = row["SoLuongTon"] != DBNull.Value ? Convert.ToDouble(row["SoLuongTon"]) : 0;
                seriesTon.Points.AddXY(tenNL, soLuongTon);
            }

            // Hiển thị phần trăm và giá trị
            seriesTon.Label = "#VALX: #PERCENT{P1} (#VALY)";
            seriesTon.LegendText = "#VALX";

            chart2.Series.Add(seriesTon);
            chart2.Titles.Add("Tỉ lệ tồn kho nguyên liệu");
        }

        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                Excel.Application xlApp = new Excel.Application();
                if (xlApp == null)
                {
                    MessageBox.Show("Excel is not properly installed!");
                    return;
                }

                Excel.Workbook xlWorkBook = xlApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];
                xlWorkSheet.Name = "Chi phí nhập";

                // Tiêu đề
                Excel.Range title = xlWorkSheet.Range["A1", "E1"];
                title.Merge();
                title.Value2 = "BÁO CÁO CHI PHÍ NHẬP HÀNG";
                title.Font.Size = 16;
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                // Tiêu đề cột
                xlWorkSheet.Cells[3, 1] = "STT";
                xlWorkSheet.Cells[3, 2] = "Ngày nhập";
                xlWorkSheet.Cells[3, 3] = "Nhà cung cấp";
                xlWorkSheet.Cells[3, 4] = "Nhân viên nhập";
                xlWorkSheet.Cells[3, 5] = "Tổng tiền";

                // Lấy dữ liệu từ SQL (bạn giữ hàm này trong Functions)
                string sqlNhap = @"
            SELECT hdn.NgayNhap, ncc.TenNCC, nv.HoTen AS NhanVienNhap,
                ISNULL(SUM(cthdn.SoLuongNhap * cthdn.DonGiaNhap), 0) AS TongTien
            FROM HoaDonNhap hdn
            LEFT JOIN NhanVien nv ON hdn.MaNV = nv.MaNhanVien
            LEFT JOIN NhaCungCap ncc ON hdn.MaNCC = ncc.MaNCC
            LEFT JOIN ChiTietHoaDonNhap cthdn ON hdn.MaHDN = cthdn.MaHDN
            GROUP BY hdn.NgayNhap, ncc.TenNCC, nv.HoTen
            ORDER BY hdn.NgayNhap DESC";

                DataTable dt = Functions.GetDataToTable(sqlNhap);

                int row = 4;
                int stt = 1;
                foreach (DataRow r in dt.Rows)
                {
                    xlWorkSheet.Cells[row, 1] = stt++;
                    xlWorkSheet.Cells[row, 2] = Convert.ToDateTime(r["NgayNhap"]).ToString("dd/MM/yyyy");
                    xlWorkSheet.Cells[row, 3] = r["TenNCC"].ToString();
                    xlWorkSheet.Cells[row, 4] = r["NhanVienNhap"].ToString();
                    xlWorkSheet.Cells[row, 5] = Convert.ToDouble(r["TongTien"]);
                    row++;
                }

                // Định dạng cột tổng tiền
                Excel.Range rangeMoney = xlWorkSheet.Range[xlWorkSheet.Cells[4, 5], xlWorkSheet.Cells[row - 1, 5]];
                rangeMoney.NumberFormat = "#,##0";

                // Tạo bảng
                Excel.Range tableRange = xlWorkSheet.Range[xlWorkSheet.Cells[3, 1], xlWorkSheet.Cells[row - 1, 5]];
                tableRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                // Autofit cột
                xlWorkSheet.Columns.AutoFit();

                // Thêm biểu đồ cột giống chart1
                Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
                Excel.ChartObject chartObject = xlCharts.Add(300, 50, 500, 300);
                Excel.Chart chart = chartObject.Chart;

                Excel.Range xRange = xlWorkSheet.Range[xlWorkSheet.Cells[4, 2], xlWorkSheet.Cells[row - 1, 2]]; // Ngày nhập (X)
                Excel.Range yRange = xlWorkSheet.Range[xlWorkSheet.Cells[4, 5], xlWorkSheet.Cells[row - 1, 5]]; // Tổng tiền (Y)

                chart.SetSourceData(xlWorkSheet.Range[yRange.Address + "," + xRange.Address]);
                chart.ChartType = Excel.XlChartType.xlColumnClustered;
                chart.HasTitle = true;
                chart.ChartTitle.Text = "Chi phí nhập hàng theo ngày";

                chart.Axes(Excel.XlAxisType.xlCategory).HasTitle = true;
                chart.Axes(Excel.XlAxisType.xlCategory).AxisTitle.Text = "Ngày nhập";

                chart.Axes(Excel.XlAxisType.xlValue).HasTitle = true;
                chart.Axes(Excel.XlAxisType.xlValue).AxisTitle.Text = "Tổng tiền (VNĐ)";

                // Lưu file
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveFileDialog.FileName = "BaoCaoChiPhiNhap.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    xlWorkBook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                xlWorkBook.Close(false);
                xlApp.Quit();

                ReleaseObject(chart);
                ReleaseObject(chartObject);
                ReleaseObject(xlCharts);
                ReleaseObject(xRange);
                ReleaseObject(yRange);
                ReleaseObject(tableRange);
                ReleaseObject(rangeMoney);
                ReleaseObject(title);
                ReleaseObject(xlWorkSheet);
                ReleaseObject(xlWorkBook);
                ReleaseObject(xlApp);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXuatBaoCao2_Click(object sender, EventArgs e)
        {
            try
            {
                Excel.Application xlApp = new Excel.Application();
                if (xlApp == null)
                {
                    MessageBox.Show("Excel is not properly installed!");
                    return;
                }

                Excel.Workbook xlWorkBook = xlApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];
                xlWorkSheet.Name = "Tồn kho";

                // Tiêu đề
                Excel.Range title = xlWorkSheet.Range["A1", "C1"];
                title.Merge();
                title.Value2 = "BÁO CÁO TỒN KHO NGUYÊN LIỆU";
                title.Font.Size = 16;
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                // Tiêu đề cột
                xlWorkSheet.Cells[3, 1] = "STT";
                xlWorkSheet.Cells[3, 2] = "Nguyên liệu";
                xlWorkSheet.Cells[3, 3] = "Số lượng tồn";

                string sql = @"SELECT TenNL, SoLuongTon
                       FROM NguyenLieu
                       ORDER BY SoLuongTon DESC";

                DataTable dt = Functions.GetDataToTable(sql);

                int row = 4;
                int stt = 1;
                foreach (DataRow r in dt.Rows)
                {
                    xlWorkSheet.Cells[row, 1] = stt++;
                    xlWorkSheet.Cells[row, 2] = r["TenNL"].ToString();
                    xlWorkSheet.Cells[row, 3] = Convert.ToDouble(r["SoLuongTon"]);
                    row++;
                }

                // Tạo bảng với đường viền
                Excel.Range tableRange = xlWorkSheet.Range[xlWorkSheet.Cells[3, 1], xlWorkSheet.Cells[row - 1, 3]];
                tableRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                xlWorkSheet.Columns.AutoFit();

                // Thêm biểu đồ Pie chart
                Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
                Excel.ChartObject chartObject = xlCharts.Add(300, 50, 500, 300);
                Excel.Chart chart = chartObject.Chart;

                Excel.Range xRange = xlWorkSheet.Range[xlWorkSheet.Cells[4, 2], xlWorkSheet.Cells[row - 1, 2]]; // Tên nguyên liệu
                Excel.Range yRange = xlWorkSheet.Range[xlWorkSheet.Cells[4, 3], xlWorkSheet.Cells[row - 1, 3]]; // Số lượng tồn

                chart.SetSourceData(xlWorkSheet.Range[yRange.Address + "," + xRange.Address]);
                chart.ChartType = Excel.XlChartType.xlPie;
                chart.HasTitle = true;
                chart.ChartTitle.Text = "Tỉ lệ tồn kho nguyên liệu";

                chart.ApplyDataLabels(Excel.XlDataLabelsType.xlDataLabelsShowPercent | Excel.XlDataLabelsType.xlDataLabelsShowValue);

                // Lưu file
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveFileDialog.FileName = "BaoCaoTonKho.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    xlWorkBook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                xlWorkBook.Close(false);
                xlApp.Quit();

                ReleaseObject(chart);
                ReleaseObject(chartObject);
                ReleaseObject(xlCharts);
                ReleaseObject(xRange);
                ReleaseObject(yRange);
                ReleaseObject(tableRange);
                ReleaseObject(title);
                ReleaseObject(xlWorkSheet);
                ReleaseObject(xlWorkBook);
                ReleaseObject(xlApp);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void ReleaseObject(object obj)
        {
            try
            {
                if (obj != null && Marshal.IsComObject(obj))
                {
                    Marshal.ReleaseComObject(obj);
                }
            }
            catch { }
            finally
            {
                obj = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
}
