using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DoAn1
{
    class ExcelLuong
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
            Microsoft.Office.Interop.Excel.Range head = sheet.get_Range("A1", "F1");
            head.MergeCells = true;
            head.Value2 = title;
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = "18";
            head.Characters.Font.Color = System.Drawing.Color.Red;

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //Tạo tiêu đề cột
            Microsoft.Office.Interop.Excel.Range cl1 = sheet.get_Range("A3", "A3");
            cl1.Value2 = "Mã ";
            cl1.ColumnWidth = 18.5;

            Microsoft.Office.Interop.Excel.Range cl2 = sheet.get_Range("B3", "B3");
            cl2.Value2 = "Họ và tên";
            cl2.ColumnWidth = 25.5;

            Microsoft.Office.Interop.Excel.Range cl3 = sheet.get_Range("c3", "c3");
            cl3.Value2 = "Giới tính";
            cl3.ColumnWidth = 18.5;

            Microsoft.Office.Interop.Excel.Range cl5 = sheet.get_Range("E3", "E3");
            cl5.Value2 = "Bộ Phận, Phòng Ban, Tổ";
            cl5.ColumnWidth = 40.0;

            Microsoft.Office.Interop.Excel.Range cl4 = sheet.get_Range("D3", "D3");
            cl4.Value2 = "Chức vụ";
            cl4.ColumnWidth = 23.5;

            Microsoft.Office.Interop.Excel.Range cl6 = sheet.get_Range("F3", "F3");
            cl6.Value2 = "Lương";
            cl6.ColumnWidth = 33.5;


            Microsoft.Office.Interop.Excel.Range rowHead = sheet.get_Range("A3", "F3");
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
