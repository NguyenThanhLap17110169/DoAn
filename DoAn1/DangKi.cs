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
    class DangKi
    {
        public bool insertTaiKhoan(string taikhoan, string matkhau)
        {
            MyDB mydb = new MyDB();
            SqlCommand command = new SqlCommand("INSERT INTO LogIn (TaiKhoan, MatKhau) " +
                "VALUES (@tk, @mk)", mydb.getConnection);
            command.Parameters.Add("@tk", SqlDbType.VarChar).Value = taikhoan;
            command.Parameters.Add("@mk", SqlDbType.VarChar).Value = matkhau;

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
        public bool deleteTaiKhoan(string ma)
        {
            MyDB mydb = new MyDB();
            SqlCommand cmd = new SqlCommand("DELETE FROM LogIn WHERE TaiKhoan = @ma ", mydb.getConnection);
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
    }
}
