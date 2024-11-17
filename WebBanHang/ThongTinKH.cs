using System;
using System.Linq;
using System.Windows.Forms;

namespace WebBanHang
{
    public partial class ThongTinKH : Form
    {
        private string customerId; // This will store the passed customer ID

        public ThongTinKH(string customerId)
        {
            InitializeComponent();
            this.customerId = customerId; // Store the passed customerId
        }

        private void ThongTinKH_Load(object sender, EventArgs e)
        {
            // Debugging: Show currentCustomerId value to make sure it is passed correctly
            MessageBox.Show("Current Customer ID: " + customerId);

            // Clear any old data in the textboxes first
            txtHoTen.Clear();
            txtNgaySinh.Clear();
            txtSoDienThoai.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();

            // Fetch user details based on the current logged-in user's ID (customerId)
            using (var context = new dbQLBanHangDataContext())
            {
                // Query the customer from the database based on the current customerId
                var customer = context.KhachHangs.FirstOrDefault(kh => kh.MaKH == customerId);

                if (customer != null)
                {
                    // HoTen (Full Name) - Show only if not NULL or empty
                    txtHoTen.Text = string.IsNullOrEmpty(customer.HoTen) ? "Chưa có tên" : customer.HoTen;

                    // NgaySinh (Date of Birth) - Show only if not NULL
                    txtNgaySinh.Text = customer.NgaySinh.HasValue ? customer.NgaySinh.Value.ToString("yyyy-MM-dd") : "Chưa có ngày sinh";

                    // SoDienThoai (Phone Number) - Show only if not NULL or empty
                    txtSoDienThoai.Text = string.IsNullOrEmpty(customer.SoDienThoai) ? "Chưa có số điện thoại" : customer.SoDienThoai;

                    // Email - Make sure it's read-only and show only if not NULL or empty
                    txtEmail.Text = string.IsNullOrEmpty(customer.Email) ? "Chưa có email" : customer.Email;
                    txtEmail.ReadOnly = true; // Email should be read-only

                    // DiaChi (Address) - Show only if not NULL or empty
                    txtDiaChi.Text = string.IsNullOrEmpty(customer.DiaChi) ? "Chưa có địa chỉ" : customer.DiaChi;
                }
                else
                {
                    // Show a message if no customer is found
                    MessageBox.Show("Khách hàng không tồn tại.");
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new dbQLBanHangDataContext())
                {
                    // Retrieve the customer based on the current customerId (MaKH)
                    var customer = context.KhachHangs.FirstOrDefault(kh => kh.MaKH == customerId);

                    if (customer != null)
                    {
                        // Update the customer's information

                        // Check and assign HoTen (Full Name)
                        customer.HoTen = txtHoTen.Text;

                        // Parse the NgaySinh (Date of Birth), handle invalid date format
                        if (DateTime.TryParse(txtNgaySinh.Text, out DateTime parsedDate))
                        {
                            customer.NgaySinh = parsedDate;
                        }
                        else
                        {
                            MessageBox.Show("Ngày sinh không hợp lệ. Vui lòng nhập lại.");
                            return;  // Exit the update method if date is invalid
                        }

                        // Update phone number and address
                        customer.SoDienThoai = txtSoDienThoai.Text;
                        customer.DiaChi = txtDiaChi.Text;

                        // Save changes to the database
                        context.SubmitChanges();
                        MessageBox.Show("Cập nhật thông tin thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Khách hàng không tồn tại.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Catch any unexpected exceptions
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Navigate back to User form
            User user = new User();
            user.Show();
            this.Close();
        }
    }
}
