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
    public partial class frmBCBanHang : Form
    {
        public frmBCBanHang()
        {
            InitializeComponent();
        }

        private void frmBCBanHang_Load(object sender, EventArgs e)
        {
            txtTongTien.ReadOnly = true;
            btnInHD.Enabled = false;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            
            int sum = 0;
            if (rdoTheoSP.Checked == true)
            {
                string sql = "EXEC proc_BCBanTheoSP N'{0}',N'{1}'";
                sql = string.Format(sql, dtpTuNgay.Value.ToString("yyyy/MM/dd"), dtpDenNgay.Value.ToString("yyyy/MM/dd"));
                DataTable dt = ThucThiSQL.DocBang(sql);
                dgvBCBH.DataSource = dt;
                dgvBCBH.Columns[0].HeaderText = "Mã sản phẩm";
                dgvBCBH.Columns[1].HeaderText = "Tên sản phẩm";
                dgvBCBH.Columns[1].Width = 233;
                dgvBCBH.Columns[2].HeaderText = "Đơn vị tính";
                dgvBCBH.Columns[3].HeaderText = "Tổng số lượng";
                dgvBCBH.Columns[4].HeaderText = "Đơn giá";
                dgvBCBH.Columns[5].HeaderText = "Doanh thu";
                dgvBCBH.AllowUserToAddRows = false;
                dgvBCBH.EditMode = DataGridViewEditMode.EditProgrammatically;
                for (int i = 0; i < dgvBCBH.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dgvBCBH.Rows[i].Cells[5].Value);
                }
            }

            if (rdoTheoDon.Checked == true)
            {
                string sql = "EXEC proc_BCBanTheoHD N'{0}',N'{1}'";
                sql = string.Format(sql, dtpTuNgay.Value.ToString("yyyy/MM/dd"), dtpDenNgay.Value.ToString("yyyy/MM/dd"));
                DataTable dt = ThucThiSQL.DocBang(sql);
                dgvBCBH.DataSource = dt;
                dgvBCBH.Columns[0].HeaderText = "Ngày Bán";
                dgvBCBH.Columns[1].HeaderText = "Hóa Đơn Bán";
                dgvBCBH.Columns[1].Width = 200;
                dgvBCBH.Columns[2].HeaderText = "Mã nhân viên";
                dgvBCBH.Columns[3].HeaderText = "Mã khách hàng";
                dgvBCBH.Columns[4].HeaderText = "Doanh thu";
                dgvBCBH.Columns[4].Width = 233;
                dgvBCBH.AllowUserToAddRows = false;
                dgvBCBH.EditMode = DataGridViewEditMode.EditProgrammatically;
                for (int i = 0; i < dgvBCBH.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dgvBCBH.Rows[i].Cells[4].Value);
                }
            }
            txtTongTien.Text = string.Format("{0:0,0}",sum);
            if (dgvBCBH.Rows.Count == 0)
            {
                btnInHD.Enabled = false;
            }
            else btnInHD.Enabled = true;
        }

        private void rdoTheoDon_CheckedChanged(object sender, EventArgs e)
        {
            btnInHD.Enabled = false;
            txtTongTien.Text = "";
            dgvBCBH.DataSource = null;
            dgvBCBH.Rows.Clear();
        }

        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            btnInHD.Enabled = false;
            txtTongTien.Text = "";
            dgvBCBH.DataSource = null;
            dgvBCBH.Rows.Clear();
        }

        private void dtpDenNgay_ValueChanged(object sender, EventArgs e)
        {
            btnInHD.Enabled = false;
            txtTongTien.Text = "";
            dgvBCBH.DataSource = null;
            dgvBCBH.Rows.Clear();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            if(rdoTheoDon.Checked == true)
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
                exRange.Range["C2:F2"].Font.Size = 16;
                exRange.Range["C2:F2"].Font.Name = "Times new roman";
                exRange.Range["C2:F2"].Font.Bold = true;
                exRange.Range["C2:F2"].Font.ColorIndex = 3; //Màu đỏ
                exRange.Range["C2:F2"].MergeCells = true;
                exRange.Range["C2:F2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["C2:F2"].Value = "BÁO CÁO DOANH THU";
                //Lấy thông tin các mặt hàng
                sql = "EXEC proc_BCBanTheoHD N'{0}',N'{1}'";
                sql = string.Format(sql, dtpTuNgay.Value.ToString("yyyy/MM/dd"), dtpDenNgay.Value.ToString("yyyy/MM/dd"));
                tblThongtinHang = ThucThiSQL.DocBang(sql);
                //Tạo dòng tiêu đề bảng
                exRange.Range["A6:F6"].Font.Bold = true;
                exRange.Range["A6:F6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["C6:D6"].ColumnWidth = 19;
                exRange.Range["E6:E6"].ColumnWidth = 13;
                exRange.Range["F6:F6"].ColumnWidth = 16.67;
                exRange.Range["A6:A6"].Value = "STT";
                exRange.Range["B6:B6"].Value = "Ngày Bán";
                exRange.Range["C6:C6"].Value = "Hóa Đơn Bán";
                exRange.Range["D6:D6"].Value = "Nhân Viên";
                exRange.Range["E6:E6"].Value = "Khách Hàng";
                exRange.Range["F6:F6"].Value = "Doanh Thu";
                for (hang = 0; hang <= tblThongtinHang.Rows.Count - 1; hang++)
                {
                    //Điền số thứ tự vào cột 1 từ dòng 7
                    exSheet.Cells[1][hang + 7] = hang + 1;
                    for (cot = 0; cot <= tblThongtinHang.Columns.Count - 1; cot++)
                        //Điền thông tin hàng từ cột thứ 2, dòng 7
                        exSheet.Cells[cot + 2][hang + 7] = tblThongtinHang.Rows[hang][cot].ToString();
                }
                exRange = exSheet.Cells[cot][hang + 9];
                exRange.Font.Bold = true;
                exRange.Value2 = "Tổng tiền:";
                exRange = exSheet.Cells[cot + 1][hang + 9];
                exRange.Font.Bold = true;
                exRange.Value2 = string.Format("{0:0,0 VNĐ}", double.Parse(txtTongTien.Text));
                exRange = exSheet.Cells[1][hang + 10]; //Ô A1
                exRange.Range["A1:F1"].MergeCells = true;
                exRange.Range["A1:F1"].Font.Bold = true;
                exRange.Range["A1:F1"].Font.Italic = true;
                exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
                exRange.Range["A1:F1"].Value = "Bằng chữ: " + ThucThiSQL.ChuyenSoSangChu(txtTongTien.Text);
                exRange = exSheet.Cells[3][hang + 12]; //Ô A1
                exRange.Range["B1:D1"].MergeCells = true;
                exRange.Range["B1:D1"].Font.Italic = true;
                exRange.Range["B1:D1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                DateTime d = DateTime.Now;
                exRange.Range["B1:D1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
                exRange.Range["B2:D2"].MergeCells = true;
                exRange.Range["B2:D2"].Font.Italic = true;
                exRange.Range["B2:D2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["B2:D2"].Value = "Nhân viên lập báo cáo";
                exSheet.Name = "Báo Cáo Doanh Thu";
                exApp.Visible = true;
            }

            if(rdoTheoSP.Checked==true)
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
                exRange.Range["C2:G2"].Font.Size = 16;
                exRange.Range["C2:G2"].Font.Name = "Times new roman";
                exRange.Range["C2:G2"].Font.Bold = true;
                exRange.Range["C2:G2"].Font.ColorIndex = 3; //Màu đỏ
                exRange.Range["C2:G2"].MergeCells = true;
                exRange.Range["C2:G2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["C2:G2"].Value = "BÁO CÁO DOANH THU";
                //Lấy thông tin các mặt hàng
                sql = "EXEC proc_BCBanTheoSP N'{0}',N'{1}'";
                sql = string.Format(sql, dtpTuNgay.Value.ToString("yyyy/MM/dd"), dtpDenNgay.Value.ToString("yyyy/MM/dd"));
                tblThongtinHang = ThucThiSQL.DocBang(sql);
                //Tạo dòng tiêu đề bảng
                exRange.Range["A6:G6"].Font.Bold = true;
                exRange.Range["A6:G6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["C6:C6"].ColumnWidth = 33;
                exRange.Range["F6:G6"].ColumnWidth = 15;
                exRange.Range["A6:A6"].Value = "STT";
                exRange.Range["B6:B6"].Value = "Mã Sản Phẩm";
                exRange.Range["C6:C6"].Value = "Tên Sản Phẩm";
                exRange.Range["D6:D6"].Value = "ĐVT";
                exRange.Range["E6:E6"].Value = "Tổng SL";
                exRange.Range["F6:F6"].Value = "Đơn Giá";
                exRange.Range["G6:G6"].Value = "Doanh Thu";               
                for (hang = 0; hang <= tblThongtinHang.Rows.Count - 1; hang++)
                {
                    //Điền số thứ tự vào cột 1 từ dòng 7
                    exSheet.Cells[1][hang + 7] = hang + 1;
                    for (cot = 0; cot <= tblThongtinHang.Columns.Count - 1; cot++)
                        //Điền thông tin hàng từ cột thứ 2, dòng 7
                        exSheet.Cells[cot + 2][hang + 7] = tblThongtinHang.Rows[hang][cot].ToString();
                }
                exRange = exSheet.Cells[cot][hang + 9];
                exRange.Font.Bold = true;
                exRange.Value2 = "Tổng tiền:";
                exRange = exSheet.Cells[cot + 1][hang + 9];
                exRange.Font.Bold = true;
                exRange.Value2 = string.Format("{0:0,0 VNĐ}", double.Parse(txtTongTien.Text));
                exRange = exSheet.Cells[1][hang + 10]; //Ô A1
                exRange.Range["A1:G1"].MergeCells = true;
                exRange.Range["A1:G1"].Font.Bold = true;
                exRange.Range["A1:G1"].Font.Italic = true;
                exRange.Range["A1:G1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
                exRange.Range["A1:G1"].Value = "Bằng chữ: " + ThucThiSQL.ChuyenSoSangChu(txtTongTien.Text);
                exRange = exSheet.Cells[3][hang + 12]; //Ô A1
                exRange.Range["C1:E1"].MergeCells = true;
                exRange.Range["C1:E1"].Font.Italic = true;
                exRange.Range["C1:E1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                DateTime d = DateTime.Now;
                exRange.Range["C1:E1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
                exRange.Range["C2:E2"].MergeCells = true;
                exRange.Range["C2:E2"].Font.Italic = true;
                exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["C2:E2"].Value = "Nhân viên lập báo cáo";
                exSheet.Name = "Báo Cáo Doanh Thu";
                exApp.Visible = true;
            }
        }

        private void dtpTuNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dtpDenNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
