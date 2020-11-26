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
            dgvKH.Columns[3].Width = 150;
            dgvKH.Columns[4].HeaderText = "SĐT";
            dgvKH.Columns[4].Width = 100;
            dgvKH.AllowUserToAddRows = false;
            dgvKH.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        public void SemiReset()
        {
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            txtTenKH.Text = "";
            txtDiachi.Text = "";
            dtpNgaySinh.Text = DateTime.Now.ToString();
            txtSDT.Text = "";
        }

        public void Reset()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtDiachi.Text = "";
            dtpNgaySinh.Text = DateTime.Now.ToString();
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
            txtMaKH.Text = ThucThiSQL.AutoGenerate("KH", "tblKH");
            Enable();
            SemiReset();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaKH.Text == "")
            {
                MessageBox.Show("Bạn phải nhập Mã KH");
                return;
            }
            if (txtTenKH.Text == "")
            {
                MessageBox.Show("Bạn phải nhập Tên KH");
                txtTenKH.Focus();
                return;
            }
            sql = "SELECT * FROM tblKH WHERE MaKH ='" + txtMaKH.Text + "'";
            DataTable dt = ThucThiSQL.DocBang(sql);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Bạn đã nhập trùng MÃ KH");
                txtMaKH.Text = "";
                txtMaKH.Focus();
                return;
            }
            sql = "INSERT INTO tblKH(MaKH,TenKH,GioiT,DiaChi,NgaySinh,SDT) " +
                "VALUES (N'" + txtMaKH.Text + "',N'" + txtTenKH.Text + "',N'" + txtDiachi.Text + "',N'" + dtpNgaySinh.Value.ToShortDateString()+ "',N'" + txtSDT.Text + "')";
            ThucThiSQL.CapNhapDuLieu(sql);
            HienThi_Luoi();
            Reset();
            btnLuu.Enabled = false;
            txtTenKH.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtTenKH.Text == "")
            {
                MessageBox.Show("Bạn phải nhập TÊN KH");
                txtTenKH.Focus();
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
            sql = "UPDATE tblKH SET TenKH = N'" + txtTenKH.Text + "'," +
                "DiaChi = N'" + txtDiachi.Text + "'," +
                "NgaySinh = N'" + dtpNgaySinh.Value.ToString("yyyy/MM/dd") + "'," +
                "SDT = N'" + txtSDT.Text + "' WHERE " +
                "MaKH= N'" + txtMaKH.Text + "'";
            ThucThiSQL.CapNhapDuLieu(sql);
            HienThi_Luoi();
            Reset();
            Disable();
            SemiReset();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
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

        private void dgvKH_Click(object sender, EventArgs e)
        {
            Enable();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            txtMaKH.Text = dgvKH.CurrentRow.Cells["MaKH"].Value.ToString();
            txtTenKH.Text = dgvKH.CurrentRow.Cells["TenKH"].Value.ToString();
            txtDiachi.Text = dgvKH.CurrentRow.Cells["DiaChi"].Value.ToString();
            dtpNgaySinh.Text = dgvKH.CurrentRow.Cells["NgaySinh"].Value.ToString();
            txtSDT.Text = dgvKH.CurrentRow.Cells["SDT"].Value.ToString();
        }
    }
}
