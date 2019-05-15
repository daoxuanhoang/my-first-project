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
    public partial class DanhSachPhuTung : Form
    {
        public DanhSachPhuTung()
        {
            InitializeComponent();
        }

        private void DanhSachPhuTung_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox9.Enabled = false;
            comboBox2.Enabled = false;


            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            load();

            comboBox2.Items.Add("Bánh Xe");
            comboBox2.Items.Add("Van Xe");
            comboBox2.Items.Add("Nhông Xích");
            comboBox2.Items.Add("Mã phanh");
            comboBox2.Items.Add("Thắng đĩa");
        }
        private void load()
        {
            DataTable dt = new DataTable("DB");
            dt.Clear();
            SqlDataAdapter da = new SqlDataAdapter("select *from PhuTung", @"Data Source=DESKTOP-QBCTLQP\HOANG;Initial Catalog=QL_XEMAY;Integrated Security=True");
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox9.Enabled = true;
            comboBox2.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox9.Text = "";
            comboBox2.Text = "";

            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           DialogResult kq = MessageBox.Show("Bạn có muốn sửa không ?", "thông báo", MessageBoxButtons.YesNo);
            if (kq == System.Windows.Forms.DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QBCTLQP\HOANG;Initial Catalog=QL_XEMAY;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("update PhuTung set MaPT ='"+textBox1.Text+"',MaXe='"+textBox9.Text+"',TenPT='"+comboBox2.Text+"',ĐVT='"+textBox2.Text+"',GiaNhap='"+textBox3.Text+"',GiaBan='"+textBox4.Text+"',SoLuongTon='"+textBox5.Text+"',GhiChu ='"+textBox6.Text+"' Where MaPT ='"+textBox1.Text+"'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                load();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn xóa không ?", "thông báo", MessageBoxButtons.YesNo);
            if (kq == System.Windows.Forms.DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QBCTLQP\HOANG;Initial Catalog=QL_XEMAY;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("delete  from PhuTung Where MaPT = '" + textBox1.Text + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                load();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Ban có muốn Lưu không ?", "thông báo", MessageBoxButtons.YesNo);
            if (kq == System.Windows.Forms.DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QBCTLQP\HOANG;Initial Catalog=QL_XEMAY;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("insert dbo.PhuTung values ('" + textBox1.Text + "','" + textBox9.Text + "','" + comboBox2.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','"+textBox6.Text+"')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                load();
                con.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;
            textBox1.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            textBox9.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.Rows[index].Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.Rows[index].Cells[6].Value.ToString();
            textBox6.Text = dataGridView1.Rows[index].Cells[7].Value.ToString();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox9.Enabled = true;
            comboBox2.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox9.Text = "";
            comboBox2.Text = "";

            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                DataTable dt = new DataTable("DB");
                dt.Clear();
                SqlDataAdapter da = new SqlDataAdapter("select *from PhuTung where MaXe like'%" + textBox7.Text + "%' ", @"Data Source=DESKTOP-QBCTLQP\HOANG;Initial Catalog=QL_XEMAY;Integrated Security=True");
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                DataTable dt = new DataTable("DB");
                dt.Clear();
                SqlDataAdapter da = new SqlDataAdapter("select *from PhuTung where TenPT like '%" + textBox8.Text + "%'", @"Data Source=DESKTOP-QBCTLQP\HOANG;Initial Catalog=QL_XEMAY;Integrated Security=True");
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
    }
}
