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
    public partial class DoiMatKhau : Form
    {
        public DoiMatKhau()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            txtmkht.Text = txtmkm.Text = txttaikhoan.Text = txtxn.Text = "";

        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QBCTLQP\HOANG;Initial Catalog=QL_XEMAY;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select count (*) from TaiKhoan where TaiKhoan = '"+txttaikhoan.Text+"'and MatKhau = '"+txtmkht.Text+"'",con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            errorProvider1.Clear();
            if (dt.Rows[0][0].ToString() == "1")
            {
                if (txtmkm.Text == txtxn.Text)
                {
                    if (txtmkm.Text.Length > 6)
                    {
                        SqlDataAdapter da1 = new SqlDataAdapter("update TaiKhoan set MatKhau = '" + txtmkm.Text + "' where TaiKhoan = '" + txttaikhoan.Text + "'and MatKhau = '" + txtmkht.Text + "'", con);
                        DataTable dt1 = new DataTable();
                        da1.Fill(dt1);
                        MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        errorProvider1.SetError(txtmkm,"Độ dài mật khẩu không đủ");
                    }
                }
                else
                {
                    errorProvider1.SetError(txtmkm,"Bạn chưa điền mật khẩu");
                    errorProvider1.SetError(txtxn,"Bạn nhập lại mật khẩu chưa đúng!");
                }
             }
             else
             {
                errorProvider1.SetError(txttaikhoan,"Tên người dùng không đúng");
                errorProvider1.SetError(txtmkht,"Mật khẩu hiện tại không đúng!");
             }
        }

        private void txttaikhoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttaikhoan_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void txtmkht_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void txtmkm_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void txtxn_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {

        }

        private void DoiMatKhau_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
