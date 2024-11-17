using System;
using System.Linq;
using System.Windows.Forms;

namespace WebBanHang
{
    public partial class DienThoai : Form
    {
        public DienThoai()
        {
            InitializeComponent();
            // Set Tag properties for each PictureBox to represent the MaSP
            pictureBox9.Tag = "SP01"; // Set the MaSP for product 1
            pictureBox10.Tag = "SP02"; // Set the MaSP for product 2
            pictureBox11.Tag = "SP03"; // Set the MaSP for product 3
            pictureBox12.Tag = "SP04"; // Set the MaSP for product 4
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
