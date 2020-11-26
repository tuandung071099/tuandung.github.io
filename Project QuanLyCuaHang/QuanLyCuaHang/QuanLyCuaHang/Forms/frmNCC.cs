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
            txtMaNCC.Text = ThucThiSQL.AutoGenerate2("NCC", "tblNCC");
            txtMaNCC.ReadOnly = true;
            txtTenNCC.Enabled = true;
            txtDiachi.Enabled = true;
            txtSDT.Enabled = true;
            btnLuu.Enabled = true;
            SemiReset();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaNCC.Text == "")
            {
                MessageBox.Show("Bạn phải nhập Mã NCC");
                return;
            }
            if (txtTenNCC.Text == "")
            {
                MessageBox.Show("Bạn phải nhập Tên NCC");
                txtTenNCC.Focus();
                return;
            }
            sql = "SELECT * FROM tblNCC WHERE MaNCC ='" + txtMaNCC.Text + "'";
            DataTable dt = ThucThiSQL.DocBang(sql);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Bạn đã nhập trùng MÃ NCC");
                txtMaNCC.Text = "";
                txtMaNCC.Focus();
                return;
            }
            sql = "INSERT INTO tblNCC(MaNCC,TenNCC,DiaChi,SDT) " +
                "VALUES (N'" + txtMaNCC.Text + "',N'" + txtTenNCC.Text + "',N'" + txtDiachi.Text + "',N'" + txtSDT.Text + "')";
            ThucThiSQL.CapNhapDuLieu(sql);
            HienThi_Luoi();
            Reset();
            btnLuu.Enabled = false;
            txtTenNCC.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtTenNCC.Text == "")
            {
                MessageBox.Show("Bạn phải nhập TÊN NCC");
                txtTenNCC.Focus();
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
            sql = "UPDATE tblNCC SET TenNCC = N'" + txtTenNCC.Text + "'," +
                "DiaChi = N'" + txtDiachi.Text + "',SDT = N'" + txtSDT.Text + "' WHERE " +
                "MaNCC= N'" + txtMaNCC.Text + "'";
            ThucThiSQL.CapNhapDuLieu(sql);
            HienThi_Luoi();
            Reset();
            Disable();
            SemiReset();
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

        private void dgvNCC_Click(object sender, EventArgs e)
        {
            txtTenNCC.Enabled = true;
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
    }
}
