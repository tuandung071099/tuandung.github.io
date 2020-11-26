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
            dgvNV.Columns[4].Width = 100;
            dgvNV.Columns[5].HeaderText = "SĐT";
            dgvNV.Columns[5].Width = 150;
            dgvNV.AllowUserToAddRows = false;
            dgvNV.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        public void SemiReset()
        {
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            txtTenNV.Text = "";
            txtDiachi.Text = "";
            dtpNgaySinh.Text = "";
            txtSDT.Text = "";
            cboGioiTinh.SelectedIndex = -1;
        }

        public void Reset()
        {
            txtTenNV.ReadOnly = false;
            btnThem.Enabled = true;
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtDiachi.Text = "";
            dtpNgaySinh.Text = "";
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

            dtpNgaySinh.Text = "";
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
            txtTenNV.ReadOnly = false;
            txtMaNV.Text = ThucThiSQL.AutoGenerate("NV", "tblNV");
            Enable();
            SemiReset();
            btnThem.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaNV.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập Mã NV", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenNV.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập Tên NV", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNV.Focus();
                return;
            }
            if (DateTime.TryParse(dtpNgaySinh.Text, out DateTime dDate) == false)
            {
                MessageBox.Show("Bạn nhập sai Ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaySinh.Text = "";
                dtpNgaySinh.Focus();
                return;
            }
            sql = "SELECT * FROM tblNV WHERE MaNV ='" + txtMaNV.Text + "'";
            DataTable dt = ThucThiSQL.DocBang(sql);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Bạn đã nhập trùng MÃ NV", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaNV.Text = "";
                txtMaNV.Focus();
                return;
            }
            sql = "SELECT * FROM tblNV WHERE SDT ='" + txtSDT.Text + "'";
            dt = ThucThiSQL.DocBang(sql);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Bạn đã nhập trùng SDT", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSDT.Text = "";
                txtSDT.Focus();
                return;
            }
            sql = "INSERT INTO tblNV(MaNV,TenNV,GioiTinh,DiaChi,NgaySinh,SDT) " +
                "VALUES (N'" + txtMaNV.Text + "',N'" + txtTenNV.Text + "',N'" + cboGioiTinh.Text + "',N'" + txtDiachi.Text + "',N'" + dtpNgaySinh.Value.ToString("MM/dd/yyyy") + "',N'" + txtSDT.Text + "')";
            ThucThiSQL.CapNhatDuLieu(sql);
            HienThi_Luoi();
            Reset();
            btnLuu.Enabled = false;
            txtTenNV.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtTenNV.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập TÊN NV", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNV.Focus();
                return;
            }
            if (txtDiachi.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập Địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiachi.Focus();
                return;
            }
            if (txtSDT.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập SDT", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label.Focus();
                return;
            }
            if (DateTime.TryParse(dtpNgaySinh.Text, out DateTime dDate) == false)
            {
                MessageBox.Show("Bạn nhập sai Ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaySinh.Text = "";
                dtpNgaySinh.Focus();
                return;
            }
            sql = "SELECT * FROM tblNV WHERE SDT ='" + txtSDT.Text + "' AND MaNV <> '" + txtMaNV.Text + "'";
            DataTable dt = ThucThiSQL.DocBang(sql);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Bạn đã nhập trùng SDT", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSDT.Text = "";
                txtSDT.Focus();
                return;
            }
            sql = "UPDATE tblNV SET TenNV = N'" + txtTenNV.Text + "',GioiTinh = N'" + cboGioiTinh.Text + "'," +
                "DiaChi = N'" + txtDiachi.Text + "',NgaySinh = N'" + dtpNgaySinh.Value.ToString("MM/dd/yyyy") +"',SDT = N'" + txtSDT.Text + "' WHERE " +
                "MaNV= N'" + txtMaNV.Text + "'";
            ThucThiSQL.CapNhatDuLieu(sql);
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
                MessageBox.Show("KHÔNG CÓ DỮ LIỆU");
                return;
            }
            string ma = dgvNV.CurrentRow.Cells["MaNV"].Value.ToString();

            if (MessageBox.Show("Bạn có muốn xóa không? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE FROM tblTK WHERE MaNV =N'" + ma + "' ";
                ThucThiSQL.CapNhatDuLieu(sql);
                sql = "DELETE FROM tblNV WHERE MaNV =N'" + ma + "' ";
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
            btnThem.Enabled = true;
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

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            bool CheckValid2 = int.TryParse(txtSDT.Text, out int Num);
            if (txtSDT.Text == "")
            {
                CheckValid2 = true;
            }
            if (CheckValid2 == false)
            {
                int index = txtSDT.SelectionStart;
                txtSDT.Text = txtSDT.Text.Remove(txtSDT.SelectionStart - 1, 1);
                txtSDT.SelectionStart = index;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "EXEC proc_TimkiemNV N'{0}'";
            sql = string.Format(sql, txtTentim.Text);
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
    }
}
