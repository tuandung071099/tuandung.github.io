using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHang.Forms.FormLoai
{
    public partial class frmLoai : Form
    {
        public frmLoai()
        {
            InitializeComponent();
        }

        public void HienThi_Luoi()
        {
            string sql = "SELECT * FROM tblLoai ";
            DataTable dt = ThucThiSQL.DocBang(sql);
            dgvLoai.DataSource = dt;
            dgvLoai.Columns[0].HeaderText = "Mã loại";
            dgvLoai.Columns[0].Width = 150;
            dgvLoai.Columns[1].HeaderText = "Tên loại";
            dgvLoai.Columns[1].Width = 558;
            dgvLoai.AllowUserToAddRows = false;
            dgvLoai.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        public void SemiReset()
        {
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            txtTenloai.Text = "";
        }

        private void frmLoai_Load(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            txtTenloai.Enabled = false;
            txtMaloai.ReadOnly = true;
            btnLuu.Enabled = false;
            HienThi_Luoi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtTenloai.ReadOnly = false;
            txtMaloai.Text = ThucThiSQL.AutoGenerate("LH", "tblLoai");
            btnThem.Enabled = false;
            txtMaloai.ReadOnly = true;
            txtTenloai.Enabled = true;
            btnLuu.Enabled = true;
            SemiReset();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string sql;
                if (txtMaloai.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn phải nhập Mã loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtTenloai.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn phải nhập Tên loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenloai.Focus();
                    return;
                }
                sql = "SELECT * FROM tblLoai WHERE MaLoai ='" + txtMaloai.Text + "'";
                DataTable dt = ThucThiSQL.DocBang(sql);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Bạn đã nhập trùng Mã Loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaloai.Text = "";
                    txtMaloai.Focus();
                    return;
                }
                sql = "SELECT * FROM tblLoai WHERE TenLoai ='" + txtTenloai.Text + "'";
                dt = ThucThiSQL.DocBang(sql);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Bạn đã nhập trùng Tên loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTenloai.Text = "";
                    txtTenloai.Focus();
                    return;
                }
                sql = "INSERT INTO tblLoai(MaLoai,TenLoai) " +
                    "VALUES (N'" + txtMaloai.Text + "',N'" + txtTenloai.Text + "')";
                ThucThiSQL.CapNhatDuLieu(sql);
                HienThi_Luoi();
                txtMaloai.Text = "";
                txtTenloai.Text = "";
                btnLuu.Enabled = false;
                txtTenloai.Enabled = false;
                btnThem.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Đã xảy ra lỗi, xin thử lại sau");
            }
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            txtTentim.Text = "";
            HienThi_Luoi();
            txtMaloai.Text = "";
            btnLuu.Enabled = false;
            SemiReset();
            txtTenloai.Enabled = false;
            btnThem.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string sql;
                if (txtTenloai.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn phải nhập TÊN Loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenloai.Focus();
                    return;
                }
                sql = "SELECT * FROM tblLoai WHERE TenLoai ='" + txtTenloai.Text + "' AND MaLoai <>'"+txtMaloai.Text+"'";
                DataTable dt = ThucThiSQL.DocBang(sql);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Bạn đã nhập trùng Tên loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTenloai.Text = "";
                    txtTenloai.Focus();
                    return;
                }
                sql = "SELECT * FROM tblLoai WHERE TenLoai ='" + txtTenloai.Text + "'AND MaLoai <> '"+txtMaloai.Text+"' ";
                dt = ThucThiSQL.DocBang(sql);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Bạn đã nhập trùng Tên loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTenloai.Text = "";
                    txtTenloai.Focus();
                    return;
                }

                sql = "UPDATE tblLoai SET TenLoai = N'" + txtTenloai.Text + "' WHERE " +
                    "MaLoai= N'" + txtMaloai.Text + "'";
                ThucThiSQL.CapNhatDuLieu(sql);
                HienThi_Luoi();
                txtMaloai.Text = "";
                txtTenloai.Enabled = false;
                SemiReset();
            }
            catch
            {
                MessageBox.Show("Đã xảy ra lỗi, xin thử lại sau");
            }
        }

        private void dgvLoai_Click(object sender, EventArgs e)
        {
            txtTenloai.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            txtMaloai.Text = dgvLoai.CurrentRow.Cells["MaLoai"].Value.ToString();
            txtTenloai.Text = dgvLoai.CurrentRow.Cells["TenLoai"].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string sql;
                if (dgvLoai.Rows.Count == 0)
                {
                    MessageBox.Show("KHÔNG CÓ DỮ LIỆU");
                    return;
                }
                string ma = dgvLoai.CurrentRow.Cells["MaLoai"].Value.ToString();

                if (MessageBox.Show("Bạn có muốn xóa không? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sql = "DELETE FROM tblLoai WHERE MaLoai =N'" + ma + "' ";
                    ThucThiSQL.CapNhatDuLieu(sql);
                    HienThi_Luoi();
                    txtMaloai.Text = "";
                    SemiReset();
                    txtTenloai.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("Đã xảy ra lỗi, xin thử lại sau");
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdoTheoTen.Checked == true)
                {
                    string sql = "EXEC proc_TimkiemLoai N'{0}'";
                    sql = string.Format(sql, txtTentim.Text);
                    DataTable dt = ThucThiSQL.DocBang(sql);
                    dgvLoai.DataSource = dt;
                    dgvLoai.DataSource = dt;
                    dgvLoai.Columns[0].HeaderText = "Mã loại";
                    dgvLoai.Columns[0].Width = 150;
                    dgvLoai.Columns[1].HeaderText = "Tên loại";
                    dgvLoai.Columns[1].Width = 558;
                    dgvLoai.AllowUserToAddRows = false;
                    dgvLoai.EditMode = DataGridViewEditMode.EditProgrammatically;
                }
                if (rdoTheoMa.Checked == true)
                {
                    string sql = "EXEC proc_TimkiemLoaiTheoMa N'{0}'";
                    sql = string.Format(sql, txtTentim.Text);
                    DataTable dt = ThucThiSQL.DocBang(sql);
                    dgvLoai.DataSource = dt;
                    dgvLoai.DataSource = dt;
                    dgvLoai.Columns[0].HeaderText = "Mã loại";
                    dgvLoai.Columns[0].Width = 150;
                    dgvLoai.Columns[1].HeaderText = "Tên loại";
                    dgvLoai.Columns[1].Width = 558;
                    dgvLoai.AllowUserToAddRows = false;
                    dgvLoai.EditMode = DataGridViewEditMode.EditProgrammatically;
                }
                txtTentim.Text = "";
                rdoTheoMa.Checked = false;
                rdoTheoTen.Checked = false;
            }
            catch
            {
                MessageBox.Show("Đã xảy ra lỗi, xin thử lại sau");
            }
        }

        private void rdoTheoTen_CheckedChanged(object sender, EventArgs e)
        {
            txtTentim.Text = "";
        }
    }
}
