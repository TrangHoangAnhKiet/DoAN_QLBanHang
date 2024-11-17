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
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
            MessageBox.Show("Current Customer ID: " + DangNhap.currentCustomerId);

        }
        private Form currentFormChild;

        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }

            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_Body.Controls.Add(childForm);
            panel_Body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LapTop());
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DienThoai());
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PC());
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PhuKien());
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            // Pass currentCustomerId to ThongTinKH form when opening it
            ThongTinKH thongTinKH = new ThongTinKH(DangNhap.currentCustomerId);
            thongTinKH.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            // Retrieve the MaSP from the Tag property of the clicked PictureBox
            string maSP = (sender as PictureBox)?.Tag?.ToString();

            // Check if maSP is not null or empty
            if (string.IsNullOrEmpty(maSP))
            {
                MessageBox.Show("Sản phẩm không có mã hợp lệ.");
                return;  // Exit the method if MaSP is invalid
            }

            // Pass the maSP to the GioHang form constructor
            try
            {
                GioHang gioHangForm = new GioHang(maSP);
                gioHangForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi mở giỏ hàng: {ex.Message}");
            }
        }

    }
}
