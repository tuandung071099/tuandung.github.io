namespace QuanLyCuaHang.Forms.FormLoai
{
    partial class frmLoai
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvLoai = new System.Windows.Forms.DataGridView();
            this.txtMaloai = new System.Windows.Forms.TextBox();
            this.txtTenloai = new System.Windows.Forms.TextBox();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnLammoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.ForestGreen;
            this.label1.Location = new System.Drawing.Point(317, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loại hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã Loại";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(320, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên Loại";
            // 
            // dgvLoai
            // 
            this.dgvLoai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoai.Location = new System.Drawing.Point(28, 165);
            this.dgvLoai.Name = "dgvLoai";
            this.dgvLoai.RowTemplate.Height = 24;
            this.dgvLoai.Size = new System.Drawing.Size(751, 184);
            this.dgvLoai.TabIndex = 3;
            this.dgvLoai.Click += new System.EventHandler(this.dgvLoai_Click);
            // 
            // txtMaloai
            // 
            this.txtMaloai.Location = new System.Drawing.Point(111, 118);
            this.txtMaloai.Name = "txtMaloai";
            this.txtMaloai.Size = new System.Drawing.Size(100, 22);
            this.txtMaloai.TabIndex = 4;
            // 
            // txtTenloai
            // 
            this.txtTenloai.Location = new System.Drawing.Point(407, 118);
            this.txtTenloai.Name = "txtTenloai";
            this.txtTenloai.Size = new System.Drawing.Size(100, 22);
            this.txtTenloai.TabIndex = 5;
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnDong.Location = new System.Drawing.Point(668, 388);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(111, 50);
            this.btnDong.TabIndex = 11;
            this.btnDong.Text = "Đóng";
            this.btnDong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnLammoi
            // 
            this.btnLammoi.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnLammoi.Location = new System.Drawing.Point(540, 388);
            this.btnLammoi.Name = "btnLammoi";
            this.btnLammoi.Size = new System.Drawing.Size(122, 50);
            this.btnLammoi.TabIndex = 10;
            this.btnLammoi.Text = "Làm mới";
            this.btnLammoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLammoi.UseVisualStyleBackColor = false;
            this.btnLammoi.Click += new System.EventHandler(this.btnLammoi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnXoa.Location = new System.Drawing.Point(412, 388);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(111, 50);
            this.btnXoa.TabIndex = 9;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSua.Location = new System.Drawing.Point(284, 388);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(111, 50);
            this.btnSua.TabIndex = 8;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnLuu.Location = new System.Drawing.Point(156, 388);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(111, 50);
            this.btnLuu.TabIndex = 7;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnThem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnThem.Location = new System.Drawing.Point(28, 388);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(111, 50);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox7.Enabled = false;
            this.pictureBox7.Image = global::QuanLyCuaHang.Properties.Resources.Repair;
            this.pictureBox7.Location = new System.Drawing.Point(287, 392);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(47, 41);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 18;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox6.Enabled = false;
            this.pictureBox6.Image = global::QuanLyCuaHang.Properties.Resources.Trash_empty1;
            this.pictureBox6.Location = new System.Drawing.Point(415, 392);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(47, 41);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 17;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox5.Enabled = false;
            this.pictureBox5.Image = global::QuanLyCuaHang.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_view_refresh;
            this.pictureBox5.Location = new System.Drawing.Point(543, 392);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(47, 41);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 16;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox3.Enabled = false;
            this.pictureBox3.Image = global::QuanLyCuaHang.Properties.Resources.Delete;
            this.pictureBox3.Location = new System.Drawing.Point(671, 393);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(45, 40);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox2.Enabled = false;
            this.pictureBox2.Image = global::QuanLyCuaHang.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_document_save_all;
            this.pictureBox2.Location = new System.Drawing.Point(159, 392);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(47, 41);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox1.BackgroundImage = global::QuanLyCuaHang.Properties.Resources.icon1;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = global::QuanLyCuaHang.Properties.Resources.edit_add;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(31, 392);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // frmLoai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 450);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnLammoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtTenloai);
            this.Controls.Add(this.txtMaloai);
            this.Controls.Add(this.dgvLoai);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmLoai";
            this.Text = "Danh mục loại hàng";
            this.Load += new System.EventHandler(this.frmLoai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvLoai;
        private System.Windows.Forms.TextBox txtMaloai;
        private System.Windows.Forms.TextBox txtTenloai;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLammoi;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
    }
}