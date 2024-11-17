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
    public partial class QL_KBH : Form
    {
        public QL_KBH()
        {
            InitializeComponent();
            this.ControlBox = false;

        }


        private void QL_KBH_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qL_BanHangDienTuDataSet.KenhBanHang' table. You can move, or remove it, as needed.
            this.kenhBanHangTableAdapter.Fill(this.qL_BanHangDienTuDataSet.KenhBanHang);
            loadDSKenhBanHang();
        }

        private void loadDSKenhBanHang()
        {
            dbQLBanHangDataContext db = new dbQLBanHangDataContext();
            dgvQLDH.DataSource = db.KenhBanHangs.ToList()
                .Select((p, index) => new {
                    STT = index + 1,
                    p.MaKenh,
                    p.TenKenh,
                   
                    p.MoTaKenh,
                   
                }).OrderBy(p => p.MaKenh)
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
            KenhBanHang l = db.KenhBanHangs.Where(p => p.MaDH == MaDH).SingleOrDefault();
            txtMaDH.Text = l.MaDH;
            txtTenDonHang.Text = l.TenKenh;
          
            txtTrangThai.Text = l.MoTaKenh;
           

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string MaDH = txtMaDH.Text;
            dbQLBanHangDataContext db = new dbQLBanHangDataContext();
            //kiem tra ton tai
            KenhBanHang l = db.KenhBanHangs.Where(p => p.MaDH == MaDH).SingleOrDefault();
            if (l != null)
            {
                //du lieu da ton tai => THEM: FAILED
                MessageBox.Show("Mã lớp đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaDH.Focus();
                return;
            }
            l = new KenhBanHang();
            txtMaDH.Text = l.MaDH;
            txtTenDonHang.Text = l.TenKenh;

            txtTrangThai.Text = l.MoTaKenh;
            db.KenhBanHangs.InsertOnSubmit(l);
            db.SubmitChanges();
            //reload du lieu
            loadDSKenhBanHang();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string MaDH = txtMaDH.Text;
            dbQLBanHangDataContext db = new dbQLBanHangDataContext();
            //kiem tra ton tai
            KenhBanHang l = db.KenhBanHangs.Where(p => p.MaDH == MaDH).SingleOrDefault();
            if (l == null)
            {
                //du lieu khong ton tai => XOA: FAILED
                MessageBox.Show("Mã lớp không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaDH.Focus();
                return;
            }
            db.KenhBanHangs.DeleteOnSubmit(l);
            db.SubmitChanges();

            //reload du lieu
            loadDSKenhBanHang();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string MaDH = txtMaDH.Text;
            dbQLBanHangDataContext db = new dbQLBanHangDataContext();
            //kiem tra ton tai
            KenhBanHang l = db.KenhBanHangs.Where(p => p.MaKenh == MaDH).SingleOrDefault();
            if (l == null)
            {
                //du lieu chua ton tai => SUA: FAILED
                MessageBox.Show("Mã lớp chưa tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaDH.Focus();
                return;
            }
            //ko update MaDH

          
            txtTenDonHang.Text = l.TenKenh;

            txtTrangThai.Text = l.MoTaKenh;

            db.SubmitChanges();
            //reload du lieu
            loadDSKenhBanHang();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            //tenKenhBanHang = null => FULL DS
            string tenKenhBanHang = txtTenDonHang.Text;
            if (tenKenhBanHang == "") loadDSKenhBanHang();
            else
            {
                dbQLBanHangDataContext db = new dbQLBanHangDataContext();
                dgvQLDH.DataSource = db.KenhBanHangs.Where(p => p.TenKenh.Contains(tenKenhBanHang)).ToList()
                     .Select((p, index) => new {
                         STT = index + 1,
                         p.MaKenh,
                         p.TenKenh,

                         p.MoTaKenh,

                     }).OrderBy(p => p.MaKenh)
                .ToList();
            }
        }
    }
}
