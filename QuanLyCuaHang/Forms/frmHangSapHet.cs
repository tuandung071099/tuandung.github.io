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
    public partial class frmHangSapHet : Form
    {
        public frmHangSapHet()
        {
            InitializeComponent();
        }

        public void Hienthi_luoi()
        {
            string sql = "SELECT MaSP,TenSP,MaLoai,DonViTinh,DonGiaNhap,DonGiaBan,SoLuongTon,GioiHanTon FROM tblSP WHERE SoLuongTon<GioiHanTon/2 AND SoLuongTon<>0";
            DataTable dt = ThucThiSQL.DocBang(sql);
            dgvTonkho.DataSource = dt;
            dgvTonkho.Columns[0].HeaderText = "Mã Sản Phẩm";
            dgvTonkho.Columns[1].HeaderText = "Tên Sản Phẩm";
            dgvTonkho.Columns[2].HeaderText = "Loại Hàng";
            dgvTonkho.Columns[3].HeaderText = "Đơn Vị Tính";
            dgvTonkho.Columns[4].HeaderText = "Giá Nhập";
            dgvTonkho.Columns[4].DefaultCellStyle.Format = "c";
            dgvTonkho.Columns[5].HeaderText = "Giá Bán";
            dgvTonkho.Columns[5].DefaultCellStyle.Format = "c";
            dgvTonkho.Columns[6].HeaderText = "Số Lượng Tồn";
            dgvTonkho.Columns[6].Width = 65;
            dgvTonkho.Columns[7].HeaderText = "Giới Hạn Tồn";
            dgvTonkho.Columns[7].Width = 65;
            dgvTonkho.AllowUserToAddRows = false;
            dgvTonkho.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void frmHangSapHet_Load(object sender, EventArgs e)
        {
            Hienthi_luoi();
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
            DataTable tblThongtinHang;
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
            exRange.Range["C2:I2"].Font.Size = 16;
            exRange.Range["C2:I2"].Font.Name = "Times new roman";
            exRange.Range["C2:I2"].Font.Bold = true;
            exRange.Range["C2:I2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:I2"].MergeCells = true;
            exRange.Range["C2:I2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:I2"].Value = "BÁO CÁO HÀNG SẮP HẾT";
            //Lấy thông tin các mặt hàng
            sql = "SELECT MaSP,TenSP,MaLoai,DonViTinh,DonGiaNhap,DonGiaBan,SoLuongTon,GioiHanTon FROM tblSP WHERE SoLuongTon<GioiHanTon/2 AND SoLuongTon<>0";
            tblThongtinHang = ThucThiSQL.DocBang(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A6:I6"].Font.Bold = true;
            exRange.Range["A6:I6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C6:C6"].ColumnWidth = 31;
            exRange.Range["F6:F6"].ColumnWidth = 19;
            exRange.Range["G6:G6"].ColumnWidth = 19;
            exRange.Range["I6:I6"].ColumnWidth = 13;
            exRange.Range["A6:A6"].Value = "STT";
            exRange.Range["B6:B6"].Value = "Mã SP";
            exRange.Range["C6:C6"].Value = "Tên Sản Phẩm";
            exRange.Range["D6:D6"].Value = "Mã Loại";
            exRange.Range["E6:E6"].Value = "ĐVT";
            exRange.Range["F6:F6"].Value = "Đơn Giá Nhập";
            exRange.Range["G6:G6"].Value = "Đơn Giá Bán";
            exRange.Range["H6:H6"].Value = "Tồn";
            exRange.Range["I6:I6"].Value = "Giới Hạn Tồn";
            for (hang = 0; hang <= tblThongtinHang.Rows.Count - 1; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 7
                exSheet.Cells[1][hang + 7] = hang + 1;
                for (cot = 0; cot <= tblThongtinHang.Columns.Count - 1; cot++)
                    //Điền thông tin hàng từ cột thứ 2, dòng 7
                    exSheet.Cells[cot + 2][hang + 7] = tblThongtinHang.Rows[hang][cot].ToString();
            }
            exRange = exSheet.Cells[3][hang + 9 ]; //Ô A1
            exRange.Range["E1:G1"].MergeCells = true;
            exRange.Range["E1:G1"].Font.Italic = true;
            exRange.Range["E1:G1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = DateTime.Now;
            exRange.Range["E1:G1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["E2:G2"].MergeCells = true;
            exRange.Range["E2:G2"].Font.Italic = true;
            exRange.Range["E2:G2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["E2:G2"].Value = "Nhân viên lập báo cáo";
            exSheet.Name = "Báo Cáo Hàng Sắp Hết";
            exApp.Visible = true;
        }
    }
}
