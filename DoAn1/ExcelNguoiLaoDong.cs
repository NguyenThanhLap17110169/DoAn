using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DoAn1
{
    class ExcelNguoiLaoDong
    {
        public void ExportExcel(DataTable dt, string SheetName, string title)
        {
            //Tạo các đối tượng trong Excel
            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            Microsoft.Office.Interop.Excel.Sheets oSheets;
            Microsoft.Office.Interop.Excel.Workbook book;
            Microsoft.Office.Interop.Excel.Worksheet sheet;

            //tạo mới 1 Exel WorkBook
            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            oExcel.Application.SheetsInNewWorkbook = 1;
            oBooks = oExcel.Workbooks;

            book = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            oSheets = book.Worksheets;
            sheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
            sheet.Name = SheetName;
            //tạo phần đầu nếu muốn
            Microsoft.Office.Interop.Excel.Range head = sheet.get_Range("A1", "J1");
            head.MergeCells = true;
            head.Value2 = title;
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = "18";
            head.Characters.Font.Color = System.Drawing.Color.Red;

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //Tạo tiêu đề cột
            Microsoft.Office.Interop.Excel.Range cl1 = sheet.get_Range("A3", "A3");
            cl1.Value2 = "Mã Người lao động";
            cl1.ColumnWidth = 18.5;

            Microsoft.Office.Interop.Excel.Range cl2 = sheet.get_Range("B3", "B3");
            cl2.Value2 = "Họ tên người lao động";
            cl2.ColumnWidth = 25.5;

            Microsoft.Office.Interop.Excel.Range cl3 = sheet.get_Range("C3", "C3");
            cl3.Value2 = "Ngày tháng năm sinh";
            cl3.NumberFormat = "m/d/yyyy";
            cl3.ColumnWidth = 25.5;

            Microsoft.Office.Interop.Excel.Range cl4 = sheet.get_Range("D3", "D3");
            cl4.Value2 = "Giới tính";
            cl4.ColumnWidth = 18.5;

            Microsoft.Office.Interop.Excel.Range cl5 = sheet.get_Range("E3", "E3");
            cl5.Value2 = "Địa chỉ";
            cl5.ColumnWidth = 40.0;

            Microsoft.Office.Interop.Excel.Range cl6 = sheet.get_Range("F3", "F3");
            cl6.Value2 = "SĐT";
            cl6.ColumnWidth = 23.5;

            Microsoft.Office.Interop.Excel.Range cl7 = sheet.get_Range("G3", "G3");
            cl7.Value2 = "Trình độ";
            cl7.ColumnWidth = 33.5;

            Microsoft.Office.Interop.Excel.Range cl8 = sheet.get_Range("H3", "H3");
            cl8.Value2 = "Chức vụ";
            cl8.ColumnWidth = 23.0;

            Microsoft.Office.Interop.Excel.Range cl9 = sheet.get_Range("I3", "I3");
            cl9.Value2 = "Chuyên môn";
            cl9.ColumnWidth = 38.5;

            Microsoft.Office.Interop.Excel.Range cl10 = sheet.get_Range("J3", "J3");
            cl10.Value2 = "Đơn vị trực thuộc";
            cl10.ColumnWidth = 30.0;



            Microsoft.Office.Interop.Excel.Range rowHead = sheet.get_Range("A3", "J3");
            rowHead.Font.Bold = true;
            //kẻ viền
            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            //thiết lập màu nền
            rowHead.Interior.ColorIndex = 15;
            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            //tạo mảng đối tượng để lưu trữ toàn bộ dữ liệu trong Database
            //vì dữ liệu đc gán vào các Cell trong Excel phải thông qua object thuần
            object[,] arr = new object[dt.Rows.Count, dt.Columns.Count];
            //chuyển dữ liệu từ Database vào mảng đối tượng
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                DataRow dr = dt.Rows[r];
                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    arr[r, c] = dr[c];
                }
            }
            //thiết lập vùng điền dữ liệu
            int rowStart = 4;
            int columnStart = 1;
            int rowEnd = rowStart + dt.Rows.Count - 1;
            int columnEnd = dt.Columns.Count;
            //Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)sheet.Cells[rowStart, columnStart];
            //Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)sheet.Cells[rowEnd, columnEnd];
            //Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = sheet.get_Range(c1, c2);
            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;

            // Kẻ viền
            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            // Căn giữa cột STT
            Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)sheet.Cells[rowEnd, columnStart];
            Microsoft.Office.Interop.Excel.Range c4 = sheet.get_Range(c1, c3);
            sheet.get_Range(c3, c4).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

        }
    }
}
