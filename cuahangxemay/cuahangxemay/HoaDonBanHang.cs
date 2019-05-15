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
    public partial class HoaDonBanHang : Form
    {
        public HoaDonBanHang()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void HoaDonBanHang_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox8.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            maskedTextBox1.Enabled = false;


            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;

            comboBox1.Items.Add("81-B2 20655");
            comboBox1.Items.Add("81-B2 20656");
            comboBox1.Items.Add("81-B2 20657");
            comboBox1.Items.Add("81-B2 20658");
            comboBox2.Items.Add("Winner");
            comboBox2.Items.Add("Wave");
            comboBox2.Items.Add("Dream Lùn");
            comboBox2.Items.Add("Dream Cao");
            comboBox3.Items.Add("Bánh Xe");
            comboBox3.Items.Add("Van Xe");
            comboBox3.Items.Add("Nhông Xích");
            comboBox3.Items.Add("Mã phanh");
            comboBox3.Items.Add("Thắng đĩa");
            comboBox4.Items.Add("5%");
            comboBox4.Items.Add("10%");
            comboBox4.Items.Add("20%");
            load();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox8.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            maskedTextBox1.Enabled = true;

            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = comboBox1.Text = comboBox2.Text = comboBox3.Text = maskedTextBox1.Text = "";

            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button8.Enabled = true;

        }
        private void load()
        {
            DataTable dt = new DataTable("DB");
            dt.Clear();
            SqlDataAdapter da = new SqlDataAdapter("select *from Chitiethoadon", @"Data Source=DESKTOP-QBCTLQP\HOANG;Initial Catalog=QL_XEMAY;Integrated Security=True");
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }
        private void load1()
        {
            DataTable dt = new DataTable("DB");
            dt.Clear();
            SqlDataAdapter da = new SqlDataAdapter("select *from LichSu", @"Data Source=DESKTOP-QBCTLQP\HOANG;Initial Catalog=QL_XEMAY;Integrated Security=True");
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView2.CurrentRow.Index;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QBCTLQP\HOANG;Initial Catalog=QL_XEMAY;Integrated Security=True");
            con.Open();
            //SqlCommand cmd = new SqlCommand("insert into Chitiethoadon values @MaPT,@TenPT,@SoLuong,@DonGia,@ThanhTien,@GhiChu");
            SqlCommand cmd = new SqlCommand("insert into Chitiethoadon values ('"+comboBox1.Text+"','"+comboBox2.Text+"','"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+maskedTextBox1.Text+"','"+textBox7.Text+"','"+comboBox3.Text+"','"+textBox4.Text+"','"+textBox5.Text+"','"+textBox6.Text+"')",con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn xóa không ?", "thông báo", MessageBoxButtons.YesNo);
            if (kq == System.Windows.Forms.DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QBCTLQP\HOANG;Initial Catalog=QL_XEMAY;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("delete from Chitiethoadon where mahoadon = '" + textBox7.Text + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                load();
                load1();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn sửa không ?", "thông báo", MessageBoxButtons.YesNo);
            if (kq == System.Windows.Forms.DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QBCTLQP\HOANG;Initial Catalog=QL_XEMAY;Integrated Security=True");
                //string sqlsua = "update Chitiethoadon set MaPT =@MaPT,TenPT = @TenPT, SoLuong = @SoLuong, DonGia = @DonGia,ThanhTien = @ThanhTien,GhiChu = @GhiChu ";
                string sqlsua = "update Chitiethoadon set bienkiemsoat='" + comboBox1.Text + "',loaixe='" + comboBox2.Text + "',tenkhachhang='" + textBox1.Text + "',sodienthoai='" + textBox2.Text + "',diachi='" + textBox3.Text + "',ngaylap='" + maskedTextBox1.Text + "',mahoadon='" + textBox7.Text + "',tenphutung='" + comboBox3.Text + "',soluong='" + textBox4.Text + "',dongia='" + textBox5.Text + "',ghichu='" + textBox6.Text + "' where mahoadon='"+textBox7.Text+"'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlsua,con);
                cmd.ExecuteNonQuery();
                //cmd.Parameters.AddWithValue("SoLuong",textBox4.Text);
                //cmd.Parameters.AddWithValue("DonGia",textBox5.Text);
                load();
                load1();
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            button6.Enabled = true;
            DialogResult kq = MessageBox.Show("Ban có muốn Lưu không ?", "thông báo", MessageBoxButtons.YesNo);
            if (kq == System.Windows.Forms.DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QBCTLQP\HOANG;Initial Catalog=QL_XEMAY;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Chitiethoadon values ('" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + maskedTextBox1.Text + "','" + textBox7.Text + "','" + comboBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')", con);
                
                cmd.ExecuteNonQuery();
                load();
                load1();
                con.Close();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            BanDoi m = new BanDoi();
            this.Hide();
            m.ShowDialog();
            this.Show();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Xuất hóa đơn thành công ","Thông báo!");
            button6.Enabled = true;
        }
    }
}
