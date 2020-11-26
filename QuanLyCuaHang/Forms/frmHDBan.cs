using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace QuanLyCuaHang.Forms
{
    public partial class frmHDBan : Form
    {
        public frmHDBan()
        {
            InitializeComponent();
        }

        public void Hienthi_luoi()
        {
            string sql = "EXEC proc_BCBanTheoHD N'{0}',N'{1}'";
            sql = string.Format(sql, dtpTuNgay.Value.ToString("yyyy/MM/dd"), dtpDenNgay.Value.ToString("yyyy/MM/dd"));
            DataTable dt = ThucThiSQL.DocBang(sql);
            dgvDanhsach.DataSource = dt;
            dgvDanhsach.Columns[0].HeaderText = "Ngày Bán";
            dgvDanhsach.Columns[1].HeaderText = "Hóa Đơn Bán";
            dgvDanhsach.Columns[1].Width = 300;
            dgvDanhsach.Columns[2].HeaderText = "Mã Nhân Viên";
            dgvDanhsach.Columns[3].HeaderText = "Mã KH";
            dgvDanhsach.Columns[4].HeaderText = "Tổng Tiền";
            dgvDanhsach.Columns[4].Width = 190;
            dgvDanhsach.AllowUserToAddRows = false;
            dgvDanhsach.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        public void DelUpdateHang(string mahangxoa, double slxoa)
        {
            double sl = Convert.ToDouble(ThucThiSQL.DocBang("SELECT SoLuongTon FROM tblSP WHERE MaSP=N'" + mahangxoa + "'").Rows[0][0].ToString());
            double slmoi = sl + slxoa;
            ThucThiSQL.CapNhatDuLieu("UPDATE tblSP SET SoLuongTon =" + slmoi + " WHERE MaSP=N'" + mahangxoa + "'");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Forms.frmUpdateThongtinHDB f = new Forms.frmUpdateThongtinHDB();
            f.txtMaHD.Text = dgvDanhsach.CurrentRow.Cells["MaHDBan"].Value.ToString();
            f.dtpNgayNhap.Text = dgvDanhsach.CurrentRow.Cells["NgayBan"].Value.ToString();
            f.cboMaNV.Text = dgvDanhsach.CurrentRow.Cells["MaNV"].Value.ToString();
            f.cboMaKH.Text = dgvDanhsach.CurrentRow.Cells["MaKH"].Value.ToString();
            f.txtTongTien.Text = dgvDanhsach.CurrentRow.Cells["TongTien"].Value.ToString();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            string sql = "EXEC proc_BCBanTheoHD N'{0}',N'{1}'";
            sql = string.Format(sql, dtpTuNgay.Value.ToString("yyyy/MM/dd"), dtpDenNgay.Value.ToString("yyyy/MM/dd"));
            DataTable dt = ThucThiSQL.DocBang(sql);
            dgvDanhsach.DataSource = dt;
            dgvDanhsach.Columns[0].HeaderText = "Ngày Bán";
            dgvDanhsach.Columns[1].HeaderText = "Hóa Đơn Bán";
            dgvDanhsach.Columns[1].Width = 300;
            dgvDanhsach.Columns[2].HeaderText = "Mã Nhân Viên";
            dgvDanhsach.Columns[3].HeaderText = "Mã KH";
            dgvDanhsach.Columns[4].HeaderText = "Tổng Tiền";
            dgvDanhsach.Columns[4].Width = 190;
            dgvDanhsach.AllowUserToAddRows = false;
            dgvDanhsach.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            Forms.frmBanHang f = new Forms.frmBanHang();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpDenNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dtpTuNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Lấy thông tin các mặt hàng sẽ bị xóa
                string sql = "SELECT MaSP, SoLuong FROM tblChitietHDBan WHERE MaHDBan = N'" + dgvDanhsach.CurrentRow.Cells["MaHDBan"].Value.ToString() + "'";
                DataTable tbl = ThucThiSQL.DocBang(sql);
                // cập nhật lại số lượng,đơn giá nhập, đơn giá bán
                for (int i = 0; i < tbl.Rows.Count; i++)
                    DelUpdateHang(tbl.Rows[i][0].ToString(), Convert.ToDouble(tbl.Rows[i][1]));
                //xóa chi tiết hóa đơn
                sql = "DELETE tblChiTietHDBan WHERE MaHDBan=N'" + dgvDanhsach.CurrentRow.Cells["MaHDBan"].Value.ToString() + "'";
                ThucThiSQL.CapNhatDuLieu(sql);
                //xóa hóa đơn
                sql = "DELETE tblHDBan WHERE MaHDBan=N'" + dgvDanhsach.CurrentRow.Cells["MaHDBan"].Value.ToString() + "'";
                ThucThiSQL.CapNhatDuLieu(sql);
                Hienthi_luoi();
            }
            if (dgvDanhsach.Rows.Count == 0)
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnInHD.Enabled = false;
            }
        }

        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnInHD.Enabled = false;
            dgvDanhsach.DataSource = null;
            dgvDanhsach.Rows.Clear();
        }

        private void dtpDenNgay_ValueChanged(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnInHD.Enabled = false;
            dgvDanhsach.DataSource = null;
            dgvDanhsach.Rows.Clear();
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
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet); exSheet = exBook.Worksheets[1];
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
            exRange.Range["C2:F2"].Font.Size = 16;
            exRange.Range["C2:F2"].Font.Name = "Times new roman";
            exRange.Range["C2:F2"].Font.Bold = true;
            exRange.Range["C2:F2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:F2"].MergeCells = true;
            exRange.Range["C2:F2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:F2"].Value = "HÓA ĐƠN BÁN";
            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "SELECT a.MaHDBan, a.NgayBan, a.TongTien, b.TenKH, b.Diachi, b.SDT, c.TenNV " +
            "FROM tblHDBan AS a, tblKH AS b, tblNV AS c WHERE a.MaHDBan = N'" + dgvDanhsach.CurrentRow.Cells["MaHDBan"].Value.ToString() +
            "' AND a.MaKH = b.MaKH AND a.MaNV = c.MaNV";
            tblThongtinHD = ThucThiSQL.DocBang(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:C9"].Font.Name = "Times new roman";
            exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Khách hàng:";
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
            "FROM dbo.tblChiTietHDBan AS a , dbo.tblSP AS b WHERE a.MaHDBan = N'" + dgvDanhsach.CurrentRow.Cells["MaHDBan"].Value.ToString() +
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
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][6];
            exSheet.Name = "Hóa Đơn Bán";
            exApp.Visible = true;
        }

        private void frmHDBan_Load(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnInHD.Enabled = false;
        }

        private void dgvDanhsach_Click(object sender, EventArgs e)
        {
            if(dgvDanhsach.Rows.Count==0)
            {
                return;
            }
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnInHD.Enabled = true;
        }
    }
}
