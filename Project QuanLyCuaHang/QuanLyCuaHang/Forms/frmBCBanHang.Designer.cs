namespace QuanLyCuaHang.Forms
{
    partial class frmBCBanHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBCBanHang));
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rdoTheoSP = new System.Windows.Forms.RadioButton();
            this.rdoTheoDon = new System.Windows.Forms.RadioButton();
            this.btnXem = new System.Windows.Forms.Button();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.btnDong = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnInHD = new System.Windows.Forms.Button();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.dgvBCBH = new System.Windows.Forms.DataGridView();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBCBH)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.ForestGreen;
            this.label4.Location = new System.Drawing.Point(270, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(300, 36);
            this.label4.TabIndex = 93;
            this.label4.Text = "Thông kê doanh thu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Đến ngày";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Từ ngày";
            // 
            // rdoTheoSP
            // 
            this.rdoTheoSP.AutoSize = true;
            this.rdoTheoSP.Location = new System.Drawing.Point(226, 32);
            this.rdoTheoSP.Name = "rdoTheoSP";
            this.rdoTheoSP.Size = new System.Drawing.Size(155, 21);
            this.rdoTheoSP.TabIndex = 1;
            this.rdoTheoSP.TabStop = true;
            this.rdoTheoSP.Text = "Xem theo sản phẩm";
            this.rdoTheoSP.UseVisualStyleBackColor = true;
            // 
            // rdoTheoDon
            // 
            this.rdoTheoDon.AutoSize = true;
            this.rdoTheoDon.Location = new System.Drawing.Point(22, 32);
            this.rdoTheoDon.Name = "rdoTheoDon";
            this.rdoTheoDon.Size = new System.Drawing.Size(153, 21);
            this.rdoTheoDon.TabIndex = 0;
            this.rdoTheoDon.TabStop = true;
            this.rdoTheoDon.Text = "Xem theo đơn hàng";
            this.rdoTheoDon.UseVisualStyleBackColor = true;
            this.rdoTheoDon.CheckedChanged += new System.EventHandler(this.rdoTheoDon_CheckedChanged);
            // 
            // btnXem
            // 
            this.btnXem.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnXem.Location = new System.Drawing.Point(171, 122);
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
            this.dtpDenNgay.Location = new System.Drawing.Point(298, 77);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(121, 22);
            this.dtpDenNgay.TabIndex = 6;
            this.dtpDenNgay.ValueChanged += new System.EventHandler(this.dtpDenNgay_ValueChanged);
            this.dtpDenNgay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpDenNgay_KeyPress);
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnDong.Location = new System.Drawing.Point(685, 161);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(111, 50);
            this.btnDong.TabIndex = 91;
            this.btnDong.Text = "Đóng";
            this.btnDong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(557, 472);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 17);
            this.label3.TabIndex = 86;
            this.label3.Text = "Tổng doanh thu";
            // 
            // btnInHD
            // 
            this.btnInHD.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnInHD.Location = new System.Drawing.Point(559, 161);
            this.btnInHD.Name = "btnInHD";
            this.btnInHD.Size = new System.Drawing.Size(111, 50);
            this.btnInHD.TabIndex = 89;
            this.btnInHD.Text = "In BC";
            this.btnInHD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInHD.UseVisualStyleBackColor = false;
            this.btnInHD.Click += new System.EventHandler(this.btnInHD_Click);
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(667, 467);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(129, 22);
            this.txtTongTien.TabIndex = 88;
            // 
            // dgvBCBH
            // 
            this.dgvBCBH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBCBH.Location = new System.Drawing.Point(20, 229);
            this.dgvBCBH.Name = "dgvBCBH";
            this.dgvBCBH.RowTemplate.Height = 24;
            this.dgvBCBH.Size = new System.Drawing.Size(776, 232);
            this.dgvBCBH.TabIndex = 87;
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(85, 77);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(121, 22);
            this.dtpTuNgay.TabIndex = 5;
            this.dtpTuNgay.ValueChanged += new System.EventHandler(this.dtpTuNgay_ValueChanged);
            this.dtpTuNgay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpTuNgay_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.btnXem);
            this.groupBox1.Controls.Add(this.dtpDenNgay);
            this.groupBox1.Controls.Add(this.dtpTuNgay);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rdoTheoSP);
            this.groupBox1.Controls.Add(this.rdoTheoDon);
            this.groupBox1.Location = new System.Drawing.Point(20, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 173);
            this.groupBox1.TabIndex = 85;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tùy chọn";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox2.Enabled = false;
            this.pictureBox2.Image = global::QuanLyCuaHang.Properties.Resources.Magnifying_Glass;
            this.pictureBox2.Location = new System.Drawing.Point(174, 124);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(27, 27);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 74;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox3.Enabled = false;
            this.pictureBox3.Image = global::QuanLyCuaHang.Properties.Resources.Delete;
            this.pictureBox3.Location = new System.Drawing.Point(688, 165);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(45, 40);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 92;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Image = global::QuanLyCuaHang.Properties.Resources.Printer_print_3d_vector_symbol_simple_pictogram;
            this.pictureBox1.Location = new System.Drawing.Point(562, 166);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 90;
            this.pictureBox1.TabStop = false;
            // 
            // frmBCBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 501);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvBCBH);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnInHD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBCBanHang";
            this.Text = "Thống kê doanh thu";
            this.Load += new System.EventHandler(this.frmBCBanHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBCBH)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdoTheoSP;
        private System.Windows.Forms.RadioButton rdoTheoDon;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnInHD;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvBCBH;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}