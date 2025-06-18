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
    public partial class frmDoanhThu: Form
    {
        private DataTable dtDoanhThu;
        public frmDoanhThu()
        {
            InitializeComponent();
        }

        private void frmDoanhThu_Load(object sender, EventArgs e)
        {
            cboDoanhThuTheo.Items.AddRange(new string[] { "Ngày", "Tháng", "Năm" });
            cboDoanhThuTheo.SelectedIndex = 0;
            btnXuatBaoCao.Enabled = false; 
        }

        private void btnTaoBaoCao_Click(object sender, EventArgs e)
        {
            btnXuatBaoCao.Enabled = true;
            string tuyChon = cboDoanhThuTheo.SelectedItem.ToString();
            DateTime tuNgay = dtpTgBD.Value.Date;
            DateTime denNgay = dtpTgKT.Value.Date.AddDays(1).AddSeconds(-1);

            string selectDisplay = "", groupBy = "", orderBy = "", formatDisplay = "";

            switch (tuyChon)
            {
                case "Ngày":
                    selectDisplay = "CONVERT(date, ThoiGian) AS NhomThoiGian";
                    groupBy = "CONVERT(date, ThoiGian)";
                    orderBy = "NhomThoiGian";
                    formatDisplay = "dd/MM/yyyy";
                    break;
                case "Tháng":
                    selectDisplay = "FORMAT(ThoiGian, 'MM/yyyy') AS NhomThoiGian";
                    groupBy = "FORMAT(ThoiGian, 'MM/yyyy')";
                    orderBy = "NhomThoiGian";
                    formatDisplay = "MM/yyyy";
                    break;
                case "Năm":
                    selectDisplay = "YEAR(ThoiGian) AS NhomThoiGian";
                    groupBy = "YEAR(ThoiGian)";
                    orderBy = "NhomThoiGian";
                    formatDisplay = "yyyy";
                    break;
            }

            string sql = $@"
        SELECT {selectDisplay}, SUM(TongTien) AS DoanhThu
        FROM HoaDonBan
        WHERE ThoiGian BETWEEN '{tuNgay:yyyy-MM-dd}' AND '{denNgay:yyyy-MM-dd HH:mm:ss}'
        GROUP BY {groupBy}
        ORDER BY {orderBy}";

            DataTable dt = Functions.GetDataToTable(sql);

            // Vẽ biểu đồ
            chartDoanhThu.Series.Clear();
            Series series = new Series("Doanh thu");
            series.ChartType = SeriesChartType.Column;
            series.Color = System.Drawing.Color.OrangeRed;

            foreach (DataRow row in dt.Rows)
            {
                string nhom = row["NhomThoiGian"].ToString();
                double giaTri = Convert.ToDouble(row["DoanhThu"]);
                series.Points.AddXY(nhom, giaTri);
            }

            chartDoanhThu.Series.Add(series);
            chartDoanhThu.ChartAreas[0].AxisX.Title = tuyChon;
            chartDoanhThu.ChartAreas[0].AxisY.Title = "Doanh thu (VNĐ)";
            chartDoanhThu.Titles.Add("Báo cáo doanh thu");
            dtDoanhThu = Functions.GetDataToTable(sql);
        }

        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                if (chartDoanhThu.Series.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Excel._Worksheet worksheet = workbook.Sheets[1];
                worksheet.Name = "BaoCaoDoanhThu";

                int rowStart = 5;

                // --- Tiêu đề
                worksheet.Cells[1, 1] = "NHÀ HÀNG DOOKKI";
                worksheet.Cells[2, 1] = "BÁO CÁO DOANH THU";
                worksheet.Cells[3, 1] = $"Từ {dtpTgBD.Value:dd/MM/yyyy} đến {dtpTgKT.Value:dd/MM/yyyy}";

                Excel.Range title = worksheet.Range["A2", "C2"];
                title.Merge();
                title.Font.Size = 16;
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                // --- Header cột
                worksheet.Cells[rowStart, 1] = cboDoanhThuTheo.SelectedItem.ToString();
                worksheet.Cells[rowStart, 2] = "Doanh thu (VNĐ)";
                worksheet.Range["A5", "B5"].Font.Bold = true;
                worksheet.Range["A5", "B5"].Interior.Color = Color.LightGray;

                // --- Ghi dữ liệu từ chart
                Series series = chartDoanhThu.Series[0];
                for (int i = 0; i < series.Points.Count; i++)
                {
                    worksheet.Cells[rowStart + i + 1, 1] = series.Points[i].AxisLabel;
                    worksheet.Cells[rowStart + i + 1, 2] = series.Points[i].YValues[0];
                }

                // --- Định dạng bảng
                Excel.Range usedRange = worksheet.Range["A5", $"B{rowStart + series.Points.Count}"];
                usedRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                usedRange.Columns.AutoFit();

                // --- Vẽ biểu đồ
                int chartTop = (rowStart + series.Points.Count + 2) * 15;
                Excel.ChartObjects chartObjects = (Excel.ChartObjects)worksheet.ChartObjects();
                Excel.ChartObject chartObject = chartObjects.Add(50, chartTop, 500, 300);
                Excel.Chart chart = chartObject.Chart;

                Excel.Range chartRange = worksheet.Range["A5", $"B{rowStart + series.Points.Count}"];
                chart.SetSourceData(chartRange);
                chart.ChartType = Excel.XlChartType.xlColumnClustered;

                chart.HasTitle = true;
                chart.ChartTitle.Text = "Biểu đồ doanh thu";
                chart.Axes(Excel.XlAxisType.xlCategory).HasTitle = true;
                chart.Axes(Excel.XlAxisType.xlCategory).AxisTitle.Text = cboDoanhThuTheo.SelectedItem.ToString();
                chart.Axes(Excel.XlAxisType.xlValue).HasTitle = true;
                chart.Axes(Excel.XlAxisType.xlValue).AxisTitle.Text = "Doanh thu (VNĐ)";

                excelApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xuất báo cáo thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDoanhThuCaoNhat_Click(object sender, EventArgs e)
        {
            if (dtDoanhThu == null || dtDoanhThu.Rows.Count == 0)
            {
                MessageBox.Show("Bạn cần tạo báo cáo trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataRow maxRow = dtDoanhThu.AsEnumerable()
                .OrderByDescending(row => Convert.ToDouble(row["DoanhThu"]))
                .FirstOrDefault();


            if (maxRow == null)
            {
                MessageBox.Show("Không có dữ liệu doanh thu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string nhom = maxRow["NhomThoiGian"].ToString();
            double giaTri = Convert.ToDouble(maxRow["DoanhThu"]);

            chartDoanhThu.Series.Clear();
            Series series = new Series("Doanh thu cao nhất");
            series.ChartType = SeriesChartType.Column;
            series.Color = Color.Green;

            series.Points.AddXY(nhom, giaTri);

            chartDoanhThu.Series.Add(series);
            chartDoanhThu.ChartAreas[0].AxisX.Title = cboDoanhThuTheo.SelectedItem.ToString();
            chartDoanhThu.ChartAreas[0].AxisY.Title = "Doanh thu (VNĐ)";
            chartDoanhThu.Titles.Clear();
            chartDoanhThu.Titles.Add($"Doanh thu cao nhất: {giaTri:N0} VNĐ ({nhom})");
        }

    }
}
