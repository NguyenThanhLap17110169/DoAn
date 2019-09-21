using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn1
{
    public partial class DangKiForm : Form
    {
        public DangKiForm()
        {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            DangKi dk = new DangKi();
            if(verif())
            {
                string tk = txtTaiKhoan.Text;
                string mk1 = txtMatKhau1.Text;
                string mk2 = txtMatKhau2.Text;
                if (dk.insertTaiKhoan(tk, mk1) )
                    MessageBox.Show("New TaiKhoan Added");
                else
                    MessageBox.Show("Error");
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
