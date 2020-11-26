﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace QuanLyCuaHang.Forms
{
    public partial class frmNhapHang : Form
    {
        public frmNhapHang()
        {
            InitializeComponent();
        }
        
        public void Hienthi_luoi()
        {
            string sql = "SELECT MaSP,SoLuong,DonGia,KhuyenMai,ThanhTien FROM tblChitietHDNhap WHERE MaHDNhap=N'" + txtMaHD.Text + "' ";

            DataTable dt = ThucThiSQL.DocBang(sql);
            dgvCT.DataSource = dt;
            dgvCT.Columns[0].HeaderText = "Mã Hàng";
            dgvCT.Columns[1].HeaderText = "Số Lượng";
            dgvCT.Columns[2].HeaderText = "Giá Nhập";
            dgvCT.Columns[3].HeaderText = "Giảm Giá";
            dgvCT.Columns[4].HeaderText = "Thành Tiền";
            dgvCT.Columns[4].Width = 447;
            dgvCT.Columns[4].DefaultCellStyle.Format = "c";
            dgvCT.AllowUserToAddRows = false;
            dgvCT.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void ResetValues()
        {
            txtMaHD.Text = "";
            dtpNgayNhap.Text = DateTime.Now.ToShortDateString();
            cboMaNV.Text = "";
            cboMaNCC.Text = "";
            txtTongTien.Text = "0";
            lblBangchu.Text = "Bằng chữ: ";
            cboMahang.Text = "";
            txtSoluong.Text = "";
            txtDonGia.Text = "";
            txtThanhtien.Text = "0";
        }

        public void resetValueHang()
        {
            cboMahang.SelectedIndex = -1;
            txtTenHang.Text = "";
            txtSoluong.Text = "";
            txtDonGia.Text = "";
            txtGiamGia.Text = "";
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

        private void frmNhapHang_Load(object sender, EventArgs e)
        {
            btnSuaSP.Enabled = false;
            txtGHT.ReadOnly = true;
            txtTon.ReadOnly = true;
            btnSua.Enabled = false;
            grbThongtin.Enabled = false;
            grbChitiet.Enabled = false;
            btnLuuHD.Enabled = false;
            btnHuyHD.Enabled = false;
            btnInHD.Enabled = false;
            btnThemSP.Enabled = false;
            btnXoaSP.Enabled = false;
            txtTongTien.Text = "0";
            txtThanhtien.ReadOnly = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            dgvCT.DataSource = null;
            dgvCT.Rows.Clear();
            ResetValues();
            resetValueHang();
            grbChitiet.Enabled = false;
            btnThemHD.Enabled = false;
            grbThongtin.Enabled = true;
            btnLuuHD.Enabled = true;
            btnHuyHD.Enabled = false;
            btnInHD.Enabled = false;
            txtMaHD.ReadOnly = true;
            txtTenNV.ReadOnly = true;
            txtTenNCC.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            txtDienthoai.ReadOnly = true;
            txtTenHang.ReadOnly = true;
            txtTongTien.ReadOnly = true;
            txtMaHD.Text = ThucThiSQL.CreateKey("HDN");
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

        private void btnLuuHD_Click(object sender, EventArgs e)
        {
            if (cboMaNV.Text == "")
            {
                MessageBox.Show("Bạn phải chọn Mã NV!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cboMaNCC.Text == "")
            {
                MessageBox.Show("Bạn phải chọn Nhà cung cấp!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string sql;
            sql = "INSERT INTO tblHDNhap (MaHDNhap,MaNV,MaNCC,NgayNhap,TongTien) " +
                "VALUES (N'" + txtMaHD.Text + "',N'" + cboMaNV.Text + "',N'" + cboMaNCC.Text + "',N'" + dtpNgayNhap.Value.ToString("yyyy/MM/dd") + "'," + txtTongTien.Text + ")";
            ThucThiSQL.CapNhatDuLieu(sql);
            btnLuuHD.Enabled = false;
            btnHuyHD.Enabled = true;
            btnThemHD.Enabled = true;
            btnThemSP.Enabled = true;
            grbThongtin.Enabled = true;
            grbChitiet.Enabled = true;
            btnSua.Enabled = true;
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

        private void btnHangban_Click(object sender, EventArgs e)
        {
            DataTable dt = ThucThiSQL.DocBang("SELECT GioiHanTon,SoLuongTon FROM tblSP WHERE MaSP=N'" + cboMahang.Text + "'");
            if (cboMahang.Text == "")
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
            if (Convert.ToInt64(dt.Rows[0][0].ToString()) < (Convert.ToInt64(txtSoluong.Text)+ Convert.ToInt64(dt.Rows[0][1].ToString())))
            {
                MessageBox.Show("Số lượng nhập vượt quá giới hạn, Vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoluong.Text = "";
                txtSoluong.Focus();
                return;
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
            txtTongTien.Text = string.Format("{0:0,0 VNĐ}", double.Parse(tongmoi.ToString()));
            if(tongmoi==(int) tongmoi)
            lblBangchu.Text = "Bằng chữ: " + ThucThiSQL.ChuyenSoSangChu(tongmoi.ToString());
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
            //the end
            resetValueHang();
            btnHuyHD.Enabled = true;
            btnInHD.Enabled = true;
        }

        private void btnHuyHD_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Lấy thông tin các mặt hàng sẽ bị xóa
                string sql = "SELECT MaSP, SoLuong, DonGia FROM tblChitietHDNhap WHERE MaHDNhap = N'" + txtMaHD.Text + "'";
                DataTable tbl = ThucThiSQL.DocBang(sql);
                //xóa chi tiết hóa đơn
                sql = "DELETE tblChiTietHDNhap WHERE MaHDNhap=N'" + txtMaHD.Text + "'";
                ThucThiSQL.CapNhatDuLieu(sql);
                //xóa hóa đơn
                sql = "DELETE tblHDNhap WHERE MaHDNhap=N'" + txtMaHD.Text + "'";
                ThucThiSQL.CapNhatDuLieu(sql);
                ResetValues();
                Hienthi_luoi();
                // cập nhật lại số lượng,đơn giá nhập, đơn giá bán
                for (int i = 0; i < tbl.Rows.Count; i++)
                    DelUpdateHang(tbl.Rows[i][0].ToString(), Convert.ToDouble(tbl.Rows[i][1]), Convert.ToDouble(tbl.Rows[i][2]));
                btnThemHD.Enabled = true;
                btnHuyHD.Enabled = false;
                btnInHD.Enabled = false;
                btnThemSP.Enabled = false;
                btnXoaSP.Enabled = false;
                grbThongtin.Enabled = false;
                grbChitiet.Enabled = false;
                dgvCT.DataSource = null;
                dgvCT.Rows.Clear();
            }
        }

        private void dgvCT_Click(object sender, EventArgs e)
        {            
            if (dgvCT.Rows.Count==0)
            {
                return;
            }
            btnXoaSP.Enabled = true;
            btnThemSP.Enabled = false;
            btnSuaSP.Enabled = true;
            cboMahang.Text = dgvCT.CurrentRow.Cells["MaSP"].Value.ToString();
            txtSoluong.Text = dgvCT.CurrentRow.Cells["SoLuong"].Value.ToString();
            txtDonGia.Text = dgvCT.CurrentRow.Cells["DonGia"].Value.ToString();
            txtGiamGia.Text = dgvCT.CurrentRow.Cells["KhuyenMai"].Value.ToString();
            txtThanhtien.Text = dgvCT.CurrentRow.Cells["ThanhTien"].Value.ToString();
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM tblChitietHDNhap WHERE MaHDNhap = N'" + txtMaHD.Text + "'";
            if (ThucThiSQL.DocBang(sql).Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                string mahangxoa = dgvCT.CurrentRow.Cells["MaSP"].Value.ToString();
                double slxoa = Convert.ToDouble(dgvCT.CurrentRow.Cells["SoLuong"].Value.ToString());
                double gianhapxoa = Convert.ToDouble(dgvCT.CurrentRow.Cells["DonGia"].Value.ToString());
                double thanhtienxoa = Convert.ToDouble(dgvCT.CurrentRow.Cells["ThanhTien"].Value.ToString());
                sql = "DELETE tblChitietHDNhap WHERE MaHDNhap=N'" + txtMaHD.Text + "' AND MaSP=N'" + mahangxoa + "'";
                ThucThiSQL.CapNhatDuLieu(sql);
                Hienthi_luoi();
                DelUpdateHang(mahangxoa, slxoa, gianhapxoa);
                DelUpdateTongTien(txtMaHD.Text, thanhtienxoa);
                resetValueHang();
            }
            btnThemSP.Enabled = true;
            if (dgvCT.Rows.Count == 0)
            {
                btnInHD.Enabled = false;
            }
            else btnInHD.Enabled = true;
        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            Forms.frmNCC f = new Forms.frmNCC();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            Forms.frmNV f = new Forms.frmNV();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook;
            COMExcel.Worksheet exSheet;
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinHang;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 21;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "T-MART";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "809 La Thành - Ba Đình - Hà Nội";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (096) 626-6336";
            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Name = "Times new roman";
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN NHẬP";
            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "SELECT a.MaHDNhap, a.NgayNhap, a.TongTien, b.TenNCC, b.Diachi, b.SDT, c.TenNV " +
            "FROM tblHDNhap AS a, tblNCC AS b, tblNV AS c WHERE a.MaHDNhap = N'" + txtMaHD.Text +
            "' AND a.MaNCC = b.MaNCC AND a.MaNV = c.MaNV";
            tblThongtinHD = ThucThiSQL.DocBang(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:C9"].Font.Name = "Times new roman";
            exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Nhà cung cấp:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = "Điện thoại:";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = "'" + tblThongtinHD.Rows[0][5].ToString();
            //Lấy thông tin các mặt hàng
            sql = "SELECT b.TenSP, a.Soluong, a.DonGia, a.KhuyenMai, a.ThanhTien " +
            "FROM dbo.tblChiTietHDNhap AS a , dbo.tblSP AS b WHERE a.MaHDNhap = N'" + txtMaHD.Text +
            "' AND a.MaSP = b.MaSP";
            tblThongtinHang = ThucThiSQL.DocBang(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên hàng";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Đơn giá";
            exRange.Range["E11:E11"].Value = "Giảm giá";
            exRange.Range["F11:F11"].Value = "Thành tiền";
            for (hang = 0; hang <= tblThongtinHang.Rows.Count - 1; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot <= tblThongtinHang.Columns.Count - 1; cot++)
                    //Điền thông tin hàng từ cột thứ 2, dòng 12
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = string.Format("{0:0,0 VNĐ}", double.Parse(tblThongtinHD.Rows[0][2].ToString()));
            exRange = exSheet.Cells[1][hang + 15]; //Ô A1
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + ThucThiSQL.ChuyenSoSangChu(tblThongtinHD.Rows[0][2].ToString());
            exRange = exSheet.Cells[4][hang + 17]; //Ô A1
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên nhập hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][6];
            exSheet.Name = "Hóa Đơn Nhập";
            exApp.Visible = true;
        }

        private void cboMaNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboMaNCC_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboMahang_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
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
        }

        private void frmNhapHang_Activated(object sender, EventArgs e)
        {
        }
        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            DataTable dt = ThucThiSQL.DocBang("SELECT GioiHanTon,SoLuongTon FROM tblSP WHERE MaSP=N'" + cboMahang.Text + "'");
            if ((Convert.ToInt64(txtSoluong.Text) - Convert.ToInt64(dgvCT.CurrentRow.Cells["SoLuong"].Value.ToString()) + (Convert.ToInt64(dt.Rows[0][1].ToString()))) > Convert.ToInt64(dt.Rows[0][0].ToString()))
            {
                MessageBox.Show("Số lượng nhập vượt quá giới hạn, Vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoluong.Text = "";
                txtSoluong.Focus();
                return;
            }
            string mahangxoa = cboMahang.Text;
            double slxoa = double.Parse(dgvCT.CurrentRow.Cells["SoLuong"].Value.ToString());
            double gianhapxoa = double.Parse(dgvCT.CurrentRow.Cells["DonGia"].Value.ToString());
            double thanhtienxoa = double.Parse(dgvCT.CurrentRow.Cells["ThanhTien"].Value.ToString());
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
    }
}
