using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBanHang
{
    public partial class TrangChu : Form {
        public TrangChu()
        {
            InitializeComponent();

        }
        private Form currentFormChild;

        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }

            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel3.Controls.Add(childForm);
            panel3.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QLBC());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QL_KBH());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QL_DH());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QL_NV());

        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QL_SP());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QL_KHO());
        }

        
    }
}

