using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace DoAn1
{
    class NhanVien
    {
        public bool insertNhanVien(string manv, string hoten, DateTime ngaysinh, string gioitinh, string diachi, string sđt, string trinhdo, string chucvu, string congviec, string phongban, MemoryStream hinhanh)
        {
            MyDB mydb = new MyDB();
            SqlCommand command = new SqlCommand("INSERT INTO NhanVien (MaNV, HoTen, NgaySinh, GioiTinh, DiaChi, SĐT, TrinhDo, ChucVu, CongViec, PhongBan , HinhAnh) " +
                "VALUES (@ma, @ht, @ns, @gt, @dc, @dt, @td, @cv, @c,@pb,@ha)", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = manv;
            command.Parameters.Add("@ht", SqlDbType.VarChar).Value = hoten;
            command.Parameters.Add("@ns", SqlDbType.DateTime).Value = ngaysinh;
            command.Parameters.Add("@gt", SqlDbType.VarChar).Value = gioitinh;
            command.Parameters.Add("@dc", SqlDbType.VarChar).Value = diachi;
            command.Parameters.Add("@dt", SqlDbType.VarChar).Value = sđt;
            command.Parameters.Add("@td", SqlDbType.VarChar).Value = trinhdo;
            command.Parameters.Add("@cv", SqlDbType.VarChar).Value = chucvu;
            command.Parameters.Add("@c", SqlDbType.VarChar).Value = congviec;
            command.Parameters.Add("@pb", SqlDbType.VarChar).Value = phongban;
            command.Parameters.Add("@ha", SqlDbType.Image).Value = hinhanh.ToArray();

            mydb.openConnection();

            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
        public bool deleteNhanVien(string ma)
        {
            MyDB mydb = new MyDB();
            SqlCommand cmd = new SqlCommand("DELETE FROM NhanVien WHERE MaNV = @ma ", mydb.getConnection);
            cmd.Parameters.Add("@ma", SqlDbType.VarChar).Value = ma;
            mydb.openConnection();
            if ((cmd.ExecuteNonQuery() == 1))
            {
                cmd.Dispose();
                mydb.closeConnection();
                return true;
            }
            else
            {
                cmd.Dispose();
                mydb.closeConnection();
                return false;
            }
        }
        public bool UpdateNhanVien(string manv, string hoten, DateTime ngaysinh, string gioitinh, string diachi, string sđt, string trinhdo, string chucvu, string congviec, string phongban, MemoryStream hinhanh)
        {
            MyDB mydb = new MyDB();
            SqlCommand command = new SqlCommand("UPDATE NhanVien SET MaNV=@ma,HoTen=@ht,NgaySinh=@ns,GioiTinh=@gt,DiaChi=@dc,SĐT=@dt,TrinhDo=@td,ChucVu=@cv,CongViec=@c,PhongBan=@pb,HinhAnh=@ha WHERE MaNV=@ma", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = manv;
            command.Parameters.Add("@ht", SqlDbType.VarChar).Value = hoten;
            command.Parameters.Add("@ns", SqlDbType.DateTime).Value = ngaysinh;
            command.Parameters.Add("@gt", SqlDbType.VarChar).Value = gioitinh;
            command.Parameters.Add("@dc", SqlDbType.VarChar).Value = diachi;
            command.Parameters.Add("@dt", SqlDbType.VarChar).Value = sđt;
            command.Parameters.Add("@td", SqlDbType.VarChar).Value = trinhdo;
            command.Parameters.Add("@cv", SqlDbType.VarChar).Value = chucvu;
            command.Parameters.Add("@c", SqlDbType.VarChar).Value = congviec;
            command.Parameters.Add("@pb", SqlDbType.VarChar).Value = phongban;
            command.Parameters.Add("@ha", SqlDbType.Image).Value = hinhanh.ToArray();

            mydb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                command.Dispose();
                mydb.closeConnection();
                return true;
            }
            else
            {
                command.Dispose();
                mydb.closeConnection();
                return false;
            }
        }
    }
}
