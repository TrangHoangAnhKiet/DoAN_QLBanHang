using System;
using System.Linq;
using System.Windows.Forms;

namespace WebBanHang
{
    public partial class DangNhap : Form
    {
        // Class-level variable to store MaKH globally
        public static string currentCustomerId = string.Empty;

        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text;
            string password = txtMatKhau.Text;

            using (var context = new dbQLBanHangDataContext())
            {
                // Find the user in the TaiKhoan table based on username and password
                var user = context.TaiKhoans.FirstOrDefault(u => u.TenDangNhap == username && u.MatKhau == password);

                if (user != null)
                {
                    // Find the corresponding customer in KhachHang using TenDangNhap (user.TenDangNhap)
                    var customer = context.KhachHangs.FirstOrDefault(kh => kh.TaiKhoan == username);

                    if (customer != null)
                    {
                        // Store the MaKH (Customer ID) for future use
                        currentCustomerId = customer.MaKH;

                        if (user.LoaiTK == "Admin")
                        {
                            MessageBox.Show("Dang Nhap Thanh Cong voi vai tro Admin");
                            TrangChu frmAdmin = new TrangChu(); // Assuming AdminPanel is a Form
                            frmAdmin.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Dang Nhap Thanh Cong voi vai tro Nguoi Dung");
                            User frmUser = new User(); // Assuming UserPanel is a Form
                            frmUser.ShowDialog();
                        }

                        this.Hide(); // Ẩn form đăng nhập
                    }
                    else
                    {
                        MessageBox.Show("Khach hang khong ton tai.");
                    }
                }
                else
                {
                    MessageBox.Show("Dang Nhap That Bai");
                }
            }
        }

        private void lblDangKy_Click(object sender, EventArgs e)
        {
            DangKy dangKy = new DangKy();
            dangKy.ShowDialog();
            this.Hide();
        }
    }
}
