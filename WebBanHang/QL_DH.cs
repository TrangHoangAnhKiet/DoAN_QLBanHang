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
    public partial class QL_DH : Form
    {
        public QL_DH()
        {
            InitializeComponent();
            this.ControlBox = false;

        }

        
        private void QL_DH_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qL_BanHangDienTuDataSet.DonHang' table. You can move, or remove it, as needed.
            this.donHangTableAdapter.Fill(this.qL_BanHangDienTuDataSet.DonHang);
            // TODO: This line of code loads data into the 'qL_BanHangDienTuDataSet.DonHang' table. You can move, or remove it, as needed.
            this.donHangTableAdapter.Fill(this.qL_BanHangDienTuDataSet.DonHang);
            loadDSDonHang();
        }

        private void loadDSDonHang()
        {
            dbQLBanHangDataContext db = new dbQLBanHangDataContext();
            dgvQLDH.DataSource = db.DonHangs.ToList()
                .Select((p, index) => new { STT = index + 1, p.MaDH, p.TenDonHang,
                NgayDat = string.Format("{0:dd-MM-yyyy}", p.NgayDatHang),
                NgayXuat = string.Format("{0:dd-MM-yyyy}", p.NgayXuatHang),
                p.TrangThaiDH, p.TongGiaTriDH 
                }).OrderBy(p => p.MaDH)
                .ToList();
        }


        private void btnIN_Click(object sender, EventArgs e)
        {
            BaoCaoDonHang bc = new BaoCaoDonHang();
            bc.Show();
        }

        private void dgvQLDH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idrowclick = e.RowIndex;

            if (idrowclick == -1) return; //dong header
            //tim MaDH dang chon tai dong do
            string MaDH = dgvQLDH[1, idrowclick].Value.ToString();
            //hien thi du lieu
            dbQLBanHangDataContext db = new dbQLBanHangDataContext();
            DonHang l = db.DonHangs.Where(p => p.MaDH == MaDH).SingleOrDefault();
            txtMaDH.Text = l.MaDH;
            txtTenDonHang.Text = l.TenDonHang;
            dtpNgayDat.Value = (DateTime)l.NgayDatHang;
            dtpNgayXuat.Value = (DateTime)l.NgayXuatHang;
            txtTrangThai.Text = l.TrangThaiDH;
            txtTong.Text = l.TongGiaTriDH.ToString();
           
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string MaDH = txtMaDH.Text;
            dbQLBanHangDataContext db = new dbQLBanHangDataContext();
            //kiem tra ton tai
            DonHang l = db.DonHangs.Where(p => p.MaDH == MaDH).SingleOrDefault();
            if (l != null)
            {
                //du lieu da ton tai => THEM: FAILED
                MessageBox.Show("Mã lớp đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaDH.Focus();
                return;
            }
            l = new DonHang();
            txtMaDH.Text = l.MaDH;
            txtTenDonHang.Text = l.TenDonHang;
            dtpNgayDat.Value = (DateTime)l.NgayDatHang;
            dtpNgayXuat.Value = (DateTime)l.NgayXuatHang;
            txtTrangThai.Text = l.TrangThaiDH;
            txtTong.Text = l.TongGiaTriDH.ToString();
            db.DonHangs.InsertOnSubmit(l);
            db.SubmitChanges();
            //reload du lieu
            loadDSDonHang();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string MaDH = txtMaDH.Text;
            dbQLBanHangDataContext db = new dbQLBanHangDataContext();
            //kiem tra ton tai
            DonHang l = db.DonHangs.Where(p => p.MaDH == MaDH).SingleOrDefault();
            if (l == null)
            {
                //du lieu khong ton tai => XOA: FAILED
                MessageBox.Show("Mã lớp không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaDH.Focus();
                return;
            }
            db.DonHangs.DeleteOnSubmit(l);
            db.SubmitChanges();

            //reload du lieu
            loadDSDonHang();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string MaDH = txtMaDH.Text;
            dbQLBanHangDataContext db = new dbQLBanHangDataContext();
            //kiem tra ton tai
            DonHang l = db.DonHangs.Where(p => p.MaDH == MaDH).SingleOrDefault();
            if (l == null)
            {
                //du lieu chua ton tai => SUA: FAILED
                MessageBox.Show("Mã lớp chưa tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaDH.Focus();
                return;
            }
            //ko update MaDH
           
            txtTenDonHang.Text = l.TenDonHang;
            dtpNgayDat.Value = (DateTime)l.NgayDatHang;
            dtpNgayXuat.Value = (DateTime)l.NgayXuatHang;
            txtTrangThai.Text = l.TrangThaiDH;
            txtTong.Text = l.TongGiaTriDH.ToString();

            db.SubmitChanges();
            //reload du lieu
            loadDSDonHang();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            //tenDonHang = null => FULL DS
            string tenDonHang = txtTenDonHang.Text;
            if (tenDonHang == "") loadDSDonHang();
            else
            {
                dbQLBanHangDataContext db = new dbQLBanHangDataContext();
                dgvQLDH.DataSource = db.DonHangs.Where(p => p.TenDonHang.Contains(tenDonHang)).ToList()
                     .Select((p, index) => new {
                         STT = index + 1,
                         p.MaDH,
                         p.TenDonHang,
                         NgayDat = string.Format("{0:dd-MM-yyyy}", p.NgayDatHang),
                         NgayXuat = string.Format("{0:dd-MM-yyyy}", p.NgayXuatHang),
                         p.TrangThaiDH,
                         p.TongGiaTriDH
                     }).OrderBy(p => p.MaDH)
                .ToList();
            }
        }
    }
}
