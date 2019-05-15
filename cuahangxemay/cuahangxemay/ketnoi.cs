using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace cuahangxemay
{
    class ketnoi
    {
        public static SqlConnection con;
        public static SqlCommand cmd;


        public SqlConnection openDB()
        {
            con = new SqlConnection(@"Data Source=DESKTOP-QBCTLQP\HOANG;Initial Catalog=QL_XEMAY;Integrated Security=True");
            return con;
        }
        public static void OpenConnection()
        {
            string sql = @"Data Source=DESKTOP-QBCTLQP\HOANG;Initial Catalog=QL_XEMAY;Integrated Security=True";
            try
            {
                con = new SqlConnection(sql);
                con.Open();
            }
            catch(SqlException)
            {
                
            }
        }
        public static void Disconnection()
        {
            con.Close();
            con.Dispose();
            con = null;
        }
        public static void Excute(string sql)
        {
            cmd = new SqlCommand(sql,con);
            cmd.ExecuteNonQuery();
        }
    }
}
