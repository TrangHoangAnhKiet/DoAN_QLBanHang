namespace WebBanHang
{
    partial class QLBC
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnTim = new System.Windows.Forms.Button();
            this.dgvQLDH = new System.Windows.Forms.DataGridView();
            this.qLBanHangDienTuDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qL_BanHangDienTuDataSet = new WebBanHang.QL_BanHangDienTuDataSet();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnIN = new System.Windows.Forms.Button();
            this.txtMaDH = new System.Windows.Forms.TextBox();
            this.MaDH = new System.Windows.Forms.Label();
            this.txtTenDonHang = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTrangThai = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.baoCaoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.baoCaoTableAdapter = new WebBanHang.QL_BanHangDienTuDataSetTableAdapters.BaoCaoTableAdapter();
            this.maBCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loaiBCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noidungBCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayLapBCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpNgayLapBC = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQLDH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLBanHangDienTuDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qL_BanHangDienTuDataSet)).BeginInit();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.baoCaoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(55, 12);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(104, 43);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(229, 12);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(104, 43);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(403, 12);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(104, 43);
            this.btnCapNhat.TabIndex = 2;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(570, 12);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(104, 43);
            this.btnTim.TabIndex = 2;
            this.btnTim.Text = "Tìm kiếm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // dgvQLDH
            // 
            this.dgvQLDH.AutoGenerateColumns = false;
            this.dgvQLDH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQLDH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maBCDataGridViewTextBoxColumn,
            this.loaiBCDataGridViewTextBoxColumn,
            this.noidungBCDataGridViewTextBoxColumn,
            this.ngayLapBCDataGridViewTextBoxColumn});
            this.dgvQLDH.DataSource = this.baoCaoBindingSource;
            this.dgvQLDH.Location = new System.Drawing.Point(-10, 255);
            this.dgvQLDH.Name = "dgvQLDH";
            this.dgvQLDH.RowHeadersWidth = 51;
            this.dgvQLDH.RowTemplate.Height = 24;
            this.dgvQLDH.Size = new System.Drawing.Size(817, 192);
            this.dgvQLDH.TabIndex = 6;
            this.dgvQLDH.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQLDH_CellContentClick);
            // 
            // qLBanHangDienTuDataSetBindingSource
            // 
            this.qLBanHangDienTuDataSetBindingSource.DataSource = this.qL_BanHangDienTuDataSet;
            this.qLBanHangDienTuDataSetBindingSource.Position = 0;
            // 
            // qL_BanHangDienTuDataSet
            // 
            this.qL_BanHangDienTuDataSet.DataSetName = "QL_BanHangDienTuDataSet";
            this.qL_BanHangDienTuDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(803, 449);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(8, 8);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(0, 0);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(0, 0);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnIN
            // 
            this.btnIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIN.Location = new System.Drawing.Point(700, 12);
            this.btnIN.Name = "btnIN";
            this.btnIN.Size = new System.Drawing.Size(88, 43);
            this.btnIN.TabIndex = 8;
            this.btnIN.Text = "🖨";
            this.btnIN.UseVisualStyleBackColor = true;
            this.btnIN.Click += new System.EventHandler(this.btnIN_Click);
            // 
            // txtMaDH
            // 
            this.txtMaDH.Location = new System.Drawing.Point(175, 81);
            this.txtMaDH.Name = "txtMaDH";
            this.txtMaDH.Size = new System.Drawing.Size(100, 22);
            this.txtMaDH.TabIndex = 9;
            // 
            // MaDH
            // 
            this.MaDH.AutoSize = true;
            this.MaDH.Location = new System.Drawing.Point(52, 84);
            this.MaDH.Name = "MaDH";
            this.MaDH.Size = new System.Drawing.Size(79, 16);
            this.MaDH.TabIndex = 10;
            this.MaDH.Text = "Mã báo cáo";
            // 
            // txtTenDonHang
            // 
            this.txtTenDonHang.Location = new System.Drawing.Point(143, 136);
            this.txtTenDonHang.Name = "txtTenDonHang";
            this.txtTenDonHang.Size = new System.Drawing.Size(100, 22);
            this.txtTenDonHang.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Loại báo cáo";
            // 
            // txtTrangThai
            // 
            this.txtTrangThai.Location = new System.Drawing.Point(125, 178);
            this.txtTrangThai.Multiline = true;
            this.txtTrangThai.Name = "txtTrangThai";
            this.txtTrangThai.Size = new System.Drawing.Size(150, 22);
            this.txtTrangThai.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Nội dung";
            // 
            // baoCaoBindingSource
            // 
            this.baoCaoBindingSource.DataMember = "BaoCao";
            this.baoCaoBindingSource.DataSource = this.qLBanHangDienTuDataSetBindingSource;
            // 
            // baoCaoTableAdapter
            // 
            this.baoCaoTableAdapter.ClearBeforeFill = true;
            // 
            // maBCDataGridViewTextBoxColumn
            // 
            this.maBCDataGridViewTextBoxColumn.DataPropertyName = "MaBC";
            this.maBCDataGridViewTextBoxColumn.HeaderText = "MaBC";
            this.maBCDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.maBCDataGridViewTextBoxColumn.Name = "maBCDataGridViewTextBoxColumn";
            this.maBCDataGridViewTextBoxColumn.Width = 125;
            // 
            // loaiBCDataGridViewTextBoxColumn
            // 
            this.loaiBCDataGridViewTextBoxColumn.DataPropertyName = "LoaiBC";
            this.loaiBCDataGridViewTextBoxColumn.HeaderText = "LoaiBC";
            this.loaiBCDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.loaiBCDataGridViewTextBoxColumn.Name = "loaiBCDataGridViewTextBoxColumn";
            this.loaiBCDataGridViewTextBoxColumn.Width = 125;
            // 
            // noidungBCDataGridViewTextBoxColumn
            // 
            this.noidungBCDataGridViewTextBoxColumn.DataPropertyName = "NoidungBC";
            this.noidungBCDataGridViewTextBoxColumn.HeaderText = "NoidungBC";
            this.noidungBCDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.noidungBCDataGridViewTextBoxColumn.Name = "noidungBCDataGridViewTextBoxColumn";
            this.noidungBCDataGridViewTextBoxColumn.Width = 125;
            // 
            // ngayLapBCDataGridViewTextBoxColumn
            // 
            this.ngayLapBCDataGridViewTextBoxColumn.DataPropertyName = "NgayLapBC";
            this.ngayLapBCDataGridViewTextBoxColumn.HeaderText = "NgayLapBC";
            this.ngayLapBCDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.ngayLapBCDataGridViewTextBoxColumn.Name = "ngayLapBCDataGridViewTextBoxColumn";
            this.ngayLapBCDataGridViewTextBoxColumn.Width = 125;
            // 
            // dtpNgayLapBC
            // 
            this.dtpNgayLapBC.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayLapBC.Location = new System.Drawing.Point(537, 111);
            this.dtpNgayLapBC.Name = "dtpNgayLapBC";
            this.dtpNgayLapBC.Size = new System.Drawing.Size(200, 22);
            this.dtpNgayLapBC.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(416, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Ngày lập báo cáo";
            // 
            // QLBC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtpNgayLapBC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MaDH);
            this.Controls.Add(this.txtTrangThai);
            this.Controls.Add(this.txtTenDonHang);
            this.Controls.Add(this.txtMaDH);
            this.Controls.Add(this.btnIN);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dgvQLDH);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Name = "QLBC";
            this.Text = "QLBC";
            this.Load += new System.EventHandler(this.QLBC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQLDH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLBanHangDienTuDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qL_BanHangDienTuDataSet)).EndInit();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.baoCaoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.DataGridView dgvQLDH;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private QL_BanHangDienTuDataSet qL_BanHangDienTuDataSet;
        private System.Windows.Forms.BindingSource qLBanHangDienTuDataSetBindingSource;
        private System.Windows.Forms.Button btnIN;
        private System.Windows.Forms.TextBox txtMaDH;
        private System.Windows.Forms.Label MaDH;
        private System.Windows.Forms.TextBox txtTenDonHang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTrangThai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource baoCaoBindingSource;
        private QL_BanHangDienTuDataSetTableAdapters.BaoCaoTableAdapter baoCaoTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn maBCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loaiBCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noidungBCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayLapBCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DateTimePicker dtpNgayLapBC;
        private System.Windows.Forms.Label label1;
    }
}

