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
    class NguoiLaoDong
    {
        public bool insertNguoiLaoDong(string manld, string hoten, DateTime ngaysinh, string gioitinh, string diachi, string sđt, string trinhdo, string chucvu, string chuyenmon, string donvitructhuoc, MemoryStream hinhanh)
        {
            MyDB mydb = new MyDB();
            SqlCommand command = new SqlCommand("INSERT INTO NguoiLaoDong (MaNLD, HoTen, NgaySinh, GioiTinh, DiaChi, SĐT, TrinhDo, ChucVu, ChuyenMon, DonViTrucThuoc , HinhAnh) " +
                "VALUES (@ma, @ht, @ns, @gt, @dc, @dt, @td, @cv, @cm,@dvtt,@ha)", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.NVarChar).Value = manld;
            command.Parameters.Add("@ht", SqlDbType.NVarChar).Value = hoten;
            command.Parameters.Add("@ns", SqlDbType.DateTime).Value = ngaysinh;
            command.Parameters.Add("@gt", SqlDbType.NVarChar).Value = gioitinh;
            command.Parameters.Add("@dc", SqlDbType.NVarChar).Value = diachi;
            command.Parameters.Add("@dt", SqlDbType.NVarChar).Value = sđt;
            command.Parameters.Add("@td", SqlDbType.NVarChar).Value = trinhdo;
            command.Parameters.Add("@cv", SqlDbType.NVarChar).Value = chucvu;
            command.Parameters.Add("@cm", SqlDbType.NVarChar).Value = chuyenmon;
            command.Parameters.Add("@dvtt", SqlDbType.NVarChar).Value = donvitructhuoc;
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
        public bool deleteNguoiLaoDong(string ma)
        {
            MyDB mydb = new MyDB();
            SqlCommand cmd = new SqlCommand("DELETE FROM NguoiLaoDong WHERE MaNLD = @ma ", mydb.getConnection);
            cmd.Parameters.Add("@ma", SqlDbType.NVarChar).Value = ma;
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
        public bool UpdateNguoiLaoDong(string manld, string hoten, DateTime ngaysinh, string gioitinh, string diachi, string sđt, string trinhdo, string chucvu, string chuyenmon, string donvitructhuoc, MemoryStream hinhanh)
        {
            MyDB mydb = new MyDB();
            SqlCommand command = new SqlCommand("UPDATE NguoiLaoDong SET MaNLD=@ma,HoTen=@ht,NgaySinh=@ns,GioiTinh=@gt,DiaChi=@dc,SĐT=@dt,TrinhDo=@td,ChucVu=@cv,ChuyenMon=@cm,DonViTrucThuoc=@dvtt,HinhAnh=@ha WHERE MaNLD=@ma", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.NVarChar).Value = manld;
            command.Parameters.Add("@ht", SqlDbType.NVarChar).Value = hoten;
            command.Parameters.Add("@ns", SqlDbType.DateTime).Value = ngaysinh;
            command.Parameters.Add("@gt", SqlDbType.NVarChar).Value = gioitinh;
            command.Parameters.Add("@dc", SqlDbType.NVarChar).Value = diachi;
            command.Parameters.Add("@dt", SqlDbType.NVarChar).Value = sđt;
            command.Parameters.Add("@td", SqlDbType.NVarChar).Value = trinhdo;
            command.Parameters.Add("@cv", SqlDbType.NVarChar).Value = chucvu;
            command.Parameters.Add("@cm", SqlDbType.NVarChar).Value = chuyenmon;
            command.Parameters.Add("@dvtt", SqlDbType.NVarChar).Value = donvitructhuoc;
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
