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
            string sql = "SELECT MaSP,TenSP,MaLoai,SoLuong,DonGiaNhap,DonGiaBan,Anh,GhiChu FROM tblSP ";
            DataTable dt = ThucThiSQL.DocBang(sql);
            dgvSP.DataSource = dt;
            dgvSP.Columns[0].HeaderText = "Mã SP";
            dgvSP.Columns[0].Width = 58;
            dgvSP.Columns[1].HeaderText = "Tên SP";
            dgvSP.Columns[1].Width = 150;
            dgvSP.Columns[2].HeaderText = "Mã Loại";
            dgvSP.Columns[2].Width = 50;
            dgvSP.Columns[3].HeaderText = "Số Lượng";
            dgvSP.Columns[3].Width = 200;
            dgvSP.Columns[4].HeaderText = "Đơn Giá Nhập";
            dgvSP.Columns[4].Width = 150;
            dgvSP.Columns[5].HeaderText = "Đơn giá Bán";
            dgvSP.Columns[5].Width = 100;
            dgvSP.Columns[6].HeaderText = "Ảnh";
            dgvSP.Columns[6].Width = 100;
            dgvSP.Columns[7].HeaderText = "Ghi chú";
            dgvSP.Columns[7].Width = 100;
            dgvSP.AllowUserToAddRows = false;
            dgvSP.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        public void SemiReset()
        {
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            txtTenSP.Text = "";
            cboMaLoai.SelectedIndex = -1;
            txtDongiaNhap.Text = "";
            txtDongiaBan.Text = "";
            txtSoluong.Text = "";
            txtLink.Text = "";
            txtGhichu.Text = "";

        }

        public void Reset()
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            cboMaLoai.SelectedIndex = -1;
            txtDongiaNhap.Text = "";
            txtDongiaBan.Text = "";
            txtSoluong.Text = "";
            txtLink.Text = "";
            txtGhichu.Text = "";
        }

        public void Disable()
        {
            txtTenSP.Enabled = false;
            cboMaLoai.Enabled = false;
            txtDongiaNhap.Enabled = false;
            txtDongiaBan.Enabled = false;
            txtSoluong.Enabled = false;
            txtLink.Enabled = false;
            txtGhichu.Enabled = false;
        }

        public void Enable()
        {
            txtTenSP.Enabled = true;
            cboMaLoai.Enabled = true;
            txtDongiaNhap.Enabled = true;
            txtDongiaBan.Enabled = true;
            txtSoluong.Enabled = true;
            txtLink.Enabled = true;
            txtGhichu.Enabled = true;
        }

        private void frmSP_Load(object sender, EventArgs e)
        {
            cboMaLoai.DataSource = ThucThiSQL.DocBang("SELECT MaLoai FROM tblLoai");
            cboMaLoai.ValueMember = "MaLoai";
            cboMaLoai.SelectedIndex = -1;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            Disable();
            txtMaSP.ReadOnly = true;
            btnLuu.Enabled = false;
            HienThi_Luoi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaSP.Text = ThucThiSQL.AutoGenerate("SP", "tblSP");
            Enable();
            SemiReset();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaSP.Text == "")
            {
                MessageBox.Show("Bạn phải nhập Mã SP");
                return;
            }
            if (txtTenSP.Text == "")
            {
                MessageBox.Show("Bạn phải nhập Tên SP");
                txtTenSP.Focus();
                return;
            }
            sql = "SELECT * FROM tblSP WHERE MaSP ='" + txtMaSP.Text + "'";
            DataTable dt = ThucThiSQL.DocBang(sql);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Bạn đã nhập trùng MÃ SP");
                txtMaSP.Text = "";
                txtMaSP.Focus();
                return;
            }
            sql = "INSERT INTO tblSP (MaSP,TenSP,MaLoai,DonGiaNhap,DonGiaBan,SoLuong,Anh,GhiChu) " +
                "VALUES (N'" + txtMaSP.Text + "',N'" + txtTenSP.Text + "',N'" + cboMaLoai.Text + "'," +
                "" + txtDongiaNhap.Text + "," + txtDongiaBan.Text + "," + txtSoluong.Text + "," +
                "N'" + txtLink.Text + "',N'" + txtGhichu.Text + "')";
            ThucThiSQL.CapNhapDuLieu(sql);
            HienThi_Luoi();
            Reset();
            btnLuu.Enabled = false;
            txtTenSP.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtTenSP.Text == "")
            {
                MessageBox.Show("Bạn phải nhập TÊN NV");
                txtTenSP.Focus();
                return;
            }
            if (cboMaLoai.Text == "")
            {
                MessageBox.Show("Bạn phải nhập Địa chỉ");
                cboMaLoai.Focus();
                return;
            }
            if (txtDongiaNhap.Text == "")
            {
                MessageBox.Show("Bạn phải nhập SDT");
                txtDongiaNhap.Focus();
                return;
            }
            if (txtDongiaBan.Text == "")
            {
                MessageBox.Show("Bạn phải nhập SDT");
                txtDongiaBan.Focus();
                return;
            }
            if (txtSoluong.Text == "")
            {
                MessageBox.Show("Bạn phải nhập SDT");
                txtDongiaBan.Focus();
                return;
            }
            sql = "UPDATE tblNV SET TenSP=N'" + txtTenSP.Text + "',MaLoai=N'" + cboMaLoai.Text + "'," +
                "DonGiaNhap=" + txtDongiaNhap.Text + ",DonGiaBan=" + txtDongiaBan.Text + ",SoLuong=" + txtSoluong.Text + "," +
                "Anh=N'" + txtLink.Text + "',GhiChu=N'" + txtGhichu.Text + "' WHERE " +
                "MaSP= N'" + txtMaSP.Text + "'";
            ThucThiSQL.CapNhapDuLieu(sql);
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
                ThucThiSQL.CapNhapDuLieu(sql);
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
            SemiReset();
            Disable();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
