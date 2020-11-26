using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHang.Forms
{
    public partial class frmSP : Form
    {
        public frmSP()
        {
            InitializeComponent();
        }

        public void HienThi_Luoi()
        {
            string sql = "SELECT MaSP,TenSP,MaLoai,DonViTinh,SoLuongTon,DonGiaNhap,DonGiaBan,GioiHanTon FROM tblSP ";
            DataTable dt = ThucThiSQL.DocBang(sql);
            dgvSP.DataSource = dt;
            dgvSP.Columns[0].HeaderText = "Mã SP";
            dgvSP.Columns[0].Width = 83;
            dgvSP.Columns[1].HeaderText = "Tên SP";
            dgvSP.Columns[1].Width = 165;
            dgvSP.Columns[2].HeaderText = "Mã Loại";
            dgvSP.Columns[2].Width = 60;
            dgvSP.Columns[3].HeaderText = "Đơn vị tính";
            dgvSP.Columns[3].Width = 50;
            dgvSP.Columns[4].HeaderText = "Số Lượng Tồn";
            dgvSP.Columns[4].Width = 50;
            dgvSP.Columns[5].HeaderText = "Đơn Giá Nhập";
            dgvSP.Columns[5].Width = 125;
            dgvSP.Columns[6].HeaderText = "Đơn giá Bán";
            dgvSP.Columns[6].Width = 125;
            dgvSP.Columns[7].HeaderText = "Giới Hạn Tồn";
            dgvSP.Columns[7].Width = 50;
            dgvSP.AllowUserToAddRows = false;
            dgvSP.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        public void SemiReset()
        {
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            txtTenSP.Text = "";
            cboMaLoai.Text = "";
            txtDongiaNhap.Text = "";
            txtDongiaBan.Text = "";
            txtGioiHanTon.Text = "";
            txtSoLuongTon.Text = "";
            txtDonViTinh.Text = "";
        }

        public void Reset()
        {
            txtTenSP.ReadOnly = false;
            btnThem.Enabled = true;
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            cboMaLoai.Text = "";
            txtDongiaNhap.Text = "";
            txtDongiaBan.Text = "";
            txtGioiHanTon.Text = "";
            txtSoLuongTon.Text = "";
            txtDonViTinh.Text = "";
        }

        public void Disable()
        {
            txtTenSP.Enabled = false;
            cboMaLoai.Enabled = false;
            txtDongiaNhap.Enabled = false;
            txtDongiaBan.Enabled = false;
            txtGioiHanTon.Enabled = false;
            txtSoLuongTon.Enabled = false;
            txtDonViTinh.Enabled = false;
        }

        public void Enable()
        {
            btnLuu.Enabled = true;
            txtTenSP.Enabled = true;
            cboMaLoai.Enabled = true;
            txtDongiaNhap.Enabled = true;
            txtDongiaBan.Enabled = true;
            txtGioiHanTon.Enabled = true;
            txtSoLuongTon.Enabled = true;
            txtDonViTinh.Enabled = true;
        }

        private void frmSP_Load(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            Disable();
            txtMaSP.ReadOnly = true;
            txtTenLoai.ReadOnly = true;
            txtSoLuongTon.ReadOnly = true;
            txtDongiaBan.ReadOnly = true;
            txtDongiaNhap.ReadOnly = true;
            btnLuu.Enabled = false;
            HienThi_Luoi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtTenSP.ReadOnly = false;
            btnThem.Enabled = false;
            txtMaSP.Text = ThucThiSQL.AutoGenerate("SP", "tblSP");
            Enable();
            SemiReset();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            txtSoLuongTon.Text = "0";
            txtDongiaBan.Text = "0";
            txtDongiaNhap.Text = "0";
            string sql;
            DataTable dt;
            if (txtMaSP.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập Mã SP", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSP.Focus();
                return;
            }
            if (txtTenSP.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập Tên SP", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenSP.Focus();
                return;
            }
            sql = "SELECT * FROM tblSP WHERE MaSP ='" + txtMaSP.Text + "'";
            dt = ThucThiSQL.DocBang(sql);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Bạn đã nhập trùng MÃ SP", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaSP.Text = "";
                txtMaSP.Focus();
                return;
            }
            sql = "SELECT * FROM tblSP WHERE TenSP ='" + txtTenSP.Text + "'";
            dt = ThucThiSQL.DocBang(sql);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Bạn đã nhập trùng Tên SP", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenSP.Text = "";
                txtTenSP.Focus();
                return;
            }
            sql = "INSERT INTO tblSP (MaSP,TenSP,MaLoai,DonViTinh,DonGiaNhap,DonGiaBan,SoLuongTon,GioiHanTon) " +
                "VALUES (N'" + txtMaSP.Text + "',N'" + txtTenSP.Text + "',N'" + cboMaLoai.Text + "',N'" + txtDonViTinh.Text + "'," +
                "" + txtDongiaNhap.Text + "," + txtDongiaBan.Text + "," + txtSoLuongTon.Text + "," +
                "" + txtGioiHanTon.Text + ")";
            ThucThiSQL.CapNhatDuLieu(sql);
            HienThi_Luoi();
            Reset();
            btnLuu.Enabled = false;
            txtTenSP.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtTenSP.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập Tên SP", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenSP.Focus();
                return;
            }
            if (cboMaLoai.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải chọn Mã loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaLoai.Focus();
                return;
            }
            if (txtGioiHanTon.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập Giới hạn tồn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGioiHanTon.Focus();
                return;
            }
            if (txtDonViTinh.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập Đơn vị tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDonViTinh.Focus();
                return;
            }
            sql = "SELECT * FROM tblSP WHERE TenSP ='" + txtTenSP.Text + "' AND MaSP <> '"+txtMaSP.Text+"'";
            DataTable dt = ThucThiSQL.DocBang(sql);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Bạn đã nhập trùng Tên SP", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenSP.Text = "";
                txtTenSP.Focus();
                return;
            }
            sql = "UPDATE tblSP SET TenSP=N'" + txtTenSP.Text + "',MaLoai=N'" + cboMaLoai.Text + "',DonViTinh=N'" + txtDonViTinh.Text + "'," +
                "DonGiaNhap=" + txtDongiaNhap.Text + ",DonGiaBan=" + txtDongiaBan.Text + ",SoLuongTon=" + txtSoLuongTon.Text + "," +
                "GioiHanTon=" + txtGioiHanTon.Text + " WHERE " +
                "MaSP= N'" + txtMaSP.Text + "'";
            ThucThiSQL.CapNhatDuLieu(sql);
            HienThi_Luoi();
            Reset();
            Disable();
            SemiReset();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (dgvSP.Rows.Count == 0)
            {
                MessageBox.Show("KHÔNG CÓ DỮ LIỆU");
                return;
            }
            string ma = dgvSP.CurrentRow.Cells["MaSP"].Value.ToString();

            if (MessageBox.Show("Bạn có muốn xóa không? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE FROM tblSP WHERE MaSP =N'" + ma + "' ";
                ThucThiSQL.CapNhatDuLieu(sql);
                HienThi_Luoi();
                Reset();
                SemiReset();
                Disable();
            }
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            HienThi_Luoi();
            Reset();
            btnLuu.Enabled = false;
            txtTentim.Text = "";
            SemiReset();
            Disable();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboMaLoai_TextChanged(object sender, EventArgs e)
        {
            if(cboMaLoai.Text=="")
            {
                txtTenLoai.Text = "";
            }
            if (ThucThiSQL.DocBang("SELECT TenLoai FROM tblLoai WHERE MaLoai=N'" + cboMaLoai.Text + "'").Rows.Count > 0)
                txtTenLoai.Text = ThucThiSQL.DocBang("SELECT TenLoai FROM tblLoai WHERE MaLoai=N'" + cboMaLoai.Text + "'").Rows[0][0].ToString();
        }

        private void cboMaLoai_DropDown(object sender, EventArgs e)
        {
            cboMaLoai.DataSource = ThucThiSQL.DocBang("SELECT MaLoai FROM tblLoai");
            cboMaLoai.ValueMember = "MaLoai";
            cboMaLoai.SelectedIndex = -1;
        }

        private void dgvSP_Click(object sender, EventArgs e)
        {
            Enable();
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            txtMaSP.Text = dgvSP.CurrentRow.Cells["MaSP"].Value.ToString();
            txtTenSP.Text = dgvSP.CurrentRow.Cells["TenSP"].Value.ToString();
            cboMaLoai.Text = dgvSP.CurrentRow.Cells["MaLoai"].Value.ToString();
            txtDonViTinh.Text = dgvSP.CurrentRow.Cells["DonViTinh"].Value.ToString();
            txtSoLuongTon.Text = dgvSP.CurrentRow.Cells["SoLuongTon"].Value.ToString();
            txtDongiaBan.Text = dgvSP.CurrentRow.Cells["DonGiaBan"].Value.ToString();
            txtDongiaNhap.Text = dgvSP.CurrentRow.Cells["DonGiaNhap"].Value.ToString();
            txtGioiHanTon.Text = dgvSP.CurrentRow.Cells["GioiHanTon"].Value.ToString();        
        }

        private void txtGioiHanTon_TextChanged(object sender, EventArgs e)
        {
            bool CheckValid2 = int.TryParse(txtGioiHanTon.Text, out int Num);
            if (txtGioiHanTon.Text == "")
            {
                CheckValid2 = true;
            }
            if (CheckValid2 == false)
            {
                int index = txtGioiHanTon.SelectionStart;
                txtGioiHanTon.Text = txtGioiHanTon.Text.Remove(txtGioiHanTon.SelectionStart - 1, 1);
                txtGioiHanTon.SelectionStart = index;
            }
        }

        private void cboMaLoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (rdoTheoTen.Checked == true)
            {
                string sql = "EXEC proc_TimkiemSP N'{0}'";
                sql = string.Format(sql, txtTentim.Text);
                DataTable dt = ThucThiSQL.DocBang(sql);
                dgvSP.DataSource = dt;
                dgvSP.Columns[0].HeaderText = "Mã SP";
                dgvSP.Columns[0].Width = 83;
                dgvSP.Columns[1].HeaderText = "Tên SP";
                dgvSP.Columns[1].Width = 165;
                dgvSP.Columns[2].HeaderText = "Mã Loại";
                dgvSP.Columns[2].Width = 60;
                dgvSP.Columns[3].HeaderText = "Đơn vị tính";
                dgvSP.Columns[3].Width = 50;
                dgvSP.Columns[4].HeaderText = "Số Lượng Tồn";
                dgvSP.Columns[4].Width = 50;
                dgvSP.Columns[5].HeaderText = "Đơn Giá Nhập";
                dgvSP.Columns[5].Width = 125;
                dgvSP.Columns[6].HeaderText = "Đơn giá Bán";
                dgvSP.Columns[6].Width = 125;
                dgvSP.Columns[7].HeaderText = "Giới Hạn Tồn";
                dgvSP.Columns[7].Width = 50;
                dgvSP.AllowUserToAddRows = false;
                dgvSP.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            if (rdoTheoMa.Checked == true)
            {
                string sql = "EXEC proc_TimkiemSPTheoMa N'{0}'";
                sql = string.Format(sql, txtTentim.Text);
                DataTable dt = ThucThiSQL.DocBang(sql);
                dgvSP.DataSource = dt;
                dgvSP.Columns[0].HeaderText = "Mã SP";
                dgvSP.Columns[0].Width = 83;
                dgvSP.Columns[1].HeaderText = "Tên SP";
                dgvSP.Columns[1].Width = 165;
                dgvSP.Columns[2].HeaderText = "Mã Loại";
                dgvSP.Columns[2].Width = 60;
                dgvSP.Columns[3].HeaderText = "Đơn vị tính";
                dgvSP.Columns[3].Width = 50;
                dgvSP.Columns[4].HeaderText = "Số Lượng Tồn";
                dgvSP.Columns[4].Width = 50;
                dgvSP.Columns[5].HeaderText = "Đơn Giá Nhập";
                dgvSP.Columns[5].Width = 125;
                dgvSP.Columns[6].HeaderText = "Đơn giá Bán";
                dgvSP.Columns[6].Width = 125;
                dgvSP.Columns[7].HeaderText = "Giới Hạn Tồn";
                dgvSP.Columns[7].Width = 50;
                dgvSP.AllowUserToAddRows = false;
                dgvSP.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            txtTentim.Text = "";
            rdoTheoMa.Checked = false;
            rdoTheoTen.Checked = false;
        }

        private void rdoTheoTen_CheckedChanged(object sender, EventArgs e)
        {
            txtTentim.Text = "";
        }
    }
}
