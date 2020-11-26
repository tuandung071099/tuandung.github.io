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
    public partial class frmNV : Form
    {
        public frmNV()
        {
            InitializeComponent();
        }

        public void HienThi_Luoi()
        {
            string sql = "SELECT MaNV,TenNV,GioiTinh,DiaChi,NgaySinh,SDT FROM tblNV ";
            DataTable dt = ThucThiSQL.DocBang(sql);
            dgvNV.DataSource = dt;
            dgvNV.Columns[0].HeaderText = "Mã NV";
            dgvNV.Columns[0].Width = 58;
            dgvNV.Columns[1].HeaderText = "Tên NV";
            dgvNV.Columns[1].Width = 150;
            dgvNV.Columns[2].HeaderText = "Giới tính";
            dgvNV.Columns[2].Width = 50;
            dgvNV.Columns[3].HeaderText = "Địa chỉ";
            dgvNV.Columns[3].Width = 200;
            dgvNV.Columns[4].HeaderText = "Ngày sinh";
            dgvNV.Columns[4].Width = 150;
            dgvNV.Columns[5].HeaderText = "SĐT";
            dgvNV.Columns[5].Width = 100;
            dgvNV.AllowUserToAddRows = false;
            dgvNV.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        public void SemiReset()
        {
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            txtTenNV.Text = "";
            txtDiachi.Text = "";
            dtpNgaySinh.Text = DateTime.Now.ToString();
            txtSDT.Text = "";
            cboGioiTinh.SelectedIndex = -1;
        }

        public void Reset()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtDiachi.Text = "";
            dtpNgaySinh.Text = DateTime.Now.ToString();
            txtSDT.Text = "";
            cboGioiTinh.SelectedIndex = -1;
        }

        public void Disable()
        {
            txtTenNV.Enabled = false;
            txtDiachi.Enabled = false;
            txtSDT.Enabled = false;
            dtpNgaySinh.Enabled = false;
            cboGioiTinh.Enabled = false;
        }

        public void Enable()
        {
            txtTenNV.Enabled = true;
            txtDiachi.Enabled = true;
            dtpNgaySinh.Enabled = true;
            txtSDT.Enabled = true;
            btnLuu.Enabled = true;
            cboGioiTinh.Enabled = true;
        }

        private void frmNV_Load(object sender, EventArgs e)
        {
            cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            Disable();
            txtMaNV.ReadOnly = true;
            btnLuu.Enabled = false;
            HienThi_Luoi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaNV.Text = ThucThiSQL.AutoGenerate("NV", "tblNV");
            Enable();
            SemiReset();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Bạn phải nhập Mã NV");
                return;
            }
            if (txtTenNV.Text == "")
            {
                MessageBox.Show("Bạn phải nhập Tên NV");
                txtTenNV.Focus();
                return;
            }
            sql = "SELECT * FROM tblNV WHERE MaNV ='" + txtMaNV.Text + "'";
            DataTable dt = ThucThiSQL.DocBang(sql);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Bạn đã nhập trùng MÃ NV");
                txtMaNV.Text = "";
                txtMaNV.Focus();
                return;
            }
            sql = "INSERT INTO tblNV(MaNV,TenNV,GioiTinh,DiaChi,NgaySinh,SDT) " +
                "VALUES (N'" + txtMaNV.Text + "',N'" + txtTenNV.Text + "',N'" + cboGioiTinh.Text + "',N'" + txtDiachi.Text + "',N'" + dtpNgaySinh.Value.ToShortDateString() + "',N'" + txtSDT.Text + "')";
            ThucThiSQL.CapNhapDuLieu(sql);
            HienThi_Luoi();
            Reset();
            btnLuu.Enabled = false;
            txtTenNV.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtTenNV.Text == "")
            {
                MessageBox.Show("Bạn phải nhập TÊN NV");
                txtTenNV.Focus();
                return;
            }
            if (txtDiachi.Text == "")
            {
                MessageBox.Show("Bạn phải nhập Địa chỉ");
                txtDiachi.Focus();
                return;
            }
            if (txtSDT.Text == "")
            {
                MessageBox.Show("Bạn phải nhập SDT");
                label.Focus();
                return;
            }
            sql = "UPDATE tblNV SET TenNV = N'" + txtTenNV.Text + "',GioiTinh = N'" + cboGioiTinh.Text + "'," +
                "DiaChi = N'" + txtDiachi.Text + "',NgaySinh = N'" + dtpNgaySinh.Value.ToString("yyyy/MM/dd") + "',SDT = N'" + txtSDT.Text + "' WHERE " +
                "MaNV= N'" + txtMaNV.Text + "'";
            ThucThiSQL.CapNhapDuLieu(sql);
            HienThi_Luoi();
            Reset();
            Disable();
            SemiReset();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (dgvNV.Rows.Count == 0)
            {
                MessageBox.Show("NVÔNG CÓ DỮ LIỆU");
                return;
            }
            string ma = dgvNV.CurrentRow.Cells["MaNV"].Value.ToString();

            if (MessageBox.Show("Bạn có muốn xóa NVông? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE FROM tblNV WHERE MaNV =N'" + ma + "' ";
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

        private void dgvNV_Click(object sender, EventArgs e)
        {
            Enable();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            txtMaNV.Text = dgvNV.CurrentRow.Cells["MaNV"].Value.ToString();
            txtTenNV.Text = dgvNV.CurrentRow.Cells["TenNV"].Value.ToString();
            txtDiachi.Text = dgvNV.CurrentRow.Cells["DiaChi"].Value.ToString();
            cboGioiTinh.Text = dgvNV.CurrentRow.Cells["GioiTinh"].Value.ToString();
            dtpNgaySinh.Text = dgvNV.CurrentRow.Cells["NgaySinh"].Value.ToString();
            txtSDT.Text = dgvNV.CurrentRow.Cells["SDT"].Value.ToString();
        }

        private void cboGioiTinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
