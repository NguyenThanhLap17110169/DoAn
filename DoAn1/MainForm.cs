using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Btncongnhan_Click(object sender, EventArgs e)
        {
           
            CongNhanForm cn = new CongNhanForm();
            cn.getdata();
            cn.Refresh1();
            cn.ShowDialog();
        }

        private void Btnkysu_Click(object sender, EventArgs e)
        {
            KySuForm ks = new KySuForm();
            ks.getdata();
            ks.Refresh1();
            ks.ShowDialog();
        }

        private void Btnnhanvien_Click(object sender, EventArgs e)
        {
            NhanVienForm nv = new NhanVienForm();
            nv.getdata();
            nv.Refresh1();
            nv.ShowDialog();
        }

        private void Btnhethong_Click(object sender, EventArgs e)
        {
            HeThongSanXuatForm ht = new HeThongSanXuatForm();
           // ht.getdata();
            ht.ShowDialog();
        }

        private void Btnluong_Click(object sender, EventArgs e)
        {
            SalaryForm s = new SalaryForm();
            s.ShowDialog();
        }
    }
}
