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
    public partial class DanhMucKhachHang : Form
    {
        public DanhMucKhachHang()
        {
            InitializeComponent();
            textBox1.Focus();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void DanhMucKhachHang_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            maskedTextBox1.Enabled = false;
            textBox7.Enabled = false;

            btluu.Enabled = false;
            btsua.Enabled = false;
            btxoa.Enabled = false;
            load();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btthemmoi_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            maskedTextBox1.Enabled = true;
            textBox7.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            maskedTextBox1.Text = "";
            textBox7.Text = "";

            btsua.Enabled = true;
            btxoa.Enabled = true;
            btluu.Enabled = true;
        }

        void load()
        {
            DataTable dt = new DataTable("DB");
            dt.Clear();
            SqlDataAdapter da = new SqlDataAdapter("select * from Khachhang",@"Data Source=DESKTOP-QBCTLQP\HOANG;Initial Catalog=QL_XEMAY;Integrated Security=True");
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;
            textBox1.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[index].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.Rows[index].Cells[6].Value.ToString();
        }

        private void btthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btluu_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn Lưu không ?", "thông báo", MessageBoxButtons.YesNo);
            if (kq == System.Windows.Forms.DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QBCTLQP\HOANG;Initial Catalog=QL_XEMAY;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("insert dbo.Khachhang values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + maskedTextBox1.Text + "','" + textBox7.Text + "')",con);
                con.Open();
                cmd.ExecuteNonQuery();
                load();
                con.Close();
            }

        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn xóa không ?", "thông báo", MessageBoxButtons.YesNo);
            if (kq == System.Windows.Forms.DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QBCTLQP\HOANG;Initial Catalog=QL_XEMAY;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("delete from Khachhang where MaKH = '" + textBox1.Text + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                load();
            }
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            //try
            //{
            DialogResult kq = MessageBox.Show("Bạn có muốn sửa!","Thông Báo!",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(kq == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QBCTLQP\HOANG;Initial Catalog=QL_XEMAY;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("update Khachhang set MaKH ='"+textBox1.Text+"',TenKH='"+textBox2.Text+"',LoaiXe ='"+textBox3.Text+"',BienKiemSoat='"+textBox4.Text+"',SoDienThoai='"+textBox5.Text+"',NgaySuaChua='"+maskedTextBox1.Text+"',GhiChu='"+textBox7.Text+"' Where MaKH ='"+textBox1.Text+"' ", con);
                cmd.ExecuteNonQuery();
                con.Close();
                load();
            }
            //catch
            //{
                //MessageBox.Show("Lỗi!");
          // }
        }

        private void DanhMucKhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("Bạn có muốn thoát !", "Thông báo !", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes)
            //{
            //    e.Cancel = true;
            //}
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            maskedTextBox1.Enabled = true;
            textBox7.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            maskedTextBox1.Text = "";
            textBox7.Text = "";

            btxoa.Enabled = true;
            btsua.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    
    
        

        private void groupBox3_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                DataTable dt = new DataTable("DB");
                dt.Clear();
                SqlDataAdapter da = new SqlDataAdapter("select *from Khachhang where BienKiemSoat like '%" + textBox8.Text + "%'", @"Data Source=DESKTOP-QBCTLQP\HOANG;Initial Catalog=QL_XEMAY;Integrated Security=True");
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                DataTable dt = new DataTable("DB");
                dt.Clear();
                SqlDataAdapter da = new SqlDataAdapter("select *from Khachhang where TenKH like '%" + textBox9.Text + "%'", @"Data Source=DESKTOP-QBCTLQP\HOANG;Initial Catalog=QL_XEMAY;Integrated Security=True");
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
    }
}
