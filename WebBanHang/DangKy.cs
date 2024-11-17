using System;
using System.Linq;
using System.Windows.Forms;

namespace WebBanHang
{
    public partial class DangKy : Form
    {
        public DangKy()
        {
            InitializeComponent();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            string username = TXT_TenDangKy.Text.Trim();
            string password = TXT_MatKhau.Text.Trim();
            string email = TXT_Email.Text.Trim();

            // Check if any required fields are empty
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            // Check if email format is valid
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Địa chỉ email không hợp lệ.");
                return;
            }

            try
            {
                using (var context = new dbQLBanHangDataContext())
                {
                    // Check if username already exists in TaiKhoan
                    var existingUser = context.TaiKhoans.FirstOrDefault(u => u.TenDangNhap == username);
                    if (existingUser != null)
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại.");
                        return;
                    }

                    // Check if email already exists in KhachHang
                    var existingEmail = context.KhachHangs.FirstOrDefault(k => k.Email == email);
                    if (existingEmail != null)
                    {
                        MessageBox.Show("Email đã tồn tại.");
                        return;
                    }

                    // Generate new MaKH (Customer ID)
                    string newMaKH = GenerateNewMaKH(context);

                    // Add new record to KhachHang table
                    var newCustomer = new KhachHang
                    {
                        MaKH = newMaKH,
                        Email = email,
                        TaiKhoan = username // Store the username (TenDangNhap) in the KhachHang table
                    };

                    context.KhachHangs.InsertOnSubmit(newCustomer);

                    // Add new record to TaiKhoan table
                    var newUser = new TaiKhoan
                    {
                        TenDangNhap = username,
                        MatKhau = password, // Consider hashing for security
                        LoaiTK = "User" // Default role is "User"
                    };

                    context.TaiKhoans.InsertOnSubmit(newUser);

                    // Save changes to the database
                    context.SubmitChanges();

                    MessageBox.Show($"Đăng ký thành công với Mã KH: {newMaKH}. Vui lòng đăng nhập.");

                    // Redirect to login form
                    DangNhap loginForm = new DangNhap();
                    loginForm.Show();
                    this.Hide();
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Định dạng Mã KH không hợp lệ: {ex.Message}");
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show($"Lỗi tham chiếu null: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        // Method to validate email format using a regular expression
        private bool IsValidEmail(string email)
        {
            try
            {
                var emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                var regex = new System.Text.RegularExpressions.Regex(emailPattern);
                return regex.IsMatch(email);
            }
            catch
            {
                return false;
            }
        }

        // Method to generate a new MaKH based on the last existing MaKH
        private string GenerateNewMaKH(dbQLBanHangDataContext context)
        {
            try
            {
                // Get the highest MaKH from the database
                var lastMaKH = context.KhachHangs
                    .OrderByDescending(k => k.MaKH)
                    .Select(k => k.MaKH)
                    .FirstOrDefault();

                if (string.IsNullOrEmpty(lastMaKH))
                {
                    // If there are no records, start with KH01
                    return "KH01";
                }

                // Ensure the MaKH format is valid (e.g., starts with "KH" and ends with a number)
                if (!lastMaKH.StartsWith("KH") || lastMaKH.Length < 3 || !int.TryParse(lastMaKH.Substring(2), out int lastNumber))
                {
                    throw new FormatException($"Invalid MaKH format: {lastMaKH}");
                }

                // Increment the numeric part and format as KHXX
                int newNumber = lastNumber + 1;
                return $"KH{newNumber:D2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo Mã KH: {ex.Message}");
                throw; // Re-throw to propagate the exception if needed
            }
        }
    }
}
