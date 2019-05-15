using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace cuahangxemay
{
    class ckn
    {
        string dg = @"Data Source=DESKTOP-QBCTLQP\HOANG;Initial Catalog=QL_XEMAY;Integrated Security=True";
        public DataTable sql_select(string query)
        {
            DataTable dt = new DataTable();
            SqlConnection sql_con = new SqlConnection(dg);
            sql_con.Open();
            SqlCommand sql_com = new SqlCommand(query, sql_con);
            SqlDataReader datareader = sql_com.ExecuteReader();
            dt.Load(datareader);
            sql_con.Close();
            return dt;
        }
        public void sql_insert_delete_update(string query)
        {
            SqlConnection sql_con = new SqlConnection(dg);
            sql_con.Open();
            SqlCommand sql_com = new SqlCommand(query, sql_con);
            int tv = sql_com.ExecuteNonQuery();
            sql_con.Close();
        }
    }
}
