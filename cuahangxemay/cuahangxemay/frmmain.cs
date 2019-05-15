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
    public partial class frmmain : Form
    {
        public frmmain()
        {
            InitializeComponent();
        }
        ckn ketnoi = new ckn();
        private void thayĐổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMatKhau D = new DoiMatKhau();
            //this.Hide();
            D.ShowDialog();
            this.Show();
        }


        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhMucKhachHang kh = new DanhMucKhachHang();
            kh.ShowDialog();
            this.Show();
        }

        private void loạiXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhMucLoaiXe lx = new DanhMucLoaiXe();
            
            lx.ShowDialog();
            this.Show();
        }

        private void dangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Dangnhap m = new Dangnhap();
            //m.ShowDialog();
            this.Close();

        }

        private void phụTùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Hide();
            DanhSachPhuTung pt = new DanhSachPhuTung();
            pt.ShowDialog();
            this.Show();
        }

        private void nghiệpVụToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void BànĐợiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Hide();
            BanDoi bd = new BanDoi();
            bd.ShowDialog();
            this.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frmmain_Load(object sender, EventArgs e)
        {
            pn1.Hide();

            DataTable dt=  ketnoi.sql_select("select * from TaiKhoan ");
            dataGridView1.DataSource = dt;
        }

        private void quảnLýNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pn1.Show();
        }
        private void load()
        {
            DataTable dt = new DataTable("DB");
            dt.Clear();
            SqlDataAdapter da = new SqlDataAdapter("select *from TaiKhoan", @"Data Source=DESKTOP-QBCTLQP\HOANG;Initial Catalog=quanlybanxemay;Integrated Security=True");
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void tạoNgườiDùngMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void xóaNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txttaikhoan.Text != "")
            {
                if (txtmatkhau.Text != "")
                {
                    if (txtquyen.Text != "")
                    {
                        ketnoi.sql_insert_delete_update("insert into TaiKhoan values ('"+txttaikhoan.Text+"','"+txtmatkhau.Text+"','"+txtquyen.Text+"')");
                        button3_Click(sender, e);
                        MessageBox.Show("Đăng kí thành công","thông báo!");
                        load();
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtmatkhau.Text = txtquyen.Text = txttaikhoan.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="")
            {
                ketnoi.sql_insert_delete_update("delete TaiKhoan where TaiKhoan = '"+textBox1.Text+"'");
                load();
            }
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int vt = e.RowIndex;
                textBox1.Text = dataGridView1.Rows[vt].Cells["TaiKhoan"].Value.ToString();
            }
            catch (exception)
            {
                return;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pn1.Hide();
        }


    }
}
