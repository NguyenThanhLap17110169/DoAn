using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DoAn1
{
    class MyDB
    {
        SqlConnection cn = new SqlConnection(@"Data Source=(local);Initial Catalog=QuanLyNhanSu;Integrated Security=True");
        public SqlConnection getConnection
        {
            get
            {
                return cn;
            }
        }
        public void openConnection()
        {
            if ((cn.State == ConnectionState.Closed))
                cn.Open();
        }
        public void closeConnection()
        {
            if ((cn.State == ConnectionState.Open))
                cn.Close();
        }
    }
}
