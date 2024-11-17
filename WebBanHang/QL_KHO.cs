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
    public partial class QL_KHO : Form
    {
        public QL_KHO()
        {
            InitializeComponent();
            this.ControlBox = false;

        }

        

        private void QL_KHO_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qL_BanHangDienTuDataSet.KhoHang' table. You can move, or remove it, as needed.
            this.khoHangTableAdapter.Fill(this.qL_BanHangDienTuDataSet.KhoHang);
            loadDSKhoHang();

        }

        private void loadDSKhoHang()
        {
            dbQLBanHangDataContext db = new dbQLBanHangDataContext();
            dgvQLDH.DataSource = db.KhoHangs.ToList()
                .Select((p, index) => new {
                    STT = index + 1,
                    p.MaKhoHang,
                    p.DiaChiKho,

                  

                }).OrderBy(p => p.MaKhoHang)
                .ToList();
        }


        private void btnIN_Click(object sender, EventArgs e)
        {

        }

        private void dgvQLDH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idrowclick = e.RowIndex;

            if (idrowclick == -1) return; //dong header
            //tim MaDH dang chon tai dong do
            string MaDH = dgvQLDH[1, idrowclick].Value.ToString();
            //hien thi du lieu
            dbQLBanHangDataContext db = new dbQLBanHangDataContext();
            KhoHang l = db.KhoHangs.Where(p => p.MaKhoHang == MaDH).SingleOrDefault();
            txtMaDH.Text = l.MaKhoHang;
            txtTenDonHang.Text = l.DiaChiKho;

          


        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string MaDH = txtMaDH.Text;
            dbQLBanHangDataContext db = new dbQLBanHangDataContext();
            //kiem tra ton tai
            KhoHang l = db.KhoHangs.Where(p => p.MaKhoHang == MaDH).SingleOrDefault();
            if (l != null)
            {
                //du lieu da ton tai => THEM: FAILED
                MessageBox.Show("Mã lớp đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaDH.Focus();
                return;
            }
            l = new KhoHang();
            txtMaDH.Text = l.MaKhoHang;
            txtTenDonHang.Text = l.DiaChiKho;

           
            db.KhoHangs.InsertOnSubmit(l);
            db.SubmitChanges();
            //reload du lieu
            loadDSKhoHang();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string MaDH = txtMaDH.Text;
            dbQLBanHangDataContext db = new dbQLBanHangDataContext();
            //kiem tra ton tai
            KhoHang l = db.KhoHangs.Where(p => p.MaKhoHang == MaDH).SingleOrDefault();
            if (l == null)
            {
                //du lieu khong ton tai => XOA: FAILED
                MessageBox.Show("Mã lớp không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaDH.Focus();
                return;
            }
            db.KhoHangs.DeleteOnSubmit(l);
            db.SubmitChanges();

            //reload du lieu
            loadDSKhoHang();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string MaDH = txtMaDH.Text;
            dbQLBanHangDataContext db = new dbQLBanHangDataContext();
            //kiem tra ton tai
            KhoHang l = db.KhoHangs.Where(p => p.MaKhoHang == MaDH).SingleOrDefault();
            if (l == null)
            {
                //du lieu chua ton tai => SUA: FAILED
                MessageBox.Show("Mã lớp chưa tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaDH.Focus();
                return;
            }
            //ko update MaDH


            txtTenDonHang.Text = l.DiaChiKho;

          
            db.SubmitChanges();
            //reload du lieu
            loadDSKhoHang();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            //tenKhoHang = null => FULL DS
            string tenKhoHang = txtTenDonHang.Text;
            if (tenKhoHang == "") loadDSKhoHang();
            else
            {
                dbQLBanHangDataContext db = new dbQLBanHangDataContext();
                dgvQLDH.DataSource = db.KhoHangs.Where(p => p.MaKhoHang.Contains(tenKhoHang)).ToList()
                     .Select((p, index) => new {
                         STT = index + 1,
                         p.MaKhoHang,
                         p.DiaChiKho,



                     }).OrderBy(p => p.MaKhoHang)
                .ToList();
            }
        }
    }
}
