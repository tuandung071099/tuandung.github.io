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
    public partial class frmNCC : Form
    {
        public frmNCC()
        {
            InitializeComponent();
        }

        public void HienThi_Luoi()
        {
            string sql = "SELECT * FROM tblNCC ";
            DataTable dt = ThucThiSQL.DocBang(sql);
            dgvNCC.DataSource = dt;
            dgvNCC.Columns[0].HeaderText = "Mã NCC";
            dgvNCC.Columns[0].Width = 108;
            dgvNCC.Columns[1].HeaderText = "Tên NCC";
            dgvNCC.Columns[1].Width = 200;
            dgvNCC.Columns[2].HeaderText = "Địa chỉ";
            dgvNCC.Columns[2].Width = 250;
            dgvNCC.Columns[3].HeaderText = "SĐT";
            dgvNCC.Columns[3].Width = 150;
            dgvNCC.AllowUserToAddRows = false;
            dgvNCC.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        public void SemiReset()
        {
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            txtTenNCC.Text = "";
            txtDiachi.Text = "";
            txtSDT.Text = "";
        }

        public void Reset()
        {
            txtTenNCC.ReadOnly = false;
            btnThem.Enabled = true;
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtDiachi.Text = "";
            txtSDT.Text = "";
        }

        public void Disable()
        {
            txtTenNCC.Enabled = false;
            txtDiachi.Enabled = false;
            txtSDT.Enabled = false;
        }

        private void frmNCC_Load(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            Disable();
            txtMaNCC.ReadOnly = true;
            btnLuu.Enabled = false;
            HienThi_Luoi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtTenNCC.ReadOnly = false;
            txtMaNCC.Text = ThucThiSQL.AutoGenerate2("NCC", "tblNCC");
            txtMaNCC.ReadOnly = true;
            txtTenNCC.Enabled = true;
            txtDiachi.Enabled = true;
            txtSDT.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            SemiReset();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
                { 
                string sql;
                if (txtTenNCC.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn phải nhập Tên NCC", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenNCC.Focus();
                    return;
                }
                DataTable dt;
                sql = "SELECT * FROM tblNCC WHERE TenNCC ='" + txtTenNCC.Text + "'";
                dt = ThucThiSQL.DocBang(sql);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Bạn đã nhập trùng Tên NCC", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTenNCC.Text = "";
                    txtTenNCC.Focus();
                    return;
                }
                sql = "SELECT * FROM tblNCC WHERE SDT ='" + txtSDT.Text + "'";
                dt = ThucThiSQL.DocBang(sql);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Bạn đã nhập trùng SDT NCC", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSDT.Text = "";
                    txtSDT.Focus();
                    return;
                }
                sql = "INSERT INTO tblNCC(MaNCC,TenNCC,DiaChi,SDT) " +
                    "VALUES (N'" + txtMaNCC.Text + "',N'" + txtTenNCC.Text + "',N'" + txtDiachi.Text + "',N'" + txtSDT.Text + "')";
                ThucThiSQL.CapNhatDuLieu(sql);
                HienThi_Luoi();
                Reset();
                btnLuu.Enabled = false;
                txtTenNCC.Enabled = false;
                }
            catch
                {
                    MessageBox.Show("Đã xảy ra lỗi, xin thử lại sau");
                }
    }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string sql;
                if (txtTenNCC.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn phải nhập TÊN NCC", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenNCC.Focus();
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
                sql = "SELECT * FROM tblNCC WHERE SDT ='" + txtSDT.Text + "' AND MaNCC <> '" + txtMaNCC.Text + "'";
                DataTable dt = ThucThiSQL.DocBang(sql);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Bạn đã nhập trùng SDT NCC", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSDT.Text = "";
                    txtSDT.Focus();
                    return;
                }
                sql = "SELECT * FROM tblNCC WHERE TenNCC ='" + txtTenNCC.Text + "' AND MaNCC <> '" + txtMaNCC.Text + "'";
                dt = ThucThiSQL.DocBang(sql);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Bạn đã nhập trùng Tên NCC", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTenNCC.Text = "";
                    txtTenNCC.Focus();
                    return;
                }
                sql = "UPDATE tblNCC SET TenNCC = N'" + txtTenNCC.Text + "'," +
                    "DiaChi = N'" + txtDiachi.Text + "',SDT = N'" + txtSDT.Text + "' WHERE " +
                    "MaNCC= N'" + txtMaNCC.Text + "'";
                ThucThiSQL.CapNhatDuLieu(sql);
                HienThi_Luoi();
                Reset();
                Disable();
                SemiReset();
            } 
            catch
                {
                    MessageBox.Show("Đã xảy ra lỗi, xin thử lại sau");
                }
            }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (dgvNCC.Rows.Count == 0)
            {
                MessageBox.Show("KHÔNG CÓ DỮ LIỆU");
                return;
            }
            string ma = dgvNCC.CurrentRow.Cells["MaNCC"].Value.ToString();

            if (MessageBox.Show("Bạn có muốn xóa không? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE FROM tblNCC WHERE MaNCC =N'" + ma + "' ";
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

        private void dgvNCC_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            txtDiachi.Enabled = true;
            txtSDT.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            txtMaNCC.Text = dgvNCC.CurrentRow.Cells["MaNCC"].Value.ToString();
            txtTenNCC.Text = dgvNCC.CurrentRow.Cells["TenNCC"].Value.ToString();
            txtDiachi.Text = dgvNCC.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtSDT.Text = dgvNCC.CurrentRow.Cells["SDT"].Value.ToString();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
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
            if (rdoTheoTen.Checked == true)
            {
                string sql = "EXEC proc_TimkiemNCC N'{0}'";
                sql = string.Format(sql, txtTentim.Text);
                DataTable dt = ThucThiSQL.DocBang(sql);
                dgvNCC.DataSource = dt;
                dgvNCC.Columns[0].HeaderText = "Mã NCC";
                dgvNCC.Columns[0].Width = 108;
                dgvNCC.Columns[1].HeaderText = "Tên NCC";
                dgvNCC.Columns[1].Width = 200;
                dgvNCC.Columns[2].HeaderText = "Địa chỉ";
                dgvNCC.Columns[2].Width = 250;
                dgvNCC.Columns[3].HeaderText = "SĐT";
                dgvNCC.Columns[3].Width = 150;
                dgvNCC.AllowUserToAddRows = false;
                dgvNCC.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            if (rdoTheoMa.Checked == true)
            {
                string sql = "EXEC proc_TimkiemNCCTheoMa N'{0}'";
                sql = string.Format(sql, txtTentim.Text);
                DataTable dt = ThucThiSQL.DocBang(sql);
                dgvNCC.DataSource = dt;
                dgvNCC.Columns[0].HeaderText = "Mã NCC";
                dgvNCC.Columns[0].Width = 108;
                dgvNCC.Columns[1].HeaderText = "Tên NCC";
                dgvNCC.Columns[1].Width = 200;
                dgvNCC.Columns[2].HeaderText = "Địa chỉ";
                dgvNCC.Columns[2].Width = 250;
                dgvNCC.Columns[3].HeaderText = "SĐT";
                dgvNCC.Columns[3].Width = 150;
                dgvNCC.AllowUserToAddRows = false;
                dgvNCC.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            if (rdoTheoSDT.Checked == true)
            {
                string sql = "EXEC proc_TimkiemNCCTheoSDT N'{0}'";
                sql = string.Format(sql, txtTentim.Text);
                DataTable dt = ThucThiSQL.DocBang(sql);
                dgvNCC.DataSource = dt;
                dgvNCC.Columns[0].HeaderText = "Mã NCC";
                dgvNCC.Columns[0].Width = 108;
                dgvNCC.Columns[1].HeaderText = "Tên NCC";
                dgvNCC.Columns[1].Width = 200;
                dgvNCC.Columns[2].HeaderText = "Địa chỉ";
                dgvNCC.Columns[2].Width = 250;
                dgvNCC.Columns[3].HeaderText = "SĐT";
                dgvNCC.Columns[3].Width = 150;
                dgvNCC.AllowUserToAddRows = false;
                dgvNCC.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            txtTentim.Text = "";
            rdoTheoSDT.Checked = false;
            rdoTheoTen.Checked = false;
            rdoTheoMa.Checked = false;
        }

        private void rdoTheoTen_CheckedChanged(object sender, EventArgs e)
        {
            txtTentim.Text = "";
        }

        private void rdoTheoMa_CheckedChanged(object sender, EventArgs e)
        {
            txtTentim.Text = "";
        }
    }
}
