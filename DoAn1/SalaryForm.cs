using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn1
{
    public partial class SalaryForm : Form
    {
        public SalaryForm()
        {
            InitializeComponent();
            DataGridView1.ReadOnly = true;
            DataGridView1.RowTemplate.Height = 50;
            DataGridView1.AllowUserToAddRows = false;
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            MyDB mydb = new MyDB();
            clear();
            SqlCommand command = new SqlCommand("SELECT KySu.MaKS, KySu.HoTen, KySu.GioiTinh, KySu.ChucVu, KySu.BoPhan, Luong.Luong FROM KySu, Luong WHERE KySu.ChucVu=Luong.Ma", mydb.getConnection);
            mydb.openConnection();
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            if (table.Rows.Count > 0)
            {
                try
                {
                    BindingSource bsource = new BindingSource();   //dong nay xuat hien khi dua datasource vao
                    bsource.DataSource = table;
                    DataGridView1.DataSource = bsource;
                    //ExcelNV exnv = new ExcelNV();
                    //exnv.ExportExcel(table, "Nhân Viên", "Danh sách nhân viên cần tìm");
                    // đếm nhân viên
                    //   labelTotalNhanVien.Text = ("Tổng Nhân Viên trong danh sách: " + DataGridView1.RowCount);
                    mydb.closeConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Not Found");
            }
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            MyDB mydb = new MyDB();
            clear();
            SqlCommand command = new SqlCommand("SELECT CongNhan.MaCN, CongNhan.HoTen, CongNhan.GioiTinh, CongNhan.ChucVu, CongNhan.Nhom, Luong.Luong FROM CongNhan, Luong WHERE CongNhan.ChucVu=Luong.Ma", mydb.getConnection);
            mydb.openConnection();
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            if (table.Rows.Count > 0)
            {
                try
                {
                    BindingSource bsource = new BindingSource();   //dong nay xuat hien khi dua datasource vao
                    bsource.DataSource = table;
                    DataGridView1.DataSource = bsource;
                    //ExcelNV exnv = new ExcelNV();
                    //exnv.ExportExcel(table, "Nhân Viên", "Danh sách nhân viên cần tìm");
                    // đếm nhân viên
                    //   labelTotalNhanVien.Text = ("Tổng Nhân Viên trong danh sách: " + DataGridView1.RowCount);
                    mydb.closeConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Not Found");
            }
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            MyDB mydb = new MyDB();
            clear();
            SqlCommand command = new SqlCommand("SELECT NhanVien.MaNV,NhanVien.HoTen, NhanVien.GioiTinh, NhanVien.ChucVu, NhanVien.PhongBan, Luong.Luong FROM NhanVien, Luong WHERE NhanVien.ChucVu=Luong.Ma", mydb.getConnection);
            mydb.openConnection();
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            if (table.Rows.Count > 0)
            {
                try
                {
                    BindingSource bsource = new BindingSource();   //dong nay xuat hien khi dua datasource vao
                    bsource.DataSource = table;
                    DataGridView1.DataSource = bsource;
                    //ExcelNV exnv = new ExcelNV();
                    //exnv.ExportExcel(table, "Nhân Viên", "Danh sách nhân viên cần tìm");
                    // đếm nhân viên
                    //   labelTotalNhanVien.Text = ("Tổng Nhân Viên trong danh sách: " + DataGridView1.RowCount);
                    mydb.closeConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Not Found");
            }
        }

        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            txtMa.Text = DataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtHoTen.Text = DataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtBPN.Text = DataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtChucVu.Text = DataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtLuong.Text = DataGridView1.CurrentRow.Cells[5].Value.ToString();
            string gender = DataGridView1.CurrentRow.Cells[2].Value.ToString();
            string gender1 = "Nu";
            int flag = 1;
            for (int i = 0; i < gender1.Length; i++)
            {
                if (gender[i] != gender1[i])
                {
                    flag = 0;
                    break;
                }
            }
            if (flag == 1)
            {
                radioButtonFemale.Checked = true;
            }
            else
            {
                radioButtonMale.Checked = true;
            }
        }
        void clear()
        {
            txtMa.Clear();
            txtHoTen.Clear();
            txtBPN.Clear();
            txtChucVu.Clear();
            txtLuong.Clear();
            radioButtonMale.Checked = true;
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            MyDB mydb = new MyDB();
            if(radioButton1.Checked == true)
            {
                SqlCommand command = new SqlCommand("SELECT KySu.MaKS, KySu.HoTen, KySu.GioiTinh, KySu.ChucVu, KySu.BoPhan, Luong.Luong FROM KySu, Luong WHERE KySu.ChucVu=Luong.Ma and CONCAT(KySu.HoTen,KySu.ChucVu,KySu.BoPhan) LIKE N'%" + textBoxSearch.Text + "%'", mydb.getConnection);
                mydb.openConnection();
                DataTable table = new DataTable();
                table.Load(command.ExecuteReader());
                if (table.Rows.Count > 0)
                {
                    try
                    {
                        BindingSource bsource = new BindingSource();   //dong nay xuat hien khi dua datasource vao
                        bsource.DataSource = table;
                        DataGridView1.DataSource = bsource;
                        ExcelLuong exks = new ExcelLuong();
                        exks.ExportExcel(table, "Kỹ sư", "Danh sách kỹ sư cần tìm");
                        // đếm nhân viên
                        //   labelTotalNhanVien.Text = ("Tổng Nhân Viên trong danh sách: " + DataGridView1.RowCount);
                        mydb.closeConnection();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Not Found");
                }
            }
            if (radioButton2.Checked == true)
            {
                SqlCommand command = new SqlCommand("SELECT NhanVien.MaNV,NhanVien.HoTen, NhanVien.GioiTinh, NhanVien.ChucVu, NhanVien.PhongBan, Luong.Luong FROM NhanVien, Luong WHERE NhanVien.ChucVu=Luong.Ma and CONCAT(HoTen,ChucVu,PhongBan) LIKE'%" + textBoxSearch.Text + "%'", mydb.getConnection);
                mydb.openConnection();
                DataTable table = new DataTable();
                table.Load(command.ExecuteReader());
                if (table.Rows.Count > 0)
                {
                    try
                    {
                        BindingSource bsource = new BindingSource();   //dong nay xuat hien khi dua datasource vao
                        bsource.DataSource = table;
                        DataGridView1.DataSource = bsource;
                        ExcelLuong exnv = new ExcelLuong();
                        exnv.ExportExcel(table, "Nhân Viên", "Danh sách nhân viên cần tìm");
                        // đếm nhân viên
                        //   labelTotalNhanVien.Text = ("Tổng Nhân Viên trong danh sách: " + DataGridView1.RowCount);
                        mydb.closeConnection();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Not Found");
                }
            }
            if (radioButton3.Checked == true)
            {
                SqlCommand command = new SqlCommand("SELECT CongNhan.MaCN,CongNhan.HoTen, CongNhan.GioiTinh, CongNhan.ChucVu, CongNhan.Nhom, Luong.Luong FROM CongNhan, Luong WHERE CongNhan.ChucVu=Luong.Ma and CONCAT(HoTen,ChucVu,Nhom) LIKE'%" + textBoxSearch.Text + "%'", mydb.getConnection);
                mydb.openConnection();
                DataTable table = new DataTable();
                table.Load(command.ExecuteReader());
                if (table.Rows.Count > 0)
                {
                    try
                    {
                        BindingSource bsource = new BindingSource();   //dong nay xuat hien khi dua datasource vao
                        bsource.DataSource = table;
                        DataGridView1.DataSource = bsource;
                        ExcelLuong excn = new ExcelLuong();
                        excn.ExportExcel(table, "Công nhân", "Danh sách công nhân cần tìm");
                        // đếm nhân viên
                        //   labelTotalNhanVien.Text = ("Tổng Nhân Viên trong danh sách: " + DataGridView1.RowCount);
                        mydb.closeConnection();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Not Found");
                }
            }
        }
    }
}
