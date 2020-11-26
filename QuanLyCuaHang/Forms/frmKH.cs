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
    public partial class frmKH : Form
    {
        public frmKH()
        {
            InitializeComponent();
        }

        public void HienThi_Luoi()
        {
            string sql = "SELECT * FROM tblKH ";
            DataTable dt = ThucThiSQL.DocBang(sql);
            dgvKH.DataSource = dt;
            dgvKH.Columns[0].HeaderText = "Mã KH";
            dgvKH.Columns[0].Width = 108;
            dgvKH.Columns[1].HeaderText = "Tên KH";
            dgvKH.Columns[1].Width = 150;
            dgvKH.Columns[2].HeaderText = "Địa chỉ";
            dgvKH.Columns[2].Width = 200;
            dgvKH.Columns[3].HeaderText = "Ngày sinh";
            dgvKH.Columns[3].Width = 100;
            dgvKH.Columns[4].HeaderText = "SĐT";
            dgvKH.Columns[4].Width = 150;
            dgvKH.AllowUserToAddRows = false;
            dgvKH.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        public void SemiReset()
        {
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            txtTenKH.Text = "";
            txtDiachi.Text = "";
            dtpNgaySinh.Text = "";
            txtSDT.Text = "";
        }

        public void Reset()
        {
            txtTenKH.ReadOnly = false;
            btnThem.Enabled = true;
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtDiachi.Text = "";
            dtpNgaySinh.Text = "";
            txtSDT.Text = "";
        }

        public void Disable()
        {
            txtTenKH.Enabled = false;
            txtDiachi.Enabled = false;
            txtSDT.Enabled = false;
            dtpNgaySinh.Enabled = false;
        }

        public void Enable()
        {
            txtTenKH.Enabled = true;
            txtDiachi.Enabled = true;
            dtpNgaySinh.Enabled = true;
            txtSDT.Enabled = true;
            btnLuu.Enabled = true;
        }

        private void frmKH_Load(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            Disable();
            txtMaKH.ReadOnly = true;
            btnLuu.Enabled = false;
            HienThi_Luoi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtTenKH.ReadOnly = false;
            txtMaKH.Text = ThucThiSQL.AutoGenerate("KH", "tblKH");
            btnThem.Enabled = false;
            Enable();
            SemiReset();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaKH.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập Mã KH", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtTenKH.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập Tên KH", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKH.Focus();
                return;
            }
            if(DateTime.TryParse(dtpNgaySinh.Text, out DateTime dDate)==false)
            {
                MessageBox.Show("Bạn nhập sai Ngày sinh","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                dtpNgaySinh.Text = "";
                dtpNgaySinh.Focus();
                return;
            }

            sql = "SELECT * FROM tblKH WHERE MaKH ='" + txtMaKH.Text + "'";
            DataTable dt = ThucThiSQL.DocBang(sql);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Bạn đã nhập trùng MÃ KH", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaKH.Text = "";
                txtMaKH.Focus();
                return;
            }
            sql = "SELECT * FROM tblKH WHERE TenKH ='" + txtTenKH.Text + "'";
            dt = ThucThiSQL.DocBang(sql);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Bạn đã nhập trùng Tên KH", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenKH.Text = "";
                txtTenKH.Focus();
                return;
            }
            sql = "INSERT INTO tblKH(MaKH,TenKH,DiaChi,NgaySinh,SDT) " +
                "VALUES (N'" + txtMaKH.Text + "',N'" + txtTenKH.Text + "',N'" + txtDiachi.Text + "',N'" + dtpNgaySinh.Value.ToString("MM/dd/yyyy")+ "',N'" + txtSDT.Text + "')";
            ThucThiSQL.CapNhatDuLieu(sql);
            HienThi_Luoi();
            Reset();
            btnLuu.Enabled = false;
            txtTenKH.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtTenKH.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập TÊN KH", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKH.Focus();
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
                txtSDT.Focus();
                return;
            }
            if (DateTime.TryParse(dtpNgaySinh.Text, out DateTime dDate) == false)
            {
                MessageBox.Show("Bạn nhập sai Ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaySinh.Text = "";
                dtpNgaySinh.Focus();
                return;
            }
            sql = "SELECT * FROM tblKH WHERE SDT ='" + txtSDT.Text + "' AND MaKH <> '" + txtMaKH.Text + "'";
            DataTable dt = ThucThiSQL.DocBang(sql);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Bạn đã nhập trùng SDT khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSDT.Text = "";
                txtSDT.Focus();
                return;
            }
            sql = "UPDATE tblKH SET TenKH = N'" + txtTenKH.Text + "'," +
                "DiaChi = N'" + txtDiachi.Text + "'," +
                "NgaySinh = N'" + dtpNgaySinh.Value.ToString("MM/dd/yyyy") + "'," +
                "SDT = N'" + txtSDT.Text + "' WHERE " +
                "MaKH= N'" + txtMaKH.Text + "'";
            ThucThiSQL.CapNhatDuLieu(sql);
            HienThi_Luoi();
            Reset();
            Disable();
            SemiReset();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtTenKH.ReadOnly = true;
            string sql;
            if (dgvKH.Rows.Count == 0)
            {
                MessageBox.Show("KHÔNG CÓ DỮ LIỆU");
                return;
            }
            string ma = dgvKH.CurrentRow.Cells["MaKH"].Value.ToString();

            if (MessageBox.Show("Bạn có muốn xóa không? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE FROM tblKH WHERE MaKH =N'" + ma + "' ";
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

        private void dgvKH_Click(object sender, EventArgs e)
        {
            Enable();
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            txtMaKH.Text = dgvKH.CurrentRow.Cells["MaKH"].Value.ToString();
            txtTenKH.Text = dgvKH.CurrentRow.Cells["TenKH"].Value.ToString();
            txtDiachi.Text = dgvKH.CurrentRow.Cells["DiaChi"].Value.ToString();
            dtpNgaySinh.Text = dgvKH.CurrentRow.Cells["NgaySinh"].Value.ToString();
            txtSDT.Text = dgvKH.CurrentRow.Cells["SDT"].Value.ToString();
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
                string sql = "EXEC proc_TimkiemKH N'{0}'";
                sql = string.Format(sql, txtTentim.Text);
                DataTable dt = ThucThiSQL.DocBang(sql);
                dgvKH.DataSource = dt;
                dgvKH.Columns[0].HeaderText = "Mã KH";
                dgvKH.Columns[0].Width = 108;
                dgvKH.Columns[1].HeaderText = "Tên KH";
                dgvKH.Columns[1].Width = 150;
                dgvKH.Columns[2].HeaderText = "Địa chỉ";
                dgvKH.Columns[2].Width = 200;
                dgvKH.Columns[3].HeaderText = "Ngày sinh";
                dgvKH.Columns[3].Width = 100;
                dgvKH.Columns[4].HeaderText = "SĐT";
                dgvKH.Columns[4].Width = 150;
                dgvKH.AllowUserToAddRows = false;
                dgvKH.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            if (rdoTheoSDT.Checked == true)
            {
                string sql = "EXEC proc_TimkiemKHTheoDT N'{0}'";
                sql = string.Format(sql, txtTentim.Text);
                DataTable dt = ThucThiSQL.DocBang(sql);
                dgvKH.DataSource = dt;
                dgvKH.Columns[0].HeaderText = "Mã KH";
                dgvKH.Columns[0].Width = 108;
                dgvKH.Columns[1].HeaderText = "Tên KH";
                dgvKH.Columns[1].Width = 150;
                dgvKH.Columns[2].HeaderText = "Địa chỉ";
                dgvKH.Columns[2].Width = 200;
                dgvKH.Columns[3].HeaderText = "Ngày sinh";
                dgvKH.Columns[3].Width = 100;
                dgvKH.Columns[4].HeaderText = "SĐT";
                dgvKH.Columns[4].Width = 150;
                dgvKH.AllowUserToAddRows = false;
                dgvKH.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            txtTentim.Text = "";
            rdoTheoSDT.Checked = false;
            rdoTheoTen.Checked = false;
        }

        private void rdoTheoTen_CheckedChanged(object sender, EventArgs e)
        {
            txtTentim.Text = "";
        }
    }
}
