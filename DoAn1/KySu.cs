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
    class KySu
    {
        public bool insertKySu(string maks, string hoten, DateTime ngaysinh, string gioitinh, string diachi, string sđt, string trinhdo, string chucvu, string nganhdaotao, string bophan, MemoryStream hinhanh)
        {
            MyDB mydb = new MyDB();
            SqlCommand command = new SqlCommand("INSERT INTO KySu (MaKS, HoTen, NgaySinh, GioiTinh, DiaChi, SĐT, TrinhDo, ChucVu, NganhDaoTao, BoPhan , HinhAnh) " +
                "VALUES (@ma, @ht, @ns, @gt, @dc, @dt, @td, @cv, @ndt,@bp,@ha)", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.NVarChar).Value = maks;
            command.Parameters.Add("@ht", SqlDbType.NVarChar).Value = hoten;
            command.Parameters.Add("@ns", SqlDbType.DateTime).Value = ngaysinh;
            command.Parameters.Add("@gt", SqlDbType.NVarChar).Value = gioitinh;
            command.Parameters.Add("@dc", SqlDbType.NVarChar).Value = diachi;
            command.Parameters.Add("@dt", SqlDbType.NVarChar).Value = sđt;
            command.Parameters.Add("@td", SqlDbType.NVarChar).Value = trinhdo;
            command.Parameters.Add("@cv", SqlDbType.NVarChar).Value = chucvu;
            command.Parameters.Add("@ndt", SqlDbType.NVarChar).Value = nganhdaotao;
            command.Parameters.Add("@bp", SqlDbType.NVarChar).Value = bophan;
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
        public bool deleteKySu(string ma)
        {
            MyDB mydb = new MyDB();
            SqlCommand cmd = new SqlCommand("DELETE FROM KySu WHERE MaKS = @ma ", mydb.getConnection);
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
        public bool UpdateKySu(string maks, string hoten, DateTime ngaysinh, string gioitinh, string diachi, string sđt, string trinhdo, string chucvu, string nganhdaotao, string bophan, MemoryStream hinhanh)
        {
            MyDB mydb = new MyDB();
            SqlCommand command = new SqlCommand("UPDATE KySu SET MaKS=@ma,HoTen=@ht,NgaySinh=@ns,GioiTinh=@gt,DiaChi=@dc,SĐT=@dt,TrinhDo=@td,ChucVu=@cv,NganhDaoTao=@ndt,BoPhan=@bp,HinhAnh=@ha WHERE MaKS=@ma", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.NVarChar).Value = maks;
            command.Parameters.Add("@ht", SqlDbType.NVarChar).Value = hoten;
            command.Parameters.Add("@ns", SqlDbType.DateTime).Value = ngaysinh;
            command.Parameters.Add("@gt", SqlDbType.NVarChar).Value = gioitinh;
            command.Parameters.Add("@dc", SqlDbType.NVarChar).Value = diachi;
            command.Parameters.Add("@dt", SqlDbType.NVarChar).Value = sđt;
            command.Parameters.Add("@td", SqlDbType.NVarChar).Value = trinhdo;
            command.Parameters.Add("@cv", SqlDbType.NVarChar).Value = chucvu;
            command.Parameters.Add("@ndt", SqlDbType.NVarChar).Value = nganhdaotao;
            command.Parameters.Add("@bp", SqlDbType.NVarChar).Value = bophan;
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
