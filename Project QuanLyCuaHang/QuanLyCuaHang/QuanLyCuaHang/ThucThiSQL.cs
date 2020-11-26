﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang
{
    class ThucThiSQL
    {
        public static SqlConnection conn;
        public static string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" +
            System.IO.Directory.GetCurrentDirectory().ToString() +
            @"\Database\MART.mdf;Integrated Security=True";

        public static void KetNoiCSDL()
        {
            conn = new SqlConnection();
            conn.ConnectionString = connStr;
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

        }

        public static void DongKetNoiCSDL()
        {
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
                conn = null;
            }
        }

        public static DataTable DocBang(string sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            KetNoiCSDL();
            da.SelectCommand.Connection = conn;
            da.SelectCommand.CommandText = sql;
            da.Fill(dt);
            DongKetNoiCSDL();
            return dt;
        }

        public static void CapNhapDuLieu(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            KetNoiCSDL();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            DongKetNoiCSDL();
        }

        public static string AutoGenerate(string first, string tbl)
        {
            DataTable dt = new DataTable();
            dt = ThucThiSQL.DocBang("SELECT * FROM "+tbl+""); // hàm GetAllData trong class NhanVienMod sẽ trả lại 1 Datatable chứa toàn bộ nhân viên.
            int coso = 0;
            if (dt.Rows.Count == 0)// nếu danh sách nhân viên rỗng
            {
                coso = 1;
            }
            else if (dt.Rows.Count == 1 && int.Parse(dt.Rows[0][0].ToString().Substring(2, 3)) == 1) // nếu danh sách nhân viên có 1 nhân viên và mã người này là NV001
            {
                coso = 2;
            }
            else if (dt.Rows.Count == 1 && int.Parse(dt.Rows[0][0].ToString().Substring(2, 3)) > 1) // nếu danh sách có 1 nhân viên mà mã người này khác NV001
            {
                coso = 1;
            }
            else // nếu danh sách có hơn 1 nhân viên
            {
                for (int i = 0; i < dt.Rows.Count - 1; i++)
                {
                    if (int.Parse(dt.Rows[i + 1][0].ToString().Substring(2, 3)) - int.Parse(dt.Rows[i][0].ToString().Substring(2, 3)) > 1)
                    {
                        coso = int.Parse(dt.Rows[i][0].ToString().Substring(2, 3)) + 1;
                        break;
                    }
                }
                coso = int.Parse(dt.Rows[dt.Rows.Count - 1][0].ToString().Substring(2, 3)) + 1;
            }
            string ma = "";
            if (coso < 10)
                ma = "" + first + "00" + coso;
            else if (coso < 100)
                ma = "" + first + "0" + coso;
            else
                ma = "" + first + "" + coso;
            return ma;
        }

        public static string AutoGenerate2(string first, string tbl)
        {
            DataTable dt = new DataTable();
            dt = ThucThiSQL.DocBang("SELECT * FROM " + tbl + ""); // hàm GetAllData trong class NhanVienMod sẽ trả lại 1 Datatable chứa toàn bộ nhân viên.
            int coso = 0;
            if (dt.Rows.Count == 0)// nếu danh sách nhân viên rỗng
            {
                coso = 1;
            }
            else if (dt.Rows.Count == 1 && int.Parse(dt.Rows[0][0].ToString().Substring(3, 3)) == 1) // nếu danh sách nhân viên có 1 nhân viên và mã người này là NV001
            {
                coso = 2;
            }
            else if (dt.Rows.Count == 1 && int.Parse(dt.Rows[0][0].ToString().Substring(3, 3)) > 1) // nếu danh sách có 1 nhân viên mà mã người này khác NV001
            {
                coso = 1;
            }
            else // nếu danh sách có hơn 1 nhân viên
            {
                for (int i = 0; i < dt.Rows.Count - 1; i++)
                {
                    if (int.Parse(dt.Rows[i + 1][0].ToString().Substring(3, 3)) - int.Parse(dt.Rows[i][0].ToString().Substring(3, 3)) > 1)
                    {
                        coso = int.Parse(dt.Rows[i][0].ToString().Substring(3, 3)) + 1;
                        break;
                    }
                }
                coso = int.Parse(dt.Rows[dt.Rows.Count - 1][0].ToString().Substring(3, 3)) + 1;
            }
            string ma = "";
            if (coso < 10)
                ma = "" + first + "00" + coso;
            else if (coso < 100)
                ma = "" + first + "0" + coso;
            else
                ma = "" + first + "" + coso;
            return ma;
        }

        //Hàm chuyển đổi thời gian từ dạng PM sang dạng 24h 
        public static string ConvertTimeTo24(string hour)
        {
            string h = "";
            switch (hour)
            {
                case "1":
                    h = "13";
                    break;
                case "2":
                    h = "14";
                    break;
                case "3":
                    h = "15";
                    break;
                case "4":
                    h = "16";
                    break;
                case "5":
                    h = "17";
                    break;
                case "6":
                    h = "18";
                    break;
                case "7":
                    h = "19";
                    break;
                case "8":
                    h = "20";
                    break;
                case "9":
                    h = "21";
                    break;
                case "10":
                    h = "22";
                    break;
                case "11":
                    h = "23";
                    break;
                case "12":
                    h = "24";
                    break;
            }
            return h;
        }

        public static string CreateKey(string tiento)
        {
            string key = tiento;
            string[] partsDay;
            partsDay = DateTime.Now.ToShortDateString().Split('/');
            //Ví dụ 07/08/2009
            string d = String.Format("{0}{1}{2}", partsDay[0], partsDay[1], partsDay[2]);
            key = key + d;
            string[] partsTime;
            partsTime = DateTime.Now.ToLongTimeString().Split(':');
            //Ví dụ 7:08:03 PM hoặc 7:08:03 AM
            if (partsTime[2].Substring(3, 2) == "PM")
                partsTime[0] = ConvertTimeTo24(partsTime[0]);
            if (partsTime[2].Substring(3, 2) == "AM")
            {
                if (partsTime[0].Length == 1)
                    partsTime[0] = "0" + partsTime[0];
            }
            //Xóa kí tự trắng và PM hoặc AM
            partsTime[2] = partsTime[2].Remove(2, 3);
            string t;
            t = String.Format("_{0}{1}{2}", partsTime[0], partsTime[1], partsTime[2]);
            key = key + t;
            return key;
        }

        public static string ChuyenSoSangChu(string sNumber)
        {
            int mLen, mDigit;
            string mTemp = "";
            string[] mNumText;
            //Xóa các dấu "," nếu có
            sNumber = sNumber.Replace(",", "");
            mNumText = "không;một;hai;ba;bốn;năm;sáu;bảy;tám;chín".Split(';');
            mLen = sNumber.Length - 1; // trừ 1 vì thứ tự đi từ 0
            for (int i = 0; i <= mLen; i++)
            {
                mDigit = Convert.ToInt32(sNumber.Substring(i, 1));
                mTemp = mTemp + " " + mNumText[mDigit];
                if (mLen == i) // Chữ số cuối cùng không cần xét tiếp
                    break;
                switch ((mLen - i) % 9)
                {
                    case 0:
                        mTemp = mTemp + " tỷ";
                        if (sNumber.Substring(i + 1, 3) == "000")
                            i = i + 3;
                        if (sNumber.Substring(i + 1, 3) == "000")
                            i = i + 3;
                        if (sNumber.Substring(i + 1, 3) == "000")
                            i = i + 3;
                        break;
                    case 6:
                        mTemp = mTemp + " triệu";
                        if (sNumber.Substring(i + 1, 3) == "000")
                            i = i + 3;
                        if (sNumber.Substring(i + 1, 3) == "000")
                            i = i + 3;
                        break;
                    case 3:
                        mTemp = mTemp + " nghìn";
                        if (sNumber.Substring(i + 1, 3) == "000")
                            i = i + 3;
                        break;
                    default:
                        switch ((mLen - i) % 3)
                        {
                            case 2:
                                mTemp = mTemp + " trăm";
                                break;
                            case 1:
                                mTemp = mTemp + " mươi";
                                break;
                        }
                        break;
                }
            }
            //Loại bỏ trường hợp x00
            mTemp = mTemp.Replace("không mươi không ", "");
            mTemp = mTemp.Replace("không mươi không", "");
            //Loại bỏ trường hợp 00x
            mTemp = mTemp.Replace("không mươi ", "linh ");
            //Loại bỏ trường hợp x0, x>=2
            mTemp = mTemp.Replace("mươi không", "mươi");
            //Fix trường hợp 10
            mTemp = mTemp.Replace("một mươi", "mười");
            //Fix trường hợp x4, x>=2
            mTemp = mTemp.Replace("mươi bốn", "mươi tư");
            //Fix trường hợp x04
            mTemp = mTemp.Replace("linh bốn", "linh tư");
            //Fix trường hợp x5, x>=2
            mTemp = mTemp.Replace("mươi năm", "mươi lăm");
            //Fix trường hợp x1, x>=2
            mTemp = mTemp.Replace("mươi một", "mươi mốt");
            //Fix trường hợp x15
            mTemp = mTemp.Replace("mười năm", "mười lăm");
            //Bỏ ký tự space
            mTemp = mTemp.Trim();
            //Viết hoa ký tự đầu tiên
            mTemp = mTemp.Substring(0, 1).ToUpper() + mTemp.Substring(1) + " đồng";
            return mTemp;
        }
    }
}
