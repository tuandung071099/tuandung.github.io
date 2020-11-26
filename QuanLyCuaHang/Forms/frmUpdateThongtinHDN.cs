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
    public partial class frmUpdateThongtinHDN : Form
    {
        public frmUpdateThongtinHDN()
        {
            InitializeComponent();
        }

        public void Hienthi_luoi()
        {
            string sql = "SELECT MaSP,SoLuong,DonGia,KhuyenMai,ThanhTien FROM tblChitietHDNhap WHERE MaHDNhap=N'" + txtMaHD.Text + "' ";
            DataTable dt = ThucThiSQL.DocBang(sql);
            dgvUpdateCT.DataSource = dt;
            dgvUpdateCT.DataSource = dt;
            dgvUpdateCT.Columns[0].HeaderText = "Mã Hàng";
            dgvUpdateCT.Columns[1].HeaderText = "Số Lượng";
            dgvUpdateCT.Columns[2].HeaderText = "Giá Nhập";
            dgvUpdateCT.Columns[3].HeaderText = "Giảm Giá";
            dgvUpdateCT.Columns[4].HeaderText = "Thành Tiền";
            dgvUpdateCT.Columns[4].Width = 450;
            dgvUpdateCT.Columns[4].DefaultCellStyle.Format = "c";
            dgvUpdateCT.AllowUserToAddRows = false;
            dgvUpdateCT.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        public void DelUpdateHang(string mahangxoa, double slxoa, double gianhapxoa)
        {
            double sl = Convert.ToDouble(ThucThiSQL.DocBang("SELECT SoLuongTon FROM tblSP WHERE MaSP=N'" + mahangxoa + "'").Rows[0][0].ToString());
            double slmoi = sl - slxoa;
            ThucThiSQL.CapNhatDuLieu("UPDATE tblSP SET SoLuongTon =" + slmoi + " WHERE MaSP=N'" + mahangxoa + "'");

            double dgn = Convert.ToDouble(ThucThiSQL.DocBang("SELECT DonGiaNhap FROM tblSP WHERE MaSP=N'" + mahangxoa + "'").Rows[0][0].ToString());
            double dgnmoi = (sl * dgn - slxoa * gianhapxoa) / slmoi;
            if (slmoi == 0)
                dgnmoi = 0;
            ThucThiSQL.CapNhatDuLieu("UPDATE tblSP SET DonGiaNhap =" + dgnmoi + " WHERE MaSP=N'" + mahangxoa + "'");

            ThucThiSQL.CapNhatDuLieu("UPDATE tblSP SET DonGiaBan =" + (dgnmoi * 1.2) + " WHERE MaSP=N'" + mahangxoa + "'");
        }

        private void DelUpdateTongTien(string mahoadonxoa, double thanhtienxoa)
        {
            double tong = Convert.ToDouble(ThucThiSQL.DocBang("SELECT TongTien FROM tblHDNhap WHERE MaHDNhap=N'" + mahoadonxoa + "'").Rows[0][0].ToString());
            double tongmoi = tong - thanhtienxoa;
            ThucThiSQL.CapNhatDuLieu("UPDATE tblHDNhap SET TongTien=" + tongmoi + " WHERE MaHDNhap =N'" + mahoadonxoa + "'");
            txtTongTien.Text = tongmoi.ToString();
            lblBangchu.Text = "Bằng chữ: " + ThucThiSQL.ChuyenSoSangChu(tongmoi.ToString());
        }

        public void resetValueHang()
        {
            cboMahang.Text = "";
            txtTenHang.Text = "";
            txtSoluong.Text = "";
            txtDonGia.Text = "";
            txtGiamGia.Text = "";
        }

        private void tpThongTin_Enter(object sender, EventArgs e)
        {
            txtMaHD.ReadOnly = true;
            txtTenNV.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            txtDienthoai.ReadOnly = true;
            txtTenNCC.ReadOnly = true;
        }

        private void tpChiTiet_Enter(object sender, EventArgs e)
        {
            txtTenHang.ReadOnly = true;
            txtThanhtien.ReadOnly = true;
            txtTon.ReadOnly = true;
            txtGHT.ReadOnly = true;
            Hienthi_luoi();
        }

        private void cboMaNV_TextChanged(object sender, EventArgs e)
        {
            if (cboMaNV.Text == "")
            {
                txtTenNV.Text = "";
            }
            DataTable dt = ThucThiSQL.DocBang("SELECT TenNV FROM tblNV WHERE MaNV=N'" + cboMaNV.Text + "'");
            if (dt.Rows.Count > 0)
            {
                txtTenNV.Text = dt.Rows[0][0].ToString();
            }
        }

        private void cboMaNCC_TextChanged(object sender, EventArgs e)
        {
            if (cboMaNCC.Text == "")
            {
                txtTenNCC.Text = "";
                txtDiaChi.Text = "";
                txtDienthoai.Text = "";
            }
            DataTable dt = ThucThiSQL.DocBang("SELECT TenNCC,DiaChi,SDT FROM tblNCC WHERE MaNCC=N'" + cboMaNCC.Text + "'");
            if (dt.Rows.Count > 0)
            {
                txtTenNCC.Text = dt.Rows[0][0].ToString();
                txtDiaChi.Text = dt.Rows[0][1].ToString();
                txtDienthoai.Text = dt.Rows[0][2].ToString();
            }
        }

        private void cboMahang_TextChanged(object sender, EventArgs e)
        {
            txtDonGia.Text = "";
            txtSoluong.Text = "";
            txtGiamGia.Text = "";
            if (cboMahang.Text == "")
            {
                txtTenHang.Text = "";
                txtTon.Text = "";
                txtGHT.Text = "";
            }
            DataTable dt = ThucThiSQL.DocBang("SELECT TenSP,SoLuongTon,GioiHanTon FROM tblSP WHERE MaSP=N'" + cboMahang.Text + "'");
            if (dt.Rows.Count > 0)
            {
                txtTenHang.Text = dt.Rows[0][0].ToString();
                txtTon.Text = dt.Rows[0][1].ToString();
                txtGHT.Text = dt.Rows[0][2].ToString();
            }
        }

        private void cboMaNV_DropDown(object sender, EventArgs e)
        {
            cboMaNV.DataSource = ThucThiSQL.DocBang("SELECT MaNV FROM tblNV");
            cboMaNV.ValueMember = "MaNV";
            cboMaNV.SelectedIndex = -1;
        }

        private void cboMaNCC_DropDown(object sender, EventArgs e)
        {
            cboMaNCC.DataSource = ThucThiSQL.DocBang("SELECT MaNCC FROM tblNCC");
            cboMaNCC.ValueMember = "MaNCC";
            cboMaNCC.SelectedIndex = -1;
        }

        private void cboMahang_DropDown(object sender, EventArgs e)
        {
            cboMahang.DataSource = ThucThiSQL.DocBang("SELECT MaSP FROM tblSP");
            cboMahang.ValueMember = "MaSP";
            cboMahang.SelectedIndex = -1;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (cboMaNV.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải chọn Mã NV", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaNV.Focus();
                return;
            }
            if (cboMaNCC.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải chọn Mã NCC", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaNCC.Focus();
                return;
            }
            string sql;
            DataTable dt = new DataTable();
            sql = "UPDATE tblHDNhap SET NgayNhap =N'" + dtpNgayNhap.Value.ToString("MM/dd/yyyy") + "'" +
                ", MaNV=N'" + cboMaNV.Text + "' , MaNCC=N'" + cboMaNCC.Text + "'" +
                "WHERE MaHDNhap=N'" + txtMaHD.Text + "' ";
            ThucThiSQL.CapNhatDuLieu(sql);
            MessageBox.Show("Sửa thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (cboMahang.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải chọn Mã sản phẩm!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMahang.Focus();
                return;
            }
            if (txtSoluong.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập số lượng!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoluong.Focus();
                return;
            }
            if (txtDonGia.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập đơn giá!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDonGia.Focus();
                return;
            }
            if (txtGiamGia.Text.Trim() == "")
            {
                txtGiamGia.Text = "0";
            }
            if (ThucThiSQL.DocBang("SELECT MaSP FROM tblChitietHDNhap WHERE MaHDNhap=N'" + txtMaHD.Text + "' AND MaSP=N'" + cboMahang.Text + "'").Rows.Count > 0)
            {
                MessageBox.Show("Mã SP đã tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                resetValueHang();
                cboMahang.Focus();
                return;
            }
            string sql;
            //cập nhật dữ liệu cho tblChitietHDN
            sql = "INSERT INTO tblChitietHDNhap (MaHDNhap,MaSP,SoLuong,DonGia,KhuyenMai,ThanhTien) " +
                "VALUES (N'" + txtMaHD.Text + "',N'" + cboMahang.Text + "'," + txtSoluong.Text + "," + txtDonGia.Text + "," + txtGiamGia.Text + "," + txtThanhtien.Text + ")";
            ThucThiSQL.CapNhatDuLieu(sql);
            Hienthi_luoi();
            //cập nhật tổng tiền mới cho tblHDNhap
            double tong = Convert.ToDouble(txtThanhtien.Text);
            double tongmoi = tong + Convert.ToDouble(ThucThiSQL.DocBang("SELECT TongTien FROM tblHDNhap WHERE MaHDNhap=N'" + txtMaHD.Text + "'").Rows[0][0].ToString());
            ThucThiSQL.CapNhatDuLieu("UPDATE tblHDNhap SET TongTien=" + tongmoi + " WHERE MaHDNhap =N'" + txtMaHD.Text + "'");
            //hiển thị tổng tiền mới và dạng chữ của nó
            txtTongTien.Text = string.Format("{0:0,0.000 VNĐ}", double.Parse(tongmoi.ToString()));

            if (tongmoi == (int)tongmoi)
                lblBangchu.Text = "Bằng chữ: " + ThucThiSQL.ChuyenSoSangChu(tongmoi.ToString());
            //cập nhật số lượng mới của Mahang cho bảng hàng
            double sl, slmoi;
            sl = Convert.ToDouble(txtSoluong.Text);
            slmoi = sl + Convert.ToDouble(ThucThiSQL.DocBang("SELECT SoLuongTon FROM tblSP WHERE MaSP=N'" + cboMahang.Text + "'").Rows[0][0].ToString());
            ThucThiSQL.CapNhatDuLieu("UPDATE tblSP SET SoLuongTon =" + slmoi + " WHERE MaSP=N'" + cboMahang.Text + "'");
            //cập nhật đơn giá nhập mới của Mahang cho bảng hàng
            double dgnmoi, dgbmoi;
            DataTable dt = ThucThiSQL.DocBang("SELECT SoLuongTon,DonGiaNhap FROM tblSP WHERE MaSP=N'" + cboMahang.Text + "'");
            dgnmoi = (Convert.ToDouble(dt.Rows[0][0].ToString()) * Convert.ToDouble(dt.Rows[0][1].ToString())
                + Convert.ToDouble(txtSoluong.Text) * Convert.ToDouble(txtDonGia.Text)) /
                (Convert.ToDouble(txtSoluong.Text) + Convert.ToDouble(dt.Rows[0][0].ToString()));
            ThucThiSQL.CapNhatDuLieu("UPDATE tblSP SET DonGiaNhap=" + dgnmoi + " WHERE MaSP=N'" + cboMahang.Text + "'");
            //cập nhật đơn giá bán mới của Mahang cho bảng hàng
            dgbmoi = dgnmoi * 1.2;
            ThucThiSQL.CapNhatDuLieu("UPDATE tblSP SET DonGiaBan=" + dgbmoi + " WHERE MaSP=N'" + cboMahang.Text + "'");
            //the end
            resetValueHang();
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM tblChitietHDNhap WHERE MaHDNhap = N'" + txtMaHD.Text + "'";
            if (ThucThiSQL.DocBang(sql).Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                string mahangxoa = dgvUpdateCT.CurrentRow.Cells["MaSP"].Value.ToString();
                double slxoa = Convert.ToDouble(dgvUpdateCT.CurrentRow.Cells["SoLuong"].Value.ToString());
                double gianhapxoa = Convert.ToDouble(dgvUpdateCT.CurrentRow.Cells["DonGia"].Value.ToString());
                double thanhtienxoa = Convert.ToDouble(dgvUpdateCT.CurrentRow.Cells["ThanhTien"].Value.ToString());
                sql = "DELETE tblChitietHDNhap WHERE MaHDNhap=N'" + txtMaHD.Text + "' AND MaSP=N'" + mahangxoa + "'";
                ThucThiSQL.CapNhatDuLieu(sql);
                Hienthi_luoi();
                DelUpdateHang(mahangxoa, slxoa, gianhapxoa);
                DelUpdateTongTien(txtMaHD.Text, thanhtienxoa);
            }
        }

        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {
            bool CheckValid2 = int.TryParse(txtSoluong.Text, out int Num);
            if (txtSoluong.Text.Trim() == "")
            {
                CheckValid2 = true;
            }
            if (CheckValid2 == false)
            {
                int index = txtSoluong.SelectionStart;
                txtSoluong.Text = txtSoluong.Text.Remove(txtSoluong.SelectionStart - 1, 1);
                txtSoluong.SelectionStart = index;
            }
            double sl, dg, gg, tt;
            if (txtSoluong.Text.Trim() == "")
            {
                sl = 0;
            }
            else
                sl = Convert.ToDouble(txtSoluong.Text);
            if (txtDonGia.Text.Trim() == "")
            {
                dg = 0;
            }
            else
                dg = Convert.ToDouble(txtDonGia.Text);
            if (txtGiamGia.Text.Trim() == "")
            {
                gg = 0;
            }
            else
                gg = Convert.ToDouble(txtGiamGia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhtien.Text = tt.ToString();
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            bool CheckValid2 = int.TryParse(txtDonGia.Text, out int Num);
            if (txtDonGia.Text.Trim() == "")
            {
                CheckValid2 = true;
            }
            if (CheckValid2 == false)
            {
                int index = txtDonGia.SelectionStart;
                txtDonGia.Text = txtDonGia.Text.Remove(txtDonGia.SelectionStart - 1, 1);
                txtDonGia.SelectionStart = index;
            }
            double sl, dg, gg, tt;
            if (txtSoluong.Text.Trim() == "")
            {
                sl = 0;
            }
            else
                sl = Convert.ToDouble(txtSoluong.Text);
            if (txtDonGia.Text.Trim() == "")
            {
                dg = 0;
            }
            else
                dg = Convert.ToDouble(txtDonGia.Text);
            if (txtGiamGia.Text.Trim() == "")
            {
                gg = 0;
            }
            else
                gg = Convert.ToDouble(txtGiamGia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhtien.Text = tt.ToString();
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            bool CheckValid2 = double.TryParse(txtGiamGia.Text, out double Num);
            if (txtGiamGia.Text.Trim() == "")
            {
                CheckValid2 = true;
            }
            if (CheckValid2 == false)
            {
                int index = txtGiamGia.SelectionStart;
                txtGiamGia.Text = txtGiamGia.Text.Remove(txtGiamGia.SelectionStart - 1, 1);
                txtGiamGia.SelectionStart = index;
            }
            double sl, dg, gg, tt;
            if (txtSoluong.Text.Trim() == "")
            {
                sl = 0;
            }
            else
                sl = Convert.ToDouble(txtSoluong.Text);
            if (txtDonGia.Text.Trim() == "")
            {
                dg = 0;
            }
            else
                dg = Convert.ToDouble(txtDonGia.Text);
            if (txtGiamGia.Text.Trim() == "")
            {
                gg = 0;
            }
            else
                gg = Convert.ToDouble(txtGiamGia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhtien.Text = tt.ToString();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            DataTable dt = ThucThiSQL.DocBang("SELECT GioiHanTon,SoLuongTon FROM tblSP WHERE MaSP=N'" + cboMahang.Text + "'");
            if ((Convert.ToInt64(txtSoluong.Text) - Convert.ToInt64(dgvUpdateCT.CurrentRow.Cells["SoLuong"].Value.ToString()) + (Convert.ToInt64(dt.Rows[0][1].ToString()))) > Convert.ToInt64(dt.Rows[0][0].ToString()))
            {
                MessageBox.Show("Số lượng nhập vượt quá giới hạn, Vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoluong.Text = "";
                txtSoluong.Focus();
                return;
            }
            string mahangxoa = cboMahang.Text;
            double slxoa = double.Parse(dgvUpdateCT.CurrentRow.Cells["SoLuong"].Value.ToString());
            double gianhapxoa = double.Parse(dgvUpdateCT.CurrentRow.Cells["DonGia"].Value.ToString());
            double thanhtienxoa = double.Parse(dgvUpdateCT.CurrentRow.Cells["ThanhTien"].Value.ToString());
            DelUpdateHang(mahangxoa, slxoa, gianhapxoa);
            DelUpdateTongTien(txtMaHD.Text, thanhtienxoa);
            string sql = "DELETE tblChitietHDNhap WHERE MaHDNhap=N'" + txtMaHD.Text + "' AND MaSP=N'" + mahangxoa + "'";
            ThucThiSQL.CapNhatDuLieu(sql);

            //cập nhật dữ liệu cho tblChitietHDN
            sql = "INSERT INTO tblChitietHDNhap (MaHDNhap,MaSP,SoLuong,DonGia,KhuyenMai,ThanhTien) " +
                "VALUES (N'" + txtMaHD.Text + "',N'" + cboMahang.Text + "'," + txtSoluong.Text + "," + txtDonGia.Text + "," + txtGiamGia.Text + "," + txtThanhtien.Text + ")";
            ThucThiSQL.CapNhatDuLieu(sql);
            //cập nhật tổng tiền mới cho tblHDNhap
            double tong = Convert.ToDouble(txtThanhtien.Text);
            double tongmoi = tong + Convert.ToDouble(ThucThiSQL.DocBang("SELECT TongTien FROM tblHDNhap WHERE MaHDNhap=N'" + txtMaHD.Text + "'").Rows[0][0].ToString());
            ThucThiSQL.CapNhatDuLieu("UPDATE tblHDNhap SET TongTien=" + tongmoi + " WHERE MaHDNhap =N'" + txtMaHD.Text + "'");
            //cập nhật đơn giá nhập mới của Mahang cho bảng hàng
            double dgnmoi, dgbmoi;
            dt = ThucThiSQL.DocBang("SELECT SoLuongTon,DonGiaNhap FROM tblSP WHERE MaSP=N'" + cboMahang.Text + "'");
            dgnmoi = (Convert.ToDouble(dt.Rows[0][0].ToString()) * Convert.ToDouble(dt.Rows[0][1].ToString())
                + Convert.ToDouble(txtSoluong.Text) * Convert.ToDouble(txtDonGia.Text)) /
                (Convert.ToDouble(txtSoluong.Text) + Convert.ToDouble(dt.Rows[0][0].ToString()));
            ThucThiSQL.CapNhatDuLieu("UPDATE tblSP SET DonGiaNhap=" + dgnmoi + " WHERE MaSP=N'" + cboMahang.Text + "'");
            //cập nhật số lượng mới của Mahang cho bảng hàng
            double sl, slmoi;
            sl = Convert.ToDouble(txtSoluong.Text);
            slmoi = sl + Convert.ToDouble(ThucThiSQL.DocBang("SELECT SoLuongTon FROM tblSP WHERE MaSP=N'" + cboMahang.Text + "'").Rows[0][0].ToString());
            ThucThiSQL.CapNhatDuLieu("UPDATE tblSP SET SoLuongTon =" + slmoi + " WHERE MaSP=N'" + cboMahang.Text + "'");
            //cập nhật đơn giá bán mới của Mahang cho bảng hàng
            dgbmoi = dgnmoi * 1.2;
            ThucThiSQL.CapNhatDuLieu("UPDATE tblSP SET DonGiaBan=" + dgbmoi + " WHERE MaSP=N'" + cboMahang.Text + "'");
            Hienthi_luoi();
            //the end
            txtTongTien.Text = string.Format("{0:0,0 VNĐ}", tongmoi);
            lblBangchu.Text = "Bằng chữ: " + ThucThiSQL.ChuyenSoSangChu(tongmoi.ToString());
            resetValueHang();
            btnSua.Enabled = false;
        }

        private void cboMahang_Click(object sender, EventArgs e)
        {
            btnThemSP.Enabled = true;
            btnSuaSP.Enabled = false;
        }

        private void btnThemhang_Click(object sender, EventArgs e)
        {
            Forms.frmSP f = new Forms.frmSP();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            Forms.frmNV f = new Forms.frmNV();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            Forms.frmNCC f = new Forms.frmNCC();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void dgvUpdateCT_Click(object sender, EventArgs e)
        {
            if (dgvUpdateCT.Rows.Count == 0)
            {
                return;
            }
            btnXoaSP.Enabled = true;
            btnThemSP.Enabled = false;
            btnSuaSP.Enabled = true;
            cboMahang.Text = dgvUpdateCT.CurrentRow.Cells["MaSP"].Value.ToString();
            txtSoluong.Text = dgvUpdateCT.CurrentRow.Cells["SoLuong"].Value.ToString();
            txtDonGia.Text = dgvUpdateCT.CurrentRow.Cells["DonGia"].Value.ToString();
            txtGiamGia.Text = dgvUpdateCT.CurrentRow.Cells["KhuyenMai"].Value.ToString();
            txtThanhtien.Text = dgvUpdateCT.CurrentRow.Cells["ThanhTien"].Value.ToString();
        }
    }
}
