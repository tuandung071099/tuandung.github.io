namespace QuanLyCuaHang.Forms
{
    partial class frmHangSapHet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHangSapHet));
            this.btnInHD = new System.Windows.Forms.Button();
            this.btnLammoi = new System.Windows.Forms.Button();
            this.dgvTonkho = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnDong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTonkho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInHD
            // 
            this.btnInHD.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnInHD.Location = new System.Drawing.Point(140, 396);
            this.btnInHD.Name = "btnInHD";
            this.btnInHD.Size = new System.Drawing.Size(111, 50);
            this.btnInHD.TabIndex = 67;
            this.btnInHD.Text = "In BC";
            this.btnInHD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInHD.UseVisualStyleBackColor = false;
            this.btnInHD.Click += new System.EventHandler(this.btnInHD_Click);
            // 
            // btnLammoi
            // 
            this.btnLammoi.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnLammoi.Location = new System.Drawing.Point(12, 396);
            this.btnLammoi.Name = "btnLammoi";
            this.btnLammoi.Size = new System.Drawing.Size(122, 50);
            this.btnLammoi.TabIndex = 65;
            this.btnLammoi.Text = "Làm mới";
            this.btnLammoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLammoi.UseVisualStyleBackColor = false;
            // 
            // dgvTonkho
            // 
            this.dgvTonkho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTonkho.Location = new System.Drawing.Point(12, 57);
            this.dgvTonkho.Name = "dgvTonkho";
            this.dgvTonkho.RowTemplate.Height = 24;
            this.dgvTonkho.Size = new System.Drawing.Size(776, 332);
            this.dgvTonkho.TabIndex = 64;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.ForestGreen;
            this.label1.Location = new System.Drawing.Point(206, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(377, 36);
            this.label1.TabIndex = 63;
            this.label1.Text = "Danh Sách Hàng Sắp Hết";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Image = global::QuanLyCuaHang.Properties.Resources.Printer_print_3d_vector_symbol_simple_pictogram;
            this.pictureBox1.Location = new System.Drawing.Point(143, 401);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 68;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox5.Enabled = false;
            this.pictureBox5.Image = global::QuanLyCuaHang.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_view_refresh;
            this.pictureBox5.Location = new System.Drawing.Point(15, 400);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(47, 41);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 66;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox3.Enabled = false;
            this.pictureBox3.Image = global::QuanLyCuaHang.Properties.Resources.Delete;
            this.pictureBox3.Location = new System.Drawing.Point(680, 405);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(45, 40);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 70;
            this.pictureBox3.TabStop = false;
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnDong.Location = new System.Drawing.Point(677, 401);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(111, 50);
            this.btnDong.TabIndex = 69;
            this.btnDong.Text = "Đóng";
            this.btnDong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // frmHangSapHet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 457);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnInHD);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.btnLammoi);
            this.Controls.Add(this.dgvTonkho);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHangSapHet";
            this.Text = "Hàng sắp hết";
            this.Load += new System.EventHandler(this.frmHangSapHet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTonkho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnInHD;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button btnLammoi;
        private System.Windows.Forms.DataGridView dgvTonkho;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnDong;
    }
}