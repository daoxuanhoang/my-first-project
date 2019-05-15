using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace cuahangxemay
{
    public partial class Dangnhap : Form
    {
        public Dangnhap()
        {
            InitializeComponent();
            
           
        }
        int dem = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QBCTLQP\HOANG;Initial Catalog=QL_XEMAY;Integrated Security=True");
            txtmatkhau.UseSystemPasswordChar = true;
            txttaikhoan.Text = Properties.Settings.Default.Username;
            txtmatkhau.Text = Properties.Settings.Default.Password;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QBCTLQP\HOANG;Initial Catalog=QL_XEMAY;Integrated Security=True");
            try
            
            {
                if (dem <= 3)
                {
                    con.Open();
                    string user, pass;
                    user = txttaikhoan.Text;
                    pass = txtmatkhau.Text;
                    string sql = "select * from TaiKhoan where TaiKhoan = '" + user + "'and MatKhau='" + pass + "'";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataReader dta = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dta);
                    con.Close();
                    if (dt.Rows.Count != 0)
                    {
                        MessageBox.Show("Đăng nhập thành công");
                        frmmain f = new frmmain();
                        this.Hide();
                        f.ShowDialog();
                        this.Show();

                    }
                    else
                    {
                        MessageBox.Show("Đăng nhập thất bại");
                        dem++;
                    }

                }
            }
            catch (Exception)
            {
               MessageBox.Show("lỗi kết nối");
            }
            if (checkBox1.Checked)
            {
                Properties.Settings.Default.Username = txttaikhoan.Text;
                Properties.Settings.Default.Password = txtmatkhau.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.Username = "";
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.Save();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (dem > 3)
            {
                Application.Exit();
            }
        }

        private void Dangnhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát !", "Thông báo !", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
