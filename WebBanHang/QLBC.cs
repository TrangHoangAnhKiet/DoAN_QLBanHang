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
    public partial class QLBC : Form
    {
        public QLBC()
        {
            InitializeComponent();
            this.ControlBox = false;

        }

       

        private void QLBC_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qL_BanHangDienTuDataSet.BaoCao' table. You can move, or remove it, as needed.
            this.baoCaoTableAdapter.Fill(this.qL_BanHangDienTuDataSet.BaoCao);
            loadDSBaoCao();

        }

        private void loadDSBaoCao()
        {
            dbQLBanHangDataContext db = new dbQLBanHangDataContext();
            dgvQLDH.DataSource = db.BaoCaos.ToList()
                .Select((p, index) => new {
                    STT = index + 1,
                    p.MaBC,
                    p.LoaiBC,

                    p.NoidungBC,
                    NgayLapBC = string.Format("{0:dd-MM-yyyy}", p.NgayLapBC)
                }).OrderBy(p => p.MaBC)
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
            BaoCao l = db.BaoCaos.Where(p => p.MaBC == MaDH).SingleOrDefault();
            txtMaDH.Text = l.MaBC;
            txtTenDonHang.Text = l.LoaiBC;

            txtTrangThai.Text = l.NoidungBC;
            dtpNgayLapBC.Value = (DateTime)l.NgayLapBC;


        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string MaDH = txtMaDH.Text;
            dbQLBanHangDataContext db = new dbQLBanHangDataContext();
            //kiem tra ton tai
            BaoCao l = db.BaoCaos.Where(p => p.MaBC == MaDH).SingleOrDefault();
            if (l != null)
            {
                //du lieu da ton tai => THEM: FAILED
                MessageBox.Show("Mã lớp đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaDH.Focus();
                return;
            }
            l = new BaoCao();
            txtMaDH.Text = l.MaBC;
            txtTenDonHang.Text = l.LoaiBC;

            txtTrangThai.Text = l.NoidungBC;
            dtpNgayLapBC.Value = (DateTime)l.NgayLapBC;
            db.BaoCaos.InsertOnSubmit(l);
            db.SubmitChanges();
            //reload du lieu
            loadDSBaoCao();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string MaDH = txtMaDH.Text;
            dbQLBanHangDataContext db = new dbQLBanHangDataContext();
            //kiem tra ton tai
            BaoCao l = db.BaoCaos.Where(p => p.MaBC == MaDH).SingleOrDefault();
            if (l == null)
            {
                //du lieu khong ton tai => XOA: FAILED
                MessageBox.Show("Mã lớp không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaDH.Focus();
                return;
            }
            db.BaoCaos.DeleteOnSubmit(l);
            db.SubmitChanges();

            //reload du lieu
            loadDSBaoCao();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string MaDH = txtMaDH.Text;
            dbQLBanHangDataContext db = new dbQLBanHangDataContext();
            //kiem tra ton tai
            BaoCao l = db.BaoCaos.Where(p => p.MaBC == MaDH).SingleOrDefault();
            if (l == null)
            {
                //du lieu chua ton tai => SUA: FAILED
                MessageBox.Show("Mã lớp chưa tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaDH.Focus();
                return;
            }
            //ko update MaDH


            txtTenDonHang.Text = l.LoaiBC;

            txtTrangThai.Text = l.NoidungBC;
            dtpNgayLapBC.Value = (DateTime)l.NgayLapBC;
            db.SubmitChanges();
            //reload du lieu
            loadDSBaoCao();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            //tenBaoCao = null => FULL DS
            string tenBaoCao = txtTenDonHang.Text;
            if (tenBaoCao == "") loadDSBaoCao();
            else
            {
                dbQLBanHangDataContext db = new dbQLBanHangDataContext();
                dgvQLDH.DataSource = db.BaoCaos.Where(p => p.MaBC.Contains(tenBaoCao)).ToList()
                     .Select((p, index) => new {
                         STT = index + 1,
                         p.MaBC,
                         p.LoaiBC,

                         p.NoidungBC,
                         NgayLapBC = string.Format("{0:dd-MM-yyyy}", p.NgayLapBC)
                     }).OrderBy(p => p.MaBC)
                .ToList();
            }
        }
    }
}
