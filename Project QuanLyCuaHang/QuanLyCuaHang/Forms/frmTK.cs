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
    public partial class frmTK : Form
    {
        public frmTK()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM tblTK WHERE MaNV ='" + txtMaNV.Text + "'";
            DataTable dt = ThucThiSQL.DocBang(sql);
            if (txtMaNV.Text.Trim()=="")
            {
                MessageBox.Show("Bạn chưa nhập mã NV", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNV.Focus();
                return;
            }
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Nhân viên không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaNV.Text = "";
                txtMaNV.Focus();
                return;
            }
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Nhân viên đã có tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaNV.Text = "";
                txtMaNV.Focus();
                return;
            }
            sql = "SELECT * FROM tblTK WHERE ID ='" + txtID.Text + "'";
            dt = ThucThiSQL.DocBang(sql);
            if (txtID.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập ID", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtID.Focus();
                return;
            }
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Tên tài khoản đã có người đặt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtID.Text = "";
                txtID.Focus();
                return;
            }
            sql = "INSERT INTO tblTK(MaNV,ID,Pass) " +
                "VALUES (N'" + txtMaNV.Text + "',N'" + txtID.Text + "',N'" + txtPass.Text + "')";
            ThucThiSQL.CapNhatDuLieu(sql);
            MessageBox.Show("Đăng kí thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
