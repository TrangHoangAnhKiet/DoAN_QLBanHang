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
    public partial class LapTop : Form
    {
         public LapTop()
        {
            InitializeComponent();
            // Set Tag properties for each PictureBox to represent the MaSP
            pictureBox9.Tag = "SP05"; // Set the MaSP for product 1
            pictureBox10.Tag = "SP06"; // Set the MaSP for product 2
            pictureBox11.Tag = "SP07"; // Set the MaSP for product 3
            pictureBox12.Tag = "SP08"; // Set the MaSP for product 4
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
            string maSP = (sender as PictureBox).Tag.ToString();
            GioHang gioHangForm = new GioHang(maSP);
            gioHangForm.Show();
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
