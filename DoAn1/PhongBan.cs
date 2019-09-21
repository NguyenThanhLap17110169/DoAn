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
    class PhongBan
    {
        public bool insertPhongBan(string maphongban, string tenphongban)
        {
            MyDB mydb = new MyDB();
            SqlCommand command = new SqlCommand("INSERT INTO PhongBan (MaPhongBan, TenPhongBan) " +
                "VALUES (@ma, @ten)", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = maphongban;
            command.Parameters.Add("@ten", SqlDbType.VarChar).Value = tenphongban;

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
        public bool deletePhongBan(string ma)
        {
            MyDB mydb = new MyDB();
            SqlCommand cmd = new SqlCommand("DELETE FROM PhongBan WHERE MaPhongBan = @ma ", mydb.getConnection);
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
        public bool UpdatePhongBan(string maphongban, string tenphongban)
        {
            MyDB mydb = new MyDB();
            SqlCommand command = new SqlCommand("UPDATE PhongBan SET MaPhongBan=@ma,TenPhongBan=@ten WHERE MaPhongBan=@ma", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = maphongban;
            command.Parameters.Add("@ten", SqlDbType.VarChar).Value = tenphongban;

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
