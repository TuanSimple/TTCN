using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NhaHangDookki
{
    class Functions
    {
        public static SqlConnection conn;
        public static string Connstring;
        public static void connect()
        {
            Connstring = "Data Source=PHANANHTUAN;Initial Catalog=NHDK_final;Integrated Security=True";
            conn = new SqlConnection();
            conn.ConnectionString = Connstring;
            conn.Open();
            //MessageBox.Show("Kết nối thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void RunSql(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Connection = Functions.conn;
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();
            cmd = null;
        }
        public static DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, Functions.conn);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            return table;
        }
        public static void FillCombo(string sql, ComboBox cbo, string ma, string ten)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, Functions.conn);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            cbo.DataSource = table;

            cbo.ValueMember = ma;
            cbo.DisplayMember = ten;
        }
        public static string GetFieldValues(string sql)
        {
            string result = "";
            SqlCommand cmd = new SqlCommand(sql, Functions.conn);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = reader[0].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy vấn dữ liệu: " + ex.Message);
            }
            return result;
        }


        public static void RunSqlDel(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Functions.conn;
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception)
            {
                MessageBox.Show("Dữ liệu đang được dùng, không thể xóa...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            cmd.Dispose();
            cmd = null;
        }
        public static bool CheckKey(string sql)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, Functions.conn);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static int GetNextIdentityValue(string tableName)
        {
            int nextID = 1;
            string sql = $"SELECT IDENT_CURRENT('{tableName}') + IDENT_INCR('{tableName}')";
            SqlCommand cmd = new SqlCommand(sql, Functions.conn);
            object result = cmd.ExecuteScalar();
            if (result != DBNull.Value && result != null)
            {
                nextID = Convert.ToInt32(result);
            }
            cmd.Dispose();
            return nextID;
        }

        public static long GetCurrentTimestampID()
        {
            // Lấy thời gian hiện tại
            DateTime now = DateTime.Now;

            // Định dạng thành chuỗi yyyyMMddHHmmssfff
            string timestampStr = now.ToString("yyyyMMddHHmmssfff");

            // Chuyển thành long
            long timestampID = long.Parse(timestampStr);

            return timestampID;
        }

    }
}
