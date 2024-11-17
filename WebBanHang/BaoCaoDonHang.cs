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
    public partial class BaoCaoDonHang : Form
    {
        public BaoCaoDonHang()
        {
            InitializeComponent();
        }

        private void BaoCaoDonHang_Load(object sender, EventArgs e)
        {
            //nap du lieu tu MaLop
            dbQLBanHangDataContext db = new dbQLBanHangDataContext();
            List<DonHang> lstDH = new List<DonHang>();
            lstDH = db.DonHangs.ToList();


            this.reportViewer1.RefreshReport();
        }
    }
}
