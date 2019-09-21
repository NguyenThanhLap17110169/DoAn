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
    class BoPhan
    {
        public bool insertBoPhan(string mabophan, string tenbophan)
        {
            MyDB mydb = new MyDB();
            SqlCommand command = new SqlCommand("INSERT INTO BoPhan (MaBoPhan, TenBoPhan) " +
                "VALUES (@ma, @ten)", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = mabophan;
            command.Parameters.Add("@ten", SqlDbType.VarChar).Value = tenbophan;

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
        public bool deleteBoPhan(string ma)
        {
            MyDB mydb = new MyDB();
            SqlCommand cmd = new SqlCommand("DELETE FROM BoPhan WHERE MaBoPhan = @ma ", mydb.getConnection);
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
        public bool UpdateBoPhan(string mabophan, string tenbophan)
        {
            MyDB mydb = new MyDB();
            SqlCommand command = new SqlCommand("UPDATE BoPhan SET MaBoPhan=@ma,TenBoPhan=@ten WHERE MaBoPhan=@ma", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = mabophan;
            command.Parameters.Add("@ten", SqlDbType.VarChar).Value = tenbophan;
           
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
