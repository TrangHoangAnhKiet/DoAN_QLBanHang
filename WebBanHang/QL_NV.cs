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
    public partial class QL_NV : Form
    {
        public QL_NV()
        {
            InitializeComponent();
            this.ControlBox = false;

        }

      

        private void QL_NV_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qL_BanHangDienTuDataSet.NhanVien' table. You can move, or remove it, as needed.
            this.nhanVienTableAdapter.Fill(this.qL_BanHangDienTuDataSet.NhanVien);
            loadDSNhanVien();

        }

        private void loadDSNhanVien()
        {
            dbQLBanHangDataContext db = new dbQLBanHangDataContext();
            dgvQLDH.DataSource = db.NhanViens.ToList()
                .Select((p, index) => new {
                    STT = index + 1,
                    p.MaNV,
                    p.TenNV,
                    NamSinh = string.Format("{0:dd-MM-yyyy}", p.NamSinh),
                    p.LoaiCongViec,
                    p.GioiTinh,
                    p.HeSoLuong
                }).OrderBy(p => p.MaNV)
                .ToList();
        }


        private void btnIN_Click(object sender, EventArgs e)
        {
           
        }

        private void dgvQLDH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idrowclick = e.RowIndex;

            if (idrowclick == -1) return; //dong header
            //tim MaNV dang chon tai dong do
            string MaNV = dgvQLDH[1, idrowclick].Value.ToString();
            //hien thi du lieu
            dbQLBanHangDataContext db = new dbQLBanHangDataContext();
            NhanVien l = db.NhanViens.Where(p => p.MaNV == MaNV).SingleOrDefault();
            txtNV.Text = l.MaNV;
            txtTenNV.Text = l.TenNV;

            dtpNamSinh.Value = (DateTime)l.NamSinh;
            txtGioiTinh.Text = l.GioiTinh;
            txtLoaiCongViec.Text = l.LoaiCongViec;
            txtHeSoLuong.Text = l.HeSoLuong.ToString();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string MaNV = txtNV.Text;
            dbQLBanHangDataContext db = new dbQLBanHangDataContext();
            //kiem tra ton tai
            NhanVien l = db.NhanViens.Where(p => p.MaNV == MaNV).SingleOrDefault();
            if (l != null)
            {
                //du lieu da ton tai => THEM: FAILED
                MessageBox.Show("Mã lớp đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNV.Focus();
                return;
            }
            l = new NhanVien();
            txtNV.Text = l.MaNV;
            txtTenNV.Text = l.TenNV;
            dtpNamSinh.Value = (DateTime)l.NamSinh;
            txtGioiTinh.Text = l.GioiTinh;
            txtLoaiCongViec.Text = l.LoaiCongViec;
            txtHeSoLuong.Text = l.HeSoLuong.ToString();
            db.NhanViens.InsertOnSubmit(l);
            db.SubmitChanges();
            //reload du lieu
            loadDSNhanVien();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string MaNV = txtNV.Text;
            dbQLBanHangDataContext db = new dbQLBanHangDataContext();
            //kiem tra ton tai
            NhanVien l = db.NhanViens.Where(p => p.MaNV == MaNV).SingleOrDefault();
            if (l == null)
            {
                //du lieu khong ton tai => XOA: FAILED
                MessageBox.Show("Mã lớp không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNV.Focus();
                return;
            }
            db.NhanViens.DeleteOnSubmit(l);
            db.SubmitChanges();

            //reload du lieu
            loadDSNhanVien();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string MaNV = txtNV.Text;
            dbQLBanHangDataContext db = new dbQLBanHangDataContext();
            //kiem tra ton tai
            NhanVien l = db.NhanViens.Where(p => p.MaNV == MaNV).SingleOrDefault();
            if (l == null)
            {
                //du lieu chua ton tai => SUA: FAILED
                MessageBox.Show("Mã lớp chưa tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNV.Focus();
                return;
            }
            //ko update MaNV

            txtTenNV.Text = l.TenNV;
           

            dtpNamSinh.Value = (DateTime)l.NamSinh;
            txtGioiTinh.Text = l.GioiTinh;
            txtLoaiCongViec.Text = l.LoaiCongViec;
            txtHeSoLuong.Text = l.HeSoLuong.ToString();
            

            db.SubmitChanges();
            //reload du lieu
            loadDSNhanVien();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            //TenNV = null => FULL DS
            string TenNV = txtTenNV.Text;
            if (TenNV == "") loadDSNhanVien();
            else
            {
                dbQLBanHangDataContext db = new dbQLBanHangDataContext();
                dgvQLDH.DataSource = db.NhanViens.Where(p => p.TenNV.Contains(TenNV)).ToList()
                      .Select((p, index) => new {
                          STT = index + 1,
                          p.MaNV,
                          p.TenNV,
                          NamSinh = string.Format("{0:dd-MM-yyyy}", p.NamSinh),
                          p.LoaiCongViec,
                          p.GioiTinh,
                          p.HeSoLuong
                      }).OrderBy(p => p.MaNV)
                .ToList();
            }
        }
    }
}
