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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        //public DataTable checkLog(string user, string pass)
        //{
        //    MyDB mydb = new MyDB();
        //    SqlCommand command = new SqlCommand(" select * from LogIn, KySu where LogIn.TaiKhoan=KySu.MaKS and KySu.ChucVu='QuanLy'  ;", mydb.getConnection);
        //  //  string sql = "Select * From DangNhap where NguoiDung='" + user + "' and Pass='" + pass + "'";
        //    SqlDataAdapter sda = new SqlDataAdapter();
        //    sda.SelectCommand = command;
        //    DataTable dbdataset = new DataTable();
        //    sda.Fill(dbdataset);
        //    return dbdataset;
        //}
        private void ButtonLOGIN_Click(object sender, EventArgs e)
        {
            StaticValue.ID = txtTaiKhoan.Text;
            MyDB con = new MyDB();
            con.openConnection();
            string tk = txtTaiKhoan.Text;
            string mk = txtPassword.Text;
            string sql = "select * from LogIn, KySu where LogIn.TaiKhoan='" + tk + "' and LogIn.MatKhau= '" + mk + "' and LogIn.TaiKhoan=KySu.MaKS and KySu.ChucVu = N'Quản Lý'";
            SqlCommand cmd = new SqlCommand(sql, con.getConnection);
            SqlDataReader dta = cmd.ExecuteReader();


            if (dta.Read() == true)
            {
                MainForm m = new MainForm();
                m.ShowDialog();
            }
            else
                MessageBox.Show("Invalid Username of Password");
        }

        private void ButtonCANCEL_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            DangKiForm dk = new DangKiForm();
            dk.ShowDialog();
        }
    }
}
