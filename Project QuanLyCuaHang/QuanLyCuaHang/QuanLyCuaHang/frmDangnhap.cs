using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHang.FormQuanLy;
namespace QuanLyCuaHang
{
    public partial class frmDangnhap : Form
    {
        public frmDangnhap()
        {
            InitializeComponent();
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTaikhoan.Text.Trim() == "")
                {
                    MessageBox.Show("Nhập tên đăng nhập!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTaikhoan.Focus();
                    return;
                }
                if (txtMatkhau.Text.Trim() == "")
                {
                    MessageBox.Show("Nhập mật khẩu!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMatkhau.Focus();
                    return;
                }
                DataTable dt = ThucThiSQL.DocBang("SELECT TaiKhoan,Pass FROM tblNhanVien WHERE TaiKhoan=N'" + txtTaikhoan.Text + "'");
                if (dt.Rows.Count > 0 && txtTaikhoan.Text == dt.Rows[0][0].ToString() && txtMatkhau.Text == dt.Rows[0][1].ToString())
                {
                    MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMatkhau.Text = "";
                    txtMatkhau.Focus();
                    return;
                }
                frmMain f = new frmMain();
                f.StartPosition = FormStartPosition.CenterScreen;
                f.Show();
            }
            catch(Exception)
            {
                throw;
            }
        }

        private void frmDangnhap_Load(object sender, EventArgs e)
        {
            this.Hide();
            frmMain f = new frmMain();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }
    }
}
