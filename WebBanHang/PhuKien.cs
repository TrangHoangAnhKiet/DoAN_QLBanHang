using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBanHang
{
    public partial class PhuKien : Form
    {
        public PhuKien()
        {
            InitializeComponent();
            // Set Tag properties for each PictureBox to represent the MaSP
            pictureBox9.Tag = "SP13"; // Set the MaSP for product 1
            pictureBox10.Tag = "SP14"; // Set the MaSP for product 2
            pictureBox11.Tag = "SP15"; // Set the MaSP for product 3
            pictureBox12.Tag = "SP16"; // Set the MaSP for product 4
        }

        // PictureBox click handlers
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string maSP = (sender as PictureBox).Tag.ToString();
            GioHang gioHangForm = new GioHang(maSP);
            gioHangForm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string maSP = (sender as PictureBox).Tag.ToString();
            GioHang gioHangForm = new GioHang(maSP);
            gioHangForm.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string maSP = (sender as PictureBox).Tag.ToString();
            GioHang gioHangForm = new GioHang(maSP);
            gioHangForm.Show();
        }
    }
}
