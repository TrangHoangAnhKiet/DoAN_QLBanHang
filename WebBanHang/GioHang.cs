using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WebBanHang
{
    public partial class GioHang : Form
    {
        private string _maSP;
        private List<CartItem> cartItems;
        // Constructor that takes MaSP as a parameter
        public GioHang(string maSP)
        {
            InitializeComponent();
            _maSP = maSP;  // Store the MaSP to use for fetching product details
            cartItems = new List<CartItem>();
            LoadProductToCart(maSP);  // Load product details on form load
        }

        private void GioHang_Load(object sender, EventArgs e)
        {
            // Optionally, you can also call the LoadProductToCart here if you prefer
        }

        private void LoadProductToCart(string maSP)
        {
            using (var context = new dbQLBanHangDataContext())
            {
                // Query the SanPham table using MaSP to get the product details
                var product = context.SanPhams.FirstOrDefault(sp => sp.MaSP == maSP);

                if (product != null)
                {
                    // Create a new list of CartItems and add the product
                    var cartItems = new List<CartItem>
                    {
                        new CartItem
                        {
                            MaSP = product.MaSP,
                            TenSP = product.TenSP,
                            Gia = product.Gia,
                            MoTa = product.MoTa,
                            ThongSoKT = product.ThongSoKT,
                            SoLuong = 1 // Default quantity
                        }
                    };

                    // Bind the cart items to the DataGridView
                    dataGridViewCart.DataSource = cartItems;
                }
                else
                {
                    MessageBox.Show("Sản phẩm không tồn tại.");
                }
            }
        }

        // CartItem class for binding to DataGridView
        public class CartItem
        {
            public string MaSP { get; set; }
            public string TenSP { get; set; }
            public decimal Gia { get; set; }
            public string MoTa { get; set; }
            public string ThongSoKT { get; set; }
            public int SoLuong { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you for buying!");
            this.Close();
        }
    }
}
