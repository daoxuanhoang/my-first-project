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
    public partial class DanhMucLoaiXe : Form
    {
        public DanhMucLoaiXe()
        {
            InitializeComponent();
        }
        void load()
        {
            DataTable dt = new DataTable("DB");
            dt.Clear();
            SqlDataAdapter da = new SqlDataAdapter("select *from LoaiXe", @"Data Source=DESKTOP-QBCTLQP\HOANG;Initial Catalog=QL_XEMAY;Integrated Security=True");
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void DanhMucLoaiXe_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;

            button2.Enabled = false;
            button3.Enabled= false;
            button4.Enabled = false;
            load();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;
            textBox1.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //try
           // {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QBCTLQP\HOANG;Initial Catalog=QL_XEMAY;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("update LoaiXe set MaXe='"+textBox1.Text+"',LoaiXe ='"+textBox2.Text+"',DonGia ='"+textBox3.Text+"' where MaXe ='"+textBox1.Text+"'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                load();
            }
            //catch
            //{
               // MessageBox.Show("Lỗi!");
           // }
        //}

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn Lưu không ?", "thông báo", MessageBoxButtons.YesNo);
            if (kq == System.Windows.Forms.DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QBCTLQP\HOANG;Initial Catalog=QL_XEMAY;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("insert into LoaiXe values('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                load();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn xóa không ?", "thông báo", MessageBoxButtons.YesNo);
            if (kq == System.Windows.Forms.DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QBCTLQP\HOANG;Initial Catalog=QL_XEMAY;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("delete from LoaiXe where MaXe = '" + textBox1.Text + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                load();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

        }
    }
}
