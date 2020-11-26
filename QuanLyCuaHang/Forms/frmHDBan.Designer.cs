namespace QuanLyCuaHang.Forms
{
    partial class frmHDBan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHDBan));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnXem = new System.Windows.Forms.Button();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThemHD = new System.Windows.Forms.Button();
            this.dgvDanhsach = new System.Windows.Forms.DataGridView();
            this.label16 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.btnInHD = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhsach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.btnXem);
            this.groupBox1.Controls.Add(this.dtpDenNgay);
            this.groupBox1.Controls.Add(this.dtpTuNgay);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(14, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 120);
            this.groupBox1.TabIndex = 101;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tùy chọn";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox2.Enabled = false;
            this.pictureBox2.Image = global::QuanLyCuaHang.Properties.Resources.Magnifying_Glass;
            this.pictureBox2.Location = new System.Drawing.Point(172, 80);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(28, 28);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 74;
            this.pictureBox2.TabStop = false;
            // 
            // btnXem
            // 
            this.btnXem.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnXem.Location = new System.Drawing.Point(169, 78);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(87, 33);
            this.btnXem.TabIndex = 73;
            this.btnXem.Text = "Xem";
            this.btnXem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXem.UseVisualStyleBackColor = false;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(296, 33);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(121, 22);
            this.dtpDenNgay.TabIndex = 6;
            this.dtpDenNgay.ValueChanged += new System.EventHandler(this.dtpDenNgay_ValueChanged);
            this.dtpDenNgay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpDenNgay_KeyPress);
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(83, 33);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(121, 22);
            this.dtpTuNgay.TabIndex = 5;
            this.dtpTuNgay.ValueChanged += new System.EventHandler(this.dtpTuNgay_ValueChanged);
            this.dtpTuNgay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpTuNgay_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Đến ngày";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Từ ngày";
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnDong.Location = new System.Drawing.Point(736, 443);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(111, 50);
            this.btnDong.TabIndex = 99;
            this.btnDong.Text = "Đóng";
            this.btnDong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSua.Location = new System.Drawing.Point(159, 443);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(111, 50);
            this.btnSua.TabIndex = 97;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThemHD
            // 
            this.btnThemHD.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnThemHD.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnThemHD.Location = new System.Drawing.Point(14, 443);
            this.btnThemHD.Name = "btnThemHD";
            this.btnThemHD.Size = new System.Drawing.Size(130, 50);
            this.btnThemHD.TabIndex = 95;
            this.btnThemHD.Text = "Thêm HĐ";
            this.btnThemHD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemHD.UseVisualStyleBackColor = false;
            this.btnThemHD.Click += new System.EventHandler(this.btnThemHD_Click);
            // 
            // dgvDanhsach
            // 
            this.dgvDanhsach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhsach.Location = new System.Drawing.Point(14, 177);
            this.dgvDanhsach.Name = "dgvDanhsach";
            this.dgvDanhsach.RowTemplate.Height = 24;
            this.dgvDanhsach.Size = new System.Drawing.Size(833, 232);
            this.dgvDanhsach.TabIndex = 94;
            this.dgvDanhsach.Click += new System.EventHandler(this.dgvDanhsach_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.ForestGreen;
            this.label16.Location = new System.Drawing.Point(235, 3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(353, 36);
            this.label16.TabIndex = 93;
            this.label16.Text = "Danh sách hóa đơn bán";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox3.Enabled = false;
            this.pictureBox3.Image = global::QuanLyCuaHang.Properties.Resources.Delete;
            this.pictureBox3.Location = new System.Drawing.Point(739, 447);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(45, 40);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 100;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox7.Enabled = false;
            this.pictureBox7.Image = global::QuanLyCuaHang.Properties.Resources.Repair;
            this.pictureBox7.Location = new System.Drawing.Point(162, 447);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(47, 41);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 98;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox1.BackgroundImage = global::QuanLyCuaHang.Properties.Resources.icon1;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = global::QuanLyCuaHang.Properties.Resources.edit_add;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(17, 447);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 96;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox6.Enabled = false;
            this.pictureBox6.Image = global::QuanLyCuaHang.Properties.Resources.Trash_empty1;
            this.pictureBox6.Location = new System.Drawing.Point(288, 447);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(47, 41);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 103;
            this.pictureBox6.TabStop = false;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnXoa.Location = new System.Drawing.Point(285, 443);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(111, 50);
            this.btnXoa.TabIndex = 102;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox5.Enabled = false;
            this.pictureBox5.Image = global::QuanLyCuaHang.Properties.Resources.Printer_print_3d_vector_symbol_simple_pictogram;
            this.pictureBox5.Location = new System.Drawing.Point(417, 448);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(45, 40);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 109;
            this.pictureBox5.TabStop = false;
            // 
            // btnInHD
            // 
            this.btnInHD.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnInHD.Location = new System.Drawing.Point(414, 443);
            this.btnInHD.Name = "btnInHD";
            this.btnInHD.Size = new System.Drawing.Size(111, 50);
            this.btnInHD.TabIndex = 108;
            this.btnInHD.Text = "In HĐ";
            this.btnInHD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInHD.UseVisualStyleBackColor = false;
            this.btnInHD.Click += new System.EventHandler(this.btnInHD_Click);
            // 
            // frmHDBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 510);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.btnInHD);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnThemHD);
            this.Controls.Add(this.dgvDanhsach);
            this.Controls.Add(this.label16);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHDBan";
            this.Text = "frmHDBan";
            this.Load += new System.EventHandler(this.frmHDBan_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhsach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnThemHD;
        private System.Windows.Forms.DataGridView dgvDanhsach;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button btnInHD;
    }
}