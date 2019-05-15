using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cuahangxemay
{
    public partial class BanDoi : Form
    {
        public BanDoi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HoaDonBanHang m = new HoaDonBanHang();
            this.Hide();
            m.ShowDialog();
            this.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HoaDonBanHang m = new HoaDonBanHang();
            this.Hide();
            m.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HoaDonBanHang m = new HoaDonBanHang();
            this.Hide();
            m.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HoaDonBanHang m = new HoaDonBanHang();
            this.Hide();
            m.ShowDialog();
            this.Show();
        }

        private void BanDoi_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Giao dịch thành công!","Thông Báo",MessageBoxButtons.OK);
            if (kq == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
