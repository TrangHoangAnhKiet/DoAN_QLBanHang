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
    public partial class QL_SP : Form
    {
        public QL_SP()
        {
            InitializeComponent();
            this.ControlBox = false;

        }

        private void QL_SP_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qL_BanHangDienTuDataSet.SanPham' table. You can move, or remove it, as needed.
            this.sanPhamTableAdapter.Fill(this.qL_BanHangDienTuDataSet.SanPham);
            loadDSSanPham();

        }

        private void loadDSSanPham()
        {
            dbQLBanHangDataContext db = new dbQLBanHangDataContext();
            dgvQLDH.DataSource = db.SanPhams.ToList()
                .Select((p, index) => new {
                    STT = index + 1,
                    p.MaSP,
                    p.TenSP,
                    p.Gia,
                    p.MoTa,
                    p.ThongSoKT,
                    p.TonKho
                }).OrderBy(p => p.MaSP)
                .ToList();
        }


        private void btnIN_Click(object sender, EventArgs e)
        {
           
        }

        private void dgvQLDH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idrowclick = e.RowIndex;

            if (idrowclick == -1) return; //dong header
            //tim MaSP dang chon tai dong do
            string MaSP = dgvQLDH[1, idrowclick].Value.ToString();
            //hien thi du lieu
            dbQLBanHangDataContext db = new dbQLBanHangDataContext();
            SanPham l = db.SanPhams.Where(p => p.MaSP == MaSP).SingleOrDefault();
            txtMaSP.Text = l.MaSP;
            txtTenSP.Text = l.TenSP;
            txtGia.Text = l.Gia.ToString();
            txtMoTa.Text = l.MoTa;
            txtTSKT.Text = l.ThongSoKT;
            txtTonKho.Text = l.TonKho.ToString();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string MaSP = txtMaSP.Text;
            dbQLBanHangDataContext db = new dbQLBanHangDataContext();
            //kiem tra ton tai
            SanPham l = db.SanPhams.Where(p => p.MaSP == MaSP).SingleOrDefault();
            if (l != null)
            {
                //du lieu da ton tai => THEM: FAILED
                MessageBox.Show("Mã lớp đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaSP.Focus();
                return;
            }
            l = new SanPham();
            txtMaSP.Text = l.MaSP;
            txtTenSP.Text = l.TenSP;
            txtGia.Text = l.Gia.ToString();
            txtMoTa.Text = l.MoTa;
            txtTSKT.Text = l.ThongSoKT;
            txtTonKho.Text = l.TonKho.ToString();
            db.SanPhams.InsertOnSubmit(l);
            db.SubmitChanges();
            //reload du lieu
            loadDSSanPham();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string MaSP = txtMaSP.Text;
            dbQLBanHangDataContext db = new dbQLBanHangDataContext();
            //kiem tra ton tai
            SanPham l = db.SanPhams.Where(p => p.MaSP == MaSP).SingleOrDefault();
            if (l == null)
            {
                //du lieu khong ton tai => XOA: FAILED
                MessageBox.Show("Mã lớp không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaSP.Focus();
                return;
            }
            db.SanPhams.DeleteOnSubmit(l);
            db.SubmitChanges();

            //reload du lieu
            loadDSSanPham();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string MaSP = txtMaSP.Text;
            dbQLBanHangDataContext db = new dbQLBanHangDataContext();
            //kiem tra ton tai
            SanPham l = db.SanPhams.Where(p => p.MaSP == MaSP).SingleOrDefault();
            if (l == null)
            {
                //du lieu chua ton tai => SUA: FAILED
                MessageBox.Show("Mã lớp chưa tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaSP.Focus();
                return;
            }
            //ko update MaSP

            txtTenSP.Text = l.TenSP;
            txtGia.Text = l.Gia.ToString();
            txtMoTa.Text = l.MoTa;
            txtTSKT.Text = l.ThongSoKT;
            txtTonKho.Text = l.TonKho.ToString();
            

            db.SubmitChanges();
            //reload du lieu
            loadDSSanPham();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            //TenSP = null => FULL DS
            string TenSP = txtTenSP.Text;
            if (TenSP == "") loadDSSanPham();
            else
            {
                dbQLBanHangDataContext db = new dbQLBanHangDataContext();
                dgvQLDH.DataSource = db.SanPhams.Where(p => p.TenSP.Contains(TenSP)).ToList()
                    .Select((p, index) => new {
                        STT = index + 1,
                        p.MaSP,
                        p.TenSP,
                        p.Gia,
                        p.MoTa,
                        p.ThongSoKT,
                        p.TonKho
                    }).OrderBy(p => p.MaSP)
                .ToList();
            }
        }
    }
}
