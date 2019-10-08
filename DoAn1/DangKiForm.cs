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
    public partial class DangKiForm : Form
    {
        public DangKiForm()
        {
            InitializeComponent();
        }
        bool kiemtraTaiKhoan(string ma)
        {
            MyDB mydb = new MyDB();
            SqlCommand cmd = new SqlCommand("SELECT * FROM KySu WHERE MaKS = @ma ", mydb.getConnection);
            cmd.Parameters.Add("@ma", SqlDbType.NVarChar).Value = ma;
            string str = "SELECT  count (MaKS)  FROM KySu WHERE MaKS = '" + ma + "' ";
            SqlCommand cmd1 = new SqlCommand(str, mydb.getConnection);

            mydb.openConnection();
            int n = (int)cmd1.ExecuteScalar();
            mydb.closeConnection();
            if (n >= 1)
            {
                return false;
            }
            else
                return true;
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            DangKi dk = new DangKi();
            
            if (verif() )
            {
                string tk = txtTaiKhoan.Text;
                string mk1 = txtMatKhau1.Text;
                string mk2 = txtMatKhau2.Text;
                if (kiemtraTaiKhoan(tk) == false)
                {
                    if (dk.insertTaiKhoan(tk, mk1))
                        MessageBox.Show("New TaiKhoan Added");
                    else
                        MessageBox.Show("Error");
                }
                else
                    MessageBox.Show("Đăng Kí Không Thành Công");
            }
            else
                MessageBox.Show("Empty Fields");

        }
        bool verif()
        {
            if ((txtTaiKhoan.Text.Trim() == "")
                || (txtMatKhau1.Text.Trim() == "")
                || (txtMatKhau2.Text.Trim() == ""))
            {
                return false;
            }
            else
                return true;
        }

        private void LabelLogin_Click(object sender, EventArgs e)
        {
            LoginForm l = new LoginForm();
            l.ShowDialog();
        }
    }
}
